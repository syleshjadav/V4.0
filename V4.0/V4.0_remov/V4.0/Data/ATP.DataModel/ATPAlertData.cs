using System.Runtime.Serialization;

namespace ATP.DataModel
{
    [DataContract]
    public class ATPAlertData
    {
        public ATPAlertData() { }

        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string ShowYesNo { get; set; }
        [DataMember]
        public string Msg { get; set; }

        [DataMember]
        public string IsCustMsg { get; set; }

        [DataMember]
        public string MsgDt { get; set; }

        [DataMember]
        public string PersonGuid { get; set; }
    }


    [DataContract]
    public class ATPAlertDataNew
    {
        public ATPAlertDataNew() { }

        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string ShowYesNo { get; set; }
        [DataMember]
        public string Msg { get; set; }

        [DataMember]
        public string IsCustMsg { get; set; }

        [DataMember]
        public string MsgDt { get; set; }

        [DataMember]
        public string PersonGuid { get; set; }

        [DataMember]
        public string DealerEmpGuid
        {
            get; set;
        }
    }
}
