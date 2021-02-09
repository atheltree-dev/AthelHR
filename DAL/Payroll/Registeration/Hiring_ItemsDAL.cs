using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Data.Entity.Validation;

namespace DAL.Payroll.Registeration
{
  public  class Hiring_ItemsDAL:CommonDB

    {
    

        public  async Task<int> Insert(Hr_Hiring_Items objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_Hiring_Items.Add(objInsert);
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
        public int InsertTask(Hr_Hiring_Items objInsert)
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


                    objPharmaEntities.Hr_Hiring_Items.Add(objInsert);
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

        public async Task<bool> Update(Hr_Hiring_Items objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Hiring_Items ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                            where objLinq.HireItem_Id == objUpdate.HireItem_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.HireItem_Name = objUpdate.HireItem_Name;
                    ObjForUpdate.HireItem_NameEn = objUpdate.HireItem_NameEn;
                    ObjForUpdate.HireItem_Type = objUpdate.HireItem_Type;
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
        public bool UpdateTask(Hr_Hiring_Items objUpdate)
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
                    Hr_Hiring_Items ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                            where objLinq.HireItem_Id == objUpdate.HireItem_Id
                                            && objLinq.Company_Id==objUpdate.Company_Id && objLinq.Branch_Id==objUpdate.Branch_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.HireItem_Name = objUpdate.HireItem_Name;
                    ObjForUpdate.HireItem_NameEn = objUpdate.HireItem_NameEn;

                    ObjForUpdate.HireItem_Type = objUpdate.HireItem_Type;
                    ObjForUpdate.Account_Type = objUpdate.Account_Type;
                    ObjForUpdate.Hire_Appear_W_Grade = objUpdate.Hire_Appear_W_Grade;
                    ObjForUpdate.JoinEndOfService = objUpdate.JoinEndOfService;
                    ObjForUpdate.CalcAnnually = objUpdate.CalcAnnually;

                    ObjForUpdate.NotIncludeVacAllownce = objUpdate.NotIncludeVacAllownce;
                    ObjForUpdate.AffectsSalaries = objUpdate.AffectsSalaries;
                    ObjForUpdate.Hire_AppearOnlyW_Grades = objUpdate.Hire_AppearOnlyW_Grades;
                    ObjForUpdate.Hire_Status = 0;
                    ObjForUpdate.IsPaymentBorrow = objUpdate.IsPaymentBorrow;
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

        public bool UpdateTaskWithOutBranch(Hr_Hiring_Items objUpdate)
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
                    Hr_Hiring_Items ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                                    where objLinq.HireItem_Id == objUpdate.HireItem_Id
                                                    //&& objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                    select objLinq).FirstOrDefault();
                    ObjForUpdate.HireItem_Name = objUpdate.HireItem_Name;
                    ObjForUpdate.HireItem_NameEn = objUpdate.HireItem_NameEn;

                    ObjForUpdate.HireItem_Type = objUpdate.HireItem_Type;
                    ObjForUpdate.Account_Type = objUpdate.Account_Type;
                    ObjForUpdate.Hire_Appear_W_Grade = objUpdate.Hire_Appear_W_Grade;
                    ObjForUpdate.JoinEndOfService = objUpdate.JoinEndOfService;
                    ObjForUpdate.CalcAnnually = objUpdate.CalcAnnually;

                    ObjForUpdate.NotIncludeVacAllownce = objUpdate.NotIncludeVacAllownce;
                    ObjForUpdate.AffectsSalaries = objUpdate.AffectsSalaries;
                    ObjForUpdate.Hire_AppearOnlyW_Grades = objUpdate.Hire_AppearOnlyW_Grades;
                    ObjForUpdate.Hire_Status = 0;
                    ObjForUpdate.IsPaymentBorrow = objUpdate.IsPaymentBorrow;
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

        public async Task<bool> Delete(Hr_Hiring_Items objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Hiring_Items objForDelete = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                            where objLinq.HireItem_Id == objDelete.HireItem_Id
                                            && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public bool DeleteTask(Hr_Hiring_Items objDelete)
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
                    Hr_Hiring_Items objForDelete = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                            where objLinq.HireItem_Id == objDelete.HireItem_Id
                                            && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public bool DeleteTaskWithOutBranch(Hr_Hiring_Items objDelete)
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
                    Hr_Hiring_Items objForDelete = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                                    where objLinq.HireItem_Id == objDelete.HireItem_Id
                                                   // && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public Hr_Hiring_Items GetById(string HireItem_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                Hr_Hiring_Items JobsForGetEntity = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                            where objLinq.HireItem_Id == HireItem_Id && objLinq.Rec_Status == 0
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

        public Hr_Hiring_Items GetByIdWithOutBranch(string HireItem_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                Hr_Hiring_Items JobsForGetEntity = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                                    where objLinq.HireItem_Id == HireItem_Id && objLinq.Rec_Status == 0
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

        public List<Hr_Hiring_Items> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_Hiring_Items> objectList = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                            where objLinq.Rec_Status == 0
                                            //&& objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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
        public List<Hr_Hiring_Items> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_Hiring_Items> objectList = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                            where objLinq.Rec_Status == 0
                                            && objLinq.Company_Id == strcomapny && objLinq.Branch_Id == strbranch
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


        public List<Hr_Hiring_Items> SelectAll()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_Hiring_Items> objectList = (from objLinq in objPharmaEntities.Hr_Hiring_Items
                                                    where objLinq.Rec_Status == 0
                                               //     && objLinq.Company_Id == strcomapny && objLinq.Branch_Id == strbranch
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

        public string GetNewId(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 HireItem_Id as HireItem_Id  from Hr_Hiring_Items where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(HireItem_Id))+HireItem_Id desc";
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
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 HireItem_Id as HireItem_Id  from Hr_Hiring_Items  order by replicate('0',15-len(HireItem_Id))+HireItem_Id desc";
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

        public string GetCalcType(string strHiringItem)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string result = string.Empty;
            byte resultData;

            OpenEntityConnection();
            string strsql;
            strsql = "select CalcAnnually  from Hr_Hiring_Items where  HireItem_Id = '" + strHiringItem + "'";
            resultData = objPharmaEntities.Database.SqlQuery<byte>(strsql).FirstOrDefault<byte>();

            result = Convert.ToString(resultData);

            return result;
        }

      

      



       


    }
}
