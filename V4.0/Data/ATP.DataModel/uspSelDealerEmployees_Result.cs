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
    
    public partial class uspSelDealerEmployees_Result
    {
        public byte DeptId { get; set; }
        public int DealerId { get; set; }
        public string DeptName { get; set; }
        public string EmployeeName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public System.Guid EmployeeGuid { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsValid { get; set; }
        public Nullable<int> SiteRole { get; set; }
        public Nullable<int> DeviceTypeId { get; set; }
        public Nullable<bool> IsEnableDoorBell { get; set; }
        public string GoogleGuid { get; set; }
        public Nullable<int> AssignedWorkCount { get; set; }
    }
}
