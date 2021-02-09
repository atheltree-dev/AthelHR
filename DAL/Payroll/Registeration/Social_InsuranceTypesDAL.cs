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
  public  class Social_InsuranceTypesDAL:CommonDB

    {
      

        public  async Task<int> Insert(Hr_Social_InsuranceTypes  objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_Social_InsuranceTypes.Add(objInsert);
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
        public int InsertTask(Hr_Social_InsuranceTypes objInsert)
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


                    objPharmaEntities.Hr_Social_InsuranceTypes.Add(objInsert);
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

        public async Task<bool> Update(Hr_Social_InsuranceTypes objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Social_InsuranceTypes ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                                             where objLinq.Insurance_Type_Id == objUpdate.Insurance_Type_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.Insurance_Type_Name = objUpdate.Insurance_Type_Name;
                    ObjForUpdate.Insurance_Type_NameEn = objUpdate.Insurance_Type_NameEn;
                    ObjForUpdate.HireItem_Id = objUpdate.HireItem_Id;
                    ObjForUpdate.DeductOnEmpOrComp = objUpdate.DeductOnEmpOrComp;
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
        public bool UpdateTask(Hr_Social_InsuranceTypes objUpdate)
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
                    Hr_Social_InsuranceTypes ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                                             where objLinq.Insurance_Type_Id == objUpdate.Insurance_Type_Id
                                            
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.Insurance_Type_Name = objUpdate.Insurance_Type_Name;
                    ObjForUpdate.Insurance_Type_NameEn = objUpdate.Insurance_Type_NameEn;
                    ObjForUpdate.HireItem_Id = objUpdate.HireItem_Id;
                    ObjForUpdate.DeductOnEmpOrComp = objUpdate.DeductOnEmpOrComp;

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

        public bool UpdateTaskWithOutBranch(Hr_Social_InsuranceTypes objUpdate)
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
                    Hr_Social_InsuranceTypes ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                                             where objLinq.Insurance_Type_Id == objUpdate.Insurance_Type_Id
                                                   // && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                    select objLinq).FirstOrDefault();

                    ObjForUpdate.Insurance_Type_Name = objUpdate.Insurance_Type_Name;
                    ObjForUpdate.Insurance_Type_NameEn = objUpdate.Insurance_Type_NameEn;
                    ObjForUpdate.HireItem_Id = objUpdate.HireItem_Id;
                    ObjForUpdate.DeductOnEmpOrComp = objUpdate.DeductOnEmpOrComp;

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

        public async Task<bool> Delete(Hr_Social_InsuranceTypes objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Social_InsuranceTypes objForDelete = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                                             where objLinq.Insurance_Type_Id == objDelete.Insurance_Type_Id
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

        public bool DeleteTask(Hr_Social_InsuranceTypes objDelete)
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
                    Hr_Social_InsuranceTypes objForDelete = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                                             where objLinq.Insurance_Type_Id == objDelete.Insurance_Type_Id
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

        public bool DeleteTaskWithOutBranch(Hr_Social_InsuranceTypes objDelete)
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
                    Hr_Social_InsuranceTypes objForDelete = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                                             where objLinq.Insurance_Type_Id == objDelete.Insurance_Type_Id
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

        public Hr_Social_InsuranceTypes GetById(string Insurance_Type_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_Social_InsuranceTypes JobsForGetEntity = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                                             where objLinq.Insurance_Type_Id == Insurance_Type_Id && objLinq.Rec_Status == 0
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
        public Hr_Social_InsuranceTypes GetByIdWithOutBranch(string Insurance_Type_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_Social_InsuranceTypes JobsForGetEntity = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                                             where objLinq.Insurance_Type_Id == Insurance_Type_Id && objLinq.Rec_Status == 0
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
        public List<Hr_Social_InsuranceTypes> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_Social_InsuranceTypes> objectList = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
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
        public List<Hr_Social_InsuranceTypes> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_Social_InsuranceTypes> objectList = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                            where objLinq.Rec_Status == 0
                                                  //&& objLinq.Insurance_Type_Id == Insurance_Type_Id
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

        public List<Hr_Social_InsuranceTypes> SelectAll()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_Social_InsuranceTypes> objectList = (from objLinq in objPharmaEntities.Hr_Social_InsuranceTypes
                                                    where objLinq.Rec_Status == 0
                                                  //  && objLinq.Company_Id == strcomapny && objLinq.Branch_Id == strbranch
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
                strsql = "select top 1 Insurance_Type_Id as Insurance_Type_Id  from Hr_Social_InsuranceTypes where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(Insurance_Type_Id))+Insurance_Type_Id desc";
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


        public string GetHireItem(string strcomapny, string strbranch,string VarInsurance_Type_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            
            string Result = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select HireItem_Id as HireItem_Id  from Hr_Hiring_Items where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " and HireItem_Type =" + VarInsurance_Type_Id + "";
                Result = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();

                if (Result != null)
                {
                    return Result; 

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
            return Result;
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
                strsql = "select top 1 Insurance_Type_Id as Insurance_Type_Id  from Hr_Social_InsuranceTypes  order by replicate('0',15-len(Insurance_Type_Id))+Insurance_Type_Id desc";
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
