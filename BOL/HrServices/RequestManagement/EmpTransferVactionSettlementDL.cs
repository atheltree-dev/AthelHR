using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpTransferVactionSettlementDL
    {
         
        public System.Guid? LastTransRec_hdr_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public decimal NoOfRestVacDays { get; set; }
        public decimal ContractPeriod_Id { get; set; }
        public decimal Contract_Id { get; set; }
        public string FromStartPeriod { get; set; }
        public string ToEndPeriod { get; set; }
        public decimal NoOfDeservedDays { get; set; }
        public decimal NoOfVacDays { get; set; }

        

    }

}
