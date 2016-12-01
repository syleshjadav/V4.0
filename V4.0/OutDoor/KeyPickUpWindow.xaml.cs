using ATP.Kiosk.Views;
using MyShopOutDoor.Common;
using MyShopOutDoor.OutDoorProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MyShopOutDoor {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class KeyPickUpWindow : Page {

    int _dealerId = ConfigClass.DealerId;
    public KeyPickUpWindow() {
      InitializeComponent();
      CtrlValidatePin.cmdVerifyPIN.Click += CmdVerifyPIN_Click;
    }



    private void cmdKeysPickUp_Click(object sender, RoutedEventArgs e) {
      // var wnd = new MainWindow();
      //wnd.ctrlKeyPickUp.Visibility = Visibility.Collapsed;
      //wnd.ctrlMenu.Visibility = Visibility.Visible;

      NavigationService nav = NavigationService.GetNavigationService(this);
      nav.Navigate(new Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));

    }

    public OutDoorProxy.uspVerifyPinGetCustInfo_Result CustomerInfo { get; set; }

    private string FindHomeAndMoveStepsReading { get; set; }
    private string BucketToppleReading { get; set; }

    private void CmdVerifyPIN_Click(object sender, RoutedEventArgs e) {

      var res = new List<OutDoorProxy.uspVerifyPinGetCustInfo_Result>();



      try {
        res = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
          return svcs.VerifyPinGetCustInfo(_dealerId, false, CtrlValidatePin.TxtPin.Text).ToList();
        });

        if (res != null && res.Count == 1) {
          CustomerInfo = res.ToList().FirstOrDefault();

          if (CustomerInfo.PinStatus == "G") {





            var stepsLst = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
              return svcs.GetKeyLockerSteps(_dealerId, null, true).ToList();
            });


            FindHomeAndMoveStepsReading = stepsLst.Where(m => m.StepCode == "FH").SingleOrDefault().NoOfRotationCustomer;

            BucketToppleReading = stepsLst.Where(m => m.StepCode == "BT").SingleOrDefault().StepReading;


            //ConfigClass.CustomerSerialPort.Write("BT75000 \n");
            ConfigClass.SendCommandToBoard("FH" + FindHomeAndMoveStepsReading);

            ConfigClass.SendCommandToBoard(BucketToppleReading);

            var msg = "PICKUP your keys now. Thanks for using our automated Key system. ";
            var msgType = "Chat";

            var finalResult = SendMsgToDevice(CustomerInfo, "Key Pickup Info ..", msgType, "MsgToCust", msg);

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


                var res1 = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
                  return svcs.InsDealerMsg(x);
                });

              }



              MessageBox(" PICKUP your keys now...\n  Thanks for using our automated key system", "Key PICKUP Information");
              NavigationService nav = NavigationService.GetNavigationService(this);


              nav.Navigate(new Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));
            }

            catch (Exception ex) {
              MessageBox(ex.Message.ToString(), "Error !");
            }
          }

          else {
            var s = String.Format("{0},{1}", CustomerInfo.Comments, " Try Again or Request New PIN from your MyShopAuto phone App.");

            MessageBox(s, "ERROR");
          }


        }
        else {
          MessageBox("I did not find any PINS, Please request again from your MyShopAuto phone App.");
        }


      }
      catch (Exception ex) {
        // lstStatus.Items.Add(ex.Message);
        MessageBox(ex.Source, "ERROR");
      }
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

    private static void MessageBox(string msg, string header = "Information") {
      var wnd = new AdamMessageBox();
      wnd.TxtError.Text = msg;
      wnd.TxtHeader.Text = header;
      wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
      wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
      wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;

      var confirm = wnd.ShowDialog();
    }

    private void cmdPickUpKeys_Click(object sender, RoutedEventArgs e) {

    }

    private void cmdBack_Click(object sender, RoutedEventArgs e) {

    }

    private void cmdNext_Click(object sender, RoutedEventArgs e) {

    }
  }
}
