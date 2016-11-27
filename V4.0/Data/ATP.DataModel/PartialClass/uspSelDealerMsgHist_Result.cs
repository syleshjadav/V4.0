using System;
using System.Runtime.Serialization;
namespace ATP.DataModel
{
    public partial class uspSelDealerMsgHist_Result
    {
        [DataMember]
        public short PageStartIndex { get; set; }
        [DataMember]
        public Nullable<System.DateTime> MsgDtFrom { get; set; }
        [DataMember]
        public Nullable<System.DateTime> MsgDtTo { get; set; }
    }
}