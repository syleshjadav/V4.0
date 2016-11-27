using System;
using System.Runtime.Serialization;

namespace ATP.DataModel
{
    public class VehicleServicesDataTable
    {
        [DataMember]
        public Guid VehicleGUID { get; set; }
        [DataMember]
        public int? DealerId { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public int KioskId { get; set; }

        [DataMember]
        public string KeyId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int Mileage { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string RONumber { get; set; }
        [DataMember]
        public bool Paid { get; set; }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public bool ADAM { get; set; }
        [DataMember]
        public double ServiceCost { get; set; }
        [DataMember]
        public double PackageCost { get; set; }
       
        [DataMember]
        public int ExpressNumber { get; set; }
        [DataMember]
        public Guid EnteredBy { get; set; }
        [DataMember]
        public string KeyTagBarCodeId { get; set; }

    }
}
