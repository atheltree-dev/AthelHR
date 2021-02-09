using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.IntegrationGL.Registeration
{

    public class GlAssignAccountDL
    {
        public int ? Internal_serial_Id { set; get; }
        public string Company_Id { set; get; }
        public string Branch_Id { set; get; }
        public string HireItem_Id { set; get; }
        public string AccountNo { set; get; }
        public string Ins_User { set; get; }
        public byte AccountType { set; get; }
        public DateTime Ins_date { set; get; }
        public int Status { set; get; }
    }

}