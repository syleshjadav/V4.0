using System;
using System.Runtime.Serialization;

namespace ATP.DataModel
{
    public partial class uspSelCustomerLite_Result
    {
        [DataMember]
        public short PageStartIndex { get; set; }


        [DataMember]
        public bool? IsSelected { get; set; }

        [DataMember]
        public bool? IsPickUpOrDrop { get; set; }

        //public static implicit operator uspSelCustomerLite_Result(uspSelCustomerLite_Result v)
        //{
        //    throw new NotImplementedException();
        //}
    }

}