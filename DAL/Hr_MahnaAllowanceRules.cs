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
    
    public partial class Hr_MahnaAllowanceRules
    {
        public int id { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public Nullable<decimal> Distance { get; set; }
        public Nullable<byte> CarRent { get; set; }
        public Nullable<byte> DailyAllowance { get; set; }
        public Nullable<decimal> AllowanceValueLess7Day { get; set; }
        public Nullable<decimal> AllowanceValueMore7Day { get; set; }
        public Nullable<decimal> MaxValueHousingForMangwithoutSeason { get; set; }
        public Nullable<decimal> MaxValueHousingForMangwithinSeason { get; set; }
        public Nullable<decimal> MaxValueHousingForSuperVsorwithoutSeason { get; set; }
        public Nullable<decimal> MaxValueHousingForSuperVsorwithinSeason { get; set; }
        public Nullable<decimal> TransPortValueLess7Day { get; set; }
        public Nullable<decimal> TransPortValueMore7Day { get; set; }
        public Nullable<byte> NeedAirLine { get; set; }
    }
}
