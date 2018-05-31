namespace BetterWay
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"C:\temp", "*py", SearchOption.AllDirectories);

            var count = 0;

            foreach (var file in files)
            {
                var test = File.ReadLines(file).Any(theFile => theFile.Contains("xml"));
                if (test)
                {
                    Console.WriteLine("this is probably an XML parsing python script");
                    count++;
                }
            }

            if (count == 2)
            {
                foreach (var file in files)
                {
                    if (file == @"C:\temp\xmlparse.py")
                    {
                        var process = new Process();
                        process.StartInfo = new ProcessStartInfo(@"C:\Users\########\AppData\Local\Programs\Python\Python36-32\python.exe", file)
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
        }
    }
}
