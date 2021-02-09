using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace DAL.UserManagement
{
    public class MenusDAL:CommonDB
    {
        //AthelHREntities objPharmaEntities;
        public MenusDAL()
        {
            //objPharmaEntities = new AthelHREntities();
        }
        public async Task<int> Insert(APP_Menus  objInsert) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int RowEffected = 0;
            try
            {
                if (objInsert != null) 
                {
                    OpenEntityConnection();

                    objPharmaEntities.APP_Menus.Add(objInsert);
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


        public int InsertTask(APP_Menus objInsert)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

           // int task = Insert(objInsert).Result;
           /// return task;
              int RowEffected = 0;
            try
            {
                if (objInsert != null)
                {
                    OpenEntityConnection();

                    objPharmaEntities.APP_Menus.Add(objInsert);
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

        public async Task<bool> Update(APP_Menus objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                   OpenEntityConnection();
                   APP_Menus ObjForUpdate = (from objLinq in objPharmaEntities.APP_Menus
                                         where objLinq.MenuId == objUpdate.MenuId
                                             select objLinq).FirstOrDefault();
                    ObjForUpdate.MenuName = objUpdate.MenuName;
                    ObjForUpdate.MenuNameEn = objUpdate.MenuNameEn;
                    
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

        public bool UpdateTask(APP_Menus objUpdate)

        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

          //  bool task = Update(objUpdate).Result;
         //   return task;

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    APP_Menus ObjForUpdate = (from objLinq in objPharmaEntities.APP_Menus
                                              where objLinq.MenuId == objUpdate.MenuId
                                              select objLinq).FirstOrDefault();
                    ObjForUpdate.MenuName = objUpdate.MenuName;
                    ObjForUpdate.MenuNameEn = objUpdate.MenuNameEn;

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




        public async Task<bool> Delete(APP_Menus objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                OpenEntityConnection();
                if (objDelete != null) //Definsive Programming
                {

                    APP_Menus objForDelete = (from objLinq in objPharmaEntities.APP_Menus
                                             where objLinq.MenuId == objDelete.MenuId 
                                             select objLinq).FirstOrDefault();
                    objForDelete.isActive = 0;
                    
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
        public bool DeleteTask(APP_Menus objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

         //   bool task = Delete(objDelete).Result;
         //   return task;
            int rowEffected = 0;
            try
            {
                OpenEntityConnection();
                if (objDelete != null) //Definsive Programming
                {

                    APP_Menus objForDelete = (from objLinq in objPharmaEntities.APP_Menus
                                              where objLinq.MenuId == objDelete.MenuId
                                              select objLinq).FirstOrDefault();
                    objForDelete.isActive = 0;

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

        public APP_Menus GetById(string Rec_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                APP_Menus objectForGetEntity = (from objLinq in objPharmaEntities.APP_Menus
                                         where objLinq.MenuId == Rec_ID 

                                            select objLinq).FirstOrDefault();
                return objectForGetEntity;
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
        public List<APP_Menus> GetAll()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                List<APP_Menus> objectList = (from objLinq in objPharmaEntities.APP_Menus
                                              where objLinq.isActive == 1
                                              orderby objLinq.LevelId,objLinq.OrderNo
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
              // object maxId;
                 //maxId = (from anything in objPharmaEntities.SP_Menus_SelectMaxId()
                 //               select anything.MenuId).FirstOrDefault();


               foreach (APP_Menus cs in objPharmaEntities.APP_Menus)
                   maxId= cs.MenuId;


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
