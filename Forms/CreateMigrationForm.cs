using System;
using System.Globalization;
using System.Windows.Forms;

namespace CaseOneToolkit.Forms
{
    [ProvideToolboxControl("CaseOneToolkit.Forms.CreateMigrationForm", false)]
    public partial class CreateMigrationForm : Form
    {
        public string MigrationName => migrationName.Text.Trim();
        public bool IsMaintenance => isMaintenance.Checked;
        public bool IsWithSqlFile => isWithSqlFile.Checked;
        public bool IsIgnoreChanges => isIgnoreChanges.Checked;
        public bool IsForce => isForce.Checked;
        public bool IsPostgresDb => isPostgresDb.Checked;

        public CreateMigrationForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Save.Enabled = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
