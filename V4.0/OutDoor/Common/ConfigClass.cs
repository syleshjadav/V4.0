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

            if (!CustomerSerialPort.IsOpen) { CustomerSerialPort.Open(); }
            CustomerSerialPort.Write(scommand + "\n");

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


