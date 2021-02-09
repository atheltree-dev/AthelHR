using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.TimeAttendance.Registration
{
    public class ShiftsDL
    {
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string ShiftGroup_Id { get; set; }
        public string ShiftGroup_Name { get; set; }
        public string ShiftGroup_NameEn { get; set; }
        public string ShiftGroup_ShortName { get; set; }
        public string ShiftGroup_NameConv { get; set; }
        public string InsUser { get; set; }
        public DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public byte Rec_Status { get; set; }
        public decimal Id { get; set; }
        public byte Row_Status { get; set; }

    }

    public class ShiftsDetailsDL
    {
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string Shift_Id { get; set; }
        public Nullable<System.Guid> Shift_Hdr_Id { get; set; }
        public string Shift_Name { get; set; }
        public string Shift_NameEn { get; set; }
        public string ShortName { get; set; }
        public string Shift_NameConv { get; set; }
        public string From_Time { get; set; }
        public string To_Time { get; set; }
        public Nullable<decimal> Shift_DurationByMin { get; set; }
        public string BreakFrom_Time { get; set; }
        public string BreakTo_Time { get; set; }
        public Nullable<decimal> Break_DurationByMin { get; set; }
        public Nullable<decimal> AllowedPeriodToCalcByMin { get; set; }
        public string InsUser { get; set; }
        public DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public byte Rec_Status { get; set; }
        public string ShiftGroup_Id { get; set; }
        public byte Row_Status { get; set; }


    }
}
