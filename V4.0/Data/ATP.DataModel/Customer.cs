

using System;
using System.Runtime.Serialization;
namespace ATP.DataModel
{
    [System.Serializable]
    [System.Runtime.Serialization.DataContract(Name = "Customer", Namespace = "http://www.AdamKiosks.com/Customer")]
    public partial class Customer
    {
        public Customer() { }

        [System.Runtime.Serialization.DataMember(Name = "DealerId", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "DealerId", DataType = "int", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "DealerId", DataType = "int", IsNullable = true)]
        public int? DealerId;
        [System.Runtime.Serialization.DataMember(Name = "DealerFamilyId", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "DealerFamilyId", DataType = "short", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "DealerFamilyId", DataType = "short", IsNullable = true)]
        public short? DealerFamilyId;
        [System.Runtime.Serialization.DataMember(Name = "FirstName", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "FirstName", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "FirstName", DataType = "string", IsNullable = true)]
        public string FirstName;
        [System.Runtime.Serialization.DataMember(Name = "LastName", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "LastName", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "LastName", DataType = "string", IsNullable = true)]
        public string LastName;
        [System.Runtime.Serialization.DataMember(Name = "Address", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "Address", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Address", DataType = "string", IsNullable = true)]
        public string Address;
        [System.Runtime.Serialization.DataMember(Name = "Address2", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "Address2", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Address2", DataType = "string", IsNullable = true)]
        public string Address2;
        [System.Runtime.Serialization.DataMember(Name = "City", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "City", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "City", DataType = "string", IsNullable = true)]
        public string City;
        [System.Runtime.Serialization.DataMember(Name = "State", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "State", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "State", DataType = "string", IsNullable = true)]
        public string State;
        [System.Runtime.Serialization.DataMember(Name = "Zip", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "Zip", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Zip", DataType = "string", IsNullable = true)]
        public string Zip;
        [System.Runtime.Serialization.DataMember(Name = "Plate", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "Plate", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Plate", DataType = "string", IsNullable = true)]
        public string Plate;
        [System.Runtime.Serialization.DataMember(Name = "VIN", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "VIN", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "VIN", DataType = "string", IsNullable = true)]
        public string VIN;
        [System.Runtime.Serialization.DataMember(Name = "MakeId", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "MakeId", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "MakeId", DataType = "string", IsNullable = true)]
        public string MakeId;
        [System.Runtime.Serialization.DataMember(Name = "ModelId", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "ModelId", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "ModelId", DataType = "string", IsNullable = true)]
        public string ModelId;
        [System.Runtime.Serialization.DataMember(Name = "TrimId", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "TrimId", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "TrimId", DataType = "string", IsNullable = true)]
        public string TrimId;
        [System.Runtime.Serialization.DataMember(Name = "Year", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "Year", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Year", DataType = "string", IsNullable = true)]
        public string Year;
        [System.Runtime.Serialization.DataMember(Name = "CurrentMileage", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "CurrentMileage", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "CurrentMileage", DataType = "string", IsNullable = true)]
        public string CurrentMileage;
        [System.Runtime.Serialization.DataMember(Name = "YearlyMiles", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "YearlyMiles", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "YearlyMiles", DataType = "string", IsNullable = true)]
        public string YearlyMiles;
        [System.Runtime.Serialization.DataMember(Name = "Phone", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "Phone", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Phone", DataType = "string", IsNullable = true)]
        public string Phone;
        [System.Runtime.Serialization.DataMember(Name = "Email", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "Email", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "Email", DataType = "string", IsNullable = true)]
        public string Email;
        [System.Runtime.Serialization.DataMember(Name = "VehicleName", IsRequired = false, EmitDefaultValue = false)]
        [System.Xml.Serialization.SoapElement(ElementName = "VehicleName", DataType = "string", IsNullable = true)]
        [System.Xml.Serialization.XmlElement(ElementName = "VehicleName", DataType = "string", IsNullable = true)]
        public string VehicleName;
    }
    [Serializable, DataContract]
    public partial class CustomerForRestSvc
    {

        public CustomerForRestSvc() { }

        [DataMember]
        public string DealerId { get; set; }
        [DataMember]
        public string DealerFamilyId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string Plate { get; set; }
        [DataMember]
        public string VIN { get; set; }
        [DataMember]
        public string MakeId { get; set; }
        [DataMember]
        public string ModelId { get; set; }
        [DataMember]
        public string TrimId { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string CurrentMileage { get; set; }
        [DataMember]
        public string YearlyMiles { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string VehName { get; set; }
    }

    [Serializable, DataContract]
    public partial class CustomerForRestSvcLite
    {

        public CustomerForRestSvcLite() { }

        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string DealerId { get; set; }
        [DataMember]
        public string DealerFamilyId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string PersonGuid { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string VehYrMkMod { get; set; }
        [DataMember]
        public string Zip { get; set; }


    }
}
