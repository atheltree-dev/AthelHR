using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Objects;
using System.Diagnostics;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

using BOL.HR.Registeration;

namespace DAL.HR.Registeration
{
    public class EmployeeContractPeriodsDAL : CommonDB

    {

        public EmployeeContractPeriodsDL GetContractPeriodData(string CompanyId, string Branch_Id, decimal Emp_Serial_No, string StartDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            // int MaxValue = 0;

            EmployeeContractPeriodsDL objEmpEmployeeContractPeriodsDLList = new EmployeeContractPeriodsDL();
            try
            {


                OpenEntityConnection();

                object[] param1 = { 
                new SqlParameter("@Company_Id",CompanyId),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No),
                new SqlParameter("@StartDate", StartDate)};


                string strsql = "select WorkstartingDate,FromStartPeriod,ToEndPeriod,Contract_Id,ContractPeriod_Id from [dbo].[FnTble_get_emp_ContractPeriods] ('" + CompanyId + "','" + Branch_Id + "','" + Emp_Serial_No + "','" + StartDate + "')";
                //var objlist = objPharmaEntities.Database.SqlQuery<EmployeeContractPeriodsDL>("select WorkstartingDate,FromStartPeriod,ToEndPeriod,Contract_Id,ContractPeriod_Id from [dbo].[FnTble_get_emp_ContractPeriods] (@CompanyId,@Branch_Id,@Emp_Serial_No,@StartDate)", param1).FirstOrDefault();
                var objlist = objPharmaEntities.Database.SqlQuery<EmployeeContractPeriodsDL>(strsql).FirstOrDefault();


                if (objlist != null)
                {
                    EmployeeContractPeriodsDL objEmployeeContractPeriodsDLDL = new EmployeeContractPeriodsDL();

                    objEmployeeContractPeriodsDLDL.WorkstartingDate = objlist.WorkstartingDate;
                    objEmployeeContractPeriodsDLDL.FromStartPeriod = objlist.FromStartPeriod;
                    objEmployeeContractPeriodsDLDL.ToEndPeriod = objlist.ToEndPeriod;
                    objEmployeeContractPeriodsDLDL.Contract_Id = objlist.Contract_Id;
                    objEmployeeContractPeriodsDLDL.ContractPeriod_Id = objlist.ContractPeriod_Id;



                    return objEmployeeContractPeriodsDLDL;


                }
                else
                    return null;

                //foreach (var obj in objlist)
                //{
                //    ComboDL objCombDL = new ComboDL();

                //    objCombDL.Id = Convert.ToString(obj.Id);
                //    objCombDL.Name = obj.Name;
                //    objectList.Add(objCombDL);

                //}






            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return null;
            }
            finally
            {
                CloseEntityConnection();
            }
            return objEmpEmployeeContractPeriodsDLList;

        }



    }
}
