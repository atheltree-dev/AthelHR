using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
namespace DAL.HR.Registeration
{
  public  class BranchesDAL:CommonDB

    {
        public  async Task<int> Insert(Hr_Branches objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_Branches.Add(objInsert);
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
        public int InsertTask(Hr_Branches objInsert)
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


                    objPharmaEntities.Hr_Branches.Add(objInsert);
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

        public async Task<bool> Update(Hr_Branches objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Branches ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Branches
                                                where objLinq.Branch_Id == objUpdate.Branch_Id && objLinq.Company_Id == objUpdate.Company_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.Branch_Name = objUpdate.Branch_Name;
                    ObjForUpdate.Branch_NameEn = objUpdate.Branch_NameEn;
                    ObjForUpdate.Branch_Code = objUpdate.Branch_Code;
                    ObjForUpdate.Branch_AccountNo = objUpdate.Branch_AccountNo;
                    ObjForUpdate.Company_Id = objUpdate.Company_Id;
                    ObjForUpdate.Country_Id = objUpdate.Country_Id;
                    ObjForUpdate.City_Id = objUpdate.City_Id;
                    ObjForUpdate.Currency_Id = objUpdate.Currency_Id;
                    ObjForUpdate.StreetName = objUpdate.StreetName;
                    ObjForUpdate.Buiding_Number = objUpdate.Buiding_Number;
                    ObjForUpdate.P_O_Box = objUpdate.P_O_Box;
                    ObjForUpdate.Postal_Code = objUpdate.Postal_Code;
                    ObjForUpdate.Phone1 = objUpdate.Phone1;
                    ObjForUpdate.Phone2 = objUpdate.Phone2;
                    ObjForUpdate.Phone3 = objUpdate.Phone3;
                    ObjForUpdate.Fax = objUpdate.Fax;
                    ObjForUpdate.Email = objUpdate.Email;
                    ObjForUpdate.ExtenstionTel1 = objUpdate.ExtenstionTel1;
                    ObjForUpdate.ExtenstionTel2 = objUpdate.ExtenstionTel2;
                    ObjForUpdate.ExtenstionTel3 = objUpdate.ExtenstionTel3;
                    ObjForUpdate.ResponsibleEmpId = objUpdate.ResponsibleEmpId;

                    
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
        public bool UpdateTask(Hr_Branches objUpdate)
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
                    Hr_Branches ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Branches
                                                where objLinq.Branch_Id == objUpdate.Branch_Id && objLinq.Company_Id == objUpdate.Company_Id
                                            select objLinq).FirstOrDefault();
                    if (ObjForUpdate != null) 
                    { 
                            ObjForUpdate.Branch_Name = objUpdate.Branch_Name;
                            ObjForUpdate.Branch_NameEn = objUpdate.Branch_NameEn;
                            ObjForUpdate.Branch_Code = objUpdate.Branch_Code;
                            ObjForUpdate.Branch_AccountNo = objUpdate.Branch_AccountNo;
                            ObjForUpdate.Company_Id = objUpdate.Company_Id;
                            ObjForUpdate.Country_Id = objUpdate.Country_Id;
                            ObjForUpdate.City_Id = objUpdate.City_Id;
                            ObjForUpdate.Currency_Id = objUpdate.Currency_Id;
                            ObjForUpdate.StreetName = objUpdate.StreetName;
                            ObjForUpdate.Buiding_Number = objUpdate.Buiding_Number;
                            ObjForUpdate.P_O_Box = objUpdate.P_O_Box;
                            ObjForUpdate.Postal_Code = objUpdate.Postal_Code;
                            ObjForUpdate.Phone1 = objUpdate.Phone1;
                            ObjForUpdate.Phone2 = objUpdate.Phone2;
                            ObjForUpdate.Phone3 = objUpdate.Phone3;
                            ObjForUpdate.Fax = objUpdate.Fax;
                            ObjForUpdate.Email = objUpdate.Email;
                            ObjForUpdate.ExtenstionTel1 = objUpdate.ExtenstionTel1;
                            ObjForUpdate.ExtenstionTel2 = objUpdate.ExtenstionTel2;
                            ObjForUpdate.ExtenstionTel3 = objUpdate.ExtenstionTel3;
                            ObjForUpdate.ResponsibleEmpId = objUpdate.ResponsibleEmpId;
                        
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

        public async Task<bool> Delete(Hr_Branches objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Branches objForDelete = (from objLinq in objPharmaEntities.Hr_Branches
                                                where objLinq.Branch_Id == objDelete.Branch_Id && objLinq.Company_Id == objDelete.Company_Id
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

        public bool DeleteTask(Hr_Branches objDelete)
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
                    Hr_Branches objForDelete = (from objLinq in objPharmaEntities.Hr_Branches
                                                where objLinq.Branch_Id == objDelete.Branch_Id && objLinq.Company_Id == objDelete.Company_Id
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

        public Hr_Branches GetById(string Branch_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_Branches BranchesForGetEntity = (from objLinq in objPharmaEntities.Hr_Branches
                                            where objLinq.Branch_Id == Branch_ID && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return BranchesForGetEntity;
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
        public List<Hr_Branches> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<Hr_Branches> objectList = (from objLinq in objPharmaEntities.Hr_Branches
                                            where objLinq.Rec_Status == 0
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

        public List<Hr_Branches> SelectAllByCompany(string strcomapny) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                string sql = " select     Company_Id, Branch_Id, Branch_Code, Branch_Name, Branch_NameEn, Branch_NameConv, Branch_AccountNo, InsUser, InsDate, UpdateUser, ";
                sql = sql + "UpdateDate, DeleteUser, DeleteDate, Rec_Status, Prefix, Country_Id, City_Id, Currency_Id, StreetName, Buiding_Number, P_O_Box, Postal_Code, Phone1, Phone2, ";
                sql = sql + "Phone3, Fax, Email, ExtenstionTel1, ExtenstionTel2, ExtenstionTel3,ResponsibleEmpId,Id";
                sql = sql + " from Hr_Branches where Rec_Status = 0 and Company_Id='" + strcomapny + "'";
                sql = sql + " Order by Id ";

              //  List<Hr_Departments> objectList = (from objLinq in objPharmaEntities.Hr_Departments
                                //                       where objLinq.Rec_Status == 0 && objLinq.Branch_Id == strbranch && objLinq.Company_Id == strcomapny
                                //              select objLinq).ToList();



                List<Hr_Branches> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Branches>(sql).ToList();

                //var str = (from objlinq in objPharmaEntities.Hr_Departments
                //           where objlinq.Rec_Status == 0
                //           && objlinq.Company_Id == strcomapny && objlinq.Branch_Id == strbranch
                //           select objlinq);
                //string sql = ((ObjectQuery)str).ToTraceString();

                return objectlist;

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


  

        public string GetNewId(string strCompany)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
             object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Branches_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Branches_SelectMaxId()
                //         select anything.Branch_Id).Single();
                //foreach (Hr_Branches cs in objPharmaEntities.Hr_Branches)
                //    maxId = cs.Branch_Id;

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 Branch_Id  as Branch_Id  from Hr_Branches where Company_Id='" + strCompany + "' order by replicate('0',15-len(Branch_Id))+Branch_Id desc").FirstOrDefault<string>();
              
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
