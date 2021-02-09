using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.UserManagement
{
   public class AppRolesMenuPriviledgeDL
    {
       public string MenuId { get; set; }
       public string MenuName { get; set; }
       public string MenuNameEn { get; set; }
       public int ParentId { get; set; }
       public int LevelId { get; set; }
       public int IsVisiable { get; set; }
       public int CanInsert { get; set; }
       public int CanUpdate { get; set; }
       public int CanDelete { get; set; }
       public int CanSearch { get; set; }

       
      
    }
}
