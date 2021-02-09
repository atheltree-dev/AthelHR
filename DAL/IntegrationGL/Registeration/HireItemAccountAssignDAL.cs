using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.IntegrationGL.Registeration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DAL.IntegrationGL.Registeration
{
    public class HireItemAccountAssignDAL : CommonDB
    {





        public bool SaveData(List<GlAssignAccountDL> objList)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                int Result = 0;
                foreach (var obj in objList)
                {
                    if (obj.Status == 0)
                    {

                    }

                    else if (obj.Status == 1)
                    {
                        GL_HireItemAccountAssign newobj = new GL_HireItemAccountAssign();
                        newobj.Company_Id = obj.Company_Id;
                        newobj.Branch_Id = obj.Branch_Id;
                        newobj.HireItem_Id = obj.HireItem_Id;
                        newobj.AccountNo = obj.AccountNo;
                        newobj.Ins_User = UserNameProperty;
                        newobj.Ins_date = DateTime.Now;
                        newobj.AccountType = obj.AccountType;
                        objPharmaEntities.GL_HireItemAccountAssign.Add(newobj);
                        Result = objPharmaEntities.SaveChanges();

                    }
                    else if (obj.Status == 2)
                    {
                        if (obj.Internal_serial_Id == null)
                        {
                            GL_HireItemAccountAssign newobj = new GL_HireItemAccountAssign();
                            newobj.Company_Id = obj.Company_Id;
                            newobj.Branch_Id = obj.Branch_Id;
                            newobj.HireItem_Id = obj.HireItem_Id;
                            newobj.AccountNo = obj.AccountNo;
                            newobj.Ins_User = UserNameProperty;
                            newobj.Ins_date = DateTime.Now;
                            newobj.AccountType = obj.AccountType;
                            objPharmaEntities.GL_HireItemAccountAssign.Add(newobj);
                            Result = objPharmaEntities.SaveChanges();
                        }

                        GL_HireItemAccountAssign ObjForUpdate = (from objLinq in objPharmaEntities.GL_HireItemAccountAssign
                                                                 where objLinq.Internal_serial_Id == obj.Internal_serial_Id
                                                                        select objLinq).FirstOrDefault();
                        ObjForUpdate.Internal_serial_Id =(int) obj.Internal_serial_Id;
                        ObjForUpdate.Company_Id = obj.Company_Id;
                        ObjForUpdate.Branch_Id = obj.Branch_Id;
                        ObjForUpdate.HireItem_Id = obj.HireItem_Id;
                        ObjForUpdate.AccountNo = obj.AccountNo;
                        ObjForUpdate.Ins_User = UserNameProperty;
                        ObjForUpdate.Ins_date = DateTime.Now;
                        ObjForUpdate.AccountType = obj.AccountType;



                        Result = objPharmaEntities.SaveChanges();

                    }

                    else if (obj.Status == 3)
                    {
                        if (obj.Internal_serial_Id != null)
                        {
                            GL_HireItemAccountAssign ObjForDelete = (from objLinq in objPharmaEntities.GL_HireItemAccountAssign
                                                                     where objLinq.Internal_serial_Id == obj.Internal_serial_Id
                                                                            select objLinq).FirstOrDefault();
                            if (ObjForDelete != null)
                            {
                                objPharmaEntities.GL_HireItemAccountAssign.Remove(ObjForDelete);
                                Result = objPharmaEntities.SaveChanges();
                            }

                        }
                        else
                        {

                        }

                    }
                    else
                    {

                    }

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



        public List<HireItemAccountAssignDL> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<HireItemAccountAssignDL> objectList = new List<HireItemAccountAssignDL>();
                object[] param1 = {

                new SqlParameter("@HireItem",(object)DBNull.Value),
                new SqlParameter("@Account",(object)DBNull.Value)



                };


                var objlist = objPharmaEntities.Database.SqlQuery<HireItemAccountAssignDL>("exec dbo.sp_GetHireItemAccountAssignSearch @HireItem, @Account",param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);


                foreach (var obj in objlist)
                {
                    HireItemAccountAssignDL objHireItemAccountAssign = new HireItemAccountAssignDL();
                    objHireItemAccountAssign.Internal_serial_Id = obj.Internal_serial_Id;
                    objHireItemAccountAssign.Id = obj.Id;
                    objHireItemAccountAssign.AccountName = obj.AccountName;
                    objHireItemAccountAssign.AccountNameEn = obj.AccountNameEn;
                    objHireItemAccountAssign.AccountNo = obj.AccountNo;
                    objHireItemAccountAssign.AccountType = obj.AccountType;
                    objHireItemAccountAssign.HireItem_Id = obj.HireItem_Id;
                    objHireItemAccountAssign.HireItem_Name = obj.HireItem_Name;
                    objHireItemAccountAssign.HireItem_NameEn = obj.HireItem_NameEn;
                    objHireItemAccountAssign.HireItem_Type = obj.HireItem_Type;


                    objectList.Add(objHireItemAccountAssign);

                }


                return objectList;

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

        public List<HireItemAccountAssignDL> GetAccountAssignDataSearch(string HireItem, string Account)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<HireItemAccountAssignDL> objectList = new List<HireItemAccountAssignDL>();
                object[] param1 = {

                new SqlParameter("@HireItem", HireItem !=null?HireItem :(object)DBNull.Value),
                new SqlParameter("@Account",Account !=null?Account :(object)DBNull.Value)
                


                };


                var objlist = objPharmaEntities.Database.SqlQuery<HireItemAccountAssignDL>("exec dbo.sp_GetHireItemAccountAssignSearch @HireItem,@Account",param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);


                foreach (var obj in objlist)
                {
                    HireItemAccountAssignDL objHireItemAccountAssign = new HireItemAccountAssignDL();
                    objHireItemAccountAssign.Internal_serial_Id = obj.Internal_serial_Id;
                    objHireItemAccountAssign.Id = obj.Id;
                    objHireItemAccountAssign.AccountName = obj.AccountName;
                    objHireItemAccountAssign.AccountNameEn = obj.AccountNameEn;
                    objHireItemAccountAssign.AccountNo = obj.AccountNo;
                    objHireItemAccountAssign.AccountType = obj.AccountType;
                    objHireItemAccountAssign.HireItem_Id = obj.HireItem_Id;
                    objHireItemAccountAssign.HireItem_Name = obj.HireItem_Name;
                    objHireItemAccountAssign.HireItem_NameEn = obj.HireItem_NameEn;
                    objHireItemAccountAssign.HireItem_Type = obj.HireItem_Type;


                    objectList.Add(objHireItemAccountAssign);

                }


                return objectList;

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

        public string GetAccountType(string selectedHireItem)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string result = string.Empty;
            byte resultData;

            OpenEntityConnection();
            string strsql;
            strsql = "select HireItem_Type  from Hr_Hiring_Items where  HireItem_Id = '" + selectedHireItem + "'";

           // strsql = "select AccountType  from GL_ChartOfAcc where  AccountNo = '" + selectedAccount + "'";
            resultData = objPharmaEntities.Database.SqlQuery<byte>(strsql).FirstOrDefault<byte>();

            result = Convert.ToString(resultData);

            return result;
        }

    }
}
