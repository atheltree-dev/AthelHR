using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HR.Registeration
{
    public class AlternativeEmployeesTransDL
    {
        
        public string Company_Id { set; get; }
        public string Branch_Id { set; get; }
        
            
        public decimal Emp_Serial_No { set; get; }
        public string FullNameArabic { set; get; }
        public string FullNameEn { set; get; }
        public string Job_Id { set; get; }
        public decimal Alternate_Emp_Serial_No { set; get; }
        public string Alternate_FullNameArabic { set; get; }
        public string Alternate_FullNameEn { set; get; }
        public string Alternate_Job_Id { set; get; }
        public int Status { set; get; }
        public string InsUser { set; get; }
        public byte StatusActivate { set; get; }




    }
}
