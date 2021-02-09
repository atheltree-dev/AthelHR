using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Reflection;

namespace DAL.HrServices.Registeration
{
    public class WorkFlowTransDAL : CommonDB
    {

        public bool AddWorkFlow(WorkFlow_Hdr ObjWorkFlow_HdrDL, List<WorkFlow_Dtls> ListWorkFlow_Dtls)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            var strErrorMessage = string.Empty;
          //  ObjWorkFlow_HdrDL.InsUser = "5";
            ObjWorkFlow_HdrDL.InsDate = DateTime.Now;
            // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
            bool result = true;

            using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
            {
                try
                {
                    if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed) 
                    {
                        objPharmaEntities.Database.Connection.Open();
                    }
                  

                    WorkFlow_Hdr loclWorkFlow_Hdr = new WorkFlow_Hdr
                    {
                        WorkFlow_Id = ObjWorkFlow_HdrDL.WorkFlow_Id,
                        WorkFlow_Name = ObjWorkFlow_HdrDL.WorkFlow_Name,
                        WorkFlow_NameEn = ObjWorkFlow_HdrDL.WorkFlow_NameEn,
                        InsUser = ObjWorkFlow_HdrDL.InsUser,
                        InsDate = ObjWorkFlow_HdrDL.InsDate
                    };
                    objPharmaEntities.WorkFlow_Hdr.Add(loclWorkFlow_Hdr);
                    //saves all above operations within one transaction
                    objPharmaEntities.SaveChanges();
                    foreach (WorkFlow_Dtls ObjWorkFlow_Dtls in ListWorkFlow_Dtls)
                    {
                        if (ObjWorkFlow_Dtls != null)
                        {
                            WorkFlow_Dtls loclWorkFlow_Dtls = new WorkFlow_Dtls
                            {

                                WorkFlow_Id = ObjWorkFlow_HdrDL.WorkFlow_Id,
                                Job_Id = ObjWorkFlow_Dtls.Job_Id,
                                WorkFlowOrder = ObjWorkFlow_Dtls.WorkFlowOrder
                            };
                            objPharmaEntities.WorkFlow_Dtls.Add(loclWorkFlow_Dtls);
                            //saves all above operations within one transaction
                            objPharmaEntities.SaveChanges();
                        }
                    }


                    //commit transaction
                    dbTran.Commit();
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
                    dbTran.Rollback();
                    result = false;
                    
                }

                catch (Exception ex)
                {
                    
                    //Rollback transaction if exception occurs
                    dbTran.Rollback();
                    result = false;
                   

                }
              

                    
                finally
                {
                    objPharmaEntities.Database.Connection.Close();
                    dbTran.Dispose();

                    if (!string.IsNullOrEmpty(strErrorMessage))
                    {
                       SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());



                    }
                }
                return result;

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
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
                //         select anything.Job_Id).Single();
                //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
                //    maxId = cs.Job_Id;

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 WorkFlow_Id   from WorkFlow_Hdr  order by replicate('0',15-len(WorkFlow_Id))+WorkFlow_Id desc").FirstOrDefault<string>();

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

        public WorkFlow_Hdr GetById(string WorkFlow_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                WorkFlow_Hdr WorkFlowForGetEntity = (from objLinq in objPharmaEntities.WorkFlow_Hdr
                                                 where objLinq.WorkFlow_Id == WorkFlow_ID && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return WorkFlowForGetEntity;
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
        public List<WorkFlow_Hdr> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                string sql = "select Rec_Id,WorkFlow_Id,[WorkFlow_Name],[WorkFlow_NameEn],[WorkFlow_NameConv],[InsUser],[InsDate],[UpdateUser],[UpdateDate],[DeleteUser],[DeleteDate],[Rec_Status]";
                sql = sql + " from WorkFlow_Hdr where Rec_Status = 0 ";

                List<WorkFlow_Hdr> objectlist = objPharmaEntities.Database.SqlQuery<WorkFlow_Hdr>(sql).ToList();

                //List<WorkFlow_Hdr> objectList = (from objLinq in objPharmaEntities.WorkFlow_Hdr
                //                            where objLinq.Rec_Status == 0
                //                            select objLinq).ToList();
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
    
        public WorkFlow_Dtls  GetWorkFlowDtlsById(string WorkFlow_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                WorkFlow_Dtls WorkFlowForGetEntity = (from objLinq in objPharmaEntities.WorkFlow_Dtls
                                                     where objLinq.WorkFlow_Id == WorkFlow_ID 
                                                     select objLinq).FirstOrDefault();
                return WorkFlowForGetEntity;
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

        
        public bool UpdateWorkFlow(WorkFlow_Hdr ObjWorkFlow_HdrDL, List<WorkFlow_Dtls> ListWorkFlow_Dtls)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            var strErrorMessage = string.Empty;
            //  ObjWorkFlow_HdrDL.InsUser = "5";
            
            // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
            bool result = true;

            using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
            {
                try
                {
                    if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
                    {
                        objPharmaEntities.Database.Connection.Open();
                    }


                    WorkFlow_Hdr loclDtlsUpdate = (from objLinq in objPharmaEntities.WorkFlow_Hdr
                                                   where objLinq.WorkFlow_Id == ObjWorkFlow_HdrDL.WorkFlow_Id
                                                   select objLinq).FirstOrDefault();
                    if (loclDtlsUpdate != null)
                    {
                        loclDtlsUpdate.WorkFlow_Name = ObjWorkFlow_HdrDL.WorkFlow_Name;
                        loclDtlsUpdate.WorkFlow_NameEn = ObjWorkFlow_HdrDL.WorkFlow_NameEn;
                        loclDtlsUpdate.UpdateUser = ObjWorkFlow_HdrDL.UpdateUser;
                        loclDtlsUpdate.UpdateDate = DateTime.Now;

                        objPharmaEntities.SaveChanges();

                    }

                    result = DeleteWorkFlow_Dtls(ObjWorkFlow_HdrDL.WorkFlow_Id);

                    if (result)
                    {
                        foreach (WorkFlow_Dtls ObjWorkFlow_Dtls in ListWorkFlow_Dtls)
                        {
                            if (ObjWorkFlow_Dtls != null)
                            {
                                WorkFlow_Dtls loclWorkFlow_Dtls = new WorkFlow_Dtls
                                {

                                    WorkFlow_Id = ObjWorkFlow_HdrDL.WorkFlow_Id,
                                    Job_Id = ObjWorkFlow_Dtls.Job_Id,
                                    WorkFlowOrder = ObjWorkFlow_Dtls.WorkFlowOrder
                                };
                                objPharmaEntities.WorkFlow_Dtls.Add(loclWorkFlow_Dtls);
                                //saves all above operations within one transaction
                                objPharmaEntities.SaveChanges();
                            }
                        }
                        dbTran.Commit();

                    }



                    //commit transaction

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
                    dbTran.Rollback();
                    result = false;

                }

                catch (Exception ex)
                {

                    //Rollback transaction if exception occurs
                    dbTran.Rollback();
                    result = false;


                }



                finally
                {
                    objPharmaEntities.Database.Connection.Close();
                    dbTran.Dispose();

                    if (!string.IsNullOrEmpty(strErrorMessage))
                    {
                        SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());



                    }
                }
                return result;

            }
        }

        public bool DeleteWorkFlow_Dtls(string WorkFlow_Id)
        {
            bool result = true;
            List<WorkFlow_Dtls> WorkFlow_DtlsItemToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                WorkFlow_DtlsItemToDelete = ctx.WorkFlow_Dtls.Where(s => s.WorkFlow_Id == WorkFlow_Id).ToList();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                foreach (WorkFlow_Dtls Obj_Dtls in WorkFlow_DtlsItemToDelete)
                {
                    if (Obj_Dtls != null)
                    {
                        newContext.Entry(Obj_Dtls).State = System.Data.Entity.EntityState.Deleted;

                        result = newContext.SaveChanges() > 0;

                    }
                }



            }
            return result;

        }


        public List<WorkFlow_Dtls> GetWorkFlowDtlsAll(string WorkFlow_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                string sql = "select Dtls_Id,WorkFlow_Id,Job_Id,WorkFlowOrder";
                sql = sql + " from WorkFlow_Dtls where  WorkFlow_Id='" + WorkFlow_ID + "'";
                List<WorkFlow_Dtls> WorkFlowForGetEntity = objPharmaEntities.Database.SqlQuery<WorkFlow_Dtls>(sql).ToList();

              
                return WorkFlowForGetEntity;
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

        

       
    }

}
