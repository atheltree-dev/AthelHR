using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpAllowanceRequestDL
    {

        public System.Guid Rec_Hdr_Id { get; set; }
        public decimal Rec_No { get; set; }
        public string ReferenceNo { get; set; }
        public string Request_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string Project_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string TransDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public string Order_Status { get; set; }
        public string DocumentPath { get; set; }
        public string MessageNotesForEmp { get; set; }
        public decimal Contract_Id { get; set; }
        public decimal ContractPeriod_Id { get; set; }
        public decimal Commissioner_Serial_no { get; set; }
        public string Allowance_Type { get; set; }
        public string Allowance_Method_Type { get; set; }
        public string GradeJob_Id { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public decimal? MissionDays { get; set; }
        public decimal? DailyAllowance { get; set; }
        public decimal? HousingAllowance { get; set; }
        public string TransportUsedType { get; set; }
        public decimal? TransportAllowance { get; set; }
        public byte? IsBookingFlight { get; set; }
        public byte? IsSession { get; set; }
        public decimal? ExpectedTotalValue { get; set; }
        public string RequestTypeName { get; set; }
        public string StatusName { get; set; }
        public string RequestTypeNameEn { get; set; }
        public string StatusNameEn { get; set; }
        public decimal? CitiesDistance { get; set; }


    }

    public class EmpAllowanceRulesDL
    {
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string GradeJob_Id { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int PeriodByDays { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public decimal? CitiesDistance { get; set; }
        public byte? CarRent { get; set; }
        public byte? DailyAllowance { get; set; }
        public decimal? DailyAllowanceValue { get; set; }
        public decimal?  HousingAllowanceValue { get; set; }
        public decimal? TransPortAllowanceValue { get; set; }
        public byte NeedAirLine { get; set; }


    }


    public class EmpAllowanceRecordDL
    {
        public System.Guid Rec_Hdr_Id { get; set; }
        public decimal Rec_No { get; set; }
        public string ReferenceNo { get; set; }
        public string Request_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string Project_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string Rec_Order_No { get; set; }
        public System.Guid Rec_Order_HdrId { get; set; }
        public string TransDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Notes { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public string Order_Status { get; set; }
        public string DocumentPath { get; set; }
        public decimal Commissioner_Serial_no { get; set; }
        public string MessageNotesForEmp { get; set; }
        public decimal Contract_Id { get; set; }
        public decimal ContractPeriod_Id { get; set; }
        public string Allowance_Type { get; set; }
        public string Allowance_Method_Type { get; set; }
        public string GradeJob_Id { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public decimal? MissionDays { get; set; }
        public decimal? DailyAllowance { get; set; }
        public decimal? HousingAllowance { get; set; }
        public string TransportUsedType { get; set; }
        public decimal? TransportAllowance { get; set; }
        public byte? IsBookingFlight { get; set; }
        public byte? IsSession { get; set; }
        public decimal? ExpectedTotalValue { get; set; }
        public decimal? ActualDailyAllowance { get; set; }
        public decimal? ActualHousingAllowance { get; set; }
        public decimal? ActualTransportAllowance { get; set; }
        public decimal? ActualFuelAllowance { get; set; }
        public string HousingAllowanceAttach { get; set; }
        public string TransportAllowanceAttach { get; set; }
        public string FuelAllowanceAttach { get; set; }
        public byte IsActualDone { get; set; }
        public decimal DirectManagerEmp_Serial_No { get; set; }
        public byte ManagerConfirmed { get; set; }
        public string ManagerComment { get; set; }
        public string ManagerCommentDate { get; set; }
        public decimal HrManagerEmp_Serial_No { get; set; }
        public byte HRMangerConfirmed { get; set; }
        public string HRMangerComment { get; set; }
        public string HRMangerCommentDate { get; set; }
        public string DailyNotes { get; set; }
        public string HousingNotes { get; set; }
        public string TransportNotes { get; set; }
        public string FuelNotes { get; set; }
        public decimal? CitiesDistance { get; set; }




    }


}
