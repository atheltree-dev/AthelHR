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
    
    public partial class Hr_Locations
    {
        public string Firm_Id { get; set; }
        public string Location_Id { get; set; }
        public string Location_Code { get; set; }
        public string Location_Name { get; set; }
        public string Location_NameEn { get; set; }
        public string Location_NameConv { get; set; }
        public string Location_AccountNo { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public byte Rec_Status { get; set; }
        public string Prefix { get; set; }
        public string Country_Id { get; set; }
        public string City_Id { get; set; }
        public string Currency_Id { get; set; }
        public string StreetName { get; set; }
        public string Buiding_Number { get; set; }
        public string P_O_Box { get; set; }
        public string Postal_Code { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ExtenstionTel1 { get; set; }
        public string ExtenstionTel2 { get; set; }
        public string ExtenstionTel3 { get; set; }
        public Nullable<decimal> ResponsibleEmpId { get; set; }
        public decimal Id { get; set; }
    
        public virtual Hr_Firms Hr_Firms { get; set; }
        public virtual Hr_Locations Hr_Locations1 { get; set; }
        public virtual Hr_Locations Hr_Locations2 { get; set; }
    }
}
