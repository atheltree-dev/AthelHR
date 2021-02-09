using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.AppSetting;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.Entity;namespace DAL.AppSetting
{
    public class AppDuesAndDeduct_SettingDAL : CommonDB

    {


        //public bool SaveDateAppDuesAndDeduct(List<AppDuesAndDeduct_Setting> ListDtls)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    var strErrorMessage = string.Empty;
        //    //  ObjWorkFlow_HdrDL.InsUser = "5";

        //    // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
        //    bool result = true;

        //    //using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
        //    //{
        //    try
        //    {
        //        if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //        {
        //            objPharmaEntities.Database.Connection.Open();
        //        }

        //        string strBranch_Id = ListDtls[0].Branch_Id.ToString();
        //        string strCompany_Id = ListDtls[0].Company_Id.ToString();
        //        string strAppSettingType = ListDtls[0].AppSettingType.ToString();

        //        //if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && !String.IsNullOrEmpty(strCompany_Id))
        //        //{
        //        //    result = DeleteAppDuesAndDeduct(strBranch_Id, strCompany_Id, strAppSettingType);
        //        //}

                
        //            foreach (AppDuesAndDeduct_Setting Obj_Dtls in ListDtls)
        //            {
        //                if (Obj_Dtls != null)
        //                {

        //                    AppDuesAndDeduct_Setting objlist = (from objLinq in objPharmaEntities.AppDuesAndDeduct_Setting
        //                                                        where objLinq.Company_Id == Obj_Dtls.Company_Id && objLinq.Branch_Id == Obj_Dtls.Branch_Id && objLinq.AppSettingType == Obj_Dtls.AppSettingType
        //                                                        && objLinq.HireItemId == Obj_Dtls.HireItemId
        //                                                        select objLinq).FirstOrDefault();

        //                       if (objlist !=null)
        //                       {
        //                            //bool resultupdate = objPharmaEntities.ChangeTracker.HasChanges();
        //                            //if (resultupdate)
        //                            //{
        //                                objlist.CalcOnType = Obj_Dtls.CalcOnType;
        //                                objlist.CheckedStatus = Obj_Dtls.CheckedStatus;
        //                                result = objPharmaEntities.SaveChanges() > 0;
        //                            //}
        //                            //else
        //                            //{
        //                            //    return true;
        //                            //}
        //                       }
        //                       else
        //                       {


        //                                AppDuesAndDeduct_Setting loclDtls = new AppDuesAndDeduct_Setting
        //                                {
        //                                    Branch_Id = Obj_Dtls.Branch_Id,
        //                                    Company_Id = Obj_Dtls.Company_Id,
        //                                    AppSettingType = Obj_Dtls.AppSettingType,
        //                                    CalcOnType = Obj_Dtls.CalcOnType,
        //                                    HireItemId = Obj_Dtls.HireItemId,
        //                                    CheckedStatus = Obj_Dtls.CheckedStatus
        //                                };

        //                                objPharmaEntities.AppDuesAndDeduct_Setting.Add(loclDtls);
        //                                //saves all above operations within one transaction
        //                         result= objPharmaEntities.SaveChanges()> 0 ;
        //                   }
        //                    // dbTran.Commit();
        //                    // }



        //                }
        //            }
                

        //        //commit transaction
        //        //  dbTran.Commit();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {


        //        // Retrieve the error messages as a list of strings.
        //        var errorMessages = ex.EntityValidationErrors
        //                .SelectMany(x => x.ValidationErrors)
        //                .Select(x => x.ErrorMessage);

        //        // Join the list to a single string.
        //        var fullErrorMessage = string.Join("; ", errorMessages);

        //        // Combine the original exception message with the new one.
        //        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
        //        strErrorMessage = fullErrorMessage;
        //        // Throw a new DbEntityValidationException with the improved exception message.
        //        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        //        //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
        //        //   dbTran.Rollback();
        //        result = false;

        //    }

        //    catch (Exception ex)
        //    {

        //        //Rollback transaction if exception occurs
        //        //  dbTran.Rollback();
        //        result = false;

        //    }

        //    finally
        //    {
        //        objPharmaEntities.Database.Connection.Close();
        //        //  dbTran.Dispose();

        //        if (!string.IsNullOrEmpty(strErrorMessage))
        //        {
        //            SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        }

        //    }
        //    return result;

        //    //  }

        //}
        public bool SaveDateAppDuesAndDeduct(List<AppDuesAndDeduct_Setting> ListDtls)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            var strErrorMessage = string.Empty;
            //  ObjWorkFlow_HdrDL.InsUser = "5";

            // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
            bool result = true;

            //using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
            //{
            try
            {
                if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
                {
                    objPharmaEntities.Database.Connection.Open();
                }

                string strBranch_Id = ListDtls[0].Branch_Id.ToString();
                string strCompany_Id = ListDtls[0].Company_Id.ToString();
                string strAppSettingType = ListDtls[0].AppSettingType.ToString();

                //if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && !String.IsNullOrEmpty(strCompany_Id))
                //{
                //    result = DeleteAppDuesAndDeduct(strBranch_Id, strCompany_Id, strAppSettingType);
                //}


                foreach (AppDuesAndDeduct_Setting Obj_Dtls in ListDtls)
                {
                    if (Obj_Dtls != null)
                    {

                        AppDuesAndDeduct_Setting objlist = (from objLinq in objPharmaEntities.AppDuesAndDeduct_Setting
                                                            where objLinq.Company_Id == Obj_Dtls.Company_Id && objLinq.Branch_Id == Obj_Dtls.Branch_Id && objLinq.AppSettingType == Obj_Dtls.AppSettingType
                                                            && objLinq.HireItemId == Obj_Dtls.HireItemId
                                                            select objLinq).FirstOrDefault();

                        if (objlist != null)
                        {
                            //bool resultupdate = objPharmaEntities.ChangeTracker.HasChanges();
                            //if (resultupdate)
                            //{
                            objlist.CalcOnType = Obj_Dtls.CalcOnType;
                            objlist.CheckedStatus = Obj_Dtls.CheckedStatus;
                            result = objPharmaEntities.SaveChanges() > 0;
                            result = true;
                            //}
                            //else
                            //{
                            //    return true;
                            //}
                        }
                        else
                        {


                            AppDuesAndDeduct_Setting loclDtls = new AppDuesAndDeduct_Setting
                            {
                                Branch_Id = Obj_Dtls.Branch_Id,
                                Company_Id = Obj_Dtls.Company_Id,
                                AppSettingType = Obj_Dtls.AppSettingType,
                                CalcOnType = Obj_Dtls.CalcOnType,
                                HireItemId = Obj_Dtls.HireItemId,
                                CheckedStatus = Obj_Dtls.CheckedStatus
                            };

                            objPharmaEntities.AppDuesAndDeduct_Setting.Add(loclDtls);
                            //saves all above operations within one transaction
                            result = objPharmaEntities.SaveChanges() > 0;
                        }
                        // dbTran.Commit();
                        // }



                    }
                }


                //commit transaction
                //  dbTran.Commit();
            }
            catch (DbEntityValidationException ex)
            {


                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                strErrorMessage = fullErrorMessage;
                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
                //   dbTran.Rollback();
                result = false;

            }

            catch (Exception ex)
            {

                //Rollback transaction if exception occurs
                //  dbTran.Rollback();
                result = false;

            }

            finally
            {
                objPharmaEntities.Database.Connection.Close();
                //  dbTran.Dispose();

                if (!string.IsNullOrEmpty(strErrorMessage))
                {
                    SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                }

            }
            return result;

            //  }

        }


        public bool DeleteAppDuesAndDeduct(string Branch_Id, string Company_Id, string AppSettingType)
        {
            bool result = true;
            List<AppDuesAndDeduct_Setting> GradeHiringItemToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                GradeHiringItemToDelete = ctx.AppDuesAndDeduct_Setting.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.AppSettingType == AppSettingType).ToList();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                foreach (AppDuesAndDeduct_Setting Obj_Dtls in GradeHiringItemToDelete)
                {
                    if (Obj_Dtls != null)
                    {
                        newContext.Entry(Obj_Dtls).State = System.Data.Entity.EntityState.Deleted;

                        result = newContext.SaveChanges() > 0;

                    }
                }



            }
            return result;

        }


        public List<AppDuesAndDeduct_Setting> SelectAllAppDuesAndDeduct(string Company_Id, string Branch_Id, string AppSettingType)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<AppDuesAndDeduct_Setting> objectList = new List<AppDuesAndDeduct_Setting>();

                var objlist = (from objLinq in objPharmaEntities.AppDuesAndDeduct_Setting
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.AppSettingType == AppSettingType
                               //&& objLinq.Grade_Id == Grade_Id

                                

                               select new
                               {

                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   AppSettingType = objLinq.AppSettingType,
                                   CalcOnType = objLinq.CalcOnType,
                                   HireItemId = objLinq.HireItemId
                                   

                               }).ToList();



                foreach (var obj in objlist)
                {
                    AppDuesAndDeduct_Setting objGradeHiringItemDL = new AppDuesAndDeduct_Setting();

                    objGradeHiringItemDL.Branch_Id = obj.Branch_Id;
                    objGradeHiringItemDL.Company_Id = obj.Company_Id;
                    objGradeHiringItemDL.AppSettingType = obj.AppSettingType;
                    objGradeHiringItemDL.CalcOnType = obj.CalcOnType;
                    objGradeHiringItemDL.HireItemId = obj.HireItemId;

                    objectList.Add(objGradeHiringItemDL);

                }


                return objectList;

                //Rec_No ,ReferenceNo ,BranchAccount_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,BranchAccountTypeName ,StatusName 

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


        public List<AppDuesAndDeduct_SettingDL> SelectAllAppDuesAndDeductBySettingType(string Company_Id, string Branch_Id, string AppSettingType)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                OpenEntityConnection();

            List<AppDuesAndDeduct_SettingDL> objectList = new List<AppDuesAndDeduct_SettingDL>();

              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@AppSettingType", AppSettingType)};

              var objlist = objPharmaEntities.Database.SqlQuery<AppDuesAndDeduct_SettingDL>("exec dbo.GetAppDuesAndDeduct_Setting @Company_Id,@Branch_Id,@AppSettingType", param1).ToList();

              foreach (var obj in objlist)
              {
                  AppDuesAndDeduct_SettingDL objAppDuesAndDeduct_SettingDL = new AppDuesAndDeduct_SettingDL();
                  objAppDuesAndDeduct_SettingDL.Company_Id = obj.Company_Id;
                  objAppDuesAndDeduct_SettingDL.Branch_Id = obj.Branch_Id;
                  objAppDuesAndDeduct_SettingDL.HireItem_NameEn = obj.HireItem_NameEn;
                  objAppDuesAndDeduct_SettingDL.AppSettingType = obj.AppSettingType;
                  objAppDuesAndDeduct_SettingDL.CalcOnType = obj.CalcOnType;
                  objAppDuesAndDeduct_SettingDL.HireItemId = obj.HireItemId;
                  objAppDuesAndDeduct_SettingDL.HireItem_Name = obj.HireItem_Name;
                  objAppDuesAndDeduct_SettingDL.HireItem_NameEn = obj.HireItem_NameEn;
                  objAppDuesAndDeduct_SettingDL.Checked = obj.Checked;
                  
                  objectList.Add(objAppDuesAndDeduct_SettingDL);

              }



              return objectList;

                //Rec_No ,ReferenceNo ,BranchAccount_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,BranchAccountTypeName ,StatusName 

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

        //public AppDuesAndDeduct_SettingDL GetDataByBranchandCompany(string strCompany_Id, string strBranch_Id)
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();


        //    try
        //    {
        //        OpenEntityConnection();

        //        AppDuesAndDeduct_Setting ObjlistAppDuesAndDeduct_Setting = (from objLinq in objPharmaEntities.AppDuesAndDeduct_Setting
        //                                     where objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id
        //                                     select objLinq).FirstOrDefault();

        //        if (ObjlistAppDuesAndDeduct_Setting != null)
        //        {
        //            AppDuesAndDeduct_SettingDL objAppDuesAndDeduct_SettingDL = new AppDuesAndDeduct_SettingDL();

        //            {
        //                objAppDuesAndDeduct_SettingDL.Branch_Id = ObjlistAppDuesAndDeduct_Setting.Branch_Id;
        //                objAppDuesAndDeduct_SettingDL.Company_Id = ObjlistAppDuesAndDeduct_Setting.Company_Id;
        //                objAppDuesAndDeduct_SettingDL.AppSettingType = ObjlistAppDuesAndDeduct_Setting.AppSettingType;
        //                objAppDuesAndDeduct_SettingDL.CalcOnType = ObjlistAppDuesAndDeduct_Setting.CalcOnType;
        //                objAppDuesAndDeduct_SettingDL.HireItemId = ObjlistAppDuesAndDeduct_Setting.HireItemId;


        //            }
        //            return objAppDuesAndDeduct_SettingDL;
        //        }
        //        else
        //        {
        //            return null;
        //        }




        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //        return null;

        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }


        //}



        //public bool SaveData(AppDuesAndDeduct_SettingDL objList)
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();


        //    try
        //    {
        //        OpenEntityConnection();


        //        int Result = 0 ;




        //                AppDuesAndDeduct_Setting ObjForUpdate = (from objLinq in objPharmaEntities.AppDuesAndDeduct_Setting
        //                                                           where objLinq.Company_Id == objList.Company_Id && objLinq.Branch_Id == objList.Branch_Id
        //                                                           && objLinq.AppSettingType== objList.AppSettingType
        //                                                           select objLinq).FirstOrDefault();
        //                if (ObjForUpdate != null)
        //                {
        //                    ObjForUpdate.CalcOnType = objList.CalcOnType;
        //                    ObjForUpdate.HireItemId = objList.HireItemId;
        //                    Result = objPharmaEntities.SaveChanges();

        //                }
        //                else 
        //                {
        //                    if (objList != null)
        //                    {
        //                        AppDuesAndDeduct_Setting loclDtls = new AppDuesAndDeduct_Setting
        //                        {
        //                            Branch_Id = objList.Branch_Id,
        //                            Company_Id = objList.Company_Id,
        //                            AppSettingType = objList.AppSettingType,
        //                            CalcOnType = objList.CalcOnType,
        //                            HireItemId = objList.HireItemId,

        //                        };

        //                        objPharmaEntities.AppDuesAndDeduct_Setting.Add(loclDtls);
        //                        //saves all above operations within one transaction
        //                        Result = objPharmaEntities.SaveChanges();
        //                        return (Result > 0);

        //                    }
        //                    else
        //                        return false;

        //                }


        //        return (Result > 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //        return false;

        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }


        //}



