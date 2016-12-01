
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
using MyShopOutDoor.Common;
using MyShopOutDoor.MyShopUserControl;

namespace MyShopOutDoor {
  /// <summary>
  /// Interaction logic for CustomerKeyDropWindow.xaml
  /// </summary>
  public partial class CustomerKeyDropWindow : UserControl {

    private OutDoorProxy.uspVerifyPinGetCustInfo_Result CustomerInfo { get; set; }
    private string FindHomeAndMoveStepsReading { get; set; }
    private string RotateKeyFloorReading { get; set; }
    private string DoorLatchReading { get; set; }


    SerialPort _serialPort = ConfigClass.DealerSerialPort;
    int _dealerId = ConfigClass.DealerId;
    public CustomerKeyDropWindow() {
      InitializeComponent();
      App.Current.SessionEnding += Current_SessionEnding;
      CtrlValidatePin.cmdVerifyPIN.Click += CmdVerifyPIN_Click;
      _serialPort = new SerialPort();
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
      if (_serialPort.IsOpen) { _serialPort.Close(); }
    }
  //  private bool _IsDoorClosed = false;

    private void cmdOpenDoorLatch_Click(object sender, RoutedEventArgs e) {
      ConfigClass.SendCommandToBoard("DL" + DoorLatchReading);
    }



    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      if (_serialPort.IsOpen) { _serialPort.Close(); }
    }

    private void CtrlCustomerKeyDrop_Unloaded(object sender, RoutedEventArgs e) {

      if (_serialPort.IsOpen) { _serialPort.Close(); }
    }



    private void CmdVerifyPIN_Click(object sender, RoutedEventArgs e) {


      var res = new List<OutDoorProxy.uspVerifyPinGetCustInfo_Result>();
      var x = new List<uspSelVehicleMakes_Result>();

      try {
        res = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
          return svcs.VerifyPinGetCustInfo(_dealerId, true, CtrlValidatePin.TxtPin.Text).ToList();
        });

        if (res != null && res.Count == 1) {
          if (res[0].PinStatus == "G") {
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

            var stepsLst = ATP.Common.ProxyHelper.Service<OutDoorProxy.IOutDoor>.Use(svcs => {
              return svcs.GetKeyLockerSteps(_dealerId, null, true).ToList();
            });

            if (stepsLst != null && stepsLst.Count > 0) {
              FindHomeAndMoveStepsReading = stepsLst.Where(m => m.StepCode == "FH").SingleOrDefault().NoOfRotationCustomer ;
              RotateKeyFloorReading = stepsLst.Where(m => m.StepCode == "KF").SingleOrDefault().StepReading;
              DoorLatchReading = stepsLst.Where(m => m.StepCode == "DL").SingleOrDefault().StepReading;

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
    // int iOpenDoorPressedCount = 0;

    //private void cmdChkDoorClosed_Click(object sender, RoutedEventArgs e) {



    //  // _serialPort.Write("FH47500 \n"); // jadav
    //  ConfigClass.SendCommandToBoard("DL5000" , "C");

    //  MessageBox("The Door is now open, Place the key and click DROP KEY button", "Information");
    //}

    //private async void TurnKeyFloor() {

    //    await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
    //    {
    //        _serialPort.Write("KF170000 \n");

    //        await Task.Delay(15000);

    //    });
    //}
   

    private void GoHome() {
      NavigationService nav = NavigationService.GetNavigationService(this);
      nav.Navigate(new Uri("MenuWindow.xaml", UriKind.RelativeOrAbsolute));
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

            var wnd = new OpenDoorAndDropKeys();
            wnd.CustomerInfo = CustomerInfo;

            wnd.Show();
            

        }

    private void cmdBack_Click(object sender, RoutedEventArgs e) {
      GoHome();
    }
  }

}
