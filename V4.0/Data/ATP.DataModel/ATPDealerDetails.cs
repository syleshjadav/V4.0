using System;
using System.Runtime.Serialization;


namespace ATP.DataModel
{
    [System.Runtime.Serialization.DataContract(Name = "ATPDealerDetails", Namespace = "http://www.AdamKiosks.com/ATPDealerDetails")]
    [Serializable]
    public partial class ATPDealerDetails
    {
        public ATPDealerDetails() { }

        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string DealerName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ImageOSPath { get; set; }
        [DataMember]
        public string ImageHttpPath { get; set; }
        [DataMember]
        public string ServiceEmailFromId { get; set; }
        [DataMember]
        public string ServiceEmailFromName { get; set; }
        [DataMember]
        public string ServiceEmailSubject { get; set; }
        [DataMember]
        public string WebURL { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string ZipCode4 { get; set; }
        [DataMember]
        public string SalesPhone { get; set; }
        [DataMember]
        public string ServicePhone { get; set; }
        [DataMember]
        public string GeneralInquryPhone { get; set; }
        [DataMember]
        public string ManagerName { get; set; }
        [DataMember]
        public string ManagerPhone { get; set; }
    }
}
