using MyShopOutDoor.Common;
using System;
using System.IO;
using System.Windows;
using System.Windows.Navigation;
using System.Xml;

namespace MyShopOutDoor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow {
        public MainWindow() {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {


            var dir = @"c:\Sites";
            var filedir = dir + "\\MyShopApp.xml";
            XmlDocument xdoc = new XmlDocument();
            try {
                if (!Directory.Exists(dir)) {
                    Directory.CreateDirectory(dir);
                }
                if (!File.Exists(filedir)) {
                    string s = "<ROOT><DEALERID>116</DEALERID><DEALERCOMMPORT>COM4</DEALERCOMMPORT><CUSTCOMMPORT>COM5</CUSTCOMMPORT></ROOT>";

                    xdoc.LoadXml(s);
                    xdoc.Save(@"c:\Sites\MyShopApp.xml");
                }

                xdoc.Load(filedir);
                XmlNode xmlnode;
                xmlnode = xdoc.SelectSingleNode("ROOT");
                ConfigClass.DealerId = Convert.ToInt32(xmlnode["DEALERID"].InnerText);


                return;

                SerialPortInterface sp = new SerialPortInterface(); // load port details
               // ConfigClass.DealerSerialPort.PortName = xmlnode["DEALERCOMMPORT"].InnerText;
               ConfigClass.CustomerSerialPort.PortName = xmlnode["CUSTCOMMPORT"].InnerText;


                if (!ConfigClass.DealerSerialPort.IsOpen) { ConfigClass.DealerSerialPort.Open(); }
                if (!ConfigClass.CustomerSerialPort.IsOpen) { ConfigClass.CustomerSerialPort.Open(); }



            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);



            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            return;
            if (!ConfigClass.DealerSerialPort.IsOpen) { ConfigClass.DealerSerialPort.Close(); }
            if (!ConfigClass.CustomerSerialPort.IsOpen) { ConfigClass.CustomerSerialPort.Close(); }

        }

        // NavigationService svc;// = new NavigationService();
        private void cmdKeysPickUp_Click(object sender, RoutedEventArgs e) {

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("KeyPickUpWindow.xaml", UriKind.RelativeOrAbsolute));


        }
    }
}
