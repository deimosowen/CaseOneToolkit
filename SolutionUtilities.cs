using Microsoft.VisualStudio.Shell;
using System.Threading.Tasks;

namespace CaseMapCoreInitExtension
{
    public static class SolutionUtilities
    {
        public static string ScriptCaseProTools => "ProjectTemplates\\CaseMap.T4\\Scripts\\CaseProTools.psm1";

        public static async Task<string> GetActiveProjectRootPathAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            var dte = await ServiceProvider.GetGlobalServiceAsync(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
            if (dte?.Solution?.Projects == null) return null;

            foreach (EnvDTE.Project project in dte.Solution.Projects)
            {
                if (project.Properties.Item("FullPath") is EnvDTE.Property fullPathProperty)
                {
                    return fullPathProperty.Value.ToString();
                }
            }

            return null;
        }
    }
}
