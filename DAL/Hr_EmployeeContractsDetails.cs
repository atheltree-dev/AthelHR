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
    
    public partial class Hr_EmployeeContractsDetails
    {
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Contract_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string Start_Contract { get; set; }
        public string End_Contract { get; set; }
        public Nullable<decimal> ContractPeriodByMonth { get; set; }
        public string WorkStartingDate { get; set; }
    }
}
