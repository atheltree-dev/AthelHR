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
    
    public partial class Hr_EmpBorrow_Dtls
    {
        public System.Guid Dtls_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public System.Guid Hdr_Id { get; set; }
        public string Borrow_Month_No { get; set; }
        public Nullable<decimal> Borrow_Month_Value { get; set; }
        public byte Borrow_Month_Status { get; set; }
        public byte RowId { get; set; }
    
        public virtual Hr_EmpBorrow_Hdr Hr_EmpBorrow_Hdr { get; set; }
    }
}
