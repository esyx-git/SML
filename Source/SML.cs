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
            string executable3 = doc.SelectSingleNode("/Configuration/LLM").InnerText;
            string executable4 = doc.SelectSingleNode("/Configuration/Herika").InnerText;
            string executable5 = doc.SelectSingleNode("/Configuration/xVASynth").InnerText;

            string directory1 = Path.GetDirectoryName(executable1);
            string directory2 = Path.GetDirectoryName(executable2);
            string directory3 = Path.GetDirectoryName(executable3);
            string directory4 = Path.GetDirectoryName(executable4);
            string directory5 = Path.GetDirectoryName(executable5);

            bool useExecutable3 = bool.Parse(doc.SelectSingleNode("/Configuration/UseLLM").InnerText);
            bool useExecutable4 = bool.Parse(doc.SelectSingleNode("/Configuration/UseHerika").InnerText);
            bool useExecutable5 = bool.Parse(doc.SelectSingleNode("/Configuration/UsexVASynth").InnerText);


            Console.WriteLine("Opening Mod Organizer and monitoring process.");

            ProcessStartInfo startInfo = new ProcessStartInfo(executable1);
            startInfo.WorkingDirectory = directory1;
            Process mainProcess = Process.Start(startInfo);

            Console.WriteLine("Opening Mantella and monitoring process.");

            ProcessStartInfo startInfo2 = new ProcessStartInfo(executable2);
            startInfo2.WorkingDirectory = directory2;
            startInfo2.WindowStyle = ProcessWindowStyle.Minimized;
            Process process2 = Process.Start(startInfo2);

            if (useExecutable3)
            {
                Console.WriteLine("Opening LLM and monitoring process.");

                ProcessStartInfo startInfo3 = new ProcessStartInfo(executable3);
                startInfo3.WorkingDirectory = directory3;
                startInfo3.WindowStyle = ProcessWindowStyle.Minimized;
                Process process3 = Process.Start(startInfo3);

                mainProcess.WaitForExit();

                if (!process3.HasExited)
                {
                    process3.CloseMainWindow();
                    process3.WaitForExit();
                }
            }

            if (useExecutable4)
            {
                Console.WriteLine("Opening Herika and monitoring process.");

                ProcessStartInfo startInfo4 = new ProcessStartInfo(executable4);
                startInfo4.WorkingDirectory = directory4;
                startInfo4.WindowStyle = ProcessWindowStyle.Minimized;
                Process process4 = Process.Start(startInfo4);

                mainProcess.WaitForExit();

                if (!process4.HasExited)
                {
                    process4.CloseMainWindow();
                    process4.WaitForExit();
                }
            }

            if (useExecutable5)
            {

                Console.WriteLine("Opening xVASynth and monitoring process.");

                ProcessStartInfo startInfo5 = new ProcessStartInfo(executable5);
                startInfo5.WorkingDirectory = directory5;
                startInfo5.WindowStyle = ProcessWindowStyle.Minimized;
                Process process5 = Process.Start(startInfo5);

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

            Console.WriteLine("\nSuccess! This window will close in 3 seconds...");
            Thread.Sleep(3000);
        }
    }
}