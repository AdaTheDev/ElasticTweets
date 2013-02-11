namespace ElasticTweets
{
    partial class frmImport
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
            this.lblSourceDirectory = new System.Windows.Forms.Label();
            this.txtSourceDirectory = new System.Windows.Forms.TextBox();
            this.lblElasticHost = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblIndexName = new System.Windows.Forms.Label();
            this.txtIndexName = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChangeDirectory = new System.Windows.Forms.Button();
            this.lblElasticSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSourceDirectory
            // 
            this.lblSourceDirectory.AutoSize = true;
            this.lblSourceDirectory.Location = new System.Drawing.Point(11, 15);
            this.lblSourceDirectory.Name = "lblSourceDirectory";
            this.lblSourceDirectory.Size = new System.Drawing.Size(123, 13);
            this.lblSourceDirectory.TabIndex = 0;
            this.lblSourceDirectory.Text = "Tweet Data JS Directory";
            // 
            // txtSourceDirectory
            // 
            this.txtSourceDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceDirectory.Location = new System.Drawing.Point(140, 10);
            this.txtSourceDirectory.Name = "txtSourceDirectory";
            this.txtSourceDirectory.Size = new System.Drawing.Size(335, 20);
            this.txtSourceDirectory.TabIndex = 1;
            // 
            // lblElasticHost
            // 
            this.lblElasticHost.AutoSize = true;
            this.lblElasticHost.Location = new System.Drawing.Point(11, 59);
            this.lblElasticHost.Name = "lblElasticHost";
            this.lblElasticHost.Size = new System.Drawing.Size(29, 13);
            this.lblElasticHost.TabIndex = 2;
            this.lblElasticHost.Text = "Host";
            // 
            // txtHost
            // 
            this.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHost.Location = new System.Drawing.Point(82, 55);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(132, 20);
            this.txtHost.TabIndex = 3;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(11, 83);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Location = new System.Drawing.Point(82, 78);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(40, 20);
            this.txtPort.TabIndex = 5;
            // 
            // lblIndexName
            // 
            this.lblIndexName.AutoSize = true;
            this.lblIndexName.Location = new System.Drawing.Point(12, 106);
            this.lblIndexName.Name = "lblIndexName";
            this.lblIndexName.Size = new System.Drawing.Size(64, 13);
            this.lblIndexName.TabIndex = 6;
            this.lblIndexName.Text = "Index Name";
            // 
            // txtIndexName
            // 
            this.txtIndexName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIndexName.Location = new System.Drawing.Point(82, 101);
            this.txtIndexName.Name = "txtIndexName";
            this.txtIndexName.Size = new System.Drawing.Size(132, 20);
            this.txtIndexName.TabIndex = 7;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(14, 147);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(72, 27);
            this.btnImport.TabIndex = 8;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // folderDialog
            // 
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // btnChangeDirectory
            // 
            this.btnChangeDirectory.Location = new System.Drawing.Point(478, 8);
            this.btnChangeDirectory.Name = "btnChangeDirectory";
            this.btnChangeDirectory.Size = new System.Drawing.Size(24, 23);
            this.btnChangeDirectory.TabIndex = 9;
            this.btnChangeDirectory.Text = "...";
            this.btnChangeDirectory.UseVisualStyleBackColor = true;
            this.btnChangeDirectory.Click += new System.EventHandler(this.btnChangeDirectory_Click);
            // 
            // lblElasticSearch
            // 
            this.lblElasticSearch.AutoSize = true;
            this.lblElasticSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElasticSearch.Location = new System.Drawing.Point(11, 41);
            this.lblElasticSearch.Name = "lblElasticSearch";
            this.lblElasticSearch.Size = new System.Drawing.Size(203, 13);
            this.lblElasticSearch.TabIndex = 10;
            this.lblElasticSearch.Text = "ElasticSearch Connection Settings";
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(517, 185);
            this.Controls.Add(this.lblElasticSearch);
            this.Controls.Add(this.btnChangeDirectory);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtIndexName);
            this.Controls.Add(this.lblIndexName);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblElasticHost);
            this.Controls.Add(this.txtSourceDirectory);
            this.Controls.Add(this.lblSourceDirectory);
            this.Name = "frmImport";
            this.Text = "ElasticTweets - Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourceDirectory;
        private System.Windows.Forms.TextBox txtSourceDirectory;
        private System.Windows.Forms.Label lblElasticHost;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblIndexName;
        private System.Windows.Forms.TextBox txtIndexName;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Button btnChangeDirectory;
        private System.Windows.Forms.Label lblElasticSearch;
    }
}

