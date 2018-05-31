namespace AnotherBetterWay
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    class Program
    {
        private static int FindStringInFiles(string contains, string[] files)
        {
            var count = 0;
            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    var test = File.ReadLines(file).Any(theFile => theFile.Contains(contains));
                    if (test)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static void ExecutePythonScript(string pathToScript)
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo(@"C:\Users\########\AppData\Local\Programs\Python\Python36-32\python.exe", pathToScript)
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
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"C:\temp", "*py", SearchOption.AllDirectories);

            var count = FindStringInFiles("xml", files);
            
            if (count == 2)
            {
                foreach (var file in files.Where(file => file == @"C:\temp\xmlparse.py"))
                {
                    ExecutePythonScript(file);
                }
            }
        }
    }
}
