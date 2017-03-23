using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jira_Issue_Creator
{
    class INIFile
    {        
        private const string CsCommentIndicator = "//";
        public List<string[]> Values = new List<string[]>();
        private const string CsIniDelim = "=";
        private const char ARRAY_SEP = '|';

        public INIFile(string filename)
        {
            var sParams = new List<string[]>();
            if (File.Exists(filename))
            {
                try
                {
                    //Load all parameters
                    using (var sr = new StreamReader(filename))
                    {
                        string line;
                        string[] sCurrentParam;
                        while ((line = sr.ReadLine()) != null)
                            if (IsValidParam(line, out sCurrentParam))
                                sParams.Add(sCurrentParam);
                        Values = sParams;

                        sr.Close();
                    }
                    return; //successful
                }
                catch (Exception ex)
                {
                    throw new Exception("INI file failed to load. See inner exception for details.", ex);
                }
            }

            //If we get here, the file wasn't found
            throw new Exception("INI file failed to load.");
        }

        private static bool IsValidParam(string value, out string[] sParam)
        {
            var retVal = new string[2];
            sParam = retVal;

            //Figure out if we have valid info
            if (value.Length < 3) return false; //The shortest allowable line is 3 characters
            if (value.Substring(0, 2) == CsCommentIndicator) return false; //removes comments
            var delimIndex = value.IndexOf(CsIniDelim, StringComparison.Ordinal);
            if (delimIndex == -1) return false;

            //It looks like we found a parameter.  Return the values
            retVal[0] = value.Substring(0, delimIndex); //get the parameter name
            if ((delimIndex + 1) != value.Length) //if not a line like Value=
                retVal[1] = value.Substring(delimIndex + 1); //get the parameter value

            sParam = retVal; //update if we found something
            return true; //if we made it this far, it's valid
        }

        public string GetIni(string paramName)
        {
            var sParam = Values.FirstOrDefault(t => t[0].ToUpper() == paramName.ToUpper());
            return sParam?.GetUpperBound(0) == 1 ? sParam[1] : string.Empty;
        }

        public long GetIniAsNumber(string paramName)
        {
            long retVal;
            var stringValue = GetIni(paramName);
            return (long.TryParse(stringValue, out retVal)) ? retVal : 0;
            //try to convert to a number, or return 0 otherwise
        }

        public string[] GetIniAsArray(string paramName)
        {
            var sParam = Values.FirstOrDefault(t => t[0].ToUpper() == paramName.ToUpper());
            return sParam?.GetUpperBound(0) == 1 ? sParam[1].Split(ARRAY_SEP) : null;
        }
    }
}
