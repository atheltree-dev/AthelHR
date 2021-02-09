using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.TimeAttendance
{
    public class MonthlyEmpActualAttendanceDaysDL
    {


        public decimal Internal_serial_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string FullNameEn { get; set; }
        public string FullNameArabic { get; set; }
        public string Mont_No { get; set; }
        public byte MonthDaysNum { get; set; }
        public byte AttendsDaysNum { get; set; }
        public byte AnnualVacDaysNum { get; set; }
        public byte CompellingVacDaysNum { get; set; }
        public byte SickDasysNum { get; set; }
        public byte VacDaysNumWithoutSalary { get; set; }
        public byte OtherDaysNum { get; set; }
        public byte AbsenceDaysNum { get; set; }
        public byte DaysNumFromStartingContractInThisMonth { get; set; }
        public byte Apporval_Status { get; set; }
        public byte CalculatedDaysNum { get; set; }
        public decimal OvertimePeriodByHour { get; set; }
        public decimal DelayPeriodByHour { get; set; }

        

    }
     

    //public class UpdateEmpAttendanceDL 
    //{
    //    public Guid Rec_Hdr_Id { get; set; }
    //    public Guid Dtls_Id { get; set; }
    //    public Int32 BeforeCheck_In { get; set; }
        
    //    public Int32 AfterCheck_In { get; set; }
        
    //    public Int32 BeforeCheck_OUT { get; set; }
        
    //    public Int32 AfterCheck__OUT { get; set; }
    //    public decimal BeforeCheck_In_EffectInMin { get; set; }
    //    public decimal AfterCheck_In_EffectInMin { get; set; }
    //    public decimal BeforeCheck_OUT_EffectInMin { get; set; }
    //    public decimal AfterCheck__OUT_EffectInMin { get; set; }
    //    public decimal WorkingPeriodWithShftInMinute { get; set; }

    //    public string Shift_Id { get; set; }
    //    public string Shift_FromTime { get; set; }
    //    public string Shift_ToTime { get; set; }

    //    public Int32 Row_Status { get; set; }
        
    //}

    //public class GetDetailsShiftAfterCalcDL 
    //{
    //    public decimal BeforeCheck_In_EffectInMin { get; set; }
    //    public decimal AfterCheck_In_EffectInMin { get; set; }
    //    public decimal BeforeCheck_OUT_EffectInMin { get; set; }
    //    public decimal AfterCheck__OUT_EffectInMin { get; set; }
    //    public decimal WorkingPeriodWithShftInMinute { get; set; }

    //    public string Shift_Id { get; set; }
    //    public string Shift_FromTime { get; set; }
    //    public string Shift_ToTime { get; set; }
    //    public string ShortName { get; set; }

    //}


   

}
