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
    public class EntryFormattingDAL : CommonDB
    {





        public bool SaveEntryFormattingData(List<EntryFormattingDL> objList)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                int Result = 0;
                foreach (var obj in objList)
                {
                    if (obj.Status==0 && obj.Internal_serial_Id !=null)
                    {

                    }
                 
                   else if ( obj.Status ==1 && obj.Internal_serial_Id == null)
                    {
                        GL_AccountPostingFormat newobj = new GL_AccountPostingFormat();
                        newobj.Company_Id = obj.Company_Id;
                        newobj.Branch_Id = obj.Branch_Id;
                        newobj.TransType = obj.TransType;
                        newobj.EntryType = obj.EntryType;
                        newobj.Actual_HireItem_Id = obj.Actual_HireItem_Id;
                        newobj.CR_Type = obj.CR_Type;
                        newobj.CR_Actual_HireItem_Id = obj.CR_Actual_HireItem_Id;
                        newobj.Dbt_Type = obj.Dbt_Type;
                        newobj.Dbt_Actual_HireItem_Id = obj.Dbt_Actual_HireItem_Id;
                        newobj.Ins_User =UserNameProperty ;
                        newobj.Ins_Date = DateTime.Now;
                        newobj.Rec_Status = 0;


                        objPharmaEntities.GL_AccountPostingFormat.Add(newobj);
                        Result = objPharmaEntities.SaveChanges();

                }

                    else if (obj.Status == 2)
                    {
                        if ( obj.Internal_serial_Id== null)
                        {
                            GL_AccountPostingFormat newobj = new GL_AccountPostingFormat();
                            newobj.Company_Id = obj.Company_Id;
                            newobj.Branch_Id = obj.Branch_Id;
                            newobj.TransType = obj.TransType;
                            newobj.EntryType = obj.EntryType;
                            newobj.Actual_HireItem_Id = obj.Actual_HireItem_Id;
                            newobj.CR_Type = obj.CR_Type;
                            newobj.CR_Actual_HireItem_Id = obj.CR_Actual_HireItem_Id;
                            newobj.Dbt_Type = obj.Dbt_Type;
                            newobj.Dbt_Actual_HireItem_Id = obj.Dbt_Actual_HireItem_Id;
                            newobj.Ins_User = UserNameProperty;
                            newobj.Ins_Date = DateTime.Now;
                            newobj.Rec_Status = 0;


                            objPharmaEntities.GL_AccountPostingFormat.Add(newobj);
                            Result = objPharmaEntities.SaveChanges();

                        }
                        else
                        {

                     
                        GL_AccountPostingFormat ObjForUpdate = (from objLinq in objPharmaEntities.GL_AccountPostingFormat
                                                                where objLinq.Internal_serial_Id == obj.Internal_serial_Id
                                                                    select objLinq).FirstOrDefault();
                        if (ObjForUpdate != null) { 

                            //    ObjForUpdate.Internal_serial_Id =(int) obj.Internal_serial_Id;
                    ObjForUpdate.Company_Id = obj.Company_Id;
                    ObjForUpdate.Branch_Id = obj.Branch_Id;
                    ObjForUpdate.TransType = obj.TransType;
                    ObjForUpdate.EntryType = obj.EntryType;
                    ObjForUpdate.Actual_HireItem_Id = obj.Actual_HireItem_Id;
                    ObjForUpdate.CR_Actual_HireItem_Id = obj.CR_Actual_HireItem_Id;
                    ObjForUpdate.Dbt_Actual_HireItem_Id = obj.Dbt_Actual_HireItem_Id;
                    ObjForUpdate.Ins_User = UserNameProperty;
                    ObjForUpdate.Ins_Date = DateTime.Now;
                  



                   Result = objPharmaEntities.SaveChanges();
                        }

                    }
                  }

                    else if (obj.Status == 3)
                    {
                        if (obj.Internal_serial_Id != null)
                        {
                            GL_AccountPostingFormat ObjForDelete = (from objLinq in objPharmaEntities.GL_AccountPostingFormat
                                                                    where objLinq.Internal_serial_Id == obj.Internal_serial_Id
                                                                            select objLinq).FirstOrDefault();
                            if (ObjForDelete != null)
                            {
                                objPharmaEntities.GL_AccountPostingFormat.Remove(ObjForDelete);
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



        public List<EntryFormattingDL> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<EntryFormattingDL> objectList = new List<EntryFormattingDL>();
                object[] param1 = {

                new SqlParameter("@TransType",(object)DBNull.Value),
                new SqlParameter("@EntryType",(object)DBNull.Value),
                new SqlParameter("@CR_Actual_HireItem_Id",(object)DBNull.Value ),
                new SqlParameter("@Dbt_Actual_HireItem_Id",(object)DBNull.Value )

                };


                var objlist = objPharmaEntities.Database.SqlQuery<EntryFormattingDL>("exec dbo.sp_GetAccountPostingFormatSearch @TransType, @EntryType, @CR_Actual_HireItem_Id, @Dbt_Actual_HireItem_Id", param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);


                foreach (var obj in objlist)
                {
                    EntryFormattingDL objEntryFormattingDL = new EntryFormattingDL();
                    objEntryFormattingDL.Internal_serial_Id = obj.Internal_serial_Id;
                    objEntryFormattingDL.TransType = obj.TransType;
                    objEntryFormattingDL.TransType_Name = obj.TransType_Name;
                    objEntryFormattingDL.TransType_NameEn = obj.TransType_NameEn;
                    objEntryFormattingDL.EntryType = obj.EntryType;
                    objEntryFormattingDL.Actual_HireItem_Id = obj.Actual_HireItem_Id;
                    objEntryFormattingDL.CR_Type = obj.CR_Type;
                    objEntryFormattingDL.CR_HireItem_Name = obj.CR_HireItem_Name;
                    objEntryFormattingDL.CR_HireItem_NameEn = obj.CR_HireItem_NameEn;
                    objEntryFormattingDL.CR_Actual_HireItem_Id = obj.CR_Actual_HireItem_Id;
                    objEntryFormattingDL.Dbt_Type = obj.Dbt_Type;
                    objEntryFormattingDL.Dbt_Actual_HireItem_Id = obj.Dbt_Actual_HireItem_Id;
                    objEntryFormattingDL.Dbt_HireItem_Name = obj.Dbt_HireItem_Name;
                    objEntryFormattingDL.Dbt_HireItem_NameEn = obj.Dbt_HireItem_NameEn;
                    objEntryFormattingDL.Ins_Date = obj.Ins_Date;
                    objEntryFormattingDL.Rec_Status = obj.Rec_Status;


                    objectList.Add(objEntryFormattingDL);

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



        public List<EntryFormattingDL> GetDataSearch(string TransType, string EntryType, string CR_Salaryitem, string Dbt_Salaryitem)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            //if (TransType == null) TransType =null;
            //if (EntryType == null) EntryType = null;
            //if (CR_Salaryitem == null) CR_Salaryitem = null;
            //if (Dbt_Salaryitem == null) Dbt_Salaryitem = null;



            try
            {
                OpenEntityConnection();

                List<EntryFormattingDL> objectList = new List<EntryFormattingDL>();

                object[] param1 = {

                new SqlParameter("@TransType", TransType !=null ? TransType:(object)DBNull.Value),
                new SqlParameter("@EntryType",EntryType  !=null ? EntryType:(object)DBNull.Value),
                new SqlParameter("@CR_Actual_HireItem_Id",CR_Salaryitem !=null ? CR_Salaryitem:(object)DBNull.Value ),
                new SqlParameter("@Dbt_Actual_HireItem_Id",Dbt_Salaryitem !=null ? Dbt_Salaryitem:(object)DBNull.Value )

                };

                var objlist = objPharmaEntities.Database.SqlQuery<EntryFormattingDL>("exec dbo.sp_GetAccountPostingFormatSearch @TransType, @EntryType , @CR_Actual_HireItem_Id , @Dbt_Actual_HireItem_Id", param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);


                foreach (var obj in objlist)
                {
                    EntryFormattingDL objEntryFormattingDL = new EntryFormattingDL();
                    objEntryFormattingDL.Internal_serial_Id = obj.Internal_serial_Id;
                    objEntryFormattingDL.TransType = obj.TransType;
                    objEntryFormattingDL.TransType_Name = obj.TransType_Name;
                    objEntryFormattingDL.TransType_NameEn = obj.TransType_NameEn;
                    objEntryFormattingDL.EntryType = obj.EntryType;
                    objEntryFormattingDL.Actual_HireItem_Id = obj.Actual_HireItem_Id;
                    objEntryFormattingDL.CR_Type = obj.CR_Type;
                    objEntryFormattingDL.CR_HireItem_Name = obj.CR_HireItem_Name;
                    objEntryFormattingDL.CR_HireItem_NameEn = obj.CR_HireItem_NameEn;
                    objEntryFormattingDL.CR_Actual_HireItem_Id = obj.CR_Actual_HireItem_Id;
                    objEntryFormattingDL.Dbt_Type = obj.Dbt_Type;
                    objEntryFormattingDL.Dbt_Actual_HireItem_Id = obj.Dbt_Actual_HireItem_Id;
                    objEntryFormattingDL.Dbt_HireItem_Name = obj.Dbt_HireItem_Name;
                    objEntryFormattingDL.Dbt_HireItem_NameEn = obj.Dbt_HireItem_NameEn;
                    objEntryFormattingDL.Ins_Date = obj.Ins_Date;
                    objEntryFormattingDL.Rec_Status = obj.Rec_Status;

                    objectList.Add(objEntryFormattingDL);

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



    }
}
