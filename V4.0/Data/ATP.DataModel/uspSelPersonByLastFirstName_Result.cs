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
    
    public partial class uspSelPersonByLastFirstName_Result
    {
        public System.Guid PersonGuid { get; set; }
        public byte PersonTypeId { get; set; }
        public string UserName { get; set; }
        public bool Valid { get; set; }
        public string GoogleGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public byte PersonNameTypeId { get; set; }
        public string PersonTypeName { get; set; }
        public string PersonRoleName { get; set; }
        public short AccessLevel { get; set; }
        public string PersonRoleDesc { get; set; }
        public System.DateTime PersonEntered { get; set; }
    }
}
