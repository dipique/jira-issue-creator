namespace Jira_Issue_Creator
{
    partial class fmrMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStepsToReproduce = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtComponents = new System.Windows.Forms.TextBox();
            this.txtVersions = new System.Windows.Forms.TextBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.txtFoundIn = new System.Windows.Forms.TextBox();
            this.txtIssueType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtJiraURL = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAttachment = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lnkIssue = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.btnUpdateCredentials = new System.Windows.Forms.Button();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtStepsToReproduce
            // 
            this.txtStepsToReproduce.Location = new System.Drawing.Point(81, 168);
            this.txtStepsToReproduce.Multiline = true;
            this.txtStepsToReproduce.Name = "txtStepsToReproduce";
            this.txtStepsToReproduce.Size = new System.Drawing.Size(235, 63);
            this.txtStepsToReproduce.TabIndex = 1;
            this.txtStepsToReproduce.Tag = "customfield_11000";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 82);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(235, 80);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Tag = "description";
            // 
            // txtComponents
            // 
            this.txtComponents.Location = new System.Drawing.Point(81, 237);
            this.txtComponents.Name = "txtComponents";
            this.txtComponents.Size = new System.Drawing.Size(235, 20);
            this.txtComponents.TabIndex = 3;
            this.txtComponents.Tag = "components";
            this.txtComponents.Text = "Store Portal";
            // 
            // txtVersions
            // 
            this.txtVersions.Location = new System.Drawing.Point(81, 263);
            this.txtVersions.Name = "txtVersions";
            this.txtVersions.Size = new System.Drawing.Size(235, 20);
            this.txtVersions.TabIndex = 4;
            this.txtVersions.Tag = "versions";
            this.txtVersions.Text = "SRS 1.6";
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(81, 56);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(235, 20);
            this.txtSummary.TabIndex = 5;
            this.txtSummary.Tag = "summary";
            // 
            // txtFoundIn
            // 
            this.txtFoundIn.Location = new System.Drawing.Point(81, 293);
            this.txtFoundIn.Name = "txtFoundIn";
            this.txtFoundIn.Size = new System.Drawing.Size(235, 20);
            this.txtFoundIn.TabIndex = 6;
            this.txtFoundIn.Tag = "customfield_11501";
            this.txtFoundIn.Text = "UAT";
            // 
            // txtIssueType
            // 
            this.txtIssueType.Location = new System.Drawing.Point(249, 31);
            this.txtIssueType.Name = "txtIssueType";
            this.txtIssueType.Size = new System.Drawing.Size(67, 20);
            this.txtIssueType.TabIndex = 7;
            this.txtIssueType.Tag = "issuetype";
            this.txtIssueType.Text = "Bug";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "Steps to Reproduce";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Found In";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Components";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Versions";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Summary";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Description";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Issue Type";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(81, 420);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(235, 20);
            this.txtUsername.TabIndex = 17;
            this.txtUsername.Tag = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 423);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "User Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 449);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Password";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(81, 446);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(129, 20);
            this.txtPassword.TabIndex = 20;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(241, 345);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 21;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtJiraURL
            // 
            this.txtJiraURL.Location = new System.Drawing.Point(81, 482);
            this.txtJiraURL.Name = "txtJiraURL";
            this.txtJiraURL.Size = new System.Drawing.Size(235, 20);
            this.txtJiraURL.TabIndex = 22;
            this.txtJiraURL.Text = "http://jira.zalecorp.com:9000/rest/api/2/issue/";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 485);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Jira URL";
            // 
            // txtAttachment
            // 
            this.txtAttachment.AllowDrop = true;
            this.txtAttachment.Location = new System.Drawing.Point(81, 319);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.Size = new System.Drawing.Size(235, 20);
            this.txtAttachment.TabIndex = 24;
            this.txtAttachment.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAttachment_DragDrop);
            this.txtAttachment.DragOver += new System.Windows.Forms.DragEventHandler(this.txtAttachment_DragOver);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Attachment";
            // 
            // lnkIssue
            // 
            this.lnkIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkIssue.AutoSize = true;
            this.lnkIssue.Location = new System.Drawing.Point(78, 375);
            this.lnkIssue.Name = "lnkIssue";
            this.lnkIssue.Size = new System.Drawing.Size(0, 13);
            this.lnkIssue.TabIndex = 26;
            this.lnkIssue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkIssue.Click += new System.EventHandler(this.lnkIssue_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(322, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Tag = "txtIssueType";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(294, -1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 32);
            this.label13.TabIndex = 28;
            this.label13.Text = "Reset After Submit";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(322, 59);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 29;
            this.checkBox2.Tag = "txtSummary";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(322, 115);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 30;
            this.checkBox3.Tag = "txtDescription";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(322, 193);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 31;
            this.checkBox4.Tag = "txtStepsToReproduce";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(322, 240);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 32;
            this.checkBox5.Tag = "txtComponents";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(322, 266);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 33;
            this.checkBox6.Tag = "txtVersions";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(322, 296);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 34;
            this.checkBox7.Tag = "txtFoundIn";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(173, 34);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(15, 14);
            this.checkBox8.TabIndex = 35;
            this.checkBox8.Tag = "cboProject";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Checked = true;
            this.checkBox9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox9.Location = new System.Drawing.Point(322, 322);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(15, 14);
            this.checkBox9.TabIndex = 36;
            this.checkBox9.Tag = "txtAttachment";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // btnUpdateCredentials
            // 
            this.btnUpdateCredentials.Location = new System.Drawing.Point(210, 444);
            this.btnUpdateCredentials.Name = "btnUpdateCredentials";
            this.btnUpdateCredentials.Size = new System.Drawing.Size(106, 23);
            this.btnUpdateCredentials.TabIndex = 37;
            this.btnUpdateCredentials.Text = "&Update Credentials";
            this.btnUpdateCredentials.UseVisualStyleBackColor = true;
            this.btnUpdateCredentials.Click += new System.EventHandler(this.btnUpdateCredentials_Click);
            // 
            // cboProject
            // 
            this.cboProject.FormattingEnabled = true;
            this.cboProject.Location = new System.Drawing.Point(81, 31);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(89, 21);
            this.cboProject.TabIndex = 38;
            this.cboProject.Tag = "project";
            this.cboProject.Text = "REP";
            // 
            // fmrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 511);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.btnUpdateCredentials);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lnkIssue);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAttachment);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtJiraURL);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIssueType);
            this.Controls.Add(this.txtFoundIn);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.txtVersions);
            this.Controls.Add(this.txtComponents);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtStepsToReproduce);
            this.Controls.Add(this.label8);
            this.Name = "fmrMain";
            this.Text = "Jira Issue Submission";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmrMain_FormClosing);
            this.Shown += new System.EventHandler(this.fmrMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtStepsToReproduce;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtComponents;
        private System.Windows.Forms.TextBox txtVersions;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TextBox txtFoundIn;
        private System.Windows.Forms.TextBox txtIssueType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtJiraURL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAttachment;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel lnkIssue;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.Button btnUpdateCredentials;
        private System.Windows.Forms.ComboBox cboProject;
    }
}

