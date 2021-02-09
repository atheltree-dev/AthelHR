using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
namespace DAL.HR.Registeration
{
  public  class PermissionSubReasonsDAL:CommonDB

    {
        public  async Task<int> Insert(Hr_PermissionSubReasons objInsert) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int RowEffected = 0;
            try
            {
                if (objInsert != null)
                {
                    OpenEntityConnection();
                    objInsert.InsDate = DateTime.Now;//DateTime.Today;
                    
                    
                    objPharmaEntities.Hr_PermissionSubReasons.Add(objInsert);
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
        //public  int test() {
        //    int task =  Insert().Result;
        //    return task;
         
        //}
        public int InsertTask(Hr_PermissionSubReasons objInsert)
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
                    objInsert.InsDate = DateTime.Now;//DateTime.Today;


                    objPharmaEntities.Hr_PermissionSubReasons.Add(objInsert);
                    RowEffected =  objPharmaEntities.SaveChanges();
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

        public async Task<bool> Update(Hr_PermissionSubReasons objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_PermissionSubReasons ObjForUpdate = (from objLinq in objPharmaEntities.Hr_PermissionSubReasons
                                            where objLinq.PermissionSubReason_Id == objUpdate.PermissionSubReason_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.PermissionSubReason_Name = objUpdate.PermissionSubReason_Name;
                    ObjForUpdate.PermissionSubReason_NameEn = objUpdate.PermissionSubReason_NameEn;
                    ObjForUpdate.PermissionReason_Id = objUpdate.PermissionReason_Id;
                    ObjForUpdate.PermissionSubReason_Code = objUpdate.PermissionSubReason_Code;
                    ObjForUpdate.Permission_Type = objUpdate.Permission_Type;
                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;
                    

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
        public bool UpdateTask(Hr_PermissionSubReasons objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

           // bool task = Update(objInsert).Result;
            //return task;
            int rowEffected = 0;
            try
            {

                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_PermissionSubReasons ObjForUpdate = (from objLinq in objPharmaEntities.Hr_PermissionSubReasons
                                            where objLinq.PermissionSubReason_Id == objUpdate.PermissionSubReason_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.PermissionSubReason_Name = objUpdate.PermissionSubReason_Name;
                    ObjForUpdate.PermissionSubReason_NameEn = objUpdate.PermissionSubReason_NameEn;
                    ObjForUpdate.PermissionReason_Id = objUpdate.PermissionReason_Id;
                    ObjForUpdate.PermissionSubReason_Code = objUpdate.PermissionSubReason_Code;
                    ObjForUpdate.Permission_Type = objUpdate.Permission_Type;
                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;

                    rowEffected =  objPharmaEntities.SaveChanges();
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

        public async Task<bool> Delete(Hr_PermissionSubReasons objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_PermissionSubReasons objForDelete = (from objLinq in objPharmaEntities.Hr_PermissionSubReasons
                                            where objLinq.PermissionSubReason_Id == objDelete.PermissionSubReason_Id
                                            select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

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

        public bool DeleteTask(Hr_PermissionSubReasons objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

           // bool task = Delete(objInsert).Result;
           // return task;
            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_PermissionSubReasons objForDelete = (from objLinq in objPharmaEntities.Hr_PermissionSubReasons
                                            where objLinq.PermissionSubReason_Id == objDelete.PermissionSubReason_Id
                                            select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected =  objPharmaEntities.SaveChanges();
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

        public Hr_PermissionSubReasons GetById(string PermissionSubReason_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_PermissionSubReasons PermissionSubReasonsForGetEntity = (from objLinq in objPharmaEntities.Hr_PermissionSubReasons
                                            where objLinq.PermissionSubReason_Id == PermissionSubReason_ID && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return PermissionSubReasonsForGetEntity;
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
        public List<Hr_PermissionSubReasons> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<Hr_PermissionSubReasons> objlist = new List<Hr_PermissionSubReasons>();
            try
            {
                OpenEntityConnection();

                List<Hr_PermissionSubReasons> objectList = (from objLinq in objPharmaEntities.Hr_PermissionSubReasons
                                              where objLinq.Rec_Status == 0
                                              orderby objLinq.Id
                                              select objLinq).ToList();
                //PermissionSubReason_Id,PermissionSubReason_Name,PermissionSubReason_NameEn,PermissionSubReason_NameConv,PermissionReason_Id,PermissionSubReason_Code,InsUser,InsDate,UpdateUser,UpdateDate,DeleteUser,DeleteDate,Rec_Status


                //string sql = "select *  from Hr_PermissionSubReasons where Rec_Status = 0  order by replicate('0',15-len(PermissionSubReason_Id))+PermissionSubReason_Id ";

                //List<Hr_PermissionSubReasons> objectlist = objPharmaEntities.Database.SqlQuery<Hr_PermissionSubReasons>(sql).ToList();



                if (objectList != null)
                {
                    foreach (var obj in objectList)
                    {
                        Hr_PermissionSubReasons obj1 = new Hr_PermissionSubReasons();
                        obj1.PermissionSubReason_Id = obj.PermissionSubReason_Id;
                        obj1.PermissionSubReason_Name = obj.PermissionSubReason_Name;
                        obj1.PermissionSubReason_NameEn = obj.PermissionSubReason_NameEn;
                        obj1.PermissionSubReason_NameConv = obj.PermissionSubReason_NameConv;
                        obj1.PermissionReason_Id = obj.PermissionReason_Id;
                        obj1.Permission_Type = obj.Permission_Type;
                        obj1.PermissionSubReason_Code = obj.PermissionSubReason_Code;
                        objlist.Add(obj1);

                    }

                }

                return objlist;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex) 
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

                      


                    }

                }

                throw raise;
            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                Exception raise = ex;




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
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_PermissionSubReasons_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_PermissionSubReasons_SelectMaxId()
                //         select anything.PermissionSubReason_Id).Single();
                //foreach (Hr_PermissionSubReasons cs in objPharmaEntities.Hr_PermissionSubReasons)
                //    maxId = cs.PermissionSubReason_Id;

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 PermissionSubReason_Id  as PermissionSubReason_Id  from Hr_PermissionSubReasons  order by replicate('0',15-len(PermissionSubReason_Id))+PermissionSubReason_Id desc").FirstOrDefault<string>();
              
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

    }
}
