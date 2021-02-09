using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Objects;
using System.Diagnostics;
using System.Reflection;


namespace DAL.HR.Registeration
{
    public class JobsDAL : CommonDB

    {
        public  async Task<int> Insert(Hr_Jobs objInsert) 
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


                    objPharmaEntities.Hr_Jobs.Add(objInsert);
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
        public int InsertTask(Hr_Jobs objInsert)
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


                    objPharmaEntities.Hr_Jobs.Add(objInsert);
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

      

        public List<Hr_Jobs> SelectAllByCompanyAndBranch(string strcomapny, string strbranch) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                List<Hr_Jobs> objlist = new List<Hr_Jobs>();


                string sql ="select [Company_Id],[Branch_Id],[Job_Code]";
                sql = sql + ",[Job_Id],[Job_Name],[Job_NameEn],[Job_NameConv],GradeJob_Id,[InsUser],[InsDate]";
                sql = sql + ",[UpdateUser],UpdateDate,DeleteUser,DeleteDate,Rec_Status,IsManager";
               
                sql = sql + " from Hr_Jobs where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";
                sql = sql + " Order by Id";

              //  List<Hr_Jobs> objectList = (from objLinq in objPharmaEntities.Hr_Jobs
                                //                       where objLinq.Rec_Status == 0 && objLinq.Branch_Id == strbranch && objLinq.Company_Id == strcomapny
                                //              select objLinq).ToList();



                List<Hr_Jobs> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Jobs>(sql).ToList();

                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        Hr_Jobs objHr_Jobs = new Hr_Jobs();
                        objHr_Jobs.Company_Id = obj.Company_Id;
                        objHr_Jobs.Branch_Id = obj.Branch_Id;
                        objHr_Jobs.Job_Code = obj.Job_Code;
                        objHr_Jobs.GradeJob_Id = obj.GradeJob_Id;
                        objHr_Jobs.Job_Name = obj.Job_Name;
                        objHr_Jobs.Job_NameEn = obj.Job_NameEn;
                        objHr_Jobs.IsManager = obj.IsManager;
                        objHr_Jobs.Job_Id = obj.Job_Id;

                        objlist.Add(objHr_Jobs);

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


        public List<Hr_Jobs> SelectAll()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                List<Hr_Jobs> objlist = new List<Hr_Jobs>();

                string sql = "select [Company_Id],[Branch_Id],[Job_Code]";
                sql = sql + ",[Job_Id],[Job_Name],[Job_NameEn],[Job_NameConv],GradeJob_Id,[InsUser],[InsDate]";
                sql = sql + ",[UpdateUser],UpdateDate,DeleteUser,DeleteDate,Rec_Status,IsManager,Id";

                sql = sql + " from Hr_Jobs where Rec_Status = 0 ";
                sql = sql + " Order by Id";
              


                List<Hr_Jobs> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Jobs>(sql).ToList();

                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        Hr_Jobs objHr_Jobs = new Hr_Jobs();
                        objHr_Jobs.Company_Id = obj.Company_Id;
                        objHr_Jobs.Branch_Id = obj.Branch_Id;
                        objHr_Jobs.Job_Code = obj.Job_Code;
                        objHr_Jobs.GradeJob_Id = obj.GradeJob_Id;
                        objHr_Jobs.Job_Name = obj.Job_Name;
                        objHr_Jobs.Job_NameEn = obj.Job_NameEn;
                        objHr_Jobs.IsManager = obj.IsManager;
                        objHr_Jobs.Job_Id = obj.Job_Id;

                        objlist.Add(objHr_Jobs);

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

      

        //public IEnumerable<Hr_Jobs> SearchDataIsExistNew(string strcomapny, string strbranch, string strEmpSerialNo, string strEmpSearchName) 
        //{
        //    var varstrEmpSerialNo = Convert.ToDecimal(strEmpSerialNo);
        //    var varstrEmpSearchName = Convert.ToDecimal(strEmpSearchName);

        //    var objJobs = from o in objPharmaEntities.Hr_Jobs
        //                 select new Jobs
        //                 {
        //                     emp = temp,
        //                     CourseName = o.CourseName,
        //                 };
        //    return objJobs.ToList();
        //}

        public async Task<bool> Update(Hr_Jobs objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Jobs ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Jobs
                                            where objLinq.Job_Id == objUpdate.Job_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                            select objLinq).FirstOrDefault();



                    ObjForUpdate.Job_Name = objUpdate.Job_Name;
                    ObjForUpdate.Job_NameEn = objUpdate.Job_NameEn;
                    ObjForUpdate.Job_NameConv = objUpdate.Job_NameConv;
                    ObjForUpdate.GradeJob_Id = objUpdate.GradeJob_Id;
                    ObjForUpdate.Job_Code = objUpdate.Job_Code;

                    

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
        public bool UpdateTask(Hr_Jobs objUpdate)
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
                    Hr_Jobs ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Jobs
                                                 where objLinq.Job_Id == objUpdate.Job_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                 select objLinq).FirstOrDefault();



                    ObjForUpdate.Job_Name = objUpdate.Job_Name;
                    ObjForUpdate.Job_NameEn = objUpdate.Job_NameEn;
                    ObjForUpdate.Job_NameConv = objUpdate.Job_NameConv;
                    
                    ObjForUpdate.GradeJob_Id = objUpdate.GradeJob_Id;
                    ObjForUpdate.Job_Code = objUpdate.Job_Code;
                    ObjForUpdate.IsManager = objUpdate.IsManager;
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

        public bool UpdateTaskWithOutBranch(Hr_Jobs objUpdate)
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
                    Hr_Jobs ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Jobs
                                            where objLinq.Job_Id == objUpdate.Job_Id 
                                            select objLinq).FirstOrDefault();



                    ObjForUpdate.Job_Name = objUpdate.Job_Name;
                    ObjForUpdate.Job_NameEn = objUpdate.Job_NameEn;
                    ObjForUpdate.Job_NameConv = objUpdate.Job_NameConv;
                    ObjForUpdate.Job_Code = objUpdate.Job_Code;
                    ObjForUpdate.IsManager = objUpdate.IsManager;
                    ObjForUpdate.GradeJob_Id = objUpdate.GradeJob_Id;

                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;

                    rowEffected = objPharmaEntities.SaveChanges();
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

        public async Task<bool> Delete(Hr_Jobs objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Jobs objForDelete = (from objLinq in objPharmaEntities.Hr_Jobs
                                                 where objLinq.Job_Id == objDelete.Job_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public bool DeleteTask(Hr_Jobs objDelete)
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
                    Hr_Jobs objForDelete = (from objLinq in objPharmaEntities.Hr_Jobs
                                            where objLinq.Job_Id == objDelete.Job_Id
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

        public bool DeleteTaskWithOutBranch(Hr_Jobs objDelete)
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
                    Hr_Jobs objForDelete = (from objLinq in objPharmaEntities.Hr_Jobs
                                            where objLinq.Job_Id == objDelete.Job_Id
                                            select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected = objPharmaEntities.SaveChanges();
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

        public Hr_Jobs GetById(string strJob_Id, string strCompanyId, string strBranchId )
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                Hr_Jobs JobsForGetEntity = (from objLinq in objPharmaEntities.Hr_Jobs
                                                 where objLinq.Job_Id == strJob_Id && objLinq.Company_Id == strCompanyId && objLinq.Branch_Id == strBranchId && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return JobsForGetEntity;
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
        public Hr_Jobs GetByIdWithOutBranch(string strJob_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                Hr_Jobs JobsForGetEntity = (from objLinq in objPharmaEntities.Hr_Jobs
                                            where objLinq.Job_Id == strJob_Id  && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return JobsForGetEntity;
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

        public List<Hr_Jobs> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_Jobs> objectList = (from objLinq in objPharmaEntities.Hr_Jobs
                                                 where objLinq.Rec_Status == 0
                                                 && objLinq.Company_Id == objLinq.Company_Id && objLinq.Branch_Id == objLinq.Branch_Id
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

        public string GetNewId(string strcomapny , string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
             object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
                //         select anything.Job_Id).Single();
                //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
                //    maxId = cs.Job_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 Job_Id as Job_Id  from Hr_Jobs where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(Job_Id))+Job_Id desc";
                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
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


        public string GetNewIdWithOutBranch()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
                //         select anything.Job_Id).Single();
                //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
                //    maxId = cs.Job_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 Job_Id as Job_Id  from Hr_Jobs  order by replicate('0',15-len(Job_Id))+Job_Id desc";
                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
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
