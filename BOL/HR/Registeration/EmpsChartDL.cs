using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HR.Registeration
{

    public class EmpsChartDl
    {
        public string id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string Type { get; set; }
        public string Parent { get; set; }
        public string parent_type { get; set; }
        public string level { get; set; }
        public string childCount { get; set; }
        public string ArJob { get; set; }
        public string EnJob { get; set; }
        public string Image { get; set; }
    }

    public class EmpTreeDL
    {
        public string id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string Type { get; set; }
        public string Parent { get; set; }
        public string parent_type { get; set; }
        public string level { get; set; }
        public string childCount { get; set; }
    }

}
