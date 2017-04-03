using ATP.DataModel;
using ATP.Kiosk.Views;
using ATP.WCF.Svcs;
using MyShopExpress.Common;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MyShopExpress {
    /// <summary>
    /// Interaction logic for TowTruck.xaml
    /// </summary>
    public partial class TowTruck : Window {

        private AdamMessageBox wnd;
        public TowTruck() {
            InitializeComponent();
            wnd = new AdamMessageBox();
            wnd.BtnNo.Click += BtnNo_Click;
            this.Loaded += TowTruck_Loaded;
        }

        int _dealerId;

        private void TowTruck_Loaded(object sender, RoutedEventArgs e) {

            _dealerId = ConfigClass.DealerId;
        }



        private void BtnNo_Click(object sender, RoutedEventArgs e) {
        }

        private void GoHome() {
            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));
            this.Close();
        }


        private void cmdBack_Click(object sender, RoutedEventArgs e) {
            GoHome();
        }
        private string FindHomeAndMoveStepsReading { get; set; }
        private string RotateKeyFloorReading { get; set; }
        private string DoorLatchReading { get; set; }

        public byte? OutDoorKeyDroppedBy { get; set; }


        //private void CmdDropKeys_Click(object sender, RoutedEventArgs e) {

        //    ConfigClass.SendCommandToBoard("FH" + FindHomeAndMoveStepsReading );
        //    // _serialPort.Write("KF170000 \n");
        //    ConfigClass.SendCommandToBoard(RotateKeyFloorReading);
        //}


        private void cmdDropKeys_Click(object sender, RoutedEventArgs e) {

            if (String.IsNullOrEmpty(TxtPhone.Text) || String.IsNullOrEmpty(TxtName.Text)) {

                MessageBox("Please enter Name and Phone Number before you drop the keys", "Information");
                return;
            }

            try {
                // wnd = new AdamMessageBox();
                //Application.Current.Dispatcher.Invoke(() => {
                //  if (Mouse.OverrideCursor != Cursors.Wait)
                //    Mouse.OverrideCursor = Cursors.Wait;
                //});


                var stepsLst = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
                    return svcs.GetKeyLockerSteps(_dealerId, null, true).ToList();
                });

                if (stepsLst != null && stepsLst.Count > 0) {
                    FindHomeAndMoveStepsReading = stepsLst.Where(m => m.StepCode == "FH").SingleOrDefault().NoOfRotationCustomer;
                    RotateKeyFloorReading = stepsLst.Where(m => m.StepCode == "KF").SingleOrDefault().StepReading;
                    DoorLatchReading = stepsLst.Where(m => m.StepCode == "DL").SingleOrDefault().StepReading;

                    if (FindHomeAndMoveStepsReading == "0000") {
                        MessageBox("Electronic Key Locker is Full \n Sorry try another time..", "Information");
                        return;
                    }

                    this.Opacity = .1;
                    MyKeyboard.Visibility = Visibility.Collapsed;

                    MyKeyboard.IsOpen = false;


                    var wnd = new PickUpOrDrop { OutDoorKeyDroppedBy  = OutDoorKeyDroppedBy };

                    wnd.SelectedPerson = new uspSelAllKeyDropPegByDealerId_Result {
                        FirstName = TxtName.Text,
                        PhoneNumber = TxtPhone.Text,

                        NoOfRotationDealer = FindHomeAndMoveStepsReading,
                        ServiceStatus = 4
                    };

                    wnd.CustomerInfo = new uspVerifyPinGetCustInfo_Result {
                        FirstName = TxtName.Text,
                        PhoneNumber = TxtPhone.Text,
                        NoOfRotationCustomer = FindHomeAndMoveStepsReading,
                        Comments = TxtNotes.Text
                    };

                    wnd.ShowDialog();

                    this.Opacity = 1;
                    MyKeyboard.Visibility = Visibility.Visible;
                    MyKeyboard.IsOpen = true;

                    // if (wnd.IsKeyDroppedClcked == true) {
                    GoHome();
                    // }

                }
                else {
                    MessageBox("Electronic Key Locker is Full \n Sorry try another time..", "Information");
                }

            }
            catch (Exception ex) {

                var stepsLst = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
                    return svcs.LogError(ex.Message);
                });

            }
            //Application.Current.Dispatcher.Invoke(() => {
            //  if (Mouse.OverrideCursor != Cursors.Arrow)
            //    Mouse.OverrideCursor = Cursors.Arrow;
            //});

        }

        //   private static  AdamMessageBox wnd;//= new AdamMessageBox();
        private void MessageBox(string msg, string header = "Information") {
            //var 
            Opacity = .1;
            wnd = new AdamMessageBox();
            wnd.TxtError.Text = msg;
            wnd.TxtHeader.Text = header;
            wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
            wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
            wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;


            MyKeyboard.IsOpen = false;
            var confirm = wnd.ShowDialog();
            MyKeyboard.IsOpen = true;
            Opacity = 1;
        }

        private void TxtNotes_GotFocus(object sender, RoutedEventArgs e) {
            MyKeyboard.Focus();
            MyKeyboard.BringIntoView();

        }
    }
}
