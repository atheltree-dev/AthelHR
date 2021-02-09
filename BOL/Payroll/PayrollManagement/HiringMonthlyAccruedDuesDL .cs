using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Payroll.PayrollManagement
{
    public class HiringMonthlyAccruedDuesDL
    {

     

      //  public Guid Rec_Hdr_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_no { get; set; }
        public string MonthNo { get; set; }
        public string HireItem_Id { get; set; }
        public string HireItem_Name { get; set; }
        public string HireItem_NameEn { get; set; }
        public decimal OpeningBalance_days { get; set; }
        public decimal OpeningBalance_Amount { get; set; }
        public decimal TransAccrued_days { get; set; }
        public decimal TransAccrued_Amount { get; set; }
        public decimal TotalAccrued_days { get; set; }
        public decimal TotalAccrued_Amount { get; set; }
        public decimal PayedAccrued_days { get; set; }
        public decimal PayedAccrued_Amount { get; set; }
        public decimal NetAccrued_days { get; set; }
        public decimal NetAccrued_Amount { get; set; }
        public decimal SalaryDay { get; set; }
        

        // public byte IsPayed { get; set; }


    }
}
