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
  public  class PreparingPayrollwithAccrualDAL: CommonDB

    {

      public class HiringEmpDetailsReceivableDuesDL
      {
          public string TransItemDate { get; set; }

          public decimal HireItem_Value { get; set; }

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


      //public List<HiringEmpReceivableDuesDL> SelectAllHiringEmpReceivableDues(string Company_Id, string Branch_Id, decimal Emp_serialNo, string MonthNo)
      //{

      //    StackFrame stackFrame = new StackFrame();
      //    MethodBase methodBase = stackFrame.GetMethod();

      //    try
      //    {


      //        OpenEntityConnection();


      //        List<HiringEmpReceivableDuesDL> objectList = new List<HiringEmpReceivableDuesDL>();

      //        var objlist = (from objLinq in objPharmaEntities.Hr_HiringEmpReceivableDues_Hdr 
      //                       join objlinqhdr in   objPharmaEntities.Hr_HiringEmpReceivableDues_Dtls
      //                       on objLinq.Rec_Hdr_Id equals objlinqhdr.RecHdr_Id
      //                       where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_serialNo && objLinq.Month_No==MonthNo
      //                       orderby objlinqhdr.HireItem_Id
      //                       //&& objLinq.Grade_Id == Grade_Id

      //                       select new
      //                       {

      //                           Branch_Id = objLinq.Branch_Id,
      //                           Company_Id = objLinq.Company_Id,
      //                           Emp_Serial_No = objLinq.Emp_Serial_No,
      //                           Month_No = objLinq.Month_No,
      //                           HireItem_Id = objlinqhdr.HireItem_Id,
      //                           HireItem_Type = objlinqhdr.HireItem_Type,
      //                           HireItem_Value = objlinqhdr.HireItem_Value,
      //                           HireItem_ActuallValue = objlinqhdr.HireItem_ActuallValue,
      //                           HireItem_DiffValue = objlinqhdr.HireItem_DiffValue,
      //                           RecHdr_Id = objlinqhdr.RecHdr_Id,
      //                           Dtls_Id = objlinqhdr.Dtls_Id

      //                       }).ToList();



      //        foreach (var obj in objlist)
      //        {
      //            HiringEmpReceivableDuesDL objHiringEmpReceivableDuesDL = new HiringEmpReceivableDuesDL();

      //            objHiringEmpReceivableDuesDL.BranchId = obj.Branch_Id;
      //            objHiringEmpReceivableDuesDL.CompanyId = obj.Company_Id;
      //            objHiringEmpReceivableDuesDL.Emp_Serial_No = obj.Emp_Serial_No;
      //            objHiringEmpReceivableDuesDL.MonthNo = obj.Month_No;
      //            objHiringEmpReceivableDuesDL.HireItem_Id = obj.HireItem_Id;
      //            objHiringEmpReceivableDuesDL.HireItem_Type = obj.HireItem_Type;
      //            objHiringEmpReceivableDuesDL.HireItem_Value = obj.HireItem_Value;
      //            objHiringEmpReceivableDuesDL.HireItem_ActuallValue = obj.HireItem_ActuallValue;
      //            objHiringEmpReceivableDuesDL.HireItem_DiffValue = obj.HireItem_DiffValue;
      //            objHiringEmpReceivableDuesDL.RecHdr_Id = obj.RecHdr_Id;
      //            objHiringEmpReceivableDuesDL.Dtls_Id = obj.Dtls_Id;
                  
      //            objectList.Add(objHiringEmpReceivableDuesDL);

      //        }


      //        return objectList;

      //        //Rec_No ,ReferenceNo ,BranchAccount_Id 
      //        //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,BranchAccountTypeName ,StatusName 

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



     

      public string FillPayrollWitAccrualData(string Company_Id, string Branch_Id, string MonthNo,decimal Emp_Serial_No)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();
          try
          {
             OpenEntityConnection();
              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No)};

              var objlist = objPharmaEntities.Database.SqlQuery<string>("exec dbo.SPFillHiringMonth_ActuallDues @Company_Id,@Branch_Id,@MonthNo,@Emp_Serial_No", param1).FirstOrDefault<string>();

              objlist =(objlist == null?"0":objlist);

              return objlist;

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

      public string ReFillEmpHiringMonthDues(string Company_Id, string Branch_Id, string MonthNo, decimal Emp_Serial_No)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              int resultdel;
              var objlist = "0";
              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo)
                                };
              object[] param2 = { 
               new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No)
                                };

              resultdel = objPharmaEntities.Database.ExecuteSqlCommand("delete from Hr_Emp_HiringMonthStatus where MonthNo=@MonthNo and Company_Id=@Company_Id and Branch_Id = @Branch_Id", param1);

              if (resultdel > 0)
              {
                   objlist = objPharmaEntities.Database.SqlQuery<string>("exec dbo.SPFillHiringMonth_ActuallDues @Company_Id,@Branch_Id,@MonthNo,@Emp_Serial_No", param2).FirstOrDefault<string>();
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



        public string ConfirmPayrollWitAccrualData(string Company_Id, string Branch_Id, string MonthNo, decimal Emp_Serial_No)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                OpenEntityConnection();
                object[] param1 = {
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No)};

                var objlist = objPharmaEntities.Database.SqlQuery<string>("exec dbo.SPConfirmHiringMonth_ActuallDues @Company_Id,@Branch_Id,@MonthNo,@Emp_Serial_No", param1).FirstOrDefault<string>();

                objlist = (objlist == null ? "0" : objlist);

                return objlist;

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



    }
}
