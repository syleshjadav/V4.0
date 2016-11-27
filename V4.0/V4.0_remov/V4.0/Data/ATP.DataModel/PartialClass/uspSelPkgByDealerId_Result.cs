using System.Runtime.Serialization;
namespace ATP.DataModel
{
    public partial class uspSelPkgByDealerId_Result
    {
        [DataMember]
        public int Cost { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }
    }
}