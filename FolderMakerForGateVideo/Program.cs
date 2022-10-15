using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FolderMakerForGateVideo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                StreamWriter sr = new StreamWriter(Path.Combine(desktopPath, "Exception.txt"));
                sr.Write(eventArgs.Exception.ToString());
                //Clipboard.SetText(eventArgs.Exception.ToString());
                Debug.WriteLine(eventArgs.Exception.ToString());
                sr.Close();
                sr.Dispose();
            };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Temp());
            Application.Run(new Form1());

        }
    }
}
