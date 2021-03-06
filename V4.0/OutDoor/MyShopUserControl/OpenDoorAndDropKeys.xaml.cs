﻿using ATP.Kiosk.Views;
using MyShopOutDoor.Common;
using MyShopOutDoor.OutDoorProxy;
using System;
using System.Collections.Generic;
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

namespace MyShopOutDoor.MyShopUserControl {
    /// <summary>
    /// Interaction logic for OpenDoorAndDropKeys.xaml
    /// </summary>
    public partial class OpenDoorAndDropKeys : Window {
        public OpenDoorAndDropKeys() {
            InitializeComponent();
            this.Loaded += OpenDoorAndDropKeys_Loaded;
        }

        private void OpenDoorAndDropKeys_Loaded(object sender, RoutedEventArgs e) {
            Application.Current.Dispatcher.Invoke(() => {
                if (Mouse.OverrideCursor != Cursors.Arrow)
                    Mouse.OverrideCursor = Cursors.Arrow;
            });
        }

        int _dealerId = ConfigClass.DealerId;
        public string FindHomeAndMoveStepsReading { get; set; }
        public string RotateKeyFloorReading { get; set; }
        public string DoorLatchReading { get; set; }

        public bool IsKeyDroppedClcked { get; set; }
        public OutDoorProxy.uspVerifyPinGetCustInfo_Result CustomerInfo { get; set; }
        private void cmdOpenDoor_Click(object sender, RoutedEventArgs e) {

            try {
                MessageBox("DL005000", "Customer test");

                ConfigClass.SendCommandToBoard("DL005000");


                MessageBox("The Door is now open..., Place the key and click DROP KEY button", "Information");

                cmdDropKeys.IsEnabled = true;

                cmdDropKeys.Opacity = 1;

                cmdOpenDoor.Opacity = 0.5;
                cmdOpenDoor.IsEnabled = false;
            }
            catch (Exception ex) {
                MessageBox(ex.Message, "Error");
            }


        }

        private void OpenDoorLatchAndBringToHomePosition() {



            ConfigClass.SendCommandToBoard(FindHomeAndMoveStepsReading);
            //Thread.Sleep(TimeSpan.FromHours(1));
        }
        private void FindHomeAndRotateKeyFloor() {
            // ConfigClass.SendCommandToBoard("FH" + FindHomeAndMoveStepsReading, "C");

            //  MessageBox(FindHomeAndMoveStepsReading, "dfd");
            ConfigClass.SendCommandToBoard(FindHomeAndMoveStepsReading); // key floor

        }

        private void cmdDropKeys_Click(object sender, RoutedEventArgs e) {

            // Thread t = new Thread(FindHomeAndRotateKeyFloor);

            // MessageBox(RotateKeyFloorReading, "dfd");
            ConfigClass.SendCommandToBoard(FindHomeAndMoveStepsReading); //careousel
            ConfigClass.SendCommandToBoard("KC00170000");// key floor


            IsKeyDroppedClcked = true;

            var firstName = CustomerInfo.FirstName;
            var phone = CustomerInfo.PhoneNumber;
            var svcInfo = CustomerInfo.Comments;
            byte? serviceStatusId = 4;
            byte? assignedKeyLockerBucketId = Convert.ToByte(FindHomeAndMoveStepsReading.Substring(2, 2));


            // Phone customer will have service guid // towtruck no guid
            if (CustomerInfo.VehicleServiceGuid != null) {
                try {

                    var res = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
                        return svcs.UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(_dealerId, CustomerInfo.VehicleServiceGuid, CustomerInfo.VehicleGuid, svcInfo, serviceStatusId, assignedKeyLockerBucketId);
                    });

                }
                catch (Exception ex) {
                    MessageBox(ex.Message.ToString(), "Error !");
                }
            }
            else {

                try {

                    var res = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
                        return svcs.CreateSeviceAndKeyLockerBucket_TowTruck(_dealerId, firstName, phone, svcInfo, serviceStatusId, assignedKeyLockerBucketId);
                    });

                }
                catch (Exception ex) {
                    MessageBox(ex.Message.ToString(), "Error !");
                }
            }

            // _serialPort.Write("BT75000 \n");
            MessageBox("WE HAVE YOUR INFORMATION.\nTHANKS FOR USING OUR AUTOMATED KEY SYSTEM", "KEY DROP INFORMATION");

            var msg = "WE HAVE YOUR INFORMATION NOW. THANKS FOR USING OUR AUTOMATED KEY SYSTEM. ";
            var msgType = "Chat";
            if (CustomerInfo.PersonGuid != null || !string.IsNullOrEmpty(CustomerInfo.GoogleGuid)) {
                var finalResult = SendMsgToDevice(CustomerInfo, "Key Drop Info ..", msgType, "MsgToCust", msg);

                try {
                    if (finalResult.ToUpper() == "SUCCESS" && msgType != "Notification") {

                        var x = new uspSelDealerMsg_Result();
                        x.DealerId = _dealerId;
                        x.TxtMsg = msg;
                        x.IsMsgToCust = true;
                        x.IsCustMsg = false;
                        x.VehicleGuid = CustomerInfo.VehicleGuid;
                        x.VehicleServiceGuid = CustomerInfo.VehicleServiceGuid;
                        x.PersonGuid = CustomerInfo.PersonGuid;


                        var res = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
                            return svcs.InsDealerMsg(x);
                        });

                    }

                }
                catch (Exception ex) {
                    MessageBox(ex.Message.ToString(), "Error !");
                }
            }
            this.Close();
            this.Close();
            this.Close();
        }

        private static void MessageBox(string msg, string header = "INFORMATION") {
            var wnd = new AdamMessageBox();
            wnd.TxtError.Text = msg;
            wnd.TxtHeader.Text = header;
            wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
            wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
            wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;

            var confirm = wnd.ShowDialog();
        }


        public string SendMsgToDevice(OutDoorProxy.uspVerifyPinGetCustInfo_Result currPerson, string contentTitle, string msgType, string MsgToCust, string message) {
            // var DealerId = 116;


            string tickerText = "You have a message";
            string deviceId = currPerson.GoogleGuid;


            if (string.IsNullOrEmpty(deviceId)) {
                MessageBox("I couldn't find device Id. Sorry cannot send message to this customer");
                return "false";

            }
            var finalResult = "SUCCESS";
            try {

                //currPerson.DealerId = ATPDealerRecord.DealerId;
                var vehphId = currPerson.VehPhId == null ? "1" : currPerson.VehPhId;

                // var dealerEmpMsgDataTableList = new List<DataModel.DataTables.DealerEmpMsgDataTable>();

                //  var jsonCustomMsg = new GeneratePhoneMessage().GetMessageToSend(message, msgType, contentTitle, SelectedVehicleInService.DeviceTypeId);
                var jsonCustomMsg = new ATP.Kiosk.Common.GeneratePhoneMessage().GetMessageToSend(_dealerId.ToString(), currPerson.FirstName, currPerson.LastName, currPerson.PersonGuid.ToString(),
                    message, msgType, contentTitle, currPerson.DeviceTypeId.ToString(), "TxtRoNum", "TxtROAmount", currPerson.PersonGuid.ToString(), vehphId);


                if (currPerson.DeviceTypeId == 0) {
                    var msgret = new ATP.Kiosk.Common.GeneratePhoneMessage().SendMessageToAndroid(deviceId, jsonCustomMsg, tickerText, contentTitle);
                    var gcmReturn = ATP.Kiosk.Common.JSonHelpers.FromJson<ATP.Kiosk.Common.GCMReturn>(msgret);
                    if (gcmReturn.success == "1") { finalResult = "Success"; }
                }
                else if (currPerson.DeviceTypeId == 1) {
                    //  var iosdeviceToken = "04d40a3743b36b27ebcc3fded70b33e3feceb3b857b7724ea2095bd4a635a682";
                    var bsandbox = false;
                    var payload = new MoonAPNS.NotificationPayload(deviceId, tickerText);

                    // var certPath = @"Certs\FaulknerToyota-prod.p12";

                    //if (SelectedVehicleInService.DealerId > 100)
                    //  {
                    var certPath = @"Certs\AdamShopAPNProdPvtKey.p12";
                    // }
                    var notificationList = new List<MoonAPNS.NotificationPayload> { payload };
                    var pushNotifi = new MoonAPNS.PushNotification(bsandbox, certPath, "Sarina87!");
                    //Sarina87!
                    //jsonCustomMsg = jsonCustomMsg.Replace("ContentAvail", "").Replace("'':","");
                    var iosResult = pushNotifi.SendToApple(notificationList, jsonCustomMsg); // You are done!
                    if (iosResult != null) { finalResult = "Success"; }

                }
                else {
                    MessageBox("Either No Customer Selected or Device Id is Null");
                    return "false";
                }

                return finalResult;

            }
            catch (Exception ex) {
                MessageBox(ex.Message.ToString(), "Error !");
            }
            return finalResult;
        }

        private void cmdBack_Click(object sender, RoutedEventArgs e) {
            this.Close();
            this.Close();
            this.Close();
        }
    }
}
