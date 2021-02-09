using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HR.Dashboard
{
    public class DataCountDL
    {
        public int Flag { get; set; }
        public int Count_ { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HrEmployeesGender> HrEmployeesGender { get; set; }
        public virtual ICollection<HrEmployeesAgeRang> HrEmployeesAgeRang { get; set; }
        public virtual ICollection<HrEmployeesAdministrations> HrEmployeesAdministrations { get; set; }
        public virtual ICollection<HrEmployeesInDepartment> HrEmployeesInDepartment { get; set; }
        public virtual ICollection<HrEmployeeStatus> HrEmployeeStatus { get; set; }

    }
}
