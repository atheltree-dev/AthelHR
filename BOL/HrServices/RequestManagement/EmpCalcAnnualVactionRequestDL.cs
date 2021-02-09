using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpCalcAnnualVactionRequestDL
    {


        public string Request_Id_Col { get; set; }
        public string CompanyId_Col { get; set; }
        public string Branch_Id_Col { get; set; }
        public decimal Emp_Serial_No_Col { get; set; }

        public decimal NoOfActuallyVacationDaysTillDate_Col { get; set; }
        public decimal NoOfPerviousAnnaulVacTillDate_Col { get; set; }
        public decimal NoOfTransferAnnaulVacTillDate_Col { get; set; }

        public decimal NoOfWorkingDaysFromVacDuesDate_Col { get; set; }
        public decimal Net_noOfDaysMustbeWorkToTakeVacation_Col { get; set; }
        public decimal Net_NoOfActuallyVacationDaysTillDate_Col { get; set; }
        public decimal AllowedVacationBal_Col { get; set; }
        public decimal NewTransferedAfterFinishingContract_Col { get; set; }

        public decimal VactionFromPrmEffect_Col { get; set; }
        

        public decimal Contract_Id { get; set; }
        public decimal ContractPeriod_Id { get; set; }
        public string FromStartPeriod { get; set; }
        public string ToEndPeriod { get; set; }

      
    }
}
