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
//using BOL.Payroll.Registeration;

namespace DAL.AppSetting
{
  public  class Social_InsuranceDeductionPercntg_SAGDAL:CommonDB

    {
      public bool AddNewRecord(List<Hr_Social_InsuranceDeductionPercntg_SA> ListDtls)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          var strErrorMessage = string.Empty;
          //  ObjWorkFlow_HdrDL.InsUser = "5";

          // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
          bool result = true;

          try 
          {
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

                         // EmpDuesDAL objEmpGrade = new EmpDuesDAL();

                        //  result = objEmpGrade.AddEmpDuesByContext(ListDtlsEmpDus, varEmpHdrId, UserNameProperty, varcontext);

                          result = DeleteSocialInsurance(varcontext);

                          if (result)
                          {

                              foreach (Hr_Social_InsuranceDeductionPercntg_SA Obj_Dtls in ListDtls)
                              {
                                  if (Obj_Dtls != null)
                                  {
                                     
                                      Obj_Dtls.DeductOnEmpOrComp = 0;
                                      Obj_Dtls.InsUser = "Admin";
                                      Hr_Social_InsuranceDeductionPercntg_SA loclDtls = new Hr_Social_InsuranceDeductionPercntg_SA
                                      {


                                          Insurance_Type_Id = Obj_Dtls.Insurance_Type_Id,
                                          HireItem_Id = Obj_Dtls.HireItem_Id,
                                          DeductOnEmpOrComp = Obj_Dtls.DeductOnEmpOrComp,
                                          EmpNational_TypeId = Obj_Dtls.EmpNational_TypeId,
                                          DeductPercentage = Obj_Dtls.DeductPercentage,
                                          InsDate = DateTime.Now,
                                          InsUser = Obj_Dtls.InsUser,

                                      };

                                      varcontext.Hr_Social_InsuranceDeductionPercntg_SA.Add(loclDtls);
                                      //saves all above operations within one transaction
                                      varcontext.SaveChanges();
                                    //  result = (varcontext.SaveChanges() > 0);

                                      // dbTran.Commit();
                                      // }



                                  }
                                  
                                  

                              }
                              if (result)
                              {
                                  dbContextTransaction.Commit();
                              }

                              //EmpSpousesDAL objEmpSpouses = new EmpSpousesDAL();

                              //result = objEmpSpouses.AddEmpSpousesByContext(ListDtlsEmpSpouses, varEmpHdrId, UserNameProperty, varcontext);
                              //if (result)
                              //{



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
      //public bool AddNewRecord(List<Hr_Social_InsuranceDeductionPercntg_SA> ListDtls)
      //  {
      //      StackFrame stackFrame = new StackFrame();
      //      MethodBase methodBase = stackFrame.GetMethod();

      //      var strErrorMessage = string.Empty;
      //      //  ObjWorkFlow_HdrDL.InsUser = "5";

      //      // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
      //      bool result = true;

      //      //using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
      //      //{
      //          try
      //          {
      //              if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
      //              {
      //                  objPharmaEntities.Database.Connection.Open();
      //              }

      //              //string strBranch_Id = ListDtls[0].Branch.ToString();
      //              //string strCompany_Id = ListDtls[0].Company_Id.ToString();
                    
                    
                    
      //              result = DeleteSocialInsurance();
                    

      //              if (result == true) 
      //              { 
      //              foreach (Hr_Social_InsuranceDeductionPercntg_SA Obj_Dtls in ListDtls)
      //              {
      //                  if (Obj_Dtls != null)
      //                  {
      //                      //if (Obj_Dtls.RowState == "0")
      //                      //{
      //                      //     Hr_Social_InsuranceDeductionPercntg_SA loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_Social_InsuranceDeductionPercntg_SA
      //                      //                where objLinq.DtlHdrId == Obj_Dtls.DtlHdrId && objLinq.BranchId == Obj_Dtls.BranchId && objLinq.CompanyId == Obj_Dtls.CompanyId
      //                      //                select objLinq).FirstOrDefault();

      //                      //        loclDtlsUpdate.BankId = Obj_Dtls.BankId;
      //                      //        loclDtlsUpdate.BrnchAccountNo = Obj_Dtls.BrnchAccountNo;
      //                      //        loclDtlsUpdate.Rec_Status = Obj_Dtls.Rec_Status;
      //                      //        loclDtlsUpdate.AccountType = Obj_Dtls.AccountType;
                                
      //                      //        loclDtlsUpdate.RowState = Obj_Dtls.RowState;

      //                      //         objPharmaEntities.SaveChanges();
      //                      //       //  dbTran.Commit();
      //                      //}
      //                      //else 
      //                      //{
      //                       Obj_Dtls.DeductOnEmpOrComp = 0;
      //                      Obj_Dtls.InsUser = "Admin";
      //                         Hr_Social_InsuranceDeductionPercntg_SA loclDtls = new Hr_Social_InsuranceDeductionPercntg_SA
      //                          {
                                    
                                   
      //                              Insurance_Type_Id = Obj_Dtls.Insurance_Type_Id,
      //                              HireItem_Id = Obj_Dtls.HireItem_Id,
      //                              DeductOnEmpOrComp = Obj_Dtls.DeductOnEmpOrComp,
      //                              EmpNational_TypeId = Obj_Dtls.EmpNational_TypeId,
      //                              DeductPercentage = Obj_Dtls.DeductPercentage,
      //                              InsDate = DateTime.Now,
      //                              InsUser = Obj_Dtls.InsUser,

      //                          };
                                
      //                          objPharmaEntities.Hr_Social_InsuranceDeductionPercntg_SA.Add(loclDtls);
      //                          //saves all above operations within one transaction
      //                          objPharmaEntities.SaveChanges();

      //                         // dbTran.Commit();
      //                     // }
                            
                            
                           
      //                  }
      //               }
      //              }

      //              //commit transaction
      //            //  dbTran.Commit();
      //          }
      //          catch (DbEntityValidationException ex)
      //          {


      //              // Retrieve the error messages as a list of strings.
      //              var errorMessages = ex.EntityValidationErrors
      //                      .SelectMany(x => x.ValidationErrors)
      //                      .Select(x => x.ErrorMessage);

      //              // Join the list to a single string.
      //              var fullErrorMessage = string.Join("; ", errorMessages);

      //              // Combine the original exception message with the new one.
      //              var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
      //              strErrorMessage = fullErrorMessage;
      //              // Throw a new DbEntityValidationException with the improved exception message.
      //              throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
      //              //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
      //           //   dbTran.Rollback();
      //              result = false;

      //          }

      //          catch (Exception ex)
      //          {

      //              //Rollback transaction if exception occurs
      //            //  dbTran.Rollback();
      //              result = false;

      //          }

      //          finally
      //          {
      //              objPharmaEntities.Database.Connection.Close();
      //            //  dbTran.Dispose();

      //              if (!string.IsNullOrEmpty(strErrorMessage))
      //              {
      //                  SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
      //              }

      //          }
      //          return result;

      //    //  }

      //  }







        public List<Hr_Social_InsuranceDeductionPercntg_SA> SelectAllSocial_InsuranceDeductionPercntg_SAetting()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_Social_InsuranceDeductionPercntg_SA> objectList = new List<Hr_Social_InsuranceDeductionPercntg_SA>();

                var objlist = (from objLinq in objPharmaEntities.Hr_Social_InsuranceDeductionPercntg_SA 
                               //&& objLinq.Insurance_Type_Id == Insurance_Type_Id

                               select new
                               {


                                   EmpNational_TypeId = objLinq.EmpNational_TypeId,
                                   Insurance_Type_Id = objLinq.Insurance_Type_Id,
                                   HireItem_Id = objLinq.HireItem_Id,
                                   DeductOnEmpOrComp = objLinq.DeductOnEmpOrComp,
                                   DeductPercentage = objLinq.DeductPercentage
      
                               }).ToList();

                

                 foreach (var obj in objlist)
                {
                    Hr_Social_InsuranceDeductionPercntg_SA objSocial_InsuranceDeductionPercntg_SADL = new Hr_Social_InsuranceDeductionPercntg_SA();


                    objSocial_InsuranceDeductionPercntg_SADL.EmpNational_TypeId = obj.EmpNational_TypeId;
                        objSocial_InsuranceDeductionPercntg_SADL.Insurance_Type_Id = obj.Insurance_Type_Id;
                        objSocial_InsuranceDeductionPercntg_SADL.HireItem_Id = obj.HireItem_Id;
                        objSocial_InsuranceDeductionPercntg_SADL.DeductOnEmpOrComp = obj.DeductOnEmpOrComp;
                        objSocial_InsuranceDeductionPercntg_SADL.DeductPercentage = obj.DeductPercentage;
                    
                    objectList.Add(objSocial_InsuranceDeductionPercntg_SADL);

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

       

        public bool DeleteSocialInsurance()
        {
            bool result = true;
            List<Hr_Social_InsuranceDeductionPercntg_SA> Social_InsuranceDeductionPercntg_SAToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                Social_InsuranceDeductionPercntg_SAToDelete = ctx.Hr_Social_InsuranceDeductionPercntg_SA.ToList();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                foreach (Hr_Social_InsuranceDeductionPercntg_SA Obj_Dtls in Social_InsuranceDeductionPercntg_SAToDelete)
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


        public bool DeleteSocialInsurance(AthelHREntities VarContext)
        {
            bool result = true;
            List<Hr_Social_InsuranceDeductionPercntg_SA> Social_InsuranceDeductionPercntg_SAToDelete;
            //1. Get student from DB
            


                Social_InsuranceDeductionPercntg_SAToDelete = VarContext.Hr_Social_InsuranceDeductionPercntg_SA.ToList();
           

            //Create new context for disconnected scenario
            //using (var newContext = new AthelHREntities())
            //{

                foreach (Hr_Social_InsuranceDeductionPercntg_SA Obj_Dtls in Social_InsuranceDeductionPercntg_SAToDelete)
                {
                    if (Obj_Dtls != null)
                    {
                        VarContext.Entry(Obj_Dtls).State = System.Data.Entity.EntityState.Deleted;

                        result = VarContext.SaveChanges() > 0;

                    }
                }



            //}
            return result;

        }

      

       


    }
}
