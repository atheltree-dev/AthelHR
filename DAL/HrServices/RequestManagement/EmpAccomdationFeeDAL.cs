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
    public class EmpAccomdationFeeDAL : CommonDB
    {

        public bool AddBeginBalanceForAccomdtionFee(Hr_EmpAccomdationFees_OrgHdr ObjHr_EmpAccomdationFees_OrgHdrDL, List<Hr_EmpAccomdationFees_OrgDtls> ListHr_EmpAccomdationFees_OrgDtls, string HireItem, decimal RecievedValue)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            var strErrorMessage = string.Empty;
          //  ObjHr_EmpAccomdationFees_OrgHdrDL.InsUser = "5";
            ObjHr_EmpAccomdationFees_OrgHdrDL.InsDate = DateTime.Now;
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

                                    Hr_EmpAccomdationFees_OrgHdr loclHr_EmpAccomdationFees_OrgHdr = new Hr_EmpAccomdationFees_OrgHdr
                                                {
                                                    Hdr_Id = StrHdr_Id,
                                                    Company_Id = ObjHr_EmpAccomdationFees_OrgHdrDL.Company_Id,
                                                    Branch_Id = ObjHr_EmpAccomdationFees_OrgHdrDL.Branch_Id,
                                                    Emp_Serial_No = ObjHr_EmpAccomdationFees_OrgHdrDL.Emp_Serial_No,
                                                    Transdate = ObjHr_EmpAccomdationFees_OrgHdrDL.Transdate,
                                                    Rec_Order_No="0",
                                                    Rec_Order_HdrId=StrHdr_Id,
                                                    
                                                    AccomdtionFee_Value = ObjHr_EmpAccomdationFees_OrgHdrDL.AccomdtionFee_Value,
                                                    AccomdtionFee_Period=ObjHr_EmpAccomdationFees_OrgHdrDL.AccomdtionFee_Period,
                                                    AccomdtionFeeStartDate = ObjHr_EmpAccomdationFees_OrgHdrDL.AccomdtionFeeStartDate,
                                                    AccomdtionFee_MonthValue = ObjHr_EmpAccomdationFees_OrgHdrDL.AccomdtionFee_MonthValue,
                                                    AccomdtionFee_Status = ObjHr_EmpAccomdationFees_OrgHdrDL.AccomdtionFee_Status,
                                                    Notes = ObjHr_EmpAccomdationFees_OrgHdrDL.Notes,
                                                    HireItem_Id = ObjHr_EmpAccomdationFees_OrgHdrDL.HireItem_Id,
                                                    DocumentPath = ObjHr_EmpAccomdationFees_OrgHdrDL.DocumentPath,
                                                    Commissioner_Serial_no = ObjHr_EmpAccomdationFees_OrgHdrDL.Commissioner_Serial_no,
                                                    AccomdtionFeeDuesDate = ObjHr_EmpAccomdationFees_OrgHdrDL.AccomdtionFeeDuesDate,
                                                    MessageNotesForEmp = ObjHr_EmpAccomdationFees_OrgHdrDL.MessageNotesForEmp,
                                                    TotalALLAccomdationValue = ObjHr_EmpAccomdationFees_OrgHdrDL.TotalALLAccomdationValue,
                                                    ReceivedFees_Value = ObjHr_EmpAccomdationFees_OrgHdrDL.ReceivedFees_Value,
                                                    CompanyFees_Value = ObjHr_EmpAccomdationFees_OrgHdrDL.CompanyFees_Value,
                                                    InsUser = ObjHr_EmpAccomdationFees_OrgHdrDL.InsUser,
                                                    InsDate = ObjHr_EmpAccomdationFees_OrgHdrDL.InsDate
                                                };
                                      varcontext.Hr_EmpAccomdationFees_OrgHdr.Add(loclHr_EmpAccomdationFees_OrgHdr);
                                                //saves all above operations within one transaction
                                      result = (varcontext.SaveChanges() > 0);
                 
                                             //   int i = 0;
                                             //   foreach (Hr_EmpAccomdationFees_OrgDtls ObjHr_EmpAccomdationFees_OrgDtls in ListHr_EmpAccomdationFees_OrgDtls)
                                             //   {
                                             //       if (ObjHr_EmpAccomdationFees_OrgDtls != null)
                                             //       {
                                             //           Hr_EmpAccomdationFees_OrgDtls loclHr_EmpAccomdationFees_OrgDtls = new Hr_EmpAccomdationFees_OrgDtls
                                             //           {
                                             //               Dtls_Id=GetNewHeaderId(),
                                             //               Hdr_Id=StrHdr_Id,
                                             //               Company_Id=ObjHr_EmpAccomdationFees_OrgHdrDL.Company_Id,
                                             //               Branch_Id = ObjHr_EmpAccomdationFees_OrgHdrDL.Branch_Id,
                                             //               AccomdtionFee_Month_No = ObjHr_EmpAccomdationFees_OrgDtls.AccomdtionFee_Month_No,
                                             //               AccomdtionFee_Month_Value = ObjHr_EmpAccomdationFees_OrgDtls.AccomdtionFee_Month_Value,
                                             //               AccomdtionFee_Month_Status = ObjHr_EmpAccomdationFees_OrgDtls.AccomdtionFee_Month_Status,
                                             //               RowId = Byte.Parse((i+1).ToString())
                                             //           };
                                             //           varcontext.Hr_EmpAccomdationFees_OrgDtls.Add(loclHr_EmpAccomdationFees_OrgDtls);
                                             //           //saves all above operations within one transaction
                           
                                             //       }
                                             //       i = i + 1;

                                             //   }

                                             //result= (varcontext.SaveChanges()>0);
                                       if (result)
                                       {
                                           EmpBeginEmpReceivableDuesDAL objEmpBeginBalanc = new EmpBeginEmpReceivableDuesDAL();
                                            Hr_BeginEmpReceivableDues_Dtls ListDtlsBeginBalance  = new Hr_BeginEmpReceivableDues_Dtls
                                            {

                                                    Hdr_Id = GetNewHeaderId(),
                                                    Branch_Id = ObjHr_EmpAccomdationFees_OrgHdrDL.Branch_Id,
                                                    Company_Id = ObjHr_EmpAccomdationFees_OrgHdrDL.Company_Id,
                                                    Month_No = ListHr_EmpAccomdationFees_OrgDtls[0].AccomdtionFee_Month_No,
                                                    Emp_Serial_No = ObjHr_EmpAccomdationFees_OrgHdrDL.Emp_Serial_No,
                                                    TransDate = ObjHr_EmpAccomdationFees_OrgHdrDL.Transdate,
                                                    HireItem_Id = HireItem,
                                                    HireItem_Value = RecievedValue,
                                                    TransItemDate = ObjHr_EmpAccomdationFees_OrgHdrDL.Transdate,
                                                    DueDate = ObjHr_EmpAccomdationFees_OrgHdrDL.AccomdtionFeeDuesDate,
                                                    RecRequestHdr_Id = StrHdr_Id,

                                                    InsItemDate = DateTime.Now,
                                                    InsItemUser = ObjHr_EmpAccomdationFees_OrgHdrDL.InsUser

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





        public Hr_EmpAccomdationFees_Setting GetAccomdationFeesSettingDataByBranchandCompany(string strCompany_Id, string strBranch_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                Hr_EmpAccomdationFees_Setting ObjEmpAccomdationFees_Settings = (from objLinq in objPharmaEntities.Hr_EmpAccomdationFees_Setting
                                                               where objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id
                                                               select objLinq).FirstOrDefault();

                if (ObjEmpAccomdationFees_Settings != null)
                {
                    Hr_EmpAccomdationFees_Setting objEmpAccomdationFees_SettingsDL = new Hr_EmpAccomdationFees_Setting();


                    {
                        objEmpAccomdationFees_SettingsDL.Branch_Id = ObjEmpAccomdationFees_Settings.Branch_Id;
                        objEmpAccomdationFees_SettingsDL.Company_Id = ObjEmpAccomdationFees_Settings.Company_Id;
                        objEmpAccomdationFees_SettingsDL.HireItem_Id = ObjEmpAccomdationFees_Settings.HireItem_Id;
                        


                    }
                    return objEmpAccomdationFees_SettingsDL;
                }
                else
                {
                    return null;
                }




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

        //        maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 WorkFlow_Id   from Hr_EmpAccomdationFees_OrgHdr  order by replicate('0',15-len(WorkFlow_Id))+WorkFlow_Id desc").FirstOrDefault<string>();

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

        //public Hr_EmpAccomdationFees_OrgHdr GetById(string WorkFlow_ID)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {
        //        OpenEntityConnection();
        //        Hr_EmpAccomdationFees_OrgHdr WorkFlowForGetEntity = (from objLinq in objPharmaEntities.Hr_EmpAccomdationFees_OrgHdr
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
        //public List<Hr_EmpAccomdationFees_OrgHdr> GetAll()
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();


        //    try
        //    {
        //        OpenEntityConnection();

        //        string sql = "select Rec_Id,WorkFlow_Id,[WorkFlow_Name],[WorkFlow_NameEn],[WorkFlow_NameConv],[InsUser],[InsDate],[UpdateUser],[UpdateDate],[DeleteUser],[DeleteDate],[Rec_Status]";
        //        sql = sql + " from Hr_EmpAccomdationFees_OrgHdr where Rec_Status = 0 ";

        //        List<Hr_EmpAccomdationFees_OrgHdr> objectlist = objPharmaEntities.Database.SqlQuery<Hr_EmpAccomdationFees_OrgHdr>(sql).ToList();

        //        //List<Hr_EmpAccomdationFees_OrgHdr> objectList = (from objLinq in objPharmaEntities.Hr_EmpAccomdationFees_OrgHdr
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
    
        //public Hr_EmpAccomdationFees_OrgDtls  GetWorkFlowDtlsById(string WorkFlow_ID)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {
        //        OpenEntityConnection();
        //        Hr_EmpAccomdationFees_OrgDtls WorkFlowForGetEntity = (from objLinq in objPharmaEntities.Hr_EmpAccomdationFees_OrgDtls
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

        
        //public bool UpdateWorkFlow(Hr_EmpAccomdationFees_OrgHdr ObjHr_EmpAccomdationFees_OrgHdrDL, List<Hr_EmpAccomdationFees_OrgDtls> ListHr_EmpAccomdationFees_OrgDtls)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    var strErrorMessage = string.Empty;
        //    //  ObjHr_EmpAccomdationFees_OrgHdrDL.InsUser = "5";
            
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


        //            Hr_EmpAccomdationFees_OrgHdr loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_EmpAccomdationFees_OrgHdr
        //                                           where objLinq.WorkFlow_Id == ObjHr_EmpAccomdationFees_OrgHdrDL.WorkFlow_Id
        //                                           select objLinq).FirstOrDefault();
        //            if (loclDtlsUpdate != null)
        //            {
        //                loclDtlsUpdate.WorkFlow_Name = ObjHr_EmpAccomdationFees_OrgHdrDL.WorkFlow_Name;
        //                loclDtlsUpdate.WorkFlow_NameEn = ObjHr_EmpAccomdationFees_OrgHdrDL.WorkFlow_NameEn;
        //                loclDtlsUpdate.UpdateUser = ObjHr_EmpAccomdationFees_OrgHdrDL.UpdateUser;
        //                loclDtlsUpdate.UpdateDate = DateTime.Now;

        //                objPharmaEntities.SaveChanges();

        //            }

        //            result = DeleteHr_EmpAccomdationFees_OrgDtls(ObjHr_EmpAccomdationFees_OrgHdrDL.WorkFlow_Id);

        //            if (result)
        //            {
        //                foreach (Hr_EmpAccomdationFees_OrgDtls ObjHr_EmpAccomdationFees_OrgDtls in ListHr_EmpAccomdationFees_OrgDtls)
        //                {
        //                    if (ObjHr_EmpAccomdationFees_OrgDtls != null)
        //                    {
        //                        Hr_EmpAccomdationFees_OrgDtls loclHr_EmpAccomdationFees_OrgDtls = new Hr_EmpAccomdationFees_OrgDtls
        //                        {

        //                            WorkFlow_Id = ObjHr_EmpAccomdationFees_OrgHdrDL.WorkFlow_Id,
        //                            Job_Id = ObjHr_EmpAccomdationFees_OrgDtls.Job_Id,
        //                            WorkFlowOrder = ObjHr_EmpAccomdationFees_OrgDtls.WorkFlowOrder
        //                        };
        //                        objPharmaEntities.Hr_EmpAccomdationFees_OrgDtls.Add(loclHr_EmpAccomdationFees_OrgDtls);
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

        //public bool DeleteHr_EmpAccomdationFees_OrgDtls(string WorkFlow_Id)
        //{
        //    bool result = true;
        //    List<Hr_EmpAccomdationFees_OrgDtls> Hr_EmpAccomdationFees_OrgDtlsItemToDelete;
        //    //1. Get student from DB
        //    using (var ctx = new AthelHREntities())
        //    {


        //        Hr_EmpAccomdationFees_OrgDtlsItemToDelete = ctx.Hr_EmpAccomdationFees_OrgDtls.Where(s => s.WorkFlow_Id == WorkFlow_Id).ToList();
        //    }

        //    //Create new context for disconnected scenario
        //    using (var newContext = new AthelHREntities())
        //    {

        //        foreach (Hr_EmpAccomdationFees_OrgDtls Obj_Dtls in Hr_EmpAccomdationFees_OrgDtlsItemToDelete)
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


        //public List<Hr_EmpAccomdationFees_OrgDtls> GetWorkFlowDtlsAll(string WorkFlow_ID)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {
        //        OpenEntityConnection();
        //        string sql = "select Dtls_Id,WorkFlow_Id,Job_Id,WorkFlowOrder";
        //        sql = sql + " from Hr_EmpAccomdationFees_OrgDtls where  WorkFlow_Id='" + WorkFlow_ID + "'";
        //        List<Hr_EmpAccomdationFees_OrgDtls> WorkFlowForGetEntity = objPharmaEntities.Database.SqlQuery<Hr_EmpAccomdationFees_OrgDtls>(sql).ToList();

              
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
