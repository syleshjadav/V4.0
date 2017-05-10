
using ATP.DataModel;
using ATP.Kiosk.Helpers;
using ATP.Kiosk.Views;
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

        private uspVerifyPinGetCustInfo_Result CustomerInfo { get; set; }
        private string FindHomeAndMoveStepsReading { get; set; }
        private string RotateKeyFloorReading { get; set; }
        private string DoorLatchReading { get; set; }
        public byte? OutDoorKeyDroppedBy { get; set; }
        public List<uspSelSvcTypeByDealerId_Result> DealerServiceList { get; set; }
        public uspSelAllKeyDropPegByDealerId_Result SelectedPerson { get; set; }
        //SerialPort _serialPort = ConfigClass.MyShopSerialPort;
        int _dealerId = ConfigClass.DealerId;
        public NoPhoneApp()
        {
            InitializeComponent();
            // cmdVerifyPIN.Click += CmdVerifyPIN_Click;

            this.Loaded += CustomerKeyDropWindow_Loaded;
        }

        private void CustomerKeyDropWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetDealerServiceList();
            MyKeyboard.IsOpen = false;
        }

        //private void Current_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        //{

        //}

        private delegate void UpdateUiTextDelegate(string text);
        //private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    //  string recieved_data = _serialPort.ReadExisting();
        //    //  Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(WriteData), recieved_data);

        //}
        private bool IsKeyFloorProcess { get; set; }
        private void WriteData(string text)
        {
            // Assign the value of the plot to the RichTextBox.
            //lstStatus.Items.Add(text);
            if (text.Contains("KF-DONE"))
            {
                IsKeyFloorProcess = true;
                //wnd.Close();


                MessageBox("KeyFloor Done", "Information");


            }

            if (text.Contains("FH-DONE"))
            {
                MessageBox("Find Home Done", "Information");
            }

            if (text.Contains("BT-DONE"))
            {
                MessageBox("Bucket Topple  Done", "Information");
            }
        }
        private void ClosePort()
        {
            // if (_serialPort.IsOpen) { _serialPort.Close(); }
        }
        //  private bool _IsDoorClosed = false;
        private void cmdOpenDoorLatch_Click(object sender, RoutedEventArgs e)
        {
            ConfigClass.SendCommandToBoard("DL" + DoorLatchReading);
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // if (_serialPort.IsOpen) { _serialPort.Close(); }
        }

        private void CtrlCustomerKeyDrop_Unloaded(object sender, RoutedEventArgs e)
        {

            // if (_serialPort.IsOpen) { _serialPort.Close(); }
        }
        public bool IsPickUpOrDrop { get; set; }
        //private void CmdVerifyPIN_Click(object sender, RoutedEventArgs e)
        //{

        //    // pickup = false, drop = true
        //    MyKeyboard.IsOpen = false;

        //    var res = new List<uspVerifyPinGetCustInfo_Result>();
        //    var x = new List<uspSelVehicleMakes_Result>();

        //    // CtrlValidatePin.TxtPin.Text = "30372";

        //    try
        //    {
        //        res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
        //            return svcs.VerifyPinGetCustInfo(_dealerId, IsPickUpOrDrop, TxtPin.Text).ToList();
        //        });




        //        if (res != null && res.Count == 1)
        //        {
        //            if (res[0].PinStatus == "G" && IsPickUpOrDrop == false)
        //            {
        //                CustomerInfo = res[0];

        //                FindHomeAndMoveStepsReading = CustomerInfo.NoOfRotationCustomer;

        //                if (String.IsNullOrEmpty(FindHomeAndMoveStepsReading))
        //                {

        //                    MessageBox("No Key location Information found");
        //                    this.Close();
        //                }

        //                cmdNext_Click(sender, e);

        //            }
        //            else if (res[0].PinStatus == "G" && IsPickUpOrDrop == true)
        //            {
        //                //lstStatus.Items.Add("Good Pin");
        //                //var cust = new uspVerifyPinGetCustInfo_Result();
        //                CustomerInfo = res[0];

        //                var pGuid = CustomerInfo.PersonGuid;
        //                var vGuid = CustomerInfo.VehicleGuid;
        //                var vsGuid = CustomerInfo.VehicleServiceGuid;

        //                TxtName.Text = String.Format("{0} {1}", CustomerInfo.FirstName, CustomerInfo.LastName);
        //                TxtVehicle.Text = String.Format("{0} {1} {2} - {3}", CustomerInfo.VehicleYear, CustomerInfo.VehicleMake, CustomerInfo.VehicleModel, CustomerInfo.VehicleYrMkMod);
        //                TxtContacts.Text = String.Format("{0} {1}", CustomerInfo.EmailAddress, CustomerInfo.PhoneNumber);

        //                //true for keydrop and false for pickup

        //                var stepsLst = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
        //                    return svcs.GetKeyLockerSteps(_dealerId, null, true).ToList();
        //                });

        //                if (stepsLst != null && stepsLst.Count > 0)
        //                {
        //                    FindHomeAndMoveStepsReading = stepsLst.Where(m => m.StepCode == "FH").SingleOrDefault().NoOfRotationCustomer;
        //                    RotateKeyFloorReading = stepsLst.Where(m => m.StepCode == "KF").SingleOrDefault().StepReading;
        //                    DoorLatchReading = stepsLst.Where(m => m.StepCode == "DL").SingleOrDefault().StepReading;

        //                    CustomerInfo.NoOfRotationCustomer = FindHomeAndMoveStepsReading;

        //                    if (FindHomeAndMoveStepsReading == "0000")
        //                    {
        //                        MessageBox("Electronic Key Locker is Full \n Sorry try another time..", "Information");
        //                        GoHome();
        //                        return;
        //                    }

        //                    var svclist = new List<uspSelVehicleServiceDetails_Result>();

        //                    try
        //                    {
        //                        svclist = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
        //                            return svcs.SelVehicleServiceDetails(_dealerId, vsGuid, vGuid, pGuid, null, null).ToList();
        //                        });
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        MessageBox(ex.Message);
        //                    }

        //                    if (LstServiceItems != null && svclist != null)
        //                    {



        //                        // Serializer ser = new Serializer();


        //                        if (svclist.FirstOrDefault().VEHSVCS != null)
        //                        {

        //                            // var selectedSvcList = ser.Deserialize<VEHSVCS>(svclist.FirstOrDefault().VEHSVCS.ToString());


        //                            var ser = new XmlSerializer(typeof(VEHSVCS));

        //                            using (TextReader reader = new StringReader(svclist.FirstOrDefault().VEHSVCS.ToString()))
        //                            {
        //                                var result = (VEHSVCS)ser.Deserialize(reader);
        //                                LstServiceItems.ItemsSource = result.VEHSVC;
        //                                LstServiceItems.Items.Refresh();
        //                            }


        //                        }
        //                        // xmlOutputData = ser.Serialize<Customer>(customer)




        //                        TxtComments.Text = svclist.FirstOrDefault().Comments;

        //                    }



        //                    //foreach (var itm in stepsLst) {
        //                    //    var txt = String.Format("{0} {1} {2}", itm.StepCode, itm.StepDesc, itm.NoOfRotation);

        //                    //    lstStatus.Items.Add(txt);
        //                    //}

        //                    GrdKeyDrop.Visibility = Visibility.Visible;
        //                    GrdEnterPin.Visibility = Visibility.Collapsed;
        //                }
        //                else
        //                {
        //                    MessageBox("Electronic Key Locker is Full \n Sorry try another time..", "Information");
        //                }
        //            }
        //            else
        //            {
        //                MessageBox(res[0].Comments, "Information");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox("Did not get any values back", "Information");
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox(ex.Message);
        //    }


        //}



        private void GoHome()
        {
            MyKeyboard.IsOpen = false;
            this.Close();
        }


        //static AdamMessageBox wnd;

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

        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {
            MyKeyboard.IsOpen = false;
            if (String.IsNullOrEmpty(TxtContacts.Text) || String.IsNullOrEmpty(TxtName.Text) || String.IsNullOrEmpty(TxtVehicle.Text))
            {
                MessageBox("Please Enter All Values Marked in YELLOW...", "Error");
                return;
            }

            try
            {



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


             var wnd = new PickUpOrDrop { OutDoorKeyDroppedBy = OutDoorKeyDroppedBy };

            wnd.CustomerInfo = new uspVerifyPinGetCustInfo_Result { FirstName = TxtName.Text, VehicleMake = TxtVehicle.Text, EmailAddress = TxtEmail.Text, PhoneNumber = TxtContacts.Text };
            wnd.SelectedServiceList = DealerServiceList.Where(m => m.IsSelected == true).ToList();
            //  wnd.co = TxtComments.Text;
            //wnd.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //wnd.ShowDialog();



            wnd.SelectedPerson = new uspSelAllKeyDropPegByDealerId_Result { ServiceStatus = 4 };


            

            wnd.SelectedPerson = new uspSelAllKeyDropPegByDealerId_Result
            {
                FirstName = TxtName.Text,
                PhoneNumber = TxtContacts.Text,
                
                NoOfRotationDealer = FindHomeAndMoveStepsReading,
                ServiceStatus = 4
            };




            wnd.ShowDialog();

            this.Opacity = 1;
            GoHome();


        }

        private void cmdBack_Click(object sender, RoutedEventArgs e)
        {
            GoHome();
        }

        private void TxtPin_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MyKeyboard.IsOpen = true;

        }

        private void TxtComments_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MyKeyboard.IsOpen = true;
        }

        private void LstServiceItems_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void LstServiceItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private void TxtComments_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TxtName_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void GetDealerServiceList()
        {
            if (App.gDealerServiceList == null)
            {
                DealerServiceList = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs =>
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
            LstServiceItems.UnselectAll();

        }

    }
}
