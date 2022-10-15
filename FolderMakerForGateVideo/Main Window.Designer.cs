namespace FolderMakerForGateVideo
{
    partial class Form1
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
            this.Create_Root_Folder_Button = new System.Windows.Forms.Button();
            this.Create_Subject_Folders = new System.Windows.Forms.Button();
            this.Create_Topic_Folders = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Create_Files_data = new System.Windows.Forms.Button();
            this.GetValidFileNames = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNoOfTopics = new System.Windows.Forms.Label();
            this.lblNoOfContents = new System.Windows.Forms.Label();
            this.cmbContent = new System.Windows.Forms.ComboBox();
            this.lblNoOfSubjectFolders = new System.Windows.Forms.Label();
            this.cmbTopic = new System.Windows.Forms.ComboBox();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.cmbRoot = new System.Windows.Forms.ComboBox();
            this.lblNoOfRootFolders = new System.Windows.Forms.Label();
            this.lblCompleteDuration = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Create_Root_Folder_Button
            // 
            this.Create_Root_Folder_Button.BackColor = System.Drawing.SystemColors.Control;
            this.Create_Root_Folder_Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Create_Root_Folder_Button.Location = new System.Drawing.Point(3, 3);
            this.Create_Root_Folder_Button.Name = "Create_Root_Folder_Button";
            this.Create_Root_Folder_Button.Size = new System.Drawing.Size(189, 30);
            this.Create_Root_Folder_Button.TabIndex = 1;
            this.Create_Root_Folder_Button.Text = "Create Root Folder";
            this.Create_Root_Folder_Button.UseVisualStyleBackColor = false;
            this.Create_Root_Folder_Button.Click += new System.EventHandler(this.Create_Root_Folder_Button_Click);
            // 
            // Create_Subject_Folders
            // 
            this.Create_Subject_Folders.Location = new System.Drawing.Point(198, 3);
            this.Create_Subject_Folders.Name = "Create_Subject_Folders";
            this.Create_Subject_Folders.Size = new System.Drawing.Size(199, 30);
            this.Create_Subject_Folders.TabIndex = 2;
            this.Create_Subject_Folders.Text = "Create Subject Folders";
            this.Create_Subject_Folders.UseVisualStyleBackColor = true;
            this.Create_Subject_Folders.Click += new System.EventHandler(this.Create_Subject_Folders_Click);
            // 
            // Create_Topic_Folders
            // 
            this.Create_Topic_Folders.Location = new System.Drawing.Point(403, 3);
            this.Create_Topic_Folders.Name = "Create_Topic_Folders";
            this.Create_Topic_Folders.Size = new System.Drawing.Size(199, 30);
            this.Create_Topic_Folders.TabIndex = 3;
            this.Create_Topic_Folders.Text = "Create Topic Folders";
            this.Create_Topic_Folders.UseVisualStyleBackColor = true;
            this.Create_Topic_Folders.Click += new System.EventHandler(this.Create_Topic_Folders_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Create_Root_Folder_Button);
            this.flowLayoutPanel1.Controls.Add(this.Create_Subject_Folders);
            this.flowLayoutPanel1.Controls.Add(this.Create_Topic_Folders);
            this.flowLayoutPanel1.Controls.Add(this.Create_Files_data);
            this.flowLayoutPanel1.Controls.Add(this.GetValidFileNames);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 920);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1882, 33);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // Create_Files_data
            // 
            this.Create_Files_data.Location = new System.Drawing.Point(608, 3);
            this.Create_Files_data.Name = "Create_Files_data";
            this.Create_Files_data.Size = new System.Drawing.Size(297, 30);
            this.Create_Files_data.TabIndex = 4;
            this.Create_Files_data.Text = "Create Files Data(pdfs,videos)";
            this.Create_Files_data.UseVisualStyleBackColor = true;
            this.Create_Files_data.Click += new System.EventHandler(this.Create_Files_data_Click);
            // 
            // GetValidFileNames
            // 
            this.GetValidFileNames.Location = new System.Drawing.Point(911, 3);
            this.GetValidFileNames.Name = "GetValidFileNames";
            this.GetValidFileNames.Size = new System.Drawing.Size(297, 30);
            this.GetValidFileNames.TabIndex = 5;
            this.GetValidFileNames.Text = "Get valid file names";
            this.GetValidFileNames.UseVisualStyleBackColor = true;
            this.GetValidFileNames.Click += new System.EventHandler(this.GetValidFileNames_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1214, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Go To Time Calculator";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.2967F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.29671F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.40659F));
            this.tableLayoutPanel1.Controls.Add(this.lblNoOfTopics, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNoOfContents, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbContent, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNoOfSubjectFolders, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTopic, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbSubject, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbRoot, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNoOfRootFolders, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCompleteDuration, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1882, 138);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lblNoOfTopics
            // 
            this.lblNoOfTopics.AutoSize = true;
            this.lblNoOfTopics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoOfTopics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfTopics.Location = new System.Drawing.Point(1255, 39);
            this.lblNoOfTopics.Name = "lblNoOfTopics";
            this.lblNoOfTopics.Size = new System.Drawing.Size(624, 20);
            this.lblNoOfTopics.TabIndex = 5;
            // 
            // lblNoOfContents
            // 
            this.lblNoOfContents.AutoSize = true;
            this.lblNoOfContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoOfContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfContents.Location = new System.Drawing.Point(3, 98);
            this.lblNoOfContents.Name = "lblNoOfContents";
            this.lblNoOfContents.Size = new System.Drawing.Size(620, 20);
            this.lblNoOfContents.TabIndex = 7;
            // 
            // cmbContent
            // 
            this.cmbContent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbContent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbContent.BackColor = System.Drawing.Color.SeaShell;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbContent, 3);
            this.cmbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbContent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbContent.FormattingEnabled = true;
            this.cmbContent.Location = new System.Drawing.Point(3, 62);
            this.cmbContent.Name = "cmbContent";
            this.cmbContent.Size = new System.Drawing.Size(1876, 33);
            this.cmbContent.TabIndex = 6;
            this.cmbContent.SelectedIndexChanged += new System.EventHandler(this.cmbContent_SelectedIndexChanged);
            this.cmbContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbContent_KeyDown);
            // 
            // lblNoOfSubjectFolders
            // 
            this.lblNoOfSubjectFolders.AutoSize = true;
            this.lblNoOfSubjectFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoOfSubjectFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfSubjectFolders.Location = new System.Drawing.Point(629, 39);
            this.lblNoOfSubjectFolders.Name = "lblNoOfSubjectFolders";
            this.lblNoOfSubjectFolders.Size = new System.Drawing.Size(620, 20);
            this.lblNoOfSubjectFolders.TabIndex = 4;
            // 
            // cmbTopic
            // 
            this.cmbTopic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTopic.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTopic.BackColor = System.Drawing.Color.SeaShell;
            this.cmbTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTopic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTopic.FormattingEnabled = true;
            this.cmbTopic.Location = new System.Drawing.Point(1255, 3);
            this.cmbTopic.Name = "cmbTopic";
            this.cmbTopic.Size = new System.Drawing.Size(624, 33);
            this.cmbTopic.TabIndex = 2;
            this.cmbTopic.SelectedIndexChanged += new System.EventHandler(this.cmbTopic_SelectedIndexChanged);
            // 
            // cmbSubject
            // 
            this.cmbSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubject.BackColor = System.Drawing.Color.SeaShell;
            this.cmbSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSubject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(629, 3);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(620, 33);
            this.cmbSubject.TabIndex = 1;
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);
            // 
            // cmbRoot
            // 
            this.cmbRoot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRoot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRoot.BackColor = System.Drawing.Color.SeaShell;
            this.cmbRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRoot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoot.FormattingEnabled = true;
            this.cmbRoot.Location = new System.Drawing.Point(3, 3);
            this.cmbRoot.Name = "cmbRoot";
            this.cmbRoot.Size = new System.Drawing.Size(620, 33);
            this.cmbRoot.TabIndex = 0;
            this.cmbRoot.SelectedIndexChanged += new System.EventHandler(this.cmbRoot_SelectedIndexChanged);
            // 
            // lblNoOfRootFolders
            // 
            this.lblNoOfRootFolders.AutoSize = true;
            this.lblNoOfRootFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoOfRootFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfRootFolders.Location = new System.Drawing.Point(3, 39);
            this.lblNoOfRootFolders.Name = "lblNoOfRootFolders";
            this.lblNoOfRootFolders.Size = new System.Drawing.Size(620, 20);
            this.lblNoOfRootFolders.TabIndex = 3;
            this.lblNoOfRootFolders.Text = ".";
            // 
            // lblCompleteDuration
            // 
            this.lblCompleteDuration.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblCompleteDuration, 2);
            this.lblCompleteDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompleteDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleteDuration.Location = new System.Drawing.Point(629, 98);
            this.lblCompleteDuration.Name = "lblCompleteDuration";
            this.lblCompleteDuration.Size = new System.Drawing.Size(1250, 20);
            this.lblCompleteDuration.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 138);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1882, 782);
            this.textBox1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1412, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "Get All Filenames";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1882, 953);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Create_Root_Folder_Button;
        private System.Windows.Forms.Button Create_Subject_Folders;
        private System.Windows.Forms.Button Create_Topic_Folders;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Create_Files_data;
        private System.Windows.Forms.Button GetValidFileNames;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbContent;
        private System.Windows.Forms.Label lblNoOfTopics;
        private System.Windows.Forms.Label lblNoOfSubjectFolders;
        private System.Windows.Forms.ComboBox cmbTopic;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.ComboBox cmbRoot;
        private System.Windows.Forms.Label lblNoOfRootFolders;
        private System.Windows.Forms.Label lblNoOfContents;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCompleteDuration;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

