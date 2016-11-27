using System;
using System.Runtime.Serialization;

namespace ATP.DataModel
{
    public class MPIDetailTiresDataTable
    {

        [DataMember]
        public byte MPIItemId { get; set; }
        [DataMember]
        public byte LFRYGNValue { get; set; }
        [DataMember]
        public string LFTechComments { get; set; }
        [DataMember]
        public string LFCustComments { get; set; }
        [DataMember]
        public byte LFCustAcceptedYN { get; set; }
        [DataMember]
        public decimal LFCost { get; set; }
        [DataMember]
        public byte RFRYGNValue { get; set; }
        [DataMember]
        public string RFTechComments { get; set; }
        [DataMember]
        public string RFCustComments { get; set; }
        [DataMember]
        public byte RFCustAcceptedYN { get; set; }
        [DataMember]
        public decimal RFCost { get; set; }
        [DataMember]
        public byte RLRYGNValue { get; set; }
        [DataMember]
        public string RLTechComments { get; set; }
        [DataMember]
        public string RLCustComments { get; set; }
        [DataMember]
        public byte RLCustAcceptedYN { get; set; }
        [DataMember]
        public decimal RLCost { get; set; }
        [DataMember]
        public byte RRRYGNValue { get; set; }
        [DataMember]
        public string RRTechComments { get; set; }
        [DataMember]
        public string RRCustComments { get; set; }
        [DataMember]
        public byte RRCustAcceptedYN { get; set; }
        [DataMember]
        public decimal RRCost { get; set; }
        [DataMember]
        public byte SPRYGNValue { get; set; }
        [DataMember]
        public string SPTechComments { get; set; }
        [DataMember]
        public string SPCustComments { get; set; }
        [DataMember]
        public byte SPCustAcceptedYN { get; set; }
        [DataMember]
        public decimal SPCost { get; set; }
        [DataMember]
        public string FrontPSIValueSetTo { get; set; }
        [DataMember]
        public string REARPSIValueSetTo { get; set; }
        [DataMember]
        public string SparePSIValueSetTo { get; set; }
        [DataMember]
        public string LFnds { get; set; }
        [DataMember]
        public string RFnds { get; set; }
        [DataMember]
        public string RLnds { get; set; }
        [DataMember]
        public string RRnds { get; set; }
        [DataMember]
        public string SPnds { get; set; }
    }
}
