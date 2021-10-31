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
            Config config;
            try 
            {
                config = Config.ParseParameters(args);
            }
            catch (ConfigException e) 
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
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

            // tähän haetaan ne tiedostot Directory.EnumerateFiles:llä
            List<string> files = new List<string> { @"C:\Users\TeemuPC\Pictures\test1.png", @"C:\Users\TeemuPC\Pictures\test2.png", @"C:\Users\TeemuPC\Pictures\test3.png", @"C:\Users\TeemuPC\Pictures\test4.png" };

            int i = 0;
            while (i < 5)
            {
                foreach (string item in files)
                {
                    process.StandardInput.WriteLine(item);
                    Thread.Sleep(5000);
                    // ei käyttäjällä välttämättä toimi näin
                    process.StandardInput.WriteLine(@"taskkill /F /IM Microsoft.Photos.exe");
                }
                i++;
            }
            process.Kill();
        }

    }
}
