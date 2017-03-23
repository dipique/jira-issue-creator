using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Jira_Issue_Creator
{
    public partial class fmrMain : Form
    {
        private const string JIRA_LINK_ROOT = "http://jira.zalecorp.com:9000/browse/"; //add key to get full URL, e.g. REP-357
        private const string STATE_FILENAME = "state.xml";
        private const string INI_FILENAME = "settings.ini";
        JiraIssue jiraIssue = new JiraIssue();
        INIFile Settings = null;

        public fmrMain()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            try
            {
                //check attachments
                if (!string.IsNullOrWhiteSpace(txtAttachment.Text))
                    jiraIssue.ForceSingleAttachment(txtAttachment.Text);

                //populate the jira issue
                FillJiraFromForm();

                //submit the issue and attachment0
                string result = jiraIssue.Submit(txtJiraURL.Text, txtPassword.Text);
                if (string.IsNullOrEmpty(jiraIssue.IssueKey))
                {
                    result = $"Issue creation failed.\r\n{result}";
                    lnkIssue.Text = string.Empty;
                }
                else
                {
                    lnkIssue.Text = $"{JIRA_LINK_ROOT}{jiraIssue.IssueKey}";
                    ResetMarkedFields();
                }
                MessageBox.Show(result);
            }
            catch (Exception ex) { MessageBox.Show($"Error in submission: {ex.Data}"); }
            finally { btnSubmit.Enabled = true; }
        }

        private void FillJiraFromForm()
        {
            //populate the jira issue
            Type type = typeof(JiraIssue);
            foreach (Control control in Controls)
            {
                string tag = control.Tag?.ToString();
                if (!string.IsNullOrEmpty(tag))
                {
                    string value = control.Text;
                    PropertyInfo property = type.GetProperties().FirstOrDefault(p => JSONField.GetFieldName(p) == tag);
                    if (property != null) property.SetValue(jiraIssue, value);
                }
            }
        }

        /// <summary>
        /// Reset fields marked to be reset. This is designated by having a checked checkbox with
        /// the textbox's name in the Tag field.
        /// </summary>
        private void ResetMarkedFields()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() != typeof(CheckBox)) continue;
                var checkbox = (CheckBox)c;
                if (checkbox.Checked)
                {
                    var linkedControl = Controls.Find(checkbox.Tag.ToString(), false).FirstOrDefault();
                    if (linkedControl == null) continue;
                    linkedControl.Text = string.Empty;
                }
            }
        }

        const char PATH_INDICATOR = '\\';
        const string MESSAGE_EXT = ".msg";
        private void txtAttachment_DragDrop(object sender, DragEventArgs e)
        {
            string currentText = txtAttachment.Text;
            string retVal = jiraIssue.AddAttachment(e.Data);
            if (string.IsNullOrEmpty(retVal))
            {
                MessageBox.Show("Invalid attachment or drag/drop type.");
            }
            else
            {
                //if the attachment text is updating
                if (retVal != currentText)
                {
                    //and the value isn't a path
                    if (retVal.IndexOf(PATH_INDICATOR) == -1)
                    {
                        //get the email subject, which is the same as the file name
                        string subject = retVal;

                        //remove the extension, if necessary
                        int extPosition = subject.Length - MESSAGE_EXT.Length;
                        if (extPosition > 0 && subject.Substring(extPosition).Equals(MESSAGE_EXT, StringComparison.CurrentCultureIgnoreCase))
                        {
                            subject = subject.Substring(0, extPosition);
                        }
                        txtSummary.Text = subject;
                    }
                }
                txtAttachment.Text = retVal;
            }
        }

        private void txtAttachment_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lnkIssue_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(lnkIssue.Text);
        }

        private void btnUpdateCredentials_Click(object sender, EventArgs e)
        {
            string input = string.Empty;
            DialogResult result = ShowInputDialog(ref input);
            if (result == DialogResult.OK)
            {
                txtPassword.Text = JiraIssue.GetCredentialString(txtUsername.Text, input);
            }
        }

        private static DialogResult ShowInputDialog(ref string input)
        {
            var size = new System.Drawing.Size(200, 70);
            var inputBox = new Form();

            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Enter Password";

            var textBox = new MaskedTextBox();
            textBox.PasswordChar = '*';
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            var okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            var cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        #region Form State Management

        private void fmrMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormState(STATE_FILENAME);
            e.Cancel = false;
        }

        private void SaveFormState(string filename)
        {
            var controlStates = new List<ControlState>();
            foreach (Control c in Controls)
            {
                //see if the control is checked
                bool? isChecked = null;
                PropertyInfo checkedProperty = c.GetType().GetProperty("Checked");
                if (checkedProperty != null)
                {
                    isChecked = (bool)checkedProperty.GetValue(c);
                }

                //save the text
                string text = c.Text;

                //create the control state object, if needed
                if (!(isChecked == null && text == null))
                {
                    controlStates.Add(new ControlState(c.Name, text, isChecked ?? false));
                }
            }
            try
            {
                //delete the state file before writing a new one
                if (File.Exists(STATE_FILENAME))
                {
                    try { File.Delete(STATE_FILENAME); }
                    catch { return; }
                }

                var serializer = new XmlSerializer(typeof(List<ControlState>));
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fs, controlStates);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                //what?!
            }
        }

        private void LoadFormState(string filename)
        {
            if (!File.Exists(filename)) return;

            //deserialize
            var serializer = new XmlSerializer(typeof(List<ControlState>));
            List<ControlState> states = null;
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                states = (List<ControlState>)serializer.Deserialize(fs);
                fs.Close();
            }

            //load in the states
            foreach (ControlState c in states)
            {
                Control con = Controls.Find(c.Name, false).FirstOrDefault();
                if (con != null)
                {
                    //see if the control is checked
                    PropertyInfo checkedProperty = con.GetType().GetProperty("Checked");
                    if (checkedProperty != null)
                    {
                        checkedProperty.SetValue(con, c.Checked);
                    }

                    //load the text
                    con.Text = c.Text;
                }
            }
        }

        private void LoadSetting(string filename)
        {
            Settings = new INIFile(filename);
            foreach (var c in Controls)
            {
                if (c.GetType() != typeof(ComboBox)) continue;
                var cbo = (ComboBox)c;
                string tag = cbo.Tag.ToString();
                if (string.IsNullOrEmpty(tag)) continue;

                var options = Settings.GetIniAsArray(tag);
                if (options == null) continue;
                foreach (var option in options)
                {
                    cbo.Items.Add(option);
                }
            }
        }

        private void fmrMain_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();  //ensures that form finishes loading before we load our form state            
            LoadSetting(INI_FILENAME);
            LoadFormState(STATE_FILENAME);
        }

        #endregion
    }

    public class ControlStates
    {
        public List<ControlState> States { get; set; }
        public ControlStates() { }
        public ControlStates(List<ControlState> states)
        {
            States = states;
        }
    }

    public class ControlState
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public bool Checked { get; set; }
        public ControlState() { }

        public ControlState(string name, string text, bool isChecked)
        {
            Name = name;
            Text = text;
            Checked = isChecked;
        }
    }
}
