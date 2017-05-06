
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ATP.Kiosk.Views;
using MyShopExpress.ServiceReference1;
using ATP.Kiosk.Helpers;
using ATP.Common;


namespace MyShopExpress
{
    /// <summary>
    /// Interaction logic for CustomerKeyDropWindow.xaml
    /// </summary>
    public partial class NewExpressCustomer : Window
    {

        //private uspVerifyPinGetCustInfoExpress_Result CustomerInfo { get; set; }
        //private string FindHomeAndMoveStepsReading { get; set; }
        //private string RotateKeyFloorReading { get; set; }
        //private string DoorLatchReading { get; set; }
        //public int OutDoorKeyDroppedBy { get; set; }

        //SerialPort _serialPort = ConfigClass.MyShopSerialPort;
        int _dealerId = ConfigClass.DealerId;
        public NewExpressCustomer()
        {
            InitializeComponent();
            // App.Current.SessionEnding += Current_SessionEnding;


            //TxtName.Text = "John Hayes";
            //TxtVehicle.Text = "2015 , Honda CRV ";
            //TxtComments.Text = "Check for vibration in front.";
            //TxtContacts.Text = " 717-865-8975";
            this.Loaded += NewExpressCustomer_Loaded;
        }

        private void NewExpressCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            GetDealerServiceList();
            // TxtName.Focus();
            KeyBoard.IsOpen = false;
        }

        public List<uspSelSvcTypeByDealerId_Result> SelectedServiceList { get; set; }

        public uspSelSvcTypeByDealerId_Result SelectedService { get; set; }
        public List<uspSelSvcTypeByDealerId_Result> DealerServiceList { get; set; }

        public bool IsPickUpOrDrop { get; set; }

        private void GoHome()
        {
            this.Close();
        }

        private static void MessageBox(string msg, string header = "Information")
        {
            var wnd = new AdamMessageBox();
            wnd.TxtError.Text = msg;
            wnd.TxtHeader.Text = header;
            wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
            wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
            wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;

            var confirm = wnd.ShowDialog();
        }

        private void GetDealerServiceList()
        {
            if (App.gDealerServiceList == null)
            {
                DealerServiceList = ProxyHelper.Service<IOutDoor>.Use(svcs =>
                {

                    return svcs.GetServiceTypes(_dealerId.ToString()).Where(m => m.Express == true).ToList();
                });
                App.gDealerServiceList = DealerServiceList;
            }
            else
            {
                DealerServiceList = App.gDealerServiceList;
            }



            DealerServiceList.Update(xx => xx.OpacityVal = 1);
            DealerServiceList.Update(xx => xx.IsEnabledVal = true);
            DealerServiceList.Update(xx => xx.IsSelected = false);
            LstServiceItems.UnselectAll();


            LstServiceItems.ItemsSource = DealerServiceList;
        }
        private void LstServiceItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // return;
            var currentSelectedService = new uspSelSvcTypeByDealerId_Result();
            if (e.RemovedItems.Count > 0)
            {
                currentSelectedService.IsSelected = false;
                currentSelectedService = (uspSelSvcTypeByDealerId_Result)e.RemovedItems[0];
                currentSelectedService.IsSelected = false;

                LstServiceItems.SelectedItems.Remove(currentSelectedService);
                DealerServiceList.Where(mm => mm.ServiceTypeId == currentSelectedService.ServiceTypeId).Update(xx => xx.IsSelected = false);

            }

            if (e.AddedItems.Count > 0)
            {
                currentSelectedService.IsSelected = true;
                currentSelectedService = (uspSelSvcTypeByDealerId_Result)e.AddedItems[0];
                LstServiceItems.SelectedItems.Add(currentSelectedService);

                DealerServiceList.Where(mm => mm.ServiceTypeId == currentSelectedService.ServiceTypeId).Update(xx => xx.IsSelected = true);

            }



        }



        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {


            KeyBoard.IsOpen = false;

            var wnd = new VerifyAndPrint();

            if(String.IsNullOrEmpty( TxtContacts.Text) || String.IsNullOrEmpty(TxtName.Text) || String.IsNullOrEmpty(TxtVehicle.Text))
            {
                MessageBox("Please Enter All Values Marked in YELLOW...", "Error");
                return;
            }


            wnd.CustomerInfo = new uspVerifyPinGetCustInfoExpress_Result { FirstName = TxtName.Text,VehicleMake = TxtVehicle.Text,EmailAddress = TxtEmail.Text,PhoneNumber = TxtContacts.Text};
            wnd.SelectedServiceList = DealerServiceList.Where(m => m.IsSelected == true).ToList();
            wnd.CustNotes = TxtComments.Text;
            wnd.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            wnd.ShowDialog();

        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            GoHome();
            KeyBoard.IsOpen = false;
        }

        private void TxtName_GotFocus(object sender, RoutedEventArgs e)
        {
            KeyBoard.IsOpen = true;
        }

        private void LstServiceItems_GotFocus(object sender, RoutedEventArgs e)
        {
            KeyBoard.IsOpen = false;
        }
    }





}
