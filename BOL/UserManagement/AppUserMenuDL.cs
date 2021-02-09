using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.UserManagement
{
   public class AppUserMenuDL
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuNameEn { get; set; }
        public int ParentId { get; set; }
        public int LevelId { get; set; }
        public byte IsVisiable { get; set; }
        public byte CanInsert { get; set; }
        public byte CanUpdate { get; set; }
        public byte CanDelete { get; set; }
        public byte CanSearch { get; set; }
        public string PathUrl { get; set; }
        public string PageName { get; set; }
        public byte isActive { get; set; }
    }
}
