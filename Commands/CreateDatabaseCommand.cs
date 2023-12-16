﻿using CaseMapCoreInitExtension.Forms;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace CaseMapCoreInitExtension.Commands
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class CreateDatabaseCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("be63337c-ea10-4a31-a622-edb7fb0739d9");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDatabaseCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private CreateDatabaseCommand(AsyncPackage package, OleMenuCommandService commandService)
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
        public static CreateDatabaseCommand Instance
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
            // Switch to the main thread - the call to AddCommand in CreateDatabaseCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new CreateDatabaseCommand(package, commandService);
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
                using (var form = new CreateDatabaseForm())
                {
                    var result = form.ShowDialog();
                    if (result != DialogResult.OK) return;

                    var solutionDirectory = await SolutionUtilities.GetActiveProjectRootPathAsync();
                    var modulePath = Path.Combine(solutionDirectory, SolutionUtilities.ScriptCaseProTools);
                    var moduleName = Path.GetFileNameWithoutExtension(modulePath);
                    var scriptBuilder = new StringBuilder();
                    scriptBuilder.AppendLine($"if (-not (Get-Module -Name '{moduleName}')) {{");
                    scriptBuilder.AppendLine($"    Import-Module '{modulePath}' -Force -DisableNameChecking");
                    scriptBuilder.AppendLine($"}}");
                    scriptBuilder.AppendLine($"Set-Location '{solutionDirectory}'");
                    scriptBuilder.Append("CP-Create-Database ");

                    if (form.IsNotDropDb)
                        scriptBuilder.Append("-NotDropDb ");
                    if (form.IsPrintMigrations)
                        scriptBuilder.Append("-PrintMigrations ");
                    if (form.IsPostgresDb)
                        scriptBuilder.Append("-PostgresDb");

                    PowerShellExecutor.RunScript(scriptBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                VsShellUtilities.ShowMessageBox(
                    this.package,
                    "An error occurred: " + ex.Message,
                    "Create Database",
                    OLEMSGICON.OLEMSGICON_CRITICAL,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            }
        }
    }
}
