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
    
    public partial class uspSelDealerEmpPages_Result
    {
        public byte Id { get; set; }
        public byte TypeId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public string ControlName { get; set; }
        public string ActionName { get; set; }
        public string AppName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
        public bool Valid { get; set; }
        public System.Guid EnteredBy { get; set; }
        public System.DateTime Entered { get; set; }
        public Nullable<System.Guid> UpdatedBy { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public Nullable<bool> IsEnabled { get; set; }
    }
}
