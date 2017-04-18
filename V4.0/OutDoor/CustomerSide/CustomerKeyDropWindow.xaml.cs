
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.IO.Ports;

using System.Windows.Threading;
using ATP.Kiosk.Views;
using MyShopExpress.Common;
using System.Xml.Serialization;
using System.IO;
using ATP.DataModel;
using ATP.WCF.Svcs;
using KeyPad;

namespace MyShopExpress {
    /// <summary>
    /// Interaction logic for CustomerKeyDropWindow.xaml
    /// </summary>
    public partial class CustomerKeyDropWindow : Window {

        private uspVerifyPinGetCustInfo_Result CustomerInfo { get; set; }
        private string FindHomeAndMoveStepsReading { get; set; }
        private string RotateKeyFloorReading { get; set; }
        private string DoorLatchReading { get; set; }
        public int OutDoorKeyDroppedBy { get; set; }

        //SerialPort _serialPort = ConfigClass.MyShopSerialPort;
        int _dealerId = ConfigClass.DealerId;
        public CustomerKeyDropWindow() {
            InitializeComponent();
            // App.Current.SessionEnding += Current_SessionEnding;
            cmdVerifyPIN.Click += CmdVerifyPIN_Click;
            //  _serialPort = new SerialPort();
            // _serialPort.DataReceived += _serialPort_DataReceived;
            //  _serialPort.ErrorReceived += _serialPort_ErrorReceived;


            this.Loaded += CustomerKeyDropWindow_Loaded;
        }

        private void CustomerKeyDropWindow_Loaded(object sender, RoutedEventArgs e) {
            // CmdVerifyPIN_Click(sender,e);
        }

        private void Current_SessionEnding(object sender, SessionEndingCancelEventArgs e) {
            throw new NotImplementedException();
        }

        private void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e) {

        }

        private delegate void UpdateUiTextDelegate(string text);
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            //  string recieved_data = _serialPort.ReadExisting();
            //  Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(WriteData), recieved_data);

        }
        private bool IsKeyFloorProcess { get; set; }

        private void WriteData(string text) {
            // Assign the value of the plot to the RichTextBox.
            //lstStatus.Items.Add(text);
            if (text.Contains("KF-DONE")) {
                IsKeyFloorProcess = true;
                //wnd.Close();


                MessageBox("KeyFloor Done", "Information");


            }

            if (text.Contains("FH-DONE")) {
                MessageBox("Find Home Done", "Information");
            }

            if (text.Contains("BT-DONE")) {
                MessageBox("Bucket Topple  Done", "Information");
            }
        }

        private void ClosePort() {
            // if (_serialPort.IsOpen) { _serialPort.Close(); }
        }
        //  private bool _IsDoorClosed = false;

        private void cmdOpenDoorLatch_Click(object sender, RoutedEventArgs e) {
            ConfigClass.SendCommandToBoard("DL" + DoorLatchReading);
        }



        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            // if (_serialPort.IsOpen) { _serialPort.Close(); }
        }

        private void CtrlCustomerKeyDrop_Unloaded(object sender, RoutedEventArgs e) {

            // if (_serialPort.IsOpen) { _serialPort.Close(); }
        }


        public bool IsPickUpOrDrop { get; set; }
        private void CmdVerifyPIN_Click(object sender, RoutedEventArgs e) {

            // pickup = false, drop = true

            var res = new List<uspVerifyPinGetCustInfo_Result>();
            var x = new List<uspSelVehicleMakes_Result>();

            // CtrlValidatePin.TxtPin.Text = "30372";

            try {
              res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
                    return svcs.VerifyPinGetCustInfo(_dealerId, IsPickUpOrDrop, TxtPin.Text).ToList();
                });

                if (res != null && res.Count == 1) {
                    if (res[0].PinStatus == "G" && IsPickUpOrDrop == false) {
                        CustomerInfo = res[0];

                        FindHomeAndMoveStepsReading = CustomerInfo.NoOfRotationCustomer;

                        if (String.IsNullOrEmpty(FindHomeAndMoveStepsReading)) {

                            MessageBox("No Key location Information found");
                            this.Close();
                        }

                        cmdNext_Click(sender, e);

                    }
                    else if (res[0].PinStatus == "G" && IsPickUpOrDrop == true) {
                        //lstStatus.Items.Add("Good Pin");
                        //var cust = new uspVerifyPinGetCustInfo_Result();
                        CustomerInfo = res[0];

                        var pGuid = CustomerInfo.PersonGuid;
                        var vGuid = CustomerInfo.VehicleGuid;
                        var vsGuid = CustomerInfo.VehicleServiceGuid;

                        TxtName.Text = String.Format("{0} {1}", CustomerInfo.FirstName, CustomerInfo.LastName);
                        TxtVehicle.Text = String.Format("{0} {1} {2} - {3}", CustomerInfo.VehicleYear, CustomerInfo.VehicleMake, CustomerInfo.VehicleModel, CustomerInfo.VehicleYrMkMod);
                        TxtContacts.Text = String.Format("{0} {1}", CustomerInfo.EmailAddress, CustomerInfo.PhoneNumber);

                        //true for keydrop and false for pickup

                        var stepsLst = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
                            return svcs.GetKeyLockerSteps(_dealerId, null, true).ToList();
                        });

                        if (stepsLst != null && stepsLst.Count > 0) {
                            FindHomeAndMoveStepsReading = stepsLst.Where(m => m.StepCode == "FH").SingleOrDefault().NoOfRotationCustomer;
                            RotateKeyFloorReading = stepsLst.Where(m => m.StepCode == "KF").SingleOrDefault().StepReading;
                            DoorLatchReading = stepsLst.Where(m => m.StepCode == "DL").SingleOrDefault().StepReading;

                            CustomerInfo.NoOfRotationCustomer = FindHomeAndMoveStepsReading;

                            if (FindHomeAndMoveStepsReading == "0000") {
                                MessageBox("Electronic Key Locker is Full \n Sorry try another time..", "Information");
                                GoHome();
                                return;
                            }

                            var svclist = new List<uspSelVehicleServiceDetails_Result>();

                            try {
                                svclist = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
                                    return svcs.SelVehicleServiceDetails(_dealerId, vsGuid, vGuid, pGuid, null, null).ToList();
                                });
                            }
                            catch (Exception ex) {
                                MessageBox(ex.Message);
                            }

                            if (LstServiceItems != null && svclist != null) {



                                // Serializer ser = new Serializer();


                                if (svclist.FirstOrDefault().VEHSVCS != null) {

                                    // var selectedSvcList = ser.Deserialize<VEHSVCS>(svclist.FirstOrDefault().VEHSVCS.ToString());


                                    var ser = new XmlSerializer(typeof(VEHSVCS));

                                    using (TextReader reader = new StringReader(svclist.FirstOrDefault().VEHSVCS.ToString())) {
                                        var result = (VEHSVCS)ser.Deserialize(reader);
                                        LstServiceItems.ItemsSource = result.VEHSVC;
                                        LstServiceItems.Items.Refresh();
                                    }


                                }
                                // xmlOutputData = ser.Serialize<Customer>(customer)




                                TxtComments.Text = svclist.FirstOrDefault().Comments;

                            }



                            //foreach (var itm in stepsLst) {
                            //    var txt = String.Format("{0} {1} {2}", itm.StepCode, itm.StepDesc, itm.NoOfRotation);

                            //    lstStatus.Items.Add(txt);
                            //}

                            GrdKeyDrop.Visibility = Visibility.Visible;
                            GrdEnterPin.Visibility = Visibility.Collapsed;
                        }
                        else {
                            MessageBox("Electronic Key Locker is Full \n Sorry try another time..", "Information");
                        }
                    }
                    else {
                        MessageBox(res[0].Comments, "Information");
                    }
                }
                else {
                    MessageBox("Did not get any values back", "Information");
                }


            }
            catch (Exception ex) {
                MessageBox(ex.Message);
            }


        }



        private void GoHome() {
            this.Close();
        }


        //static AdamMessageBox wnd;

        private static void MessageBox(string msg, string header = "Information") {
            var wnd = new AdamMessageBox();
            wnd.TxtError.Text = msg;
            wnd.TxtHeader.Text = header;
            wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
            wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
            wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;

            var confirm = wnd.ShowDialog();
        }

        private void cmdNext_Click(object sender, RoutedEventArgs e) {
            // var sKeyLockerId = res[0].KeyLockerId;
            //GrdVerifiedPinInfo.Visibility = Visibility.Visible;
            GrdVerifyPinInfo.Visibility = Visibility.Collapsed;

            var wnd = new PickUpOrDrop();
            wnd.SelectedPerson = new uspSelAllKeyDropPegByDealerId_Result {
                FirstName = CustomerInfo.FirstName,
                LastName = CustomerInfo.LastName,
                VehicleYear = CustomerInfo.VehicleYear,
                VehicleMake = CustomerInfo.VehicleMake,
                VehicleModel = CustomerInfo.VehicleModel,
                NoOfRotationDealer = FindHomeAndMoveStepsReading,
                ServiceStatus = 4
            };


            wnd.CustomerInfo = CustomerInfo;

            if (IsPickUpOrDrop == false) // pickup
              {
                wnd.SelectedPerson.ServiceStatus = 10;
            }

            wnd.ShowDialog();

            this.Opacity = 1;
            // MyKeyboard.Visibility = Visibility.Visible;
            // MyKeyboard.IsOpen = true;

            // if (wnd.IsKeyDroppedClcked == true) {
            GoHome();

            //var wnd = new OpenDoorAndDropKeys {
            //          FindHomeAndMoveStepsReading = FindHomeAndMoveStepsReading,
            //          CustomerInfo = CustomerInfo
            //      };

            //      wnd.ShowDialog();
            //      GoHome();

        }

        private void cmdBack_Click(object sender, RoutedEventArgs e) {
            GoHome();
        }

        private void TxtPin_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            Keypad keypadWindow = new Keypad(textbox, this, "Enter PIN");
            keypadWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.Opacity = .8;
            if (keypadWindow.ShowDialog() == true)
                textbox.Text = keypadWindow.Result;

            this.Opacity = 1;

        }

        private void TxtComments_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InvokeKeyBoard(sender, "Enter Comments :");
        }
        private void InvokeKeyBoard(object sender, string title)
        {
            TextBox tb = sender as TextBox;
            VirtualKeyboard kbWin = new VirtualKeyboard(tb, this, title);
            kbWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.Opacity = .8;
            if (kbWin.ShowDialog() == true)
                tb.Text = kbWin.Result;
            this.Opacity = 1;
        }
    }


    [XmlRoot(ElementName = "VEHSVC")]
    public class VEHSVC {
        [XmlElement(ElementName = "VehicleServiceGUID")]
        public string VehicleServiceGUID { get; set; }
        [XmlElement(ElementName = "ServiceTypeId")]
        public string ServiceTypeId { get; set; }
        [XmlElement(ElementName = "Sequence")]
        public string Sequence { get; set; }
        [XmlElement(ElementName = "ShortName")]
        public string ShortName { get; set; }
    }

    [XmlRoot(ElementName = "VEHSVCS")]
    [Serializable]
    public class VEHSVCS {
        [XmlElement(ElementName = "VEHSVC")]
        public List<VEHSVC> VEHSVC { get; set; }
    }
}
