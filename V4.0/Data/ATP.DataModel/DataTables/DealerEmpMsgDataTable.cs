using System;
using System.Runtime.Serialization;

namespace ATP.DataModel.DataTables
{
   public class DealerEmpMsgDataTable
    {

        [DataMember]
        public long MsgId { get; set; }
        [DataMember]
        public Guid DealerEmpGuid { get; set; }
   }
}
