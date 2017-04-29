
using ATP.DataModel;
using ATP.Kiosk.Helpers;
using ATP.Kiosk.Views;
using KeyPad;
using MyShopExpress.Common;
using OutDoorCustomer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MyShopExpress
{
    /// <summary>
    /// Interaction logic for TowTruck.xaml
    /// </summary>
    public partial class NoPhoneApp : Window
    {

        private AdamMessageBox wnd;
        public NoPhoneApp()
        {
            InitializeComponent();
            wnd = new AdamMessageBox();
            wnd.BtnNo.Click += BtnNo_Click;
            this.Loaded += TowTruck_Loaded;
        }

        int _dealerId;

        private void TowTruck_Loaded(object sender, RoutedEventArgs e)
        {

            _dealerId = ConfigClass.DealerId;
            SelectedServiceList = new List<uspSelSvcTypeByDealerId_Result>();

           // LstServiceItems.Items.Clear();
            LstServiceItems.SelectedIndex = -1;
        }



        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
        }

        private void GoHome()
        {
            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));
            this.Close();
        }


        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            GoHome();
        }
        private string FindHomeAndMoveStepsReading { get; set; }
        private string RotateKeyFloorReading { get; set; }
        private string DoorLatchReading { get; set; }

        public byte? OutDoorKeyDroppedBy { get; set; }


        private void LstServiceItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var currentSelectedService = new uspSelSvcTypeByDealerId_Result();

            ////if (!App.GatpUserRecord.SelectedServiceTypeList.Any())
            ////{
            ////    LstServiceItems.UnselectAll();
            ////}

            //if (TxtDescription != null)
            //{
            //    TxtDescription.Document = null;
            //}

            if (e.RemovedItems.Count > 0)
            {
               currentSelectedService = (uspSelSvcTypeByDealerId_Result)e.RemovedItems[0];
                SelectedServiceList.Remove(currentSelectedService);

            //    if (currentSelectedService.ShortName.ToLower().Contains("multi point inspection") || currentSelectedService.ShortName.ToLower().Contains("complimentary 16 point inspection"))
            //    {
            //        var multipoint = DealerServiceList.SingleOrDefault(m => m.ShortName.ToLower().Contains("multi point inspection"));
            //        var multipoint1 = DealerServiceList.SingleOrDefault(m => m.ShortName.ToLower().Contains("complimentary 16 point inspection"));

            //        if (multipoint != null)
            //        {
            //            LstServiceItems.SelectedItems.Add(multipoint);
            //            return;
            //        }
            //        if (multipoint1 != null)
            //        {
            //            LstServiceItems.SelectedItems.Add(multipoint1);
            //            return;
            //        }
            //    }

            }

            if (e.AddedItems.Count > 0 && SelectedServiceList != null)
            {
                currentSelectedService = (uspSelSvcTypeByDealerId_Result)e.AddedItems[0];
                SelectedServiceList.Add(currentSelectedService);
            }



        }

        public List<uspSelSvcTypeByDealerId_Result> SelectedServiceList { get; set; }

        public uspSelSvcTypeByDealerId_Result SelectedService { get; set; }
        private List<uspSelSvcTypeByDealerId_Result> _dealerServiceList;
        public List<uspSelSvcTypeByDealerId_Result> DealerServiceList {
            get {
                if (_dealerServiceList == null)
                {
                    // _dealerId = 105;
                    _dealerId = ConfigClass.DealerId;
                    _dealerServiceList = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs =>
                    {

                        return svcs.GetServiceTypes(_dealerId.ToString()).Where(m => m.Express == true).ToList();
                    });

                    _dealerServiceList.Update(x => x.OpacityVal = 1);
                    _dealerServiceList.Update(x => x.IsEnabledVal = true);


                }

                return _dealerServiceList;
            }
            set {
                _dealerServiceList = value;
            }
        }

        private void cmdDropKeys_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(TxtPhone.Text) || String.IsNullOrEmpty(TxtName.Text))
            {

                MessageBox("Please enter Name and Phone Number before you drop the keys", "Information");
                return;
            }

            try
            {
                // wnd = new AdamMessageBox();
                //Application.Current.Dispatcher.Invoke(() => {
                //  if (Mouse.OverrideCursor != Cursors.Wait)
                //    Mouse.OverrideCursor = Cursors.Wait;
                //});


                var stepsLst = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs =>
                {
                    return svcs.GetKeyLockerSteps(_dealerId, null, true).ToList();
                });

                if (stepsLst != null && stepsLst.Count > 0)
                {
                    FindHomeAndMoveStepsReading = stepsLst.Where(m => m.StepCode == "FH").SingleOrDefault().NoOfRotationCustomer;
                    RotateKeyFloorReading = stepsLst.Where(m => m.StepCode == "KF").SingleOrDefault().StepReading;
                    DoorLatchReading = stepsLst.Where(m => m.StepCode == "DL").SingleOrDefault().StepReading;

                    if (FindHomeAndMoveStepsReading == "0000")
                    {
                        MessageBox("Electronic Key Locker is Full \n Sorry try another time..", "Information");
                        return;
                    }

                    this.Opacity = .1;
                   


                    var wnd = new PickUpOrDrop { OutDoorKeyDroppedBy = OutDoorKeyDroppedBy };

                    wnd.SelectedPerson = new uspSelAllKeyDropPegByDealerId_Result
                    {
                        FirstName = TxtName.Text,
                        PhoneNumber = TxtPhone.Text,

                        NoOfRotationDealer = FindHomeAndMoveStepsReading,
                        ServiceStatus = 4
                    };

                    wnd.CustomerInfo = new uspVerifyPinGetCustInfo_Result
                    {
                        FirstName = TxtName.Text,
                        PhoneNumber = TxtPhone.Text,
                        NoOfRotationCustomer = FindHomeAndMoveStepsReading,
                        Comments = TxtNotes.Text
                    };
                    //if (LstServiceItems.SelectedItems != null && LstServiceItems.SelectedItems.Count > 0)
                    //{
                    //    List<uspSelSvcTypeByDealerId_Result> selectedServices = LstServiceItems.SelectedItems.Cast<uspSelSvcTypeByDealerId_Result>().ToList();
                        wnd.SelectedServiceList = SelectedServiceList;
                    //}
                    wnd.ShowDialog();

                    this.Opacity = 1;
                   

                    // if (wnd.IsKeyDroppedClcked == true) {
                    GoHome();
                    // }

                }
                else
                {
                    MessageBox("Electronic Key Locker is Full \n Sorry try another time..", "Information");
                }

            }
            catch (Exception ex)
            {

                var stepsLst = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs =>
                {
                    return svcs.LogError(ex.Message);
                });

            }
            //Application.Current.Dispatcher.Invoke(() => {
            //  if (Mouse.OverrideCursor != Cursors.Arrow)
            //    Mouse.OverrideCursor = Cursors.Arrow;
            //});

        }

        //   private static  AdamMessageBox wnd;//= new AdamMessageBox();
        private void MessageBox(string msg, string header = "Information")
        {
            //var 
            Opacity = .1;
            wnd = new AdamMessageBox();
            wnd.TxtError.Text = msg;
            wnd.TxtHeader.Text = header;
            wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
            wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
            wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;


          
            var confirm = wnd.ShowDialog();
          
            Opacity = 1;
        }

        private void TxtNotes_GotFocus(object sender, RoutedEventArgs e)
        {
           

        }

        private void TxtName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InvokeKeyBoard(sender, "Enter Name :");
        }

        private void TxtPhone_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InvokeKeyBoardNumeric(sender, "Enter Phone :");
        }

        private void TxtNotes_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InvokeKeyBoard(sender, "Enter Comments :");
        }

        private void InvokeKeyBoard(object sender, string title)
        {
            TextBox tb = sender as TextBox;
            VirtualKeyboard kbWin = new VirtualKeyboard(tb, this, title);
            kbWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.Opacity = .6;
            if (kbWin.ShowDialog() == true)
                tb.Text = kbWin.Result;
            this.Opacity = 1;
        }

        private void InvokeKeyBoardNumeric(object sender, string title)
        {
            TextBox tb = sender as TextBox;
            Keypad kbWin = new Keypad(tb, this, title);
            kbWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.Opacity = .8;
            if (kbWin.ShowDialog() == true)
                tb.Text = kbWin.Result;
            this.Opacity = 1;
        }
    }
}
