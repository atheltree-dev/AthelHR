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
    public class RolesDAL : CommonDB
    {


        public async Task<int> Insert(AspNetRoles objInsert) 
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
                    objInsert.Id = GetNewHeaderId().ToString();
                    objPharmaEntities.AspNetRoles.Add(objInsert);
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


        public int InsertTask(AspNetRoles objInsert)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            //int result = Insert(objInsert).Result;
            //return result;

            int RowEffected = 0;
            try
            {
                if (objInsert != null)
                {
                    OpenEntityConnection();


                    objInsert.Id = GetNewHeaderId().ToString();
                    objPharmaEntities.AspNetRoles.Add(objInsert);
                    RowEffected = objPharmaEntities.SaveChanges();
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

        public async Task<bool> Update(AspNetRoles objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    AspNetRoles ObjForUpdate = (from objLinq in objPharmaEntities.AspNetRoles
                                             where objLinq.Id == objUpdate.Id
                                             select objLinq).FirstOrDefault();
                    
                    ObjForUpdate.Name = objUpdate.Name;
                    ObjForUpdate.AppearAllEmp = objUpdate.AppearAllEmp;
                    
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

        public bool UpdateTask(AspNetRoles objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    AspNetRoles ObjForUpdate = (from objLinq in objPharmaEntities.AspNetRoles
                                               where objLinq.Id == objUpdate.Id
                                               select objLinq).FirstOrDefault();
                    if (ObjForUpdate != null) 
                    {
                        ObjForUpdate.Name = objUpdate.Name;
                        ObjForUpdate.AppearAllEmp = objUpdate.AppearAllEmp;

                        rowEffected = objPharmaEntities.SaveChanges();
                    }
                    
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




        //public async Task<bool> Delete(AspNetRole objDelete)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    int rowEffected = 0;
        //    try
        //    {
        //        OpenEntityConnection();
        //        if (objDelete != null) //Definsive Programming
        //        {
        //            string strsql ="delete "
                    
        //            rowEffected = await objPharmaEntities.SaveChangesAsync();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        rowEffected = -1;
        //        ex.InnerException.Message.ToString();
        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }

        //    if (rowEffected > 0)
        //        return true;
        //    else
        //        return false;

        //}
        //public bool DeleteTask(Hr_Users objDelete)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    bool task = Delete(objDelete).Result;
        //    return task;

        //}

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


        public List<AspNetRoles> GetAll()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<AspNetRoles> objlist = new List<AspNetRoles>();
            try
            {
                OpenEntityConnection();

                List<AspNetRoles> objectList = (from objLinq in objPharmaEntities.AspNetRoles
                                             select objLinq).ToList();

                if (objectList != null)
                {
                    foreach (var obj in objectList)
                    {
                        AspNetRoles obj1 = new AspNetRoles();
                        obj1.Id = obj.Id;
                        obj1.Name = obj.Name;
                        obj1.AppearAllEmp = obj.AppearAllEmp;
                        
                        objlist.Add(obj1);

                    }

                }

                return objlist;

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
