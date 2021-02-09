using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrRecords.RecordManagement
{
    public class PermissionRecordDL
    {
         
        public Guid Rec_Hdr_Id { get; set; }
        public decimal Rec_No { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public string TransDate { get; set; }
        public string PermissionDate { get; set; }
        public string Request_Id { get; set; }
        public string Rec_Order_No { get; set; }
        public Guid Rec_Order_HdrId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public decimal Permission_Period { get; set; }
        public string Notes { get; set; }
        public string InsUser { get; set; }
        public DateTime InsDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string DocumentPath { get; set; }
        public string MessageNotesForEmp { get; set; }
        public byte SendToEmpDuesRequest { get; set; }
        public decimal Commissioner_Serial_no { get; set; }
        public decimal Contract_Id { get; set; }
        public decimal ContractPeriod_Id { get; set; }
        public string Permission_Type { get; set; }
        public string PermissionType_Name { get; set; }
        public string PermissionType_NameEn { get; set; }
        public string Permission_Reason_Id { get; set; }
        public string PermissionReason_Name { get; set; }
        public string PermissionReason_NameEn { get; set; }
        public string Permission_Reason_Sub_Id { get; set; }
        public string PermissionSubReason_Name { get; set; }
        public string PermissionSubReason_NameEn { get; set; }
        public byte RecStatus { get; set; }
        public byte Confirmed { get; set; }






    }

   

}
