using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrRecords.RecordManagement
{
    public class RecordsConfirmationDL
    {
         
        public Guid Rec_Hdr_Id { get; set; }
        public int Record_ID  { get; set; }
        public string RecordName_En { get; set; }
        public string RecordName_Ar { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string Emp_FullNameArabic { get; set; }
        public string Emp_FullNameEn { get; set; }
        public string TransDate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public decimal Duration { get; set; }
       
       
    }

   

}
