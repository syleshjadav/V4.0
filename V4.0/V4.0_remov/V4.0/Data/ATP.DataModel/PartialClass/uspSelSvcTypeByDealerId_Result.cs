using System.Runtime.Serialization;

namespace ATP.DataModel
{
    public partial class uspSelSvcTypeByDealerId_Result
    {

        public uspSelSvcTypeByDealerId_Result()
        {
            IsEnabledVal = true;
            OpacityVal = 1;
        }

        [DataMember]
        public bool IsEnabledVal { get; set; }

        [DataMember]
        public double OpacityVal { get; set; }

        [DataMember]
        public string BackgroundColor { get; set; }


        [DataMember]
        public bool IsPackage { get; set; }


        [DataMember]
        public bool IsSelected { get; set; }

    }

}