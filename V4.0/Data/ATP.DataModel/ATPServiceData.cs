using System;
using System.Data;
using System.Runtime.Serialization;

namespace ATP.DataModel
{
    [System.Runtime.Serialization.DataContract(Name = "ATPServiceData", Namespace = "http://www.AdamKiosks.com/ATPServiceData")]
    [Serializable]
    public class ATPServiceData
    {
        public ATPServiceData() { }

        [DataMember]
        public string Cost { get; set; }

        [DataMember]
        public string Desc { get; set; }


        [DataMember]
        public string Id { get; set; }


        [DataMember]
        public string IsPackage { get; set; }



        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public Guid DealerEmpGuid { get; set; }

    }

    [Serializable, DataContract]
    public class ATPRegisterDeviceId
    {
        public ATPRegisterDeviceId() { }

        [DataMember]
        public string DeviceTypeId { get; set; }
        [DataMember]
        public string DeviceId { get; set; }
        [DataMember]
        public string FirstName { get; set; }


        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string VIN { get; set; }

        [DataMember]
        public string DealerId { get; set; }

        [DataMember]
        public string PersonGuid { get; set; }
    }

    [Serializable, DataContract]
    public class ATPChatMessage
    {
        public ATPChatMessage() { }

        [DataMember]
        public string DealerId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string VIN { get; set; }

        [DataMember]
        public string PersonGuid { get; set; }

      
    }

    [Serializable, DataContract]
    public class ATPGetPickUpPin {
        public ATPGetPickUpPin() { }

        [DataMember]
        public string DealerId { get; set; }
        [DataMember]
        public string PersonGuid { get; set; }

        [DataMember]
        public string VehicleGuid { get; set; }
       
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string VIN { get; set; }

       


    }


    [Serializable, DataContract]
    public class ATPChatMessageNew
    {
        public ATPChatMessageNew() { }

        [DataMember]
        public string DealerId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string VIN { get; set; }

        [DataMember]
        public string PersonGuid { get; set; }
        [DataMember]
        public string DealerEmpGuid
        {
            get; set;
        }
    }


    [Serializable, DataContract]
    public class ATPServiceDataKeyDrop {
        public ATPServiceDataKeyDrop() { }

        [DataMember]
        public string DealerId { get; set; }

        [DataMember]
        public string PersonGuid { get; set; }
        
        [DataMember]
        public string VehicleGuid { get; set; }
        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public System.Collections.Generic.List<ATPServiceData> ATPServiceDataList { get; set; }
    }


    [Serializable, DataContract]
    public class ATPExpressCheckIn
    {
        public ATPExpressCheckIn() { }

        [DataMember]
        public string DealerId { get; set; }

        [DataMember]
        public string PersonGuid { get; set; }

        [DataMember]
        public string VehicleGuid { get; set; }
        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public System.Collections.Generic.List<ATPServiceData> ATPServiceDataList { get; set; }
    }


    [Serializable, DataContract]
    public class ATPServiceDataMaster
    {
        public ATPServiceDataMaster() { }

        [DataMember]
        public string DealerId { get; set; }

        [DataMember]
        public string FirstName { get; set; }


        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string VIN { get; set; }


       

        [DataMember]
        public System.Collections.Generic.List<ATPServiceData> ATPServiceDataList { get; set; }
    }

    [Serializable, DataContract]
    public class ATPServiceDataMasterWithDt
    {
        public ATPServiceDataMasterWithDt() { }

        [DataMember]
        public string DealerId { get; set; }

        [DataMember]
        public string FirstName { get; set; }


        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string VIN { get; set; }

        [DataMember]
        public string ScheduleDate { get; set; }

        [DataMember]
        public System.Collections.Generic.List<ATPServiceData> ATPServiceDataList { get; set; }
    }

    public class ATPServiceDataMasterKiosk
    {
        public ATPServiceDataMasterKiosk() { }

        [DataMember]
        public int DealerId { get; set; }

        [DataMember]
        public Guid VehicleGuid { get; set; }

        [DataMember]
        public Guid PersonGuid { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public int VehicleMileage { get; set; }
        [DataMember]
        public int Mileage { get; set; }
        [DataMember]
        public int StatusId { get; set; }

        [DataMember]
        public string RONumber { get; set; }

        [DataMember]
        public string KioskName { get; set; }

        [DataMember]
        public string KioskMachineId { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public int KioskId { get; set; }
        [DataMember]
        public string ContactText { get; set; }
        [DataMember]
        public string ContactCellPhone { get; set; }

        [DataMember]
        public string ContactEmail { get; set; }
        [DataMember]
        public bool ContactByText { get; set; }
        [DataMember]
        public string EnteredBy { get; set; }

        [DataMember]
        public bool Paid { get; set; }
        [DataMember]
        public int ExpressNumber { get; set; }

        [DataMember]
        public bool ADAM { get; set; }

        [DataMember]
        public double PackageCost { get; set; }

        [DataMember]
        public double ServiceCost { get; set; }

        [DataMember]
        public string KeyTagBarCodeId { get; set; }
        [DataMember]
        public byte KeyLockerPegId { get; set; }

        [DataMember]
        public System.Collections.Generic.List<ATPServiceData> ATPServiceDataList { get; set; }
    }

    public class ATPServiceDataTable
    {

        public static DataTable ATPServiceDataType()
        {
            var dt = new DataTable();
            dt.Columns.Add("Cost", typeof(double));
            dt.Columns.Add("DetailDesc", typeof(string));
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("IsPackage", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            return dt;
        }
    }
}
