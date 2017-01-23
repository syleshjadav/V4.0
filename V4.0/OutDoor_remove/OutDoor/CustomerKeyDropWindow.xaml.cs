
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.IO.Ports;

using System.Windows.Threading;
using ATP.Kiosk.Views;

using MyShopOutDoor.OutDoorProxy;
using System.Threading;
using System.Threading.Tasks;

namespace MyShopOutDoor {
  /// <summary>
  /// Interaction logic for CustomerKeyDropWindow.xaml
  /// </summary>
  public partial class CustomerKeyDropWindow : UserControl {


    private int _baudRate = 19200;
    private int _dataBits = 8;
    private Handshake _handshake = Handshake.None;
    private Parity _parity = Parity.None;
    private string _portName = "COM4";
    private StopBits _stopBits = StopBits.One;
    SerialPort _serialPort;

    public CustomerKeyDropWindow() {
      InitializeComponent();
     // App.Current.MainWindow.Closing += MainWindow_Closing;
      App.Current.SessionEnding += Current_SessionEnding;
      _serialPort = new SerialPort();
      _serialPort.BaudRate = _baudRate;
      _serialPort.DataBits = _dataBits;
      _serialPort.Handshake = _handshake;
      _serialPort.Parity = _parity;
      _serialPort.PortName = _portName;
      _serialPort.StopBits = _stopBits;
      _serialPort.Encoding = System.Text.Encoding.Default;
      _serialPort.ReadTimeout = 10000;

      _serialPort.DtrEnable = true;
      _serialPort.RtsEnable = true;
      //   _serialPort.Open();
      _serialPort.DataReceived += _serialPort_DataReceived;
      _serialPort.ErrorReceived += _serialPort_ErrorReceived;
    }

    private void Current_SessionEnding(object sender, SessionEndingCancelEventArgs e) {
      throw new NotImplementedException();
    }

    private void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e) {

    }

    private delegate void UpdateUiTextDelegate(string text);
    private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
      string recieved_data = _serialPort.ReadExisting();
      Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(WriteData), recieved_data);

    }
    private bool IsKeyFloorProcess { get; set; }

    private void WriteData(string text) {
      // Assign the value of the plot to the RichTextBox.
      lstStatus.Items.Add(text);
      if (text.Contains("KF-DONE")) {
        IsKeyFloorProcess = true;
        wnd.Close();


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
      if (_serialPort.IsOpen) { _serialPort.Close(); }
    }
    private bool _IsDoorClosed = false;

    private void cmdOpenDoorLatch_Click(object sender, RoutedEventArgs e) {
      lstStatus.Items.Clear();
      // ClosePort();
      if (_serialPort.IsOpen == false) { _serialPort.Open(); }
      // lstStatus.Items.Clear();


      if (_serialPort.IsOpen) {
        _serialPort.Write("DL100O \n");/*
        System.Threading.Thread.Sleep(5000);

       
        }*/
      }
      else {
        lstStatus.Items.Add("Port Not Open");
      }
    }

    private void cmdChkDoorClosed_Click(object sender, RoutedEventArgs e) {


      if (!_serialPort.IsOpen) { _serialPort.Open(); }


      _serialPort.Write("FH47500 \n");


      MessageBox("The Door is now open, Place the key and click DROP KEY button", "Information");



    }

    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      if (_serialPort.IsOpen) { _serialPort.Close(); }
    }

    private void CtrlCustomerKeyDrop_Unloaded(object sender, RoutedEventArgs e) {

      if (_serialPort.IsOpen) { _serialPort.Close(); }
    }

    private OutDoorProxy.uspVerifyPinGetCustInfo_Result CustomerInfo { get; set; }
    private void cmdVerifyPIN_Click(object sender, RoutedEventArgs e) {

      var res = new List<OutDoorProxy.uspVerifyPinGetCustInfo_Result>();
      var x = new List<uspSelVehicleMakes_Result>();






      try {
        res = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
          return svcs.VerifyPinGetCustInfo(_dealerId, true, TxtPin.Text).ToList();
        });

        if (res != null && res.Count == 1) {
          if (res[0].PinStatus == "G") {
            lstStatus.Items.Add("Good Pin");
            //var cust = new uspVerifyPinGetCustInfo_Result();
            CustomerInfo = res[0];

            var pGuid = CustomerInfo.PersonGuid;
            var vGuid = CustomerInfo.VehicleGuid;
            var vsGuid = CustomerInfo.VehicleServiceGuid;

            TxtName.Text = String.Format("{0} {1}", CustomerInfo.FirstName, CustomerInfo.LastName);
            TxtVehicle.Text = String.Format("{0} {1} {2} - {3}", CustomerInfo.VehicleYear, CustomerInfo.VehicleMake, CustomerInfo.VehicleModel, CustomerInfo.VehicleYrMkMod);
            TxtContacts.Text = String.Format("{0} {1}", CustomerInfo.EmailAddress, CustomerInfo.PhoneNumber);

            //true for keydrop and false for pickup

            var stepsLst = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
              return svcs.GetKeyLockerSteps(_dealerId, null, true).ToList();
            });

            foreach (var itm in stepsLst) {
              var txt = String.Format("{0} {1} {2}", itm.StepCode, itm.StepDesc, itm.NoOfRotation);

              lstStatus.Items.Add(txt);
            }

            GrdKeyDrop.Visibility = Visibility.Visible;
            GrdEnterPin.Visibility = Visibility.Collapsed;
          }
          else {
            lstStatus.Items.Add(res[0].Comments);
          }
        }
        else {
          lstStatus.Items.Add("Did not get any values back");
        }


      }
      catch (Exception ex) {
        lstStatus.Items.Add(ex.Message);
      }
    }

    #region "Keyboard"

    private void cmdBack_Click(object sender, RoutedEventArgs e) {
      NavigationService nav = NavigationService.GetNavigationService(this);
      nav.Navigate(new Uri("KeyDropWindow.xaml", UriKind.RelativeOrAbsolute));
    }

    private void btnOne_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "1";
    }

    private void btnTwo_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "2";
    }

    private void bthThree_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "3";
    }

    private void btnFour_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "4";
    }

    private void btnFive_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "5";
    }

    private void btnSix_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "6";
    }

    private void btnSeven_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "7";
    }

    private void btnEight_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "8";
    }

    private void btnNine_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "9";
    }

    private void btnZero_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text += "0";
    }

    private void btnBackSpace_Click(object sender, RoutedEventArgs e) {
      if (TxtPin.Text.Length > 0) {

        TxtPin.Text = TxtPin.Text.Substring(0, TxtPin.Text.Length - 1);
      }
    }

    private void btnClearAll_Click(object sender, RoutedEventArgs e) {
      TxtPin.Text = "";
    }

    #endregion

    int _dealerId = 116;

    private async void TurnKeyFloor() {

      await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
      {
        _serialPort.Write("KF170000 \n");

        await Task.Delay(15000);
       
      });
    }
    private void cmdDropKeys_Click(object sender, RoutedEventArgs e) {

      IsKeyFloorProcess = false;

      _serialPort.Write("KF170000 \n");

      MessageBox("We have your information and Keys.\n  Thanks for using our automated key system", "Key Drop Information");
       
            // _serialPort.Write("BT75000 \n");

      var msg = "We have your information now. Thanks for using our automated Key system. ";
      var msgType = "Chat";

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

     
      

      NavigationService nav = NavigationService.GetNavigationService(this);


      nav.Navigate(new Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));
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

    static AdamMessageBox wnd;

    private static void MessageBox(string msg, string header = "Information") {
      wnd = new AdamMessageBox();
      wnd.TxtError.Text = msg;
      wnd.TxtHeader.Text = header;
      wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
      wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
      wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;

      var confirm = wnd.ShowDialog();
    }

    private void cmdNext_Click(object sender, RoutedEventArgs e) {
      // var sKeyLockerId = res[0].KeyLockerId;
      GrdVerifiedPinInfo.Visibility = Visibility.Visible;
      GrdVerifyPinInfo.Visibility = Visibility.Collapsed;

      if (!_serialPort.IsOpen) { _serialPort.Open(); }

    }


  }

}
