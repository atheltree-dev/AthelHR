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
    
    public partial class Hr_Companies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hr_Companies()
        {
            this.Hr_Branches = new HashSet<Hr_Branches>();
            this.Hr_Employees = new HashSet<Hr_Employees>();
            this.Hr_Shifts = new HashSet<Hr_Shifts>();
        }
    
        public string Company_Id { get; set; }
        public string Company_Code { get; set; }
        public string Company_Name { get; set; }
        public string Company_NameEn { get; set; }
        public string Company_NameConv { get; set; }
        public string Company_AccountNo { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hr_Branches> Hr_Branches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hr_Employees> Hr_Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hr_Shifts> Hr_Shifts { get; set; }
    }
}