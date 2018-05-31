using System;
using System.Diagnostics;

namespace ScriptExecutor
{
    public class ExecutePythonScript
    {
        public void ExecuteScript(string pathToExe, string pathToScript)
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo(pathToExe, pathToScript)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}

