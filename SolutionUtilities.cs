using System.IO;
using Microsoft.VisualStudio.Shell;
using System.Threading.Tasks;

namespace CaseOneToolkit
{
    public static class SolutionUtilities
    {
        public static string ScriptCaseProTools => "ProjectTemplates\\CaseMap.T4\\Scripts\\CaseProTools.psm1";

        public static async Task<string> GetActiveProjectRootPathAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            var dte = await ServiceProvider.GetGlobalServiceAsync(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
            if (dte?.Solution == null) return null;

            var solutionFilePath = dte.Solution.FullName;
            return string.IsNullOrEmpty(solutionFilePath) ? null : Path.GetDirectoryName(solutionFilePath);
        }
    }
}
