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
using MyShopCompInspectionSync;

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

    public Form1()
    {
      InitializeComponent();


      Connectionstring = MyShopCompInspectionSync.Properties.Settings.Default.ConnectionString;

      conn.ConnectionString = Connectionstring;
      conn.Open();

      //SelectAllCounties();

      // UpsertCustomer();
      DateTime thisDay = DateTime.Today;
      txtInspectionDate.Text = thisDay.ToString("d");

      if (conn.IsConnectionAlive)
      {
        conn.Close();
      }

    }

    private void UpsertCustomer()
    {
      CustVehInfo cust = LoadDataIntoObject();



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

    private CustVehInfo LoadDataIntoObject()
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
        InspectionDate = txtInspectionDate.Text
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

        BrakeLFBondRivet = txtLFBCondition.Text,
        BrakeLRBondRivet = txtLRBCondition.Text,
        BrakeRFBondRivet = txtRFBCondition.Text,
        BrakeRRBondRivet = txtRRBCondition.Text,


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

      if (cust.InspectionInfo.Body=="F" || cust.InspectionInfo.Break=="F" || cust.InspectionInfo.Exhaust=="F" || cust.InspectionInfo.Fuel=="F" || cust.InspectionInfo.Glazing=="F" || 
        cust.InspectionInfo.Lights=="F" ||cust.InspectionInfo.Other=="F" || cust.InspectionInfo.RegVerified=="F" || cust.InspectionInfo.RoadTest=="F" || cust.InspectionInfo.Streering=="F" ||
        cust.InspectionInfo.Tires=="F")
      {
        cust.InspectionInfo.PassInspection = "N";
      }

      if(cust.VisualAnti.AIRPump=="F" || cust.VisualAnti.CatalyticConverter=="F" || cust.VisualAnti.ERG=="F" || cust.VisualAnti.EvaporativeControl=="F" || cust.VisualAnti.FuelInlet=="F"
        || cust.VisualAnti.PCV=="F")
      {
        cust.InspectionInfo.PassInspection = "N";
      }
     

      


      return cust;
    }

    private void SelectAllCounties()
    {
      try
      {

        string sql = " SELECT * from PACounty";

        cmd.CommandText = sql;
        cmd.Connection = conn;
        adapter.SelectCommand = cmd;
        adapter.Fill(dset);
        if (dset.Tables[0].Rows.Count > 0)
        {
          var success = true;

        }

      }
      catch (AdsException e)
      {
        // print the exception message
        Console.WriteLine(e.Message);
      }
    }

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
      CustVehInfo cust = LoadDataIntoObject();

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

            cmd.Parameters.Add("VehicleBody", cust.Body);
            cmd.Parameters.Add("VehicleYear", cust.Year);
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


            cmd.Parameters.Add("BrakeLFBondRivet", cust.Brakes.BrakeLFBondRivet);
            cmd.Parameters.Add("BrakeLFThickness", cust.Brakes.BrakeLFThickness);
            cmd.Parameters.Add("BrakeLRBondRivet", cust.Brakes.BrakeLRBondRivet);
            cmd.Parameters.Add("BrakeLRThickness", cust.Brakes.BrakeLRThickness);
            cmd.Parameters.Add("BrakeRFBondRivet", cust.Brakes.BrakeRFBondRivet);
            cmd.Parameters.Add("BrakeRFThickness", cust.Brakes.BrakeRFThickness);
            cmd.Parameters.Add("BrakeRRBondRivet", cust.Brakes.BrakeRRBondRivet);
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
      
      MessageBox.Show("It will be coded after verification");
      Helper.ClearFormControls(this);
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
  public string WorkOrder { get; set; }
  public string InspectionDate { get; set; }
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
  public string BrakeLFBondRivet { get; set; }
  public string BrakeLRBondRivet { get; set; }
  public string BrakeRFBondRivet { get; set; }
  public string BrakeRRBondRivet { get; set; }

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
