using System.ComponentModel;

namespace CaseMapCoreInitExtension.Forms
{
    partial class CreateDatabaseForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.isNotDropDb = new System.Windows.Forms.CheckBox();
            this.isPrintMigrations = new System.Windows.Forms.CheckBox();
            this.isPostgresDb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Database";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // isNotDropDb
            // 
            this.isNotDropDb.AccessibleDescription = "";
            this.isNotDropDb.AutoSize = true;
            this.isNotDropDb.Location = new System.Drawing.Point(12, 12);
            this.isNotDropDb.Name = "isNotDropDb";
            this.isNotDropDb.Size = new System.Drawing.Size(251, 17);
            this.isNotDropDb.TabIndex = 1;
            this.isNotDropDb.Text = "NotDropDb - не удалять существующую базу";
            this.isNotDropDb.UseVisualStyleBackColor = true;
            // 
            // isPrintMigrations
            // 
            this.isPrintMigrations.AutoSize = true;
            this.isPrintMigrations.Location = new System.Drawing.Point(12, 35);
            this.isPrintMigrations.Name = "isPrintMigrations";
            this.isPrintMigrations.Size = new System.Drawing.Size(368, 17);
            this.isPrintMigrations.TabIndex = 2;
            this.isPrintMigrations.Text = "PrintMigrations - выводить в консоль имена применяемых миграции";
            this.isPrintMigrations.UseVisualStyleBackColor = true;
            // 
            // isPostgresDb
            // 
            this.isPostgresDb.AutoSize = true;
            this.isPostgresDb.Location = new System.Drawing.Point(12, 58);
            this.isPostgresDb.Name = "isPostgresDb";
            this.isPostgresDb.Size = new System.Drawing.Size(233, 17);
            this.isPostgresDb.TabIndex = 3;
            this.isPostgresDb.Text = "PostgresDb - указывает работу с postgres";
            this.isPostgresDb.UseVisualStyleBackColor = true;
            // 
            // CreateDatabaseForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 124);
            this.Controls.Add(this.isPostgresDb);
            this.Controls.Add(this.isPrintMigrations);
            this.Controls.Add(this.isNotDropDb);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateDatabaseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox isNotDropDb;
        private System.Windows.Forms.CheckBox isPrintMigrations;
        private System.Windows.Forms.CheckBox isPostgresDb;
    }
}
