using ATP.Kiosk.Views;
using MyShopExpress.Common;
using OutDoorCustomer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace MyShopExpress {


    public partial class MenuWindow : Window {

        public static DispatcherTimer dispatcherTimer;

        public MenuWindow() {
            InitializeComponent();
            this.Loaded += MenuWindow_Loaded;
            this.Unloaded += MenuWindow_Unloaded;

        }

        private void MenuWindow_Unloaded(object sender, RoutedEventArgs e)
        {
           
        }

        int _dealerId;
        private void MenuWindow_Loaded(object sender, RoutedEventArgs e) {
            _dealerId = ConfigClass.DealerId;

            //var res1 = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
            //    return svcs.UpsertKioskInUSE(_dealerId, null, new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
            //});

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 300);


           // cmdNoPhoneDrop_Click(sender, e);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (Window win in App.Current.Windows)
            {
                if (!win.IsFocused && win.Tag != null && win.Tag.ToString() == "mdi_child")
                {
                    win.Close();
                }
            }

            dispatcherTimer.Stop();
        }



        private void cmdKeysPickUp_Click(object sender, RoutedEventArgs e) {

            //if (CheckIfKioskIsInUse() == true) {
            //    NavigationService nav = NavigationService.GetNavigationService(this);
            //    nav.Navigate(new Uri("KeyPickUpWindow.xaml", UriKind.RelativeOrAbsolute));
            //}

            if (CheckIfKioskIsInUse() == true) {
                this.Opacity = .5;
                var wnd = new CustomerKeyDropWindow {
                    IsPickUpOrDrop = false
                };
                wnd.ShowDialog();
                this.Opacity = 1;
                ReSetLock();
            }
        }

        //private void cmdDropKeysByPhone(object sender, RoutedEventArgs e) {
        //  if (CheckIfKioskIsInUse() == true) {
        //    this.Opacity = .5;
        //    var wnd = new CustomerKeyDropWindow();
        //    wnd.ShowDialog();
        //    this.Opacity = 1;

        //  }

        //}

        private bool CheckIfKioskIsInUse() {

            return true;

            //var res = new List<uspSelKioskInUSE_Result>();
            try {
            //    res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
            //        return svcs.SelKioskInUSE(_dealerId).ToList();
            //    });


            //    if (res != null && res.Count == 1) {
            //        if (res.FirstOrDefault().IsMachineInUse == true) {
            //            MessageBox("Kiosk InUse by Dealer, Please try in few minutes ...");
            //            return false;
            //        }
            //        else {

            //            var res1 = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
            //                return svcs.UpsertKioskInUSE(_dealerId, "C", new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
            //            });

            //        }
            //    }
            }

            catch (Exception ex) {
                MessageBox(ex.Message.ToString(), "Error !");
            }

            return true;
        }


        private void CtrlMenuWindow_Unloaded(object sender, RoutedEventArgs e) {
            if (ConfigClass.MyShopSerialPort.IsOpen) { ConfigClass.MyShopSerialPort.Close(); }
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

        private void cmdTowTruckPickUp_Click(object sender, RoutedEventArgs e) {
            if (CheckIfKioskIsInUse() == true) {
                dispatcherTimer.Start();
                var wnd = new TowTruck { OutDoorKeyDroppedBy = 2 };
                wnd.Tag = "mdi_child";
                wnd.ShowDialog();
                ReSetLock();
            }
        }

        private void cmdDropKeysByPhone_Click(object sender, RoutedEventArgs e) {
            if (CheckIfKioskIsInUse() == true) {
                dispatcherTimer.Start();
                this.Opacity = .5;
                var wnd = new CustomerKeyDropWindow {
                    IsPickUpOrDrop = true,
                     OutDoorKeyDroppedBy = 3 
                };
                wnd.Tag = "mdi_child";
                wnd.ShowDialog();
                this.Opacity = 1;
                ReSetLock();
            }
        }

        private void ReSetLock() {
            var res1 = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
                return svcs.UpsertKioskInUSE(_dealerId, null, new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
            });
        }

        private void cmdPickUpKeysByPhone_Click(object sender, RoutedEventArgs e) {
            if (CheckIfKioskIsInUse() == true) {
                this.Opacity = .5;
                dispatcherTimer.Start();
                var wnd = new CustomerKeyDropWindow();
                wnd.IsPickUpOrDrop = false; // pickup
                wnd.Tag = "mdi_child";
                wnd.ShowDialog();
                this.Opacity = 1;
                ReSetLock();
            }
        }

        private void cmdNoPhoneDrop_Click(object sender, RoutedEventArgs e) {
            if (CheckIfKioskIsInUse() == true) {
                dispatcherTimer.Start();
                var wnd = new NoPhoneApp { OutDoorKeyDroppedBy = 3 };
                wnd.Tag = "mdi_child";
                wnd.ShowDialog();
                ReSetLock();
            }
        }
    }
}
