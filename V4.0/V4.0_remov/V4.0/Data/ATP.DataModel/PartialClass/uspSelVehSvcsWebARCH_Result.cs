using System.Runtime.Serialization;
namespace ATP.DataModel
{
    public partial class uspSelVehSvcsWebARCH_Result
    {
        [DataMember]
        public short PageStartIndex { get; set; }
        [DataMember]
        public System.DateTime? ServiceDateFrom { get; set; }
        [DataMember]
        public System.DateTime? ServiceDateTo { get; set; }
        [DataMember]
        public bool? ShowInServiceCustomer { get; set; }
    }
}