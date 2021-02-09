using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpSecondmentRequestDL
    {
         
        public System.Guid Rec_Hdr_Id { get; set; }
        public decimal Rec_No { get; set; }
        public string ReferenceNo { get; set; }
        public string Request_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string TransDate { get; set; }
        public string FromSecondmentDate { get; set; }
        public string ToSecondmentDate { get; set; }
        public Nullable<decimal> ExpectedValue { get; set; }
        public string Notes { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Reason { get; set; }

        public string SecondmentType { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public string Order_Status { get; set; }
        
        public string DocumentPath { get; set; }

        public string RequestTypeName { get; set; }
        public string StatusName { get; set; }
        public string RequestTypeNameEn { get; set; }
        public string StatusNameEn { get; set; }

    }
}
