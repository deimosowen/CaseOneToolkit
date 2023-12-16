using System;
using System.Globalization;
using System.Windows.Forms;

namespace CaseMapCoreInitExtension.Forms
{
    [ProvideToolboxControl("CaseMapCoreInitExtension.Forms.CreateDatabaseForm", false)]
    public partial class CreateDatabaseForm : Form
    {
        public bool IsNotDropDb => isNotDropDb.Checked;
        public bool IsPrintMigrations => isPrintMigrations.Checked;
        public bool IsPostgresDb => isPostgresDb.Checked;

        public CreateDatabaseForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
