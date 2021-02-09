﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpTransferEmployeeRequestDL
    {
         
        public System.Guid Rec_Hdr_Id { get; set; }
        public decimal Rec_No { get; set; }
        public string ReferenceNo { get; set; }
        public string Request_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string TransDate { get; set; }
        
      
        public string Notes { get; set; }

      

        public string CurrentDept_Id { get; set; }
        public string CurrentAdmin_Id { get; set; }
        public string NewDept_Id { get; set; }
        public string NewAdmin_Id { get; set; }

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
