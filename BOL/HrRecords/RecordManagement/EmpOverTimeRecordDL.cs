using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrRecords.RecordManagement
{
    public class EmpOverTimeRecordDL
    {
         
        public Guid Rec_Hdr_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public string TransDate { get; set; }
        public string OverTimeDate { get; set; }
        public string Request_Id { get; set; }
        public string Rec_Order_No { get; set; }
        public Guid Rec_Order_HdrId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public decimal OverTime_Period { get; set; }
        public string Notes { get; set; }
        public string InsUser { get; set; }
        public DateTime InsDate { get; set; }
        public string DocumentPath { get; set; }
        public decimal Commissioner_Serial_no { get; set; }
        public string DayType { get; set; }
        public string HireItem_Id { get; set; }
        public byte RecStatus { get; set; }
        public byte Confirmed { get; set; }





    }

    //public class EditEmpBorrowDetailsDL
    //{
    //    public Guid Dtls_Id { get; set; }
    //    public string Borrow_Month_No { get; set; }
    //    public decimal Borrow_Month_Value { get; set; }
    //    public byte Borrow_Month_Status { get; set; }
    //    //public string BorrowStartDate { get; set; }
    //    //public decimal Borrow_Value { get; set; }

    //}


    //public class ListEditBorrowDL
    //{
    //    public Guid Dtls_Id { get; set; }
    //    public Guid Hdr_Id { get; set; }
    // //   public string Borrow_Month_No { get; set; }
    //    public decimal NewBorrow_Month_Value { get; set; }
    //    public byte Borrow_Month_Status { get; set; }

    //}

}
