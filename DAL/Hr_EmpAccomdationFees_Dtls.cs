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
    
    public partial class Hr_EmpAccomdationFees_Dtls
    {
        public System.Guid Dtls_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public System.Guid Hdr_Id { get; set; }
        public string AccomdtionFee_Month_No { get; set; }
        public Nullable<decimal> AccomdtionFee_Month_Value { get; set; }
        public byte AccomdtionFee_Month_Status { get; set; }
        public byte RowId { get; set; }
    }
}
