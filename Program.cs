using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using JPTask01.Configuration;   // Configuration is in its own namespace
namespace JPTask01
{
    class Program
    {

        /*
            To get help run: jptask.exe -h or jptask.exe --help.
        */
        static void Main(string[] args)
        {
            Config config;
            try 
            {
                // Create valid configuration from command line parameters
                config = Config.ParseParameters(args);
            }
            catch (ConfigException e) 
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
            // Here we know, that configuration is usable
            
            /*
                We create a Program object and run a instance method.
                In this way we can add (non static) fields to Program class and
                use them in the methods. This is a bit more object oriented
                programming style and the using static methods is a more
                procedural style.

                Not necessary, but I like this style more. 
                Also statics are a bit bad, because the way their memory is reserved
                at the application startup time and never relinguished (before
                application shutdown). In long running applications that may
                be a factor. But in many times it really does not matter.
            */
            Program app = new Program();
            app.RunCMD();
        }

        private void RunCMD()
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
