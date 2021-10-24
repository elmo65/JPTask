using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace JPTask01
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine(i + ": " + args[i]);
                if (args[i] == "-h")
                {
                    Console.WriteLine("Tee metodi, joka näyttää helppiä, jos pyydetään (-h) tai annetaan vääriä tai puutteellisia parameterja.");
                }
            }
            RunCMD();
        }

        private static void RunCMD()
        {

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            List<string> files = new List<string> { @"C:\Users\TeemuPC\Pictures\test1.png", @"C:\Users\TeemuPC\Pictures\test2.png", @"C:\Users\TeemuPC\Pictures\test3.png", @"C:\Users\TeemuPC\Pictures\test4.png" };
            
            int i = 0;
            while (i < 5)
            {
                foreach (string item in files)
                {
                    process.StandardInput.WriteLine(item);
                    Thread.Sleep(5000);
                    process.StandardInput.WriteLine(@"taskkill /F /IM Microsoft.Photos.exe");
                }
                i++;
            }
            process.Kill();
        }

    }
}
