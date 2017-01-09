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
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WinTester {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();


        }
        private void RecallFound(string msg) {
            string path = @"c:\temp\recallFound.csv";
            // This text is added only once to the file.
            if (!File.Exists(path)) {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path)) {
                    sw.WriteLine("VIN ,RECALLDT, MSG");
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path)) {
                sw.WriteLine(msg);

            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            string Plate = string.Empty;
            string Phone = string.Empty;
            string Email = "sasi@ibc.com";
            try {



                var filePath = @"C:\temp\0308-REM.csv";

                StreamReader streamreader = new StreamReader(filePath);
                DataTable datatable = new DataTable();
                int rowcount = 0;
                string[] columnname = null;
                string[] streamdatavalue = null;
                while (!streamreader.EndOfStream) {
                    string streamrowdata = streamreader.ReadLine().Trim();
                    if (streamrowdata.Length > 0) {
                        streamdatavalue = streamrowdata.Split(',');
                        if (rowcount == 0) {
                            rowcount = 1;
                            columnname = streamdatavalue;
                            foreach (string csvheader in columnname) {
                                DataColumn datacolumn = new DataColumn(csvheader.ToUpper(), typeof(string));
                                datacolumn.DefaultValue = string.Empty;
                                datatable.Columns.Add(datacolumn);
                            }
                        }
                        else {
                            DataRow datarow = datatable.NewRow();
                            for (int i = 0; i < columnname.Length; i++) {
                                datarow[columnname[i]] = streamdatavalue[i] == null ? string.Empty : streamdatavalue[i].ToString();
                            }
                            datatable.Rows.Add(datarow);
                        }
                    }
                }
                streamreader.Close();
                streamreader.Dispose();
                foreach (DataRow dr in datatable.Rows) {
                    string rowvalues = string.Empty;
                    foreach (string csvcolumns in columnname) {
                        //rowvalues += csvcolumns + "=" + dr[csvcolumns].ToString() + "    ";
                        if (csvcolumns == "VIN") {
                            string vinToCheck = dr[csvcolumns].ToString();

                            var rtn = GetVinDetails(vinToCheck);

                            if (rtn != null) {
                                RecallFound(rtn);
                            }
                        }
                    }
                    //  Console.WriteLine(rowvalues);
                }
                // Console.ReadLine();




                //GetVinDetails("1J4HR58N85C636798");


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
                string rtn="";
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

                //  JavaScriptSerializer json_serializer = new JavaScriptSerializer();

                var results = JsonConvert.DeserializeObject<SampleClass>(rtnvalue);

                if (results.OEM_DATA != null && results.OEM_DATA.OPEN_RECALLS != null && results.OEM_DATA.OPEN_RECALLS.Count() > 0) {
                    foreach (var m in results.OEM_DATA.OPEN_RECALLS) {
                        var dt = "";
                        if (m != null && m.RECALL_DATE != null) {
                            if (m.RECALL_DATE.Length > 9) {
                                dt = m.RECALL_DATE.Substring(0, 10);
                            }

                            rtn += string.Format("{0},{1},{2}", vin, dt, m.RECALL_TITLE);
                        }
                    }

                }

                // var id = results.Id;

                //  SampleClass routes_list = (SampleClass)json_serializer.DeserializeObject(rtnvalue);

                return rtn;

            }
            catch (Exception ex) {
                //Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

    }
}


public class VINDATA {
    public int VIN_CORRECTED;
    public int VIN_MATCHED;
    public string VIN_PROVIDED;
    public string VIN_FOUND;
    public string VIN_STEM;
    public object VIN_MARKUP_PROVIDED;
    public object VIN_MARKUP_CORRECTED;
    public int YEAR;
    public string MAKE;
    public string MODEL;
}

public class OPENRECALL {
    public string VIN_RECALL_STATUS;
    public string MFR_RECALL_NUMBER;
    public string NHTSA_RECALL_NUMBER;
    public string RECALL_DATE;
    public string RECALL_TYPE;
    public string RECALL_TITLE;
    public string RECALL_DESCRIPTION;
    public string SAFETY_RISK_DESCRIPTION;
    public string REMEDY_DESCRIPTION;
    public object MFR_NOTES;
}

public class OEMDATA {
    public object OEM_VIN_ERROR_CODE;
    public int OEM_VIN_STATUS_FLG;
    public string OEM_VIN_STATUS_MSG;
    public string OEM_VEHICLE_STATUS_FLG;
    public int VIN_VALID_FLG;
    public int RECALLS_AVAILABLE_FLG;
    public string RECALLS_AVAILABLE_MSG;
    public int NUMBER_OF_RECALLS;
    public string REFRESH_DATE;
    public int VEHICLE_YEAR;
    public string VEHICLE_MAKE;
    public string VEHICLE_MODEL;
    public OPENRECALL[] OPEN_RECALLS;
    public object[] POSSIBLE_RECALLS;
}

public class SampleClass {
    public VINDATA VIN_DATA;
    public OEMDATA OEM_DATA;
    public string CONSUMER_MSG;
}
