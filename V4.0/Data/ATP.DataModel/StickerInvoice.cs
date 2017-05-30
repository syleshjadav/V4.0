using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ATP.DataModel
{
    
    [ Serializable]
    public class StickerInvoice
    {
        public MSDealerEmp DealerEmp { get; set; }
        public MSCustomerVehicle CustomerVehicle { get; set; }
        public MsInspectionInfo InspectionInfo { get; set; }

    }


    public partial class MSCustomerVehicle
    {
        [DataMember]
        public string GoogleGuid { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string PersonGuid { get; set; }
        [DataMember]
        public string DeviceTypeId { get; set; }
        [DataMember]
        public string DealerPersonGroupId { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string IsValid { get; set; }


        [DataMember]
        public string VehPhId { get; set; }

        [DataMember]
        public string VehicleGuid { get; set; }
        [DataMember]
        public string VehicleMake { get; set; }
        [DataMember]
        public string VehicleModel { get; set; }
        [DataMember]
        public string VehicleTrim { get; set; }
        [DataMember]
        public string VIN { get; set; }
        [DataMember]
        public string VehicleYear { get; set; }
        [DataMember]
        public string VehicleId { get; set; }
        [DataMember]
        public string VehicleName { get; set; }
        [DataMember]
        public string Plate { get; set; }
        [DataMember]
        public string NextServiceDate { get; set; }
        [DataMember]
        public string NextInspectionDate { get; set; }
        [DataMember]
        public string NextSvcInfo { get; set; }
        [DataMember]
        public string OldMileage { get; set; }
        [DataMember]
        public string CurrMileage { get; set; }
        [DataMember]
        public string MileageIn { get; set; }
        [DataMember]
        public string MileageOut { get; set; }

        [DataMember]
        public string VehicleYrMkMod { get; set; }

        [DataMember]
        public string NAIC { get; set; }


        [DataMember]
        public string InsPolicyNum { get; set; }

        [DataMember]
        public string InsExpDate { get; set; }




    }

    public partial class MSDealerEmp
    {
        [DataMember]
        [XmlElement("DealerId")]
        public string DealerId { get; set; }

        
        [XmlElement("StationYr")]
        public string StationYr { get; set; }

        [DataMember]
        [XmlText]
        public string InspectionYr { get; set; }


        [DataMember]
        public string DeptId { get; set; }
        [DataMember]
        public string StationNumber { get; set; }

        [DataMember]
        public string StickerCharge { get; set; }

        [DataMember]
        public string DealerEmpGuid { get; set; }
        [DataMember]
        public string DeptName { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }


    }

    public class MsInspectionInfo
    {
        [DataMember]
        public InspectionItem RoadTest { get; set; }
        [DataMember]
        public InspectionItem Insurance { get; set; }

        [DataMember]
        public InspectionItem SteeringandSuspension { get; set; }
        [DataMember]
        public InspectionItem GlazingAndMirrors { get; set; }
        [DataMember]
        public InspectionItem BrakeSystems { get; set; }
        [DataMember]
        public InspectionItem BodyDoorAndLatches { get; set; }
        [DataMember]
        public InspectionItem FuelSystems { get; set; }
        [DataMember]
        public InspectionItem ExhaustSystems { get; set; }
        [DataMember]
        public InspectionItem TiresAndWheels { get; set; }
        [DataMember]
        public InspectionItem RegistrationVerified { get; set; }

        [DataMember]
        public InspectionItem VisualAntiTampering { get; set; }

        [DataMember]
        public FrontRear BrakeReadings { get; set; }


        [DataMember]
        public FrontRear TireReadings { get; set; }

        [DataMember]
        public InspectionItem InspectionResult { get; set; }


        [DataMember]
        public InspectionItem StickerNumber { get; set; }


    }


    public class InspectionItem
    {
      //  public string ItemName { get; set; }
        public string DuringInsp { get; set; }
        public string PostInsp { get; set; }
        public string Comments { get; set; }

        public string Cost { get; set; }

    }


    public class FrontRear
    {
        public Findings LF { get; set; }
        public Findings LR { get; set; }
        public Findings RF { get; set; }
        public Findings RR { get; set; }

    }



    public class Findings
    {
        public string Readings { get; set; }
        public string BondOrRevet { get; set; }

        public string Comments { get; set; }
    }

}
