using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpVactionRequestWorkFlowDL
    {
        

        public System.Guid Hdr_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        
       public string EmpComment { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public string Job_NameEn { get; set; }
        public string Job_Name { get; set; }
        public decimal Sender_Serial_No { get; set; }
        public decimal Reciever_Serial_no { get; set; }
        public string Reciever_Arabic_Name { get; set; }
        public string Reciever_English_Name { get; set; }
        public string Reciever_imagePath { get; set; }
        public string Sender_imagePath { get; set; }
        public byte EmpReplay { get; set; }

        public Nullable<System.DateTime> DateReplay { get; set; }
        public  string strDateReplay { get; set; }

        public string EmpReplayStatus { get; set; }
        public string Notes { get; set; }
        public decimal Alternate_Emp_Serial_No { get; set; }
        public string   Alternate_Job_Id { get; set; }
        public string AlternativeJoibNameEn { get; set; }
        public string AlternativeJoibName { get; set; }
        public string ALternativeEmpName { get; set; }
        public string ALternativeEmpNameEn { get; set; }

        

    }
}
