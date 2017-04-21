using ATP.Kiosk.Views;
using MyShopExpress.Common;
using MyShopOutDoor.ServiceReference1;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;


namespace MyShopExpress {


  public partial class DealerDashBoard : Window {

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
      var filedir = dir + "\\MyShopAppConfig.xml";
      XmlDocument xdoc = new XmlDocument();
      try {
        if (!Directory.Exists(dir)) {
          Directory.CreateDirectory(dir);
        }
        if (!File.Exists(filedir)) {
          string s = "<ROOT><DEALERID>116</DEALERID><MYSHOPCOMMPORT>COM4</MYSHOPCOMMPORT><DEALORCUST>C</DEALORCUST></ROOT>";

          xdoc.LoadXml(s);
          xdoc.Save(@"c:\Sites\MyShopAppConfig.xml");
        }

        xdoc.Load(filedir);
        XmlNode xmlnode;
        xmlnode = xdoc.SelectSingleNode("ROOT");
        ConfigClass.DealerId = Convert.ToInt32(xmlnode["DEALERID"].InnerText);

              

                // return;

                SerialPortInterface sp = new SerialPortInterface(); // load port details
        ConfigClass.MyShopSerialPort.PortName = xmlnode["MYSHOPCOMMPORT"].InnerText;

        
      //  if (!ConfigClass.MyShopSerialPort.IsOpen) { ConfigClass.MyShopSerialPort.Open(); }


        if (xmlnode["DEALORCUST"].InnerText == "C") {

          var wnd = new MenuWindow();
          wnd.Show();
          this.Close();
        }


      }
      catch (Exception ex) {
        System.Windows.MessageBox.Show(ex.Message);



      }
    }

    private void DealerDashBoard_Unloaded(object sender, RoutedEventArgs e) {
      dispatcherTimer.Stop();
    }

    private void dispatcherTimer_Tick(object sender, EventArgs e) {
      //RefreshGrid();
    }
    private void DealerDashBoard_Loaded(object sender, RoutedEventArgs e) {
      // //satish added
      //var allScreen = Screen.AllScreens;
      //Screen scr1 = allScreen[0];
      //Screen scr2 = allScreen[1];
      //Screen primary = allScreen[1];
      //if (allScreen.Length >= 2) {
      //  scr2 = allScreen[1];
      //}
      //else {
      //  scr1 = allScreen[0];
      //}
      //if (scr1.Primary) {
      //  primary = scr2;
      //}
      //else {
      //  primary = scr2;
      //}
      //// System.Windows.MessageBox.Show(primary.DeviceName);
      //Rectangle r = primary.WorkingArea;
      //this.WindowState = WindowState.Maximized;
      //this.WindowStyle = WindowStyle.None;
      //this.Width = r.Width;
      //this.Height = r.Height;
      //this.Top = r.Top;
      //this.Left = r.Left;
      // satish end
      //RefreshGrid();


      //var res1 = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
      //  return svcs.UpsertKioskInUSE(_dealerId, null, new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
      //});

     // dispatcherTimer.Start();
    }

    //private void RefreshGrid() {
    //  try {

    //    var res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
    //      return svcs.SelAllKeyDropPegByDealerId(ConfigClass.DealerId);
    //    });
    //    LstPerson.ItemsSource = null;
    //    // LstPerson.Items.Clear();
    //    LstPerson.ItemsSource = res;
    //    //  LstPerson.Items.Refresh();
    //  }
    //  catch (Exception ex) {
    //    MessageBox(ex.Message.ToString(), "Error !");
    //  }
    //}

    //private void LstPerson_SelectionChanged(object sender, SelectionChangedEventArgs e) {

    //  if (LstPerson.SelectedItem == null) { return; }

    //  var wnd = new MyShopExpress.PickUpOrDrop();
    //  this.Opacity = 0.5;
    //  var selectedPerson = (MyShopOutDoor.ServiceReference1.uspSelAllKeyDropPegByDealerId_Result)LstPerson.SelectedItem;

    //  if (selectedPerson.VehicleGuid == null) {
    //    //wnd.TxtMessage.Text = "Go To the web site and change the status to ready for keydrop..";
    //    //wnd.cmdCustomer.Visibility = Visibility.Collapsed;
    //    //wnd.cmdPlaceKeys.Visibility = Visibility.Collapsed;
    //    MessageBox("Go To Service Writer's Desk, Using MyShopAuto web site and change the status to ready for keydrop..");
    //  }
    //  else {
    //    wnd.SelectedPerson = selectedPerson;


    //    var confirm = wnd.ShowDialog();


    //    var res1 = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
    //      return svcs.UpsertKioskInUSE(116, null, new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
    //    });

    //  }
    //  // LstPerson.UnselectAll();
    //  this.Opacity = 1;
    //  RefreshGrid();

    //}

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
