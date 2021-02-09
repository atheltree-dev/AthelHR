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
  public  class EmpSonsDAL:CommonDB

    {

      public bool AddNewRecord(List<Hr_EmpSons> ListDtls)
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

                    string strBranch_Id = ListDtls[0].Branch_Id.ToString();
                    string strCompany_Id = ListDtls[0].Company_Id.ToString();
                    decimal?  strEmp_Serial_No = ListDtls[0].Emp_Serial_No;
                    
                    if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && !String.IsNullOrEmpty(strCompany_Id)) 
                    {
                        result = DeleteEmpSons(strBranch_Id, strCompany_Id, strEmp_Serial_No);
                    }

                    if (result == true) 
                    { 
                    foreach (Hr_EmpSons Obj_Dtls in ListDtls)
                    {
                        if (Obj_Dtls != null)
                        {
                            //if (Obj_Dtls.RowState == "0")
                            //{
                            //     Hr_EmpSons loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_EmpSons
                            //                where objLinq.DtlHdrId == Obj_Dtls.DtlHdrId && objLinq.BranchId == Obj_Dtls.BranchId && objLinq.CompanyId == Obj_Dtls.CompanyId
                            //                select objLinq).FirstOrDefault();

                            //        loclDtlsUpdate.BankId = Obj_Dtls.BankId;
                            //        loclDtlsUpdate.BrnchAccountNo = Obj_Dtls.BrnchAccountNo;
                            //        loclDtlsUpdate.Rec_Status = Obj_Dtls.Rec_Status;
                            //        loclDtlsUpdate.AccountType = Obj_Dtls.AccountType;
                                
                            //        loclDtlsUpdate.RowState = Obj_Dtls.RowState;

                            //         objPharmaEntities.SaveChanges();
                            //       //  dbTran.Commit();
                            //}
                            //else 
                            //{
                               Hr_EmpSons loclDtls = new Hr_EmpSons
                                {
                                    Dtls_Id=Obj_Dtls.Dtls_Id,
                                    EmpHdrId = Obj_Dtls.EmpHdrId,
                                    Branch_Id = Obj_Dtls.Branch_Id,
                                    Company_Id = Obj_Dtls.Company_Id,
                                    SonNameArabic = Obj_Dtls.SonNameArabic,
                                    SonNameEn = Obj_Dtls.SonNameEn,
                                    SonNameConv = "",
                                    SonBithDate = Obj_Dtls.SonBithDate,
                                    DeathDate = Obj_Dtls.DeathDate,
                                    SonNationality_Id = Obj_Dtls.SonNationality_Id,
                                    SonPassportNo = Obj_Dtls.SonPassportNo,
                                    SonPassportIssueDate = Obj_Dtls.SonPassportIssueDate,
                                    SonPassportExpiryDate = Obj_Dtls.SonPassportExpiryDate,
                                    SonInsuranceNo = Obj_Dtls.SonInsuranceNo,
                                    SonInsuranceIssueDate = Obj_Dtls.SonInsuranceIssueDate,
                                    SonInsuranceExpiryDate = Obj_Dtls.SonInsuranceExpiryDate,

                                    National_Id = Obj_Dtls.National_Id,
                                    NationalStartDate = Obj_Dtls.NationalStartDate,
                                    NationalEndDate = Obj_Dtls.NationalEndDate,
                                    BirthCertificateAttach = Obj_Dtls.BirthCertificateAttach,

                                    SonGeneder_Id = Obj_Dtls.SonGeneder_Id,
                                    SonSocial_Status_Id = Obj_Dtls.SonSocial_Status_Id,
                                    SonQualify_Id = Obj_Dtls.SonQualify_Id,
                                    SonImageAttach = Obj_Dtls.SonImageAttach,

                                   
                                    SonNotes = Obj_Dtls.SonNotes,
                                    Emp_Serial_No = Obj_Dtls.Emp_Serial_No,
                                    RowState = "0",
                                    Rec_Status = 0,
                                    InsDate = DateTime.Now,
                                    InsUser = UserNameProperty,

                                };
                                
                                objPharmaEntities.Hr_EmpSons.Add(loclDtls);
                                //saves all above operations within one transaction
                                objPharmaEntities.SaveChanges();

                               // dbTran.Commit();
                           // }
                            
                            
                           
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







        public List<Hr_EmpSons> SelectAllEmpSonsetting(string Company_Id, string Branch_Id, decimal Emp_Serial_No)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_EmpSons> objectList = new List<Hr_EmpSons>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpSons
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_Serial_No 
                               //&& objLinq.Grade_Id == Grade_Id

                               select new
                               {

                                   EmpHdrId = objLinq.EmpHdrId,
                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   SonNameArabic = objLinq.SonNameArabic,
                                   SonNameEn = objLinq.SonNameEn,
                                   SonBithDate = objLinq.SonBithDate,
                                   DeathDate = objLinq.DeathDate,
                                   SonNationality_Id = objLinq.SonNationality_Id,
                                   SonPassportNo = objLinq.SonPassportNo,
                                   SonPassportIssueDate = objLinq.SonPassportIssueDate,
                                   SonPassportExpiryDate = objLinq.SonPassportExpiryDate,
                                   SonInsuranceNo = objLinq.SonInsuranceNo,
                                   SonInsuranceIssueDate = objLinq.SonInsuranceIssueDate,
                                   SonInsuranceExpiryDate = objLinq.SonInsuranceExpiryDate,
                                   National_Id = objLinq.National_Id,
                                   NationalStartDate = objLinq.NationalStartDate,
                                   NationalEndDate = objLinq.NationalEndDate,
                                   BirthCertificateAttach = objLinq.BirthCertificateAttach,
                                   SonNotes = objLinq.SonNotes,

                                   SonGeneder_Id = objLinq.SonGeneder_Id,
                                   SonSocial_Status_Id = objLinq.SonSocial_Status_Id,
                                   SonQualify_Id = objLinq.SonQualify_Id,
                                   SonImageAttach = objLinq.SonImageAttach,

                                  

                                   Emp_Serial_No = objLinq.Emp_Serial_No
      
                               }).ToList();

                

                 foreach (var obj in objlist)
                {
                    Hr_EmpSons objEmpSonsDL = new Hr_EmpSons();

                        objEmpSonsDL.Branch_Id = obj.Branch_Id;
                        objEmpSonsDL.Company_Id = obj.Company_Id;
                        objEmpSonsDL.EmpHdrId = obj.EmpHdrId;        
                        objEmpSonsDL.SonNameArabic = obj.SonNameArabic;
                        objEmpSonsDL.SonNameEn = obj.SonNameEn;
                        objEmpSonsDL.SonBithDate = obj.SonBithDate;
                        objEmpSonsDL.DeathDate = obj.DeathDate;
                        objEmpSonsDL.SonNationality_Id = obj.SonNationality_Id;
                        objEmpSonsDL.SonPassportNo = obj.SonPassportNo;
                        objEmpSonsDL.SonPassportIssueDate = obj.SonPassportIssueDate;
                        objEmpSonsDL.SonPassportExpiryDate = obj.SonPassportExpiryDate;
                        objEmpSonsDL.SonInsuranceNo = obj.SonInsuranceNo;
                        objEmpSonsDL.SonInsuranceIssueDate = obj.SonInsuranceIssueDate;
                        objEmpSonsDL.SonInsuranceExpiryDate = obj.SonInsuranceExpiryDate;
                        objEmpSonsDL.National_Id = obj.National_Id;
                        objEmpSonsDL.NationalStartDate = obj.NationalStartDate;
                        objEmpSonsDL.NationalEndDate = obj.NationalEndDate;
                        objEmpSonsDL.BirthCertificateAttach = obj.BirthCertificateAttach;
                        objEmpSonsDL.SonNotes = obj.SonNotes;
                       objEmpSonsDL.SonGeneder_Id = obj.SonGeneder_Id;
                      objEmpSonsDL.SonSocial_Status_Id = obj.SonSocial_Status_Id;
                      objEmpSonsDL.SonQualify_Id = obj.SonQualify_Id;
                      objEmpSonsDL.SonImageAttach = obj.SonImageAttach;

                        objEmpSonsDL.Emp_Serial_No = obj.Emp_Serial_No;

                    
                    objectList.Add(objEmpSonsDL);

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



        public bool DeleteEmpSons(string Branch_Id, string Company_Id, decimal? Emp_Serial_No)
        {
            bool result = true;
            List<Hr_EmpSons> EmpSonsToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                EmpSonsToDelete = ctx.Hr_EmpSons.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.Emp_Serial_No == Emp_Serial_No).ToList();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                foreach (Hr_EmpSons Obj_Dtls in EmpSonsToDelete)
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

        //public List<GradeDuesDL> GetGradeDetails(string Company_Id, string Branch_Id, string GradeJob_Id, string Grade_Id)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {


        //        OpenEntityConnection();


        //        List<GradeDuesDL> objectList = new List<GradeDuesDL>();

        //        object[] param1 = { 
        //        new SqlParameter("@Company_Id",Company_Id),
        //        new SqlParameter("@Branch_Id", Branch_Id),
        //        new SqlParameter("@GradeJob_Id", GradeJob_Id),
        //        new SqlParameter("@Grade_Id", Grade_Id)};

        //        var objlist = objPharmaEntities.Database.SqlQuery<GradeDuesDL>("exec dbo.SPGetGradeDues @Company_Id,@Branch_Id,@GradeJob_Id,@Grade_Id", param1).ToList();

        //        foreach (var obj in objlist)
        //        {
        //            GradeDuesDL objGradeDuesDL = new GradeDuesDL();
        //            objGradeDuesDL.HireItem_Id = obj.HireItem_Id;
        //            objGradeDuesDL.HireItem_Name = obj.HireItem_Name;
        //            objGradeDuesDL.HireItem_NameEn = obj.HireItem_NameEn;
        //            objGradeDuesDL.HireItem_Value = obj.HireItem_Value;
        //            objGradeDuesDL.Rec_Status = 0;
        //            objectList.Add(objGradeDuesDL);

        //        }



        //        return objectList;

        //        //Rec_No ,ReferenceNo ,Request_Id 
        //        //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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


    }
}
