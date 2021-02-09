using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Payroll.PayrollManagement
{
    public class HiringEmpReceivableDuesDL
    {

     

        public string HireItem_Id { get; set; }
        public string HireItem_Name { get; set; }
        public string HireItem_NameEn { get; set; }
        public decimal HireItem_Value { get; set; }
        public decimal HireItem_BasicValue { get; set; }
        public decimal HireItem_ReceivableValue { get; set; }
        public decimal NotConfirmHireItem_ReceivableValue { get; set; }
        public decimal HireItem_ValueOrg { get; set; }
        
        public decimal HireItem_DuesValue { get; set; }
        public byte HireItem_Type { get; set; }

        public decimal Emp_Serial_No { get; set; }
        
         public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string MonthNo { get; set; }

        public Guid RecHdr_Id { get; set; }

        public Guid Dtls_Id { get; set; }

        public string TransItemDate { get; set; }
        public string DueDate { get; set; }
        public Guid RecEmpDuesHdr_Id { get; set; }
        public Guid RecRequestHdr_Id { get; set; }

        



    }
}
