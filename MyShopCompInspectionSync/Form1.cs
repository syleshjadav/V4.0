using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advantage.Data.Provider;
using System.Collections;
using System.Reflection;
using WSHControllerLibrary;
using MyShopCompInspectionSync.MyShopProxy;
using IWshRuntimeLibrary;
using System.IO;

namespace MyShopCompInspectionSync
{
    public partial class Form1 : Form
    {

        AdsConnection conn = new AdsConnection();
        AdsCommand cmd = new AdsCommand();
        AdsDataAdapter adapter = new AdsDataAdapter();
        DataSet dset = new DataSet();

        //string Connectionstring = "data source = c:\\SIRPA\\Data\\SIRDATA.ADD; ServerType=remote|local; TableType=ADT";
        string Connectionstring = MyShopCompInspectionSync.Properties.Settings.Default.ConnectionString;
        private int counter = 120;
        private int servicePollInterval = 120;
        private int dealerId = 103;
        private bool IsAutoPilot = false;

        public Form1()
        {
            InitializeComponent();


            Connectionstring = MyShopCompInspectionSync.Properties.Settings.Default.ConnectionString;

            servicePollInterval = MyShopCompInspectionSync.Properties.Settings.Default.ServicePollInterval;
            dealerId = MyShopCompInspectionSync.Properties.Settings.Default.DealerId;
            IsAutoPilot = MyShopCompInspectionSync.Properties.Settings.Default.IsAutoPilot;

            if (IsAutoPilot == true)
            {
                timer1.Enabled = true;

            }
            counter = servicePollInterval;
            lblCountDown.Text = counter.ToString();



            //SelectAllCounties();

            // UpsertCustomer();
            DateTime thisDay = DateTime.Today;
            txtInspectionDate.Text = thisDay.ToString("d");


        }

        //private void UpsertCustomer()
        //{
        //  CustVehInfo cust = LoadControlValueToObject();



        //  //cust.InspectionInfo = inspInfo;
        //  //cust.Brakes = brakes;
        //  //cust.Tires = tires;


        //  try
        //  {

        //    string sql = " SELECT top 10 * from CustomerVehicle WHERE VIN='" + cust.VIN + "'";

        //    cmd.CommandText = sql;
        //    cmd.Connection = conn;
        //    adapter.SelectCommand = cmd;
        //    adapter.Fill(dset);


        //    if (dset.Tables[0].Rows.Count == 0) // insert a new customer
        //    {
        //      sql = "INSERT INTO CustomerVehicle (FirstName, Lastname, VIN)  VALUES (:FirstName, :Lastname, :VIN) ";
        //    }
        //    else if (dset.Tables[0].Rows.Count == 1)
        //    {

        //      sql = "UPDATE CustomerVehicle SET FirstName = :FirstName, LastName=:LastName, City=:City, State=:State, Zip=:Zip," +
        //                   " VehicleCounty=:VehicleCounty,CountyCode=:CountyCode, Plate=:Plate,VehicleMake=:VehicleMake,VehicleBody=:VehicleBody, VehicleYear=:VehicleYear, " +
        //                   "Odometer=:Odometer, NAIC=:NAIC,InsuranceCompany=:InsuranceCompany,PolicyNumber=:PolicyNumber,InsuranceExpires=:InsuranceExpires" +
        //               " WHERE VIN='" + cust.VIN + "'";


        //    }
        //    else
        //    {
        //      return;
        //    }

        //    using (AdsConnection cn = new AdsConnection(Connectionstring))
        //    {
        //      using (var cmd = new AdsCommand(sql, cn))
        //      {
        //        // define parameters and their values

        //        cmd.Parameters.Add("FirstName", cust.FirstName);
        //        cmd.Parameters.Add("LastName", cust.LastName);
        //        cmd.Parameters.Add("City", cust.City);
        //        cmd.Parameters.Add("State", cust.State);
        //        cmd.Parameters.Add("Zip", cust.Zip);
        //        cmd.Parameters.Add("VehicleCounty", cust.County);
        //        cmd.Parameters.Add("CountyCode", cust.CountyCode);

        //        cmd.Parameters.Add("Plate", cust.Plate);
        //        cmd.Parameters.Add("VehicleMake", cust.VehicleMake);
        //        cmd.Parameters.Add("VehicleBody", cust.Body);
        //        cmd.Parameters.Add("VehicleYear", cust.Year);
        //        cmd.Parameters.Add("Odometer", cust.CurrOdo);

        //        cmd.Parameters.Add("VehicleBody", cust.Body);
        //        cmd.Parameters.Add("VehicleYear", cust.Year);
        //        cmd.Parameters.Add("Odometer", cust.CurrOdo);


        //        cmd.Parameters.Add("NAIC", cust.Naic);
        //        cmd.Parameters.Add("InsuranceCompany", cust.InsCpy);
        //        cmd.Parameters.Add("PolicyNumber", cust.Policy);
        //        cmd.Parameters.Add("InsuranceExpires", cust.ExpDate);

        //        /*
        //        cmd.Parameters.Add("NAIC", inspInfo.Body);
        //        cmd.Parameters.Add("NAIC", inspInfo.Break);
        //        cmd.Parameters.Add("Exhaust", inspInfo.Exhaust);
        //        cmd.Parameters.Add("NAIC", inspInfo.Fuel);
        //        cmd.Parameters.Add("GlazingMirrors", inspInfo.Glazing);
        //        cmd.Parameters.Add("Lighting", inspInfo.Lights);
        //        cmd.Parameters.Add("Other", inspInfo.Other);
        //        cmd.Parameters.Add("NAIC", inspInfo.RegVerified);
        //        cmd.Parameters.Add("NAIC", inspInfo.RoadTest);
        //        cmd.Parameters.Add("Streering", inspInfo.Streering);
        //        cmd.Parameters.Add("NAIC", inspInfo.Tires);
        //        */



        //        cn.Open();
        //        cmd.ExecuteNonQuery();
        //        cn.Close();
        //      }





        //    }

        //  }
        //  catch (AdsException e)
        //  {
        //    // print the exception message
        //    Console.WriteLine(e.Message);
        //  }
        //}

        private CustVehInfo LoadControlValueToObject()
        {
            var cust = new CustVehInfo
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Address1 = txtAddress1.Text,
                Address2 = txtAdd2.Text,
                City = txtCity.Text,
                State = txtState.Text,
                Zip = txtZip.Text,
                CountyCode = txtCountyCode.Text,
                County = txtCounty.Text,
                Region = CustomerInfo.Region,
                VIN = txtVin.Text,
                Plate = txtPlate.Text,
                Year = txtYear.Text,
                VehicleMake = txtMake.Text,
                VehicleModel = txtModel.Text,
                Body = txtBody.Text,
                CurrOdo = txtCurrOdo.Text,
                PrevOdo = txtOldOdo.Text,
                Naic = txtNaic.Text,
                ExpDate = txtExpDt.Text,
                Policy = txtPolicy.Text,
                InsCpy = txtInsuranceCpy.Text,
                InspectionDate = txtInspectionDate.Text,
                EmissonNum = txtEmissionNum.Text,
                StrickerMMYY = txtStickerMMYY.Text,
                WorkOrder = txtWorkOrder.Text

            };
            var inspInfo = new InspectionInfo
            {
                RegVerified = txtRegistrationVerified.Text,
                RoadTest = txtRoadTest.Text,
                Tires = txtTires.Text,
                Body = txtBodyInfo.Text,
                Fuel = txtFuel.Text,
                Break = txtBrake.Text,
                Exhaust = txtExhaust.Text,
                Glazing = txtGlazing.Text,
                Lights = txtLights.Text,
                Streering = txtSteering.Text,
                Other = txtOther.Text
            };
            var brakes = new Brakes
            {
                BrakeLFThickness = TxtLFBReading.Text,
                BrakeLRThickness = txtLRBReading.Text,
                BrakeRFThickness = TxtRFBReading.Text,
                BrakeRRThickness = TxtRRBReading.Text,

                LFBrakeBondRivet = txtLFBCondition.Text,
                LRBrakeBondRivet = txtLRBCondition.Text,

                RFBrakeBondRivet = txtRFBCondition.Text,
                RRBrakeBondRivet = txtRRBCondition.Text,
                //BrakeRRBondRivet = txtRRBCondition.Text,


            };
            var tires = new Tires
            {
                TireRightFront = txtRFTReading.Text,
                TireRightRear = txtRRTReading.Text,
                TireLeftFront = txtLFTReading.Text,
                TireLeftRear = txtLRTReading.Text,

                LowestTireReading = CustomerInfo.Tires.LowestTireReading,
                LowestTireSide = CustomerInfo.Tires.LowestTireSide
            };

            var visual = new VisualAnti
            {
                AIRPump = txtAirPump.Text,
                CatalyticConverter = txtCatalyticConvertor.Text,
                ERG = TxtERGValue.Text,
                EvaporativeControl = txtEvaporativeControl.Text,
                FuelInlet = txtFuelInlet.Text,
                PCV = txtPCVValue.Text

            };

            cust.Brakes = brakes;
            cust.Tires = tires;
            cust.InspectionInfo = inspInfo;
            cust.VisualAnti = visual;

            cust.InspectionInfo.PassInspection = "Y";

            if (cust.InspectionInfo.Body == "F" || cust.InspectionInfo.Break == "F" || cust.InspectionInfo.Exhaust == "F" || cust.InspectionInfo.Fuel == "F" || cust.InspectionInfo.Glazing == "F" ||
              cust.InspectionInfo.Lights == "F" || cust.InspectionInfo.Other == "F" || cust.InspectionInfo.RegVerified == "F" || cust.InspectionInfo.RoadTest == "F" || cust.InspectionInfo.Streering == "F" ||
              cust.InspectionInfo.Tires == "F")
            {
                cust.InspectionInfo.PassInspection = "N";
            }

            if (cust.VisualAnti.AIRPump == "F" || cust.VisualAnti.CatalyticConverter == "F" || cust.VisualAnti.ERG == "F" || cust.VisualAnti.EvaporativeControl == "F" || cust.VisualAnti.FuelInlet == "F"
              || cust.VisualAnti.PCV == "F")
            {
                cust.InspectionInfo.PassInspection = "N";
            }


            cust.InspectionCost = CustomerInfo.InspectionCost;
            cust.TotalCost = CustomerInfo.TotalCost;
            cust.StickerCharge = CustomerInfo.StickerCharge;
            cust.EmissonNum = CustomerInfo.EmissonNum;
            cust.Id = CustomerInfo.Id;
            cust.VehicleServiceGuid = CustomerInfo.VehicleServiceGuid;
            cust.Station_Id = CustomerInfo.Station_Id;


            return cust;
        }

        private void LoadObjectToControlValue()
        {

            txtFirstName.Text = CustomerInfo.FirstName;
            txtLastName.Text = CustomerInfo.LastName;
            txtAddress1.Text = CustomerInfo.Address1;
            txtAdd2.Text = CustomerInfo.Address2;
            txtCity.Text = CustomerInfo.City;

            txtState.Text = CustomerInfo.State;
            txtZip.Text = CustomerInfo.Zip;
            txtCountyCode.Text = CustomerInfo.CountyCode;
            txtCounty.Text = CustomerInfo.County;

            txtVin.Text = CustomerInfo.VIN;
            txtPlate.Text = CustomerInfo.Plate;
            txtYear.Text = CustomerInfo.Year;
            txtMake.Text = CustomerInfo.VehicleMake;
            txtModel.Text = CustomerInfo.VehicleModel;
            txtBody.Text = CustomerInfo.Body;
            txtCurrOdo.Text = CustomerInfo.CurrOdo;
            txtOldOdo.Text = CustomerInfo.PrevOdo;
            txtNaic.Text = CustomerInfo.Naic;
            txtInsuranceCpy.Text = CustomerInfo.InsCpy;
            txtExpDt.Text = CustomerInfo.ExpDate;
            txtPolicy.Text = CustomerInfo.Policy;
            txtInspectionDate.Text = CustomerInfo.InspectionDate;
            txtEmissionNum.Text = CustomerInfo.EmissonNum;
            txtWorkOrder.Text = CustomerInfo.WorkOrder;
            txtStickerMMYY.Text = CustomerInfo.StrickerMMYY;
            txtInspCost.Text = CustomerInfo.InspectionCost;
            txtVehicleServiceGuid.Text = CustomerInfo.VehicleServiceGuid.ToString();


            txtRegistrationVerified.Text = CustomerInfo.InspectionInfo.RegVerified;
            txtRoadTest.Text = CustomerInfo.InspectionInfo.RoadTest;
            txtTires.Text = CustomerInfo.InspectionInfo.Tires;
            txtBodyInfo.Text = CustomerInfo.InspectionInfo.Body;
            txtFuel.Text = CustomerInfo.InspectionInfo.Fuel;
            txtBrake.Text = CustomerInfo.InspectionInfo.Break;
            txtExhaust.Text = CustomerInfo.InspectionInfo.Exhaust;
            txtGlazing.Text = CustomerInfo.InspectionInfo.Glazing;
            txtLights.Text = CustomerInfo.InspectionInfo.Lights;
            txtSteering.Text = CustomerInfo.InspectionInfo.Streering;
            txtOther.Text = CustomerInfo.InspectionInfo.Other;

            TxtLFBReading.Text = CustomerInfo.Brakes.BrakeLFThickness;
            txtLRBReading.Text = CustomerInfo.Brakes.BrakeLRThickness;
            TxtRFBReading.Text = CustomerInfo.Brakes.BrakeRFThickness;
            TxtRRBReading.Text = CustomerInfo.Brakes.BrakeRRThickness;

            txtLFBCondition.Text = CustomerInfo.Brakes.LFBrakeBondRivet;
            txtLRBCondition.Text = CustomerInfo.Brakes.LRBrakeBondRivet;

            txtRFBCondition.Text = CustomerInfo.Brakes.RFBrakeBondRivet;
            txtRRBCondition.Text = CustomerInfo.Brakes.RRBrakeBondRivet;


            txtRFTReading.Text = CustomerInfo.Tires.TireRightFront;
            txtRRTReading.Text = CustomerInfo.Tires.TireRightRear;
            txtLFTReading.Text = CustomerInfo.Tires.TireLeftFront;
            txtLRTReading.Text = CustomerInfo.Tires.TireLeftRear;


            txtAirPump.Text = CustomerInfo.VisualAnti.AIRPump;
            txtCatalyticConvertor.Text = CustomerInfo.VisualAnti.CatalyticConverter;
            TxtERGValue.Text = CustomerInfo.VisualAnti.ERG;
            txtEvaporativeControl.Text = CustomerInfo.VisualAnti.EvaporativeControl;
            txtFuelInlet.Text = CustomerInfo.VisualAnti.FuelInlet;
            txtPCVValue.Text = CustomerInfo.VisualAnti.PCV;




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            lblCountDown.Text = counter.ToString();
            if (counter <= 0)
            {
                timer1.Stop();

                if (MyShopCompInspectionSync.Properties.Settings.Default.IsShowForm == false)
                {
                    this.Visible = false;
                }
                SelectAllCYADataFromWeb();
                counter = servicePollInterval;
            }

            timer1.Start();

        }

        private void SelectAllCYADataFromWeb()
        {
            try
            {

                CustomerInfo = new CustVehInfo();

                var res1 = ATP.Common.ProxyHelper.Service<ICompInspection>.Use(svcs =>
                {
                    return svcs.SelAllCompInspectionExportData(dealerId);
                });
                MapMyShopDataToObject(res1);


                if (IsAutoPilot == true && !string.IsNullOrEmpty(CustomerInfo.InspectionDate))
                {
                    UpsertInvoice();
                }



            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
        }

        private CustVehInfo CustomerInfo { get; set; }
        private void MapMyShopDataToObject(uspSelAllCompInspectionExportData_Result[] m)
        {
            if (m != null && m.Count() == 1)
            {
                var d = m[0];

                CustomerInfo = new CustVehInfo
                {
                    VehicleServiceGuid = d.VehicleServiceGuid,
                    Id = d.ID,
                    Body = d.VehBodyType,
                    County = d.VehicleCounty,
                    Region = d.Region,
                    CountyCode = d.VehicleCountyCode == null ? null : d.VehicleCountyCode.ToString(),
                    Address1 = d.Address1,
                    Address2 = d.Address2,
                    City = d.City,
                    CurrOdo = d.MilesOut == null ? null : d.MilesOut.ToString(),
                    ExpDate = d.InsuranceExpDate == null ? null : d.InsuranceExpDate.Value.ToString("d"),
                    FirstName = d.FirstName,
                    InsCpy = d.InsuranceCompanyName,
                    InspectionCost = d.InspectionCharge,
                    TotalCost = d.TotalCost,
                    StickerCharge = d.StickerCharge,
                    InspectionDate = d.InspectionDate,
                    EmissonNum = d.EmissionNum,
                    LastName = d.LastName,
                    MechanicLic = "",
                    MechanicName = "",
                    Naic = d.NAIC,
                    Plate = d.Plate,
                    Policy = d.Plate,
                    PrevOdo = d.OldMileage == null ? null : d.OldMileage.ToString(),
                    State = d.CustState,
                    VehicleMake = d.VehicleMake,
                    VehicleModel = d.VehicleModel,
                    VIN = d.VIN,
                    WorkOrder = d.WorkOrder,
                    StrickerMMYY = d.SafetyStickerYYMM,
                    Year = d.VehicleYear,
                    Zip = d.ZipCode,
                    Station_Id = d.StationNumber,
                    Brakes = new Brakes
                    {
                        LFBrakeBondRivet = d.LFBrakeBondRivet,
                        RFBrakeBondRivet = d.RFBrakeBondRivet,
                        LRBrakeBondRivet = d.LRBrakeBondRivet,
                        RRBrakeBondRivet = d.RRBrakeBondRivet,

                        BrakeLFThickness = d.BrakeFrontSize,
                        BrakeLRThickness = d.BrakeRearSize,
                        BrakeRFThickness = d.BrakeFrontRightSize,
                        BrakeRRThickness = d.BrakeRearRightSize
                    },
                    Tires = new Tires
                    {
                        TireLeftFront = d.TireFrontSize,
                        TireLeftRear = d.TireRearSize,
                        TireRightFront = d.TireFrontRightSize,
                        TireRightRear = d.TireRearRightSize
                    },
                    InspectionInfo = new InspectionInfo
                    {
                        Body = d.Body,
                        Break = d.BreakPedal,
                        Exhaust = d.Exhaust,
                        Fuel = d.Fuel,
                        Glazing = d.Glazing,
                        Lights = d.Lights,
                        Other = d.Other,
                        PassInspection = d.PassInspection,
                        RegVerified = d.RegVerified,
                        RoadTest = d.RoadTest,
                        Tires = d.Tires,
                        Streering = d.Streering
                    },
                    VisualAnti = new VisualAnti
                    {
                        AIRPump = d.AIRPump,
                        CatalyticConverter = d.CatalyticConverter,
                        ERG = d.ERG,
                        EvaporativeControl = d.EvaporativeControl,
                        FuelInlet = d.FuelInlet,
                        PCV = d.PCV

                    }

                };

                CustomerInfo.InspectionInfo.PassInspection = "Y";

                if (CustomerInfo.InspectionInfo.Body == "F" || CustomerInfo.InspectionInfo.Break == "F" || CustomerInfo.InspectionInfo.Exhaust == "F" || CustomerInfo.InspectionInfo.Fuel == "F" || CustomerInfo.InspectionInfo.Glazing == "F" ||
                  CustomerInfo.InspectionInfo.Lights == "F" || CustomerInfo.InspectionInfo.Other == "F" || CustomerInfo.InspectionInfo.RegVerified == "F" || CustomerInfo.InspectionInfo.RoadTest == "F" || CustomerInfo.InspectionInfo.Streering == "F" ||
                  CustomerInfo.InspectionInfo.Tires == "F")
                {
                    CustomerInfo.InspectionInfo.PassInspection = "N";
                }

                if (CustomerInfo.VisualAnti.AIRPump == "F" || CustomerInfo.VisualAnti.CatalyticConverter == "F" || CustomerInfo.VisualAnti.ERG == "F" || CustomerInfo.VisualAnti.EvaporativeControl == "F" || CustomerInfo.VisualAnti.FuelInlet == "F"
                  || CustomerInfo.VisualAnti.PCV == "F")
                {
                    CustomerInfo.InspectionInfo.PassInspection = "N";
                }


                var tireMinValueList = new List<TireMinValue>();


                if (!String.IsNullOrEmpty(d.TireFrontSize))
                {
                    tireMinValueList.Add(new TireMinValue(d.TireFrontSize, "LF"));
                }

                if (!String.IsNullOrEmpty(d.TireFrontRightSize))
                {
                    tireMinValueList.Add(new TireMinValue(d.TireFrontRightSize, "RF"));
                }

                if (!String.IsNullOrEmpty(d.TireRearSize))
                {
                    tireMinValueList.Add(new TireMinValue(d.TireRearSize, "LR"));
                }

                if (!String.IsNullOrEmpty(d.TireRearRightSize))
                {
                    tireMinValueList.Add(new TireMinValue(d.TireRearRightSize, "RR"));
                }

                var minv = tireMinValueList.Min(xx => xx.Key);

                if (minv != null)
                {
                    var md = tireMinValueList.Where(xx => xx.Key == minv).FirstOrDefault();
                    if (md != null)
                    {
                        CustomerInfo.Tires.LowestTireReading = md.Key;
                        CustomerInfo.Tires.LowestTireSide = md.Value;
                    }

                }

                LoadObjectToControlValue();
            }
        }


        //private void SelectAllCounties()
        //{
        //    try
        //    {

        //        string sql = " SELECT * from PACounty";

        //        cmd.CommandText = sql;
        //        cmd.Connection = conn;
        //        adapter.SelectCommand = cmd;
        //        adapter.Fill(dset);
        //        if (dset.Tables[0].Rows.Count > 0)
        //        {
        //            var success = true;

        //        }

        //    }
        //    catch (AdsException e)
        //    {
        //        // print the exception message
        //        Console.WriteLine(e.Message);
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            AddToStartup();
        }

        public void AddToStartup()
        {
            try
            {

                string startPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                if (!System.IO.File.Exists(Path.Combine(startPath, "MyShopCompInspectionSync.lnk")))
                {

                    //   System.IO.File.Copy(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\" + "MyShopCompInspectionSync.exe");

                    WshShell wsh = new WshShell();
                    IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\MyShopCompInspectionSync.lnk") as IWshRuntimeLibrary.IWshShortcut;
                    shortcut.Arguments = "";
                    shortcut.TargetPath = Application.ExecutablePath;// "c:\\app\\myftp.exe";
                                                                     // not sure about what this is for
                    shortcut.WindowStyle = 1;
                    shortcut.Description = "MyShopCompInspectionSync";
                    shortcut.WorkingDirectory = "C:\\";
                    //shortcut.IconLocation = "specify icon location";
                    shortcut.Save();
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                lblErrorMsg.Text = ex.Message;
            }
        }

        private void cmdSendData_Click(object sender, EventArgs e)
        {


            //  Helper.ResetAllControls(this);
            UpsertInvoice();


        }

        //private void BuidInsertStatement()
        //{

        //    string[] colNames = { "UserWorkOrder, InvoiceDate, InspectDate, Lastname, Firstname, VIN, InvoiceNumber, City, State, Zip, VehicleCounty, CountyCode, Plate, VehicleMake, VehicleBody, VehicleYear, " +
        //            "CurrentOdometer, OldOdometer,NAIC,InsuranceCompany,PolicyNo,InsuranceExpires,InvoiceType,RegCardVerified,Field1,Doors,BrakeSystem, Exhaust,Fuel,GlazingMirrors,Lighting,Other,RoadTest,Steering," +
        //            "};



        //    sql = "INSERT INTO Invoice (UserWorkOrder,InvoiceDate,InspectDate, Lastname, Firstname,VIN,InvoiceNumber,City, State, Zip,VehicleCounty,CountyCode, Plate,VehicleMake,VehicleBody, VehicleYear," +
        //      " CurrentOdometer, OldOdometer,NAIC,InsuranceCompany,PolicyNo,InsuranceExpires,InvoiceType,RegCardVerified,Field1,Doors," +
        //      "BrakeSystem, Exhaust,Fuel,GlazingMirrors,Lighting,Other,RoadTest,Steering," +
        //                 "BrakeLFBondRivet,BrakeLFThickness,BrakeLRBondRivet," +
        //      "BrakeLRThickness,BrakeRFBondRivet,BrakeRFThickness,BrakeRRBondRivet,BrakeRRThickness,TreadRightFront,TreadRightRear,TreadLeftFront,TreadLeftRear,InspectType," +
        //      "AirPump,CatalyticConverter,EGRvalve,EvaporativeControl,FuelInletRestrictor,PCVValve,PassInspection,StickerExpiresMonth,StickerExpiresYear,TreadLeftNR32,TreadLeft," +
        //      "Labor1,LaborTotalCost,Part1,Part1Cost,Part1Qty,Station_Id,StationInspectionCharge,CurrentYear,PartsTotalCost)  " +

        //      " VALUES (:UserWorkOrder,:InvoiceDate,:InspectDate,:Lastname, :FirstName, :VIN,:InvoiceNumber, :City, :State, :Zip,:VehicleCounty,:CountyCode, :Plate,:VehicleMake,:VehicleBody, :VehicleYear," +
        //      " :CurrentOdometer,:OldOdometer, :NAIC,:InsuranceCompany, :PolicyNo,:InsuranceExpires,:InvoiceType,:RegCardVerified,:Field1,:Doors," +
        //      ":BrakeSystem, :Exhaust,:Fuel,:GlazingMirrors,:Lighting,:Other,:RoadTest,:Steering," +
        //      ":BrakeLFBondRivet,:BrakeLFThickness,:BrakeLRBondRivet," +
        //      ":BrakeLRThickness,:BrakeRFBondRivet,:BrakeRFThickness,:BrakeRRBondRivet,:BrakeRRThickness,:TreadRightFront,:TreadRightRear,:TreadLeftFront,:TreadLeftRear,:InspectType," +
        //      "  :AirPump,:CatalyticConverter,:EGRvalve,:EvaporativeControl,:FuelInletRestrictor,:PCVValve,:PassInspection,:StickerExpiresMonth,:StickerExpiresYear,:TreadLeftNR32,:TreadLeft," +
        //      ":Labor1,:LaborTotalCost,:Part1,:Part1Cost,:Part1Qty,:Station_Id,:StationInspectionCharge,:CurrentYear,:PartsTotalCost)";
        //}


        private void UpsertInvoice()
        {
            CustVehInfo cust = LoadControlValueToObject();


            //  return;

            int InvoiceNumber = 0;
            // string lowestTireValue = string.Empty;
            // string lowestTireReading = string.Empty;



            try
            {
                conn.ConnectionString = Connectionstring;








                string sql = " SELECT top 10 * from Invoice WHERE VIN='" + cust.VIN + "' AND InspectDate='" + cust.InspectionDate + "'";

                string stickerMonth = string.Empty;
                string stickerYear = string.Empty;
                if (!String.IsNullOrEmpty(cust.StrickerMMYY) && cust.StrickerMMYY.Length == 4)
                {
                    stickerMonth = cust.StrickerMMYY.Substring(0, 2);
                    stickerYear = cust.StrickerMMYY.Substring(2, 2);
                }


                DataTable t1 = new DataTable();
                using (var a = new AdsDataAdapter(cmd))
                {
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    if (conn.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }

                    adapter.SelectCommand = cmd;
                    a.Fill(t1);
                }

                //sql = "DELETE FROM Invoice wHERE invoice_id > 1318";
                //cmd.CommandText = sql;
                //cmd.Connection = conn;
                //if (conn.State == ConnectionState.Closed)
                //{
                //    cmd.Connection.Open();
                //}

                //cmd.ExecuteNonQuery();

                //cmd.Connection.Close();



                if (t1.Rows.Count == 0) // insert a new invoice
                {
                    sql = "SELECT MAX(Invoice_Id) + 1 FROM Invoice";
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    if (conn.State == ConnectionState.Closed)
                    {
                        cmd.Connection.Open();
                    }


                    String x = cmd.ExecuteScalar().ToString();

                    if (x != null)
                    {
                        InvoiceNumber = Convert.ToInt32(x);
                    }
                    cmd.Connection.Close();




                    sql = "INSERT INTO Invoice (UserWorkOrder,InvoiceDate,InspectDate, Lastname, Firstname,VIN,InvoiceNumber,Address1,Address2,City, State, Zip,VehicleCounty,CountyCode," +
                            "Plate,VehicleMake,VehicleModel,VehicleBody, VehicleYear," +
                            " CurrentOdometer, OldOdometer,NAIC,InsuranceCompany,PolicyNo,InsuranceExpires,InvoiceType,RegCardVerified,Field1,Doors," +
                            "BrakeSystem, Exhaust,Fuel,GlazingMirrors,Lighting,Other,RoadTest,Steering," +
                            "BrakeLFBondRivet,BrakeLFThickness,BrakeLRBondRivet," +
                            "BrakeLRThickness,BrakeRFBondRivet,BrakeRFThickness,BrakeRRBondRivet,BrakeRRThickness,TreadRightFront,TreadRightRear,TreadLeftFront,TreadLeftRear,InspectType," +
                            "AirPump,CatalyticConverter,EGRvalve,EvaporativeControl,FuelInletRestrictor,PCVValve,PassInspection,StickerExpiresMonth,StickerExpiresYear,TreadLeftNR32,TreadLeft," +
                            "Labor1,LaborTotalCost,Part1,Part1Cost,Part1Qty,Station_Id,CurrentYear,PartsTotalCost," +
                            " InvoiceAmountInspection,BillingDate,EmissionStickerNumber,Region,Labor1Cost,Labor2Cost,Labor2,StateTaxRate,SubletInspection," +
                            "InspectBook,InsideOutSide,StationNumber,StickerReissued ,StickerDestroyed,StickerReplaced,Reconstructed,StickerLost,StickerStolen,StickerNeverReceived," +
                            " VisualAntiTamperRequired,OBDRequired,VisualRequired,GasCapRequired,TailpipeRequired,Labor1Inspection,Labor2Inspection,Part1Inspection," +
                            "SIRAttached,Part2Inspection,Part3Inspection,Part4Inspection,Part5Inspection,Part6Inspection,Part7Inspection,Part8Inspection,Part9Inspection," +
                            "Part10Inspection,Labor3Inspection,Labor4Inspection,Labor5Inspection,Labor6Inspection,Labor7Inspection,Labor8Inspection,Labor9Inspection,Labor10Inspection," +
                            "LockSIRInfo,Itemizeinvoice,Axles,Axle1Tires,FormName,StickerCost" +
                            ")  " +

                      " VALUES (:UserWorkOrder,:InvoiceDate,:InspectDate,:Lastname, :FirstName, :VIN,:InvoiceNumber,:Address1,:Address2, :City, :State, :Zip,:VehicleCounty,:CountyCode," +
                      ":Plate,:VehicleMake,:VehicleModel,:VehicleBody, :VehicleYear," +
                      " :CurrentOdometer,:OldOdometer, :NAIC,:InsuranceCompany, :PolicyNo,:InsuranceExpires,:InvoiceType,:RegCardVerified,:Field1,:Doors," +
                      ":BrakeSystem, :Exhaust,:Fuel,:GlazingMirrors,:Lighting,:Other,:RoadTest,:Steering," +
                      ":BrakeLFBondRivet,:BrakeLFThickness,:BrakeLRBondRivet," +
                      ":BrakeLRThickness,:BrakeRFBondRivet,:BrakeRFThickness,:BrakeRRBondRivet,:BrakeRRThickness,:TreadRightFront,:TreadRightRear,:TreadLeftFront,:TreadLeftRear,:InspectType," +
                      "  :AirPump,:CatalyticConverter,:EGRvalve,:EvaporativeControl,:FuelInletRestrictor,:PCVValve,:PassInspection,:StickerExpiresMonth,:StickerExpiresYear,:TreadLeftNR32,:TreadLeft," +
                      ":Labor1,:LaborTotalCost,:Part1,:Part1Cost,:Part1Qty,:Station_Id,:CurrentYear,:PartsTotalCost," +
                      ":InvoiceAmountInspection,:BillingDate,:EmissionStickerNumber,:Region,:Labor1Cost,:Labor2Cost,:Labor2,:StateTaxRate,:SubletInspection," +
                      ":InspectBook,:InsideOutSide,:StationNumber,:StickerReissued ,:StickerDestroyed,:StickerReplaced,:Reconstructed,:StickerLost,:StickerStolen,:StickerNeverReceived," +
                      ":VisualAntiTamperRequired,:OBDRequired,:VisualRequired,:GasCapRequired,:TailpipeRequired,:Labor1Inspection,:Labor2Inspection,:Part1Inspection," +
                      ":SIRAttached,:Part2Inspection,:Part3Inspection,:Part4Inspection,:Part5Inspection,:Part6Inspection,:Part7Inspection,:Part8Inspection,:Part9Inspection," +
                      ":Part10Inspection,:Labor3Inspection,:Labor4Inspection,:Labor5Inspection,:Labor6Inspection,:Labor7Inspection,:Labor8Inspection,:Labor9Inspection,:Labor10Inspection," +
                      ":LockSIRInfo,:Itemizeinvoice,:Axles,:Axle1Tires,:FormName,:StickerCost)";


                }
                else if (t1.Rows.Count == 1)
                {
                    InvoiceNumber = Convert.ToInt32(t1.Rows[0][0].ToString());
                    sql = "UPDATE Invoice SET UserWorkOrder=:UserWorkOrder,InspectDate=:InspectDate,FirstName = :FirstName, LastName=:LastName,Address1=:Address1,Address2=:Address2, City=:City, State=:State, Zip=:Zip," +
                                 " VehicleCounty=:VehicleCounty,CountyCode=:CountyCode, Plate=:Plate,VehicleMake=:VehicleMake,VehicleModel=:VehicleModel,VehicleBody=:VehicleBody, VehicleYear=:VehicleYear, " +
                                 "CurrentOdometer=:CurrentOdometer, NAIC=:NAIC,InsuranceCompany=:InsuranceCompany,PolicyNo=:PolicyNo,InsuranceExpires=:InsuranceExpires," +
                                 "InvoiceType=:InvoiceType,InspectType= :InspectType,InvoiceNumber=:InvoiceNumber,InvoiceDate=:InvoiceDate,VIN=:VIN,RegCardVerified=:RegCardVerified" +
                                 ", Field1=:Field1, Doors=:Doors,BrakeSystem=:BrakeSystem, Exhaust=:Exhaust,Fuel=:Fuel,GlazingMirrors=:GlazingMirrors,Lighting=:Lighting," +
                                 "Other=:Other,RoadTest=:RoadTest,Steering=:Steering,BrakeLFBondRivet=:BrakeLFBondRivet,BrakeLFThickness=:BrakeLFThickness,BrakeLRBondRivet=:BrakeLRBondRivet," +
                                 "BrakeLRThickness=:BrakeLRThickness,BrakeRFBondRivet=:BrakeRFBondRivet,BrakeRFThickness=:BrakeRFThickness,BrakeRRBondRivet=:BrakeRRBondRivet,BrakeRRThickness=:BrakeRRThickness," +
                                 "TreadRightFront=:TreadRightFront,TreadRightRear=:TreadRightRear,TreadLeftFront=:TreadLeftFront,TreadLeftRear=:TreadLeftRear, " +
                                 " AirPump=:AirPump,CatalyticConverter=:CatalyticConverter,EGRvalve=:EGRvalve,EvaporativeControl=:EvaporativeControl,FuelInletRestrictor=:FuelInletRestrictor,PCVValve=:PCVValve" +
                                 ", PassInspection=:PassInspection,OldOdometer=:OldOdometer,StickerExpiresMonth=:StickerExpiresMonth,StickerExpiresYear=:StickerExpiresYear" +
                                 ",TreadLeftNR32=:TreadLeftNR32,TreadLeft=:TreadLeft,Labor1=:Labor1,LaborTotalCost=:LaborTotalCost,Part1=:Part1,Part1Cost=:Part1Cost,Part1Qty=:Part1Qty," +
                                 " Station_Id=:Station_Id,CurrentYear=:CurrentYear,PartsTotalCost=:PartsTotalCost," +
                                 "InvoiceAmountInspection=:InvoiceAmountInspection,BillingDate=:BillingDate," +
                                 "EmissionStickerNumber=:EmissionStickerNumber,Region=:Region,Labor1Cost=:Labor1Cost,Labor2Cost=:Labor2Cost,Labor2=:Labor2," +
                                 "StateTaxRate=:StateTaxRate,SubletInspection=:SubletInspection,InspectBook=:InspectBook,InsideOutSide=:InsideOutSide,StationNumber=:StationNumber," +
                                 "StickerReissued =:StickerReissued ,StickerDestroyed=:StickerDestroyed,StickerReplaced=:StickerReplaced,Reconstructed=:Reconstructed," +
                                 "StickerLost =:StickerLost, StickerStolen=:StickerStolen,StickerNeverReceived=:StickerNeverReceived,VisualAntiTamperRequired=:VisualAntiTamperRequired, " +
                                 "OBDRequired=:OBDRequired,VisualRequired=:VisualRequired,GasCapRequired=:GasCapRequired,TailpipeRequired=:TailpipeRequired, " +
                                 "Labor1Inspection =:Labor1Inspection,Labor2Inspection=:Labor2Inspection,Part1Inspection=:Part1Inspection," +
                                 "SIRAttached =:SIRAttached,Part2Inspection =:Part2Inspection,Part3Inspection =:Part3Inspection,Part4Inspection =:Part4Inspection," +
                                "Part5Inspection =:Part5Inspection,Part6Inspection =:Part6Inspection,Part7Inspection =:Part7Inspection,Part8Inspection =:Part8Inspection,Part9Inspection =:Part9Inspection,Part10Inspection =:Part10Inspection," +
                                "Labor3Inspection =:Labor3Inspection,Labor4Inspection =:Labor4Inspection,Labor5Inspection =:Labor5Inspection,Labor6Inspection =:Labor6Inspection,Labor7Inspection =:Labor7Inspection,Labor8Inspection =:Labor8Inspection," +
                                "Labor9Inspection =:Labor9Inspection,Labor10Inspection =:Labor10Inspection,LockSIRInfo =:LockSIRInfo,Itemizeinvoice =:Itemizeinvoice,Axles =:Axles,Axle1Tires =:Axle1Tires" +
                                ",FormName=:FormName,StickerCost=:StickerCost" +
                             " WHERE VIN='" + cust.VIN + "'";



                }
                else
                {
                    return;
                }

                using (AdsConnection cn = new AdsConnection(Connectionstring))
                {
                    using (var cmd = new AdsCommand(sql, cn))
                    {
                        // define parameters and their values
                        cmd.Parameters.Add("InspectDate", cust.InspectionDate);
                        cmd.Parameters.Add("UserWorkOrder", cust.WorkOrder);
                        cmd.Parameters.Add("InvoiceType", "SI");
                        cmd.Parameters.Add("InspectType", "ANNUAL");
                        cmd.Parameters.Add("InvoiceNumber", InvoiceNumber);
                        cmd.Parameters.Add("InvoiceDate", cust.InspectionDate);
                        cmd.Parameters.Add("VIN", cust.VIN);
                        cmd.Parameters.Add("FirstName", cust.FirstName);
                        cmd.Parameters.Add("LastName", cust.LastName);
                        cmd.Parameters.Add("City", cust.City);
                        cmd.Parameters.Add("Address1", cust.Address1);
                        cmd.Parameters.Add("Address2", cust.Address2);
                        cmd.Parameters.Add("State", cust.State);
                        cmd.Parameters.Add("Zip", cust.Zip);
                        cmd.Parameters.Add("VehicleCounty", cust.County);
                        cmd.Parameters.Add("CountyCode", cust.CountyCode);
                        cmd.Parameters.Add("Region", cust.Region);

                        cmd.Parameters.Add("Plate", cust.Plate);
                        cmd.Parameters.Add("VehicleMake", cust.VehicleMake);
                        cmd.Parameters.Add("VehicleModel", cust.VehicleModel);
                        cmd.Parameters.Add("VehicleBody", cust.Body);
                        cmd.Parameters.Add("VehicleYear", cust.Year);
                        cmd.Parameters.Add("CurrentOdometer", cust.CurrOdo);
                        cmd.Parameters.Add("OldOdometer", cust.PrevOdo);

                        cmd.Parameters.Add("Station_Id", cust.Station_Id);

                        //cmd.Parameters.Add("VehicleYear", cust.Year);
                        //  cmd.Parameters.Add("CurrentOdometer", cust.CurrOdo);


                        cmd.Parameters.Add("NAIC", cust.Naic);
                        cmd.Parameters.Add("InsuranceCompany", cust.InsCpy);
                        cmd.Parameters.Add("PolicyNo", cust.Policy);
                        cmd.Parameters.Add("InsuranceExpires", cust.ExpDate);


                        cmd.Parameters.Add("RegCardVerified", cust.InspectionInfo.RegVerified);
                        cmd.Parameters.Add("Field1", cust.InspectionInfo.Tires);
                        cmd.Parameters.Add("Doors", cust.InspectionInfo.Body);

                        cmd.Parameters.Add("BrakeSystem", cust.InspectionInfo.Break);
                        cmd.Parameters.Add("Exhaust", cust.InspectionInfo.Exhaust);
                        cmd.Parameters.Add("Fuel", cust.InspectionInfo.Fuel);
                        cmd.Parameters.Add("GlazingMirrors", cust.InspectionInfo.Glazing);
                        cmd.Parameters.Add("Lighting", cust.InspectionInfo.Lights);
                        cmd.Parameters.Add("Other", cust.InspectionInfo.Other);
                        cmd.Parameters.Add("RoadTest", cust.InspectionInfo.RoadTest);
                        cmd.Parameters.Add("Steering", cust.InspectionInfo.Streering);


                        cmd.Parameters.Add("BrakeLFBondRivet", cust.Brakes.LFBrakeBondRivet);
                        cmd.Parameters.Add("BrakeLFThickness", cust.Brakes.BrakeLFThickness);
                        cmd.Parameters.Add("BrakeLRBondRivet", cust.Brakes.LRBrakeBondRivet);
                        cmd.Parameters.Add("BrakeLRThickness", cust.Brakes.BrakeLRThickness);
                        cmd.Parameters.Add("BrakeRFBondRivet", cust.Brakes.RFBrakeBondRivet);
                        cmd.Parameters.Add("BrakeRFThickness", cust.Brakes.BrakeRFThickness);
                        cmd.Parameters.Add("BrakeRRBondRivet", cust.Brakes.RRBrakeBondRivet);
                        cmd.Parameters.Add("BrakeRRThickness", cust.Brakes.BrakeRRThickness);


                        cmd.Parameters.Add("TreadRightFront", cust.Tires.TireRightFront);
                        cmd.Parameters.Add("TreadRightRear", cust.Tires.TireRightRear);
                        cmd.Parameters.Add("TreadLeftFront", cust.Tires.TireLeftFront);
                        cmd.Parameters.Add("TreadLeftRear", cust.Tires.TireLeftRear);

                        cmd.Parameters.Add("TreadLeftNR32", cust.Tires.LowestTireSide);
                        cmd.Parameters.Add("TreadLeft", cust.Tires.LowestTireReading);



                        cmd.Parameters.Add("AirPump", cust.VisualAnti.AIRPump);
                        cmd.Parameters.Add("CatalyticConverter", cust.VisualAnti.CatalyticConverter);
                        cmd.Parameters.Add("EGRvalve", cust.VisualAnti.ERG);
                        cmd.Parameters.Add("EvaporativeControl", cust.VisualAnti.EvaporativeControl);
                        cmd.Parameters.Add("FuelInletRestrictor", cust.VisualAnti.FuelInlet);
                        cmd.Parameters.Add("PCVValve", cust.VisualAnti.PCV);

                        cmd.Parameters.Add("PassInspection", cust.InspectionInfo.PassInspection);

                        var laborTotal = 0.0;

                        if (!String.IsNullOrEmpty(cust.InspectionCost))
                        {
                            laborTotal = Convert.ToDouble(cust.InspectionCost);
                        }

                        if (!String.IsNullOrEmpty(cust.TotalCost))
                        {
                            laborTotal += Convert.ToDouble(cust.TotalCost);
                        }


                        cmd.Parameters.Add("StickerExpiresMonth", stickerMonth);
                        cmd.Parameters.Add("StickerExpiresYear", stickerYear);

                        cmd.Parameters.Add("Labor1", "STATE INSPECTION  431 ANNUAL IN");
                        cmd.Parameters.Add("Labor1Cost", cust.InspectionCost);

                        cmd.Parameters.Add("Labor2", "OTHER CHARGES");
                        cmd.Parameters.Add("Labor2Cost", cust.TotalCost);

                        cmd.Parameters.Add("LaborTotalCost", laborTotal);

                        // cmd.Parameters.Add("StationInspectionCharge", "00"); //  remove hardcoding

                        cmd.Parameters.Add("CurrentYear", DateTime.Now.Year.ToString());


                        cmd.Parameters.Add("Part1", "STATE INSPECTION  431 ANNUAL IN");
                        cmd.Parameters.Add("Part1Cost", cust.StickerCharge); // remove hardcoding
                        cmd.Parameters.Add("Part1Qty", "1");

                        cmd.Parameters.Add("PartsTotalCost", cust.StickerCharge); // remove hardcoding


                        //cmd.Parameters.Add("LaborTotalCostInspection", "00"); //  remove hardcoding
                        //cmd.Parameters.Add("PartsTotalCostInspection", "0"); //  remove hardcoding
                        //cmd.Parameters.Add("TotalLaborPartsInspection", "00"); //  remove hardcoding
                        // cmd.Parameters.Add("TaxAmountInspection", ("0").ToString()); //  remove hardcoding


                        var inspCost = (Convert.ToDouble(cust.StickerCharge) + Convert.ToDouble(cust.TotalCost) + laborTotal) * 1.07;

                        cmd.Parameters.Add("InvoiceAmountInspection", inspCost);

                        cmd.Parameters.Add("SubletInspection", "0");

                        cmd.Parameters.Add("BillingDate", cust.InspectionDate);
                        cmd.Parameters.Add("EmissionStickerNumber", cust.EmissonNum);

                        cmd.Parameters.Add("StateTaxRate", "0.07");


                        cmd.Parameters.Add("InspectType", "ANNUAL");
                        cmd.Parameters.Add("InspectBook", "431AI");
                        cmd.Parameters.Add("InsideOutSide", "INSIDE");
                        cmd.Parameters.Add("StationNumber", "DW17");

                        cmd.Parameters.Add("StickerReissued", "N");
                        cmd.Parameters.Add("StickerDestroyed", "N");
                        cmd.Parameters.Add("StickerReplaced", "N");
                        cmd.Parameters.Add("Reconstructed", "N");
                        cmd.Parameters.Add("StickerLost", "N");
                        cmd.Parameters.Add("StickerStolen", "N");
                        cmd.Parameters.Add("StickerNeverReceived", "N");


                        cmd.Parameters.Add("Labor1Inspection", "Y");
                        cmd.Parameters.Add("Labor2Inspection", "Y");
                        cmd.Parameters.Add("Part1Inspection", "Y");


                        if (cust.Region == "PIT")
                        {
                            cmd.Parameters.Add("VisualAntiTamperRequired", "N");

                            cmd.Parameters.Add("OBDRequired", "N");
                            cmd.Parameters.Add("VisualRequired", "N");
                            cmd.Parameters.Add("GasCapRequired", "N");
                            cmd.Parameters.Add("TailpipeRequired", "N");


                            cmd.Parameters.Add("CatalyticConverter", "-");
                            cmd.Parameters.Add("EGRvalve", "-");
                            cmd.Parameters.Add("EvaporativeControl", "-");
                            cmd.Parameters.Add("FuelInletRestrictor", "-");
                            cmd.Parameters.Add("PCVValve", "-");
                            cmd.Parameters.Add("AirPump", "-");


                        }
                        else
                        {
                            cmd.Parameters.Add("VisualAntiTamperRequired", "Y");
                            cmd.Parameters.Add("OBDRequired", "Y");
                            cmd.Parameters.Add("VisualRequired", "Y");
                            cmd.Parameters.Add("GasCapRequired", "Y");
                            cmd.Parameters.Add("TailpipeRequired", "Y");
                        }



                        cmd.Parameters.Add("SIRAttached", "");
                        
                        cmd.Parameters.Add("Part2Inspection", "N");
                        cmd.Parameters.Add("Part3Inspection", "N");
                        cmd.Parameters.Add("Part4Inspection", "N");
                        cmd.Parameters.Add("Part5Inspection", "N");
                        cmd.Parameters.Add("Part6Inspection", "N");
                        cmd.Parameters.Add("Part7Inspection", "N");
                        cmd.Parameters.Add("Part8Inspection", "N");
                        cmd.Parameters.Add("Part9Inspection", "N");
                        cmd.Parameters.Add("Part10Inspection", "N");
                        cmd.Parameters.Add("Labor3Inspection", "N");
                        cmd.Parameters.Add("Labor4Inspection", "N");
                        cmd.Parameters.Add("Labor5Inspection", "N");
                        cmd.Parameters.Add("Labor6Inspection", "N");
                        cmd.Parameters.Add("Labor7Inspection", "N");
                        cmd.Parameters.Add("Labor8Inspection", "N");
                        cmd.Parameters.Add("Labor9Inspection", "N");
                        cmd.Parameters.Add("Labor10Inspection", "N");
                        cmd.Parameters.Add("LockSIRInfo", "Y");
                        cmd.Parameters.Add("Itemizeinvoice", "N");
                        cmd.Parameters.Add("Axles", "1");
                        cmd.Parameters.Add("Axle1Tires", "2");


                        cmd.Parameters.Add("FormName", "431(12-03)");
                        cmd.Parameters.Add("StickerCost", cust.StickerCharge);

                        



                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }



                }

                lblErrorMsg.Text = "Data send Successfully ... :-)";

                var res1 = ATP.Common.ProxyHelper.Service<ICompInspection>.Use(svcs =>
                {
                    return svcs.UpdtExportToCompInspectionStatus(cust.Id, dealerId, null, null);
                });


            }
            catch (AdsException ads)
            {
                if (ads.Number == 5035)
                {
                    lblErrorMsg.Text = "SIR IN EDIT MODE. Pls close......";
                }
                else
                {
                    lblErrorMsg.Text = ads.Message;
                    var res1 = ATP.Common.ProxyHelper.Service<ICompInspection>.Use(svcs =>
                    {
                        return svcs.UpdtExportToCompInspectionStatus(cust.Id, dealerId, true, ads.StackTrace);
                    });
                }
            }
            catch (Exception ex)
            {
                // print the exception message
                //MessageBox.Show(e.Message);
                lblErrorMsg.Text = ex.Message;
                var res1 = ATP.Common.ProxyHelper.Service<ICompInspection>.Use(svcs =>
                {
                    return svcs.UpdtExportToCompInspectionStatus(cust.Id, dealerId, true, ex.StackTrace);
                });
            }

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }



        private void cmdPullMyShopAuto_Click(object sender, EventArgs e)
        {
            Helper.ResetAllControls(this);
            SelectAllCYADataFromWeb();

        }

        private void txtLRTReading_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRegistrationVerified_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdClearAll_Click(object sender, EventArgs e)
        {
            Helper.ResetAllControls(this);
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {


        }
    }



}

public class TireMinValue
{

    public TireMinValue(string ky, string val)
    {
        Key = ky;
        Value = val;
    }

    public string Key { get; set; }
    public string Value { get; set; }
}


public class CustVehInfo
{
    public long? Id { get; set; }

    public Guid VehicleServiceGuid { get; set; }
    public string WorkOrder { get; set; }
    public string InspectionDate { get; set; }
    public string StrickerMMYY { get; set; }

    public string MechanicName { get; set; }
    public string MechanicLic { get; set; }

    public string Station_Id { get; set; }

    public string InspectionCost { get; set; }
    public string StickerCharge { get; set; }
    public string EmissonNum { get; set; }
    public string TotalCost { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string County { get; set; }
    public string CountyCode { get; set; }
    public string Region { get; set; }

    public string VIN { get; set; }
    public string Plate { get; set; }
    public string Year { get; set; }
    public string VehicleMake { get; set; }
    public string VehicleModel { get; set; }
    public string Body { get; set; }
    public string CurrOdo { get; set; }
    public string PrevOdo { get; set; }

    public string Naic { get; set; }
    public string InsCpy { get; set; }
    public string Policy { get; set; }
    public string ExpDate { get; set; }




    public InspectionInfo InspectionInfo { get; set; }
    public Brakes Brakes { get; set; }
    public Tires Tires { get; set; }
    public VisualAnti VisualAnti { get; set; }

}

public class InspectionInfo
{
    public object this[string propertyName] {
        get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
        set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
    }
    public string RegVerified { get; set; }
    public string Tires { get; set; }
    public string Streering { get; set; }
    public string Exhaust { get; set; }
    public string Fuel { get; set; }
    public string Glazing { get; set; }
    public string Lights { get; set; }
    public string Body { get; set; }
    public string Break { get; set; }
    public string Other { get; set; }
    public string RoadTest { get; set; }
    public string PassInspection { get; set; }
}

public class Brakes
{
    public string BrakeLFThickness { get; set; }
    public string BrakeLRThickness { get; set; }
    public string BrakeRFThickness { get; set; }
    public string BrakeRRThickness { get; set; }

    public string LFBrakeBondRivet { get; set; }
    public string RFBrakeBondRivet { get; set; }
    public string LRBrakeBondRivet { get; set; }
    public string RRBrakeBondRivet { get; set; }



}

public class Tires
{
    public string TireRightFront { get; set; }
    public string TireRightRear { get; set; }
    public string TireLeftFront { get; set; }
    public string TireLeftRear { get; set; }
    public string LowestTireReading { get; set; }
    public string LowestTireSide { get; set; }
}

public class VisualAnti
{
    public string CatalyticConverter { get; set; }
    public string FuelInlet { get; set; }
    public string PCV { get; set; }
    public string ERG { get; set; }
    public string AIRPump { get; set; }
    public string EvaporativeControl { get; set; }

}
