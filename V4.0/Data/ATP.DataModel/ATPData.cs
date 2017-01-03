using System;
using System.Runtime.Serialization;

namespace ATP.DataModel {
    //[System.Runtime.Serialization.DataContract(Name = "ATPPinInfo", Namespace = "http://www.AdamKiosks.com/ATPPinInfo")]
    //[System.Serializable]
    //public partial class ATPPinInfo {
    //    public ATPPinInfo() { }

    //    [DataMember]
    //    public string Id { get; set; }
    //    [DataMember]
    //    public string Value { get; set; }
    //    //[DataMember]
    //    //public string VehId { get; set; }
    //}
    [System.Runtime.Serialization.DataContract(Name = "ATPFindExistingCutomer", Namespace = "http://www.AdamKiosks.com/ATPFindExistingCutomer")]
    [System.Serializable]
    public partial class ATPFindExistingCutomer {
        public ATPFindExistingCutomer() { }

        [DataMember]
        public string DealerId { get; set; }
        [DataMember]
        public string Plate { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string DeviceId { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Name = "ATPData", Namespace = "http://www.AdamKiosks.com/ATPData")]
    [System.Serializable]
    public partial class ATPData {
        public ATPData() { }

        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Value { get; set; }
        //[DataMember]
        //public string VehId { get; set; }
    }

    [Serializable, DataContract]
    public partial class ATPLoginDealerEmployee {
        public ATPLoginDealerEmployee() { }

      
        [DataMember]
        public string EmpEmail { get; set; }
        [DataMember]
        public string EmpPassword { get; set; }

        [DataMember]
        public string ERRMSG { get; set; }

    }

    [Serializable, DataContract]
    public partial class ATPLoginDealerEmp {

        public ATPLoginDealerEmp() { }
         [DataMember] public string DeptId { get; set; }
         [DataMember] public string DealerId { get; set; }
         [DataMember] public string DealerEmpGuid { get; set; }
         [DataMember] public string DeptName { get; set; }
         [DataMember] public string EmailAddress { get; set; }
         [DataMember] public string EmpName { get; set; }
         [DataMember] public string PhoneNumber { get; set; }
        
         [DataMember] public string ERRMSG { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Name = "MyShopRegisterCustomerData", Namespace = "http://www.AdamKiosks.com/ATPData")]
    [System.Serializable]
    public partial class MyShopRegisterCustomerData {
        public MyShopRegisterCustomerData() { }

        [DataMember]
        public string PersonGuid { get; set; }
        [DataMember]
        public string VehicleId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string VehPhId { get; set; }
    }


    [Serializable, DataContract]
    public partial class ATPDataMPIRedYellow {
        [DataMember]
        public string DealerId { get; set; }
        [DataMember]
        public string VehicleId { get; set; }
        [DataMember]
        public string MPIItemId { get; set; }
        [DataMember]
        public string Itemdesc { get; set; }
        [DataMember]
        public string RYGNValue { get; set; }
        [DataMember]
        public string SWComments { get; set; }
        [DataMember]
        public string TechComments { get; set; }
        [DataMember]
        public string MPIMasterGuid { get; set; }
        [DataMember]
        public string Custcomments { get; set; }
        [DataMember]
        public string CustacceptedYN { get; set; }
        [DataMember]
        public string Cost { get; set; }
        [DataMember]
        public string IsLocked { get; set; }
        [DataMember]
        public string PersonGuid { get; set; }
        [DataMember]
        public string VehPhId { get; set; }
    }

    [System.Runtime.Serialization.DataContract(Name = "ATPCustomerDetailsByGuid", Namespace = "http://www.AdamKiosks.com/ATPData")]
    [System.Serializable]
    public partial class ATPCustomerDetailsByGuid {
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
        public string DealerId { get; set; }
        [DataMember]
        public string VehicleYrMkMod { get; set; }
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
        public string DealerFamilyId { get; set; }

        [DataMember]
        public string VehPhId { get; set; }

        [DataMember]
        public string DealerName { get; set; }
    }
}
