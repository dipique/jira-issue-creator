using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace Jira_Issue_Creator
{
    public class JiraIssue
    {
        [JSONField("project", "{{ \"key\": \"{0}\" }}")]
        public string Project { get; set; }

        [JSONField("customfield_11501", "{{ \"value\": \"{0}\" }}")]
        public string FoundIn { get; set; }

        [JSONField("customfield_11000")]
        public string StepsToReproduce { get; set; }

        [JSONField("components", "[{{  \"name\": \"{0}\" }}]")]
        public string Components { get; set; }

        [JSONField("versions", "[{{  \"name\": \"{0}\" }}]")]
        public string Versions { get; set; }

        [JSONField("summary")]
        public string Summary { get; set; }

        [JSONField("description")]
        public string Description { get; set; }

        [JSONField("issuetype", "{{ \"name\": \"{0}\" }}")]
        public string IssueType { get; set; }

        public string IssueKey { get; set; }
        public string JiraBaseURL { get; set; }
        private string JiraAttachURL => $"{JiraBaseURL}{IssueKey}/attachments";

        private List<JiraAttachment> Attachments { get; set; } = new List<JiraAttachment>();
        
        public void ForceSingleAttachment(string filename)
        {
            Attachments.RemoveAll(j => j.Filename != filename);
            if (!Attachments.Any())
            {
                Attachments.Add(new JiraAttachment(filename));
            }
        }

        public string Submit(string jiraBaseURL, string credentialString)
        {
            Credentials = credentialString;
            JiraBaseURL = jiraBaseURL;

            //generate json
            string json = string.Empty;
            try { json = this.GetJson(); }
            catch (Exception ex)
            {
                return $"Error trying to generate json request: {ex.Data}";
            }

            //prepare request
            var request = WebRequest.Create(JiraBaseURL) as HttpWebRequest;
            if (request == null) return $"Unable to create REST query: {JiraBaseURL}";
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", $"Basic {Credentials}");
            request.Accept = "application/json";
            using (var requestStream = new StreamWriter(request.GetRequestStream()))
            {
                requestStream.Write(json);
                requestStream.Flush();
                requestStream.Close();
            }

            //submit request            
            string retVal = string.Empty;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    var serializer = new DataContractJsonSerializer(typeof(JiraCreateIssueResult));
                    var sResult = (JiraCreateIssueResult)serializer.ReadObject(stream);
                    IssueKey = sResult.key;
                    retVal = $"Successfully submitted issue ID {IssueKey}!";
                }
            }
            catch (WebException e)
            {
                var httpResponse = (HttpWebResponse)e.Response;
                string err = $"Error submitting request: {httpResponse.StatusCode} - {httpResponse.StatusDescription}";
                return err += Environment.NewLine + new StreamReader(httpResponse.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                return $"Error submitting request: {ex.Data}";
            }

            //check if attachments need to be submitted
            if (Attachments.Any())
            {
                retVal += Environment.NewLine + SubmitAttachments();
            }

            return retVal;
        }

        public static string GetCredentialString(string username, string password) => 
            Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}:{password}"));

        private string Credentials { get; set; }

        public void AddAttachment(string filepath, bool deleteAfterSubmit = false) => Attachments.Add(new JiraAttachment(filepath, deleteAfterSubmit));

        public string AddAttachment(IDataObject data)
        {
            //check for drag/dropped files first
            var files = (string[])data.GetData(DataFormats.FileDrop);
            if (files != null)
            {
                if (files.Length > 1) return string.Empty; //invalid; we only support one attachment
                Attachments.Add(new JiraAttachment(files[0]));
                return files[0];
            }

            //then check for outlook drag/drops
            try
            {
                var odo = new OutlookDataObject(data);
                string filename = odo.SaveToFile();
                Attachments.Add(new JiraAttachment(filename, true));
                return filename;
            }
            catch
            {
                return string.Empty;
            }
        }

        private string SubmitAttachments()
        {
            if (string.IsNullOrEmpty(Credentials)) return "Credentials must be set before adding attachments.";
            if (string.IsNullOrEmpty(IssueKey)) return "Issue Key must be set before adding attachments.";

            //take attachment list and validate
            var filesToUpload = new List<FileInfo>();
            var retStrings = new List<string>();
            foreach (JiraAttachment attach in Attachments)
            {
                string err = attach.GetValidation();

                if (err == string.Empty)
                    filesToUpload.Add(attach.GetFileInfo());
                else
                    retStrings.Add(err);                    
            }

            //attempt to upload valid files
            if (filesToUpload.Any())
            {
                string errString = PostMultiPart(JiraAttachURL, filesToUpload);
                retStrings.Add(errString == string.Empty ? "Attachment(s) successful!" : errString);                
            }
            else
            {
                retStrings.Add("No valid files found for upload.");
            }

            return string.Join(Environment.NewLine, retStrings);
        }

        /// <summary>
        /// Posts a multi-part message to the specified URL. Specific to Atlassian's requirements for
        /// Jira attachments. Supports multiple attachments as-is.
        /// </summary>
        /// <param name="restUrl"></param>
        /// <param name="filePaths"></param>
        /// <returns>String.Empty if successful, error string otherwise.</returns>
        private string PostMultiPart(string restUrl, IEnumerable<FileInfo> filePaths)
        {
            HttpWebResponse response = null;
            HttpWebRequest request = null;

            try
            {
                string boundary = string.Format("----------{0:N}", Guid.NewGuid());
                var content = new MemoryStream();
                var writer = new StreamWriter(content);

                foreach (FileInfo filePath in filePaths)
                {
                    var fs = new FileStream(filePath.FullName, FileMode.Open, FileAccess.Read);
                    var data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                    fs.Close();

                    writer.WriteLine("--{0}", boundary);
                    writer.WriteLine($"Content-Disposition: form-data; name=\"file\"; filename=\"{filePath.Name}\"");
                    writer.WriteLine("Content-Type: application/octet-stream");
                    writer.WriteLine();
                    writer.Flush();

                    content.Write(data, 0, data.Length);

                    writer.WriteLine();
                }

                writer.WriteLine("--" + boundary + "--");
                writer.Flush();
                content.Seek(0, SeekOrigin.Begin);

                request = WebRequest.Create(restUrl) as HttpWebRequest;
                if (request == null)
                {
                    return string.Format("Unable to create REST query: {0}", restUrl);
                }

                request.Method = "POST";
                request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
                request.Accept = "application/json";                
                request.Headers.Add("Authorization", "Basic " + Credentials);
                request.Headers.Add("X-Atlassian-Token", "nocheck");
                request.ContentLength = content.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    content.WriteTo(requestStream);
                    requestStream.Close();
                }

                using (response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var reader = new StreamReader(response.GetResponseStream());
                        return string.Format("The server returned '{0}'\n{1}).", response.StatusCode, reader.ReadToEnd());
                    }

                    return string.Empty; //success
                }
            }
            catch (WebException wex)
            {
                string errorMsg = null;
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        var reader = new StreamReader(errorResponse.GetResponseStream());
                        errorMsg = string.Format("The server returned '{0}'\n{1}).", errorResponse.StatusCode, reader.ReadToEnd());
                    }
                }

                if (request != null) request.Abort();
                return errorMsg ?? $"Exception encountered: {wex.Data}";
            }
            finally { if (response != null) response.Close(); }
        }
    }

    public class JiraAttachment
    {
        const long MAX_ATTACH_LENGTH = 10485760; //(10MB)

        public string Filename { get; set; }
        public bool DeleteAfterSubmit { get; set; }
        public JiraAttachment(string filename, bool deleteAfterSubmit = false)
        {
            Filename = filename;
            DeleteAfterSubmit = deleteAfterSubmit;
        }
        
        private FileInfo fileInfo { get; set; }
        public FileInfo GetFileInfo()
        {
            if (fileInfo == null)
            {
                fileInfo = new FileInfo(Filename);
            }
            return fileInfo;
        }

        /// <summary>
        /// Checks whether attachment is valid. Empty string if valid, otherwise error message.
        /// </summary>
        /// <returns></returns>
        public string GetValidation()
        {
            if (!GetFileInfo().Exists)
            {
                return $"File not found: '{Filename}'";
            }
            if (GetFileInfo().Length > MAX_ATTACH_LENGTH)
            {
                return $"Attachment '{Filename}' too large.";
            }
            return string.Empty;
        }
    }

    public class JiraCreateIssueResult
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
    }

    public static class JSONIssueExtensions
    {
        private const string DELIM = ",";
        private const string ISSUE_TEMPLATE = "{{ \"fields\": {{ {0} }} }}";
        private const string FIELDNAME_TEMPLATE = "\"{0}\": ";
        public static string GetJson(this JiraIssue issue)
        {
            IEnumerable<PropertyInfo> properties = issue.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                            .Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(JSONField)));
            string fieldString = string.Join(DELIM, properties.Select(p => string.Format(FIELDNAME_TEMPLATE, JSONField.GetFieldName(p)) +
                                                                        string.Format(JSONField.GetTemplate(p), p.GetValue(issue))));
            return string.Format(ISSUE_TEMPLATE, fieldString);
        }
    }

    class JSONField: Attribute
    {
        public string FieldName { get; set; }
        public string FieldTemplate { get; set; }

        public JSONField(string fieldName, string fieldTemplate = null)
        {
            FieldName = fieldName;
            if (string.IsNullOrEmpty(fieldTemplate))
            {
                FieldTemplate = "\"{0}\"";
            }
            else
            {
                FieldTemplate = fieldTemplate;
            }
        }

        public static string GetTemplate(PropertyInfo p) => ((JSONField)p.GetCustomAttribute(typeof(JSONField)))?.FieldTemplate;
        public static string GetFieldName(PropertyInfo p) => ((JSONField)p.GetCustomAttribute(typeof(JSONField)))?.FieldName;
    }
}
