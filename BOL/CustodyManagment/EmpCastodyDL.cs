using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.CustodyManagment
{
    public class EmpCastodyDL
    {
        public Guid Hdr_Id { get; set; }
        public string Rec_Id { get; set; }
        public decimal Rec_No { get; set; }        
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public decimal Emp_Serial_No_New { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public string Custody_Id { get; set; }
        public string Transdate { get; set; }
        public string Custody_Name { get; set; }
        public string Custody_NameEn { get; set; }
        public string Custody_Serial_No { get; set; }
        public byte Custody_Status { get; set; }
        public byte Custody_Status_New { get; set; }
        public string Custody_Desc { get; set; }
        public string Custody_Note { get; set; }
        public string Received_Date { get; set; }
        public string Delivery_Date { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public byte IsEdit { get; set; }





    }
}
