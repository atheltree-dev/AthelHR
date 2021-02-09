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
  public  class EmpQualificationsDAL:CommonDB

    {

      public bool AddNewRecord(List<Hr_EmpQualifications> ListDtls)
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
                        result = DeleteEmpQualifications(strBranch_Id, strCompany_Id, strEmp_Serial_No);
                    }

                    if (result == true) 
                    { 
                    foreach (Hr_EmpQualifications Obj_Dtls in ListDtls)
                    {
                        if (Obj_Dtls != null)
                        {
                         //  University_Name, FromDate, ToDate, Country_Id, Degree, City_Id, InsUser, InsDate, UpdateUser, 
                         //UpdateDate, Faculty_Name, DocAttach, EmpHdrId


                               Hr_EmpQualifications loclDtls = new Hr_EmpQualifications
                                {
                                    Dtls_Id=Obj_Dtls.Dtls_Id,
                                    EmpHdrId = Obj_Dtls.EmpHdrId,
                                    Branch_Id = Obj_Dtls.Branch_Id,
                                    Company_Id = Obj_Dtls.Company_Id,
                                    University_Name = Obj_Dtls.University_Name,
                                    FromDate = Obj_Dtls.FromDate,
                                    ToDate = Obj_Dtls.ToDate,
                                    Country_Id = Obj_Dtls.Country_Id,
                                    Degree = Obj_Dtls.Degree,
                                    City_Id = Obj_Dtls.City_Id,
                                    Qualification_Id=Obj_Dtls.Qualification_Id,
                                    Specialization= Obj_Dtls.Specialization,
                                    Faculty_Name = Obj_Dtls.Faculty_Name,
                                    DocAttach = Obj_Dtls.DocAttach,
                                    Notes = Obj_Dtls.Notes,
                                    Emp_Serial_No = Obj_Dtls.Emp_Serial_No,
                                    InsDate = DateTime.Now,
                                    InsUser = UserNameProperty

                                };
                                
                                objPharmaEntities.Hr_EmpQualifications.Add(loclDtls);
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







        public List<Hr_EmpQualifications> SelectAllEmpQualificationsetting(string Company_Id, string Branch_Id, decimal Emp_Serial_No)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_EmpQualifications> objectList = new List<Hr_EmpQualifications>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpQualifications
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_Serial_No 
                               //&& objLinq.Grade_Id == Grade_Id

                               select new
                               {

                                   EmpHdrId = objLinq.EmpHdrId,
                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   University_Name = objLinq.University_Name,
                                   FromDate = objLinq.FromDate,
                                   ToDate = objLinq.ToDate,
                                   Country_Id = objLinq.Country_Id,
                                   Degree = objLinq.Degree,
                                   City_Id = objLinq.City_Id,
                                   Qualification_Id = objLinq.Qualification_Id,
                                   Specialization = objLinq.Specialization,
                                   Faculty_Name = objLinq.Faculty_Name,
                                   DocAttach = objLinq.DocAttach,
                                   Notes = objLinq.Notes
                                   
                                   
      
                               }).ToList();

                

                 foreach (var obj in objlist)
                {
                    Hr_EmpQualifications objEmpQualificationsDL = new Hr_EmpQualifications();

                        objEmpQualificationsDL.Branch_Id = obj.Branch_Id;
                        objEmpQualificationsDL.Company_Id = obj.Company_Id;
                        objEmpQualificationsDL.EmpHdrId = obj.EmpHdrId;        
                        objEmpQualificationsDL. University_Name = obj.University_Name;
                        objEmpQualificationsDL.FromDate = obj.FromDate;
                        objEmpQualificationsDL.ToDate = obj.ToDate;
                        objEmpQualificationsDL.Country_Id = obj.Country_Id;
                        objEmpQualificationsDL.Degree = obj.Degree;
                        objEmpQualificationsDL.City_Id = obj.City_Id;
                        objEmpQualificationsDL.Faculty_Name = obj.Faculty_Name;
                        objEmpQualificationsDL.DocAttach = obj.DocAttach;
                        objEmpQualificationsDL.Notes = obj.Notes;
                        objEmpQualificationsDL.Qualification_Id = obj.Qualification_Id;
                        objEmpQualificationsDL.Specialization= obj.Specialization;

                        objEmpQualificationsDL.Emp_Serial_No = obj.Emp_Serial_No;

                    
                    objectList.Add(objEmpQualificationsDL);

                }


                return objectList;

                //Rec_No ,ReferenceNo ,BranchAccount_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,City_IdOfResidence ,DocumentPath ,BranchAccountTypeName ,StatusName 

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



        public bool DeleteEmpQualifications(string Branch_Id, string Company_Id, decimal? Emp_Serial_No)
        {
            bool result = true;
            List<Hr_EmpQualifications> EmpQualificationsToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                EmpQualificationsToDelete = ctx.Hr_EmpQualifications.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.Emp_Serial_No == Emp_Serial_No).ToList();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                foreach (Hr_EmpQualifications Obj_Dtls in EmpQualificationsToDelete)
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
