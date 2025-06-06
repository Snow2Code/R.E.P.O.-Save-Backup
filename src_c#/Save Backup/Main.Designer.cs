namespace Main
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.dataGridViewRepoSaves = new System.Windows.Forms.DataGridView();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonOpenSave = new System.Windows.Forms.Button();
            this.buttonOpenBackup = new System.Windows.Forms.Button();
            this.buttonBackupNow = new System.Windows.Forms.Button();
            this.dataGridViewBackups = new System.Windows.Forms.DataGridView();
            this.Main_Text = new System.Windows.Forms.Label();
            this.backupSaves_Label = new System.Windows.Forms.Label();
            this.repoSaves_Label = new System.Windows.Forms.Label();
            this.buttonBackupSelected = new System.Windows.Forms.Button();
            this.buttonRestoreSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRepoSaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackups)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRepoSaves
            // 
            this.dataGridViewRepoSaves.AllowUserToAddRows = false;
            this.dataGridViewRepoSaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRepoSaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRepoSaves.Location = new System.Drawing.Point(14, 21);
            this.dataGridViewRepoSaves.Name = "dataGridViewRepoSaves";
            this.dataGridViewRepoSaves.ReadOnly = true;
            this.dataGridViewRepoSaves.Size = new System.Drawing.Size(716, 342);
            this.dataGridViewRepoSaves.TabIndex = 0;
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(1095, 397);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(149, 35);
            this.buttonBackup.TabIndex = 1;
            this.buttonBackup.Text = "Restore Backup Saves";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonOpenSave
            // 
            this.buttonOpenSave.Location = new System.Drawing.Point(189, 397);
            this.buttonOpenSave.Name = "buttonOpenSave";
            this.buttonOpenSave.Size = new System.Drawing.Size(149, 35);
            this.buttonOpenSave.TabIndex = 2;
            this.buttonOpenSave.Text = "Open Save Folder";
            this.buttonOpenSave.UseVisualStyleBackColor = true;
            this.buttonOpenSave.Click += new System.EventHandler(this.buttonOpenSaves_Click);
            // 
            // buttonOpenBackup
            // 
            this.buttonOpenBackup.Location = new System.Drawing.Point(940, 397);
            this.buttonOpenBackup.Name = "buttonOpenBackup";
            this.buttonOpenBackup.Size = new System.Drawing.Size(149, 35);
            this.buttonOpenBackup.TabIndex = 3;
            this.buttonOpenBackup.Text = "Open Backup Folder";
            this.buttonOpenBackup.UseVisualStyleBackColor = true;
            this.buttonOpenBackup.Click += new System.EventHandler(this.buttonOpenBackup_Click);
            // 
            // buttonBackupNow
            // 
            this.buttonBackupNow.Location = new System.Drawing.Point(344, 397);
            this.buttonBackupNow.Name = "buttonBackupNow";
            this.buttonBackupNow.Size = new System.Drawing.Size(149, 35);
            this.buttonBackupNow.TabIndex = 4;
            this.buttonBackupNow.Text = "Backup Now";
            this.buttonBackupNow.UseVisualStyleBackColor = true;
            this.buttonBackupNow.Click += new System.EventHandler(this.buttonBackupNow_Click);
            // 
            // dataGridViewBackups
            // 
            this.dataGridViewBackups.AllowUserToAddRows = false;
            this.dataGridViewBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBackups.Location = new System.Drawing.Point(736, 21);
            this.dataGridViewBackups.Name = "dataGridViewBackups";
            this.dataGridViewBackups.ReadOnly = true;
            this.dataGridViewBackups.Size = new System.Drawing.Size(716, 342);
            this.dataGridViewBackups.TabIndex = 5;
            // 
            // Main_Text
            // 
            this.Main_Text.AutoSize = true;
            this.Main_Text.Location = new System.Drawing.Point(649, 5);
            this.Main_Text.Name = "Main_Text";
            this.Main_Text.Size = new System.Drawing.Size(185, 13);
            this.Main_Text.TabIndex = 7;
            this.Main_Text.Text = "Snow2Code\'s R.E.P.O. Save Backup";
            // 
            // backupSaves_Label
            // 
            this.backupSaves_Label.AutoSize = true;
            this.backupSaves_Label.Location = new System.Drawing.Point(1062, 371);
            this.backupSaves_Label.Name = "backupSaves_Label";
            this.backupSaves_Label.Size = new System.Drawing.Size(77, 13);
            this.backupSaves_Label.TabIndex = 8;
            this.backupSaves_Label.Text = "Backup Saves";
            this.backupSaves_Label.Click += new System.EventHandler(this.backupSaves_Label_Click);
            // 
            // repoSaves_Label
            // 
            this.repoSaves_Label.AutoSize = true;
            this.repoSaves_Label.Location = new System.Drawing.Point(293, 371);
            this.repoSaves_Label.Name = "repoSaves_Label";
            this.repoSaves_Label.Size = new System.Drawing.Size(82, 13);
            this.repoSaves_Label.TabIndex = 6;
            this.repoSaves_Label.Text = "R.E.P.O. Saves";
            this.repoSaves_Label.Click += new System.EventHandler(this.repoSaves_Label_Click);
            // 
            // buttonBackupSelected
            // 
            this.buttonBackupSelected.Location = new System.Drawing.Point(633, 369);
            this.buttonBackupSelected.Name = "buttonBackupSelected";
            this.buttonBackupSelected.Size = new System.Drawing.Size(97, 28);
            this.buttonBackupSelected.TabIndex = 9;
            this.buttonBackupSelected.Text = "Backup Selected";
            this.buttonBackupSelected.UseVisualStyleBackColor = true;
            this.buttonBackupSelected.Click += new System.EventHandler(this.buttonBackupSelected_Click);
            // 
            // buttonRestoreSelected
            // 
            this.buttonRestoreSelected.Location = new System.Drawing.Point(736, 369);
            this.buttonRestoreSelected.Name = "buttonRestoreSelected";
            this.buttonRestoreSelected.Size = new System.Drawing.Size(97, 28);
            this.buttonRestoreSelected.TabIndex = 10;
            this.buttonRestoreSelected.Text = "Restore Selected";
            this.buttonRestoreSelected.UseVisualStyleBackColor = true;
            this.buttonRestoreSelected.Click += new System.EventHandler(this.buttonRestoreSelected_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 452);
            this.Controls.Add(this.buttonRestoreSelected);
            this.Controls.Add(this.buttonBackupSelected);
            this.Controls.Add(this.backupSaves_Label);
            this.Controls.Add(this.Main_Text);
            this.Controls.Add(this.repoSaves_Label);
            this.Controls.Add(this.dataGridViewBackups);
            this.Controls.Add(this.buttonBackupNow);
            this.Controls.Add(this.buttonOpenBackup);
            this.Controls.Add(this.buttonOpenSave);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.dataGridViewRepoSaves);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "R.E.P.O. Save Backup by Snow2Code";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRepoSaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRepoSaves;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonOpenSave;
        private System.Windows.Forms.Button buttonOpenBackup;
        private System.Windows.Forms.Button buttonBackupNow;
        private System.Windows.Forms.DataGridView dataGridViewBackups;
        private System.Windows.Forms.Label Main_Text;
        private System.Windows.Forms.Label backupSaves_Label;
        private System.Windows.Forms.Label repoSaves_Label;
        private System.Windows.Forms.Button buttonBackupSelected;
        private System.Windows.Forms.Button buttonRestoreSelected;
    }
}

