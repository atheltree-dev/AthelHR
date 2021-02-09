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
  public  class EmpExperiencesDAL:CommonDB

    {

      public bool AddNewRecord(List<Hr_EmpExperiences> ListDtls)
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
                        result = DeleteEmpExperiences(strBranch_Id, strCompany_Id, strEmp_Serial_No);
                    }

                    if (result == true) 
                    { 
                    foreach (Hr_EmpExperiences Obj_Dtls in ListDtls)
                    {
                        if (Obj_Dtls != null)
                        {
                         //  Experience_Name, FromDate, ToDate, Job_Title, ExperienceCategory_Id, Place, InsUser, InsDate, UpdateUser, 
                         //UpdateDate, Experience_Id, DocAttach, EmpHdrId


                               Hr_EmpExperiences loclDtls = new Hr_EmpExperiences
                                {
                                    Dtls_Id=Obj_Dtls.Dtls_Id,
                                    EmpHdrId = Obj_Dtls.EmpHdrId,
                                    Branch_Id = Obj_Dtls.Branch_Id,
                                    Company_Id = Obj_Dtls.Company_Id,
                                    Experience_Name = Obj_Dtls.Experience_Name,
                                    FromDate = Obj_Dtls.FromDate,
                                    ToDate = Obj_Dtls.ToDate,
                                    Job_Title = Obj_Dtls.Job_Title,
                                    ExperienceCategory_Id = Obj_Dtls.ExperienceCategory_Id,
                                    Place = Obj_Dtls.Place,
                                    Experience_Id = Obj_Dtls.Experience_Id,
                                    DocAttach = Obj_Dtls.DocAttach,
                                    ReferenceType = Obj_Dtls.ReferenceType,
                                    Notes = Obj_Dtls.Notes,
                                    Emp_Serial_No = Obj_Dtls.Emp_Serial_No,
                                    InsDate = DateTime.Now,
                                    InsUser = UserNameProperty

                                };
                                
                                objPharmaEntities.Hr_EmpExperiences.Add(loclDtls);
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







        public List<Hr_EmpExperiences> SelectAllEmpExperiencesetting(string Company_Id, string Branch_Id, decimal Emp_Serial_No)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_EmpExperiences> objectList = new List<Hr_EmpExperiences>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpExperiences
                               where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_Serial_No 
                               //&& objLinq.Grade_Id == Grade_Id

                               select new
                               {

                                   EmpHdrId = objLinq.EmpHdrId,
                                   Branch_Id = objLinq.Branch_Id,
                                   Company_Id = objLinq.Company_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   Experience_Name = objLinq.Experience_Name,
                                   FromDate = objLinq.FromDate,
                                   ToDate = objLinq.ToDate,
                                   Job_Title = objLinq.Job_Title,
                                   ExperienceCategory_Id = objLinq.ExperienceCategory_Id,
                                   Place = objLinq.Place,
                                   ReferenceType = objLinq.ReferenceType,
                                   Experience_Id = objLinq.Experience_Id,
                                   DocAttach = objLinq.DocAttach,
                                   Notes = objLinq.Notes
                                   
                                   
      
                               }).ToList();

                

                 foreach (var obj in objlist)
                {
                    Hr_EmpExperiences objEmpExperiencesDL = new Hr_EmpExperiences();

                        objEmpExperiencesDL.Branch_Id = obj.Branch_Id;
                        objEmpExperiencesDL.Company_Id = obj.Company_Id;
                        objEmpExperiencesDL.EmpHdrId = obj.EmpHdrId;        
                        objEmpExperiencesDL. Experience_Name = obj.Experience_Name;
                        objEmpExperiencesDL.FromDate = obj.FromDate;
                        objEmpExperiencesDL.ToDate = obj.ToDate;
                        objEmpExperiencesDL.Job_Title = obj.Job_Title;
                        objEmpExperiencesDL.ExperienceCategory_Id = obj.ExperienceCategory_Id;
                        objEmpExperiencesDL.Place = obj.Place;
                        objEmpExperiencesDL.Experience_Id = obj.Experience_Id;
                        objEmpExperiencesDL.DocAttach = obj.DocAttach;
                        objEmpExperiencesDL.Notes = obj.Notes;
                        objEmpExperiencesDL.ReferenceType = obj.ReferenceType;
                        objEmpExperiencesDL.Emp_Serial_No = obj.Emp_Serial_No;

                    
                    objectList.Add(objEmpExperiencesDL);

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



        public bool DeleteEmpExperiences(string Branch_Id, string Company_Id, decimal? Emp_Serial_No)
        {
            bool result = true;
            List<Hr_EmpExperiences> EmpExperiencesToDelete;
            //1. Get student from DB
            using (var ctx = new AthelHREntities())
            {


                EmpExperiencesToDelete = ctx.Hr_EmpExperiences.Where(s => s.Branch_Id == Branch_Id && s.Company_Id == Company_Id && s.Emp_Serial_No == Emp_Serial_No).ToList();
            }

            //Create new context for disconnected scenario
            using (var newContext = new AthelHREntities())
            {

                foreach (Hr_EmpExperiences Obj_Dtls in EmpExperiencesToDelete)
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
