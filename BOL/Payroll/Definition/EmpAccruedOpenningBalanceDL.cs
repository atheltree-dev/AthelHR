using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Payroll.Definition
{
    public class EmpAccruedOpenningBalanceDL
    {
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal? Emp_Serial_No { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public string Emp_Code { get; set; }
        public string Hire_Date { get; set; }
        public string StartContract { get; set; }
        public string EndContract { get; set; }
        public string WorkStartingDate { get; set; }
        public decimal TotalWorkingDaysTillNow { get; set; }
        public decimal NoDaysFromStartCntrctTillDate { get; set; }
        public string Month_No { get; set; }


    }

    public class EmpAccruedOpenningBalanceDetailsDL
    {

        public decimal? Emp_Serial_No { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string HireItemId { get; set; }
        public string HireItem_Name { get; set; }
        public string HireItem_NameEn { get; set; }
        public decimal FixedMOnthlyPercentagePerEmp { get; set; }
        public decimal SalDailyPkg { get; set; }
        public decimal VactionPeriod { get; set; }
        public decimal TransferedDays { get; set; }
        public decimal TransferedValues { get; set; }
        public decimal AllowedDaysBalTillDate { get; set; }
        public decimal AllowedBalTillDateValues { get; set; }
        public decimal TotAllowedDaysBalTillDate { get; set; }
        public decimal TotAllowedBalTillDateValues { get; set; }
        public decimal PayedDaysBalTillDate { get; set; }
        public decimal PayedBalTillDateValues { get; set; }
        public decimal RemainDaysBalTillDate { get; set; }
        public decimal RemainBalTillDateValues { get; set; }




    }

    public class EmpAccruedOpenningBalanceSaveDL
    {
        public Guid Rec_Hdr_Id { get;set;}
        public decimal Emp_Serial_No { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string Transdate { get; set; }
        public string MonthNo { get; set; }
        public decimal SalDailyPkg { get; set; }
        public decimal FixedPercntage { get; set; }
        public string Accrued_HireItem_Id { get; set; }
        public decimal HireItemValueBal { get; set; }
        public decimal DaysBal { get; set; }
        public decimal HireItemValueTransfer { get; set; }
        public decimal DaysTransfer { get; set; }
        public decimal HireItemValuePayed { get; set; }
        public decimal DaysPayed { get; set; }
        public decimal HireItemValueRemain { get; set; }
        public decimal DaysRemain { get; set; }
        public byte IsPosted { get; set; }
        public string Ins_User { get; set; }
        public DateTime Ins_Date { get; set; }


    }


}
