    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Reflection;
namespace DAL.HR.Registeration
{

  public  class BranchDocDAL:CommonDB

    {
        public  async Task<int> Insert(Hr_Branch_Docs_Hdr objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_Branch_Docs_Hdr.Add(objInsert);
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
        public int InsertTask(Hr_Branch_Docs_Hdr objInsert)
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


                    objPharmaEntities.Hr_Branch_Docs_Hdr.Add(objInsert);
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

        public async Task<bool> Update(Hr_Branch_Docs_Hdr objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Branch_Docs_Hdr ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Branch_Docs_Hdr
                                                       where objLinq.Hdr_Id == objUpdate.Hdr_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.Doc_Type_Id = objUpdate.Doc_Type_Id;
                    ObjForUpdate.LastFromDate = objUpdate.LastFromDate;
                    ObjForUpdate.LastToDate = objUpdate.LastToDate;
                    ObjForUpdate.LastFromDateHijri = objUpdate.LastFromDateHijri;
                    ObjForUpdate.LastToDateHijri = objUpdate.LastToDateHijri;

                    ObjForUpdate.ToBeNotifyPeriodBefore = objUpdate.ToBeNotifyPeriodBefore;
                    ObjForUpdate.NotifyPeriodType = objUpdate.NotifyPeriodType;
                    ObjForUpdate.ResponsibleEmpIdToNotify = objUpdate.ResponsibleEmpIdToNotify;
                    ObjForUpdate.NotifyMessage = objUpdate.NotifyMessage;
                    ObjForUpdate.NotifyMessageEn = objUpdate.NotifyMessageEn;
                    ObjForUpdate.ActuallDateNotification = objUpdate.ActuallDateNotification;
                    ObjForUpdate.ActuallDateNotificationHijri = objUpdate.ActuallDateNotificationHijri;
                    ObjForUpdate.UseNotifyDateType = objUpdate.UseNotifyDateType;
                    ObjForUpdate.Issue_Place = objUpdate.Issue_Place;
                    ObjForUpdate.Issue_Region = objUpdate.Issue_Region;
                    ObjForUpdate.RegistrationNo = objUpdate.RegistrationNo;
                    ObjForUpdate.Notes = objUpdate.Notes;
                    ObjForUpdate.DocPath = objUpdate.DocPath;
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
        public bool UpdateTask(Hr_Branch_Docs_Hdr objUpdate)
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
                    Hr_Branch_Docs_Hdr ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Branch_Docs_Hdr
                                                       where objLinq.Hdr_Id == objUpdate.Hdr_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                       select objLinq).FirstOrDefault();
                    ObjForUpdate.Doc_Type_Id = objUpdate.Doc_Type_Id;
                    ObjForUpdate.LastFromDate = objUpdate.LastFromDate;
                    ObjForUpdate.LastToDate = objUpdate.LastToDate;
                    ObjForUpdate.LastFromDateHijri = objUpdate.LastFromDateHijri;
                    ObjForUpdate.LastToDateHijri = objUpdate.LastToDateHijri;

                    ObjForUpdate.ToBeNotifyPeriodBefore = objUpdate.ToBeNotifyPeriodBefore;
                    ObjForUpdate.NotifyPeriodType = objUpdate.NotifyPeriodType;
                    ObjForUpdate.ResponsibleEmpIdToNotify = objUpdate.ResponsibleEmpIdToNotify;
                    ObjForUpdate.NotifyMessage = objUpdate.NotifyMessage;
                    ObjForUpdate.NotifyMessageEn = objUpdate.NotifyMessageEn;
                    ObjForUpdate.ActuallDateNotification = objUpdate.ActuallDateNotification;
                    ObjForUpdate.ActuallDateNotificationHijri = objUpdate.ActuallDateNotificationHijri;
                    ObjForUpdate.UseNotifyDateType = objUpdate.UseNotifyDateType;
                    ObjForUpdate.Issue_Place = objUpdate.Issue_Place;
                    ObjForUpdate.Issue_Region = objUpdate.Issue_Region;
                    ObjForUpdate.RegistrationNo = objUpdate.RegistrationNo;
                    ObjForUpdate.Notes = objUpdate.Notes;
                    ObjForUpdate.DocPath = objUpdate.DocPath;
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

        public async Task<bool> Delete(Hr_Branch_Docs_Hdr objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Branch_Docs_Hdr objForDelete = (from objLinq in objPharmaEntities.Hr_Branch_Docs_Hdr
                                                       where objLinq.Hdr_Id == objDelete.Hdr_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public bool DeleteTask(Hr_Branch_Docs_Hdr objDelete)
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
                    Hr_Branch_Docs_Hdr objForDelete = (from objLinq in objPharmaEntities.Hr_Branch_Docs_Hdr
                                                                      where objLinq.Hdr_Id == objDelete.Hdr_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public Hr_Branch_Docs_Hdr GetById(Guid Doc_ID ,string strCompany_Id , string strBranch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                string sql = " Select Hdr_Id, Branch_Doc_Id, Branch_Doc_Code, Company_Id, Branch_Id, Doc_Type_Id, LastFromDate, LastToDate, LastFromDateHijri, LastToDateHijri, ";
                sql = sql + " ToBeNotifyPeriodBefore, NotifyPeriodType, ResponsibleEmpIdToNotify, NotifyMessage, NotifyMessageEn, ActuallDateNotification, ActuallDateNotificationHijri, ";
                sql = sql + " UseNotifyDateType, InsUser, InsDate, Issue_Place, Issue_Region, UpdateUser, UpdateDate, Rec_Status, DeleteUser, DeleteDate, Notes,DocPath,SendNotify,RegistrationNo";
                sql = sql + " FROM     Hr_Branch_Docs_Hdr where Rec_Status = 0 and Hdr_Id ='" + Doc_ID + "' and Company_Id='" + strCompany_Id + "' and Branch_Id='" + strBranch_Id + "'";




                Hr_Branch_Docs_Hdr objectlist = objPharmaEntities.Database.SqlQuery<Hr_Branch_Docs_Hdr>(sql).FirstOrDefault();

                //Hr_Branch_Docs_Hdr BranchDocumentsForGetEntity = (from objLinq in objPharmaEntities.Hr_Branch_Docs_Hdr
                //                                       where objLinq.Hdr_Id == Doc_ID && objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id
                //                                       select objLinq).FirstOrDefault();

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
        public List<Hr_Branch_Docs_Hdr> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<Hr_Branch_Docs_Hdr> objectList = (from objLinq in objPharmaEntities.Hr_Branch_Docs_Hdr
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
        public List<Hr_Branch_Docs_Hdr> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                string sql = " Select Hdr_Id, Branch_Doc_Id, Branch_Doc_Code, Company_Id, Branch_Id, Doc_Type_Id, LastFromDate, LastToDate, LastFromDateHijri, LastToDateHijri, ";
                sql = sql + " ToBeNotifyPeriodBefore, NotifyPeriodType, ResponsibleEmpIdToNotify, NotifyMessage, NotifyMessageEn, ActuallDateNotification, ActuallDateNotificationHijri, ";
                sql = sql + " UseNotifyDateType, InsUser, InsDate, Issue_Place, Issue_Region, UpdateUser, UpdateDate, Rec_Status, DeleteUser, DeleteDate, Notes,DocPath,SendNotify,RegistrationNo";
                sql = sql + " FROM            Hr_Branch_Docs_Hdr where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";

                //string sql = "select [Company_Id],[Branch_Id],[Admin_Code]";
                //sql = sql + ",[Admin_Id],[Admin_Name],[Admin_NameEn],[Admin_NameConv],[Admin_AccountNo],[InsUser],[InsDate]";
                //sql = sql + ",[UpdateUser],UpdateDate,DeleteUser,DeleteDate,Rec_Status,Prefix";

                //sql = sql + " from Hr_Administrations where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";

                ////  List<Hr_Administrations> objectList = (from objLinq in objPharmaEntities.Hr_Administrations
                ////                       where objLinq.Rec_Status == 0 && objLinq.Branch_Id == strbranch && objLinq.Company_Id == strcomapny
                ////              select objLinq).ToList();



                List<Hr_Branch_Docs_Hdr> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Branch_Docs_Hdr>(sql).ToList();

                //List<Hr_Branch_Docs_Hdr> objectList = (from objLinq in objPharmaEntities.Hr_Branch_Docs_Hdr
                //                             where objLinq.Rec_Status == 0 && objLinq.Company_Id==strcomapny && objLinq.Branch_Id==strbranch
                //                             select objLinq).ToList();

                //var str = (from objlinq in objPharmaEntities.Hr_Administrations
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

        public string GetNewId(string strCompany_Id , string strBranch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
             object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Branch_Docs_Hdr_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Branch_Docs_Hdr_SelectMaxId()
                //         select anything.Doc_Id).Single();
                //foreach (Hr_Branch_Docs_Hdr cs in objPharmaEntities.Hr_Branch_Docs_Hdr)
                //    maxId = cs.Doc_Id;
              
                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 Branch_Doc_Code  as Branch_Doc_Code  from Hr_Branch_Docs_Hdr where Company_Id='" + strCompany_Id + "' and Branch_Id ='" + strBranch_Id + "'     order by replicate('0',15-len(Branch_Doc_Code))+Branch_Doc_Code desc").FirstOrDefault<string>();
              
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
