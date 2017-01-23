using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using System.Windows.Threading;

namespace MyShopOutDoor {


  public partial class MenuWindow : UserControl {

    private int _baudRate = 19200;
    private int _dataBits = 8;
    private Handshake _handshake = Handshake.None;
    private Parity _parity = Parity.None;
    private string _portName = "COM4";
    private StopBits _stopBits = StopBits.One;
    SerialPort _serialPort;

    public MenuWindow() {
      InitializeComponent();
      /*
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

      if (!_serialPort.IsOpen) { _serialPort.Open(); }
      */
    }
    private delegate void UpdateUiTextDelegate(string text);
    private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
      string recieved_data = _serialPort.ReadExisting();
      Dispatcher.Invoke(DispatcherPriority.Send, new UpdateUiTextDelegate(WriteData), recieved_data);

    }
    private void WriteData(string text) {
      // Assign the value of the plot to the RichTextBox.
      //  lstStatus.Items.Add(text);
      if (text.Contains("KF-DONE")) {
        MessageBox.Show("KeyFloor Done");
      }

      if (text.Contains("FH-DONE")) {
        MessageBox.Show("Find Home Done");
      }

      if (text.Contains("BT-DONE")) {
        MessageBox.Show("Bucket Topple  Done");
      }
    }

    private void ClosePort() {
      if (_serialPort.IsOpen) { _serialPort.Close(); }
    }
    private bool _IsDoorClosed = false;
    private void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e) {

    }

   

    private void cmdKeysPickUp_Click(object sender, RoutedEventArgs e) {

      NavigationService nav = NavigationService.GetNavigationService(this);
      nav.Navigate(new Uri("KeyPickUpWindow.xaml", UriKind.RelativeOrAbsolute));

    }

    private void cmdDropKeys_Click(object sender, RoutedEventArgs e) {

      NavigationService nav = NavigationService.GetNavigationService(this);

      nav.Navigate(new Uri("KeyDropWindow.xaml", UriKind.RelativeOrAbsolute));
    
      //if (!_serialPort.IsOpen) { _serialPort.Open(); }


      //_serialPort.Write("FH47500 \n");

      //_serialPort.Write("KF170000 \n");

      //_serialPort.Write("BT75000 \n");

      



    }

  

    private void CtrlMenuWindow_Unloaded(object sender, RoutedEventArgs e) {
      //if (_serialPort.IsOpen) { _serialPort.Close(); }
    }
  }
}
