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
    
    public partial class uspSelServiceTypeEmails_Result
    {
        public int ServiceTypeId { get; set; }
        public int PackageId { get; set; }
        public string GroupCode { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }
        public bool IsSignatureRequired { get; set; }
    }
}
