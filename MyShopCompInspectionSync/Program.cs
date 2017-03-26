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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           // AddToStartup();

            Application.Run(new Form1());
        }


     
    }
}
