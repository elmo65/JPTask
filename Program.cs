using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace JPTask01
{
    class Program
    {
        static String message = @"Tee metodi, joka näyttää helppiä, jos pyydetään (-h) tai annetaan vääriä tai puutteellisia parameterja.
        args on taulukko komentoriviparametreja.
        Käytä Directory.EnumerateFiles tiedostojen hakuun annetusta hakemistosta
        https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.enumeratefiles?view=net-5.0#System_IO_Directory_EnumerateFiles_System_String_System_String_System_IO_SearchOption_
        ";

        static String directory;
        static String configFile;

        static void Main(string[] args)
        {

            for (int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine(i + ": " + args[i]);
                if (args[i] == "-h")
                {
                    Console.WriteLine(message);
                    Environment.Exit(1);
                }
            }
            if (String.IsNullOrWhiteSpace(directory) && String.IsNullOrWhiteSpace(configFile)) {
                Console.WriteLine("Komentoriviparametrit puuttuu !");
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
