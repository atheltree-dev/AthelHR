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
    
    public partial class Hr_EmpDues_History
    {
        public decimal Rec_id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string Transdate { get; set; }
        public Nullable<decimal> Emp_Serial_No { get; set; }
        public string HireItem_Id { get; set; }
        public Nullable<decimal> HireItem_Value { get; set; }
        public Nullable<decimal> HireItem_Value_New { get; set; }
        public string InsUser { get; set; }
        public Nullable<System.DateTime> InsDate { get; set; }
        public Nullable<decimal> Rec_id_Org { get; set; }
        public string GradeJob_Id { get; set; }
        public string Grade_Id { get; set; }
        public string InsTransUser { get; set; }
        public Nullable<System.DateTime> InsTransDate { get; set; }
        public Nullable<byte> Rec_Status { get; set; }
        public string RowState { get; set; }
        public string GradeJob_IdNew { get; set; }
        public string Grade_IdNew { get; set; }
    }
}
