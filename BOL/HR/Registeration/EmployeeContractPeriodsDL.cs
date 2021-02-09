using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HR.Registeration
{
    public class EmployeeContractPeriodsDL
    {

        public string WorkstartingDate { get; set; }
        
        public string FromStartPeriod { get; set; }
        public string ToEndPeriod { get; set; }
        public decimal ContractPeriod_Id { get; set; }
        public decimal Contract_Id { get; set; }
        
    }
}
