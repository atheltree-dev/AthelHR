using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HR.Dashboard;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL.HR.Dashboard
{
   public class SalariesChartsDAL : CommonDB
    {

        public List<SalariesSumDL> GetSalariesChartsData()
        {
            List<SalariesSumDL> objectList = new List<SalariesSumDL>();

            string sql = "exec  [dbo].[sp_getSalariesCharts]";  // see these Sp _SPGetOrgChart
            List<SalariesSumDL> list = objPharmaEntities.Database.SqlQuery<SalariesSumDL>(sql).ToList();


            SalariesSumDL objUserMenuDL = new SalariesSumDL();
            objUserMenuDL.AdministrationSalaryRange = new List<AdministrationSalaryRange>();
            objUserMenuDL.DepartmentsSalaryRange = new List<DepartmentsSalaryRange>();

            if (list != null)
            {
                foreach (var obj in list)
                {
                    if (obj.Flag == 1)
                    {
                        objUserMenuDL.DepartmentsSalaryRange.Add(
                            new DepartmentsSalaryRange()
                            {
                                DepartmentsAvgSalary = Convert.ToDecimal(obj.SalaryAmount),
                                DepartmentName = obj.DepartmentName.ToString()
                            });
                       
                    }

                    if (obj.Flag == 2)
                    {
                        objUserMenuDL.AdministrationSalaryRange.Add(
                           new AdministrationSalaryRange()
                           {
                               AdministrationAvegSalary = Convert.ToDecimal(obj.SalaryAmount),
                               AdministrationsName = obj.DepartmentName.ToString()
                           });

                    }
                }

                objectList.Add(objUserMenuDL);
            }

            return objectList;

        }
    }
}
