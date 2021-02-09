using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
namespace DAL.HR.Registeration
{
  public  class DocumentTypesDAL:CommonDB

    {
        public  async Task<int> Insert(Hr_DocumentTypes objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_DocumentTypes.Add(objInsert);
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
        public int InsertTask(Hr_DocumentTypes objInsert)
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


                    objPharmaEntities.Hr_DocumentTypes.Add(objInsert);
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

        public async Task<bool> Update(Hr_DocumentTypes objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_DocumentTypes ObjForUpdate = (from objLinq in objPharmaEntities.Hr_DocumentTypes
                                            where objLinq.Doc_Type_Id == objUpdate.Doc_Type_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.Doc_Type_Name = objUpdate.Doc_Type_Name;
                    ObjForUpdate.Doc_Type_NameEn = objUpdate.Doc_Type_NameEn;
                    ObjForUpdate.Doc_Type = objUpdate.Doc_Type;
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
        public bool UpdateTask(Hr_DocumentTypes objUpdate)
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
                    Hr_DocumentTypes ObjForUpdate = (from objLinq in objPharmaEntities.Hr_DocumentTypes
                                            where objLinq.Doc_Type_Id == objUpdate.Doc_Type_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.Doc_Type_Name = objUpdate.Doc_Type_Name;
                    ObjForUpdate.Doc_Type_NameEn = objUpdate.Doc_Type_NameEn;
                    ObjForUpdate.Doc_Type = objUpdate.Doc_Type;
                    ObjForUpdate.Doc_Type_Code = objUpdate.Doc_Type_Code;
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

        public async Task<bool> Delete(Hr_DocumentTypes objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_DocumentTypes objForDelete = (from objLinq in objPharmaEntities.Hr_DocumentTypes
                                            where objLinq.Doc_Type_Id == objDelete.Doc_Type_Id
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

        public bool DeleteTask(Hr_DocumentTypes objDelete)
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
                    Hr_DocumentTypes objForDelete = (from objLinq in objPharmaEntities.Hr_DocumentTypes
                                            where objLinq.Doc_Type_Id == objDelete.Doc_Type_Id
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

        public Hr_DocumentTypes GetById(string Doc_Type_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_DocumentTypes DocumentTypesForGetEntity = (from objLinq in objPharmaEntities.Hr_DocumentTypes
                                            where objLinq.Doc_Type_Id == Doc_Type_ID && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return DocumentTypesForGetEntity;
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
        public List<Hr_DocumentTypes> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<Hr_DocumentTypes> objlist = new List<Hr_DocumentTypes>();

                string sql = " Select Doc_Type_Id,Doc_Type_Code,Doc_Type_Name,Doc_Type_NameEn,Doc_Type,Doc_Type_NameConv,InsUser, InsDate,UpdateUser, UpdateDate, Rec_Status, DeleteUser, DeleteDate,Id ";
                sql = sql + " FROM            Hr_DocumentTypes where Rec_Status = 0  ";
                sql = sql + " Order by Id";

                      List<Hr_DocumentTypes> objectList = objPharmaEntities.Database.SqlQuery<Hr_DocumentTypes>(sql).ToList();

                      if (objectList != null) 
                      {
                          foreach(var obj in objectList)
                          {
                              Hr_DocumentTypes objHr_DocumentTypes = new Hr_DocumentTypes();
                              objHr_DocumentTypes.Doc_Type_Id=obj.Doc_Type_Id;
                              objHr_DocumentTypes.Doc_Type_Code = obj.Doc_Type_Code;
                              objHr_DocumentTypes.Doc_Type_Name=obj.Doc_Type_Name;
                              objHr_DocumentTypes.Doc_Type_NameEn=obj.Doc_Type_NameEn;
                              objHr_DocumentTypes.Doc_Type_NameConv=obj.Doc_Type_NameConv;
                              objHr_DocumentTypes.Doc_Type = obj.Doc_Type;
                              
                              objHr_DocumentTypes.Rec_Status=obj.Rec_Status;

                               objlist.Add(objHr_DocumentTypes);

                          }
                          
                      }

                //List<Hr_DocumentTypes> objectList = (from objLinq in objPharmaEntities.Hr_DocumentTypes
                //                            where objLinq.Rec_Status == 0
                //                         select objLinq).ToList();
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

        public string GetNewId()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
             object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_DocumentTypes_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_DocumentTypes_SelectMaxId()
                //         select anything.Doc_Type_Id).Single();
                //foreach (Hr_DocumentTypes cs in objPharmaEntities.Hr_DocumentTypes)
                //    maxId = cs.Doc_Type_Id;

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 Doc_Type_Id  as Doc_Type_Id  from Hr_DocumentTypes  order by replicate('0',15-len(Doc_Type_Id))+Doc_Type_Id desc").FirstOrDefault<string>();
              
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
