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
    
    public partial class uspSelAllErrors_Result
    {
        public int Id { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<byte> SeverityId { get; set; }
        public Nullable<long> ExceptionId { get; set; }
        public string DBName { get; set; }
        public Nullable<int> Number { get; set; }
        public Nullable<int> SourceLine { get; set; }
        public string SourceFile { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string Event { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> ProcessId { get; set; }
        public string MachineName { get; set; }
        public string UserName { get; set; }
        public string TargetSite { get; set; }
        public string StackTrace { get; set; }
        public string Text { get; set; }
    }
}
