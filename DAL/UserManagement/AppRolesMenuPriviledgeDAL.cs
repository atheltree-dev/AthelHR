using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.UserManagement;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
namespace DAL.UserManagement
{
    public class AppRolesMenuPriviledgeDAL:CommonDB
    {
       
        //AthelHREntities objPharmaEntities;
        public AppRolesMenuPriviledgeDAL()
        {
            //objPharmaEntities = new AthelHREntities();
        }


        public List<AppRolesMenuPriviledgeDL> SelectByComapnyAndBranch(string Role_Id, string Company_Id, string Branch_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<AppRolesMenuPriviledgeDL> objectList = new List<AppRolesMenuPriviledgeDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@RoleId", Role_Id)};

                var objlist = objPharmaEntities.Database.SqlQuery<AppRolesMenuPriviledgeDL>("exec  [dbo].[_SPSelectAllRoleMenuPriviledg] @Company_Id,@Branch_Id,@RoleId", param1).ToList();

                foreach (var obj in objlist)
                {
                    AppRolesMenuPriviledgeDL objAppRolesMenuPriviledgeDL = new AppRolesMenuPriviledgeDL();
                    objAppRolesMenuPriviledgeDL.MenuId = obj.MenuId;
                    objAppRolesMenuPriviledgeDL.MenuName = obj.MenuName;
                    objAppRolesMenuPriviledgeDL.MenuNameEn = obj.MenuNameEn;
                    objAppRolesMenuPriviledgeDL.ParentId = obj.ParentId;
                    objAppRolesMenuPriviledgeDL.LevelId = obj.LevelId;
                    objAppRolesMenuPriviledgeDL.IsVisiable = obj.IsVisiable;
                    objAppRolesMenuPriviledgeDL.CanInsert = obj.CanInsert;
                    objAppRolesMenuPriviledgeDL.CanUpdate = obj.CanUpdate;
                    objAppRolesMenuPriviledgeDL.CanDelete = obj.CanDelete;
                    objAppRolesMenuPriviledgeDL.CanSearch = obj.CanSearch;

                    objectList.Add(objAppRolesMenuPriviledgeDL);

                }



                return objectList;

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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


        //public PageRoleDL GetRolePageByUser(string Company_Id, string Branch_Id, string User_Id, string PageName)
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {


        //        OpenEntityConnection();


        //        PageRoleDL objectList = new PageRoleDL();

        //        object[] param1 = { 
        //        new SqlParameter("@Company_Id",Company_Id),
        //        new SqlParameter("@Branch_Id", Branch_Id),
        //        new SqlParameter("@UserId", User_Id),
        //        new SqlParameter("@PageName", PageName)};

        //        var objlist = objPharmaEntities.Database.SqlQuery<PageRoleDL>("exec  [dbo].[_SPGetRolePageByUser] @Company_Id,@Branch_Id,@UserId,@PageName", param1).FirstOrDefault();

        //        if (objlist != null) 
        //        {
        //            objectList.CanInsert = objlist.CanInsert;
        //            objectList.CanUpdate = objlist.CanUpdate;
        //            objectList.CanDelete = objlist.CanDelete;
        //            objectList.CanSearch = objlist.CanSearch;
        //            objectList.PageName = objlist.PageName;
        //        }


        //        return objectList;

        //        //Rec_No ,ReferenceNo ,Request_Id 
        //        //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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

        

        public bool SaveDateRolesMenu(List<AppRolesMenuPriviledge> ListDtls)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            var strErrorMessage = string.Empty;
          
            bool result = true;

          
            try
            {
                if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
                {
                    objPharmaEntities.Database.Connection.Open();
                }

                string strBranch_Id = ListDtls[0].Branch_Id.ToString();
                string strCompany_Id = ListDtls[0].Company_Id.ToString();
                string strRole_Id = ListDtls[0].RoleId.ToString();

                //if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && !String.IsNullOrEmpty(strCompany_Id))
                //{
                //    result = DeleteAppDuesAndDeduct(strBranch_Id, strCompany_Id, strAppSettingType);
                //}


                foreach (AppRolesMenuPriviledge Obj_Dtls in ListDtls)
                {
                    if (Obj_Dtls != null)
                    {

                        AppRolesMenuPriviledge objlist = (from objLinq in objPharmaEntities.AppRolesMenuPriviledges
                                                          where objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id && objLinq.RoleId == strRole_Id
                                                            && objLinq.MenuId == Obj_Dtls.MenuId
                                                            select objLinq).FirstOrDefault();

                        if (objlist != null)
                        {
                            //bool resultupdate = objPharmaEntities.ChangeTracker.HasChanges();
                            //if (resultupdate)
                            //{
                            objlist.IsVisiable = Obj_Dtls.IsVisiable;
                            objlist.CanInsert = Obj_Dtls.CanInsert;
                            objlist.CanUpdate = Obj_Dtls.CanUpdate;
                            objlist.CanDelete = Obj_Dtls.CanDelete;
                            objlist.CanSearch = Obj_Dtls.CanSearch;

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


                            AppRolesMenuPriviledge loclDtls = new AppRolesMenuPriviledge
                            {
                                Branch_Id = Obj_Dtls.Branch_Id,
                                Company_Id = Obj_Dtls.Company_Id,
                                RoleId = Obj_Dtls.RoleId,
                                MenuId = Obj_Dtls.MenuId,
                                IsVisiable = Obj_Dtls.IsVisiable,
                                CanInsert = Obj_Dtls.CanInsert,
                                CanUpdate = Obj_Dtls.CanUpdate,
                                CanDelete = Obj_Dtls.CanDelete,
                                CanSearch = Obj_Dtls.CanSearch,
                            };

                            objPharmaEntities.AppRolesMenuPriviledges.Add(loclDtls);
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


    }
}
