using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.RequestManagement
{
    public class EmpEmploymentExperinceRequestDL
    {

        public System.Guid Dtls_Id { get; set; }
        public decimal Rec_Id { get; set; }
        
        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public string Experience_Id { get; set; }
        public string Notes { get; set; }
        public System.Guid Rec_Hdr_Id { get; set; }
        public string InsUser { get; set; }
        public System.DateTime InsDate { get; set; }
        public int RowId { get; set; }
        
        
    }
}
