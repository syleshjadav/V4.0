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
using MyShopCompInspectionSync.MyShopProxy;

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

    public Form1()
    {
      InitializeComponent();


      Connectionstring = MyShopCompInspectionSync.Properties.Settings.Default.ConnectionString;

      servicePollInterval = MyShopCompInspectionSync.Properties.Settings.Default.ServicePollInterval;
      dealerId = MyShopCompInspectionSync.Properties.Settings.Default.DealerId;

      counter = servicePollInterval;
      lblCountDown.Text = counter.ToString();

      conn.ConnectionString = Connectionstring;
      //  conn.Open();

      //SelectAllCounties();

      // UpsertCustomer();
      DateTime thisDay = DateTime.Today;
      txtInspectionDate.Text = thisDay.ToString("d");

      if (conn.State == ConnectionState.Open)
      {
        conn.Close();
      }

    }

    private void UpsertCustomer()
    {
      CustVehInfo cust = LoadControlValueToObject();



      //cust.InspectionInfo = inspInfo;
      //cust.Brakes = brakes;
      //cust.Tires = tires;


      try
      {

        string sql = " SELECT top 10 * from CustomerVehicle WHERE VIN='" + cust.VIN + "'";

        cmd.CommandText = sql;
        cmd.Connection = conn;
        adapter.SelectCommand = cmd;
        adapter.Fill(dset);


        if (dset.Tables[0].Rows.Count == 0) // insert a new customer
        {
          sql = "INSERT INTO CustomerVehicle (FirstName, Lastname, VIN)  VALUES (:FirstName, :Lastname, :VIN) ";
        }
        else if (dset.Tables[0].Rows.Count == 1)
        {

          sql = "UPDATE CustomerVehicle SET FirstName = :FirstName, LastName=:LastName, City=:City, State=:State, Zip=:Zip," +
                       " VehicleCounty=:VehicleCounty,CountyCode=:CountyCode, Plate=:Plate,VehicleMake=:VehicleMake,VehicleBody=:VehicleBody, VehicleYear=:VehicleYear, " +
                       "Odometer=:Odometer, NAIC=:NAIC,InsuranceCompany=:InsuranceCompany,PolicyNumber=:PolicyNumber,InsuranceExpires=:InsuranceExpires" +
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

            cmd.Parameters.Add("FirstName", cust.FirstName);
            cmd.Parameters.Add("LastName", cust.LastName);
            cmd.Parameters.Add("City", cust.City);
            cmd.Parameters.Add("State", cust.State);
            cmd.Parameters.Add("Zip", cust.Zip);
            cmd.Parameters.Add("VehicleCounty", cust.County);
            cmd.Parameters.Add("CountyCode", cust.CountyCode);

            cmd.Parameters.Add("Plate", cust.Plate);
            cmd.Parameters.Add("VehicleMake", cust.VehicleMake);
            cmd.Parameters.Add("VehicleBody", cust.Body);
            cmd.Parameters.Add("VehicleYear", cust.Year);
            cmd.Parameters.Add("Odometer", cust.CurrOdo);

            cmd.Parameters.Add("VehicleBody", cust.Body);
            cmd.Parameters.Add("VehicleYear", cust.Year);
            cmd.Parameters.Add("Odometer", cust.CurrOdo);


            cmd.Parameters.Add("NAIC", cust.Naic);
            cmd.Parameters.Add("InsuranceCompany", cust.InsCpy);
            cmd.Parameters.Add("PolicyNumber", cust.Policy);
            cmd.Parameters.Add("InsuranceExpires", cust.ExpDate);

            /*
            cmd.Parameters.Add("NAIC", inspInfo.Body);
            cmd.Parameters.Add("NAIC", inspInfo.Break);
            cmd.Parameters.Add("Exhaust", inspInfo.Exhaust);
            cmd.Parameters.Add("NAIC", inspInfo.Fuel);
            cmd.Parameters.Add("GlazingMirrors", inspInfo.Glazing);
            cmd.Parameters.Add("Lighting", inspInfo.Lights);
            cmd.Parameters.Add("Other", inspInfo.Other);
            cmd.Parameters.Add("NAIC", inspInfo.RegVerified);
            cmd.Parameters.Add("NAIC", inspInfo.RoadTest);
            cmd.Parameters.Add("Streering", inspInfo.Streering);
            cmd.Parameters.Add("NAIC", inspInfo.Tires);
            */



            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
          }





        }

      }
      catch (AdsException e)
      {
        // print the exception message
        Console.WriteLine(e.Message);
      }
    }

    private CustVehInfo LoadControlValueToObject()
    {
      var cust = new CustVehInfo
      {
        FirstName = txtFirstName.Text,
        LastName = txtLastName.Text,
        City = txtCity.Text,
        State = txtState.Text,
        Zip = txtZip.Text,
        CountyCode = txtCountyCode.Text,
        County = txtCounty.Text,
        VIN = txtVin.Text,
        Plate = txtPlate.Text,
        Year = txtYear.Text,
        VehicleMake = txtMake.Text,
        Body = txtBody.Text,
        CurrOdo = txtCurrOdo.Text,
        PrevOdo = txtOldOdo.Text,
        Naic = txtNaic.Text,
        ExpDate = txtExpDt.Text,
        Policy = txtPolicy.Text,
        InspectionDate = txtInspectionDate.Text,
        EmissonNum=txtEmissionNum.Text,
        StrickerMMYY = txtStickerMMYY.Text
       
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

        BrakeFrontBondRivet = txtLFBCondition.Text,
        //BrakeLRBondRivet = txtLRBCondition.Text,
        BrakeRearBondRivet = txtRFBCondition.Text,
        //BrakeRRBondRivet = txtRRBCondition.Text,


      };
      var tires = new Tires
      {
        TireRightFront = txtRFTReading.Text,
        TireRightRear = txtRRTReading.Text,
        TireLeftFront = txtLFTReading.Text,
        TireLeftRear = txtLRTReading.Text,
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





      return cust;
    }

    private void LoadObjectToControlValue()
    {

      txtFirstName.Text = CustomerInfo.FirstName;
      txtLastName.Text = CustomerInfo.LastName;
      txtCity.Text = CustomerInfo.City;
      txtState.Text = CustomerInfo.State;
      txtZip.Text = CustomerInfo.Zip;
      txtCountyCode.Text = CustomerInfo.CountyCode;
      txtCounty.Text = CustomerInfo.County;
      txtVin.Text = CustomerInfo.VIN;
      txtPlate.Text = CustomerInfo.Plate;
      txtYear.Text = CustomerInfo.Year;
      txtMake.Text = CustomerInfo.VehicleMake;
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
      txtVehicleServiceGuid.Text = CustomerInfo.VehicleServiceGuid;


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

      txtLFBCondition.Text = CustomerInfo.Brakes.BrakeFrontBondRivet;

      txtRFBCondition.Text = CustomerInfo.Brakes.BrakeRearBondRivet;

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
      if (counter == 0)
      {
        timer1.Stop();

        if (MyShopCompInspectionSync.Properties.Settings.Default.IsShowForm == false)
        {
          this.Visible = false;
        }
        SelectAllCYADataFromWeb();
      }

      timer1.Start();

    }

    private void SelectAllCYADataFromWeb()
    {
      try
      {
        Helper.ResetAllControls(this);


        var res1 = ATP.Common.ProxyHelper.Service<ICompInspection>.Use(svcs =>
        {
          return svcs.SelAllCompInspectionExportData(dealerId);
        });
        MapMyShopDataToObject(res1);
        counter = servicePollInterval;

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
          VehicleServiceGuid= d.VehicleServiceGuid.ToString(),
          Body = d.VehBodyType,
          County = d.VehicleCounty,
          City = d.City,
          CurrOdo = d.MilesOut == null ? null : d.MilesOut.ToString(),
          ExpDate = d.InsuranceExpDate == null ? null : d.InsuranceExpDate.ToString(),
          FirstName = d.FirstName,
          InsCpy = d.InsuranceCompanyName,
          InspectionCost = d.InspectionCharge,
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
          VIN = d.VIN,
          WorkOrder = d.WorkOrder,
          StrickerMMYY= d.SafetyStickerYYMM,
          Year = d.VehicleYear,
          Zip = d.ZipCode,
          Brakes = new Brakes
          {
            BrakeFrontBondRivet = d.BrakeTypeFront,
            BrakeRearBondRivet = d.BrakeTypeRear,

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
            Body = d.Doors,
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

    }

    private void cmdSendData_Click(object sender, EventArgs e)
    {


      //UpsertCustomer();
      UpsertInvoice();

      MessageBox.Show("Data Send...Successfully ...:-)");

    }



    private void UpsertInvoice()
    {
      CustVehInfo cust = LoadControlValueToObject();

      int InvoiceNumber = 0;


      try
      {

        string sql = " SELECT top 10 * from Invoice WHERE VIN='" + cust.VIN + "' AND InvoiceDate='03/04/2017'";




        // AdsCommand cmd = new AdsCommand(sql, conn);

        DataTable t1 = new DataTable();
        using (var a = new AdsDataAdapter(cmd))
        {
          cmd.CommandText = sql;
          cmd.Connection = conn;
          adapter.SelectCommand = cmd;
          a.Fill(t1);
        }





        if (t1.Rows.Count == 0) // insert a new invoice
        {
          sql = "SELECT MAX(Invoice_Id) + 1 FROM Invoice";
          cmd.CommandText = sql;
          cmd.Connection = conn;
          cmd.Connection.Open();
          // adapter.SelectCommand = cmd;
          String x = cmd.ExecuteScalar().ToString();

          if (x != null)
          {
            InvoiceNumber = Convert.ToInt32(x);
          }
          cmd.Connection.Close();
          sql = "INSERT INTO Invoice (UserWorkOrder,InvoiceDate,InspectDate, Lastname, Firstname,VIN,InvoiceNumber,City, State, Zip,VehicleCounty,CountyCode, Plate,VehicleMake,VehicleBody, VehicleYear," +
            " CurrentOdometer, OldOdometer,NAIC,InsuranceCompany,PolicyNo,InsuranceExpires,InvoiceType,RegCardVerified,Field1,Doors," +
            "BrakeSystem, Exhaust,Fuel,GlazingMirrors,Lighting,Other,RoadTest,Steering," +
                       "BrakeLFBondRivet,BrakeLFThickness,BrakeLRBondRivet," +
            "BrakeLRThickness,BrakeRFBondRivet,BrakeRFThickness,BrakeRRBondRivet,BrakeRRThickness,TreadRightFront,TreadRightRear,TreadLeftFront,TreadLeftRear,InspectType," +
            "AirPump,CatalyticConverter,EGRvalve,EvaporativeControl,FuelInletRestrictor,PCVValve,PassInspection)  " +

            " VALUES (:UserWorkOrder,:InvoiceDate,:InspectDate,:Lastname, :FirstName, :VIN,:InvoiceNumber, :City, :State, :Zip,:VehicleCounty,:CountyCode, :Plate,:VehicleMake,:VehicleBody, :VehicleYear," +
            " :CurrentOdometer,:OldOdometer, :NAIC,:InsuranceCompany, :PolicyNo,:InsuranceExpires,:InvoiceType,:RegCardVerified,:Field1,:Doors," +
            ":BrakeSystem, :Exhaust,:Fuel,:GlazingMirrors,:Lighting,:Other,:RoadTest,:Steering," +
            ":BrakeLFBondRivet,:BrakeLFThickness,:BrakeLRBondRivet," +
            ":BrakeLRThickness,:BrakeRFBondRivet,:BrakeRFThickness,:BrakeRRBondRivet,:BrakeRRThickness,:TreadRightFront,:TreadRightRear,:TreadLeftFront,:TreadLeftRear,:InspectType," +
            "  :AirPump,:CatalyticConverter,:EGRvalve,:EvaporativeControl,:FuelInletRestrictor,:PCVValve,:PassInspection)";




        }
        else if (t1.Rows.Count == 1)
        {
          InvoiceNumber = Convert.ToInt32(t1.Rows[0][0].ToString());
          sql = "UPDATE Invoice SET UserWorkOrder=:UserWorkOrder,InspectDate=:InspectDate,FirstName = :FirstName, LastName=:LastName, City=:City, State=:State, Zip=:Zip," +
                       " VehicleCounty=:VehicleCounty,CountyCode=:CountyCode, Plate=:Plate,VehicleMake=:VehicleMake,VehicleBody=:VehicleBody, VehicleYear=:VehicleYear, " +
                       "CurrentOdometer=:CurrentOdometer, NAIC=:NAIC,InsuranceCompany=:InsuranceCompany,PolicyNo=:PolicyNo,InsuranceExpires=:InsuranceExpires," +
                       "InvoiceType=:InvoiceType,InspectType= :InspectType,InvoiceNumber=:InvoiceNumber,InvoiceDate=:InvoiceDate,VIN=:VIN,RegCardVerified=:RegCardVerified" +
                       ", Field1=:Field1, Doors=:Doors,BrakeSystem=:BrakeSystem, Exhaust=:Exhaust,Fuel=:Fuel,GlazingMirrors=:GlazingMirrors,Lighting=:Lighting," +
                       "Other=:Other,RoadTest=:RoadTest,Steering=:Steering,BrakeLFBondRivet=:BrakeLFBondRivet,BrakeLFThickness=:BrakeLFThickness,BrakeLRBondRivet=:BrakeLRBondRivet," +
                       "BrakeLRThickness=:BrakeLRThickness,BrakeRFBondRivet=:BrakeRFBondRivet,BrakeRFThickness=:BrakeRFThickness,BrakeRRBondRivet=:BrakeRRBondRivet,BrakeRRThickness=:BrakeRRThickness," +
                       "TreadRightFront=:TreadRightFront,TreadRightRear=:TreadRightRear,TreadLeftFront=:TreadLeftFront,TreadLeftRear=:TreadLeftRear, " +
                       " AirPump=:AirPump,CatalyticConverter=:CatalyticConverter,EGRvalve=:EGRvalve,EvaporativeControl=:EvaporativeControl,FuelInletRestrictor=:FuelInletRestrictor,PCVValve=:PCVValve" +
                       ", PassInspection=:PassInspection,OldOdometer=:OldOdometer" +
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
            cmd.Parameters.Add("UserWorkOrder", InvoiceNumber);
            cmd.Parameters.Add("InvoiceType", "SI");
            cmd.Parameters.Add("InspectType", "ANNUAL");
            cmd.Parameters.Add("InvoiceNumber", InvoiceNumber);
            cmd.Parameters.Add("InvoiceDate", "03/04/2017");
            cmd.Parameters.Add("VIN", cust.VIN);
            cmd.Parameters.Add("FirstName", cust.FirstName);
            cmd.Parameters.Add("LastName", cust.LastName);
            cmd.Parameters.Add("City", cust.City);
            cmd.Parameters.Add("State", cust.State);
            cmd.Parameters.Add("Zip", cust.Zip);
            cmd.Parameters.Add("VehicleCounty", cust.County);
            cmd.Parameters.Add("CountyCode", cust.CountyCode);

            cmd.Parameters.Add("Plate", cust.Plate);
            cmd.Parameters.Add("VehicleMake", cust.VehicleMake);
            cmd.Parameters.Add("VehicleBody", cust.Body);
            cmd.Parameters.Add("VehicleYear", cust.Year);
            cmd.Parameters.Add("CurrentOdometer", cust.CurrOdo);
            cmd.Parameters.Add("OldOdometer", cust.PrevOdo);

            //cmd.Parameters.Add("VehicleBody", cust.Body);
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


            cmd.Parameters.Add("BrakeLFBondRivet", cust.Brakes.BrakeFrontBondRivet);
            cmd.Parameters.Add("BrakeLFThickness", cust.Brakes.BrakeLFThickness);
            cmd.Parameters.Add("BrakeLRBondRivet", cust.Brakes.BrakeFrontBondRivet);
            cmd.Parameters.Add("BrakeLRThickness", cust.Brakes.BrakeLRThickness);
            cmd.Parameters.Add("BrakeRFBondRivet", cust.Brakes.BrakeRearBondRivet);
            cmd.Parameters.Add("BrakeRFThickness", cust.Brakes.BrakeRFThickness);
            cmd.Parameters.Add("BrakeRRBondRivet", cust.Brakes.BrakeRearBondRivet);
            cmd.Parameters.Add("BrakeRRThickness", cust.Brakes.BrakeRRThickness);


            cmd.Parameters.Add("TreadRightFront", cust.Tires.TireRightFront);
            cmd.Parameters.Add("TreadRightRear", cust.Tires.TireRightRear);
            cmd.Parameters.Add("TreadLeftFront", cust.Tires.TireLeftFront);
            cmd.Parameters.Add("TreadLeftRear", cust.Tires.TireLeftRear);

            cmd.Parameters.Add("AirPump", cust.VisualAnti.AIRPump);
            cmd.Parameters.Add("CatalyticConverter", cust.VisualAnti.CatalyticConverter);
            cmd.Parameters.Add("EGRvalve", cust.VisualAnti.ERG);
            cmd.Parameters.Add("EvaporativeControl", cust.VisualAnti.EvaporativeControl);
            cmd.Parameters.Add("FuelInletRestrictor", cust.VisualAnti.FuelInlet);
            cmd.Parameters.Add("PCVValve", cust.VisualAnti.PCV);

            cmd.Parameters.Add("PassInspection", cust.InspectionInfo.PassInspection);







            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
          }





        }

      }
      catch (AdsException e)
      {
        // print the exception message
        MessageBox.Show(e.Message);
      }
    }



    private void cmdPullMyShopAuto_Click(object sender, EventArgs e)
    {

      SelectAllCYADataFromWeb();

    }

    private void txtLRTReading_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtRegistrationVerified_TextChanged(object sender, EventArgs e)
    {

    }
  }



}

public class CustVehInfo
{
  public string VehicleServiceGuid { get; set; }
  public string WorkOrder { get; set; }
  public string InspectionDate { get; set; }
  public string StrickerMMYY { get; set; }

  public string MechanicName { get; set; }
  public string MechanicLic { get; set; }

  public string InspectionCost { get; set; }
  public string EmissonNum { get; set; }


  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string City { get; set; }
  public string State { get; set; }
  public string Zip { get; set; }
  public string County { get; set; }
  public string CountyCode { get; set; }

  public string VIN { get; set; }
  public string Plate { get; set; }
  public string Year { get; set; }
  public string VehicleMake { get; set; }
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
  public string BrakeFrontBondRivet { get; set; }
  public string BrakeRearBondRivet { get; set; }
  //public string BrakeRFBondRivet { get; set; }
  //public string BrakeRRBondRivet { get; set; }

}

public class Tires
{
  public string TireRightFront { get; set; }
  public string TireRightRear { get; set; }
  public string TireLeftFront { get; set; }
  public string TireLeftRear { get; set; }
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
