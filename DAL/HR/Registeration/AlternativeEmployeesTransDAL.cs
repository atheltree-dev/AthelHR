using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HR.Registeration;
using System.Data.SqlClient;
namespace DAL.HR.Registeration
{
    public class AlternativeEmployeesTransDAL : CommonDB

    {

        public List<AlternativeEmployeesTransDL> GetAll(string Company_Id, string Branch_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<AlternativeEmployeesTransDL> objectList = new List<AlternativeEmployeesTransDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id)};

                var objlist = objPharmaEntities.Database.SqlQuery<AlternativeEmployeesTransDL>("exec dbo._SPAlternativeEmployeesTrans @Company_Id,@Branch_Id",param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);

                if (objlist != null)
                {
                    foreach (var obj in objlist)
                    {
                        AlternativeEmployeesTransDL objAlternativeEmployeesTransDL = new AlternativeEmployeesTransDL();
                        objAlternativeEmployeesTransDL.Company_Id = obj.Company_Id;
                        objAlternativeEmployeesTransDL.Branch_Id = obj.Branch_Id;
                        objAlternativeEmployeesTransDL.Emp_Serial_No = obj.Emp_Serial_No;
                        objAlternativeEmployeesTransDL.Job_Id = obj.Job_Id;
                        objAlternativeEmployeesTransDL.Alternate_Job_Id = obj.Alternate_Job_Id;
                        objAlternativeEmployeesTransDL.FullNameArabic = obj.FullNameArabic;
                        objAlternativeEmployeesTransDL.FullNameEn = obj.FullNameEn;
                        objAlternativeEmployeesTransDL.Alternate_Emp_Serial_No = obj.Alternate_Emp_Serial_No;
                        objAlternativeEmployeesTransDL.Alternate_FullNameArabic = obj.Alternate_FullNameArabic;
                        objAlternativeEmployeesTransDL.Alternate_FullNameEn = obj.Alternate_FullNameEn;
                        objAlternativeEmployeesTransDL.InsUser = obj.InsUser;
                        objAlternativeEmployeesTransDL.Status = obj.Status;
                        objAlternativeEmployeesTransDL.StatusActivate = obj.StatusActivate;
                        objectList.Add(objAlternativeEmployeesTransDL);

                    }
                    return objectList;
                }
                else 
                {
                    return null;
                }
                

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


        }



        public bool SaveData(List<AlternativeEmployeesTransDL> objList)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                int Result = 0 ;
                foreach (var obj in objList)
                {
                    Hr_AlternativeEmployeesTrans ObjForUpdate = (from objLinq in objPharmaEntities.Hr_AlternativeEmployeesTrans
                                                                     where objLinq.Emp_Serial_No == obj.Emp_Serial_No
                                                                     && objLinq.Company_Id == obj.Company_Id && objLinq.Branch_Id == obj.Branch_Id
                                                                   select objLinq).FirstOrDefault();


                    if (ObjForUpdate == null)
                    {
                        Hr_AlternativeEmployeesTrans newobj = new Hr_AlternativeEmployeesTrans();
                        newobj.Company_Id = obj.Company_Id;
                        newobj.Branch_Id = obj.Branch_Id;
                        newobj.Emp_Serial_No = obj.Emp_Serial_No;
                        newobj.Alternate_Emp_Serial_No = obj.Alternate_Emp_Serial_No;
                        newobj.Job_Id = GetJob_IdForEmp(obj.Emp_Serial_No, obj.Company_Id, obj.Branch_Id);
                        newobj.Alternate_Job_Id = GetJob_IdForEmp(obj.Alternate_Emp_Serial_No, obj.Company_Id, obj.Branch_Id);
                        newobj.StatusActivate = obj.StatusActivate;

                        objPharmaEntities.Hr_AlternativeEmployeesTrans.Add(newobj);
                        Result = objPharmaEntities.SaveChanges();

                    }
                    else 
                    {
                        ObjForUpdate.Job_Id = GetJob_IdForEmp(obj.Emp_Serial_No, obj.Company_Id, obj.Branch_Id); 
                        ObjForUpdate.Alternate_Emp_Serial_No = obj.Alternate_Emp_Serial_No;
                        ObjForUpdate.Alternate_Job_Id = GetJob_IdForEmp(obj.Alternate_Emp_Serial_No, obj.Company_Id, obj.Branch_Id);
                        ObjForUpdate.StatusActivate = obj.StatusActivate;
                        Result = objPharmaEntities.SaveChanges();
                    }



                    //if (obj.Emp_Serial_No != -1 && obj.Alternate_Emp_Serial_No != -1)
                    //{
                    //    Hr_AlternativeEmployeesTrans newobj = new Hr_AlternativeEmployeesTrans();
                    //    newobj.Emp_Serial_No = Convert.ToDecimal(obj.Emp_Serial_No);
                    //    newobj.Alternate_Emp_Serial_No = Convert.ToDecimal(obj.Alternate_Emp_Serial_No);
                    //    newobj.Job_Id = obj.Job_Id;
                    //    newobj.Alternate_Job_Id = obj.Alternate_Job_Id;

                    //    objPharmaEntities.Hr_AlternativeEmployeesTrans.Add(newobj);
                    //    Result = objPharmaEntities.SaveChanges();

                    //}
                    //else 
                    //{
                    //    Hr_AlternativeEmployeesTrans ObjForUpdate = (from objLinq in objPharmaEntities.Hr_AlternativeEmployeesTrans
                    //                                                 where objLinq.Emp_Serial_No == Convert.ToDecimal(obj.Emp_Serial_No)
                    //                                                 && objLinq.Company_Id == obj.Company_Id && objLinq.Branch_Id == obj.Branch_Id
                    //                                               select objLinq).FirstOrDefault();
                    //    ObjForUpdate.Alternate_Emp_Serial_No = Convert.ToDecimal(obj.Alternate_Emp_Serial_No);
                    //    ObjForUpdate.Alternate_Job_Id = ObjForUpdate.Alternate_Job_Id;

                    //    Result = objPharmaEntities.SaveChanges();

                    //}

                }

                return (Result > 0);
            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return false;

            }
            finally
            {
                CloseEntityConnection();
            }


        }


        public string GetJob_IdForEmp(decimal Emp_Serial_No ,string strCompany_Id,string strBranch_Id) 
        {
            string StrJobId = "0";

            Hr_Employees ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Employees
                                         where objLinq.Emp_Serial_No == Emp_Serial_No
                                                         && objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id
                                                         select objLinq).FirstOrDefault();
            if (ObjForUpdate!=null)
            {
                StrJobId = ObjForUpdate.Job_Id;
            }

            return StrJobId;


        }


      

    }
}
