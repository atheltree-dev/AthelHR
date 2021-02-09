using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.AppSetting
{
    public class AppSettingDL
    {
         public int Id { set; get; }
         public string Company_Id { set; get; }
         public string Branch_Id { set; get; }
         public Nullable<System.Decimal> EmpSerialForDocNotify { set; get; }
         public Nullable<byte> CalcWithGrade { get; set; }
         public Nullable<byte> UseTimeInWorkFlowRequest { get; set; }

         public Nullable<System.Decimal> PerioddayToForwordRequest { set; get; }

         public Nullable<System.Decimal> WorkingHoursPerDay { set; get; }

         public Nullable<byte> ApplyPermissionDiscount { get; set; }

         public Nullable<System.Decimal> PeriodDayToNotifyFinishContract { set; get; }

         public string PayrollDay { set; get; }
         public Nullable<System.Decimal> AllowedPeriodForStopRequestEffect { set; get; }

         public string VacAllownaceBOrA { set; get; }


         public Nullable<byte> chkVacAfterMonth { get; set; }
         public Nullable<byte> chkPaidByLastSal { get; set; }
         public Nullable<byte> chkAbilityTransferVac { get; set; }
         public Nullable<byte> chkAbilityTrncferToNext { get; set; }
         public Nullable<System.Decimal> MaxTrnsferPeriod { set; get; }

         public string VacTransferAllownceSalaryItem { set; get; }
         public string VacAllownceSalaryItem { set; get; }
         public string AbsenceSalaryItem { get; set; }
         public string DelySalaryItem { get; set; }
         public string ExtraSalaryItem { get; set; }
         public string VacTicketHireItem_Id { get; set; }
         public Nullable<System.Decimal> AbsenceCalcWayByDay { get; set; }
         public string SalPrevDuesDHireItem_Id { get; set; }
         public Nullable<byte> IntegratedWithGL { get; set; }
         public string CalcSalDayRateWay { get; set; }
        public Nullable<System.Decimal> SalDayRate { get; set; }
        public string SalCalcWay { get; set; }

        public Nullable<System.Decimal> MaxallowedTransferdays { get; set; }
        public string FlightRservationManEmail { get; set; }
        public string CustomerCompany_Code { get; set; }
        public Nullable<System.Decimal> PeriodDayToNotifyFinishTesting { set; get; }

        







    }
}
