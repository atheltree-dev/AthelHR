using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EditEmpBorrowRequestDL
    {
         
        public System.Guid Hdr_Id { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public byte Borrow_Status { get; set; }
        public string BorrowStartDate { get; set; }
        public decimal Borrow_Value { get; set; }
        public string EndContract { get; set; }


    }

    public class EditEmpBorrowDetailsDL
    {
        public System.Guid Hdr_Id { get; set; }
        public Guid Dtls_Id { get; set; }
        public string Borrow_Month_No { get; set; }
        public decimal Borrow_Month_Value { get; set; }
        public byte Borrow_Month_Status { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }

        //public string BorrowStartDate { get; set; }
        //public decimal Borrow_Value { get; set; }

    }


    //public class ListEditBorrowDL
    //{
    //    public Guid Dtls_Id { get; set; }
    //    public Guid Hdr_Id { get; set; }
    // //   public string Borrow_Month_No { get; set; }
    //    public decimal NewBorrow_Month_Value { get; set; }
    //    public byte Borrow_Month_Status { get; set; }

    //}

}
