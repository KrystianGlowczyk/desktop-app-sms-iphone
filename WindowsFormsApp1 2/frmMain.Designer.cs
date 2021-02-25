namespace WindowsFormsApp1
{
    partial class frmMain
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.tbDatabaseFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnShowBackupData = new System.Windows.Forms.Button();
            this.btnShowLoadedDb = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIndicator = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbSearchByNumber = new System.Windows.Forms.TextBox();
            this.btnSearchByNumber = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(709, 50);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(169, 20);
            this.tbSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(886, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 139);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(939, 520);
            this.dgvData.TabIndex = 0;
            // 
            // tbDatabaseFile
            // 
            this.tbDatabaseFile.Location = new System.Drawing.Point(115, 10);
            this.tbDatabaseFile.Name = "tbDatabaseFile";
            this.tbDatabaseFile.ReadOnly = true;
            this.tbDatabaseFile.Size = new System.Drawing.Size(469, 20);
            this.tbDatabaseFile.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Database File:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(590, 9);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(54, 23);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnShowBackupData
            // 
            this.btnShowBackupData.Location = new System.Drawing.Point(12, 47);
            this.btnShowBackupData.Name = "btnShowBackupData";
            this.btnShowBackupData.Size = new System.Drawing.Size(138, 23);
            this.btnShowBackupData.TabIndex = 12;
            this.btnShowBackupData.Text = "Show Backed Up Data";
            this.btnShowBackupData.UseVisualStyleBackColor = true;
            this.btnShowBackupData.Click += new System.EventHandler(this.btnShowBackupData_Click);
            // 
            // btnShowLoadedDb
            // 
            this.btnShowLoadedDb.Location = new System.Drawing.Point(168, 47);
            this.btnShowLoadedDb.Name = "btnShowLoadedDb";
            this.btnShowLoadedDb.Size = new System.Drawing.Size(191, 23);
            this.btnShowLoadedDb.TabIndex = 13;
            this.btnShowLoadedDb.Text = "Show Message From Loaded DB";
            this.btnShowLoadedDb.UseVisualStyleBackColor = true;
            this.btnShowLoadedDb.Click += new System.EventHandler(this.btnShowLoadedDb_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(379, 47);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 14;
            this.btnMerge.Text = "Merge Databases";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(709, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Search by Text";
            // 
            // lblIndicator
            // 
            this.lblIndicator.AutoSize = true;
            this.lblIndicator.Location = new System.Drawing.Point(12, 115);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(130, 13);
            this.lblIndicator.TabIndex = 16;
            this.lblIndicator.Text = "Displaying From: (Backup)";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(189, 105);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(284, 105);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbSearchByNumber
            // 
            this.tbSearchByNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchByNumber.Location = new System.Drawing.Point(709, 96);
            this.tbSearchByNumber.Name = "tbSearchByNumber";
            this.tbSearchByNumber.Size = new System.Drawing.Size(169, 20);
            this.tbSearchByNumber.TabIndex = 1;
            // 
            // btnSearchByNumber
            // 
            this.btnSearchByNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchByNumber.Location = new System.Drawing.Point(886, 93);
            this.btnSearchByNumber.Name = "btnSearchByNumber";
            this.btnSearchByNumber.Size = new System.Drawing.Size(65, 23);
            this.btnSearchByNumber.TabIndex = 2;
            this.btnSearchByNumber.Text = "Search";
            this.btnSearchByNumber.UseVisualStyleBackColor = true;
            this.btnSearchByNumber.Click += new System.EventHandler(this.btnSearchByNumber_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(709, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Search by Number";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 671);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblIndicator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearchByNumber);
            this.Controls.Add(this.tbSearchByNumber);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnShowLoadedDb);
            this.Controls.Add(this.btnShowBackupData);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDatabaseFile);
            this.Controls.Add(this.dgvData);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iPhone SMS Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox tbDatabaseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnShowBackupData;
        private System.Windows.Forms.Button btnShowLoadedDb;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIndicator;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbSearchByNumber;
        private System.Windows.Forms.Button btnSearchByNumber;
        private System.Windows.Forms.Label label3;
    }
}

