using System.ComponentModel;

namespace CaseOneToolkit.Forms
{
    partial class CreateMigrationForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Save = new System.Windows.Forms.Button();
            this.isMaintenance = new System.Windows.Forms.CheckBox();
            this.isWithSqlFile = new System.Windows.Forms.CheckBox();
            this.isPostgresDb = new System.Windows.Forms.CheckBox();
            this.isIgnoreChanges = new System.Windows.Forms.CheckBox();
            this.isForce = new System.Windows.Forms.CheckBox();
            this.migrationName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(156, 205);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(156, 34);
            this.Save.TabIndex = 0;
            this.Save.Text = "Add Migration";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Button1_Click);
            // 
            // isMaintenance
            // 
            this.isMaintenance.AccessibleDescription = "";
            this.isMaintenance.AutoSize = true;
            this.isMaintenance.Location = new System.Drawing.Point(12, 62);
            this.isMaintenance.Name = "isMaintenance";
            this.isMaintenance.Size = new System.Drawing.Size(205, 17);
            this.isMaintenance.TabIndex = 1;
            this.isMaintenance.Text = "Maintenance - миграция в _sys базу";
            this.isMaintenance.UseVisualStyleBackColor = true;
            // 
            // isWithSqlFile
            // 
            this.isWithSqlFile.AutoSize = true;
            this.isWithSqlFile.Location = new System.Drawing.Point(12, 85);
            this.isWithSqlFile.Name = "isWithSqlFile";
            this.isWithSqlFile.Size = new System.Drawing.Size(402, 17);
            this.isWithSqlFile.TabIndex = 2;
            this.isWithSqlFile.Text = "WithSqlFile - добавляет <migration_name>.sql файл в миграцию и в ресурсы";
            this.isWithSqlFile.UseVisualStyleBackColor = true;
            // 
            // isPostgresDb
            // 
            this.isPostgresDb.AutoSize = true;
            this.isPostgresDb.Location = new System.Drawing.Point(12, 154);
            this.isPostgresDb.Name = "isPostgresDb";
            this.isPostgresDb.Size = new System.Drawing.Size(233, 17);
            this.isPostgresDb.TabIndex = 3;
            this.isPostgresDb.Text = "PostgresDb - указывает работу с postgres";
            this.isPostgresDb.UseVisualStyleBackColor = true;
            // 
            // isIgnoreChanges
            // 
            this.isIgnoreChanges.AutoSize = true;
            this.isIgnoreChanges.Location = new System.Drawing.Point(12, 108);
            this.isIgnoreChanges.Name = "isIgnoreChanges";
            this.isIgnoreChanges.Size = new System.Drawing.Size(264, 17);
            this.isIgnoreChanges.TabIndex = 4;
            this.isIgnoreChanges.Text = "IgnoreChanges - игнорирует изменения модели";
            this.isIgnoreChanges.UseVisualStyleBackColor = true;
            // 
            // isForce
            // 
            this.isForce.AutoSize = true;
            this.isForce.Location = new System.Drawing.Point(12, 131);
            this.isForce.Name = "isForce";
            this.isForce.Size = new System.Drawing.Size(442, 17);
            this.isForce.TabIndex = 5;
            this.isForce.Text = "Force - переопределяет содержимое миграции, если она еще не была применена";
            this.isForce.UseVisualStyleBackColor = true;
            // 
            // migrationName
            // 
            this.migrationName.Location = new System.Drawing.Point(12, 36);
            this.migrationName.Name = "migrationName";
            this.migrationName.Size = new System.Drawing.Size(442, 20);
            this.migrationName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Наименование миграции";
            // 
            // CreateMigrationForm
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 251);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.migrationName);
            this.Controls.Add(this.isForce);
            this.Controls.Add(this.isIgnoreChanges);
            this.Controls.Add(this.isPostgresDb);
            this.Controls.Add(this.isWithSqlFile);
            this.Controls.Add(this.isMaintenance);
            this.Controls.Add(this.Save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateMigrationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.CheckBox isMaintenance;
        private System.Windows.Forms.CheckBox isWithSqlFile;
        private System.Windows.Forms.CheckBox isPostgresDb;
        private System.Windows.Forms.CheckBox isIgnoreChanges;
        private System.Windows.Forms.CheckBox isForce;
        private System.Windows.Forms.TextBox migrationName;
        private System.Windows.Forms.Label label1;
    }
}
