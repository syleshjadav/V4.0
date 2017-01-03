using ATP.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTester {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e) {
            string Plate = string.Empty;
            string Phone = string.Empty;
            string Email = "sasi@ibc.com";
            try {
                GetVinDetails("1J4HR58N85C636798");
                //var mx = new ATP.Services.Data.Person().FindCustomerByPhPlateEmail(Plate, Phone, Email);

                //var xx = mx
                //     .Select(m =>
                //     new ATPCustomerDetailsByGuid {

                //         DealerFamilyId = "5",
                //         DealerId = m.DealerId.ToString(),
                //         DealerName = m.DealerName,
                //         // DealerPersonGroupId = m.DealerPersonGroupId,
                //         EmailAddress = m.EmailAddress,
                //         FirstName = m.FirstName,
                //         GoogleGuid = m.GoogleGuid,
                //         //  GroupName = m.GroupName,
                //         //  IsValid = m.IsValid.ToString(),
                //         LastName = m.LastName,
                //         MiddleName = m.MiddleName,
                //         //  NextInspectionDate = m.NextInspectionDate,
                //         //  NextServiceDate = m.NextServiceDate,
                //         PersonGuid = m.PersonGuid.ToString(),
                //         PhoneNumber = m.PhoneNumber,
                //         Plate = m.Plate,
                //         //  NextSvcInfo = m.NextSvcInfo,
                //         VehicleGuid = m.VehicleGuid.ToString(),
                //         VehicleMake = m.VehicleMake,
                //         VehicleModel = m.VehicleModel,
                //         VehicleName = m.VehicleName,
                //         VehicleTrim = m.VehicleTrim,
                //         VehicleYear = m.VehicleYear != null ? m.VehicleYear.ToString() : "",
                //         VehicleYrMkMod = m.VehicleYrMkMod,
                //         VIN = m.VIN,
                //         VehicleId = m.VehicleId.ToString(),
                //         VehPhId = m.VehPhId
                //     }).ToList();




            }
            catch (Exception ex) {

                // TraceLog("FindCustomerByPhPlateEmail", string.Format("{0} -  Error while FindCustomerByPhPlateEmail  - {1}", Email, ex.Message));
                MessageBox.Show(ex.Message);
            }

            // return new List<ATPCustomerDetailsByGuid>();

        }


        public string GetVinDetails(string vin) {
            // var requestUrl = "https://demo.vinterpreter.us:9881/ords/demo/v1/get_vin_info?vin=1FMDU34E8VZA90882";
            // var requestUrl = "https://demo.vinterpreter.us:9881/ords/demo/v1/get_recall_info_vin?vin=1ZVFT82H775283137";
            var requestUrl = string.Format("{0}{1}", "https://prd.vinterpreter.us:9881/ords/prd/v1/get_recall_info_vin?vin=", vin);
            try {
                string rtnvalue = "";

                var client = new WebClient();


                // Synchronous Consumption
                //  var client = new WebClient();
                client.Headers.Add("API_ACT", "MYSHOP");
                client.Headers.Add("API_KEY", "8E6B0E007F8CDEB95084F604732EDC4C");

                rtnvalue = client.DownloadString(requestUrl);


                // Create the Json serializer and parse the response
                //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RootObject));
                //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
                //{
                //    var weatherData = (RootObject)serializer.ReadObject(ms);
                //}
                return rtnvalue;

            }
            catch (Exception ex) {
                //Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

    }
}

