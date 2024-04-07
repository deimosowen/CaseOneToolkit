using CaseOneToolkit.Forms;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace CaseOneToolkit.Commands
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class CreateMigrationCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0101;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("be63337c-ea10-4a31-a622-edb7fb0739d9");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMigrationCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private CreateMigrationCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static CreateMigrationCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider => this.package;

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in CreateMigrationCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new CreateMigrationCommand(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private async void Execute(object sender, EventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            try
            {
                using (var form = new CreateMigrationForm())
                {
                    var result = form.ShowDialog();
                    if (result != DialogResult.OK) return;

                    if (string.IsNullOrWhiteSpace(form.MigrationName))
                    {
                        throw new Exception("Migration name is required");
                    }

                    var solutionDirectory = await SolutionUtilities.GetActiveProjectRootPathAsync();
                    var modulePath = Path.Combine(solutionDirectory, SolutionUtilities.ScriptCaseProTools);
                    var scriptBuilder = new StringBuilder();
                    scriptBuilder.AppendLine($"Import-Module '{modulePath}' -Force -DisableNameChecking");
                    scriptBuilder.Append("CP-Add-Migration ");

                    if (form.IsMaintenance)
                        scriptBuilder.Append("-Maintenance ");
                    if (form.IsWithSqlFile)
                        scriptBuilder.Append("-WithSqlFile ");
                    if (form.IsIgnoreChanges)
                        scriptBuilder.Append("-IgnoreChanges  ");
                    if (form.IsForce)
                        scriptBuilder.Append("-Force ");
                    if (form.IsPostgresDb)
                        scriptBuilder.Append("-PostgresDb");

                    ScriptExecutor.RunScript(scriptBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                VsShellUtilities.ShowMessageBox(
                    this.package,
                    "An error occurred: " + ex.Message,
                    "Add Migration",
                    OLEMSGICON.OLEMSGICON_CRITICAL,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
        }
    }
}
