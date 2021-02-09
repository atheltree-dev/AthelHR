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
  public  class BranchAccountsDAL:CommonDB

    {
      
      public bool AddBranchAccount(List<Hr_BranchAccounts> ListDtls)
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
                    
                    
                    foreach (Hr_BranchAccounts Obj_Dtls in ListDtls)
                    {
                        if (Obj_Dtls != null)
                        {
                            if (Obj_Dtls.RowState == "0")
                            {
                                 Hr_BranchAccounts loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_BranchAccounts
                                            where objLinq.DtlHdrId == Obj_Dtls.DtlHdrId && objLinq.BranchId == Obj_Dtls.BranchId && objLinq.CompanyId == Obj_Dtls.CompanyId
                                            select objLinq).FirstOrDefault();

                                    loclDtlsUpdate.BankId = Obj_Dtls.BankId;
                                    loclDtlsUpdate.BrnchAccountNo = Obj_Dtls.BrnchAccountNo;
                                    loclDtlsUpdate.Rec_Status = Obj_Dtls.Rec_Status;
                                    loclDtlsUpdate.AccountType = Obj_Dtls.AccountType;
                                
                                    loclDtlsUpdate.RowState = Obj_Dtls.RowState;

                                     objPharmaEntities.SaveChanges();
                                   //  dbTran.Commit();
                            }
                            else 
                            {
                                Hr_BranchAccounts loclDtls = new Hr_BranchAccounts
                                {

                                    DtlHdrId = GetNewHeaderId(),
                                    BranchId = Obj_Dtls.BranchId,
                                    CompanyId = Obj_Dtls.CompanyId,
                                    BankId = Obj_Dtls.BankId,
                                    AccountType = Obj_Dtls.AccountType,
                                    BrnchAccountNo = Obj_Dtls.BrnchAccountNo,
                                    Rec_Status = Obj_Dtls.Rec_Status,
                                    RowState = Obj_Dtls.RowState
                                };
                                
                                objPharmaEntities.Hr_BranchAccounts.Add(loclDtls);
                                //saves all above operations within one transaction
                                objPharmaEntities.SaveChanges();

                               // dbTran.Commit();
                            }
                            
                            
                           
                        }
                    }


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



           
      
        

        public List<Hr_BranchAccounts> SelectAllBranchAccountSetting(string Company_Id, string Branch_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_BranchAccounts> objectList = new List<Hr_BranchAccounts>();

                var objlist = (from objLinq in objPharmaEntities.Hr_BranchAccounts
                               where objLinq.CompanyId == Company_Id && objLinq.BranchId == Branch_Id && objLinq.Rec_Status == 0

                               select new
                               {
                                   DtlHdrId = objLinq.DtlHdrId,
                                   BranchId = objLinq.BranchId,
                                   CompanyId = objLinq.CompanyId,
                                   BankId = objLinq.BankId,
                                   AccountType = objLinq.AccountType,
                                   BrnchAccountNo = objLinq.BrnchAccountNo,
                                   Rec_Status = objLinq.Rec_Status,
                                   RowState = "0"
      
                               }).ToList();

                 foreach (var obj in objlist)
                {
                    Hr_BranchAccounts objBranchAccountsDL = new Hr_BranchAccounts();

                        objBranchAccountsDL.DtlHdrId = obj.DtlHdrId;
                        objBranchAccountsDL.BranchId = obj.BranchId;
                        objBranchAccountsDL.CompanyId = obj.CompanyId;
                        objBranchAccountsDL.BankId = obj.BankId;
                        objBranchAccountsDL.AccountType = obj.AccountType;
                        objBranchAccountsDL.BrnchAccountNo = obj.BrnchAccountNo;
                        objBranchAccountsDL.Rec_Status = obj.Rec_Status;
                        objBranchAccountsDL.RowState = obj.RowState;
                    
                    objectList.Add(objBranchAccountsDL);

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




    }
}
