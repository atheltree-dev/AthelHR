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
    
    public partial class Hr_Users
    {
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public byte Rec_Status { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public Nullable<System.DateTime> Last_update_pass_date { get; set; }
        public Nullable<decimal> Failed_count { get; set; }
        public string User_admin { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
    }
}
