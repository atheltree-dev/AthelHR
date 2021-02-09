using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
namespace DAL.HR.Registeration
{
    public class DisciplinaryProceduresDAL : CommonDB

    {
        public  async Task<int> Insert(Hr_DisciplinaryProcedures objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_DisciplinaryProcedures.Add(objInsert);
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
        public int InsertTask(Hr_DisciplinaryProcedures objInsert)
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


                    objPharmaEntities.Hr_DisciplinaryProcedures.Add(objInsert);
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

        public async Task<bool> Update(Hr_DisciplinaryProcedures objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_DisciplinaryProcedures ObjForUpdate = (from objLinq in objPharmaEntities.Hr_DisciplinaryProcedures
                                            where objLinq.DisciplinaryProcedure_Id == objUpdate.DisciplinaryProcedure_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.DisciplinaryProcedure_Name = objUpdate.DisciplinaryProcedure_Name;
                    ObjForUpdate.DisciplinaryProcedure_NameEn = objUpdate.DisciplinaryProcedure_NameEn;
                    ObjForUpdate.DiscountType = objUpdate.DiscountType;
                    
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
        public bool UpdateTask(Hr_DisciplinaryProcedures objUpdate)
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
                    Hr_DisciplinaryProcedures ObjForUpdate = (from objLinq in objPharmaEntities.Hr_DisciplinaryProcedures
                                            where objLinq.DisciplinaryProcedure_Id == objUpdate.DisciplinaryProcedure_Id
                                            select objLinq).FirstOrDefault();
                    if (ObjForUpdate != null) 
                    {
                    ObjForUpdate.DisciplinaryProcedure_Code = objUpdate.DisciplinaryProcedure_Code;
                    ObjForUpdate.DisciplinaryProcedure_Name = objUpdate.DisciplinaryProcedure_Name;
                    ObjForUpdate.DisciplinaryProcedure_NameEn = objUpdate.DisciplinaryProcedure_NameEn;
                    ObjForUpdate.DiscountType = objUpdate.DiscountType;
                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;

                    rowEffected =  objPharmaEntities.SaveChanges();
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

        public async Task<bool> Delete(Hr_DisciplinaryProcedures objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_DisciplinaryProcedures objForDelete = (from objLinq in objPharmaEntities.Hr_DisciplinaryProcedures
                                            where objLinq.DisciplinaryProcedure_Id == objDelete.DisciplinaryProcedure_Id
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

        public bool DeleteTask(Hr_DisciplinaryProcedures objDelete)
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
                    Hr_DisciplinaryProcedures objForDelete = (from objLinq in objPharmaEntities.Hr_DisciplinaryProcedures
                                            where objLinq.DisciplinaryProcedure_Id == objDelete.DisciplinaryProcedure_Id
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

        public Hr_DisciplinaryProcedures GetById(string DisciplinaryProcedure_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_DisciplinaryProcedures DisciplinaryProceduresForGetEntity = (from objLinq in objPharmaEntities.Hr_DisciplinaryProcedures
                                            where objLinq.DisciplinaryProcedure_Id == DisciplinaryProcedure_ID && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return DisciplinaryProceduresForGetEntity;
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
        public List<Hr_DisciplinaryProcedures> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<Hr_DisciplinaryProcedures> objectList = (from objLinq in objPharmaEntities.Hr_DisciplinaryProcedures
                                            where objLinq.Rec_Status == 0
                                                              orderby objLinq.Id
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
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_DisciplinaryProcedures_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_DisciplinaryProcedures_SelectMaxId()
                //         select anything.DisciplinaryProcedure_Id).Single();
                //foreach (Hr_DisciplinaryProcedures cs in objPharmaEntities.Hr_DisciplinaryProcedures)
                //    maxId = cs.DisciplinaryProcedure_Id;

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 DisciplinaryProcedure_Id  as DisciplinaryProcedure_Id  from Hr_DisciplinaryProcedures  order by replicate('0',15-len(DisciplinaryProcedure_Id))+DisciplinaryProcedure_Id desc").FirstOrDefault<string>();
              
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

        public byte GetDiscountType(string DiscountType) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string result = string.Empty;
            byte resultData;

            OpenEntityConnection();
            string strsql;
            strsql = "select DiscountType  from Hr_DisciplinaryProcedures where  DisciplinaryProcedure_Id = '" + DiscountType + "'";
            resultData = objPharmaEntities.Database.SqlQuery<byte>(strsql).FirstOrDefault<byte>();

           // result = Convert.ToString(resultData);

            return resultData;
        }

    }
}
