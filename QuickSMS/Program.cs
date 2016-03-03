using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using SMSPDULib;

namespace QuickSMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] data)
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Exception excep = e.ExceptionObject as Exception;
                if (excep != null)
                {
                    try
                    {
                        StreamWriter sw;
                        String filename = Application.ExecutablePath + ".LOG";
                        sw = new StreamWriter(File.Open(filename, FileMode.Append));
                        sw.WriteLine(Environment.NewLine + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + Environment.NewLine + excep);
                        sw.Close();
                    }
                    catch (Exception) { }
                }
            };

            bool developerFlag=false;
            if (data.Length > 0)
            {
                if (data[0].Equals("developermode"))
                    developerFlag = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashScreen ss = new SplashScreen();
            Application.Run(ss);
            Activation activation = new Activation(developerFlag);
            if (activation.setSerialNumber())
            {
                Application.Run(activation);
                if (activation.Suc)
                {
                    DatabasePath = Application.ExecutablePath + ".database";
                    Main main = new QuickSMS.Main();
                    Application.Run(main);
                }
            }
            else
            {
                try
                {
                    StreamWriter sw;
                    String filename = Application.ExecutablePath + ".LOG";
                    sw = new StreamWriter(File.Open(filename, FileMode.Append));
                    sw.WriteLine(Environment.NewLine + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + Environment.NewLine + "Unable to handle activation process!!");
                    sw.Close();
                }
                catch (Exception) { }
            }
        }
        public static String DatabasePath="";
    }
}
