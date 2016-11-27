using System;
using System.Runtime.Serialization;

namespace ATP.DataModel
{
    public class VehicleServiceMPIDataTable
    {
      
        [DataMember]
        public byte MPIItemId { get; set; }

        [DataMember]
        public byte RYGNValue { get; set; }
        [DataMember]
        public string TechComments { get; set; }


        [DataMember]
        public string ServiceWriterComments { get; set; }

        [DataMember]
        public string CustComments { get; set; }
        [DataMember]
        public byte CustAcceptedYN { get; set; }
        [DataMember]
        public decimal Cost { get; set; }



    }
}
