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
    
    public partial class Hr_EmpDuesVactionTicket
    {
        public decimal Dtls_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string GradeJob_Id { get; set; }
        public decimal VactionPeriod { get; set; }
        public string VactionTicketType { get; set; }
        public string InternationalWorkTicketType { get; set; }
        public string LocalWorkTicketType { get; set; }
        public string InsUser { get; set; }
        public Nullable<System.DateTime> InsDate { get; set; }
        public Nullable<System.Guid> EmpHdrId { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<byte> RecStatus { get; set; }
        public Nullable<decimal> WorkingMonthNo { get; set; }
        public string WorkingPeriodType { get; set; }
        public Nullable<int> CountTicket { get; set; }
    }
}