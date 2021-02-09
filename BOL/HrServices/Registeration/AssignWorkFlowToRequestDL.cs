using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HrServices.Registeration
{
    public class AssignWorkFlowToRequestDL
    {
        public string Request_Id { set; get; }
        public string Request_Name { set; get; }
        public string Request_NameEn { set; get; }
        public string WorkFlow_Id { set; get; }
        public string WorkFlow_Name { set; get; }
        public string WorkFlow_NameEn { set; get; }
        public int status { set; get; }


    }
}
