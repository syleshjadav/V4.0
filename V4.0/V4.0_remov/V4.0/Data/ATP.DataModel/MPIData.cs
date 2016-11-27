using System;
using System.Runtime.Serialization;

namespace ATP.DataModel
{
    [DataContract]
    public class MPIData
    {
        [DataMember]
        public Nullable<int> MPIItemId { get; set; }
        [DataMember]
        public Nullable<byte> MPIGroupId { get; set; }
        [DataMember]
        public string ItemDesc { get; set; }
        [DataMember]
        public byte RYGNValue { get; set; }
        [DataMember]
        public string ServiceWriterComments { get; set; }
        [DataMember]
        public string TechComments { get; set; }
        [DataMember]
        public Nullable<System.Guid> MPIMasterGuid { get; set; }

        [DataMember]
        public string CustComments { get; set; }
        [DataMember]
        public Nullable<byte> CustAcceptedYN { get; set; }
        [DataMember]
        public Nullable<decimal> Cost { get; set; }
    }
}
