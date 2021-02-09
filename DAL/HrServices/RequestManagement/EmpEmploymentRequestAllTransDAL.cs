using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HrServices.RequestManagement;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
namespace DAL.HrServices.RequestManagement
{
    public class EmpEmploymentRequestAllTransDAL : CommonDB

    {
        public bool InsetEmployeementReguest(Hr_EmpEmploymentRequest objInsert, List<Hr_EmploymentQualifyRequest> ListDtlsEmpQulify, List<Hr_EmploymentExperinceRequest> Obj_DtlsExprince)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            bool result = false;
            var strErrorMessage = string.Empty;

            try
            {
                int resultInsertEmployee = 0;
                Guid varEmpHdrId;
                varEmpHdrId = GetNewHeaderId();
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

                            EmploymentExperinceRequestDAL objEmploymentExperince = new EmploymentExperinceRequestDAL();

                            result = objEmploymentExperince.AddEmploymentExperinceRequestByContext(Obj_DtlsExprince, varEmpHdrId, UserNameProperty, varcontext);

                            if (result)
                            {
                                //EmpSpousesDAL objEmpSpouses = new EmpSpousesDAL();

                                //result = objEmpSpouses.AddEmpSpousesByContext(ListDtlsEmpSpouses, varEmpHdrId, UserNameProperty, varcontext);
                                //if (result)
                                //{
                                EmploymentQualifyRequestDAL objEmploymentQulify = new EmploymentQualifyRequestDAL();

                                result = objEmploymentQulify.AddEmploymentQualifyRequestByContext(ListDtlsEmpQulify, varEmpHdrId, UserNameProperty, varcontext);

                                if (result)
                                {
                                    EmpEmploymentRequestDAL objEmp = new EmpEmploymentRequestDAL();
                                    objInsert.Rec_Hdr_Id = varEmpHdrId;
                                    objInsert.InsUser = UserNameProperty;
                                    resultInsertEmployee = objEmp.InsertTaskByContext(objInsert, varcontext);

                                    result = (resultInsertEmployee > 0);
                                    varcontext.SaveChanges();
                                    dbContextTransaction.Commit();
                                }
                            }
                            //}



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

                    //--- End Try


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


    }
}
