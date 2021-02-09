using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpCalcVactionRequestDL
    {


        public string Request_Id_Col { get; set; }
        public string CompanyId_Col { get; set; }
        public string Branch_Id_Col { get; set; }
        public decimal Emp_Serial_No_Col { get; set; }
        public string HireDate_Col { get; set; }
        public decimal TakenDay_Col { get; set; }
        public decimal MaxPeriodYearPerRequest_Col { get; set; }
        public decimal MinPeriodYearPerRequest_Col { get; set; }
        
        public string RequestDiscountType_Col { get; set; }
        public decimal RequestRatioValue_Col { get; set; }

        public decimal Contract_Id { get; set; }
        public decimal ContractPeriod_Id { get; set; }
        public string FromStartPeriod { get; set; }
        public string ToEndPeriod { get; set; }

      
    }
}
