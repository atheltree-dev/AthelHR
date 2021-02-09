using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
//using BOL.Registeration.Registeration;
using System.Data;

// For execute any sqlcommand
using System.Data.Entity;

using System.Data.SqlClient;
using System.Data.Entity.Validation;
using BOL.Payroll.PayrollManagement;

namespace DAL.Payroll.PayrollManagement
{
    public class HiringMonthlyAccruedDuesDAL : CommonDB

    {

        public class HiringEmpDetailseDuesDL
        {
            public string Company_Id { get; set; }
            public string Branch_Id { get; set; }
            public decimal? Emp_Serial_no { get; set; }
            public string MonthNo { get; set; }
            public string HireItem_Id { get; set; }
            public string HireItem_Name { get; set; }
            public string HireItem_NameEn { get; set; }
            public decimal? NetAccrued_days { get; set; }
            public decimal? NetAccrued_Amount { get; set; }
            public byte IsPayed { get; set; }
            public byte TransType { get; set; }
            public byte IsOpening { get; set; }


        }

        public class HiringEmpHiringNotAdoptDL
        {


            public Guid Hdr_Id { get; set; }
            public string NameAr { get; set; }

            public string NameEn { get; set; }

            public decimal Emp_Serial_No { get; set; }

        }

        public class HiringEmpHiringNotAdoptDtlsDL
        {


            public Guid Hdr_Id { get; set; }
            public Guid Dtls_Id { get; set; }
            public string HireItemId { get; set; }

            public string HireItemName { get; set; }

            public decimal HireItemValue { get; set; }
            public Nullable<byte> Confirmed { get; set; }

        }





        //public bool AddEmpHiringMonthlyDuees(List<Hr_HiringMonthlyDuesPayment> ListDtls, List<Hr_HiringMonthlyAccruedDues> ListPayedDtls)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    var strErrorMessage = string.Empty;

        //    bool result = true;

        //    try
        //    {
        //          int resultInsertEmployee = 0;
        //          Guid Rec_Hdr_Id;
        //          Rec_Hdr_Id = GetNewHeaderId();
        //          using (AthelHREntities varcontext = new AthelHREntities())
        //          {
        //              using (var dbContextTransaction = varcontext.Database.BeginTransaction())
        //              {

        //                  try
        //                  {
        //                      if (varcontext.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                      {
        //                          varcontext.Database.Connection.Open();
        //                      }

        //                      //OpenEntityConnection();



        //                      result = AddEmpHiringMonthlyDueesByContext(ListDtls, Rec_Hdr_Id, UserNameProperty, varcontext);

        //                      if (result)
        //                      {

        //                   //       result = UpdateEmpDuesByContext(ListDtlsEmpDus, varEmpHdrId, varEmpSerialNo, UserNameProperty, varcontext);


        //                          result = UpdateEmpAccruedDuesByContext(ListDtls, ListPayedDtls , Rec_Hdr_Id, varcontext);

        //                          if (result)
        //                          {


        //                              result =true;
        //                              varcontext.SaveChanges();
        //                              dbContextTransaction.Commit();
        //                          }
        //                          else
        //                          {
        //                              dbContextTransaction.Rollback();
        //                              result = false;
        //                          }

        //                      }
        //                      //}



        //                      else
        //                      {
        //                          dbContextTransaction.Rollback();
        //                          result = false;
        //                      }

        //                  }
        //                  catch (DbEntityValidationException ex)
        //                  {
        //                      var errorMessages = ex.EntityValidationErrors
        //                              .SelectMany(x => x.ValidationErrors)
        //                             .Select(x => x.ErrorMessage);

        //                      // Join the list to a single string.
        //                      var fullErrorMessage = string.Join("; ", errorMessages);

        //                      // Combine the original exception message with the new one.
        //                      var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
        //                      strErrorMessage = fullErrorMessage;
        //                      // Throw a new DbEntityValidationException with the improved exception message.
        //                      throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        //                      //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
        //                      //   dbTran.Rollback();
        //                      dbContextTransaction.Rollback();
        //                      result = false;

        //                  }
        //                  catch (NullReferenceException ex)
        //                  {
        //                      dbContextTransaction.Rollback();

        //                      string.Concat("Processor Usage" + ex.Message);
        //                  }

        //                  //--- End Try Of Using
        //                  catch (Exception ex)
        //                  {
        //                      dbContextTransaction.Rollback(); //Required according to MSDN article 
        //                      throw; //Not in MSDN article, but recommended so the exception still bubbles up
        //                  }

        //                  finally
        //                  {

        //                      varcontext.Database.Connection.Close();
        //                      dbContextTransaction.Dispose();
        //                  }

        //                  //--- End catch
        //              }
        //              //--- End Using
        //          }

        //          if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //        {
        //            objPharmaEntities.Database.Connection.Open();
        //        }




        //        return result;
        //    }
        //    catch (DbEntityValidationException ex)
        //    {


        //        // Retrieve the error messages as a list of strings.
        //        var errorMessages = ex.EntityValidationErrors
        //                .SelectMany(x => x.ValidationErrors)
        //                .Select(x => x.ErrorMessage);

        //        // Join the list to a single string.
        //        var fullErrorMessage = string.Join("; ", errorMessages);

        //        // Combine the original exception message with the new one.
        //        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
        //        strErrorMessage = fullErrorMessage;
        //        // Throw a new DbEntityValidationException with the improved exception message.
        //        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        //        //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
        //        //   dbTran.Rollback();
        //        result = false;

        //    }

        //    catch (Exception ex)
        //    {

        //        //Rollback transaction if exception occurs
        //        //  dbTran.Rollback();
        //        result = false;

        //    }

        //    finally
        //    {
        //        objPharmaEntities.Database.Connection.Close();
        //        //  dbTran.Dispose();

        //        if (!string.IsNullOrEmpty(strErrorMessage))
        //        {
        //            SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        }

        //    }
        //    return result;

        //    //  }
        //}


        //  public bool AddEmpHiringMonthlyDueesByContext(List<Hr_HiringMonthlyDuesPayment> ListDtls, Guid Rec_Hdr_Id, string UserName, AthelHREntities VarContext)
        //  {
        //      StackFrame stackFrame = new StackFrame();
        //      MethodBase methodBase = stackFrame.GetMethod();

        //      var strErrorMessage = string.Empty;

        //      bool result = true;


        //      try
        //      {


        //          foreach (Hr_HiringMonthlyDuesPayment Obj_Dtls in ListDtls)
        //          {
        //              if (Obj_Dtls != null)
        //              {

        //                  Hr_HiringMonthlyDuesPayment loclDtls = new Hr_HiringMonthlyDuesPayment
        //                  {

        //                      Rec_Hdr_Id = Rec_Hdr_Id,
        //                      Company_Id = Obj_Dtls.Company_Id,
        //                      Branch_Id = Obj_Dtls.Branch_Id,
        //                      Emp_Serial_no = Obj_Dtls.Emp_Serial_no,
        //                      HireItemValue = Obj_Dtls.HireItemValue,
        //                      IsPosted = Obj_Dtls.IsPosted,
        //                      Accrued_HireItem_Id = Obj_Dtls.Accrued_HireItem_Id,
        //                      MonthNo = Obj_Dtls.MonthNo,
        //                      Payed_Days=Obj_Dtls.Payed_Days




        //                  };

        //                  VarContext.Hr_HiringMonthlyDuesPayment.Add(loclDtls);

        //                  //saves all above operations within one transaction
        //                  VarContext.SaveChanges();
        //              }




        //          }

        //          return result;
        //      }
        //      catch (DbEntityValidationException ex)
        //      {


        //          // Retrieve the error messages as a list of strings.
        //          var errorMessages = ex.EntityValidationErrors
        //                  .SelectMany(x => x.ValidationErrors)
        //                  .Select(x => x.ErrorMessage);

        //          // Join the list to a single string.
        //          var fullErrorMessage = string.Join("; ", errorMessages);

        //          // Combine the original exception message with the new one.
        //          var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
        //          strErrorMessage = fullErrorMessage;
        //          // Throw a new DbEntityValidationException with the improved exception message.
        //          throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        //          //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
        //          //   dbTran.Rollback();
        //          result = false;

        //      }

        //      catch (Exception ex)
        //      {

        //          //Rollback transaction if exception occurs
        //          //  dbTran.Rollback();
        //          result = false;

        //      }

        //      finally
        //      {
        //          // objPharmaEntities.Database.Connection.Close();
        //          //  dbTran.Dispose();

        //          if (!string.IsNullOrEmpty(strErrorMessage))
        //          {
        //              SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //          }

        //      }
        //      return result;

        //      //  }

        //  }

        //  public bool UpdateEmpAccruedDuesByContext(List<Hr_HiringMonthlyDuesPayment> ListDtls , List<Hr_HiringMonthlyAccruedDues> ListPayedDtls, Guid Rec_Hdr_Id, AthelHREntities VarContext)
        //  {
        //      StackFrame stackFrame = new StackFrame();
        //      MethodBase methodBase = stackFrame.GetMethod();

        //      var strErrorMessage = string.Empty;
        //      //  ObjWorkFlow_HdrDL.InsUser = "5";

        //      // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
        //      bool result = true;


        //      try
        //      {

        //          foreach (Hr_HiringMonthlyAccruedDues Obj_PayedDtls in ListPayedDtls)
        //          {
        //              if (Obj_PayedDtls != null)
        //              {
        //                  Hr_HiringMonthlyAccruedDues loclDtlsUpdate = (from objLinq in VarContext.Hr_HiringMonthlyAccruedDues
        //                                                                where objLinq.Emp_Serial_no == Obj_PayedDtls.Emp_Serial_no && objLinq.Company_Id == Obj_PayedDtls.Company_Id && objLinq.Branch_Id == Obj_PayedDtls.Branch_Id
        //                                                 && objLinq.Accrued_HireItem_Id == Obj_PayedDtls.Accrued_HireItem_Id && objLinq.IsPayed == 0 && objLinq.MonthNo == Obj_PayedDtls.MonthNo
        //                                                                select objLinq).FirstOrDefault();

        //                  if (loclDtlsUpdate != null)
        //                  {
        //                      //loclDtlsUpdate.Rec_Hdr_Id = loclDtlsUpdate.Rec_Hdr_Id;

        //                      loclDtlsUpdate.PaymentDues_Hdr = Rec_Hdr_Id;
        //                      loclDtlsUpdate.IsPayed = 1;
        //                  }


        //                  VarContext.SaveChanges();
        //              }
        //          }



        //          return result;
        //      }
        //      catch (DbEntityValidationException ex)
        //      {
        //          Exception raise = ex;

        //          foreach (var validationErrors in ex.EntityValidationErrors)
        //          {

        //              foreach (var validationError in validationErrors.ValidationErrors)
        //              {

        //                  string message = string.Format("{0}:{1}",

        //                      validationErrors.Entry.Entity.ToString(),

        //                    validationError.ErrorMessage);

        //                  // raise a new exception nesting

        //                  // the current instance as InnerException

        //                  raise = new InvalidOperationException(message, raise);




        //              }

        //          }

        //          throw raise;

        //          result = false;

        //      }

        //      catch (Exception ex)
        //      {

        //          //Rollback transaction if exception occurs
        //          //  dbTran.Rollback();
        //          result = false;

        //      }

        //      finally
        //      {
        //          // objPharmaEntities.Database.Connection.Close();
        //          //  dbTran.Dispose();

        //          if (!string.IsNullOrEmpty(strErrorMessage))
        //          {
        //              SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //          }

        //      }
        //      return result;

        //      //  }

        //  }



        public bool AddEmpHiringMonthlyDuees(List<Hr_HiringMonthlyDuesPayment> ListDtls)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            var strErrorMessage = string.Empty;

            bool result = true;


            try
            {


                foreach (Hr_HiringMonthlyDuesPayment Obj_Dtls in ListDtls)
                {
                    if (Obj_Dtls != null)
                    {

                        Hr_HiringMonthlyDuesPayment loclDtls = new Hr_HiringMonthlyDuesPayment
                        {

                            Rec_Hdr_Id = GetNewHeaderId(),
                            Company_Id = Obj_Dtls.Company_Id,
                            Branch_Id = Obj_Dtls.Branch_Id,
                            Emp_Serial_no = Obj_Dtls.Emp_Serial_no,
                            HireItemValue = Obj_Dtls.HireItemValue,
                            IsPosted = Obj_Dtls.IsPosted,
                            Accrued_HireItem_Id = Obj_Dtls.Accrued_HireItem_Id,
                            MonthNo = Obj_Dtls.MonthNo,
                            Payed_Days = Obj_Dtls.Payed_Days,
                            TransDate= Obj_Dtls.TransDate,
                            InsUser=UserNameProperty,
                            InsDate=DateTime.Now







                        };

                        objPharmaEntities.Hr_HiringMonthlyDuesPayment.Add(loclDtls);

                        //saves all above operations within one transaction
                        objPharmaEntities.SaveChanges();
                    }




                }

                return result;
            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return false;

            }
            finally
            {
                CloseEntityConnection();
            }



        }

      

    


    public List<HiringMonthlyAccruedDuesDL> GetEmpMonthDue (string Company_Id, string Branch_Id,decimal EmpSerial_No,string HireItem,int flag)// string MonthNo,
        {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<HiringMonthlyAccruedDuesDL> objectList = new List<HiringMonthlyAccruedDuesDL>();

              object[] param1 = {
               new SqlParameter("@Company_Id", Company_Id),
               new SqlParameter("@Branch_Id", Branch_Id),
               new SqlParameter("@Emp_Serial_No", EmpSerial_No),
               //new SqlParameter("@Month_No", MonthNo),
               new SqlParameter("@HireItem",HireItem),
               new SqlParameter("@flag",flag)
                };
              
              var objlist = objPharmaEntities.Database.SqlQuery<HiringMonthlyAccruedDuesDL>("exec dbo.sp_GetMonthlyAccruedDues @Company_Id,@Branch_Id, @Emp_Serial_No,@HireItem,@flag", param1).ToList();
               
            
              foreach (var obj in objlist)
              {
                    HiringMonthlyAccruedDuesDL HiringMonthlyAccruedDuesDL = new HiringMonthlyAccruedDuesDL();
                    HiringMonthlyAccruedDuesDL.Company_Id = obj.Company_Id;
                    HiringMonthlyAccruedDuesDL.Branch_Id = obj.Branch_Id;
                    HiringMonthlyAccruedDuesDL.Emp_Serial_no = obj.Emp_Serial_no;
                    HiringMonthlyAccruedDuesDL.MonthNo = obj.MonthNo;
                    HiringMonthlyAccruedDuesDL.HireItem_Id = obj.HireItem_Id;
                    HiringMonthlyAccruedDuesDL.HireItem_Name = obj.HireItem_Name;
                    HiringMonthlyAccruedDuesDL.HireItem_NameEn = obj.HireItem_NameEn;
                    HiringMonthlyAccruedDuesDL.OpeningBalance_days = obj.OpeningBalance_days;
                    HiringMonthlyAccruedDuesDL.OpeningBalance_Amount = obj.OpeningBalance_Amount;
                    HiringMonthlyAccruedDuesDL.TransAccrued_days = obj.TransAccrued_days;
                    HiringMonthlyAccruedDuesDL.TransAccrued_Amount = obj.TransAccrued_Amount;
                    HiringMonthlyAccruedDuesDL.TotalAccrued_days = obj.TotalAccrued_days;
                    HiringMonthlyAccruedDuesDL.TotalAccrued_Amount = obj.TotalAccrued_Amount;
                    HiringMonthlyAccruedDuesDL.PayedAccrued_days = obj.PayedAccrued_days;
                    HiringMonthlyAccruedDuesDL.PayedAccrued_Amount = obj.PayedAccrued_Amount;
                    HiringMonthlyAccruedDuesDL.NetAccrued_days = obj.NetAccrued_days;
                    HiringMonthlyAccruedDuesDL.NetAccrued_Amount = obj.NetAccrued_Amount;
                    HiringMonthlyAccruedDuesDL.SalaryDay = obj.SalaryDay;


                    objectList.Add(HiringMonthlyAccruedDuesDL);

              }



              return objectList;

              //Rec_No ,ReferenceNo ,Request_Id 
              //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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

      public List<HiringEmpDetailseDuesDL> GetEmpDuesDetailsByHireItem(string Company_Id, string Branch_Id, decimal Emp_Serial_no, string Accrued_HireItem_Id)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<HiringEmpDetailseDuesDL> objectList = new List<HiringEmpDetailseDuesDL>();

                object[] param1 = {

                new SqlParameter("@Company_Id", Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_no", Emp_Serial_no),
                new SqlParameter("@Accrued_HireItem_Id", Accrued_HireItem_Id)
             };

              var objlist = objPharmaEntities.Database.SqlQuery<HiringEmpDetailseDuesDL>("exec dbo.SP_GetAccruedItemDetails @Company_Id,@Branch_Id,@Emp_Serial_no,@Accrued_HireItem_Id", param1).ToList();

              foreach (var obj in objlist)
              {
                    HiringEmpDetailseDuesDL HiringEmpDetailseDuesDL = new HiringEmpDetailseDuesDL();
                    HiringEmpDetailseDuesDL.HireItem_Id = obj.HireItem_Id;
                    HiringEmpDetailseDuesDL.Emp_Serial_no = obj.Emp_Serial_no;
                    HiringEmpDetailseDuesDL.HireItem_Name = obj.HireItem_Name;
                    HiringEmpDetailseDuesDL.HireItem_NameEn = obj.HireItem_NameEn;
                    HiringEmpDetailseDuesDL.NetAccrued_days = obj.NetAccrued_days;
                    HiringEmpDetailseDuesDL.NetAccrued_Amount = obj.NetAccrued_Amount;
                    HiringEmpDetailseDuesDL.IsPayed = obj.IsPayed;
                    HiringEmpDetailseDuesDL.MonthNo = obj.MonthNo;
                    HiringEmpDetailseDuesDL.TransType = obj.TransType;
                    HiringEmpDetailseDuesDL.IsOpening = obj.IsOpening;
                    objectList.Add(HiringEmpDetailseDuesDL);

              }



              return objectList;

              //Rec_No ,ReferenceNo ,Request_Id 
              //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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
