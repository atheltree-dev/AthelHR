using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace DAL.UserManagement
{
    public class UsersDAL:CommonDB
    {

        public class UserRolesDL 
        {
            public string UserId { set; get; }
            public string RoleId { set; get; }
            public string RoleName { set; get; }
            public int CheckedValue { set; get; }
           

        }
        public async Task<int> Insert(Hr_Users objInsert) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int RowEffected = 0;
            try
            {
                if (objInsert != null) 
                {
                //Password: Admin@123
                    OpenEntityConnection();
                    objInsert.Password = Encrypt("user@123456");
                    objPharmaEntities.Hr_Users.Add(objInsert);
                   RowEffected = await objPharmaEntities.SaveChangesAsync();
                }
                
            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                RowEffected = -1;
                ex.InnerException.Message.ToString();
                
                
            }
            finally
            {
                CloseEntityConnection();
            }

            return RowEffected;   
        }
        // Calling the method of using Async
     

        public int InsertTask(Hr_Users objInsert)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int task = Insert(objInsert).Result;
            return task;

        }

        public async Task<bool> Update(Hr_Users objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Users ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Users
                                             where objLinq.UserId == objUpdate.UserId
                                             select objLinq).FirstOrDefault();
                    ObjForUpdate.Password = Encrypt(objUpdate.Password);
                    ObjForUpdate.Email = objUpdate.Email;
                    ObjForUpdate.Emp_Serial_No = objUpdate.Emp_Serial_No;

                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Today;
                    rowEffected = await objPharmaEntities.SaveChangesAsync() ;
                }
                
            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }

            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public bool UpdateTask(Hr_Users objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            bool task = Update(objUpdate).Result;
            return task;

        }

        public async Task<bool> ChangePassword(string strUserid, string strUsername, string strnewpassword)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if ((!string.IsNullOrEmpty(strUserid)) && (!string.IsNullOrEmpty(strUsername)) && (!string.IsNullOrEmpty(strnewpassword))) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Users ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Users
                                             where objLinq.UserId == strUserid && objLinq.UserName == strUsername
                                             select objLinq).FirstOrDefault();

                    ObjForUpdate.Password = Encrypt(strnewpassword);
                    ObjForUpdate.UpdateDate = DateTime.Today;
                    rowEffected = await objPharmaEntities.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }

            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public bool ChangePasswordTask(string strUserid, string strUsername, string strnewpassword)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            bool task = ChangePassword(strUserid, strUsername, strnewpassword).Result;
            return task;

        }

        public async Task<bool> Delete(Hr_Users objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                OpenEntityConnection();
                if (objDelete != null) //Definsive Programming
                {

                    Hr_Users objForDelete = (from objLinq in objPharmaEntities.Hr_Users
                                             where objLinq.UserId == objDelete.UserId && objLinq.UserName == objDelete.UserName
                                             select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Today;
                    rowEffected = await objPharmaEntities.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }

            if (rowEffected > 0)
                return true;
            else
                return false;

        }
        public bool DeleteTask(Hr_Users objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            bool task = Delete(objDelete).Result;
            return task;

        }

        public Hr_Users GetById(string Rec_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_Users ObjForGetEntity = (from objLinq in objPharmaEntities.Hr_Users
                                             where objLinq.UserId == Rec_ID
                                            select objLinq).FirstOrDefault();
                return ObjForGetEntity;
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
        public Hr_Users SelectByNameAndPassword(string UserName, string StrPassword, string StrCompanyId, string StrBranchNo)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                string StrPasswordNew = Encrypt(StrPassword).ToString();

                Hr_Users ObjForGetEntity = (from objLinq in objPharmaEntities.Hr_Users
                                           // where objLinq.UserName == UserName && objLinq.Password == StrPassword
                                            //
                                            where objLinq.UserName == UserName && objLinq.Password == StrPasswordNew
                                            && objLinq.Company_Id == StrCompanyId && objLinq.Branch_Id == StrBranchNo
                                            select objLinq).FirstOrDefault();
                return ObjForGetEntity;
            }
            catch (DbEntityValidationException ex)
            {
                    Exception raise = ex;

                 foreach (var validationErrors in ex.EntityValidationErrors)

                 {

                     foreach (var validationError in validationErrors.ValidationErrors)

                     {

                          string message = string.Format("{0}:{1}",

                              validationErrors.Entry.Entity.ToString(),

                            validationError.ErrorMessage);

                          // raise a new exception nesting

                         // the current instance as InnerException

                         raise = new InvalidOperationException(message, raise);

                        // SaveErrorLog(errorCode, message, UserName, StrClassName, strFunctionName);


                     }

                 }

                 throw raise;

                }
            catch (Exception ex)
            {
                ////Exception raise = ex;

                ////foreach (var validationErrors in ex.EntityValidationErrors)
                ////{

                ////    foreach (var validationError in validationErrors.ValidationErrors)
                ////    {

                ////        string message = string.Format("{0}:{1}",

                ////            validationErrors.Entry.Entity.ToString(),

                ////          validationError.ErrorMessage);

                ////        // raise a new exception nesting

                ////        // the current instance as InnerException

                ////        raise = new InvalidOperationException(message, raise);

                ////        // SaveErrorLog(errorCode, message, UserName, StrClassName, strFunctionName);


                ////    }

                //}

                //throw raise;

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

        public List<Hr_Users> GetAll()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<Hr_Users> objectList = (from objLinq in objPharmaEntities.Hr_Users
                                             select objLinq).ToList();
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


        public string GetNewId()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
             object maxId = null;

            try
            {

                OpenEntityConnection();
              //  object maxId;
                //object maxId = (from anything in objPharmaEntities.SP_Hr_Users_SelectMaxId()
                //                select anything.UserId).FirstOrDefault();


                foreach (Hr_Users cs in objPharmaEntities.Hr_Users)
                    maxId = cs.UserId;


                if (maxId != null)
                {
                    nextId = maxId.ToString();

                }


            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }

            return nextId;
        }
        public List<UserRolesDL> GetUserRoles(string User_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<UserRolesDL> objectList = new List<UserRolesDL>();

                object[] param1 = { 
                //new SqlParameter("@Company_Id",Company_Id),
                //new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@userId", User_Id)};

                var objlist = objPharmaEntities.Database.SqlQuery<UserRolesDL>("exec  [dbo].[_SPGetUserRoles] @userId", param1).ToList();
                if (objlist != null)
                {

                    foreach (var obj in objlist)
                    {
                        UserRolesDL objUserRolesDL = new UserRolesDL();
                        objUserRolesDL.UserId = obj.UserId;
                        objUserRolesDL.RoleId = obj.RoleId;
                        objUserRolesDL.RoleName = obj.RoleName;
                        objUserRolesDL.CheckedValue = obj.CheckedValue;
                        objectList.Add(objUserRolesDL);

                    }
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

        public bool AssignUserToRoles(List<UserRolesDL> ListDtls)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            var strErrorMessage = string.Empty;

            bool result = true;
            int resultdata;

            try
            {
                if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
                {
                    objPharmaEntities.Database.Connection.Open();
                }

               

                // string strBranch_Id = ListDtls[0].Branch_Id.ToString();
                // string strCompany_Id = ListDtls[0].Company_Id.ToString();
                string strUser_Id = ListDtls[0].UserId.ToString();

                object[] param1 = { new SqlParameter("@User_Id",strUser_Id)};

                resultdata = objPharmaEntities.Database.ExecuteSqlCommand("delete from AspNetUserRoles where UserId =@User_Id", param1);


                result = resultdata >= 0;

                string strsql;
                if (result)
                {
                    foreach (UserRolesDL Obj_Dtls in ListDtls)
                    {
                        if (Obj_Dtls != null)
                        {
                            if (Obj_Dtls.CheckedValue == 1) 
                            {
                                object[] param2 = { new SqlParameter("@User_Id", Obj_Dtls.UserId), 
                                                  new SqlParameter("@Role_Id", Obj_Dtls.RoleId)};

                                strsql = "insert into AspNetUserRoles (UserId,RoleId) values ('" + Obj_Dtls.UserId + "','" + Obj_Dtls.RoleId + "')";

                                resultdata = objPharmaEntities.Database.ExecuteSqlCommand("insert into AspNetUserRoles (UserId,RoleId) values (@User_Id,@Role_Id)", param2);

                                result = resultdata > 0;
                            }
                            

                        }

                    }

                }

                return result;
               
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
