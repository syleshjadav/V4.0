using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopOutDoor.Common {
    public static class ConfigClass {

        public static int DealerId { get; set; }

        public static SerialPort DealerSerialPort { get; set; }


        public static void SendCommandToBoard(string scommand) {
            //return;

            if (!DealerSerialPort.IsOpen) { DealerSerialPort.Open(); }
            DealerSerialPort.Write(scommand + "\n");


        }
    }



    public class SerialPortInterface {

        public SerialPortInterface() {

            int _baudRate = 19200;
            int _dataBits = 8;
            Handshake _handshake = Handshake.None;
            Parity _parity = Parity.None;
            StopBits _stopBits = StopBits.One;

            ConfigClass.DealerSerialPort = new SerialPort();

            ConfigClass.DealerSerialPort.BaudRate = _baudRate;
            ConfigClass.DealerSerialPort.DataBits = _dataBits;
            ConfigClass.DealerSerialPort.Handshake = _handshake;
            ConfigClass.DealerSerialPort.Parity = _parity;
            ConfigClass.DealerSerialPort.StopBits = _stopBits;
            ConfigClass.DealerSerialPort.Encoding = System.Text.Encoding.Default;
            ConfigClass.DealerSerialPort.ReadTimeout = 10000;

            ConfigClass.DealerSerialPort.DtrEnable = true;
            ConfigClass.DealerSerialPort.RtsEnable = true;




        }


    }
}


