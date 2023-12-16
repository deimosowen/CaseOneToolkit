using EnvDTE;
using System;
using System.Diagnostics;

namespace CaseMapCoreInitExtension
{
    public static class PowerShellExecutor
    {
        public static void RunScript(string scriptText)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            try
            {
                var objDte = System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE") as DTE;
                objDte.ExecuteCommand("View.PackageManagerConsole", scriptText);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error executing package manager console command: " + ex.Message);
            }
        }
    }
}
