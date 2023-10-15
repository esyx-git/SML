using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Xml;

namespace SML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Config.xml");

            string executable1 = doc.SelectSingleNode("/Configuration/ModOrganizer").InnerText;
            string executable2 = doc.SelectSingleNode("/Configuration/Mantella").InnerText;
            string executable3 = doc.SelectSingleNode("/Configuration/xVASynth").InnerText;
            string executable4 = doc.SelectSingleNode("/Configuration/LLM").InnerText;
            string executable5 = doc.SelectSingleNode("/Configuration/Herika").InnerText;

            string directory1 = Path.GetDirectoryName(executable1);
            string directory2 = Path.GetDirectoryName(executable2);
            string directory3 = Path.GetDirectoryName(executable3);
            string directory4 = Path.GetDirectoryName(executable4);
            string directory5 = Path.GetDirectoryName(executable5);

            bool useExecutable4 = bool.Parse(doc.SelectSingleNode("/Configuration/UseLLM").InnerText);
            bool useExecutable5 = bool.Parse(doc.SelectSingleNode("/Configuration/UseHerika").InnerText);


            Console.WriteLine("Opening Mod Organizer.");

            ProcessStartInfo startInfo = new ProcessStartInfo(executable1);
            startInfo.WorkingDirectory = directory1;
            Process mainProcess = Process.Start(startInfo);

            Console.WriteLine("Watching Mod Organizer process.");

            Console.WriteLine("Opening Mantella and xVASynth.");

            ProcessStartInfo startInfo2 = new ProcessStartInfo(executable2);
            startInfo2.WorkingDirectory = directory2;
            startInfo2.WindowStyle = ProcessWindowStyle.Minimized;
            Process process2 = Process.Start(startInfo2);

            ProcessStartInfo startInfo3 = new ProcessStartInfo(executable3);
            startInfo3.WorkingDirectory = directory3;
            startInfo3.WindowStyle = ProcessWindowStyle.Minimized;
            Process process3 = Process.Start(startInfo3);

            Console.WriteLine("Watching Mantella and xVASynth processes.");

            if (useExecutable4)
            {
                Console.WriteLine("Opening LLM.");

                ProcessStartInfo startInfo4 = new ProcessStartInfo(executable4);
                startInfo4.WorkingDirectory = directory4;
                startInfo4.WindowStyle = ProcessWindowStyle.Minimized;
                Process process4 = Process.Start(startInfo4);

                Console.WriteLine("Watching LLM process.");

                mainProcess.WaitForExit();

                if (!process4.HasExited)
                {
                    process4.CloseMainWindow();
                    process4.WaitForExit();
                }
            }

            if (useExecutable5)
            {

                Console.WriteLine("Opening Herika.");

                ProcessStartInfo startInfo5 = new ProcessStartInfo(executable5);
                startInfo5.WorkingDirectory = directory5;
                startInfo5.WindowStyle = ProcessWindowStyle.Minimized;
                Process process5 = Process.Start(startInfo5);

                Console.WriteLine("Watching Herika process.");

                mainProcess.WaitForExit();

                if (!process5.HasExited)
                {
                    process5.CloseMainWindow();
                    process5.WaitForExit();
                }
            }

            mainProcess.WaitForExit();

            Console.WriteLine("Mod Organizer has closed. Now closing other applications.");

            if (!process2.HasExited)
            {
                process2.CloseMainWindow();
                process2.WaitForExit();
            }

            if (!process3.HasExited)
            {
                process3.CloseMainWindow();
                process3.WaitForExit();
            }

            Console.WriteLine("\nSuccess! This window will close in 3 seconds...");
            Thread.Sleep(3000);
        }
    }
}