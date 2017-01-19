using ATP.Kiosk.Views;
using MyShopOutDoor.Common;
using MyShopOutDoor.OutDoorProxy;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyShopOutDoor {


    public partial class MenuWindow : UserControl {



        public MenuWindow() {
            InitializeComponent();
            this.Loaded += MenuWindow_Loaded;

        }
        int _dealerId;
        private void MenuWindow_Loaded(object sender, RoutedEventArgs e) {
            _dealerId = ConfigClass.DealerId;

            var res1 = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
                return svcs.UpsertKioskInUSE(_dealerId, null, new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
            });

        }

      



        private void cmdKeysPickUp_Click(object sender, RoutedEventArgs e) {

            if (CheckIfKioskIsInUse() == true) {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Uri("KeyPickUpWindow.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void cmdDropKeys_Click(object sender, RoutedEventArgs e) {
            if (CheckIfKioskIsInUse() == true) {
                NavigationService nav = NavigationService.GetNavigationService(this);

                nav.Navigate(new Uri("KeyDropWindow.xaml", UriKind.RelativeOrAbsolute));
            }

        }
        
        private bool CheckIfKioskIsInUse() {
            var res = new List<uspSelKioskInUSE_Result>();
            try {
                res = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
                    return svcs.SelKioskInUSE(_dealerId).ToList();
                });


                if (res != null && res.Count == 1) {
                    if (res.FirstOrDefault().IsMachineInUse == true) {
                        MessageBox("Kiosk InUse by Dealer, Please try in few minutes ...");
                        return false;
                    }
                    else {

                        var res1 = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
                            return svcs.UpsertKioskInUSE(_dealerId,"C",new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
                        });

                    }
                }
            }

            catch (Exception ex) {
                MessageBox(ex.Message.ToString(), "Error !");
            }

            return true;
        }


        private void CtrlMenuWindow_Unloaded(object sender, RoutedEventArgs e) {
            if (ConfigClass.CustomerSerialPort.IsOpen) { ConfigClass.CustomerSerialPort.Close(); }
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
