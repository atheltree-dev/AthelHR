﻿using System;
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
  public  class GradeHiringItemFixedDAL:CommonDB

    {

      public bool AddNewRecord(List<Hr_GradeHiringItemFixed> ListDtls)
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
                    string strGradeJob_Id = ListDtls[0].GradeJob_Id.ToString();

                    if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && !String.IsNullOrEmpty(strCompany_Id))
                    {
                        result = DeleteGradeHireItemFixed(strBranch_Id, strCompany_Id, strGradeJob_Id);
                    }

                   

                    if (result == true)
                    {


                        foreach (Hr_GradeHiringItemFixed Obj_Dtls in ListDtls)
                        {
                            if (Obj_Dtls != null)
                            {
                                //if (Obj_Dtls.RowState == "0")
                                //{
                                //     Hr_GradeHiringItemFixed loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_GradeHiringItemFixed
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
                                Hr_GradeHiringItemFixed loclDtls = new Hr_GradeHiringItemFixed
                                 {
                                     Branch_Id = Obj_Dtls.Branch_Id,
                                     Company_Id = Obj_Dtls.Company_Id,
                                     GradeJob_Id = Obj_Dtls.GradeJob_Id,
                                     HireItem_Id = Obj_Dtls.HireItem_Id,
                                     HireItem_Value_Type = Obj_Dtls.HireItem_Value_Type,
                                     HireItem_Value = Obj_Dtls.HireItem_Value,
                                     InsDate = DateTime.Now,
                                     InsUser = UserNameProperty,

                                 };

                                objPharmaEntities.Hr_GradeHiringItemFixed.Add(loclDtls);
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







        public List<Hr_GradeHiringItemFixed> SelectAllGradeHiringItemFixedetting(string Company_Id, string Branch_Id, string GradeJob_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_GradeHiringItemFixed> objectList = new List<Hr_GradeHiringItemFixed>();

                var objlist = (from objLinq in objPharmaEntities.Hr_GradeHiringItemFixed
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.GradeJob_Id == GradeJob_Id 

                               select new
                               {

                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   GradeJob_Id = objLinq.GradeJob_Id,
                                   HireItem_Id = objLinq.HireItem_Id,
                                   HireItem_Value_Type = objLinq.HireItem_Value_Type,
                                   HireItem_Value = objLinq.HireItem_Value
      
                               }).ToList();

                 foreach (var obj in objlist)
                {
                    Hr_GradeHiringItemFixed objGradeHiringItemFixedDL = new Hr_GradeHiringItemFixed();

                        objGradeHiringItemFixedDL.Branch_Id = obj.Branch_Id;
                        objGradeHiringItemFixedDL.Company_Id = obj.Company_Id;
                        objGradeHiringItemFixedDL.GradeJob_Id = obj.GradeJob_Id;
                        objGradeHiringItemFixedDL.HireItem_Id = obj.HireItem_Id;
                        objGradeHiringItemFixedDL.HireItem_Value_Type = obj.HireItem_Value_Type;
                        objGradeHiringItemFixedDL.HireItem_Value = obj.HireItem_Value;
                    
                    objectList.Add(objGradeHiringItemFixedDL);

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

        public bool DeleteGradeHireItemFixed(string Branch_Id, string Company_Id, string GradeJob_Id)
        {
            bool result = true;
            List<Hr_GradeHiringItemFixed> GradeHiringItemToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                GradeHiringItemToDelete = ctx.Hr_GradeHiringItemFixed.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.GradeJob_Id == GradeJob_Id).ToList();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                foreach (Hr_GradeHiringItemFixed Obj_Dtls in GradeHiringItemToDelete)
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


    }
}
