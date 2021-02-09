using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpAllowanceEditRulesDL
    {
        public int? id { get; set; }
        public string FromCity { get; set; }
        public string FromCityName { get; set; }
        public string FromCityNameEn { get; set; }
        public string ToCity { get; set; }
        public string ToCityName { get; set; }
        public string ToCityNameEn { get; set; }
        public decimal Distance { get; set; }
        public byte? CarRent { get; set; }
        public byte? DailyAllowance { get; set; }
        public decimal AllowanceValueLess7Day { get; set; }
        public decimal AllowanceValueMore7Day { get; set; }
        public decimal MaxValueHousingForMangwithoutSeason { get; set; }
        public decimal MaxValueHousingForMangwithinSeason { get; set; }
        public decimal MaxValueHousingForSuperVsorwithoutSeason { get; set; }
        public decimal MaxValueHousingForSuperVsorwithinSeason { get; set; }
        public decimal TransPortValueLess7Day { get; set; }
        public decimal TransPortValueMore7Day { get; set; }
        public byte? NeedAirLine { get; set; }
        public byte? IsEdit { get; set; }
        



    }

}
