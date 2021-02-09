using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrRecords.RecordManagement
{
    public class VcationRecordDL
    {
        public Guid Rec_Hdr_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public string Request_Id { get; set; }
        public string Rec_Order_No { get; set; }
        public Guid Rec_Order_HdrId { get; set; }
        public string TransDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string BackDate { get; set; }
        public decimal Vaction_Period { get; set; }
        public string FromStartPeriod { get; set; }
        public string ToEndPeriod { get; set; }
        public string PlaceOfResidence { get; set; }
        public string Reason { get; set; }
        public string InsUser { get; set; }
        public string MessageNotesForEmpeason { get; set; }
        public string HireItem_Id { get; set; }
        public DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public decimal? FreeBalancRequest { get; set; }
        public decimal? ChargeBalancRequest { get; set; }
        public string AcuallBackDate { get; set; }
        public decimal? AcuallVaction_Peiod { get; set; }
        public decimal? Contract_Id { get; set; }
        public decimal? ContractPeriod_Id { get; set; }
        public decimal? Tot_Transferd_Period { get; set; }
        public decimal? Curr_DiscVac_Period { get; set; }
        public decimal? Curr_DiscTransferd_Period { get; set; }
        public decimal? Prev_Vaction_Period { get; set; }
        public decimal? CurrAllowedVacTillDate { get; set; }
        public string Vac_Place_Type { get; set; }
        public decimal? Offical_Vaction_Period { get; set; }
        public decimal? VactionFromPrmEffec { get; set; }
        public byte Confirmed { get; set; }
        public byte RowStatus { get; set; }




    }

    public class VacationData
    {
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public decimal Net_NoOfActuallyVacationDaysTillDate_Col { get; set; }
        public decimal NoOfActuallyVacationDaysTillDate_Col { get; set; }
        public decimal NewTransferedAfterFinishingContract_Col { get; set; }
        public decimal NoOfPerviousAnnaulVacTillDate_Col { get; set; }
        public decimal AllowedVacationBal_Col { get; set; }
        public decimal NoOfTransferAnnaulVacTillDate_Col { get; set; }
        public decimal TotalAvailable { get; set; }
        public decimal Required { get; set; }
        public decimal OfficialVacations { get; set; }
        public decimal VactionFromPrmEffect { get; set; }
        public decimal RemainBalance { get; set; }
        public string FromStartPeriod { get; set; } 
        public string ToEndPeriod { get; set; }
        public decimal Contract_Id { get; set; }
        public decimal ContractPeriod_Id { get; set; }

    }




}
