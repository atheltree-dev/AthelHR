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
    public class AppUsersMenuPriviledgeDAL:CommonDB
    {
        public class PageUserDL
        {
            public byte CanInsert { set; get; }
            public byte CanUpdate { set; get; }
            public byte CanSearch { set; get; }
            public byte CanDelete { set; get; }
            public string PageName { set; get; }

        }
        //AthelHREntities objPharmaEntities;
        public AppUsersMenuPriviledgeDAL()
        {
            //objPharmaEntities = new AthelHREntities();
        }


        public List<AppUsersMenuPriviledgeDL> SelectByComapnyAndBranch(string User_Id, string Company_Id, string Branch_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<AppUsersMenuPriviledgeDL> objectList = new List<AppUsersMenuPriviledgeDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@UserId", User_Id)};

                var objlist = objPharmaEntities.Database.SqlQuery<AppUsersMenuPriviledgeDL>("exec  [dbo].[_SPSelectAllUserMenuPriviledg] @Company_Id,@Branch_Id,@UserId", param1).ToList();

                foreach (var obj in objlist)
                {
                    AppUsersMenuPriviledgeDL objAppUsersMenuPriviledgeDL = new AppUsersMenuPriviledgeDL();
                    objAppUsersMenuPriviledgeDL.MenuId = obj.MenuId;
                    objAppUsersMenuPriviledgeDL.MenuName = obj.MenuName;
                    objAppUsersMenuPriviledgeDL.MenuNameEn = obj.MenuNameEn;
                    objAppUsersMenuPriviledgeDL.ParentId = obj.ParentId;
                    objAppUsersMenuPriviledgeDL.LevelId = obj.LevelId;
                    objAppUsersMenuPriviledgeDL.IsVisiable = obj.IsVisiable;
                    objAppUsersMenuPriviledgeDL.CanInsert = obj.CanInsert;
                    objAppUsersMenuPriviledgeDL.CanUpdate = obj.CanUpdate;
                    objAppUsersMenuPriviledgeDL.CanDelete = obj.CanDelete;
                    objAppUsersMenuPriviledgeDL.CanSearch = obj.CanSearch;

                    objectList.Add(objAppUsersMenuPriviledgeDL);

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


        public PageUserDL GetUserPageByUser(string Company_Id, string Branch_Id, string User_Id, string PageName)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                PageUserDL objectList = new PageUserDL();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@UserId", User_Id),
                new SqlParameter("@PageName", PageName)};

                var objlist = objPharmaEntities.Database.SqlQuery<PageUserDL>("exec  [dbo].[_SPGetRolePageByUser] @Company_Id,@Branch_Id,@UserId,@PageName", param1).FirstOrDefault();

                if (objlist != null) 
                {
                    objectList.CanInsert = objlist.CanInsert;
                    objectList.CanUpdate = objlist.CanUpdate;
                    objectList.CanDelete = objlist.CanDelete;
                    objectList.CanSearch = objlist.CanSearch;
                    objectList.PageName = objlist.PageName;
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

        

        public bool SaveDateUsersMenu(List<AppUsersMenuPriviledge> ListDtls)
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
                string strUser_Id = ListDtls[0].UserId.ToString();

                //if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && !String.IsNullOrEmpty(strCompany_Id))
                //{
                //    result = DeleteAppDuesAndDeduct(strBranch_Id, strCompany_Id, strAppSettingType);
                //}


                foreach (AppUsersMenuPriviledge Obj_Dtls in ListDtls)
                {
                    if (Obj_Dtls != null)
                    {

                        AppUsersMenuPriviledge objlist = (from objLinq in objPharmaEntities.AppUsersMenuPriviledges
                                                          where objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id && objLinq.UserId == strUser_Id
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


                            AppUsersMenuPriviledge loclDtls = new AppUsersMenuPriviledge
                            {
                                Branch_Id = Obj_Dtls.Branch_Id,
                                Company_Id = Obj_Dtls.Company_Id,
                                UserId = Obj_Dtls.UserId,
                                MenuId = Obj_Dtls.MenuId,
                                IsVisiable = Obj_Dtls.IsVisiable,
                                CanInsert = Obj_Dtls.CanInsert,
                                CanUpdate = Obj_Dtls.CanUpdate,
                                CanDelete = Obj_Dtls.CanDelete,
                                CanSearch = Obj_Dtls.CanSearch,
                            };

                            objPharmaEntities.AppUsersMenuPriviledges.Add(loclDtls);
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
