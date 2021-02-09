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
using BOL.HR.Registeration;

namespace DAL.HR.Registeration
{
  public  class EmpDuesDAL:CommonDB

    {

      public bool AddEmpDues(List<Hr_EmpDues> ListDtls, Guid strEmpHdrId,string UserName)
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



                    foreach (Hr_EmpDues Obj_Dtls in ListDtls)
                    {
                        if (Obj_Dtls != null)
                        {

                            Hr_EmpDues loclDtls = new Hr_EmpDues
                            {
                                EmpHdrId = strEmpHdrId,
                                Branch_Id = Obj_Dtls.Branch_Id,
                                Company_Id = Obj_Dtls.Company_Id,
                                GradeJob_Id = Obj_Dtls.GradeJob_Id,
                                Grade_Id = Obj_Dtls.Grade_Id,
                                HireItem_Id = Obj_Dtls.HireItem_Id,
                                Emp_Serial_No = 0,
                                //HireItem_Value_Type = Obj_Dtls.HireItem_Value_Type,
                                HireItem_Value = Obj_Dtls.HireItem_Value,
                                InsDate = DateTime.Now,
                                InsUser = UserName,

                            };

                            objPharmaEntities.Hr_EmpDues.Add(loclDtls);
                            //saves all above operations within one transaction
                            //objPharmaEntities.SaveChanges();

                            // dbTran.Commit();
                            // }



                        }
                    }

                    return result;
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



      public bool AddEmpDuesByContext(List<Hr_EmpDues> ListDtls, Guid strEmpHdrId, string UserName, AthelHREntities VarContext)
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
                        //string strBranch_Id = ListDtls[0].Branch_Id.ToString();
                        //string strCompany_Id = ListDtls[0].Company_Id.ToString();
                        //decimal strGrade_Id = ListDtls[0].Grade_Id;
                       

                  



                        foreach (Hr_EmpDues Obj_Dtls in ListDtls)
                        {
                            if (Obj_Dtls != null)
                            {

                                Hr_EmpDues loclDtls = new Hr_EmpDues
                                {
                                    EmpHdrId = strEmpHdrId,
                                    Branch_Id = Obj_Dtls.Branch_Id,
                                    Company_Id = Obj_Dtls.Company_Id,
                                    GradeJob_Id = Obj_Dtls.GradeJob_Id,
                                    Grade_Id = Obj_Dtls.Grade_Id,
                                    HireItem_Id = Obj_Dtls.HireItem_Id,
                                    Emp_Serial_No = 0,
                                    RowState = "0",
                                    Rec_Status = 0,
                                    HireItem_Value = Obj_Dtls.HireItem_Value,
                                    InsDate = DateTime.Now,
                                    InsUser = UserName,

                                };

                                VarContext.Hr_EmpDues.Add(loclDtls);
                                VarContext.SaveChanges();
                                //saves all above operations within one transaction
                                //objPharmaEntities.SaveChanges();

                                // dbTran.Commit();
                                // }



                            }
                        }
                    
              return result;
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
              // objPharmaEntities.Database.Connection.Close();
              //  dbTran.Dispose();

              if (!string.IsNullOrEmpty(strErrorMessage))
              {
                  SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
              }

          }
          return result;

          //  }

      }





      public List<Hr_EmpDues> GetEmpDuesDetails(string Company_Id, string Branch_Id, decimal Emp_Serial, Guid EmpHdrId)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_EmpDues> objectList = new List<Hr_EmpDues>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpDues
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_Serial && objLinq.EmpHdrId == EmpHdrId
                               && objLinq.Rec_Status ==0
                               //&& objLinq.Grade_Id == Grade_Id

                               select new
                               {

                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   GradeJob_Id = objLinq.GradeJob_Id,
                                   Grade_Id = objLinq.Grade_Id,
                                   HireItem_Id = objLinq.HireItem_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   EmpHdrId = objLinq.EmpHdrId,
                                   HireItem_Value = objLinq.HireItem_Value,
                                   Rec_Status = objLinq.Rec_Status,
                                   //RowState =0,
      
                               }).ToList();

                

                 foreach (var obj in objlist)
                {
                    Hr_EmpDues objGradeHiringItemDL = new Hr_EmpDues();

                        objGradeHiringItemDL.Branch_Id = obj.Branch_Id;
                        objGradeHiringItemDL.Company_Id = obj.Company_Id;
                        objGradeHiringItemDL.GradeJob_Id = obj.GradeJob_Id;
                        objGradeHiringItemDL.Grade_Id = obj.Grade_Id;
                        objGradeHiringItemDL.HireItem_Id = obj.HireItem_Id;
                        objGradeHiringItemDL.Emp_Serial_No = obj.Emp_Serial_No;
                        objGradeHiringItemDL.EmpHdrId = obj.EmpHdrId;
                        objGradeHiringItemDL.HireItem_Value = obj.HireItem_Value;
                        objGradeHiringItemDL.Rec_Status = obj.Rec_Status;
                        objGradeHiringItemDL.RowState = "0";
                    objectList.Add(objGradeHiringItemDL);

                }


                return objectList;

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


      public bool UpdateEmpDuesByContext(List<Hr_EmpDues> ListDtls, Guid? strEmpHdrId,decimal strEmpSerial_No, string UserName, AthelHREntities VarContext)
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
              //string strBranch_Id = ListDtls[0].Branch_Id.ToString();
              //string strCompany_Id = ListDtls[0].Company_Id.ToString();

              //if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && strEmpHdrId != null && strEmpSerial_No != null)
              //{
              //    result = DeleteEmpDuesHireItem(strBranch_Id, strCompany_Id, strEmpHdrId, strEmpSerial_No, VarContext);
              //}



            



                  foreach (Hr_EmpDues Obj_Dtls in ListDtls)
                  {
                      if (Obj_Dtls != null)
                      {
                         

                          
                              Hr_EmpDues loclDtlsUpdate = (from objLinq in VarContext.Hr_EmpDues
                                                           where objLinq.Emp_Serial_No == Obj_Dtls.Emp_Serial_No && objLinq.Company_Id == Obj_Dtls.Company_Id && objLinq.Branch_Id == Obj_Dtls.Branch_Id && objLinq.EmpHdrId == Obj_Dtls.EmpHdrId
                                                             && objLinq.HireItem_Id == Obj_Dtls.HireItem_Id
                                                           select objLinq).FirstOrDefault();
                          if (loclDtlsUpdate !=null)
                          {
                              loclDtlsUpdate.EmpHdrId = Obj_Dtls.EmpHdrId;
                              loclDtlsUpdate.Branch_Id = Obj_Dtls.Branch_Id;
                              loclDtlsUpdate.Company_Id = Obj_Dtls.Company_Id;
                              loclDtlsUpdate.GradeJob_Id = Obj_Dtls.GradeJob_Id;
                              loclDtlsUpdate.Grade_Id = Obj_Dtls.Grade_Id;
                              loclDtlsUpdate.HireItem_Id = Obj_Dtls.HireItem_Id;
                              loclDtlsUpdate.Emp_Serial_No = Obj_Dtls.Emp_Serial_No;
                              loclDtlsUpdate.HireItem_Value = Obj_Dtls.HireItem_Value;
                              
                              loclDtlsUpdate.RowState = Obj_Dtls.RowState;
                              loclDtlsUpdate.Rec_Status = Obj_Dtls.Rec_Status;

                              loclDtlsUpdate.UpdateDate =  DateTime.Now;
                              loclDtlsUpdate.UpdateUser = UserName;
                              VarContext.SaveChanges();
                              //  dbTran.Commit();
                          }
                          else { 
                          Hr_EmpDues loclDtls = new Hr_EmpDues
                          {
                              EmpHdrId = strEmpHdrId,
                              Branch_Id = Obj_Dtls.Branch_Id,
                              Company_Id = Obj_Dtls.Company_Id,
                              GradeJob_Id = Obj_Dtls.GradeJob_Id,
                              Grade_Id = Obj_Dtls.Grade_Id,
                              HireItem_Id = Obj_Dtls.HireItem_Id,
                              Emp_Serial_No = strEmpSerial_No,
                              RowState = Obj_Dtls.RowState,
                              Rec_Status = Obj_Dtls.Rec_Status,
                              HireItem_Value = Obj_Dtls.HireItem_Value,
                              InsDate = DateTime.Now,
                              InsUser = UserName,

                          };

                          VarContext.Hr_EmpDues.Add(loclDtls);
                          VarContext.SaveChanges();

                          }


                      }
                  
              }
              return result;
          }
          catch (DbEntityValidationException ex)
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


              //////// Retrieve the error messages as a list of strings.
              //////var errorMessages = ex.EntityValidationErrors
              //////        .SelectMany(x => x.ValidationErrors)
              //////        .Select(x => x.ErrorMessage);

              //////// Join the list to a single string.
              //////var fullErrorMessage = string.Join("; ", errorMessages);

              //////// Combine the original exception message with the new one.
              //////var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
              //////strErrorMessage = fullErrorMessage;
              //////// Throw a new DbEntityValidationException with the improved exception message.
              //////throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
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
              // objPharmaEntities.Database.Connection.Close();
              //  dbTran.Dispose();

              if (!string.IsNullOrEmpty(strErrorMessage))
              {
                  SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
              }

          }
          return result;

          //  }

      }


        public bool DeleteEmpDuesHireItemByContext(string Branch_Id,string Company_Id ,Guid? EmpHdrId,decimal Emp_Serial_No, AthelHREntities VarContext)
        {
            bool result = true;
            List<Hr_EmpDues> GradeHiringItemToDelete;
            //1. Get student from DB
            //using (var ctx = new AthelHREntities())
            //using (var ctx = VarContext)
            //{


                GradeHiringItemToDelete = VarContext.Hr_EmpDues.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.EmpHdrId == EmpHdrId && s.Emp_Serial_No == Emp_Serial_No).ToList();
            //}

            //Create new context for disconnected scenario
            //using (var newContext = new AthelHREntities())
            //using (var newContext = VarContext)
            //{

                foreach (Hr_EmpDues Obj_Dtls in GradeHiringItemToDelete)
                {
                    if (Obj_Dtls != null)
                    {
                        VarContext.Entry(Obj_Dtls).State = System.Data.Entity.EntityState.Deleted;

                        result = VarContext.SaveChanges() > 0;

                    }
                //}



            }
            return result;

        }


        public decimal GetSecondmentValue(string strcomapny, string strbranch, decimal Emp_Serial_No, string SecondType)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            decimal Result = 0;
            object Obj = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql, HireItemId;
                //HireItemId = "004" ;
                //   if(SecondType == "2")
                //   {
                //       HireItemId = "005" ;
                //   }
                //   else if (SecondType == "3")
                //   {
                //       HireItemId = "006";
                //   }

                strsql = " select HireItem_Value from Hr_EmpDues empdues inner join Hr_SecondmentTypes empSec ";
                strsql = strsql + " on  empdues.HireItem_Id = empSec.HireItem_Id ";
                strsql = strsql + " where Branch_Id ="+ strbranch +" and Company_Id ="+ strcomapny+" and Emp_Serial_No ="+ Emp_Serial_No+" and SecondmentTypeId = "+ SecondType +"";

                //strsql = "select  HireItem_Value  from Hr_EmpDues where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " and Emp_Serial_No =" + Emp_Serial_No + "  and HireItem_Id =" + HireItemId + "";
                Obj = objPharmaEntities.Database.SqlQuery<decimal>(strsql).FirstOrDefault<decimal>();
                if (Obj != null)
                {
                    Result = Convert.ToDecimal(Obj);

                }
                else 
                {
                    Result = 0;
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


        public decimal GetEmpTickectValue(string strcomapny, string strbranch, decimal Emp_Serial_No)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            decimal Result = 0;
            object Obj = null;

            try
            {
                

                OpenEntityConnection();
                string strsql;
                

                   strsql = "select  HireItem_Value  from VwEmpTicketValueForAllEmployee where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " and Emp_Serial_No =" + Emp_Serial_No + "";
                Obj = objPharmaEntities.Database.SqlQuery<decimal>(strsql).FirstOrDefault<decimal>();
                if (Obj != null)
                {
                    Result = Convert.ToDecimal(Obj);

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


      


       

    }
}
