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
    
    public partial class uspSelDealerMessage_Result
    {
        public Nullable<int> TimeTakenInMin { get; set; }
        public Nullable<int> NoOfDays { get; set; }
        public Nullable<System.TimeSpan> TimeInHrMin { get; set; }
        public string TimeTakenColor { get; set; }
        public long MsgId { get; set; }
        public Nullable<System.Guid> VehicleServiceGuid { get; set; }
        public Nullable<System.Guid> VehicleGuid { get; set; }
        public Nullable<System.Guid> DealerEmpGuid { get; set; }
        public Nullable<int> DealerId { get; set; }
        public string MsgFrom { get; set; }
        public string MsgTo { get; set; }
        public Nullable<System.DateTime> MsgDt { get; set; }
        public string TxtMsg { get; set; }
        public Nullable<bool> IsCustMsg { get; set; }
        public Nullable<bool> IsMsgToCust { get; set; }
        public string FromPhNum { get; set; }
        public string ToPhNum { get; set; }
        public Nullable<bool> IsMsgRead { get; set; }
        public string ReadyBy { get; set; }
        public Nullable<System.DateTime> ReadTimeInHrMin { get; set; }
        public Nullable<bool> ShowBtn { get; set; }
        public Nullable<System.Guid> PersonGuid { get; set; }
        public Nullable<bool> IsDoorBellNotified { get; set; }
    }
}
