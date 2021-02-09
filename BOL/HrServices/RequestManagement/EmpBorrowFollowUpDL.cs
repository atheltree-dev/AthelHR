using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpBorrowFollowUpDL
    {


        public System.Guid Hdr_IdCol { get; set; }

        public string BorrowDuesDateCol { get; set; }
        public string BorrowStartDateCol { get; set; }

        public string BorrowEndDateCol { get; set; }

        public decimal Borrow_ValueCol { get; set; }
        public decimal Borrow_MonthValueCol { get; set; }
        public decimal Borrow_PeriodCol { get; set; }

        public decimal Borrow_ValueCreditTillnowCol { get; set; }

        public decimal EmpSerialNoCol { get; set; }

        public string EmpBorrow_StatusCol { get; set; }
        

    }
}
