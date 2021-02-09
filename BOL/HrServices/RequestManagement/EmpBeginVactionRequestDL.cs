using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpBeginVactionRequestDL
    {


        
        public decimal VactionPeriodCol { get; set; }
        public decimal FreeVacationCol { get; set; }
        public decimal RestBalanceCol { get; set; }

        public decimal Contract_Id { get; set; }
        public decimal ContractPeriod_Id { get; set; }
        public string ToEndPeriod { get; set; }
         public string FromStartPeriod { get; set; }

        


        
      
    }
}
