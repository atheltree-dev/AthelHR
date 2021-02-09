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
    public class DepartmentsDAL : CommonDB

    {
        public  async Task<int> Insert(Hr_Departments objInsert) 
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


                    objPharmaEntities.Hr_Departments.Add(objInsert);
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
        public int InsertTask(Hr_Departments objInsert)
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


                    objPharmaEntities.Hr_Departments.Add(objInsert);
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

      

        public List<Hr_Departments> SelectAllByCompanyAndBranch(string strcomapny, string strbranch) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<Hr_Departments> objlist = new List<Hr_Departments>();

            try
            {
                OpenEntityConnection();
                string sql ="select [Company_Id],[Branch_Id],[Dept_Code]";
                sql = sql + ",[Dept_Id],[Dept_Name],[Dept_NameEn],[Dept_NameConv],[Dept_AccountNo],Admin_Id,[InsUser],[InsDate]";
                sql = sql + ",[UpdateUser],UpdateDate,DeleteUser,DeleteDate,Rec_Status,Prefix,Id";
               
                sql = sql + " from Hr_Departments where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";
                sql = sql + " Order by Id ";

              //  List<Hr_Departments> objectList = (from objLinq in objPharmaEntities.Hr_Departments
                                //                       where objLinq.Rec_Status == 0 && objLinq.Branch_Id == strbranch && objLinq.Company_Id == strcomapny
                                //              select objLinq).ToList();



                List<Hr_Departments> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Departments>(sql).ToList();


                

                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        Hr_Departments obj1 = new Hr_Departments();
                        obj1.Company_Id = obj.Company_Id;
                        obj1.Branch_Id = obj.Branch_Id;
                        obj1.Dept_Id = obj.Dept_Id;
                        obj1.Dept_Code = obj.Dept_Code;
                        obj1.Admin_Id = obj.Admin_Id;
                        obj1.Dept_Name = obj.Dept_Name;
                        obj1.Dept_NameEn = obj.Dept_NameEn;
                        obj1.Dept_NameConv = obj.Dept_NameConv;
                        obj1.Dept_AccountNo = obj.Dept_AccountNo;
                        obj1.InsUser = obj.InsUser;
                        obj1.InsDate = obj.InsDate;
                        obj1.UpdateUser = obj.UpdateUser;
                        obj1.UpdateDate = obj.UpdateDate;
                        obj1.DeleteUser = obj.DeleteUser;
                        obj1.DeleteDate = obj.DeleteDate;
                        obj1.Rec_Status = obj.Rec_Status;
                        obj1.Prefix = obj.Prefix;

                        objlist.Add(obj1);

                    }

                }


                //var str = (from objlinq in objPharmaEntities.Hr_Departments
                //           where objlinq.Rec_Status == 0
                //           && objlinq.Company_Id == strcomapny && objlinq.Branch_Id == strbranch
                //           select objlinq);
                //string sql = ((ObjectQuery)str).ToTraceString();

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

        

      

        //public IEnumerable<Hr_Departments> SearchDataIsExistNew(string strcomapny, string strbranch, string strEmpSerialNo, string strEmpSearchName) 
        //{
        //    var varstrEmpSerialNo = Convert.ToDecimal(strEmpSerialNo);
        //    var varstrEmpSearchName = Convert.ToDecimal(strEmpSearchName);

        //    var objDepartments = from o in objPharmaEntities.Hr_Departments
        //                 select new Departments
        //                 {
        //                     emp = temp,
        //                     CourseName = o.CourseName,
        //                 };
        //    return objDepartments.ToList();
        //}

        public async Task<bool> Update(Hr_Departments objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Departments ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Departments
                                            where objLinq.Dept_Id == objUpdate.Dept_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                            select objLinq).FirstOrDefault();



                    ObjForUpdate.Dept_Name = objUpdate.Dept_Name;
                    ObjForUpdate.Dept_NameEn = objUpdate.Dept_NameEn;
                    ObjForUpdate.Dept_NameConv = objUpdate.Dept_NameConv;
                    ObjForUpdate.Dept_AccountNo = objUpdate.Dept_AccountNo;
                    ObjForUpdate.Admin_Id = objUpdate.Admin_Id;
                    

                    

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
        public bool UpdateTask(Hr_Departments objUpdate)
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
                    Hr_Departments ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Departments
                                                 where objLinq.Dept_Id == objUpdate.Dept_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                 select objLinq).FirstOrDefault();


                    if (ObjForUpdate != null)
                    {
                        ObjForUpdate.Dept_Name = objUpdate.Dept_Name;
                        ObjForUpdate.Dept_NameEn = objUpdate.Dept_NameEn;
                        ObjForUpdate.Dept_NameConv = objUpdate.Dept_NameConv;
                        ObjForUpdate.Dept_AccountNo = objUpdate.Dept_AccountNo;
                        ObjForUpdate.Admin_Id = objUpdate.Admin_Id;
                        ObjForUpdate.Dept_Code = objUpdate.Dept_Code;


                        ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                        ObjForUpdate.UpdateDate = DateTime.Now;

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

        public async Task<bool> Delete(Hr_Departments objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Departments objForDelete = (from objLinq in objPharmaEntities.Hr_Departments
                                                 where objLinq.Dept_Id == objDelete.Dept_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public bool DeleteTask(Hr_Departments objDelete)
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
                    Hr_Departments objForDelete = (from objLinq in objPharmaEntities.Hr_Departments
                                            where objLinq.Dept_Id == objDelete.Dept_Id
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

        public Hr_Departments GetById(string strDept_Id, string strCompanyId, string strBranchId )
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                Hr_Departments DeptsForGetEntity = (from objLinq in objPharmaEntities.Hr_Departments
                                                 where objLinq.Dept_Id == strDept_Id && objLinq.Company_Id == strCompanyId && objLinq.Branch_Id == strBranchId && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return DeptsForGetEntity;
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
        public List<Hr_Departments> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_Departments> objectList = (from objLinq in objPharmaEntities.Hr_Departments
                                                 where objLinq.Rec_Status == 0
                                                 && objLinq.Company_Id == objLinq.Company_Id && objLinq.Branch_Id == objLinq.Branch_Id
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
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Departments_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Departments_SelectMaxId()
                //         select anything.Dept_Id).Single();
                //foreach (Hr_Departments cs in objPharmaEntities.Hr_Departments)
                //    maxId = cs.Dept_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 Dept_Id as Dept_Id  from Hr_Departments where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(Dept_Id))+Dept_Id desc";
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
