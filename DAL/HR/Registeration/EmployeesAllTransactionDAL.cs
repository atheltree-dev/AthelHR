using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Objects;
using System.Diagnostics;
using System.Reflection;
using BOL.HR.Registeration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
namespace DAL.HR.Registeration
{
    public class EmployeesAllTransactionDAL : CommonDB

    {
        public bool InsetEmployeeData(Hr_Employees objInsert, List<Hr_EmpDues> ListDtlsEmpDus, Hr_EmpDuesVactionTicket Obj_DtlsVaction) 
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

                                    EmpDuesDAL objEmpGrade = new EmpDuesDAL();

                                    result = objEmpGrade.AddEmpDuesByContext(ListDtlsEmpDus, varEmpHdrId, UserNameProperty, varcontext);

                                    if (result)
                                    {
                                        //EmpSpousesDAL objEmpSpouses = new EmpSpousesDAL();

                                        //result = objEmpSpouses.AddEmpSpousesByContext(ListDtlsEmpSpouses, varEmpHdrId, UserNameProperty, varcontext);
                                        //if (result)
                                        //{
                                            EmpDuesVactionTicketDAL objEmpVaction = new EmpDuesVactionTicketDAL();
                                            Obj_DtlsVaction.EmpHdrId = varEmpHdrId;
                                            Obj_DtlsVaction.InsUser = UserNameProperty;

                                            result = objEmpVaction.AddNewRecordByContext(Obj_DtlsVaction, varcontext);

                                            if (result)
                                            {
                                                EmployeesDAL objEmp = new EmployeesDAL();
                                                objInsert.EmpHdrId = varEmpHdrId;
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
                                catch (NullReferenceException ex)
                                {
                                    dbContextTransaction.Rollback();

                                    string.Concat("Processor Usage" + ex.Message);
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




        public bool UpdateEmployeeData(Hr_Employees objUpdate, List<Hr_EmpDues> ListDtlsEmpDus, Hr_EmpDuesVactionTicket Obj_DtlsVaction)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            bool result = false;
            var strErrorMessage = string.Empty;

            try
            {
                //int resultUpdateEmployee = 0;
                Guid? varEmpHdrId;
                decimal varEmpSerialNo;
                varEmpHdrId = ListDtlsEmpDus[0].EmpHdrId;
                varEmpSerialNo = ListDtlsEmpDus[0].Emp_Serial_No;
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

                            EmpDuesDAL objEmpGrade = new EmpDuesDAL();

                            result = objEmpGrade.UpdateEmpDuesByContext(ListDtlsEmpDus, varEmpHdrId, varEmpSerialNo, UserNameProperty, varcontext);

                            if (result)
                            {
                                //EmpSpousesDAL objEmpSpouses = new EmpSpousesDAL();

                                //result = objEmpSpouses.UpdateEmpSpousesByContext(ListDtlsEmpSpouses, varEmpHdrId, varEmpSerialNo, UserNameProperty, varcontext);
                                //if (result)
                                //{

                                    EmpDuesVactionTicketDAL objEmpVaction = new EmpDuesVactionTicketDAL();
                                    Obj_DtlsVaction.EmpHdrId = varEmpHdrId;
                                    Obj_DtlsVaction.UpdateUser = UserNameProperty;

                                    result = objEmpVaction.UpdateNewRecordByContext(Obj_DtlsVaction, varcontext);

                                    if (result)
                                    {
                                        EmployeesDAL objEmp = new EmployeesDAL();
                                        objUpdate.EmpHdrId = varEmpHdrId;
                                        objUpdate.UpdateUser = UserNameProperty;
                                        result = objEmp.UpdateTaskBYContext(objUpdate, varcontext);

                                        //result = (resultInsertEmployee > 0);
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
        public bool DeleteEmployeeData(Hr_Employees objUpdate, List<Hr_EmpDues> ListDtlsEmpDus, Hr_EmpDuesVactionTicket Obj_DtlsVaction)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            bool result = false;
            var strErrorMessage = string.Empty;

            try
            {
                //int resultUpdateEmployee = 0;
                Guid? varEmpHdrId;
                decimal varEmpSerialNo;
                string varBranchId,varCompanyId;
                varEmpHdrId = ListDtlsEmpDus[0].EmpHdrId;
                varEmpSerialNo = ListDtlsEmpDus[0].Emp_Serial_No;
                varBranchId = ListDtlsEmpDus[0].Branch_Id;
                varCompanyId = ListDtlsEmpDus[0].Company_Id;

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

                            EmpDuesDAL objEmpGrade = new EmpDuesDAL();

                            result = objEmpGrade.DeleteEmpDuesHireItemByContext(varBranchId,varCompanyId, varEmpHdrId, varEmpSerialNo, varcontext);

                            if (result)
                            {
                                //EmpSpousesDAL objSpouses = new EmpSpousesDAL();

                                //result = objSpouses.DeleteEmpSpousesByContext(varBranchId, varCompanyId, varEmpHdrId, varEmpSerialNo, varcontext);
                                //if (result)
                                //{

                                    EmpDuesVactionTicketDAL objEmpVaction = new EmpDuesVactionTicketDAL();
                                    Obj_DtlsVaction.EmpHdrId = varEmpHdrId;
                                    Obj_DtlsVaction.UpdateUser = UserNameProperty;

                                    result = objEmpVaction.DeleteEmpVactionTicketByContext(varBranchId, varCompanyId, varEmpHdrId, varEmpSerialNo, varcontext);

                                    if (result)
                                    {
                                        EmployeesDAL objEmp = new EmployeesDAL();
                                        objUpdate.EmpHdrId = varEmpHdrId;
                                        objUpdate.DeleteUser = UserNameProperty;
                                        result = objEmp.DeleteTaskByContext(objUpdate, varcontext);

                                        //result = (resultInsertEmployee > 0);
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
