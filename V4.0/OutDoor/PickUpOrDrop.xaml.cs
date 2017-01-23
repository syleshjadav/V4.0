using ATP.Kiosk.Views;
using MyShopOutDoor.Common;
using MyShopOutDoor.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MyShopOutDoor {
  /// <summary>
  /// Interaction logic for PickUpOrDrop.xaml
  /// </summary>
  public partial class PickUpOrDrop : Window {

    int _dealerId = 116;

    public PickUpOrDrop() {
      InitializeComponent();

      this.Loaded += PickUpOrDrop_Loaded;
    }
    // public byte? ServiceStatus { get; set; }
    public uspVerifyPinGetCustInfo_Result CustomerInfo { get; set; }
    private void PickUpOrDrop_Loaded(object sender, RoutedEventArgs e) {
      GrdSelection.DataContext = SelectedPerson;

      //Ready for pickup
      if (SelectedPerson.ServiceStatus == 10) {
        TxtPlaceKeysInfo.Visibility = Visibility.Collapsed;
        cmdPlaceKeys.Visibility = Visibility.Collapsed;
        cmdOpenDoor.Visibility = Visibility.Collapsed;

        cmdTakeKeys.Visibility = Visibility.Visible;
        // ImgTakeKeys.Visibility = Visibility.Visible;

        TxtTakeKeysInfo.Visibility = Visibility.Visible;
        GrdButtons.Columns = 1;
        GrpHeaderName.Text = "TAKE CUSTOMER KEYS";
        // CheckIfKioskIsInUse();

      }
    }

    public uspSelAllKeyDropPegByDealerId_Result SelectedPerson { get; set; }

    private void cmdBack_Click(object sender, RoutedEventArgs e) {
      this.Close();
      // this.Close();

    }

    private void cmdTakeKeys_Click(object sender, RoutedEventArgs e) {


      var FindHomeAndMoveStepsReading = SelectedPerson.NoOfRotationDealer;

      ConfigClass.SendCommandToBoard(FindHomeAndMoveStepsReading);

      if (SelectedPerson.ServiceStatus == 4) {
        TowTruckOrPhoneDrop();
      }
      else if (SelectedPerson.ServiceStatus == 10) {
        //  MessageBox(FindHomeAndMoveStepsReading, "Info !");

       // ConfigClass.SendCommandToBoard(FindHomeAndMoveStepsReading);

        ConfigClass.SendCommandToBoard("BC0059000");
        TowTruckOrPhoneDrop();
       // UpdateVehicleServiceStatus(11); // Key Released

      }
      else {
        ConfigClass.SendCommandToBoard("KD0075000");
        // sylesh
        UpdateVehicleServiceStatus(3);//Currently being serviced
      }

    }

    private void UpdateVehicleServiceStatus(byte? serviceStatusId) {
      try {

        var res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
          return svcs.UpdateVehiceServiceStatus(_dealerId, CustomerInfo.VehicleServiceGuid, CustomerInfo.VehicleGuid, CustomerInfo.PersonGuid, serviceStatusId, CustomerInfo.VehicleGuid);
        });

        

      }
      catch (Exception ex) {
        MessageBox(ex.Message.ToString(), "Error !");
      }
      this.Close();
    }

    private bool CheckIfKioskIsInUse() {
      var res = new List<uspSelKioskInUSE_Result>();
      try {
        res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
          return svcs.SelKioskInUSE(_dealerId).ToList();
        });


        if (res != null && res.Count == 1) {
          if (res.FirstOrDefault().IsMachineInUse == true) {
            MessageBox("Kiosk InUse by Customer, Please try in few minutes ...");
            cmdBack_Click(new object(), new RoutedEventArgs());
            return false;

          }
          else {

            var res1 = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
              return svcs.UpsertKioskInUSE(_dealerId, "D", new Guid("A0B1C2D3-E4F5-AABB-CCDD-9F8E7D6C5B4A"));
            });

          }
        }
      }

      catch (Exception ex) {
        MessageBox(ex.Message.ToString(), "Error !");
      }

      return true;
    }


    private bool? MessageBox(string msg, string header = "Information") {
      var wnd = new AdamMessageBox();
      wnd.TxtError.Text = msg;
      wnd.TxtHeader.Text = header;
      wnd.BtnNo.Visibility = System.Windows.Visibility.Collapsed;
      wnd.BtnYes.Visibility = System.Windows.Visibility.Collapsed;
      wnd.CmdOk.Visibility = System.Windows.Visibility.Visible;
      // wnd.Width = System.Windows.SystemParameters.WorkArea.Width - 10;
      // wnd.Height = 400;
      var x = wnd.ShowDialog();
      return x;
    }

    private void cmdOpenDoor_Click(object sender, RoutedEventArgs e) {
      //Thread t = new Thread(OpenDoorLatchAndBringToHomePosition);

      OpenDoorLatchAndBringToHomePosition();

      cmdPlaceKeys.IsEnabled = true;
      cmdPlaceKeys.Opacity = 1;

      cmdOpenDoor.IsEnabled = false;
      cmdOpenDoor.Opacity = .5;


    }

    private void OpenDoorLatchAndBringToHomePosition() {


      //ConfigClass.SendCommandToBoard("DL00500");
      //ConfigClass.SendCommandToBoard("DL001000");

    //  MessageBox("DL005000", "test");
      ConfigClass.SendCommandToBoard("DL005000");
      var res = MessageBox("The Door is now Open please place the keys and close the door.", "Attention");

      var FindHomeAndMoveStepsReading = SelectedPerson.NoOfRotationDealer;
      ConfigClass.SendCommandToBoard(FindHomeAndMoveStepsReading);

     // ConfigClass.SendCommandToBoard("DL003000");

      //Thread.Sleep(TimeSpan.FromHours(1));
    }

    private void cmdPlaceKeys_Click(object sender, RoutedEventArgs e) {

      var wnd = new AdamMessageBox();
      wnd.TxtError.Text = "KINDLY ENSURE THAT THE KEYS ARE PLACED AND DOOR IS CLOSED.";
      wnd.TxtHeader.Text = "Confirmation";
      wnd.BtnNo.Visibility = System.Windows.Visibility.Visible;
      wnd.BtnYes.Visibility = System.Windows.Visibility.Visible;
      wnd.CmdOk.Visibility = System.Windows.Visibility.Collapsed;

      var x = wnd.ShowDialog();

      if (x == true) {
        //MessageBox("key placed");


        ConfigClass.SendCommandToBoard("KC00170000"); // key floor

        if (SelectedPerson.ServiceStatus == 4 && CustomerInfo.VehicleGuid == null) {
          TowTruckOrPhoneDrop();
        }
        else {
         // UpdateVehicleServiceStatus(SelectedPerson.ServiceStatus);//Ready for Pickup
          TowTruckOrPhoneDrop();
        }
      }

    }


    private void TowTruckOrPhoneDrop() {

      // Thread t = new Thread(FindHomeAndRotateKeyFloor);

      // MessageBox(RotateKeyFloorReading, "dfd");
      //ConfigClass.SendCommandToBoard(SelectedPerson.NoOfRotationDealer); //careousel
      //ConfigClass.SendCommandToBoard("KC00170000");// key floor


      // IsKeyDroppedClcked = true;

      var firstName = CustomerInfo.FirstName;
      var phone = CustomerInfo.PhoneNumber;
      var svcInfo = CustomerInfo.Comments;
      byte? serviceStatusId = 4;
      byte? assignedKeyLockerBucketId = Convert.ToByte(SelectedPerson.NoOfRotationDealer.Substring(2, 2));


      // Phone customer will have service guid // towtruck no guid
      if (CustomerInfo.VehicleServiceGuid != null) {
        try {

          var res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
            return svcs.UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(_dealerId, CustomerInfo.VehicleServiceGuid, CustomerInfo.VehicleGuid, svcInfo, serviceStatusId, assignedKeyLockerBucketId);
          });

        }
        catch (Exception ex) {
          MessageBox(ex.Message.ToString(), "Error !");
        }
      }
      else {

        try {

          var res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
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


            var res = ATP.Common.ProxyHelper.Service<IOutDoor>.Use(svcs => {
              return svcs.InsDealerMsg(x);
            });

          }

        }
        catch (Exception ex) {
          MessageBox(ex.Message.ToString(), "Error !");
        }
      }
      this.Close();

    }


    public string SendMsgToDevice(uspVerifyPinGetCustInfo_Result currPerson, string contentTitle, string msgType, string MsgToCust, string message) {
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

  }
}
