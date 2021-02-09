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
  public  class HiringEmpReceivableDuesDAL:CommonDB

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


      public bool AddEmpHiringMonth(List<Hr_HiringEmpReceivableDues_Dtls> ListDtls, string UserName, string Company_Id, string Branch_Id, decimal Emp_serialNo, string MonthNo)
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



              foreach (Hr_HiringEmpReceivableDues_Dtls Obj_Dtls in ListDtls)
              {
                  if (Obj_Dtls != null)
                  {
                      if (Obj_Dtls.Confirmed == 2)
                      {

                          Hr_HiringEmpReceivableDues_Dtls loclDtls = new Hr_HiringEmpReceivableDues_Dtls
                          {

                              Dtls_Id = GetNewHeaderId(),
                              Hdr_Id = Obj_Dtls.Hdr_Id,
                              HireItem_Id = Obj_Dtls.HireItem_Id,
                              HireItem_Value = Obj_Dtls.HireItem_Value,
                              TransItemDate = Obj_Dtls.TransItemDate,
                              DueDate = Obj_Dtls.DueDate,
                              ConfirmDate = Obj_Dtls.ConfirmDate,
                              RecEmpDuesHdr_Id = Obj_Dtls.RecEmpDuesHdr_Id,
                              RecRequestHdr_Id = Obj_Dtls.RecRequestHdr_Id,
                              ConfirmedUpdateDate = DateTime.Now,
                              InsItemDate = DateTime.Now,
                              InsItemUser = UserName,
                              Confirmed = 0

                          };

                          objPharmaEntities.Hr_HiringEmpReceivableDues_Dtls.Add(loclDtls);

                          //saves all above operations within one transaction
                          objPharmaEntities.SaveChanges();
                      }
                      else 
                      {


                          Hr_HiringEmpReceivableDues_Dtls ObjForUpdate = (from objLinq in objPharmaEntities.Hr_HiringEmpReceivableDues_Dtls
                                                                          join objlinqhdr in objPharmaEntities.Hr_HiringEmpReceivableDues_Hdr
                                                                          on objLinq.Hdr_Id equals objlinqhdr.Hdr_Id
                                                                          where objlinqhdr.Company_Id == Company_Id 
                                                                          && objlinqhdr.Branch_Id == Branch_Id && objlinqhdr.Emp_Serial_No == Emp_serialNo
                                                                          && objlinqhdr.Month_No == MonthNo && objLinq.HireItem_Id == Obj_Dtls.HireItem_Id && objLinq.Confirmed == 0
                                                                          && objLinq.RecEmpDuesHdr_Id == Obj_Dtls.RecEmpDuesHdr_Id && objLinq.RecRequestHdr_Id == Obj_Dtls.RecRequestHdr_Id
                                                                          
                                                                          select objLinq).FirstOrDefault();
                          if (ObjForUpdate != null)
                          {
                              ObjForUpdate.HireItem_Value = Obj_Dtls.HireItem_Value;


                              result = objPharmaEntities.SaveChanges() > 0;
                          }
                          else
                              return false;

                      }
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



      public bool AdoptingEmpDuesConfirmed(List<Hr_HiringEmpReceivableDues_Dtls> ListDtls, string UserName)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          var strErrorMessage = string.Empty;
          //  ObjWorkFlow_HdrDL.InsUser = "5";

          // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
          bool result = true;
          int resultdata;

          //using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
          //{
          try
          {
              if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
              {
                  objPharmaEntities.Database.Connection.Open();
              }



              foreach (Hr_HiringEmpReceivableDues_Dtls Obj_Dtls in ListDtls)
              {
                  if (Obj_Dtls != null)
                  {

                      DateTime ConfirmedUpdateDate = DateTime.Now;
                      string monthstr = Convert.ToString((DateTime.Now.Month)).Length == 2 ? (DateTime.Now.Month).ToString() : '0' + (DateTime.Now.Month).ToString();
                      string Daystr = Convert.ToString((DateTime.Now.Day)).Length == 2 ? (DateTime.Now.Day).ToString() : '0' + (DateTime.Now.Day).ToString();
                      string ConfirmDate = (DateTime.Now.Year + "" + monthstr + "" + Daystr);

                       object[] param1 = { 
                                new SqlParameter("@ConfirmedUpdateDate", ConfirmedUpdateDate),
                                new SqlParameter("@ConfirmDate", ConfirmDate),
                                new SqlParameter("@Dtls_Id",Obj_Dtls.Dtls_Id),
                                new SqlParameter("@Hdr_Id", Obj_Dtls.Hdr_Id)
                                         };


                      string sql = "update Hr_HiringEmpReceivableDues_Dtls set Confirmed = 1 where Dtls_Id ='" + Obj_Dtls.Dtls_Id + "' and Hdr_Id ='" + Obj_Dtls.Hdr_Id + "'";

                      resultdata = objPharmaEntities.Database.ExecuteSqlCommand("update Hr_HiringEmpReceivableDues_Dtls set Confirmed = 1,ConfirmedUpdateDate=@ConfirmedUpdateDate,ConfirmDate=@ConfirmDate where Dtls_Id = @Dtls_Id and Hdr_Id=@Hdr_Id", param1);

                      result = resultdata > 0;
                      //var loclDtlsUpdate = objPharmaEntities.Database.SqlQuery<bool>(sql).FirstOrDefault().ToString();

                      // FIRST create a blank object
                      //////Hr_HiringEmpReceivableDues_Dtls obj = objPharmaEntities.Hr_HiringEmpReceivableDues_Dtls.Create();

                      //////// SECOND set the ID
                      //////obj.Dtls_Id = Obj_Dtls.Dtls_Id;
                      //////obj.HireItem_Id = Obj_Dtls.HireItem_Id;
                      //////obj.Hdr_Id = Obj_Dtls.Hdr_Id;
                      //////obj.HireItem_Value = Obj_Dtls.HireItem_Value;
                      //////// THIRD attach the thing (id is not marked as modified)
                      //////objPharmaEntities.Hr_HiringEmpReceivableDues_Dtls.Attach(obj);

                      //////// FOURTH set the fields you want updated.
                      //////obj.Confirmed = 1;

                      //////// FIFTH save that thing
                      //////result = objPharmaEntities.SaveChanges() > 0;


                      //Hr_HiringEmpReceivableDues_Dtls ObjForUpdate = (from objLinq in objPharmaEntities.Hr_HiringEmpReceivableDues_Dtls
                      //                                                where objLinq.Dtls_Id == Obj_Dtls.Dtls_Id && objLinq.Hdr_Id == Obj_Dtls.Hdr_Id
                      //                                                select objLinq).SingleOrDefault();
                      //    if (ObjForUpdate != null)
                      //    {
                      //        ObjForUpdate.Confirmed = Obj_Dtls.Confirmed;
                      //        bool a = objPharmaEntities.ChangeTracker.HasChanges();
                      //        result = objPharmaEntities.SaveChanges() > 0;
                      //    }
                      //    else
                      //        return false;

                      //}

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




     

      public string FillAdoptingMonthSalary(string Company_Id, string Branch_Id, string MonthNo)
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

              var objlist = objPharmaEntities.Database.SqlQuery<string>("exec dbo.SPEtmadEmpMonthSalaries @Company_Id,@Branch_Id,@MonthNo", param1).FirstOrDefault<string>();

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


      public List<HiringEmpReceivableDuesDL> GetTotalEmpDuesByMonth(string Company_Id, string Branch_Id, string MonthNo,decimal EmpSerial_No)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<HiringEmpReceivableDuesDL> objectList = new List<HiringEmpReceivableDuesDL>();

              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Month_No", MonthNo),
                new SqlParameter("@Emp_Serial_No", EmpSerial_No)};

              var objlist = objPharmaEntities.Database.SqlQuery<HiringEmpReceivableDuesDL>("exec dbo.SPGetTotalEmpDuesByMonth @Company_Id,@Branch_Id,@Month_No,@Emp_Serial_No", param1).ToList();

              foreach (var obj in objlist)
              {
                  HiringEmpReceivableDuesDL objHiringEmpReceivableDuesDL = new HiringEmpReceivableDuesDL();
                  objHiringEmpReceivableDuesDL.HireItem_Id = obj.HireItem_Id;
                  objHiringEmpReceivableDuesDL.HireItem_Name = obj.HireItem_Name;
                  objHiringEmpReceivableDuesDL.HireItem_NameEn = obj.HireItem_NameEn;
                  objHiringEmpReceivableDuesDL.Emp_Serial_No = obj.Emp_Serial_No;
                  objHiringEmpReceivableDuesDL.CompanyId = obj.CompanyId;
                  objHiringEmpReceivableDuesDL.BranchId = obj.BranchId;
                  objHiringEmpReceivableDuesDL.MonthNo = obj.MonthNo;
                  objHiringEmpReceivableDuesDL.HireItem_Type = obj.HireItem_Type;
                  objHiringEmpReceivableDuesDL.HireItem_BasicValue = obj.HireItem_BasicValue;
                  objHiringEmpReceivableDuesDL.HireItem_ReceivableValue = obj.HireItem_ReceivableValue;
                  objHiringEmpReceivableDuesDL.HireItem_DuesValue = obj.HireItem_DuesValue;
                  objHiringEmpReceivableDuesDL.NotConfirmHireItem_ReceivableValue = obj.NotConfirmHireItem_ReceivableValue;

                  objHiringEmpReceivableDuesDL.RecEmpDuesHdr_Id = obj.RecEmpDuesHdr_Id;

                  objHiringEmpReceivableDuesDL.RecRequestHdr_Id = obj.RecRequestHdr_Id;
                  
                  


                  objectList.Add(objHiringEmpReceivableDuesDL);

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

      public List<HiringEmpDetailsReceivableDuesDL> GetEmpDuesDetailsByMonth(string Company_Id, string Branch_Id, string MonthNo, decimal EmpSerial_No, string HireItemId, Guid RecEmpDuesHdr_Id, Guid RecRequestHdr_Id)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<HiringEmpDetailsReceivableDuesDL> objectList = new List<HiringEmpDetailsReceivableDuesDL>();

              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Month_No", MonthNo),
                new SqlParameter("@Emp_Serial_No", EmpSerial_No),
                new SqlParameter("@HireItemId", HireItemId),
                new SqlParameter("@RecEmpDuesHdr_Id", RecEmpDuesHdr_Id),
                new SqlParameter("@RecRequestHdr_Id", RecRequestHdr_Id)};

              var objlist = objPharmaEntities.Database.SqlQuery<HiringEmpDetailsReceivableDuesDL>("exec dbo.SPGetEmpDuesDetailsByMonth @Company_Id,@Branch_Id,@Month_No,@Emp_Serial_No,@HireItemId,@RecEmpDuesHdr_Id,@RecRequestHdr_Id", param1).ToList();

              foreach (var obj in objlist)
              {
                  HiringEmpDetailsReceivableDuesDL objHiringEmpDetailsReceivableDuesDL = new HiringEmpDetailsReceivableDuesDL();
                  objHiringEmpDetailsReceivableDuesDL.TransItemDate = obj.TransItemDate;
                  objHiringEmpDetailsReceivableDuesDL.HireItem_Value = obj.HireItem_Value;
                  objectList.Add(objHiringEmpDetailsReceivableDuesDL);

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

      public Guid? GetEmpReceivableHdrId(string strcomapny, string strbranch, decimal strEmpSerialNo,string MonthNo)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {
              OpenEntityConnection();


              Guid varEmpHdrId = objPharmaEntities.Database.SqlQuery<Guid>("select Hdr_Id from Hr_HiringEmpReceivableDues_Hdr where  Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "' and Month_No='" + MonthNo + "' and Emp_Serial_No='" + strEmpSerialNo + "'").FirstOrDefault();

              return varEmpHdrId;

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
      
      public List<HiringEmpHiringNotAdoptDL> GetEmpHiringDuesNeedAdopting(string Company_Id, string Branch_Id, string MonthNo)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<HiringEmpHiringNotAdoptDL> objectList = new List<HiringEmpHiringNotAdoptDL>();

              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo)};

              var objlist = objPharmaEntities.Database.SqlQuery<HiringEmpHiringNotAdoptDL>("exec dbo.SPGetEmpHiringDuesNeedAdopting @Company_Id,@Branch_Id,@MonthNo", param1).ToList();

              foreach (var obj in objlist)
              {
                  HiringEmpHiringNotAdoptDL objHiringEmpHiringNotAdoptDL = new HiringEmpHiringNotAdoptDL();
                  objHiringEmpHiringNotAdoptDL.Hdr_Id = obj.Hdr_Id;
                  objHiringEmpHiringNotAdoptDL.Emp_Serial_No = obj.Emp_Serial_No;
                  objHiringEmpHiringNotAdoptDL.NameAr = obj.NameAr;
                  objHiringEmpHiringNotAdoptDL.NameEn = obj.NameEn;

                  objectList.Add(objHiringEmpHiringNotAdoptDL);

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

      public List<HiringEmpHiringNotAdoptDtlsDL> GetEmpHireItemDuesNeedAdopting(string Company_Id, string Branch_Id, string MonthNo, decimal Emp_serialNo, Guid HdrId)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<HiringEmpHiringNotAdoptDtlsDL> objectList = new List<HiringEmpHiringNotAdoptDtlsDL>();

              var objlist = (from objLinq in objPharmaEntities.Hr_HiringEmpReceivableDues_Hdr
                             join objlinqhdr in objPharmaEntities.Hr_HiringEmpReceivableDues_Dtls
                             on objLinq.Hdr_Id equals objlinqhdr.Hdr_Id 
                             join objHireitem in objPharmaEntities.Hr_Hiring_Items
                             on objlinqhdr.HireItem_Id equals objHireitem.HireItem_Id
                             where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_serialNo && objLinq.Month_No == MonthNo
                             && objlinqhdr.Hdr_Id == HdrId && objlinqhdr.Confirmed == 0
                             orderby objlinqhdr.HireItem_Id
                             //&& objLinq.Grade_Id == Grade_Id

                             select new
                             {
                                 
                                 Hdr_Id = objlinqhdr.Hdr_Id,
                                 Dtls_Id = objlinqhdr.Dtls_Id,
                                 HireItemId = objlinqhdr.HireItem_Id,
                                 HireItemName = objHireitem.HireItem_NameEn,
                                 HireItemValue = objlinqhdr.HireItem_Value,
                                 Confirmed = objlinqhdr.Confirmed


                             }).ToList();



              foreach (var obj in objlist)
              {
                  HiringEmpHiringNotAdoptDtlsDL objHiringEmpHiringNotAdoptDtlsDL = new HiringEmpHiringNotAdoptDtlsDL();

                    objHiringEmpHiringNotAdoptDtlsDL.Hdr_Id = obj.Hdr_Id;
                    objHiringEmpHiringNotAdoptDtlsDL.Dtls_Id = obj.Dtls_Id;
                    objHiringEmpHiringNotAdoptDtlsDL.HireItemId = obj.HireItemId;
                    objHiringEmpHiringNotAdoptDtlsDL.HireItemName = obj.HireItemName;
                    objHiringEmpHiringNotAdoptDtlsDL.HireItemValue = obj.HireItemValue;
                    objHiringEmpHiringNotAdoptDtlsDL.Confirmed = obj.Confirmed;
                    objectList.Add(objHiringEmpHiringNotAdoptDtlsDL);

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
