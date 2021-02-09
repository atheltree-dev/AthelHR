using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Reflection;

namespace DAL.HrServices.RequestManagement
{
    public class EmpBorrowTransactionDAL : CommonDB
    {

        public bool AddBeginBalanceForBorrow(Hr_EmpBorrow_Hdr ObjHr_EmpBorrow_HdrDL, List<Hr_EmpBorrow_Dtls> ListHr_EmpBorrow_Dtls,string HireItem,decimal RecievedValue)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            var strErrorMessage = string.Empty;
          //  ObjHr_EmpBorrow_HdrDL.InsUser = "5";
            ObjHr_EmpBorrow_HdrDL.InsDate = DateTime.Now;
            // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
            bool result = true;

            try 
            {
                 int resultInsertEmployee = 0;
                        Guid StrHdr_Id;
                        StrHdr_Id = GetNewHeaderId();
                        using (AthelHREntities varcontext = new AthelHREntities())
                        {
                            using (var dbContextTransaction = varcontext.Database.BeginTransaction())
                            {

                                try
                             {
                                    if (varcontext.Database.Connection.State == System.Data.ConnectionState.Closed)
                                    {
                                        varcontext.Database.Connection.Open();
                                    }

                                    //OpenEntityConnection();

                                      Hr_EmpBorrow_Hdr loclHr_EmpBorrow_Hdr = new Hr_EmpBorrow_Hdr
                                                {
                                                    Hdr_Id = StrHdr_Id,
                                                    Company_Id = ObjHr_EmpBorrow_HdrDL.Company_Id,
                                                    Branch_Id = ObjHr_EmpBorrow_HdrDL.Branch_Id,
                                                    Emp_Serial_No = ObjHr_EmpBorrow_HdrDL.Emp_Serial_No,
                                                    Transdate = ObjHr_EmpBorrow_HdrDL.Transdate,
                                                    Rec_Order_No="0",
                                                    Rec_Order_HdrId=StrHdr_Id,
                                                    Request_Id = ObjHr_EmpBorrow_HdrDL.Request_Id,
                                                    Borrow_Value = ObjHr_EmpBorrow_HdrDL.Borrow_Value,
                                                    Borrow_Period=ObjHr_EmpBorrow_HdrDL.Borrow_Period,
                                                    BorrowStartDate = ObjHr_EmpBorrow_HdrDL.BorrowStartDate,
                                                    Borrow_MonthValue = ObjHr_EmpBorrow_HdrDL.Borrow_MonthValue,
                                                    Borrow_Status = ObjHr_EmpBorrow_HdrDL.Borrow_Status,
                                                    Notes = ObjHr_EmpBorrow_HdrDL.Notes,
                                                    HireItem_Id = ObjHr_EmpBorrow_HdrDL.HireItem_Id,
                                                    DocumentPath = ObjHr_EmpBorrow_HdrDL.DocumentPath,
                                                    Commissioner_Serial_no = ObjHr_EmpBorrow_HdrDL.Commissioner_Serial_no,
                                                    BorrowDuesDate = ObjHr_EmpBorrow_HdrDL.BorrowDuesDate,
                                                    MessageNotesForEmp = ObjHr_EmpBorrow_HdrDL.MessageNotesForEmp,

                                                    InsUser = ObjHr_EmpBorrow_HdrDL.InsUser,
                                                    InsDate = ObjHr_EmpBorrow_HdrDL.InsDate
                                                };
                                      varcontext.Hr_EmpBorrow_Hdr.Add(loclHr_EmpBorrow_Hdr);
                                                //saves all above operations within one transaction
                    
                 
                                                int i = 0;
                                                foreach (Hr_EmpBorrow_Dtls ObjHr_EmpBorrow_Dtls in ListHr_EmpBorrow_Dtls)
                                                {
                                                    if (ObjHr_EmpBorrow_Dtls != null)
                                                    {
                                                        Hr_EmpBorrow_Dtls loclHr_EmpBorrow_Dtls = new Hr_EmpBorrow_Dtls
                                                        {
                                                            Dtls_Id=GetNewHeaderId(),
                                                            Hdr_Id=StrHdr_Id,
                                                            Company_Id=ObjHr_EmpBorrow_HdrDL.Company_Id,
                                                            Branch_Id = ObjHr_EmpBorrow_HdrDL.Branch_Id,
                                                            Borrow_Month_No = ObjHr_EmpBorrow_Dtls.Borrow_Month_No,
                                                            Borrow_Month_Value = ObjHr_EmpBorrow_Dtls.Borrow_Month_Value,
                                                            Borrow_Month_Status = ObjHr_EmpBorrow_Dtls.Borrow_Month_Status,
                                                            RowId = Byte.Parse((i+1).ToString())
                                                        };
                                                        varcontext.Hr_EmpBorrow_Dtls.Add(loclHr_EmpBorrow_Dtls);
                                                        //saves all above operations within one transaction
                           
                                                    }
                                                    i = i + 1;

                                                }

                                             result= (varcontext.SaveChanges()>0);
                                       if (result)
                                       {
                                           EmpBeginEmpReceivableDuesDAL objEmpBeginBalanc = new EmpBeginEmpReceivableDuesDAL();
                                            Hr_BeginEmpReceivableDues_Dtls ListDtlsBeginBalance  = new Hr_BeginEmpReceivableDues_Dtls
                                            {
                                                    Hdr_Id = GetNewHeaderId(),
                                                    Branch_Id = ObjHr_EmpBorrow_HdrDL.Branch_Id,
                                                    Company_Id = ObjHr_EmpBorrow_HdrDL.Company_Id,
                                                    Month_No = ListHr_EmpBorrow_Dtls[0].Borrow_Month_No,
                                                    Emp_Serial_No = ObjHr_EmpBorrow_HdrDL.Emp_Serial_No,
                                                    TransDate = ObjHr_EmpBorrow_HdrDL.Transdate,
                                                    HireItem_Id = HireItem,
                                                    HireItem_Value = RecievedValue,
                                                    TransItemDate = ObjHr_EmpBorrow_HdrDL.Transdate,
                                                    DueDate = ObjHr_EmpBorrow_HdrDL.BorrowDuesDate,
                                                    RecRequestHdr_Id = StrHdr_Id,

                                                    InsItemDate = DateTime.Now,
                                                    InsItemUser = ObjHr_EmpBorrow_HdrDL.InsUser

                                            };


                                            result = objEmpBeginBalanc.AddNewRecordByContext(ListDtlsBeginBalance,varcontext);
                                           if (result)
                                           {
                                                        dbContextTransaction.Commit();
                                           }else
                                           {
                                                dbContextTransaction.Rollback();
                                                result = false;
                                           }

                                       }
                    
                                            else
                                            {
                                               dbContextTransaction.Rollback();
                                                result = false;
                                            }

                             }
                                catch (DbEntityValidationException ex)
                                {
                                    var errorMessages = ex.EntityValidationErrors
                                            .SelectMany(x => x.ValidationErrors)
                                           .Select(x => x.ErrorMessage);

                                    // Join the list to a single string.
                                    var fullErrorMessage = string.Join("; ", errorMessages);

                                    // Combine the original exception message with the new one.
                                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                                    strErrorMessage = fullErrorMessage;
                                    // Throw a new DbEntityValidationException with the improved exception message.
                                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                                    //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
                                    //   dbTran.Rollback();
                                    dbContextTransaction.Rollback();
                                    result = false;

                                }
                                catch (NullReferenceException ex)
                                {
                                    dbContextTransaction.Rollback();

                                    string.Concat("Processor Usage" + ex.Message);
                                }

                                //--- End Try Of Using
                                catch (Exception ex)
                                {
                                    dbContextTransaction.Rollback(); //Required according to MSDN article 
                                    throw; //Not in MSDN article, but recommended so the exception still bubbles up
                                }
                                
                                finally 
                                {

                                    varcontext.Database.Connection.Close();
                                   dbContextTransaction.Dispose();
                                }
                               
                                //--- End catch
                            }
                            //--- End Using
                        }


            }
           catch (DbEntityValidationException ex)
            {


                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                strErrorMessage = fullErrorMessage;
                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
                //   dbTran.Rollback();
                result = false;

            }
            catch (Exception ex)
            {

                //Rollback transaction if exception occurs
                //  dbTran.Rollback();
                result = false;

            }

            finally
            {
                objPharmaEntities.Database.Connection.Close();

                //  dbTran.Dispose();

                if (!string.IsNullOrEmpty(strErrorMessage))
                {
                    SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                }

            }

            return result;
    }








            
      

        //public string GetNewId()
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    string nextId = "0";
        //    object maxId = null;

        //    try
        //    {
        //        // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
        //        //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
        //        //         select anything.Job_Id).Single();
        //        //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
        //        //    maxId = cs.Job_Id;

        //        OpenEntityConnection();

        //        maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 WorkFlow_Id   from Hr_EmpBorrow_Hdr  order by replicate('0',15-len(WorkFlow_Id))+WorkFlow_Id desc").FirstOrDefault<string>();

        //        if (maxId != null)
        //        {
        //            nextId = maxId.ToString();


        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }
        //    return nextId;
        //}

        //public Hr_EmpBorrow_Hdr GetById(string WorkFlow_ID)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {
        //        OpenEntityConnection();
        //        Hr_EmpBorrow_Hdr WorkFlowForGetEntity = (from objLinq in objPharmaEntities.Hr_EmpBorrow_Hdr
        //                                         where objLinq.WorkFlow_Id == WorkFlow_ID && objLinq.Rec_Status == 0
        //                                    select objLinq).FirstOrDefault();
        //        return WorkFlowForGetEntity;
        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //        return null;

        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }




        //}
        //public List<Hr_EmpBorrow_Hdr> GetAll()
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();


        //    try
        //    {
        //        OpenEntityConnection();

        //        string sql = "select Rec_Id,WorkFlow_Id,[WorkFlow_Name],[WorkFlow_NameEn],[WorkFlow_NameConv],[InsUser],[InsDate],[UpdateUser],[UpdateDate],[DeleteUser],[DeleteDate],[Rec_Status]";
        //        sql = sql + " from Hr_EmpBorrow_Hdr where Rec_Status = 0 ";

        //        List<Hr_EmpBorrow_Hdr> objectlist = objPharmaEntities.Database.SqlQuery<Hr_EmpBorrow_Hdr>(sql).ToList();

        //        //List<Hr_EmpBorrow_Hdr> objectList = (from objLinq in objPharmaEntities.Hr_EmpBorrow_Hdr
        //        //                            where objLinq.Rec_Status == 0
        //        //                            select objLinq).ToList();
        //        return objectlist;

        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //        return null;

        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }


        //}
    
        //public Hr_EmpBorrow_Dtls  GetWorkFlowDtlsById(string WorkFlow_ID)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {
        //        OpenEntityConnection();
        //        Hr_EmpBorrow_Dtls WorkFlowForGetEntity = (from objLinq in objPharmaEntities.Hr_EmpBorrow_Dtls
        //                                             where objLinq.WorkFlow_Id == WorkFlow_ID 
        //                                             select objLinq).FirstOrDefault();
        //        return WorkFlowForGetEntity;
        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //        return null;

        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }




        //}

        
        //public bool UpdateWorkFlow(Hr_EmpBorrow_Hdr ObjHr_EmpBorrow_HdrDL, List<Hr_EmpBorrow_Dtls> ListHr_EmpBorrow_Dtls)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    var strErrorMessage = string.Empty;
        //    //  ObjHr_EmpBorrow_HdrDL.InsUser = "5";
            
        //    // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
        //    bool result = true;

        //    using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //            {
        //                objPharmaEntities.Database.Connection.Open();
        //            }


        //            Hr_EmpBorrow_Hdr loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_EmpBorrow_Hdr
        //                                           where objLinq.WorkFlow_Id == ObjHr_EmpBorrow_HdrDL.WorkFlow_Id
        //                                           select objLinq).FirstOrDefault();
        //            if (loclDtlsUpdate != null)
        //            {
        //                loclDtlsUpdate.WorkFlow_Name = ObjHr_EmpBorrow_HdrDL.WorkFlow_Name;
        //                loclDtlsUpdate.WorkFlow_NameEn = ObjHr_EmpBorrow_HdrDL.WorkFlow_NameEn;
        //                loclDtlsUpdate.UpdateUser = ObjHr_EmpBorrow_HdrDL.UpdateUser;
        //                loclDtlsUpdate.UpdateDate = DateTime.Now;

        //                objPharmaEntities.SaveChanges();

        //            }

        //            result = DeleteHr_EmpBorrow_Dtls(ObjHr_EmpBorrow_HdrDL.WorkFlow_Id);

        //            if (result)
        //            {
        //                foreach (Hr_EmpBorrow_Dtls ObjHr_EmpBorrow_Dtls in ListHr_EmpBorrow_Dtls)
        //                {
        //                    if (ObjHr_EmpBorrow_Dtls != null)
        //                    {
        //                        Hr_EmpBorrow_Dtls loclHr_EmpBorrow_Dtls = new Hr_EmpBorrow_Dtls
        //                        {

        //                            WorkFlow_Id = ObjHr_EmpBorrow_HdrDL.WorkFlow_Id,
        //                            Job_Id = ObjHr_EmpBorrow_Dtls.Job_Id,
        //                            WorkFlowOrder = ObjHr_EmpBorrow_Dtls.WorkFlowOrder
        //                        };
        //                        objPharmaEntities.Hr_EmpBorrow_Dtls.Add(loclHr_EmpBorrow_Dtls);
        //                        //saves all above operations within one transaction
        //                        objPharmaEntities.SaveChanges();
        //                    }
        //                }
        //                dbTran.Commit();

        //            }



        //            //commit transaction

        //        }
        //        catch (DbEntityValidationException ex)
        //        {


        //            // Retrieve the error messages as a list of strings.
        //            var errorMessages = ex.EntityValidationErrors
        //                    .SelectMany(x => x.ValidationErrors)
        //                    .Select(x => x.ErrorMessage);

        //            // Join the list to a single string.
        //            var fullErrorMessage = string.Join("; ", errorMessages);

        //            // Combine the original exception message with the new one.
        //            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
        //            strErrorMessage = fullErrorMessage;
        //            // Throw a new DbEntityValidationException with the improved exception message.
        //            throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        //            //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
        //            dbTran.Rollback();
        //            result = false;

        //        }

        //        catch (Exception ex)
        //        {

        //            //Rollback transaction if exception occurs
        //            dbTran.Rollback();
        //            result = false;


        //        }



        //        finally
        //        {
        //            objPharmaEntities.Database.Connection.Close();
        //            dbTran.Dispose();

        //            if (!string.IsNullOrEmpty(strErrorMessage))
        //            {
        //                SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());



        //            }
        //        }
        //        return result;

        //    }
        //}

        //public bool DeleteHr_EmpBorrow_Dtls(string WorkFlow_Id)
        //{
        //    bool result = true;
        //    List<Hr_EmpBorrow_Dtls> Hr_EmpBorrow_DtlsItemToDelete;
        //    //1. Get student from DB
        //    using (var ctx = new AthelHREntities())
        //    {


        //        Hr_EmpBorrow_DtlsItemToDelete = ctx.Hr_EmpBorrow_Dtls.Where(s => s.WorkFlow_Id == WorkFlow_Id).ToList();
        //    }

        //    //Create new context for disconnected scenario
        //    using (var newContext = new AthelHREntities())
        //    {

        //        foreach (Hr_EmpBorrow_Dtls Obj_Dtls in Hr_EmpBorrow_DtlsItemToDelete)
        //        {
        //            if (Obj_Dtls != null)
        //            {
        //                newContext.Entry(Obj_Dtls).State = System.Data.Entity.EntityState.Deleted;

        //                result = newContext.SaveChanges() > 0;

        //            }
        //        }



        //    }
        //    return result;

        //}


        //public List<Hr_EmpBorrow_Dtls> GetWorkFlowDtlsAll(string WorkFlow_ID)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {
        //        OpenEntityConnection();
        //        string sql = "select Dtls_Id,WorkFlow_Id,Job_Id,WorkFlowOrder";
        //        sql = sql + " from Hr_EmpBorrow_Dtls where  WorkFlow_Id='" + WorkFlow_ID + "'";
        //        List<Hr_EmpBorrow_Dtls> WorkFlowForGetEntity = objPharmaEntities.Database.SqlQuery<Hr_EmpBorrow_Dtls>(sql).ToList();

              
        //        return WorkFlowForGetEntity;
        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //        return null;

        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }




        //}

        

       
    }

}
