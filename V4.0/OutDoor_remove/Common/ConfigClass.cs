using ATP.Kiosk.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyShopOutDoor.Common {
    public static class ConfigClass {

        public static int DealerId { get; set; }

        //  public static SerialPort DealerSerialPort { get; set; }
        public static SerialPort CustomerSerialPort { get; set; }


        public static void SendCommandToBoard(string scommand) {
            // return;

          //  SerialPortInterface sp = new SerialPortInterface();

            MessageBox(ConfigClass.CustomerSerialPort.IsOpen.ToString());

            if (!ConfigClass.CustomerSerialPort.IsOpen) { ConfigClass.CustomerSerialPort.Open(); }
            ConfigClass.CustomerSerialPort.Write(scommand + "\n");

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
    }

  

    public class SerialPortInterface {

        public SerialPortInterface() {

            int _baudRate = 19200;
            int _dataBits = 8;
            Handshake _handshake = Handshake.None;
            Parity _parity = Parity.None;
            StopBits _stopBits = StopBits.One;

           


            ConfigClass.CustomerSerialPort = new SerialPort();
            ConfigClass.CustomerSerialPort.BaudRate = _baudRate;
            ConfigClass.CustomerSerialPort.DataBits = _dataBits;
            ConfigClass.CustomerSerialPort.Handshake = _handshake;
            ConfigClass.CustomerSerialPort.Parity = _parity;
            ConfigClass.CustomerSerialPort.StopBits = _stopBits;
            ConfigClass.CustomerSerialPort.Encoding = System.Text.Encoding.Default;
            ConfigClass.CustomerSerialPort.ReadTimeout = 10000;

            ConfigClass.CustomerSerialPort.DtrEnable = true;
            ConfigClass.CustomerSerialPort.RtsEnable = true;

            ConfigClass.CustomerSerialPort.PortName = "COM3";

        }





    }

    public class Serializer {
        public T Deserialize<T>(string input) where T : class {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input)) {
                return (T)ser.Deserialize(sr);
            }
        }

        public string Serialize<T>(T ObjectToSerialize) {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter()) {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}


