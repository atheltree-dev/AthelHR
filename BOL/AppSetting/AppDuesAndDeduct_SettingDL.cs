using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.AppSetting
{
    public class AppDuesAndDeduct_SettingDL
    {
         public int Id { set; get; }
         public string Company_Id { set; get; }
         public string Branch_Id { set; get; }
         public string AppSettingType { set; get; }
         public Nullable<byte> CalcOnType { get; set; }
         public string HireItemId { get; set; }
         public Nullable<byte> Checked { get; set; }
         
        public string HireItem_Name { set; get; }
        public string HireItem_NameEn { set; get; }

        

      


    }
}
