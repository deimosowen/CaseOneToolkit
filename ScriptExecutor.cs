using Microsoft.VisualStudio.Shell;
using System;
using System.Diagnostics;

namespace CaseOneToolkit
{
    public static class ScriptExecutor
    {
        public static void RunScript(string scriptText)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{scriptText}\"",
                    UseShellExecute = false
                };

                using (var process = Process.Start(startInfo))
                {
                    var output = process.StandardOutput.ReadToEnd();
                    var errors = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(output))
                    {
                        Debug.WriteLine("PowerShell Output: " + output);
                    }
                    if (!string.IsNullOrEmpty(errors))
                    {
                        Debug.WriteLine("PowerShell Errors: " + errors);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error executing PowerShell script: " + ex.Message);
            }
        }
    }
}
