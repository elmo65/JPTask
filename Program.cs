using System;
using System.Diagnostics;
using System.Threading;

namespace JPTask01
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCMD();
        }

        private static void RunCMD()
        {

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            int i = 0;
            while (i < 5)
            {
                process.StandardInput.WriteLine(@"C:\Users\TeemuPC\Pictures\test1.png");
                Thread.Sleep(5000);     //this is how I got waiting working, but I think I have read somewhere Thread.Sleep() is not good practice??
                process.StandardInput.WriteLine(@"taskkill /F /IM Microsoft.Photos.exe");
                process.StandardInput.WriteLine(@"C:\Users\TeemuPC\Pictures\test2.png");
                Thread.Sleep(5000);
                process.StandardInput.WriteLine(@"taskkill /F /IM Microsoft.Photos.exe");
                process.StandardInput.WriteLine(@"C:\Users\TeemuPC\Pictures\test3.png");
                Thread.Sleep(5000);
                process.StandardInput.WriteLine(@"taskkill /F /IM Microsoft.Photos.exe");
                process.StandardInput.WriteLine(@"C:\Users\TeemuPC\Pictures\test4.png");
                Thread.Sleep(5000);
                process.StandardInput.WriteLine(@"taskkill /F /IM Microsoft.Photos.exe");
                i++;
            }
            process.Kill();
        }
         
    }
}

//

//  photoViewer.StartInfo.FileName = @"The photo viewer file path";
//  photoViewer.StartInfo.Arguments = @"C:\Users\TeemuPC\source\repos\JPTask01\Resources\Images\Computer-Code.jpg";

// string command = @"C:\Users\TeemuPC\source\repos\JPTask01\Resources\Images\Computer-Code.jpg";  
//%SystemRoot%\System32\rundll32.exe "%ProgramFiles%\Windows Photo Viewer\PhotoViewer.dll", ImageView_Fullscreen <full path to image file>



//string command = @"C:\Users\TeemuPC\source\repos\JPTask01\Resources\Images\Computer-Code.jpg";

//Process process = new Process();
//process.StartInfo.FileName = "cmd.exe";
//process.StartInfo.Arguments = command;
//process.Start();

//second Day------------------------------------------------------------------------------------------


//this even works

//using System.IO;
//private static void OpenSamplePhoto()
//{
//    string samplePicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

//    string picturPath = Path.Combine(samplePicturesPath, "Virhe.png");


//    ProcessStartInfo info = new ProcessStartInfo();
//    info.FileName = info.FileName = Path.Combine("ms-photos://", picturPath);
//    info.Arguments = picturPath;
//    info.UseShellExecute = true;
//    info.CreateNoWindow = true;
//    info.Verb = string.Empty;

//    Process.Start(info);s
//}



//if I have command after this it will just execute it

//process.StandardInput.WriteLine(@"timeout /T 5  /NOBREAK");