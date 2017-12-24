namespace Search_and_copy_files_tool
{
    partial class frm_Seach_And_Copy_Files_Tool
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Seach_And_Copy_Files_Tool));
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGetSourcePath = new System.Windows.Forms.Button();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCopyFiles = new System.Windows.Forms.Button();
            this.txtFilesList = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.cmdGetDestinationPath = new System.Windows.Forms.Button();
            this.cmdCreateFile = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdImport = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtSourcePath.Location = new System.Drawing.Point(95, 31);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(708, 20);
            this.txtSourcePath.TabIndex = 0;
            this.txtSourcePath.Text = "D:\\Search_and_copy_files_tool\\SourceFiles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Path:";
            // 
            // cmdGetSourcePath
            // 
            this.cmdGetSourcePath.Location = new System.Drawing.Point(804, 29);
            this.cmdGetSourcePath.Name = "cmdGetSourcePath";
            this.cmdGetSourcePath.Size = new System.Drawing.Size(29, 23);
            this.cmdGetSourcePath.TabIndex = 2;
            this.cmdGetSourcePath.Text = "...";
            this.cmdGetSourcePath.UseVisualStyleBackColor = true;
            this.cmdGetSourcePath.Click += new System.EventHandler(this.cmdGetSourcePath_Click);
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtDestinationPath.Location = new System.Drawing.Point(95, 57);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(708, 20);
            this.txtDestinationPath.TabIndex = 3;
            this.txtDestinationPath.Text = "D:\\Search_and_copy_files_tool\\DestinationFiles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destination Path:";
            // 
            // cmdCopyFiles
            // 
            this.cmdCopyFiles.Location = new System.Drawing.Point(645, 418);
            this.cmdCopyFiles.Name = "cmdCopyFiles";
            this.cmdCopyFiles.Size = new System.Drawing.Size(193, 23);
            this.cmdCopyFiles.TabIndex = 5;
            this.cmdCopyFiles.Text = "Copy files from source to destination";
            this.cmdCopyFiles.UseVisualStyleBackColor = true;
            this.cmdCopyFiles.Click += new System.EventHandler(this.cmdCopyFiles_Click);
            // 
            // txtFilesList
            // 
            this.txtFilesList.BackColor = System.Drawing.SystemColors.Window;
            this.txtFilesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilesList.Location = new System.Drawing.Point(4, 106);
            this.txtFilesList.Multiline = true;
            this.txtFilesList.Name = "txtFilesList";
            this.txtFilesList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFilesList.Size = new System.Drawing.Size(834, 306);
            this.txtFilesList.TabIndex = 6;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(1, 86);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(818, 18);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Files list to copy";
            // 
            // cmdGetDestinationPath
            // 
            this.cmdGetDestinationPath.Location = new System.Drawing.Point(804, 55);
            this.cmdGetDestinationPath.Name = "cmdGetDestinationPath";
            this.cmdGetDestinationPath.Size = new System.Drawing.Size(29, 23);
            this.cmdGetDestinationPath.TabIndex = 8;
            this.cmdGetDestinationPath.Text = "...";
            this.cmdGetDestinationPath.UseVisualStyleBackColor = true;
            this.cmdGetDestinationPath.Click += new System.EventHandler(this.cmdGetDestinationPath_Click);
            // 
            // cmdCreateFile
            // 
            this.cmdCreateFile.Location = new System.Drawing.Point(4, 418);
            this.cmdCreateFile.Name = "cmdCreateFile";
            this.cmdCreateFile.Size = new System.Drawing.Size(75, 23);
            this.cmdCreateFile.TabIndex = 10;
            this.cmdCreateFile.Text = "Create files";
            this.cmdCreateFile.UseVisualStyleBackColor = true;
            this.cmdCreateFile.Visible = false;
            this.cmdCreateFile.Click += new System.EventHandler(this.cmdCreateFile_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(850, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            this.toolStripProgressBar1.RightToLeftChanged += new System.EventHandler(this.toolStripProgressBar1_RightToLeftChanged);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel2.Text = "Time:";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(580, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(532, 418);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(107, 23);
            this.cmdImport.TabIndex = 12;
            this.cmdImport.Text = "Import from Excel";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(850, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Home page";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Exit";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // frm_Seach_And_Copy_Files_Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(850, 471);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdCreateFile);
            this.Controls.Add(this.cmdGetDestinationPath);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.txtFilesList);
            this.Controls.Add(this.cmdCopyFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.cmdGetSourcePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourcePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Seach_And_Copy_Files_Tool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search and copy files tool (Trial version 1 day)";
            this.Load += new System.EventHandler(this.frm_Seach_And_Copy_Files_Tool_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdGetSourcePath;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdCopyFiles;
        private System.Windows.Forms.TextBox txtFilesList;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button cmdGetDestinationPath;
        private System.Windows.Forms.Button cmdCreateFile;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

