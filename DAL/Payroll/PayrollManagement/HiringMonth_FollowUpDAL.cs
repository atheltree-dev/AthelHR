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
using BOL.Payroll.PayrollManagement;

namespace DAL.Payroll.PayrollManagement
{
  public  class HiringMonth_FollowUpDAL:CommonDB

    {


     

      public List<HiringMonth_FollowUpDL> SelectAllHiringMonth_FollowUp(string Company_Id, string Branch_Id, decimal Emp_serialNo, string MonthNo)
      {

          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<HiringMonth_FollowUpDL> objectList = new List<HiringMonth_FollowUpDL>();

              var objlist = (from objLinq in objPharmaEntities.Hr_HiringMonth_FollowUp_Hdr 
                             join objlinqhdr in   objPharmaEntities.Hr_HiringMonth_FollowUp_Dtls
                             on objLinq.Rec_Hdr_Id equals objlinqhdr.RecHdr_Id
                             where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_serialNo && objLinq.Month_No==MonthNo
                             orderby objlinqhdr.HireItem_Id
                             //&& objLinq.Grade_Id == Grade_Id

                             select new
                             {

                                 Branch_Id = objLinq.Branch_Id,
                                 Company_Id = objLinq.Company_Id,
                                 Emp_Serial_No = objLinq.Emp_Serial_No,
                                 Month_No = objLinq.Month_No,
                                 HireItem_Id = objlinqhdr.HireItem_Id,
                                 HireItem_Type = objlinqhdr.HireItem_Type,
                                 HireItem_Value = objlinqhdr.HireItem_Value,
                                 HireItem_ActuallValue = objlinqhdr.HireItem_ActuallValue,
                                 HireItem_DiffValue = objlinqhdr.HireItem_DiffValue,
                                 RecHdr_Id = objlinqhdr.RecHdr_Id,
                                 Dtls_Id = objlinqhdr.Dtls_Id,
                                 Sal_Month_Status = objLinq.Sal_Month_Status

                             }).ToList();



              foreach (var obj in objlist)
              {
                  HiringMonth_FollowUpDL objHiringMonth_FollowUpDL = new HiringMonth_FollowUpDL();

                  objHiringMonth_FollowUpDL.BranchId = obj.Branch_Id;
                  objHiringMonth_FollowUpDL.CompanyId = obj.Company_Id;
                  objHiringMonth_FollowUpDL.Emp_Serial_No = obj.Emp_Serial_No;
                  objHiringMonth_FollowUpDL.MonthNo = obj.Month_No;
                  objHiringMonth_FollowUpDL.HireItem_Id = obj.HireItem_Id;
                  objHiringMonth_FollowUpDL.HireItem_Type = obj.HireItem_Type;
                  objHiringMonth_FollowUpDL.HireItem_Value = obj.HireItem_Value;
                  objHiringMonth_FollowUpDL.HireItem_ActuallValue = obj.HireItem_ActuallValue;
                  objHiringMonth_FollowUpDL.HireItem_DiffValue = obj.HireItem_DiffValue;
                  objHiringMonth_FollowUpDL.RecHdr_Id = obj.RecHdr_Id;
                  objHiringMonth_FollowUpDL.Dtls_Id = obj.Dtls_Id;
                  objHiringMonth_FollowUpDL.Sal_Month_Status = obj.Sal_Month_Status;
                  
                  objectList.Add(objHiringMonth_FollowUpDL);

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
       

      public bool UpdateEmpHiringMonth(List<HiringMonth_FollowUpDL> ListDtls, string UserName)
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

              OpenEntityConnection();





              foreach (HiringMonth_FollowUpDL Obj_Dtls in ListDtls)
              {
                  if (Obj_Dtls != null)
                  {

                      


                      Hr_HiringMonth_FollowUp_Dtls loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_HiringMonth_FollowUp_Dtls
                                                                     join objlinqhdr in objPharmaEntities.Hr_HiringMonth_FollowUp_Hdr
                                                                     on objLinq.RecHdr_Id equals objlinqhdr.Rec_Hdr_Id
                                                                     where objlinqhdr.Company_Id == Obj_Dtls.CompanyId && objlinqhdr.Branch_Id == Obj_Dtls.BranchId && objlinqhdr.Emp_Serial_No == Obj_Dtls.Emp_Serial_No && objlinqhdr.Month_No == Obj_Dtls.MonthNo
                                                                     && objLinq.Dtls_Id == Obj_Dtls.Dtls_Id && objLinq.HireItem_Id == Obj_Dtls.HireItem_Id
                                                   select objLinq).FirstOrDefault();

                      if (loclDtlsUpdate != null)
                      {
                          loclDtlsUpdate.HireItem_ActuallValue = Obj_Dtls.HireItem_ActuallValue;
                          loclDtlsUpdate.HireItem_DiffValue = Obj_Dtls.HireItem_DiffValue;

                          loclDtlsUpdate.UpdateDate = DateTime.Now;
                          loclDtlsUpdate.UpdateUser = UserName;

                          objPharmaEntities.SaveChanges();
                          //  dbTran.Commit();
                      }
                      


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
              CloseEntityConnection();
          }
          return result;

          //  }

      }






      public string FillEmpHiringMonthDues(string Company_Id, string Branch_Id, string MonthNo)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();




              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo)};

              var objlist = objPharmaEntities.Database.SqlQuery<string>("exec dbo.SPFillHiringMonth_FollowUp @Company_Id,@Branch_Id,@MonthNo", param1).FirstOrDefault<string>();

              objlist = (objlist == null ? "0" : objlist);

              return objlist;

              //Rec_No ,ReferenceNo ,Request_Id 
              //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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

                       //  SaveErrorLog(errorCode, message, UserName, StrClassName, strFunctionName);


                     }

                 }

                 throw raise;


              }
          catch (Exception ex)
          {
              catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                      this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
              ex.InnerException.Message.ToString();
              return "0";

          }
          finally
          {
              CloseEntityConnection();
          }


      }

      public string ReFillEmpHiringMonthDues(string Company_Id, string Branch_Id, string MonthNo)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();
              

              

              int resultdel;
              var objlist ="0" ;
              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo)};
              object[] param2 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo)};

              resultdel = objPharmaEntities.Database.ExecuteSqlCommand("delete from Hr_Emp_HiringMonthStatus where MonthNo=@MonthNo and Company_Id=@Company_Id and Branch_Id = @Branch_Id", param1);

              if (resultdel > 0)
              {
                   objlist = objPharmaEntities.Database.SqlQuery<string>("exec dbo.SPFillHiringMonth_FollowUp @Company_Id,@Branch_Id,@MonthNo", param2).FirstOrDefault<string>();
              }
             
              objlist = (objlist == null ? "0" : objlist);

              return objlist;

              //Rec_No ,ReferenceNo ,Request_Id 
              //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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

                      //  SaveErrorLog(errorCode, message, UserName, StrClassName, strFunctionName);


                  }

              }

              throw raise;


          }
          catch (Exception ex)
          {
              catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                      this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
              ex.InnerException.Message.ToString();
              return "0";

          }
          finally
          {
              CloseEntityConnection();
          }


      }

    


      public string CheckAdoptingDuesMonth(string Company_Id, string Branch_Id, string MonthNo)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();
          string result = "0";
          try
          {


              OpenEntityConnection();


              //   string sql = "select top 1  Sal_Month_Status from  Hr_HiringMonth_FollowUp_Hdr where Company_Id ='" + Company_Id + "' and Branch_Id ='" + Branch_Id + "' and Month_No ='" + MonthNo + "'";

              string sql = "select top 1  Sal_Month_Status from  Hr_HiringMonth_FollowUp_Hdr where Company_Id ='" + Company_Id + "' and Branch_Id ='" + Branch_Id + "' and Month_No ='" + MonthNo + "'";


              var loclDtlsUpdate = objPharmaEntities.Database.SqlQuery<byte>(sql).FirstOrDefault().ToString();

              //var loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_HiringMonth_FollowUp_Hdr
              //                      where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Month_No == MonthNo
              //                                               select objLinq).FirstOrDefault();
              if (loclDtlsUpdate != null)
              {
                  // result = loclDtlsUpdate.Sal_Month_Status.ToString();
                  result = Convert.ToString(loclDtlsUpdate);
              }
              else
              {
                  result = "2";
              }



              return result;

              //Rec_No ,ReferenceNo ,Request_Id 
              //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

          }
          catch (Exception ex)
          {
              catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                      this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
              ex.InnerException.Message.ToString();
              return "0";

          }
          finally
          {
              CloseEntityConnection();
          }


      }

      public MonthStatusDL GetMonthStatus(string Company_Id, string Branch_Id, string MonthNo)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();
         
          try
          {


              OpenEntityConnection();
              MonthStatusDL objMonthStatusDL = new MonthStatusDL();
               var objlist = (from objLinq in objPharmaEntities.Hr_Emp_HiringMonthStatus
                             where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.MonthNo == MonthNo

                             select new
                             {
                                 AdoptedIsDone = objLinq.AdoptedIsDone,
                                 PreparedIsDone = objLinq.PreparedIsDone
                             }).FirstOrDefault();

              if (objlist != null) { 
                   objMonthStatusDL.PreparedIsDone = objlist.PreparedIsDone;
                    objMonthStatusDL.AdoptedIsDone = objlist.AdoptedIsDone;
                  }



              return objMonthStatusDL;

            

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


      



      public List<HiringMonth_FollowUpDL> GetEmpHiringMonthDues(string Company_Id, string Branch_Id, string MonthNo)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<HiringMonth_FollowUpDL> objectList = new List<HiringMonth_FollowUpDL>();

              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo)};

              var objlist = objPharmaEntities.Database.SqlQuery<HiringMonth_FollowUpDL>("exec dbo.SPGetEmpMonthDues @Company_Id,@Branch_Id,@MonthNo", param1).ToList();

              foreach (var obj in objlist)
              {
                  HiringMonth_FollowUpDL objHiringMonth_FollowUpDL = new HiringMonth_FollowUpDL();
                  objHiringMonth_FollowUpDL.HireItem_Id = obj.HireItem_Id;
                  objHiringMonth_FollowUpDL.HireItem_Name = obj.HireItem_Name;
                  objHiringMonth_FollowUpDL.HireItem_NameEn = obj.HireItem_NameEn;
                  objHiringMonth_FollowUpDL.HireItem_Value = obj.HireItem_Value;
                  objHiringMonth_FollowUpDL.Emp_Serial_No = obj.Emp_Serial_No;
                  objHiringMonth_FollowUpDL.HireItem_Type = obj.HireItem_Type;
                  objHiringMonth_FollowUpDL.CompanyId = obj.CompanyId;
                  objHiringMonth_FollowUpDL.BranchId = obj.BranchId;
                  objHiringMonth_FollowUpDL.MonthNo = obj.MonthNo;
                  objectList.Add(objHiringMonth_FollowUpDL);

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
