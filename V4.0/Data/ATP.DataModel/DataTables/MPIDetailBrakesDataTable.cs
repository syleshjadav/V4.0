using System;
using System.Runtime.Serialization;

namespace ATP.DataModel
{
    public class MPIDetailBrakesDataTable
    {


        [DataMember]
        public byte MPIItemId { get; set; }

        [DataMember]
        public byte LFRYGNValue { get; set; }

        [DataMember]
        public byte RFRYGNValue { get; set; }
        [DataMember]
        public byte RLRYGNValue { get; set; }

        [DataMember]
        public byte RRRYGNValue { get; set; }
        [DataMember]
        public string LFMMSValue { get; set; }

        [DataMember]
        public string RFMMSValue { get; set; }
        [DataMember]
        public string RLMMSValue { get; set; }

        [DataMember]
        public string RRMMSValue { get; set; }
        [DataMember]
        public string LFTechComments { get; set; }
        [DataMember]
        public string LFCustComments { get; set; }
        [DataMember]
        public byte LFCustAcceptedYN { get; set; }
        [DataMember]
        public decimal LFCost { get; set; }
        [DataMember]
        public string RFTechComments { get; set; }
        [DataMember]
        public string RFCustComments { get; set; }
        [DataMember]
        public byte RFCustAcceptedYN { get; set; }

        [DataMember]
        public decimal RFCost { get; set; }
        [DataMember]
        public string RLTechComments { get; set; }
        [DataMember]
        public string RLCustComments { get; set; }
        [DataMember]
        public byte RLCustAcceptedYN { get; set; }

        [DataMember]
        public decimal RLCost { get; set; }
        [DataMember]
        public string RRTechComments { get; set; }
        [DataMember]
        public string RRCustComments { get; set; }
        [DataMember]
        public byte RRCustAcceptedYN { get; set; }
        [DataMember]

        public decimal RRCost { get; set; }

    }
}
