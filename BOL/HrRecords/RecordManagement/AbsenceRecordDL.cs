using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrRecords.RecordManagement
{
    public class AbsenceRecordDL
    {
         
        public Guid Rec_Hdr_Id { get; set; }
        public decimal Rec_No { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public string TransDate { get; set; }
        public string Notes { get; set; }
        public string InsUser { get; set; }
        public DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public byte Confirmed { get; set; }
        public byte RecStatus { get; set; } 
        public DateTime UpdateDate { get; set; }
        public string HireItem_Id { get; set; }








    }

   

}
