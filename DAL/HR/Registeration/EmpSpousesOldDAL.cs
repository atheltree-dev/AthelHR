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
  public  class EmpSpousesOldDAL:CommonDB

    {

      public bool AddEmpSpouses(List<Hr_EmpSpouses> ListDtls, Guid strEmpHdrId,string UserName)
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



                    foreach (Hr_EmpSpouses Obj_Dtls in ListDtls)
                    {
                        if (Obj_Dtls != null)
                        {
                            //SpouseNameArabic, SpouseNameEn, SpouseNameConv, SpouseBithDate, MarriedDate, SpouseNationality_Id, 
                            //SpousePassportNo, SpousePassportIssueDate, SpousePassportExpiryDate,SpouseInsuranceNo,SpouseInsuranceIssueDate,SpouseInsuranceExpiryDate,
                            //National_Id, NationalStartDate, NationalEndDate, MarriedContractAttach, SpouseNotes

                            Hr_EmpSpouses loclDtls = new Hr_EmpSpouses
                            {
                                EmpHdrId = strEmpHdrId,
                                Branch_Id = Obj_Dtls.Branch_Id,
                                Company_Id = Obj_Dtls.Company_Id,
                                SpouseNameArabic = Obj_Dtls.SpouseNameArabic,
                                SpouseNameEn = Obj_Dtls.SpouseNameEn,
                                SpouseNameConv= "",
                                SpouseBithDate = Obj_Dtls.SpouseBithDate,
                                MarriedDate = Obj_Dtls.MarriedDate,
                                SpouseNationality_Id = Obj_Dtls.SpouseNationality_Id,
                                SpousePassportNo = Obj_Dtls.SpousePassportNo,
                                SpousePassportIssueDate = Obj_Dtls.SpousePassportIssueDate,
                                SpousePassportExpiryDate = Obj_Dtls.SpousePassportExpiryDate,
                                SpouseInsuranceNo = Obj_Dtls.SpouseInsuranceNo,
                                SpouseInsuranceIssueDate = Obj_Dtls.SpouseInsuranceIssueDate,
                                SpouseInsuranceExpiryDate = Obj_Dtls.SpouseInsuranceExpiryDate,

                                National_Id = Obj_Dtls.National_Id,
                                NationalStartDate = Obj_Dtls.NationalStartDate,
                                NationalEndDate = Obj_Dtls.NationalEndDate,
                                MarriedContractAttach = Obj_Dtls.MarriedContractAttach,
                                SpouseNotes = Obj_Dtls.SpouseNotes,
                                Emp_Serial_No = Obj_Dtls.Emp_Serial_No,
                                //HireItem_Value_Type = Obj_Dtls.HireItem_Value_Type,
                         
                                InsDate = DateTime.Now,
                                InsUser = UserName,

                            };

                            objPharmaEntities.Hr_EmpSpouses.Add(loclDtls);
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


      public bool UpdateEmpSpouses(List<Hr_EmpSpouses> ListDtls, Guid strEmpHdrId, string UserName)
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



                            foreach (Hr_EmpSpouses Obj_Dtls in ListDtls)
                  {
                      if (Obj_Dtls != null)
                      {



                          Hr_EmpSpouses loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_EmpSpouses
                                                           where objLinq.Emp_Serial_No == Obj_Dtls.Emp_Serial_No && objLinq.Company_Id == Obj_Dtls.Company_Id && objLinq.Branch_Id == Obj_Dtls.Branch_Id && objLinq.EmpHdrId == Obj_Dtls.EmpHdrId
                                                             && objLinq.Dtls_Id == Obj_Dtls.Dtls_Id
                                                           select objLinq).FirstOrDefault();
                          if (loclDtlsUpdate !=null)
                          {
                              loclDtlsUpdate.EmpHdrId = Obj_Dtls.EmpHdrId;
                              loclDtlsUpdate.Branch_Id = Obj_Dtls.Branch_Id;
                              loclDtlsUpdate.Company_Id = Obj_Dtls.Company_Id;
                              loclDtlsUpdate.Emp_Serial_No = Obj_Dtls.Emp_Serial_No;

                              loclDtlsUpdate.SpouseNameArabic = Obj_Dtls.SpouseNameArabic;
                              loclDtlsUpdate.SpouseNameEn = Obj_Dtls.SpouseNameEn;
                              loclDtlsUpdate.SpouseBithDate = Obj_Dtls.SpouseBithDate;
                              loclDtlsUpdate.MarriedDate = Obj_Dtls.MarriedDate;
                              loclDtlsUpdate.SpouseNationality_Id = Obj_Dtls.SpouseNationality_Id;
                              loclDtlsUpdate.SpousePassportNo = Obj_Dtls.SpousePassportNo;
                              loclDtlsUpdate.SpousePassportIssueDate = Obj_Dtls.SpousePassportIssueDate;
                              loclDtlsUpdate.SpousePassportExpiryDate = Obj_Dtls.SpousePassportExpiryDate;
                              loclDtlsUpdate.SpouseInsuranceNo = Obj_Dtls.SpouseInsuranceNo;
                              loclDtlsUpdate.SpouseInsuranceIssueDate = Obj_Dtls.SpouseInsuranceIssueDate;
                              loclDtlsUpdate.SpouseInsuranceExpiryDate = Obj_Dtls.SpouseInsuranceExpiryDate;

                              loclDtlsUpdate.National_Id = Obj_Dtls.National_Id;
                              loclDtlsUpdate.NationalStartDate = Obj_Dtls.NationalStartDate;
                              loclDtlsUpdate.NationalEndDate = Obj_Dtls.NationalEndDate;
                              loclDtlsUpdate.MarriedContractAttach = Obj_Dtls.MarriedContractAttach;
                              loclDtlsUpdate.SpouseNotes = Obj_Dtls.SpouseNotes;
                              
                              loclDtlsUpdate.RowState = Obj_Dtls.RowState;
                              loclDtlsUpdate.Rec_Status = Obj_Dtls.Rec_Status;

                              loclDtlsUpdate.UpdateDate =  DateTime.Now;
                              loclDtlsUpdate.UpdateUser = UserName;
                              objPharmaEntities.SaveChanges();
                              //  dbTran.Commit();
                          }
                          else { 
                          Hr_EmpSpouses loclDtls = new Hr_EmpSpouses
                          {
                              EmpHdrId = strEmpHdrId,
                              Branch_Id = Obj_Dtls.Branch_Id,
                              Company_Id = Obj_Dtls.Company_Id,

                              SpouseNameArabic = Obj_Dtls.SpouseNameArabic,
                              SpouseNameEn = Obj_Dtls.SpouseNameEn,
                              SpouseBithDate = Obj_Dtls.SpouseBithDate,
                              MarriedDate = Obj_Dtls.MarriedDate,
                              SpouseNationality_Id = Obj_Dtls.SpouseNationality_Id,
                              SpousePassportNo = Obj_Dtls.SpousePassportNo,
                              SpousePassportIssueDate = Obj_Dtls.SpousePassportIssueDate,
                              SpousePassportExpiryDate = Obj_Dtls.SpousePassportExpiryDate,
                              SpouseInsuranceNo = Obj_Dtls.SpouseInsuranceNo,
                              SpouseInsuranceIssueDate = Obj_Dtls.SpouseInsuranceIssueDate,
                              SpouseInsuranceExpiryDate = Obj_Dtls.SpouseInsuranceExpiryDate,
                              National_Id = Obj_Dtls.National_Id,
                              NationalStartDate = Obj_Dtls.NationalStartDate,
                              NationalEndDate = Obj_Dtls.NationalEndDate,
                              MarriedContractAttach = Obj_Dtls.MarriedContractAttach,
                              SpouseNotes = Obj_Dtls.SpouseNotes,
                              Emp_Serial_No = Obj_Dtls.Emp_Serial_No,
                              RowState = Obj_Dtls.RowState,
                              Rec_Status = Obj_Dtls.Rec_Status,
                              InsDate = DateTime.Now,
                              InsUser = UserName,

                          };

                          objPharmaEntities.Hr_EmpSpouses.Add(loclDtls);
                          objPharmaEntities.SaveChanges();

                          }


                      }
                  
              }
                      //saves all above operations within one transaction
                      //objPharmaEntities.SaveChanges();

                      // dbTran.Commit();
                      // }



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


      public bool AddEmpSpousesByContext(List<Hr_EmpSpouses> ListDtls, Guid strEmpHdrId, string UserName, AthelHREntities VarContext)
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
                       

                  



                        foreach (Hr_EmpSpouses Obj_Dtls in ListDtls)
                        {
                            if (Obj_Dtls != null)
                            {

                                Hr_EmpSpouses loclDtls = new Hr_EmpSpouses
                                {
                                    EmpHdrId = strEmpHdrId,
                                    Branch_Id = Obj_Dtls.Branch_Id,
                                    Company_Id = Obj_Dtls.Company_Id,
                                    SpouseNameArabic = Obj_Dtls.SpouseNameArabic,
                                    SpouseNameEn = Obj_Dtls.SpouseNameEn,
                                    SpouseNameConv = "",
                                    SpouseBithDate = Obj_Dtls.SpouseBithDate,
                                    MarriedDate = Obj_Dtls.MarriedDate,
                                    SpouseNationality_Id = Obj_Dtls.SpouseNationality_Id,
                                    SpousePassportNo = Obj_Dtls.SpousePassportNo,
                                    SpousePassportIssueDate = Obj_Dtls.SpousePassportIssueDate,
                                    SpousePassportExpiryDate = Obj_Dtls.SpousePassportExpiryDate,
                                    SpouseInsuranceNo = Obj_Dtls.SpouseInsuranceNo,
                                    SpouseInsuranceIssueDate = Obj_Dtls.SpouseInsuranceIssueDate,
                                    SpouseInsuranceExpiryDate = Obj_Dtls.SpouseInsuranceExpiryDate,

                                    National_Id = Obj_Dtls.National_Id,
                                    NationalStartDate = Obj_Dtls.NationalStartDate,
                                    NationalEndDate = Obj_Dtls.NationalEndDate,
                                    MarriedContractAttach = Obj_Dtls.MarriedContractAttach,
                                    SpouseNotes = Obj_Dtls.SpouseNotes,
                                    Emp_Serial_No = 0,
                                    RowState = "0",
                                    Rec_Status = 0,
                                    InsDate = DateTime.Now,
                                    InsUser = UserName,

                                };

                                VarContext.Hr_EmpSpouses.Add(loclDtls);
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





      public List<Hr_EmpSpouses> GetEmpSpousesDetails(string Company_Id, string Branch_Id, decimal Emp_Serial, Guid EmpHdrId)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_EmpSpouses> objectList = new List<Hr_EmpSpouses>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpSpouses
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_Serial && objLinq.EmpHdrId == EmpHdrId
                               && objLinq.Rec_Status ==0
                               //&& objLinq.Grade_Id == Grade_Id

                               select new
                               {

                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   SpouseNameArabic = objLinq.SpouseNameArabic,
                                   SpouseNameEn = objLinq.SpouseNameEn,
                                   SpouseBithDate = objLinq.SpouseBithDate,
                                   MarriedDate = objLinq.MarriedDate,
                                   SpouseNationality_Id = objLinq.SpouseNationality_Id,
                                   SpousePassportNo = objLinq.SpousePassportNo,
                                   SpousePassportIssueDate = objLinq.SpousePassportIssueDate,
                                   SpousePassportExpiryDate = objLinq.SpousePassportExpiryDate,
                                   SpouseInsuranceNo = objLinq.SpouseInsuranceNo,
                                   SpouseInsuranceIssueDate = objLinq.SpouseInsuranceIssueDate,
                                   SpouseInsuranceExpiryDate = objLinq.SpouseInsuranceExpiryDate,

                                   National_Id = objLinq.National_Id,
                                   NationalStartDate = objLinq.NationalStartDate,
                                   NationalEndDate = objLinq.NationalEndDate,
                                   MarriedContractAttach = objLinq.MarriedContractAttach,
                                   SpouseNotes = objLinq.SpouseNotes,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   EmpHdrId = objLinq.EmpHdrId,
                                   Rec_Status = objLinq.Rec_Status,
                                   //RowState =0,
      
                               }).ToList();

                

                 foreach (var obj in objlist)
                {
                    Hr_EmpSpouses objGradeHiringItemDL = new Hr_EmpSpouses();

                        objGradeHiringItemDL.Branch_Id = obj.Branch_Id;
                        objGradeHiringItemDL.Company_Id = obj.Company_Id;
                        objGradeHiringItemDL.Emp_Serial_No = obj.Emp_Serial_No;
                        objGradeHiringItemDL.EmpHdrId = obj.EmpHdrId;
                        objGradeHiringItemDL.SpouseNameArabic = obj.SpouseNameArabic;
                        objGradeHiringItemDL.SpouseNameEn = obj.SpouseNameEn;
                        objGradeHiringItemDL.SpouseBithDate = obj.SpouseBithDate;
                        objGradeHiringItemDL.MarriedDate = obj.MarriedDate;
                        objGradeHiringItemDL.SpouseNationality_Id = obj.SpouseNationality_Id;
                        objGradeHiringItemDL.SpousePassportNo = obj.SpousePassportNo;
                        objGradeHiringItemDL.SpousePassportIssueDate = obj.SpousePassportIssueDate;
                        objGradeHiringItemDL.SpousePassportExpiryDate = obj.SpousePassportExpiryDate;
                        objGradeHiringItemDL.SpouseInsuranceNo = obj.SpouseInsuranceNo;
                        objGradeHiringItemDL.SpouseInsuranceIssueDate = obj.SpouseInsuranceIssueDate;
                        objGradeHiringItemDL.SpouseInsuranceExpiryDate = obj.SpouseInsuranceExpiryDate;

                        objGradeHiringItemDL.National_Id = obj.National_Id;
                        objGradeHiringItemDL.NationalStartDate = obj.NationalStartDate;
                        objGradeHiringItemDL.NationalEndDate = obj.NationalEndDate;
                        objGradeHiringItemDL.MarriedContractAttach = obj.MarriedContractAttach;
                        objGradeHiringItemDL.SpouseNotes = obj.SpouseNotes;
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


      public bool UpdateEmpSpousesByContext(List<Hr_EmpSpouses> ListDtls, Guid? strEmpHdrId,decimal strEmpSerial_No, string UserName, AthelHREntities VarContext)
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
              //    result = DeleteEmpSpousesHireItem(strBranch_Id, strCompany_Id, strEmpHdrId, strEmpSerial_No, VarContext);
              //}



            



                  foreach (Hr_EmpSpouses Obj_Dtls in ListDtls)
                  {
                      if (Obj_Dtls != null)
                      {
                         

                          
                              Hr_EmpSpouses loclDtlsUpdate = (from objLinq in VarContext.Hr_EmpSpouses
                                                           where objLinq.Emp_Serial_No == Obj_Dtls.Emp_Serial_No && objLinq.Company_Id == Obj_Dtls.Company_Id && objLinq.Branch_Id == Obj_Dtls.Branch_Id && objLinq.EmpHdrId == Obj_Dtls.EmpHdrId
                                                             && objLinq.Dtls_Id == Obj_Dtls.Dtls_Id
                                                           select objLinq).FirstOrDefault();
                          if (loclDtlsUpdate !=null)
                          {
                              loclDtlsUpdate.EmpHdrId = Obj_Dtls.EmpHdrId;
                              loclDtlsUpdate.Branch_Id = Obj_Dtls.Branch_Id;
                              loclDtlsUpdate.Company_Id = Obj_Dtls.Company_Id;
                              loclDtlsUpdate.Emp_Serial_No = Obj_Dtls.Emp_Serial_No;

                              loclDtlsUpdate.SpouseNameArabic = Obj_Dtls.SpouseNameArabic;
                              loclDtlsUpdate.SpouseNameEn = Obj_Dtls.SpouseNameEn;
                              loclDtlsUpdate.SpouseBithDate = Obj_Dtls.SpouseBithDate;
                              loclDtlsUpdate.MarriedDate = Obj_Dtls.MarriedDate;
                              loclDtlsUpdate.SpouseNationality_Id = Obj_Dtls.SpouseNationality_Id;
                              loclDtlsUpdate.SpousePassportNo = Obj_Dtls.SpousePassportNo;
                              loclDtlsUpdate.SpousePassportIssueDate = Obj_Dtls.SpousePassportIssueDate;
                              loclDtlsUpdate.SpousePassportExpiryDate = Obj_Dtls.SpousePassportExpiryDate;
                              loclDtlsUpdate.SpouseInsuranceNo = Obj_Dtls.SpouseInsuranceNo;
                              loclDtlsUpdate.SpouseInsuranceIssueDate = Obj_Dtls.SpouseInsuranceIssueDate;
                              loclDtlsUpdate.SpouseInsuranceExpiryDate = Obj_Dtls.SpouseInsuranceExpiryDate;

                              loclDtlsUpdate.National_Id = Obj_Dtls.National_Id;
                              loclDtlsUpdate.NationalStartDate = Obj_Dtls.NationalStartDate;
                              loclDtlsUpdate.NationalEndDate = Obj_Dtls.NationalEndDate;
                              loclDtlsUpdate.MarriedContractAttach = Obj_Dtls.MarriedContractAttach;
                              loclDtlsUpdate.SpouseNotes = Obj_Dtls.SpouseNotes;
                              
                              loclDtlsUpdate.RowState = Obj_Dtls.RowState;
                              loclDtlsUpdate.Rec_Status = Obj_Dtls.Rec_Status;

                              loclDtlsUpdate.UpdateDate =  DateTime.Now;
                              loclDtlsUpdate.UpdateUser = UserName;
                              VarContext.SaveChanges();
                              //  dbTran.Commit();
                          }
                          else { 
                          Hr_EmpSpouses loclDtls = new Hr_EmpSpouses
                          {
                              EmpHdrId = strEmpHdrId,
                              Branch_Id = Obj_Dtls.Branch_Id,
                              Company_Id = Obj_Dtls.Company_Id,

                              SpouseNameArabic = Obj_Dtls.SpouseNameArabic,
                              SpouseNameEn = Obj_Dtls.SpouseNameEn,
                              SpouseBithDate = Obj_Dtls.SpouseBithDate,
                              MarriedDate = Obj_Dtls.MarriedDate,
                              SpouseNationality_Id = Obj_Dtls.SpouseNationality_Id,
                              SpousePassportNo = Obj_Dtls.SpousePassportNo,
                              SpousePassportIssueDate = Obj_Dtls.SpousePassportIssueDate,
                              SpousePassportExpiryDate = Obj_Dtls.SpousePassportExpiryDate,
                              SpouseInsuranceNo = Obj_Dtls.SpouseInsuranceNo,
                              SpouseInsuranceIssueDate = Obj_Dtls.SpouseInsuranceIssueDate,
                              SpouseInsuranceExpiryDate = Obj_Dtls.SpouseInsuranceExpiryDate,
                              National_Id = Obj_Dtls.National_Id,
                              NationalStartDate = Obj_Dtls.NationalStartDate,
                              NationalEndDate = Obj_Dtls.NationalEndDate,
                              MarriedContractAttach = Obj_Dtls.MarriedContractAttach,
                              SpouseNotes = Obj_Dtls.SpouseNotes,
                              Emp_Serial_No = strEmpSerial_No,
                              RowState = Obj_Dtls.RowState,
                              Rec_Status = Obj_Dtls.Rec_Status,
                              InsDate = DateTime.Now,
                              InsUser = UserName,

                          };

                          VarContext.Hr_EmpSpouses.Add(loclDtls);
                          VarContext.SaveChanges();

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

          }
          return result;

          //  }

      }


        public bool DeleteEmpSpousesByContext(string Branch_Id,string Company_Id ,Guid? EmpHdrId,decimal Emp_Serial_No, AthelHREntities VarContext)
        {
            bool result = true;
            List<Hr_EmpSpouses> GradeHiringItemToDelete;
            //1. Get student from DB
            //using (var ctx = new AthelHREntities())
            //using (var ctx = VarContext)
            //{


                GradeHiringItemToDelete = VarContext.Hr_EmpSpouses.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.EmpHdrId == EmpHdrId && s.Emp_Serial_No == Emp_Serial_No).ToList();
            //}

            //Create new context for disconnected scenario
            //using (var newContext = new AthelHREntities())
            //using (var newContext = VarContext)
            //{

                foreach (Hr_EmpSpouses Obj_Dtls in GradeHiringItemToDelete)
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



    }
}
