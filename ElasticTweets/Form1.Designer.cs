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
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblElasticSearch = new System.Windows.Forms.Label();
            this.btnChangeDirectory = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtIndexName = new System.Windows.Forms.TextBox();
            this.lblIndexName = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblElasticHost = new System.Windows.Forms.Label();
            this.txtSourceDirectory = new System.Windows.Forms.TextBox();
            this.lblSourceDirectory = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdSearchResults = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // folderDialog
            // 
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 378);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblElasticSearch);
            this.tabPage1.Controls.Add(this.btnChangeDirectory);
            this.tabPage1.Controls.Add(this.btnImport);
            this.tabPage1.Controls.Add(this.txtIndexName);
            this.tabPage1.Controls.Add(this.lblIndexName);
            this.tabPage1.Controls.Add(this.txtPort);
            this.tabPage1.Controls.Add(this.lblPort);
            this.tabPage1.Controls.Add(this.txtHost);
            this.tabPage1.Controls.Add(this.lblElasticHost);
            this.tabPage1.Controls.Add(this.txtSourceDirectory);
            this.tabPage1.Controls.Add(this.lblSourceDirectory);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblElasticSearch
            // 
            this.lblElasticSearch.AutoSize = true;
            this.lblElasticSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElasticSearch.Location = new System.Drawing.Point(20, 51);
            this.lblElasticSearch.Name = "lblElasticSearch";
            this.lblElasticSearch.Size = new System.Drawing.Size(203, 13);
            this.lblElasticSearch.TabIndex = 21;
            this.lblElasticSearch.Text = "ElasticSearch Connection Settings";
            // 
            // btnChangeDirectory
            // 
            this.btnChangeDirectory.Location = new System.Drawing.Point(487, 18);
            this.btnChangeDirectory.Name = "btnChangeDirectory";
            this.btnChangeDirectory.Size = new System.Drawing.Size(24, 22);
            this.btnChangeDirectory.TabIndex = 20;
            this.btnChangeDirectory.Text = "...";
            this.btnChangeDirectory.UseVisualStyleBackColor = true;
            this.btnChangeDirectory.Click += new System.EventHandler(this.btnChangeDirectory_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(23, 157);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(72, 26);
            this.btnImport.TabIndex = 19;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtIndexName
            // 
            this.txtIndexName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIndexName.Location = new System.Drawing.Point(91, 111);
            this.txtIndexName.Name = "txtIndexName";
            this.txtIndexName.Size = new System.Drawing.Size(132, 20);
            this.txtIndexName.TabIndex = 18;
            // 
            // lblIndexName
            // 
            this.lblIndexName.AutoSize = true;
            this.lblIndexName.Location = new System.Drawing.Point(21, 116);
            this.lblIndexName.Name = "lblIndexName";
            this.lblIndexName.Size = new System.Drawing.Size(64, 13);
            this.lblIndexName.TabIndex = 17;
            this.lblIndexName.Text = "Index Name";
            // 
            // txtPort
            // 
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Location = new System.Drawing.Point(91, 88);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(40, 20);
            this.txtPort.TabIndex = 16;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(20, 93);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 15;
            this.lblPort.Text = "Port";
            // 
            // txtHost
            // 
            this.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHost.Location = new System.Drawing.Point(91, 65);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(132, 20);
            this.txtHost.TabIndex = 14;
            // 
            // lblElasticHost
            // 
            this.lblElasticHost.AutoSize = true;
            this.lblElasticHost.Location = new System.Drawing.Point(20, 69);
            this.lblElasticHost.Name = "lblElasticHost";
            this.lblElasticHost.Size = new System.Drawing.Size(29, 13);
            this.lblElasticHost.TabIndex = 13;
            this.lblElasticHost.Text = "Host";
            // 
            // txtSourceDirectory
            // 
            this.txtSourceDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceDirectory.Location = new System.Drawing.Point(149, 20);
            this.txtSourceDirectory.Name = "txtSourceDirectory";
            this.txtSourceDirectory.Size = new System.Drawing.Size(335, 20);
            this.txtSourceDirectory.TabIndex = 12;
            // 
            // lblSourceDirectory
            // 
            this.lblSourceDirectory.AutoSize = true;
            this.lblSourceDirectory.Location = new System.Drawing.Point(20, 25);
            this.lblSourceDirectory.Name = "lblSourceDirectory";
            this.lblSourceDirectory.Size = new System.Drawing.Size(123, 13);
            this.lblSourceDirectory.TabIndex = 11;
            this.lblSourceDirectory.Text = "Tweet Data JS Directory";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdSearchResults);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(570, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Query";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdSearchResults
            // 
            this.grdSearchResults.AllowUserToAddRows = false;
            this.grdSearchResults.AllowUserToDeleteRows = false;
            this.grdSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearchResults.Location = new System.Drawing.Point(6, 35);
            this.grdSearchResults.Name = "grdSearchResults";
            this.grdSearchResults.ReadOnly = true;
            this.grdSearchResults.Size = new System.Drawing.Size(558, 297);
            this.grdSearchResults.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(6, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(598, 402);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmImport";
            this.Text = "ElasticTweets - Import";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblElasticSearch;
        private System.Windows.Forms.Button btnChangeDirectory;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtIndexName;
        private System.Windows.Forms.Label lblIndexName;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblElasticHost;
        private System.Windows.Forms.TextBox txtSourceDirectory;
        private System.Windows.Forms.Label lblSourceDirectory;
        private System.Windows.Forms.DataGridView grdSearchResults;
        private System.Windows.Forms.Button btnSearch;
    }
}

