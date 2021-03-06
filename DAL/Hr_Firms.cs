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
    
    public partial class Hr_Firms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hr_Firms()
        {
            this.Hr_Locations = new HashSet<Hr_Locations>();
        }
    
        public string Firm_Id { get; set; }
        public string Firm_Code { get; set; }
        public string Firm_Name { get; set; }
        public string Firm_NameEn { get; set; }
        public string Firm_NameConv { get; set; }
        public string Firm_AccountNo { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public byte Rec_Status { get; set; }
        public string Prefix { get; set; }
        public string Field_AR { get; set; }
        public string Field_En { get; set; }
        public string Logo_Path { get; set; }
        public Nullable<decimal> ResponsibleEmpId { get; set; }
        public decimal Id { get; set; }
        public string Small_Logo_Path { get; set; }
        public Nullable<byte> IsGroup { get; set; }
        public string GroupId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hr_Locations> Hr_Locations { get; set; }
    }
}
