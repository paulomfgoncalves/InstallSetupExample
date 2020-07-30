using System;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace InstallUtils
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("'UtilInstall' Started.");

            try
            {
                if (args.Length != 2)
                    throw new Exception("Invalid params.");

                string action = args[0];
                string targetDir = args[1].Replace("\"", ""); ;
                string batchFile = "";

                switch (action)
                {
                    case "INSTALL":
                        batchFile = "APP_Install.bat";
                        break;
                    case "COMMIT":
                        batchFile = "APP_Commit.bat";
                        break;
                    case "ROLLBACK":
                        batchFile = "APP_Rollback.bat";
                        break;
                    case "UNINSTALL":
                        batchFile = "APP_Uninstall.bat";
                        break;
                    default:
                        throw new Exception("Invalid action");
                }

                System.Console.WriteLine("Action:" + action);
                System.Console.WriteLine("targetDir:" + targetDir);

                // RUN EXTERNAL PROGRAM //
                Process process = new Process();
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.StartInfo.FileName = Path.Combine(targetDir, batchFile);

                //process.StartInfo.Arguments = "\"" + targetDir + "\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.StartInfo.CreateNoWindow = true;
                //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                //events
                process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (!String.IsNullOrEmpty(e.Data))
                        Console.WriteLine(e.Data);
                });

                process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (!String.IsNullOrEmpty(e.Data))
                        Console.WriteLine(e.Data);
                });

                process.EnableRaisingEvents = true;

                Console.WriteLine("StartInfo.FileName:" + process.StartInfo.FileName);

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();

                if (process.ExitCode != 0)
                    throw new Exception(String.Format("'{0}' terminated with ExitCode={1}", batchFile, process.ExitCode.ToString()));
            }
            catch (Exception ex)
            {
                Console.WriteLine("'UtilInstall' ERROR: {0}", ex.Message);
                    Thread.Sleep(15000);
                Environment.Exit(1);
            }

            Console.WriteLine("'UtilInstall' Finished SUCCESSFULLY.");
                Thread.Sleep(15000);
            Environment.Exit(0);
        }

    }
}
