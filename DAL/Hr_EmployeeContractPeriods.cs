//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hr_EmployeeContractPeriods
    {
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal ContractPeriod_Id { get; set; }
        public Nullable<decimal> Contract_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string WorkStartingDate { get; set; }
        public string FromStartPeriod { get; set; }
        public string ToEndPeriod { get; set; }
        public Nullable<decimal> NoOfDeservedDays { get; set; }
        public Nullable<decimal> NoOfVacDays { get; set; }
        public Nullable<System.Guid> LastTransRec_hdr_Id { get; set; }
        public Nullable<System.DateTime> Insdate { get; set; }
        public Nullable<decimal> NoOfRestVacDays { get; set; }
    }
}
