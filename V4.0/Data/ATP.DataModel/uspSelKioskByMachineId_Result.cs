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
    
    public partial class uspSelKioskByMachineId_Result
    {
        public int Id { get; set; }
        public string MachineId { get; set; }
        public string Name { get; set; }
        public Nullable<short> ResolutionHeight { get; set; }
        public Nullable<short> ResolutionWidth { get; set; }
        public string BuildNumber { get; set; }
        public Nullable<System.DateTime> BeginService { get; set; }
        public Nullable<System.DateTime> EndService { get; set; }
        public Nullable<System.DateTime> LastPatch { get; set; }
        public Nullable<System.DateTime> LastSync { get; set; }
        public Nullable<byte> OSTypeId { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<bool> ReSetPassword { get; set; }
        public string ProvidedSvcsType { get; set; }
    }
}
