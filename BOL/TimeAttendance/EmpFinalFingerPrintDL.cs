using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.TimeAttendance
{
    public class EmpFinalFingerPrintDL
    {
        public Guid Rec_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string TMachineNumber { get; set; }
        public string EnrollNumber { get; set; }
        public string InOutMode { get; set; }
        public string InOutModeName { get; set; }

        public string VerifyMode { get; set; }
        
        public string DateTimeEnroll { get; set; }
        public string transdate { get; set; }
        
        public string FullNameEn { get; set; }
        public string FullNameArabic { get; set; }
        
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }

        public string Admin_Id { get; set; }
        public string Dept_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Admin_NameEn { get; set; }
        public string Dept_Name { get; set; }
        public string Dept_NameEn { get; set; }
        public Int32 Row_Status { get; set; }

        public byte DataInputType { get; set; }



    }

    public class UpdateFinalFingerPrintDL
    {
        public Guid Rec_Id { get; set; }
        public Int32 InOutMode { get; set; }
        public Int32 Row_Status { get; set; }

    }

   
}
