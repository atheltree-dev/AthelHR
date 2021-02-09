using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HR.Dashboard
{
    public class SalariesSumDL
    {
        public int Flag { get; set; }
        public string DepartmentName { get; set; }
        public Decimal SalaryAmount { get; set; }

        public virtual ICollection<AdministrationSalaryRange> AdministrationSalaryRange { get; set; }
        public virtual ICollection<DepartmentsSalaryRange> DepartmentsSalaryRange { get; set; }
    }
}
