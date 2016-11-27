using System.Runtime.Serialization;

namespace ATP.DataModel
{
    public partial class uspSelKeyLockerOpenPeg_Result
    {

        [DataMember]
        public System.Guid? VehicleServiceGuid { get; set; }
        [DataMember]
        public System.Guid? UpdatedBy { get; set; }

        [DataMember]
        public byte? ServiceStatusId { get; set; }

        [DataMember]
        public bool? IsOpen { get; set; }


        [DataMember]
        public bool? IsDropOrPickUp { get; set; }


    }

}