using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoGreatWay
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = Directory.GetFiles(@"C:\temp", "*py", SearchOption.AllDirectories);

            var t = d;

            int count = 0;

            foreach(var x in t)
            {
                var z = x;
                var test = File.ReadLines(z).Any(q => q.Contains("xml"));
                if(test)
                {
                    Console.WriteLine("this is probably an XML parsing python script");
                    count++;
                }
            }

            if (count==2)
            {
                foreach(var x in t)
                {
                    if(x == @"C:\temp\xmlparse.py")
                    {
                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(@"C:\Users\########\AppData\Local\Programs\Python\Python36-32\python.exe", x)
                        {
                            RedirectStandardError = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };
                        p.Start();
                        var o = p.StandardOutput.ReadToEnd();
                        p.WaitForExit();

                        Console.WriteLine(o);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
