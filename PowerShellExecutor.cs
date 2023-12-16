using System;
using System.Diagnostics;

namespace CaseMapCoreInitExtension
{
    public static class PowerShellExecutor
    {
        public static void RunScript(string scriptText)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -Command \"{scriptText}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            RunProcess(startInfo);
        }

        private static void RunProcess(ProcessStartInfo startInfo)
        {
            using (var process = Process.Start(startInfo))
            {
                using (var reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                }

                using (var reader = process.StandardError)
                {
                    string error = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(error))
                    {
                        throw new InvalidOperationException(error);
                    }
                }
            }
        }
    }
}
