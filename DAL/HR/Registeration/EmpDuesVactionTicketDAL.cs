using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
//using BOL.Registeration.Registeration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Validation;


namespace DAL.HR.Registeration
{
  public  class EmpDuesVactionTicketDAL:CommonDB

    {

      public bool AddNewRecord(Hr_EmpDuesVactionTicket Obj_Dtls)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            var strErrorMessage = string.Empty;
            //  ObjWorkFlow_HdrDL.InsUser = "5";

            // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
            bool result = true;

            //using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
            //{
                try
                {
                    if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
                    {
                        objPharmaEntities.Database.Connection.Open();
                    }
                      
                    
                    if (Obj_Dtls != null)
                        {

                            Hr_EmpDuesVactionTicket loclDtls = new Hr_EmpDuesVactionTicket
                                {
                                    EmpHdrId =Obj_Dtls.EmpHdrId,
                                    Branch_Id = Obj_Dtls.Branch_Id,
                                    Company_Id = Obj_Dtls.Company_Id,
                                    GradeJob_Id = Obj_Dtls.GradeJob_Id,
                                    Emp_Serial_No = 0,
                                    VactionPeriod = Obj_Dtls.VactionPeriod,
                                    VactionTicketType = Obj_Dtls.VactionTicketType,
                                    InternationalWorkTicketType = Obj_Dtls.InternationalWorkTicketType,
                                    LocalWorkTicketType = Obj_Dtls.LocalWorkTicketType,
                                    WorkingMonthNo = Obj_Dtls.WorkingMonthNo,
                                    WorkingPeriodType = Obj_Dtls.WorkingPeriodType,

                                    InsDate = DateTime.Now,
                                    InsUser = Obj_Dtls.InsUser

                                };

                               objPharmaEntities.Hr_EmpDuesVactionTicket.Add(loclDtls);
                                //saves all above operations within one transaction
                               // objPharmaEntities.SaveChanges();

                               // dbTran.Commit();
                           // }
                            
                            
                           
                        }
                    //}


                    //commit transaction
                  //  dbTran.Commit();
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

          //  }

        }

      public bool AddNewRecordByContext(Hr_EmpDuesVactionTicket Obj_Dtls,AthelHREntities varContext )
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          var strErrorMessage = string.Empty;
          //  ObjWorkFlow_HdrDL.InsUser = "5";

          // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
          bool result = true;

          //using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
          //{
          try
          {
              //if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
              //{
              //    objPharmaEntities.Database.Connection.Open();
              //}


              if (Obj_Dtls != null)
              {

                    Hr_EmpDuesVactionTicket loclDtls = new Hr_EmpDuesVactionTicket
                    {
                        EmpHdrId = Obj_Dtls.EmpHdrId,
                        Branch_Id = Obj_Dtls.Branch_Id,
                        Company_Id = Obj_Dtls.Company_Id,
                        GradeJob_Id = Obj_Dtls.GradeJob_Id,
                        Emp_Serial_No = 0,
                        VactionPeriod = Obj_Dtls.VactionPeriod,
                        VactionTicketType = Obj_Dtls.VactionTicketType,
                        InternationalWorkTicketType = Obj_Dtls.InternationalWorkTicketType,
                        LocalWorkTicketType = Obj_Dtls.LocalWorkTicketType,
                        WorkingMonthNo = Obj_Dtls.WorkingMonthNo,
                        WorkingPeriodType = Obj_Dtls.WorkingPeriodType,
                        InsDate = DateTime.Now,
                        InsUser = Obj_Dtls.InsUser,
                        CountTicket = Obj_Dtls.CountTicket

                  };

                  varContext.Hr_EmpDuesVactionTicket.Add(loclDtls);
                  varContext.SaveChanges();
                  //saves all above operations within one transaction
                  // objPharmaEntities.SaveChanges();

                  // dbTran.Commit();
                  // }



              }
              //}


              //commit transaction
              //  dbTran.Commit();
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
             // varContext.Database.Connection.Close();
              //  dbTran.Dispose();

              if (!string.IsNullOrEmpty(strErrorMessage))
              {
                  SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
              }

          }
          return result;

          //  }

      }

      public bool UpdateNewRecordByContext(Hr_EmpDuesVactionTicket objUpdate, AthelHREntities varContext)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          var strErrorMessage = string.Empty;
          //  ObjWorkFlow_HdrDL.InsUser = "5";

          // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
          bool result = true;

          //using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
          //{
          try
          {
              //string strBranch_Id = Obj_Dtls.Branch_Id.ToString();
              //string strCompany_Id = Obj_Dtls.Company_Id.ToString();
              //Guid? strEmpHdrId = Obj_Dtls.EmpHdrId;
              //decimal strEmpSerial_No = Obj_Dtls.Emp_Serial_No;

              //if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && strEmpHdrId != null && strEmpSerial_No != null)
              //{
              //    result = DeleteEmpVactionTicket(strBranch_Id, strCompany_Id, strEmpHdrId, strEmpSerial_No, varContext);
              //}



             

                  if (objUpdate != null)
                  {
                      Hr_EmpDuesVactionTicket ObjForUpdate = (from objLinq in varContext.Hr_EmpDuesVactionTicket
                                                              where objLinq.Emp_Serial_No == objUpdate.Emp_Serial_No && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id && objLinq.EmpHdrId == objUpdate.EmpHdrId 
                                                   select objLinq).FirstOrDefault();


                      if (ObjForUpdate != null)
                      {
                          ObjForUpdate.EmpHdrId = objUpdate.EmpHdrId;

                          ObjForUpdate.Branch_Id = objUpdate.Branch_Id;
                          ObjForUpdate.Company_Id = objUpdate.Company_Id;
                          ObjForUpdate.GradeJob_Id = objUpdate.GradeJob_Id;
                          ObjForUpdate.Emp_Serial_No = objUpdate.Emp_Serial_No;
                          ObjForUpdate.VactionPeriod = objUpdate.VactionPeriod;
                          ObjForUpdate.VactionTicketType = objUpdate.VactionTicketType;
                          ObjForUpdate.InternationalWorkTicketType = objUpdate.InternationalWorkTicketType;
                          ObjForUpdate.LocalWorkTicketType = objUpdate.LocalWorkTicketType;
                          ObjForUpdate.WorkingMonthNo = objUpdate.WorkingMonthNo;
                          ObjForUpdate.WorkingPeriodType = objUpdate.WorkingPeriodType;
                          ObjForUpdate.CountTicket = objUpdate.CountTicket;
                          
                          ObjForUpdate.UpdateDate = DateTime.Now;
                          ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                          result = varContext.SaveChanges() > 0;
                      }
                      else 
                      {
                          Hr_EmpDuesVactionTicket loclDtls = new Hr_EmpDuesVactionTicket
                          {
                              EmpHdrId = objUpdate.EmpHdrId,
                              Branch_Id = objUpdate.Branch_Id,
                              Company_Id = objUpdate.Company_Id,
                              GradeJob_Id = objUpdate.GradeJob_Id,
                              Emp_Serial_No = objUpdate.Emp_Serial_No,
                              VactionPeriod = objUpdate.VactionPeriod,
                              VactionTicketType = objUpdate.VactionTicketType,
                              InternationalWorkTicketType = objUpdate.InternationalWorkTicketType,
                              LocalWorkTicketType = objUpdate.LocalWorkTicketType,
                              WorkingMonthNo = objUpdate.WorkingMonthNo,
                              WorkingPeriodType = objUpdate.WorkingPeriodType,
                              CountTicket=objUpdate.CountTicket,
                              InsDate = DateTime.Now,
                              InsUser = objUpdate.UpdateUser,

                          };

                          varContext.Hr_EmpDuesVactionTicket.Add(loclDtls);
                          result = varContext.SaveChanges()>0;
                      }
                      //saves all above operations within one transaction
                      // objPharmaEntities.SaveChanges();

                      // dbTran.Commit();
                      // }


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
              // varContext.Database.Connection.Close();
              //  dbTran.Dispose();

              if (!string.IsNullOrEmpty(strErrorMessage))
              {
                  SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
              }

          }
          return result;

          //  }

      }

      public Hr_EmpDuesVactionTicket SelectAllEmpVactionTicket(string Company_Id, string Branch_Id, decimal Emp_Serial,Guid EmpHdrId)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                Hr_EmpDuesVactionTicket objectList = new Hr_EmpDuesVactionTicket();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpDuesVactionTicket
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_Serial && objLinq.EmpHdrId == EmpHdrId

                               select new
                               {

                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   GradeJob_Id = objLinq.GradeJob_Id,
                                   VactionPeriod = objLinq.VactionPeriod,
                                   VactionTicketType = objLinq.VactionTicketType,
                                   InternationalWorkTicketType = objLinq.InternationalWorkTicketType,
                                   LocalWorkTicketType = objLinq.LocalWorkTicketType,
                                   WorkingMonthNo = objLinq.WorkingMonthNo,
                                   WorkingPeriodType = objLinq.WorkingPeriodType,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   EmpHdrId = objLinq.EmpHdrId,
                                   CountTicket=objLinq.CountTicket,

                               }).FirstOrDefault();
                if (objlist != null)
                {
                    Hr_EmpDuesVactionTicket objEmpVactionTicketDL = new Hr_EmpDuesVactionTicket();

                    objEmpVactionTicketDL.Branch_Id = objlist.Branch_Id;
                    objEmpVactionTicketDL.Company_Id = objlist.Company_Id;
                    objEmpVactionTicketDL.GradeJob_Id = objlist.GradeJob_Id;
                    objEmpVactionTicketDL.VactionPeriod = objlist.VactionPeriod;
                    objEmpVactionTicketDL.VactionTicketType = objlist.VactionTicketType;
                    objEmpVactionTicketDL.InternationalWorkTicketType = objlist.InternationalWorkTicketType;
                    objEmpVactionTicketDL.LocalWorkTicketType = objlist.LocalWorkTicketType;
                    objEmpVactionTicketDL.WorkingMonthNo = objlist.WorkingMonthNo;
                    objEmpVactionTicketDL.WorkingPeriodType = objlist.WorkingPeriodType;
                    objEmpVactionTicketDL.Emp_Serial_No = objlist.Emp_Serial_No;
                    objEmpVactionTicketDL.CountTicket = objlist.CountTicket;

                    objEmpVactionTicketDL.EmpHdrId = objlist.EmpHdrId;

                    return objEmpVactionTicketDL;
                }
                else
                {
                    return null;
                }
                
                


              

                //Rec_No ,ReferenceNo ,BranchAccount_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,BranchAccountTypeName ,StatusName 

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

      public bool DeleteEmpVactionTicketByContext(string Branch_Id, string Company_Id, Guid? EmpHdrId, decimal Emp_Serial_No, AthelHREntities VarContext)
        {
            bool result = true;
            Hr_EmpDuesVactionTicket GradeHiringItemToDelete;
            //1. Get student from DB
            //using (var ctx = new AthelHREntities())
           //using (var ctx = VarContext)
           // {


            GradeHiringItemToDelete = VarContext.Hr_EmpDuesVactionTicket.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.EmpHdrId == EmpHdrId && s.Emp_Serial_No == Emp_Serial_No).FirstOrDefault();
            //}

            //Create new context for disconnected scenario
            //using (var newContext = new AthelHREntities())
           //using (var newContext = VarContext)
           // {

                if (GradeHiringItemToDelete != null)
                {
                    VarContext.Entry(GradeHiringItemToDelete).State = System.Data.Entity.EntityState.Deleted;

                    result = VarContext.SaveChanges() > 0;

                }
                

                

            //}
            return result;

        }


     



    }
}
