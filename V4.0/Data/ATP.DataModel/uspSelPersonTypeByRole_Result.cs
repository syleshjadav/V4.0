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
    
    public partial class uspSelPersonTypeByRole_Result
    {
        public byte Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short AccessLevel { get; set; }
        public bool Disabled { get; set; }
        public bool Valid { get; set; }
        public System.Guid EnteredBy { get; set; }
        public System.DateTime Entered { get; set; }
        public Nullable<System.Guid> UpdatedBy { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public Nullable<int> DbErrorNumber { get; set; }
        public Nullable<int> DbErrorSeverity { get; set; }
        public Nullable<int> DbErrorState { get; set; }
        public string DbErrorProcedure { get; set; }
        public Nullable<int> DbErrorLine { get; set; }
        public string DbErrorMessage { get; set; }
    }
}
