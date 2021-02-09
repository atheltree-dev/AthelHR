using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpRequestNotifyDL
    {

        public System.Guid NotifyHdrId { get; set; }
        public System.Guid RequestHdrId { get; set; }
        public System.Guid DetailWorkFlowId { get; set; }
        
        public string RequestType { get; set; }
        public byte? RequestGroupType { get; set; }
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string SenderEmpName { get; set;}
        public string SenderEmpNameEn { get; set; }
        public string RequestTypeName { get; set; }        
        public string RequestTypeNameEn { get; set; }
        
        public string JobName { get; set; }
        public string JobNameEn { get; set; }
        public string SenderName { get; set; }
        public string SenderNameEn { get; set; }

        public string CommissionerName { get; set; }
        public string CommissionerNameEn { get; set; }

        public string NotifiyType { get; set; }

        

    }
}
