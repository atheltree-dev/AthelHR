using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
namespace DAL.HR.Registeration
{

  public  class BanksDAL:CommonDB

    {
        public  async Task<int> Insert(Hr_Banks objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_Banks.Add(objInsert);
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
        public int InsertTask(Hr_Banks objInsert)
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


                    objPharmaEntities.Hr_Banks.Add(objInsert);
                    RowEffected =  objPharmaEntities.SaveChanges();
                }

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
                RowEffected = -1;
                ex.InnerException.Message.ToString();


            }
            finally
            {
                CloseEntityConnection();
            }
            return RowEffected;


        }

        public async Task<bool> Update(Hr_Banks objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Banks ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Banks
                                             where objLinq.Bank_Id == objUpdate.Bank_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.Bank_Name = objUpdate.Bank_Name;
                    ObjForUpdate.Bank_Name_En = objUpdate.Bank_Name_En;
                    ObjForUpdate.Company_Id = objUpdate.Company_Id;
                    ObjForUpdate.Branch_Id = objUpdate.Branch_Id;
                    ObjForUpdate.Address = objUpdate.Address;
                    ObjForUpdate.Phone1 = objUpdate.Phone1;
                    ObjForUpdate.Phone2 = objUpdate.Phone2;
                    ObjForUpdate.Mobile1 = objUpdate.Mobile1;
                    ObjForUpdate.Mobile2 = objUpdate.Mobile2;
                    ObjForUpdate.Fax = objUpdate.Fax;
                    ObjForUpdate.WebSiteUrl = objUpdate.WebSiteUrl;
                    ObjForUpdate.Swift_Code = objUpdate.Swift_Code;
                    ObjForUpdate.Country_Id = objUpdate.Country_Id;
                    ObjForUpdate.City_Id = objUpdate.City_Id;
                    ObjForUpdate.Currency_Id = objUpdate.Currency_Id;
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
        public bool UpdateTask(Hr_Banks objUpdate)
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
                    Hr_Banks ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Banks
                                             where objLinq.Bank_Id == objUpdate.Bank_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                            select objLinq).FirstOrDefault();
                    if (ObjForUpdate != null) {
                        ObjForUpdate.Bank_Code = objUpdate.Bank_Code;
                    ObjForUpdate.Bank_Name = objUpdate.Bank_Name;
                    ObjForUpdate.Bank_Name_En = objUpdate.Bank_Name_En;
                    ObjForUpdate.Company_Id = objUpdate.Company_Id;
                    ObjForUpdate.Branch_Id = objUpdate.Branch_Id;
                     ObjForUpdate.Address = objUpdate.Address;
                    ObjForUpdate.Phone1 = objUpdate.Phone1;
                    ObjForUpdate.Phone2 = objUpdate.Phone2;
                    ObjForUpdate.Mobile1 = objUpdate.Mobile1;
                    ObjForUpdate.Mobile2 = objUpdate.Mobile2;
                    ObjForUpdate.Fax = objUpdate.Fax;
                    ObjForUpdate.WebSiteUrl = objUpdate.WebSiteUrl;
                    ObjForUpdate.Swift_Code = objUpdate.Swift_Code;
                    ObjForUpdate.Country_Id = objUpdate.Country_Id;
                    ObjForUpdate.City_Id = objUpdate.City_Id;
                    ObjForUpdate.Currency_Id = objUpdate.Currency_Id;
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

        public async Task<bool> Delete(Hr_Banks objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Banks objForDelete = (from objLinq in objPharmaEntities.Hr_Banks
                                             where objLinq.Bank_Id == objDelete.Bank_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public bool DeleteTask(Hr_Banks objDelete)
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
                    Hr_Banks objForDelete = (from objLinq in objPharmaEntities.Hr_Banks
                                             where objLinq.Bank_Id == objDelete.Bank_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public Hr_Banks GetById(string Bank_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_Banks BanksForGetEntity = (from objLinq in objPharmaEntities.Hr_Banks
                                            where objLinq.Bank_Id == Bank_ID && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return BanksForGetEntity;
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
        public List<Hr_Banks> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<Hr_Banks> objectList = (from objLinq in objPharmaEntities.Hr_Banks
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
        public List<Hr_Banks> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                //string sql = "select [Company_Id],[Branch_Id],[Admin_Code]";
                //sql = sql + ",[Admin_Id],[Admin_Name],[Admin_NameEn],[Admin_NameConv],[Admin_AccountNo],[InsUser],[InsDate]";
                //sql = sql + ",[UpdateUser],UpdateDate,DeleteUser,DeleteDate,Rec_Status,Prefix";

                //sql = sql + " from Hr_Administrations where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";

                ////  List<Hr_Administrations> objectList = (from objLinq in objPharmaEntities.Hr_Administrations
                ////                       where objLinq.Rec_Status == 0 && objLinq.Branch_Id == strbranch && objLinq.Company_Id == strcomapny
                ////              select objLinq).ToList();



                //List<Hr_Administrations> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Administrations>(sql).ToList();
                List<Hr_Banks> objectList = (from objLinq in objPharmaEntities.Hr_Banks
                                             where objLinq.Rec_Status == 0 && objLinq.Company_Id==strcomapny && objLinq.Branch_Id==strbranch
                                             orderby objLinq.Id
                                             select objLinq).ToList();

                //var str = (from objlinq in objPharmaEntities.Hr_Administrations
                //           where objlinq.Rec_Status == 0
                //           && objlinq.Company_Id == strcomapny && objlinq.Branch_Id == strbranch
                //           select objlinq);
                //string sql = ((ObjectQuery)str).ToTraceString();

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

        public string GetNewId(string strCompany_Id , string strBranch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
             object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Banks_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Banks_SelectMaxId()
                //         select anything.Bank_Id).Single();
                //foreach (Hr_Banks cs in objPharmaEntities.Hr_Banks)
                //    maxId = cs.Bank_Id;
              
                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 Bank_Id  as Bank_Id  from Hr_Banks where Company_Id='"+ strCompany_Id +"' and Branch_Id ='"+ strBranch_Id +"'     order by replicate('0',15-len(Bank_Id))+Bank_Id desc").FirstOrDefault<string>();
              
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
