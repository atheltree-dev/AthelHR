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
    public class AccruedSettingDAL : CommonDB
    {





        public bool SaveAccruedData(List<AccuredSettingDL> objList)
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
                        GL_AccruedHireItemAccountAssign newobj = new GL_AccruedHireItemAccountAssign();
                        newobj.Company_Id = obj.Company_Id;
                        newobj.Branch_Id = obj.Branch_Id;
                        newobj.HireItem_Id = obj.HireItem_Id;
                        newobj.Accrued_HireItem_Id = obj.Accrued_HireItem_Id;
                        newobj.Ins_User =UserNameProperty ;
                        newobj.Ins_date = DateTime.Now;
                        newobj.AccruedHireitem_Type_Id = obj.AccruedHireitem_Type_Id;
                        objPharmaEntities.GL_AccruedHireItemAccountAssign.Add(newobj);
                        Result = objPharmaEntities.SaveChanges();

                }

                    else if (obj.Status == 2)
                    {
                        if ( obj.Internal_serial_Id== null)
                        {
                            GL_AccruedHireItemAccountAssign newobj = new GL_AccruedHireItemAccountAssign();
                            newobj.Company_Id = obj.Company_Id;
                            newobj.Branch_Id = obj.Branch_Id;
                            newobj.HireItem_Id = obj.HireItem_Id;
                            newobj.Accrued_HireItem_Id = obj.Accrued_HireItem_Id;
                            newobj.Ins_User = UserNameProperty;
                            newobj.Ins_date = DateTime.Now;
                            newobj.AccruedHireitem_Type_Id = obj.AccruedHireitem_Type_Id;
                            objPharmaEntities.GL_AccruedHireItemAccountAssign.Add(newobj);
                            Result = objPharmaEntities.SaveChanges();
                        }

                    GL_AccruedHireItemAccountAssign ObjForUpdate = (from objLinq in objPharmaEntities.GL_AccruedHireItemAccountAssign
                                                                    where objLinq.Internal_serial_Id == obj.Internal_serial_Id
                                                                    select objLinq).FirstOrDefault();
                //    ObjForUpdate.Internal_serial_Id =(int) obj.Internal_serial_Id;
                    ObjForUpdate.Company_Id = obj.Company_Id;
                    ObjForUpdate.Branch_Id = obj.Branch_Id;
                    ObjForUpdate.HireItem_Id = obj.HireItem_Id;
                    ObjForUpdate.Accrued_HireItem_Id = obj.Accrued_HireItem_Id;
                    ObjForUpdate.Ins_User = UserNameProperty;
                    ObjForUpdate.Ins_date = DateTime.Now;
                    ObjForUpdate.AccruedHireitem_Type_Id = obj.AccruedHireitem_Type_Id;



                        Result = objPharmaEntities.SaveChanges();

                }

                    else if (obj.Status == 3)
                    {
                        if (obj.Internal_serial_Id != null)
                        {
                            GL_AccruedHireItemAccountAssign ObjForDelete = (from objLinq in objPharmaEntities.GL_AccruedHireItemAccountAssign
                                                                            where objLinq.Internal_serial_Id == obj.Internal_serial_Id
                                                                            select objLinq).FirstOrDefault();
                            if (ObjForDelete != null)
                            {
                                objPharmaEntities.GL_AccruedHireItemAccountAssign.Remove(ObjForDelete);
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



        public List<GlAccruedSettingsDL> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<GlAccruedSettingsDL> objectList = new List<GlAccruedSettingsDL>();
                object[] param1 = {

                new SqlParameter("@AccuredItem",(object)DBNull.Value),
                new SqlParameter("@HireItem",(object)DBNull.Value),
                new SqlParameter("@AccuredHireItem",(object)DBNull.Value)

                };


                var objlist = objPharmaEntities.Database.SqlQuery<GlAccruedSettingsDL>("exec dbo.sp_GetAccruedSettingsSearch @AccuredItem, @HireItem, @AccuredHireItem",param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);


                foreach (var obj in objlist)
                {
                    GlAccruedSettingsDL objGlAccruedSettings = new GlAccruedSettingsDL();
                    objGlAccruedSettings.Internal_serial_Id = obj.Internal_serial_Id;
                    objGlAccruedSettings.Accrued_HireItem_Id = obj.Accrued_HireItem_Id;
                    objGlAccruedSettings.AccruedHireItem_Name = obj.AccruedHireItem_Name;
                    objGlAccruedSettings.AccruedHireItem_NameEN = obj.AccruedHireItem_NameEN;
                    objGlAccruedSettings.AccruedHireitem_Type_Id = obj.AccruedHireitem_Type_Id;
                    objGlAccruedSettings.AccruedHireitem_Type_Name = obj.AccruedHireitem_Type_Name;
                    objGlAccruedSettings.AccruedHireitem_Type_NameEn = obj.AccruedHireitem_Type_NameEn;
                    objGlAccruedSettings.HireItem_Id = obj.HireItem_Id;
                    objGlAccruedSettings.HireItem_Name = obj.HireItem_Name;
                    objGlAccruedSettings.HireItem_NameEn = obj.HireItem_NameEn;


                    objectList.Add(objGlAccruedSettings);

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



        public List<GlAccruedSettingsDL> GetAccuredDataSearch(string AccuredItem, string HireItem, string AccuredHireItem)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<GlAccruedSettingsDL> objectList = new List<GlAccruedSettingsDL>();

                object[] param1 = {

                new SqlParameter("@AccuredItem", AccuredItem !=null?AccuredItem :(object)DBNull.Value),
                new SqlParameter("@HireItem",HireItem!=null?HireItem :(object)DBNull.Value),
                new SqlParameter("@AccuredHireItem",AccuredHireItem!=null?AccuredHireItem :(object)DBNull.Value)
              

                };

                var objlist = objPharmaEntities.Database.SqlQuery<GlAccruedSettingsDL>("exec dbo.sp_GetAccruedSettingsSearch @AccuredItem,@HireItem,@AccuredHireItem",param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);


                foreach (var obj in objlist)
                {
                    GlAccruedSettingsDL objGlAccruedSettings = new GlAccruedSettingsDL();
                    objGlAccruedSettings.Internal_serial_Id = obj.Internal_serial_Id;
                    objGlAccruedSettings.Accrued_HireItem_Id = obj.Accrued_HireItem_Id;
                    objGlAccruedSettings.AccruedHireItem_Name = obj.AccruedHireItem_Name;
                    objGlAccruedSettings.AccruedHireItem_NameEN = obj.AccruedHireItem_NameEN;
                    objGlAccruedSettings.AccruedHireitem_Type_Id = obj.AccruedHireitem_Type_Id;
                    objGlAccruedSettings.AccruedHireitem_Type_Name = obj.AccruedHireitem_Type_Name;
                    objGlAccruedSettings.AccruedHireitem_Type_NameEn = obj.AccruedHireitem_Type_NameEn;
                    objGlAccruedSettings.HireItem_Id = obj.HireItem_Id;
                    objGlAccruedSettings.HireItem_Name = obj.HireItem_Name;
                    objGlAccruedSettings.HireItem_NameEn = obj.HireItem_NameEn;


                    objectList.Add(objGlAccruedSettings);

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
