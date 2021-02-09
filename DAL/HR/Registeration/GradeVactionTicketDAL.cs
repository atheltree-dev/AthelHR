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
  public  class GradeVactionTicketDAL:CommonDB

    {

      public bool AddNewRecord(Hr_GradeVactionTicket Obj_Dtls)
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

                    string strBranch_Id = Obj_Dtls.Branch_Id.ToString();
                    string strCompany_Id = Obj_Dtls.Company_Id.ToString();
                    string strGradeJob_Id = Obj_Dtls.GradeJob_Id.ToString();

                    if (!String.IsNullOrEmpty(strBranch_Id) && !String.IsNullOrEmpty(strCompany_Id) && !String.IsNullOrEmpty(strCompany_Id))
                    {
                        result = DeleteGradeVactionTicket(strBranch_Id, strCompany_Id, strGradeJob_Id);
                    }

                    

                   

                    
                    //foreach (Hr_GradeVactionTicket Obj_Dtls in ListDtls)
                    //{
                        if (Obj_Dtls != null)
                        {
                            
                               Hr_GradeVactionTicket loclDtls = new Hr_GradeVactionTicket
                                {
                                    Branch_Id = Obj_Dtls.Branch_Id,
                                    Company_Id = Obj_Dtls.Company_Id,
                                    GradeJob_Id = Obj_Dtls.GradeJob_Id,
                                    VactionPeriod = Obj_Dtls.VactionPeriod,
                                    VactionTicketType = Obj_Dtls.VactionTicketType,
                                    InternationalWorkTicketType = Obj_Dtls.InternationalWorkTicketType,
                                    LocalWorkTicketType = Obj_Dtls.LocalWorkTicketType,
                                    WorkingMonthNo = Obj_Dtls.WorkingMonthNo,
                                    WorkingPeriodType = Obj_Dtls.WorkingPeriodType,
                                    InsDate = DateTime.Now,
                                    InsUser = UserNameProperty

                                };
                                
                                objPharmaEntities.Hr_GradeVactionTicket.Add(loclDtls);
                                //saves all above operations within one transaction
                                objPharmaEntities.SaveChanges();

                               // dbTran.Commit();
                           // }
                            
                            
                           
                        }
                    //}


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

        public Hr_GradeVactionTicket SelectAllGradeVactionTicketetting(string Company_Id, string Branch_Id, string GradeJob_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


               Hr_GradeVactionTicket objectList = new Hr_GradeVactionTicket();

                var objlist = (from objLinq in objPharmaEntities.Hr_GradeVactionTicket
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.GradeJob_Id == GradeJob_Id 

                               select new
                               {

                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   GradeJob_Id = objLinq.GradeJob_Id,
                                   VactionPeriod = objLinq.VactionPeriod,
                                   VactionTicketType = objLinq.VactionTicketType,
                                   InternationalWorkTicketType = objLinq.InternationalWorkTicketType,
                                   WorkingMonthNo = objLinq.WorkingMonthNo,
                                   WorkingPeriodType = objLinq.WorkingPeriodType,
                                   LocalWorkTicketType = objLinq.LocalWorkTicketType,

      
                               }).FirstOrDefault();
                if (objlist != null)
                {
                    Hr_GradeVactionTicket objGradeVactionTicketDL = new Hr_GradeVactionTicket();

                    objGradeVactionTicketDL.Branch_Id = objlist.Branch_Id;
                    objGradeVactionTicketDL.Company_Id = objlist.Company_Id;
                    objGradeVactionTicketDL.GradeJob_Id = objlist.GradeJob_Id;
                    objGradeVactionTicketDL.VactionPeriod = objlist.VactionPeriod;
                    objGradeVactionTicketDL.VactionTicketType = objlist.VactionTicketType;
                    objGradeVactionTicketDL.InternationalWorkTicketType = objlist.InternationalWorkTicketType;
                    objGradeVactionTicketDL.LocalWorkTicketType = objlist.LocalWorkTicketType;
                    objGradeVactionTicketDL.WorkingMonthNo = objlist.WorkingMonthNo;
                    objGradeVactionTicketDL.WorkingPeriodType = objlist.WorkingPeriodType;
                    return objGradeVactionTicketDL;
                }
                else
                {
                    return null;
                }
                
                // foreach (var obj in objlist)
                //{
                //    Hr_GradeVactionTicket objGradeVactionTicketDL = new Hr_GradeVactionTicket();

                //        objGradeVactionTicketDL.Branch_Id = obj.Branch_Id;
                //        objGradeVactionTicketDL.Company_Id = obj.Company_Id;
                //        objGradeVactionTicketDL.GradeJob_Id = obj.GradeJob_Id;
                //        objGradeVactionTicketDL.VactionPeriod = obj.VactionPeriod;
                //        objGradeVactionTicketDL.VactionTicketType = obj.VactionTicketType;
                //        objGradeVactionTicketDL.InternationalWorkTicketType = obj.InternationalWorkTicketType;
                //        objGradeVactionTicketDL.LocalWorkTicketType = obj.LocalWorkTicketType;
                    
                //    objectList.Add(objGradeVactionTicketDL);

                //}


              

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

        public bool DeleteGradeVactionTicket(string Branch_Id, string Company_Id, string GradeJob_Id)
        {
            bool result = true;
           Hr_GradeVactionTicket GradeHiringItemToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                GradeHiringItemToDelete = ctx.Hr_GradeVactionTicket.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.GradeJob_Id == GradeJob_Id).FirstOrDefault();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                if (GradeHiringItemToDelete != null)
                {
                    newContext.Entry(GradeHiringItemToDelete).State = System.Data.Entity.EntityState.Deleted;

                    result = newContext.SaveChanges() > 0;

                }
                

                

            }
            return result;

        }

      



    }
}
