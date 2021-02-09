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
  public  class EmpSpousesDAL:CommonDB

    {

      public bool AddNewRecord(List<Hr_EmpSpouses> ListDtls)
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
                        result = DeleteEmpSpouses(strBranch_Id, strCompany_Id, strEmp_Serial_No);
                    }

                    if (result == true) 
                    { 
                    foreach (Hr_EmpSpouses Obj_Dtls in ListDtls)
                    {
                        if (Obj_Dtls != null)
                        {
                            //if (Obj_Dtls.RowState == "0")
                            //{
                            //     Hr_EmpSpouses loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_EmpSpouses
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
                               Hr_EmpSpouses loclDtls = new Hr_EmpSpouses
                                {
                                    Dtls_Id=Obj_Dtls.Dtls_Id,
                                    EmpHdrId = Obj_Dtls.EmpHdrId,
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
                                    Emp_Serial_No = Obj_Dtls.Emp_Serial_No,
                                    RowState = "0",
                                    Rec_Status = 0,
                                    InsDate = DateTime.Now,
                                    InsUser = UserNameProperty,

                                };
                                
                                objPharmaEntities.Hr_EmpSpouses.Add(loclDtls);
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







        public List<Hr_EmpSpouses> SelectAllEmpSpousesetting(string Company_Id, string Branch_Id, decimal Emp_Serial_No)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_EmpSpouses> objectList = new List<Hr_EmpSpouses>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpSpouses
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_Serial_No 
                               //&& objLinq.Grade_Id == Grade_Id

                               select new
                               {

                                   EmpHdrId = objLinq.EmpHdrId,
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
                                   Emp_Serial_No = objLinq.Emp_Serial_No
      
                               }).ToList();

                

                 foreach (var obj in objlist)
                {
                    Hr_EmpSpouses objEmpSpousesDL = new Hr_EmpSpouses();

                        objEmpSpousesDL.Branch_Id = obj.Branch_Id;
                        objEmpSpousesDL.Company_Id = obj.Company_Id;
                        objEmpSpousesDL.EmpHdrId = obj.EmpHdrId;        
                        objEmpSpousesDL.SpouseNameArabic = obj.SpouseNameArabic;
                        objEmpSpousesDL.SpouseNameEn = obj.SpouseNameEn;
                        objEmpSpousesDL.SpouseBithDate = obj.SpouseBithDate;
                        objEmpSpousesDL.MarriedDate = obj.MarriedDate;
                        objEmpSpousesDL.SpouseNationality_Id = obj.SpouseNationality_Id;
                        objEmpSpousesDL.SpousePassportNo = obj.SpousePassportNo;
                        objEmpSpousesDL.SpousePassportIssueDate = obj.SpousePassportIssueDate;
                        objEmpSpousesDL.SpousePassportExpiryDate = obj.SpousePassportExpiryDate;
                        objEmpSpousesDL.SpouseInsuranceNo = obj.SpouseInsuranceNo;
                        objEmpSpousesDL.SpouseInsuranceIssueDate = obj.SpouseInsuranceIssueDate;
                        objEmpSpousesDL.SpouseInsuranceExpiryDate = obj.SpouseInsuranceExpiryDate;
                        objEmpSpousesDL.National_Id = obj.National_Id;
                        objEmpSpousesDL.NationalStartDate = obj.NationalStartDate;
                        objEmpSpousesDL.NationalEndDate = obj.NationalEndDate;
                        objEmpSpousesDL.MarriedContractAttach = obj.MarriedContractAttach;
                        objEmpSpousesDL.SpouseNotes = obj.SpouseNotes;
                        objEmpSpousesDL.Emp_Serial_No = obj.Emp_Serial_No;

                    
                    objectList.Add(objEmpSpousesDL);

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



        public bool DeleteEmpSpouses(string Branch_Id, string Company_Id, decimal? Emp_Serial_No)
        {
            bool result = true;
            List<Hr_EmpSpouses> EmpSpousesToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                EmpSpousesToDelete = ctx.Hr_EmpSpouses.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.Emp_Serial_No == Emp_Serial_No).ToList();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                foreach (Hr_EmpSpouses Obj_Dtls in EmpSpousesToDelete)
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
