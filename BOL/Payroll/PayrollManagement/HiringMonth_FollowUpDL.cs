using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Payroll.PayrollManagement
{
    public class HiringMonth_FollowUpDL
    {

     

        public string HireItem_Id { get; set; }
        public string HireItem_Name { get; set; }
        public string HireItem_NameEn { get; set; }
        public decimal HireItem_Value { get; set; }
        public decimal HireItem_ActuallValue { get; set; }

        public decimal HireItem_DiffValue { get; set; }
        public byte HireItem_Type { get; set; }

        public decimal Emp_Serial_No { get; set; }
        
         public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string MonthNo { get; set; }

        public Guid RecHdr_Id { get; set; }

        public Guid Dtls_Id { get; set; }
        public byte Sal_Month_Status { get; set; }



    }
}
