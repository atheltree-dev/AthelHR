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
    
    public partial class Hr_HiringMonth_ActuallDues_Hdr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hr_HiringMonth_ActuallDues_Hdr()
        {
            this.Hr_HiringMonth_ActuallDues_Dtls = new HashSet<Hr_HiringMonth_ActuallDues_Dtls>();
        }
    
        public System.Guid Rec_Hdr_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string Month_No { get; set; }
        public string TransDate { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public byte Emp_Rec_Status { get; set; }
        public byte Emp_Status { get; set; }
        public byte IsPostedHdr { get; set; }
        public Nullable<byte> Confirmed { get; set; }
        public string ConfirmDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hr_HiringMonth_ActuallDues_Dtls> Hr_HiringMonth_ActuallDues_Dtls { get; set; }
    }
}
