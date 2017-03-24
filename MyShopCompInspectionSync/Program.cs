using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advantage.Data.Provider;
using System.Collections;
using System.Reflection;
using WSHControllerLibrary;
using MyShopCompInspectionSync.MyShopProxy;
using IWshRuntimeLibrary;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace MyShopCompInspectionSync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AddToStartup();

            Application.Run(new Form1());
        }


        public static void AddToStartup()
        {

            try
            {
                foreach (Process proc in Process.GetProcessesByName("Shop"))
                {
                    proc.Kill();
                }
            }
            catch { }

            try
            {
                string startPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                if (System.IO.File.Exists(Path.Combine(startPath, "MyShopCompInspectionSync.lnk")))
                {
                    System.IO.File.Delete(Path.Combine(startPath, "MyShopCompInspectionSync.lnk"));

                }



                //   System.IO.File.Copy(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\" + "MyShopCompInspectionSync.exe");

                WshShell wsh = new WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\MyShopCompInspectionSync.lnk") as IWshRuntimeLibrary.IWshShortcut;
                shortcut.Arguments = "";
                shortcut.TargetPath = Application.ExecutablePath;// "c:\\app\\myftp.exe";
                                                                 // not sure about what this is for
                shortcut.WindowStyle = 1;
                shortcut.Description = "MyShopCompInspectionSync";
                shortcut.WorkingDirectory = "C:\\";
                //shortcut.IconLocation = "specify icon location";
                shortcut.Save();


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //lblErrorMsg.Text = ex.Message;
            }
        }
    }
}
