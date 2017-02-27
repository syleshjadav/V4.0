using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopExpress.Common {
  public static class ConfigClass {

    public static int DealerId { get; set; }

    public static SerialPort MyShopSerialPort { get; set; }


    public static void SendCommandToBoard(string scommand) {

     // System.Windows.Forms.MessageBox.Show(scommand);

      return;

      if (!MyShopSerialPort.IsOpen) { MyShopSerialPort.Open(); }
      MyShopSerialPort.Write(scommand + "\n");


    }
  }



  public class SerialPortInterface {

    public SerialPortInterface() {

      int _baudRate = 19200;
      int _dataBits = 8;
      Handshake _handshake = Handshake.None;
      Parity _parity = Parity.None;
      StopBits _stopBits = StopBits.One;

      ConfigClass.MyShopSerialPort = new SerialPort();

      ConfigClass.MyShopSerialPort.BaudRate = _baudRate;
      ConfigClass.MyShopSerialPort.DataBits = _dataBits;
      ConfigClass.MyShopSerialPort.Handshake = _handshake;
      ConfigClass.MyShopSerialPort.Parity = _parity;
      ConfigClass.MyShopSerialPort.StopBits = _stopBits;
      ConfigClass.MyShopSerialPort.Encoding = System.Text.Encoding.Default;
      ConfigClass.MyShopSerialPort.ReadTimeout = 10000;

      ConfigClass.MyShopSerialPort.DtrEnable = true;
      ConfigClass.MyShopSerialPort.RtsEnable = true;




    }


  }
}


