//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATP.DataModel
{
    using System;
    
    public partial class uspSelVehicleServiceImage_Result
    {
        public long ImageId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<System.Guid> ImageUploadedBy { get; set; }
        public Nullable<System.Guid> VehicleGuid { get; set; }
        public Nullable<System.Guid> VehicleServiceGuid { get; set; }
        public Nullable<System.DateTime> UploadedDate { get; set; }
        public byte[] VehImage { get; set; }
        public string Comments { get; set; }
    }
}
