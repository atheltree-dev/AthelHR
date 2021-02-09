﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpPermissionRequestDL
    {
         
        public System.Guid Rec_Hdr_Id { get; set; }
        public decimal Rec_No { get; set; }
        public string ReferenceNo { get; set; }
        public string Request_Id { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string TransDate { get; set; }
        public string PermissionDate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Reason { get; set; }
        public string MessageNotesForEmp { get; set; }

        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public string Order_Status { get; set; }
        
        public string DocumentPath { get; set; }

        public string RequestTypeName { get; set; }
        public string StatusName { get; set; }
        public string RequestTypeNameEn { get; set; }
        public string StatusNameEn { get; set; }

        public string Permission_Type { get; set; }
        public string Permission_TypeName { get; set; }
        public string Permission_TypeNameEn { get; set; }

        public string Permission_Reason_Id { get; set; }
        public string PermissionReason_Name { get; set; }
        public string PermissionReason_NameEn { get; set; }


        public string Permission_Reason_Sub_Id { get; set; }
        public string PermissionSubReason_Name { get; set; }
        public string PermissionSubReason_NameEn { get; set; }

        

    }
}