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
    
    public partial class Menus
    {
        public decimal Id { get; set; }
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuNameEn { get; set; }
        public Nullable<int> ParentId { get; set; }
        public byte isActive { get; set; }
        public int LevelId { get; set; }
        public string PathUrl { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
