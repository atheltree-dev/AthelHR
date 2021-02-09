using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpAccomdationFeeFollowUpDL
    {


        public System.Guid Hdr_IdCol { get; set; }

        public string AccomdationFeeDuesDateCol { get; set; }
        public string AccomdationFeeStartDateCol { get; set; }

        public string AccomdationFeeEndDateCol { get; set; }

        public decimal AccomdationFee_ValueCol { get; set; }
        public decimal AccomdationFee_MonthValueCol { get; set; }
        public decimal AccomdationFee_PeriodCol { get; set; }

        public decimal AccomdationFee_ValueCreditTillnowCol { get; set; }

        public decimal EmpSerialNoCol { get; set; }

        public string EmpAccomdationFee_StatusCol { get; set; }
        

    }
}
