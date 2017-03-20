
using System;

public class DealerInfo
{
    public string Station_Id { get; set; }
    public string AICharge { get; set; }
    public string AIStickerCost { get; set; }
    public string StateTaxRate { get; set; }
    public string CurrentLaborRate { get; set; }
    public int InvoiceNumber { get; set; }   
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
    public string StateTaxRate { get; set; }
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