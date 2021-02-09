using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.IntegrationGL.Registeration
{
    public class AccuredSettingDL
    {
         public int ? Internal_serial_Id { set; get; }
         public string Company_Id { set; get; }
         public string Branch_Id { set; get; }
         public string HireItem_Id { set; get; }
         public string Accrued_HireItem_Id { set; get; }
         public string Ins_User { set; get; }
         public DateTime Ins_date { set; get; }
         public string AccruedHireitem_Type_Id { set; get; }
         public int Status { get; set; }

    }
}
