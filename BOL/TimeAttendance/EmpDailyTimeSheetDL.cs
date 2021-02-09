using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.TimeAttendance
{
    public class EmpDailyTimeSheetDL
    {
        public Guid Rec_Hdr_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string Transdate { get; set; }
        public string Shift_Id { get; set; }
        public string Shift_Name { get; set; }
        public string Shift_NameEn { get; set; }


        public string Emp_Check_InTime { get; set; }
        public string Emp_Check_OutTime { get; set; }

        public decimal Working_Hours { get; set; }
        public decimal DelyAmountInMinut { get; set; }
        public decimal ExtraAmountInMinut { get; set; }

        
        public decimal OvertimePeriodFrmRqustInMinute { get; set; }
        public decimal PermissionPeriodFrmRqustInMinute { get; set; }
        public string EmpInVacation { get; set; }
        public string ApplyDely { get; set; }
        public string ApplyExtra { get; set; }
        public string ApplyAbsence { get; set; }
        public string FullNameEn { get; set; }
        public string FullNameArabic { get; set; }
         public string DayCode { get; set; }
         public string ShortName { get; set; }
         public string WeekSysDayNameEn { get; set; }
         public string WeekSysDayName { get; set; }
        public string DayType { get; set; }
        public string DayTypeName { get; set; }
        public string DayTypeNameEn { get; set; }
        public string Admin_Id { get; set; }
        public string Dept_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Admin_NameEn { get; set; }
        public string Dept_Name { get; set; }
        public string Dept_NameEn { get; set; }

        public decimal DiffDelyInMinut { get; set; }
        public decimal DiffExtraInMinut { get; set; }


        public Int32 Row_Status { get; set; }
        

    }

    public class UpdateEmpDailyTimeSheetDL 
    {
        public Guid Rec_Hdr_Id { get; set; }

        public Int32 ApplyDely { get; set; }

        public Int32 ApplyExtra { get; set; }

        public Int32 ApplyAbsence { get; set; }

        public Int32 Row_Status { get; set; }
        
    }
}
