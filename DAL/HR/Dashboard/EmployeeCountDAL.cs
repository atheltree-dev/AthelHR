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
using System.Collections;

namespace DAL.HR.Dashboard
{
    public class EmployeeCountDAL:CommonDB
    {
        public List<DataCountDL> GetAllEmployeeData()
        {
            List<DataCountDL> objectList = new List<DataCountDL>();

            string sql = "exec  [dbo].[sp_getEmployeesCount]";  // see these Sp _SPGetOrgChart
            List<DataCountDL> list = objPharmaEntities.Database.SqlQuery<DataCountDL>(sql).ToList();


            DataCountDL objUserMenuDL = new DataCountDL();
            objUserMenuDL.HrEmployeesGender = new List<HrEmployeesGender>();
            objUserMenuDL.HrEmployeesAgeRang = new List<HrEmployeesAgeRang>();
            objUserMenuDL.HrEmployeeStatus = new List<HrEmployeeStatus>();
            objUserMenuDL.HrEmployeesAdministrations = new List<HrEmployeesAdministrations>();
            objUserMenuDL.HrEmployeesInDepartment = new List<HrEmployeesInDepartment>();

            if (list != null)
            {
                foreach (var obj in list)
                {

                   
                    if (obj.Flag == 1)
                    {
                        objUserMenuDL.HrEmployeesGender.Add(
                            new HrEmployeesGender()
                            {
                                EmployeesGenderCount = Convert.ToInt32(obj.Count_),
                                HrEmployeesGenderName = obj.Name.ToString()                              
                            });

                    }

                    if (obj.Flag == 2)
                    {
                        objUserMenuDL.HrEmployeesAgeRang.Add(
                            new HrEmployeesAgeRang()
                            {
                                AgeRangNu = Convert.ToInt32(obj.Count_),
                                AgeRangName = obj.Name.ToString()
                            });
                    }

                    if (obj.Flag == 3)
                    {
                        objUserMenuDL.HrEmployeeStatus.Add(
                            new HrEmployeeStatus()
                            {
                                EmployeeStatusNumber = Convert.ToInt32(obj.Count_),
                                EmployeeStatusName = obj.Name.ToString()
                            });
                    }


                    if (obj.Flag == 4)
                    {
                        objUserMenuDL.HrEmployeesInDepartment.Add(
                              new HrEmployeesInDepartment()
                              {
                                  EmployeesDepartmentNumber = Convert.ToInt32(obj.Count_),
                                  EmployeesDepartmentName = obj.Name.ToString()
                              });
                    }

                    if (obj.Flag == 5)
                    {
                        objUserMenuDL.HrEmployeesAdministrations.Add(
                            new HrEmployeesAdministrations()
                            {
                                EmployeesAdministrationsCount = Convert.ToInt32(obj.Count_),
                                EmployeesAdministrationsName = obj.Name.ToString()
                            });
                    }


                }

                objectList.Add(objUserMenuDL);
            }

            return objectList;

        }
    }
}
