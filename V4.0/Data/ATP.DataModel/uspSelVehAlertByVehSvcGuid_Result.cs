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
    
    public partial class uspSelVehAlertByVehSvcGuid_Result
    {
        public int Id { get; set; }
        public int AlertId { get; set; }
        public Nullable<System.Guid> VehicleGUID { get; set; }
        public Nullable<System.Guid> TechGUID { get; set; }
        public bool ResponseRequested { get; set; }
        public System.DateTime Sent { get; set; }
        public Nullable<bool> Retrieved { get; set; }
        public Nullable<byte> Response { get; set; }
        public Nullable<byte> ResponseSource { get; set; }
        public Nullable<System.DateTime> ResponseReceived { get; set; }
        public string Text { get; set; }
        public System.DateTime Entered { get; set; }
    }
}
