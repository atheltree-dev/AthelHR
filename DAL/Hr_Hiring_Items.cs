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
    
    public partial class Hr_Hiring_Items
    {
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string HireItem_Id { get; set; }
        public string HireItem_Name { get; set; }
        public string HireItem_NameEn { get; set; }
        public string HireItem_NameConv { get; set; }
        public byte HireItem_Type { get; set; }
        public byte Account_Type { get; set; }
        public byte Hire_Appear_W_Grade { get; set; }
        public byte Hire_Status { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public byte Rec_Status { get; set; }
        public Nullable<byte> JoinEndOfService { get; set; }
        public Nullable<byte> CalcAnnually { get; set; }
        public Nullable<byte> NotIncludeVacAllownce { get; set; }
        public Nullable<byte> AffectsSalaries { get; set; }
        public byte Hire_AppearOnlyW_Grades { get; set; }
        public Nullable<byte> IsPaymentBorrow { get; set; }
    }
}
