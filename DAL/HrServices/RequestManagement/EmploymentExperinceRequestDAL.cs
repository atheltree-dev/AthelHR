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
using BOL.HrServices.RequestManagement;

namespace DAL.HrServices.RequestManagement
{
  public  class EmploymentExperinceRequestDAL:CommonDB

    {
      public bool AddEmploymentExperinceRequestByContext(List<Hr_EmploymentExperinceRequest> ListDtls, Guid strRec_Hdr_Id, string UserName, AthelHREntities VarContext)
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

               string strBranch_Id = ListDtls[0].Branch_Id.ToString();
                    string strCompany_Id = ListDtls[0].Company_Id.ToString();
                   
                    
                    if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && !String.IsNullOrEmpty(strCompany_Id)) 
                    {
                        result = DeleteEmploymentExperinceRequest(strBranch_Id, strCompany_Id, strRec_Hdr_Id, VarContext);
                    }

                    if (result == true)
                    {




                        foreach (Hr_EmploymentExperinceRequest Obj_Dtls in ListDtls)
                        {
                            if (Obj_Dtls != null)
                            {

                                Hr_EmploymentExperinceRequest loclDtls = new Hr_EmploymentExperinceRequest
                                {
                                    Dtls_Id = GetNewHeaderId(),
                                    Rec_Hdr_Id = strRec_Hdr_Id,
                                    Branch_Id = Obj_Dtls.Branch_Id,
                                    Company_Id = Obj_Dtls.Company_Id,
                                    Experience_Id = Obj_Dtls.Experience_Id,
                                    Notes = Obj_Dtls.Notes,
                                    RowId = Obj_Dtls.RowId,
                                    InsDate = DateTime.Now,
                                    InsUser = UserName,

                                };

                                VarContext.Hr_EmploymentExperinceRequest.Add(loclDtls);
                                VarContext.SaveChanges();
                                //saves all above operations within one transaction
                                //objPharmaEntities.SaveChanges();

                                // dbTran.Commit();
                                // }



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



    






        public List<Hr_EmploymentExperinceRequest> SelectAllEmploymentExperinceRequestetting(string Company_Id, string Branch_Id,Guid strRec_Hdr_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_EmploymentExperinceRequest> objectList = new List<Hr_EmploymentExperinceRequest>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmploymentExperinceRequest
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Rec_Hdr_Id == strRec_Hdr_Id 
                               //&& objLinq.Grade_Id == Grade_Id

                               select new
                               {

                                  
                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   Experience_Id = objLinq.Experience_Id,
                                   RowId = objLinq.RowId,
                                   Notes = objLinq.Notes
                                   
                               }).ToList();

                

                 foreach (var obj in objlist)
                {
                    Hr_EmploymentExperinceRequest objEmploymentExperinceRequestDL = new Hr_EmploymentExperinceRequest();

                        objEmploymentExperinceRequestDL.Branch_Id = obj.Branch_Id;
                        objEmploymentExperinceRequestDL.Company_Id = obj.Company_Id;
                        objEmploymentExperinceRequestDL.Experience_Id = obj.Experience_Id;
                        objEmploymentExperinceRequestDL.RowId = obj.RowId;
                        objEmploymentExperinceRequestDL.Notes = obj.Notes;
                        
                    objectList.Add(objEmploymentExperinceRequestDL);

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



       

        public bool DeleteEmploymentExperinceRequest(string Branch_Id, string Company_Id, Guid Rec_HdrId, AthelHREntities VarContext)
        {
            bool result = true;
            List<Hr_EmploymentExperinceRequest> EmploymentExperinceRequestToDelete;
            //1. Get student from DB
            //using (var ctx = new AthelHREntities())
            //using (var ctx = VarContext)
            //{


            EmploymentExperinceRequestToDelete = VarContext.Hr_EmploymentExperinceRequest.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.Rec_Hdr_Id == Rec_HdrId).ToList();
            //}

            //Create new context for disconnected scenario
            //using (var newContext = new AthelHREntities())
            //using (var newContext = VarContext)
            //{

            foreach (Hr_EmploymentExperinceRequest Obj_Dtls in EmploymentExperinceRequestToDelete)
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
