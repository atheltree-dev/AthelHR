using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.IntegrationGL.Registeration
{
    public class EntryFormattingDL
    {
         public  decimal ? Internal_serial_Id { set; get; }
         public string Company_Id { set; get; }
         public string Branch_Id { set; get; }
         public string TransType { set; get; }
         public string TransType_Name { set; get; }
         public string TransType_NameEn { set; get; }
         public string EntryType { set; get; }
         public string Actual_HireItem_Id { set; get; }
         public string CR_Type { set; get; }
         public string CR_Actual_HireItem_Id { set; get; }
         public string CR_HireItem_Name { set; get; }
         public string CR_HireItem_NameEn { set; get; }
         public string Dbt_Type { set; get; }
         public string Dbt_Actual_HireItem_Id { set; get; }
         public string Dbt_HireItem_Name { set; get; }
         public string Dbt_HireItem_NameEn { set; get; }
         public byte Rec_Status { get; set; }
         public int Status { get; set; }
         public DateTime Ins_Date { set; get; }
         public  string Ins_User { set; get; }  

    }
}
