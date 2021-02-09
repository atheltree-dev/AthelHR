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
  public  class EmpCertificationsDAL:CommonDB

    {

      public bool AddNewRecord(List<Hr_EmpCertifications> ListDtls)
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
                        result = DeleteEmpCertifications(strBranch_Id, strCompany_Id, strEmp_Serial_No);
                    }

                    if (result == true) 
                    { 
                    foreach (Hr_EmpCertifications Obj_Dtls in ListDtls)
                    {
                        if (Obj_Dtls != null)
                        {
                         //  Certification_Name, FromDate, ToDate, Major_Name, Degree, Place, InsUser, InsDate, UpdateUser, 
                         //UpdateDate, Certification_No, DocAttach, EmpHdrId


                               Hr_EmpCertifications loclDtls = new Hr_EmpCertifications
                                {
                                    Dtls_Id=Obj_Dtls.Dtls_Id,
                                    EmpHdrId = Obj_Dtls.EmpHdrId,
                                    Branch_Id = Obj_Dtls.Branch_Id,
                                    Company_Id = Obj_Dtls.Company_Id,
                                    Certification_Name = Obj_Dtls.Certification_Name,
                                    FromDate = Obj_Dtls.FromDate,
                                    ToDate = Obj_Dtls.ToDate,
                                    Major_Name = Obj_Dtls.Major_Name,
                                    Degree = Obj_Dtls.Degree,
                                    Place = Obj_Dtls.Place,
                                    Certification_No = Obj_Dtls.Certification_No,
                                    DocAttach = Obj_Dtls.DocAttach,
                                    Notes = Obj_Dtls.Notes,
                                    Emp_Serial_No = Obj_Dtls.Emp_Serial_No,
                                    InsDate = DateTime.Now,
                                    InsUser = UserNameProperty

                                };
                                
                                objPharmaEntities.Hr_EmpCertifications.Add(loclDtls);
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







        public List<Hr_EmpCertifications> SelectAllEmpCertificationsetting(string Company_Id, string Branch_Id, decimal Emp_Serial_No)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_EmpCertifications> objectList = new List<Hr_EmpCertifications>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpCertifications
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_Serial_No 
                               //&& objLinq.Grade_Id == Grade_Id

                               select new
                               {

                                   EmpHdrId = objLinq.EmpHdrId,
                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   Certification_Name = objLinq.Certification_Name,
                                   FromDate = objLinq.FromDate,
                                   ToDate = objLinq.ToDate,
                                   Major_Name = objLinq.Major_Name,
                                   Degree = objLinq.Degree,
                                   Place = objLinq.Place,
                                   Certification_No = objLinq.Certification_No,
                                   DocAttach = objLinq.DocAttach,
                                   Notes = objLinq.Notes
                                   
                                   
      
                               }).ToList();

                

                 foreach (var obj in objlist)
                {
                    Hr_EmpCertifications objEmpCertificationsDL = new Hr_EmpCertifications();

                        objEmpCertificationsDL.Branch_Id = obj.Branch_Id;
                        objEmpCertificationsDL.Company_Id = obj.Company_Id;
                        objEmpCertificationsDL.EmpHdrId = obj.EmpHdrId;        
                        objEmpCertificationsDL. Certification_Name = obj.Certification_Name;
                        objEmpCertificationsDL.FromDate = obj.FromDate;
                        objEmpCertificationsDL.ToDate = obj.ToDate;
                        objEmpCertificationsDL.Major_Name = obj.Major_Name;
                        objEmpCertificationsDL.Degree = obj.Degree;
                        objEmpCertificationsDL.Place = obj.Place;
                        objEmpCertificationsDL.Certification_No = obj.Certification_No;
                        objEmpCertificationsDL.DocAttach = obj.DocAttach;
                        objEmpCertificationsDL.Notes = obj.Notes;
                        objEmpCertificationsDL.Emp_Serial_No = obj.Emp_Serial_No;

                    
                    objectList.Add(objEmpCertificationsDL);

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



        public bool DeleteEmpCertifications(string Branch_Id, string Company_Id, decimal? Emp_Serial_No)
        {
            bool result = true;
            List<Hr_EmpCertifications> EmpCertificationsToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                EmpCertificationsToDelete = ctx.Hr_EmpCertifications.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.Emp_Serial_No == Emp_Serial_No).ToList();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                foreach (Hr_EmpCertifications Obj_Dtls in EmpCertificationsToDelete)
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
