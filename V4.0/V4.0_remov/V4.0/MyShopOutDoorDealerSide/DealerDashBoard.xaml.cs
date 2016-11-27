using ATP.Kiosk.Views;
using MyShopOutDoor.Common;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Xml;


namespace MyShopOutDoor {


    public partial class DealerDashBoard : Page {

        int _dealerId = ConfigClass.DealerId;
        public DispatcherTimer dispatcherTimer;
        public DealerDashBoard() {
            InitializeComponent();

            LoadConfig();
            _dealerId = ConfigClass.DealerId;
            this.Loaded += DealerDashBoard_Loaded;
            this.Unloaded += DealerDashBoard_Unloaded;
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 60);
        }

        private void LoadConfig() {


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
                ConfigClass.DealerSerialPort.PortName = xmlnode["DEALERCOMMPORT"].InnerText;
               // ConfigClass.CustomerSerialPort.PortName = xmlnode["CUSTCOMMPORT"].InnerText;


                if (!ConfigClass.DealerSerialPort.IsOpen) { ConfigClass.DealerSerialPort.Open(); }
              //  if (!ConfigClass.CustomerSerialPort.IsOpen) { ConfigClass.CustomerSerialPort.Open(); }



            }
            catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message);



            }
        }

        private void DealerDashBoard_Unloaded(object sender, RoutedEventArgs e) {
            dispatcherTimer.Stop();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) {
            RefreshGrid();
        }
        private void DealerDashBoard_Loaded(object sender, RoutedEventArgs e) {
            RefreshGrid();
            dispatcherTimer.Start();
        }

        private void RefreshGrid() {
            try {

                var res = ATP.Common.ProxyHelper.Service<MyShopOutDoorDealerSide.OutDoorProxy.IOutDoor>.Use(svcs => {
                    return svcs.SelAllKeyDropPegByDealerId(ConfigClass.DealerId);
                });
                LstPerson.ItemsSource = null;
               // LstPerson.Items.Clear();
               LstPerson.ItemsSource = res;
              //  LstPerson.Items.Refresh();
            }
            catch (Exception ex) {
                MessageBox(ex.Message.ToString(), "Error !");
            }
        }

        private void LstPerson_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            if(LstPerson.SelectedItem == null) { return; }

            var wnd = new MyShopOutDoor.DealerSide.PickUpOrDrop();
            this.Opacity = 0.5;
            var selectedPerson = (MyShopOutDoorDealerSide.OutDoorProxy.uspSelAllKeyDropPegByDealerId_Result)LstPerson.SelectedItem;

            if (selectedPerson.VehicleGuid == null) {
                //wnd.TxtMessage.Text = "Go To the web site and change the status to ready for keydrop..";
                //wnd.cmdCustomer.Visibility = Visibility.Collapsed;
                //wnd.cmdPlaceKeys.Visibility = Visibility.Collapsed;
                MessageBox("Go To Service Writer's Desk, Using MyShopAuto web site and change the status to ready for keydrop..");
            }
            else {
                wnd.SelectedPerson = selectedPerson;

              
                var confirm = wnd.ShowDialog();
            }
            // LstPerson.UnselectAll();
            this.Opacity = 1;
            RefreshGrid();

        }

        private static void MessageBox(string msg, string header = "Information") {
            var wnd = new AdamMessageBox();
            wnd.TxtError.Text = msg;
            wnd.TxtHeader.Text = header;
            wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
            wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
            wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;

            var confirm = wnd.ShowDialog();
        }
    }
}
