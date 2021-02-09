using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.TimeAttendance
{
    public class EmpAttendanceDL
    {

        
        public Guid Rec_Hdr_Id { get; set; }
        public Guid Dtls_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string Transdate { get; set; }
        public string Shift_Id { get; set; }
        public string Shift_FromTime { get; set; }
        public string Shift_ToTime { get; set; }
        public string Emp_Check_InTime { get; set; }
        public string Emp_Check_OutTime { get; set; }

        public string BeforeCheck_In { get; set; }
        public decimal BeforeCheck_In_EffectInMin { get; set; }
        public string AfterCheck_In { get; set; }
        public decimal AfterCheck_In_EffectInMin { get; set; }

        public string BeforeCheck_OUT { get; set; }
        public decimal BeforeCheck_OUT_EffectInMin { get; set; }

        public string AfterCheck__OUT { get; set; }
        public decimal AfterCheck__OUT_EffectInMin { get; set; }

        public decimal WorkingPeriodWithShftInMinute { get; set; }

        public string FullNameEn { get; set; }
        public string FullNameArabic { get; set; }
        public string DayTypeName { get; set; }
        public string DayTypeNameEn { get; set; }
        public string Admin_Id { get; set; }
        public string Dept_Id { get; set; }

        public string Shift_Name { get; set; }
        public string Shift_NameEn { get; set; }

        public string Admin_Name { get; set; }
        public string Admin_NameEn { get; set; }


        public string Dept_Name { get; set; }
        public string Dept_NameEn { get; set; }
        public Int32 Row_Status { get; set; }
        

    }

    public class UpdateEmpAttendanceDL 
    {
        public Guid Rec_Hdr_Id { get; set; }
        public Guid Dtls_Id { get; set; }
        public Int32 BeforeCheck_In { get; set; }
        
        public Int32 AfterCheck_In { get; set; }
        
        public Int32 BeforeCheck_OUT { get; set; }
        
        public Int32 AfterCheck__OUT { get; set; }
        public decimal BeforeCheck_In_EffectInMin { get; set; }
        public decimal AfterCheck_In_EffectInMin { get; set; }
        public decimal BeforeCheck_OUT_EffectInMin { get; set; }
        public decimal AfterCheck__OUT_EffectInMin { get; set; }
        public decimal WorkingPeriodWithShftInMinute { get; set; }

        public string Shift_Id { get; set; }
        public string Shift_FromTime { get; set; }
        public string Shift_ToTime { get; set; }

        public Int32 Row_Status { get; set; }
        
    }

    public class GetDetailsShiftAfterCalcDL 
    {
        public decimal BeforeCheck_In_EffectInMin { get; set; }
        public decimal AfterCheck_In_EffectInMin { get; set; }
        public decimal BeforeCheck_OUT_EffectInMin { get; set; }
        public decimal AfterCheck__OUT_EffectInMin { get; set; }
        public decimal WorkingPeriodWithShftInMinute { get; set; }

        public string Shift_Id { get; set; }
        public string Shift_FromTime { get; set; }
        public string Shift_ToTime { get; set; }
        public string ShortName { get; set; }

    }


   

}
