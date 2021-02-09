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
    public class EmployeesDAL : CommonDB

    {
        public async Task<int> Insert(Hr_Employees objInsert)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int RowEffected = 0;
            try
            {
                if (objInsert != null)
                {
                    OpenEntityConnection();

                    objInsert.InsDate = DateTime.Now;//DateTime.Today;


                    objPharmaEntities.Hr_Employees.Add(objInsert);
                    RowEffected = await objPharmaEntities.SaveChangesAsync();
                }

            }


            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());

                RowEffected = -1;
                ex.InnerException.Message.ToString();


            }
            finally
            {
                CloseEntityConnection();
            }
            return RowEffected;
        }
        // Calling the method of using Async
        //public  int test() {
        //    int task =  Insert().Result;
        //    return task;

        //}
        public int InsertTask(Hr_Employees objInsert)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            //int result = Insert(objInsert).Result;
            //return result;

            int RowEffected = 0;

            try
            {
                if (objInsert != null)
                {
                    OpenEntityConnection();
                    objInsert.InsDate = DateTime.Now;//DateTime.Today;
                    objPharmaEntities.Hr_Employees.Add(objInsert);
                    RowEffected = 1;
                    //objPharmaEntities.SaveChanges();


                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());

                RowEffected = -1;
                ex.InnerException.Message.ToString();


            }
            finally
            {
                CloseEntityConnection();
            }
            return RowEffected;


        }

        public int InsertTaskByContext(Hr_Employees objInsert, AthelHREntities varContext)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            //int result = Insert(objInsert).Result;
            //return result;

            int RowEffected = 0;

            try
            {
                if (objInsert != null)
                {
                    // OpenEntityConnection();
                    objInsert.InsDate = DateTime.Now;//DateTime.Today;
                    objInsert.Qualify_Id = "1";
                    objInsert.Qualify_Type_Id = "1";

                    varContext.Hr_Employees.Add(objInsert);
                    RowEffected = varContext.SaveChanges();
                    //varAthelHREntities.SaveChanges();


                }

            }
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)

            {

                Exception raise = dbEx;

                foreach (var validationErrors in dbEx.EntityValidationErrors)

                {

                    foreach (var validationError in validationErrors.ValidationErrors)

                    {

                        string message = string.Format("{0}:{1}",

                            validationErrors.Entry.Entity.ToString(),

                          validationError.ErrorMessage);

                        // raise a new exception nesting

                        // the current instance as InnerException

                        raise = new InvalidOperationException(message, raise);

                    }

                }

                throw raise;

            }


            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());

                RowEffected = -1;
                ex.InnerException.Message.ToString();


            }
            finally
            {
                CloseEntityConnection();
            }
            return RowEffected;



        }
        public List<EmployeesDL> SearchDataIsExist(string strcomapny, string strbranch, string strEmpSerialNo, decimal strEmpSearchName)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<EmployeesDL> objectEmpList = new List<EmployeesDL>();

            try
            {
                OpenEntityConnection();
                var varstrempserialno = strEmpSerialNo;
                var varstrempsearchname = strEmpSearchName;


                string sql = "select [Company_Id],[Branch_Id],[Emp_Serial_No]";
                sql = sql + ",[Emp_Id],[Emp_Code],[Emp_First_Name],[Emp_Meduim_Name],[Emp_GrandFatherName],[Emp_Last_Name],[Emp_First_NameEn],[Emp_Meduim_NameEn]";
                sql = sql + ",[Emp_GrandFatherNameEn],[Emp_Last_NameEn],[Emp_Last_NameConv],[Birth_Date],[WorkStartingDate],[Birth_Place],[Hire_Date],[Social_Status_Id],[Military_Status_Id]";
                sql = sql + ",[Geneder_Id],[Religion_Id],[Countery_Id],[City_Id],[Nationality_Id],[Project_Id],[Contract_Id],[Admin_Id],[Dept_Id]";
                sql = sql + ",[Job_Id],[JobTitle],[Grade_Id],[Qualify_Type_Id],[Qualify_Id],[Shift_Id],[Identity_Type_Id],[Identity_No]";
                sql = sql + ",[Identity_StartDate],[Identity_StartDateHijri],[Identity_EndDate],[Identity_EndDateHijri],[Inside_Phone]";
                sql = sql + ",[Inside_Mobile1],[Inside_Mobile2],[Outside_Phone1],[Outside_Mobile1],[Outside_Mobile2],[Fax]";
                sql = sql + ",[InsideAddress1],[InsideAddress2],[OutsideAddress1],[OutsideAddress2],[BusinessEmail],[PrivateEmail],[Manager_Id],[Bank_No1]";
                sql = sql + ",[AccountBankNo1]";
                sql = sql + ",[IBAN_No1],[Bank_No2],[AccountBankNo2],[IBAN_No2],[HasFingerPrint],[HasAbsence],[HasOverTime],[HasDelay],[HasPermission]";
                sql = sql + ",[HasMedicalInsurance],[Medical_Insurance_No],[Medical_Insurance_StartDate],[Medical_Insurance_StartDateHijri],[Medical_Insurance_EndDate]";
                sql = sql + ",[Medical_Insurance_EndDateHijri],[Social_Insurance_No],[Notes],[InsUser],[InsDate],[UpdateUser],[UpdateDate]";
                sql = sql + ",[DeleteUser],[DeleteDate],[Rec_Status],[Prefix],[FullNameArabic],[FullNameEn],[ImagePath],[PassportNo],[PassportIssueDate],[PassportExpiryDate]";
                sql = sql + ",[IsCommissioner],[Commissioner_Serial_no],[NeedMandate],EmpHdrId,GradeJob_Id,EmpStatusId,HasManager,ContractClassify,StartContract,EndContract";
                sql = sql + ",ContractPeriodByMonth,IsEmpManager  ";
                sql = sql + ",DeductInsurance,EnrollFPNumber,Attendance_Type,DeliverSalType,ResignationDate,TestPeriodInMonth,EndTestPeriodDate";


                sql = sql + " from Hr_Employees where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";
                if (strEmpSerialNo.Length > 0 && strEmpSerialNo != "-1")
                {
                    sql = sql + " and Emp_Code='" + strEmpSerialNo + "'";
                }
                if (strEmpSearchName > 0)
                {
                    sql = sql + " and Emp_Serial_No='" + strEmpSearchName + "'";
                }

                List<EmployeesDL> objectlist = objPharmaEntities.Database.SqlQuery<EmployeesDL>(sql).ToList();

                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        EmployeesDL objEmployeesDL = new EmployeesDL();

                        objEmployeesDL.Company_Id = obj.Company_Id;
                        objEmployeesDL.Branch_Id = obj.Branch_Id;
                        objEmployeesDL.Emp_Serial_No = obj.Emp_Serial_No;
                        objEmployeesDL.Emp_Id = obj.Emp_Id;
                        objEmployeesDL.Emp_Code = obj.Emp_Code;
                        objEmployeesDL.Emp_First_Name = obj.Emp_First_Name;
                        objEmployeesDL.Emp_Meduim_Name = obj.Emp_Meduim_Name;
                        objEmployeesDL.Emp_Last_Name = obj.Emp_Last_Name;
                        objEmployeesDL.Emp_First_NameEn = obj.Emp_First_NameEn;
                        objEmployeesDL.Emp_Meduim_NameEn = obj.Emp_Meduim_NameEn;
                        objEmployeesDL.Emp_Last_NameEn = obj.Emp_Last_NameEn;
                        objEmployeesDL.Emp_Last_NameConv = obj.Emp_Last_NameConv;
                        objEmployeesDL.Emp_GrandFatherName = obj.Emp_GrandFatherName;
                        objEmployeesDL.Emp_GrandFatherNameEn = obj.Emp_GrandFatherNameEn;
                        objEmployeesDL.Birth_Date = obj.Birth_Date;
                        objEmployeesDL.WorkStartingDate = obj.WorkStartingDate;
                        objEmployeesDL.Birth_Place = obj.Birth_Place;
                        objEmployeesDL.Hire_Date = obj.Hire_Date;
                        objEmployeesDL.Social_Status_Id = obj.Social_Status_Id;
                        objEmployeesDL.Military_Status_Id = obj.Military_Status_Id;
                        objEmployeesDL.Geneder_Id = obj.Geneder_Id;
                        objEmployeesDL.Religion_Id = obj.Religion_Id;
                        objEmployeesDL.Countery_Id = obj.Countery_Id;
                        objEmployeesDL.City_Id = obj.City_Id;
                        objEmployeesDL.Nationality_Id = obj.Nationality_Id;
                        objEmployeesDL.Project_Id = obj.Project_Id;
                        objEmployeesDL.Contract_Id = obj.Contract_Id;
                        objEmployeesDL.Admin_Id = obj.Admin_Id;
                        objEmployeesDL.Dept_Id = obj.Dept_Id;
                        objEmployeesDL.Job_Id = obj.Job_Id;
                        objEmployeesDL.JobTitle = obj.JobTitle;
                        objEmployeesDL.Grade_Id = obj.Grade_Id;
                        objEmployeesDL.Qualify_Type_Id = "1";
                        objEmployeesDL.Qualify_Id = "1";
                        objEmployeesDL.Shift_Id = obj.Shift_Id;
                        objEmployeesDL.Identity_Type_Id = obj.Identity_Type_Id;
                        objEmployeesDL.Identity_No = obj.Identity_No;
                        objEmployeesDL.Identity_StartDate = obj.Identity_StartDate;
                        objEmployeesDL.Identity_StartDateHijri = obj.Identity_StartDateHijri;
                        objEmployeesDL.Identity_EndDate = obj.Identity_EndDate;
                        objEmployeesDL.Identity_EndDateHijri = obj.Identity_EndDateHijri;
                        objEmployeesDL.Inside_Phone = obj.Inside_Phone;
                        objEmployeesDL.Inside_Mobile1 = obj.Inside_Mobile1;
                        objEmployeesDL.Inside_Mobile2 = obj.Inside_Mobile2;
                        objEmployeesDL.Outside_Phone1 = obj.Outside_Phone1;
                        objEmployeesDL.Outside_Mobile1 = obj.Outside_Mobile1;
                        objEmployeesDL.Outside_Mobile2 = obj.Outside_Mobile2;
                        objEmployeesDL.Fax = obj.Fax;
                        objEmployeesDL.InsideAddress1 = obj.InsideAddress1;
                        objEmployeesDL.InsideAddress2 = obj.InsideAddress2;
                        objEmployeesDL.OutsideAddress1 = obj.OutsideAddress1;
                        objEmployeesDL.OutsideAddress2 = obj.OutsideAddress2; ;
                        objEmployeesDL.BusinessEmail = obj.BusinessEmail;
                        objEmployeesDL.PrivateEmail = obj.PrivateEmail;
                        objEmployeesDL.Manager_Id = obj.Manager_Id;
                        objEmployeesDL.Bank_No1 = obj.Bank_No1;
                        objEmployeesDL.AccountBankNo1 = obj.AccountBankNo1;
                        objEmployeesDL.IBAN_No1 = obj.IBAN_No1;
                        objEmployeesDL.Bank_No2 = obj.Bank_No2;
                        objEmployeesDL.AccountBankNo2 = obj.AccountBankNo2;
                        objEmployeesDL.IBAN_No2 = obj.IBAN_No2;
                        objEmployeesDL.HasFingerPrint = obj.HasFingerPrint;
                        objEmployeesDL.HasAbsence = obj.HasAbsence;
                        objEmployeesDL.HasOverTime = obj.HasOverTime;
                        objEmployeesDL.HasDelay = obj.HasDelay;
                        objEmployeesDL.HasPermission = obj.HasPermission;
                        objEmployeesDL.HasMedicalInsurance = obj.HasMedicalInsurance;
                        objEmployeesDL.Medical_Insurance_No = obj.Medical_Insurance_No;
                        objEmployeesDL.Medical_Insurance_StartDate = obj.Medical_Insurance_StartDate;
                        objEmployeesDL.Medical_Insurance_StartDateHijri = obj.Medical_Insurance_StartDateHijri;
                        objEmployeesDL.Medical_Insurance_EndDate = obj.Medical_Insurance_EndDate;
                        objEmployeesDL.Medical_Insurance_EndDateHijri = obj.Medical_Insurance_EndDateHijri;
                        objEmployeesDL.Notes = obj.Notes;
                        objEmployeesDL.UpdateUser = obj.UpdateUser;
                        objEmployeesDL.UpdateDate = obj.UpdateDate;
                        objEmployeesDL.Prefix = obj.Prefix;
                        objEmployeesDL.ImagePath = obj.ImagePath;
                        objEmployeesDL.FullNameArabic = obj.FullNameArabic;
                        objEmployeesDL.FullNameEn = obj.FullNameEn;
                        objEmployeesDL.Social_Insurance_No = obj.Social_Insurance_No;
                        objEmployeesDL.PassportNo = obj.PassportNo;
                        objEmployeesDL.PassportIssueDate = obj.PassportIssueDate;
                        objEmployeesDL.PassportExpiryDate = obj.PassportExpiryDate;

                        objEmployeesDL.IsCommissioner = obj.IsCommissioner;
                        objEmployeesDL.Commissioner_Serial_no = obj.Commissioner_Serial_no;
                        objEmployeesDL.NeedMandate = obj.NeedMandate;
                        objEmployeesDL.EmpHdrId = obj.EmpHdrId;
                        objEmployeesDL.EmpStatusId = obj.EmpStatusId;
                        objEmployeesDL.HasManager = obj.HasManager;
                        objEmployeesDL.ContractClassify = obj.ContractClassify;
                        objEmployeesDL.StartContract = obj.StartContract;
                        objEmployeesDL.EndContract = obj.EndContract;
                        objEmployeesDL.GradeJob_Id = obj.GradeJob_Id;
                        objEmployeesDL.IsEmpManager = obj.IsEmpManager;
                        objEmployeesDL.ContractPeriodByMonth = obj.ContractPeriodByMonth;

                        objEmployeesDL.DeductInsurance = obj.DeductInsurance;
                        objEmployeesDL.EnrollFPNumber = obj.EnrollFPNumber;
                        objEmployeesDL.Attendance_Type = obj.Attendance_Type;
                        objEmployeesDL.DeliverSalType = obj.DeliverSalType;
                        objEmployeesDL.ResignationDate = obj.ResignationDate;

                        objEmployeesDL.TestPeriodInMonth = obj.TestPeriodInMonth;
                        objEmployeesDL.EndTestPeriodDate = obj.EndTestPeriodDate;

                        objectEmpList.Add(objEmployeesDL);

                    }
                }

                //var str = (from objlinq in objPharmaEntities.Hr_Employees
                //           where objlinq.Rec_Status == 0
                //           && objlinq.Company_Id == strcomapny && objlinq.Branch_Id == strbranch
                //           select objlinq);
                //string sql = ((ObjectQuery)str).ToTraceString();

                return objectEmpList;




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


        public List<EmployeesDL> SearchDataIsExistNew(string strcomapny, string strbranch, string strEmpSerialNo)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<EmployeesDL> objectEmpList = new List<EmployeesDL>();

            try
            {
                OpenEntityConnection();
                var varstrempserialno = strEmpSerialNo;


                string sql = "select [Company_Id],[Branch_Id],[Emp_Serial_No]";
                sql = sql + ",[Emp_Id],[Emp_Code],[Emp_First_Name],[Emp_Meduim_Name],[Emp_GrandFatherName],[Emp_Last_Name],[Emp_First_NameEn],[Emp_Meduim_NameEn]";
                sql = sql + ",[Emp_GrandFatherNameEn],[Emp_Last_NameEn],[Emp_Last_NameConv],[Birth_Date],[WorkStartingDate],[Birth_Place],[Hire_Date],[Social_Status_Id],[Military_Status_Id]";
                sql = sql + ",[Geneder_Id],[Religion_Id],[Countery_Id],[City_Id],[Nationality_Id],[Project_Id],[Contract_Id],[Admin_Id],[Dept_Id]";
                sql = sql + ",[Job_Id],[JobTitle],[Grade_Id],[Qualify_Type_Id],[Qualify_Id],[Shift_Id],[Identity_Type_Id],[Identity_No]";
                sql = sql + ",[Identity_StartDate],[Identity_StartDateHijri],[Identity_EndDate],[Identity_EndDateHijri],[Inside_Phone]";
                sql = sql + ",[Inside_Mobile1],[Inside_Mobile2],[Outside_Phone1],[Outside_Mobile1],[Outside_Mobile2],[Fax]";
                sql = sql + ",[InsideAddress1],[InsideAddress2],[OutsideAddress1],[OutsideAddress2],[BusinessEmail],[PrivateEmail],[Manager_Id],[Bank_No1]";
                sql = sql + ",[AccountBankNo1]";
                sql = sql + ",[IBAN_No1],[Bank_No2],[AccountBankNo2],[IBAN_No2],[HasFingerPrint],[HasAbsence],[HasOverTime],[HasDelay],[HasPermission]";
                sql = sql + ",[HasMedicalInsurance],[Medical_Insurance_No],[Medical_Insurance_StartDate],[Medical_Insurance_StartDateHijri],[Medical_Insurance_EndDate]";
                sql = sql + ",[Medical_Insurance_EndDateHijri],[Social_Insurance_No],[Notes],[InsUser],[InsDate],[UpdateUser],[UpdateDate]";
                sql = sql + ",[DeleteUser],[DeleteDate],[Rec_Status],[Prefix],[FullNameArabic],[FullNameEn],[ImagePath],[PassportNo],[PassportIssueDate],[PassportExpiryDate]";
                sql = sql + ",[IsCommissioner],[Commissioner_Serial_no],[NeedMandate],EmpHdrId,GradeJob_Id,EmpStatusId,HasManager,ContractClassify,StartContract,EndContract";
                sql = sql + ",ContractPeriodByMonth,IsEmpManager  ";
                sql = sql + ",DeductInsurance,EnrollFPNumber,Attendance_Type,DeliverSalType,ResignationDate,TestPeriodInMonth,EndTestPeriodDate";


                sql = sql + " from Hr_Employees where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";
                if (strEmpSerialNo.Length > 0 && strEmpSerialNo != "-1")
                {
                    sql = sql + " and Emp_Serial_No=" + strEmpSerialNo + "";
                }
                //if (strEmpSearchName > 0)
                //{
                //    sql = sql + " and Emp_Serial_No='" + strEmpSearchName + "'";
                //}

                List<EmployeesDL> objectlist = objPharmaEntities.Database.SqlQuery<EmployeesDL>(sql).ToList();

                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        EmployeesDL objEmployeesDL = new EmployeesDL();

                        objEmployeesDL.Company_Id = obj.Company_Id;
                        objEmployeesDL.Branch_Id = obj.Branch_Id;
                        objEmployeesDL.Emp_Serial_No = obj.Emp_Serial_No;
                        objEmployeesDL.Emp_Id = obj.Emp_Id;
                        objEmployeesDL.Emp_Code = obj.Emp_Code;
                        objEmployeesDL.Emp_First_Name = obj.Emp_First_Name;
                        objEmployeesDL.Emp_Meduim_Name = obj.Emp_Meduim_Name;
                        objEmployeesDL.Emp_Last_Name = obj.Emp_Last_Name;
                        objEmployeesDL.Emp_First_NameEn = obj.Emp_First_NameEn;
                        objEmployeesDL.Emp_Meduim_NameEn = obj.Emp_Meduim_NameEn;
                        objEmployeesDL.Emp_Last_NameEn = obj.Emp_Last_NameEn;
                        objEmployeesDL.Emp_Last_NameConv = obj.Emp_Last_NameConv;
                        objEmployeesDL.Emp_GrandFatherName = obj.Emp_GrandFatherName;
                        objEmployeesDL.Emp_GrandFatherNameEn = obj.Emp_GrandFatherNameEn;
                        objEmployeesDL.Birth_Date = obj.Birth_Date;
                        objEmployeesDL.WorkStartingDate = obj.WorkStartingDate;
                        objEmployeesDL.Birth_Place = obj.Birth_Place;
                        objEmployeesDL.Hire_Date = obj.Hire_Date;
                        objEmployeesDL.Social_Status_Id = obj.Social_Status_Id;
                        objEmployeesDL.Military_Status_Id = obj.Military_Status_Id;
                        objEmployeesDL.Geneder_Id = obj.Geneder_Id;
                        objEmployeesDL.Religion_Id = obj.Religion_Id;
                        objEmployeesDL.Countery_Id = obj.Countery_Id;
                        objEmployeesDL.City_Id = obj.City_Id;
                        objEmployeesDL.Nationality_Id = obj.Nationality_Id;
                        objEmployeesDL.Project_Id = obj.Project_Id;
                        objEmployeesDL.Contract_Id = obj.Contract_Id;
                        objEmployeesDL.Admin_Id = obj.Admin_Id;
                        objEmployeesDL.Dept_Id = obj.Dept_Id;
                        objEmployeesDL.Job_Id = obj.Job_Id;
                        objEmployeesDL.JobTitle = obj.JobTitle;
                        objEmployeesDL.Grade_Id = obj.Grade_Id;
                        objEmployeesDL.Qualify_Type_Id = "1";
                        objEmployeesDL.Qualify_Id = "1";
                        objEmployeesDL.Shift_Id = obj.Shift_Id;
                        objEmployeesDL.Identity_Type_Id = obj.Identity_Type_Id;
                        objEmployeesDL.Identity_No = obj.Identity_No;
                        objEmployeesDL.Identity_StartDate = obj.Identity_StartDate;
                        objEmployeesDL.Identity_StartDateHijri = obj.Identity_StartDateHijri;
                        objEmployeesDL.Identity_EndDate = obj.Identity_EndDate;
                        objEmployeesDL.Identity_EndDateHijri = obj.Identity_EndDateHijri;
                        objEmployeesDL.Inside_Phone = obj.Inside_Phone;
                        objEmployeesDL.Inside_Mobile1 = obj.Inside_Mobile1;
                        objEmployeesDL.Inside_Mobile2 = obj.Inside_Mobile2;
                        objEmployeesDL.Outside_Phone1 = obj.Outside_Phone1;
                        objEmployeesDL.Outside_Mobile1 = obj.Outside_Mobile1;
                        objEmployeesDL.Outside_Mobile2 = obj.Outside_Mobile2;
                        objEmployeesDL.Fax = obj.Fax;
                        objEmployeesDL.InsideAddress1 = obj.InsideAddress1;
                        objEmployeesDL.InsideAddress2 = obj.InsideAddress2;
                        objEmployeesDL.OutsideAddress1 = obj.OutsideAddress1;
                        objEmployeesDL.OutsideAddress2 = obj.OutsideAddress2; ;
                        objEmployeesDL.BusinessEmail = obj.BusinessEmail;
                        objEmployeesDL.PrivateEmail = obj.PrivateEmail;
                        objEmployeesDL.Manager_Id = obj.Manager_Id;
                        objEmployeesDL.Bank_No1 = obj.Bank_No1;
                        objEmployeesDL.AccountBankNo1 = obj.AccountBankNo1;
                        objEmployeesDL.IBAN_No1 = obj.IBAN_No1;
                        objEmployeesDL.Bank_No2 = obj.Bank_No2;
                        objEmployeesDL.AccountBankNo2 = obj.AccountBankNo2;
                        objEmployeesDL.IBAN_No2 = obj.IBAN_No2;
                        objEmployeesDL.HasFingerPrint = obj.HasFingerPrint;
                        objEmployeesDL.HasAbsence = obj.HasAbsence;
                        objEmployeesDL.HasOverTime = obj.HasOverTime;
                        objEmployeesDL.HasDelay = obj.HasDelay;
                        objEmployeesDL.HasPermission = obj.HasPermission;
                        objEmployeesDL.HasMedicalInsurance = obj.HasMedicalInsurance;
                        objEmployeesDL.Medical_Insurance_No = obj.Medical_Insurance_No;
                        objEmployeesDL.Medical_Insurance_StartDate = obj.Medical_Insurance_StartDate;
                        objEmployeesDL.Medical_Insurance_StartDateHijri = obj.Medical_Insurance_StartDateHijri;
                        objEmployeesDL.Medical_Insurance_EndDate = obj.Medical_Insurance_EndDate;
                        objEmployeesDL.Medical_Insurance_EndDateHijri = obj.Medical_Insurance_EndDateHijri;
                        objEmployeesDL.Notes = obj.Notes;
                        objEmployeesDL.UpdateUser = obj.UpdateUser;
                        objEmployeesDL.UpdateDate = obj.UpdateDate;
                        objEmployeesDL.Prefix = obj.Prefix;
                        objEmployeesDL.ImagePath = obj.ImagePath;
                        objEmployeesDL.FullNameArabic = obj.FullNameArabic;
                        objEmployeesDL.FullNameEn = obj.FullNameEn;
                        objEmployeesDL.Social_Insurance_No = obj.Social_Insurance_No;
                        objEmployeesDL.PassportNo = obj.PassportNo;
                        objEmployeesDL.PassportIssueDate = obj.PassportIssueDate;
                        objEmployeesDL.PassportExpiryDate = obj.PassportExpiryDate;

                        objEmployeesDL.IsCommissioner = obj.IsCommissioner;
                        objEmployeesDL.Commissioner_Serial_no = obj.Commissioner_Serial_no;
                        objEmployeesDL.NeedMandate = obj.NeedMandate;
                        objEmployeesDL.EmpHdrId = obj.EmpHdrId;
                        objEmployeesDL.EmpStatusId = obj.EmpStatusId;
                        objEmployeesDL.HasManager = obj.HasManager;
                        objEmployeesDL.ContractClassify = obj.ContractClassify;
                        objEmployeesDL.StartContract = obj.StartContract;
                        objEmployeesDL.EndContract = obj.EndContract;
                        objEmployeesDL.GradeJob_Id = obj.GradeJob_Id;
                        objEmployeesDL.IsEmpManager = obj.IsEmpManager;
                        objEmployeesDL.ContractPeriodByMonth = obj.ContractPeriodByMonth;

                        objEmployeesDL.DeductInsurance = obj.DeductInsurance;
                        objEmployeesDL.EnrollFPNumber = obj.EnrollFPNumber;
                        objEmployeesDL.Attendance_Type = obj.Attendance_Type;
                        objEmployeesDL.DeliverSalType = obj.DeliverSalType;
                        objEmployeesDL.ResignationDate = obj.ResignationDate;

                        objEmployeesDL.TestPeriodInMonth = obj.TestPeriodInMonth;
                        objEmployeesDL.EndTestPeriodDate = obj.EndTestPeriodDate;

                        objectEmpList.Add(objEmployeesDL);

                    }
                }

                //var str = (from objlinq in objPharmaEntities.Hr_Employees
                //           where objlinq.Rec_Status == 0
                //           && objlinq.Company_Id == strcomapny && objlinq.Branch_Id == strbranch
                //           select objlinq);
                //string sql = ((ObjectQuery)str).ToTraceString();

                return objectEmpList;




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


        public List<EmployeesDL> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<EmployeesDL> objectEmpList = new List<EmployeesDL>();

            try
            {
                OpenEntityConnection();
                string sql = "select [Company_Id],[Branch_Id],[Emp_Serial_No]";
                sql = sql + ",[Emp_Id],[Emp_Code],[Emp_First_Name],[Emp_Meduim_Name],[Emp_GrandFatherName],[Emp_Last_Name],[Emp_First_NameEn],[Emp_Meduim_NameEn]";
                sql = sql + ",[Emp_GrandFatherNameEn],[Emp_Last_NameEn],[Emp_Last_NameConv],[Birth_Date],[WorkStartingDate],[Birth_Place],[Hire_Date],[Social_Status_Id],[Military_Status_Id]";
                sql = sql + ",[Geneder_Id],[Religion_Id],[Countery_Id],[City_Id],[Nationality_Id],[Project_Id],[Contract_Id],[Admin_Id],[Dept_Id]";
                sql = sql + ",[Job_Id],[JobTitle],[Grade_Id],[Qualify_Type_Id],[Qualify_Id],[Shift_Id],[Identity_Type_Id],[Identity_No]";
                sql = sql + ",[Identity_StartDate],[Identity_StartDateHijri],[Identity_EndDate],[Identity_EndDateHijri],[Inside_Phone]";
                sql = sql + ",[Inside_Mobile1],[Inside_Mobile2],[Outside_Phone1],[Outside_Mobile1],[Outside_Mobile2],[Fax]";
                sql = sql + ",[InsideAddress1],[InsideAddress2],[OutsideAddress1],[OutsideAddress2],[BusinessEmail],[PrivateEmail],[Manager_Id],[Bank_No1]";
                sql = sql + ",[AccountBankNo1]";
                sql = sql + ",[IBAN_No1],[Bank_No2],[AccountBankNo2],[IBAN_No2],[HasFingerPrint],[HasAbsence],[HasOverTime],[HasDelay],[HasPermission]";
                sql = sql + ",[HasMedicalInsurance],[Medical_Insurance_No],[Medical_Insurance_StartDate],[Medical_Insurance_StartDateHijri],[Medical_Insurance_EndDate]";
                sql = sql + ",[Medical_Insurance_EndDateHijri],[Social_Insurance_No],[Notes],[InsUser],[InsDate],[UpdateUser],[UpdateDate]";
                sql = sql + ",[DeleteUser],[DeleteDate],[Rec_Status],[Prefix],[FullNameArabic],[FullNameEn],[ImagePath],[PassportNo],[PassportIssueDate],[PassportExpiryDate]  ";
                sql = sql + ",[IsCommissioner],[Commissioner_Serial_no],[NeedMandate],EmpHdrId,GradeJob_Id,EmpStatusId,HasManager,ContractClassify,StartContract,EndContract,ContractPeriodByMonth,IsEmpManager  ";
                sql = sql + " from Hr_Employees where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";
                sql = sql + " Order by replicate('0',15-len(Emp_Code))+Emp_Code ";

                List<EmployeesDL> objectlist = objPharmaEntities.Database.SqlQuery<EmployeesDL>(sql).ToList();

                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        EmployeesDL objEmployeesDL = new EmployeesDL();

                        objEmployeesDL.Company_Id = obj.Company_Id;
                        objEmployeesDL.Branch_Id = obj.Branch_Id;
                        objEmployeesDL.Emp_Id = obj.Emp_Id;
                        objEmployeesDL.Emp_Code = obj.Emp_Code;
                        objEmployeesDL.Emp_Serial_No = obj.Emp_Serial_No;
                        objEmployeesDL.Emp_First_Name = obj.Emp_First_Name;
                        objEmployeesDL.Emp_Meduim_Name = obj.Emp_Meduim_Name;
                        objEmployeesDL.Emp_Last_Name = obj.Emp_Last_Name;
                        objEmployeesDL.Emp_First_NameEn = obj.Emp_First_NameEn;
                        objEmployeesDL.Emp_Meduim_NameEn = obj.Emp_Meduim_NameEn;
                        objEmployeesDL.Emp_Last_NameEn = obj.Emp_Last_NameEn;
                        objEmployeesDL.Emp_Last_NameConv = obj.Emp_Last_NameConv;
                        objEmployeesDL.Emp_GrandFatherName = obj.Emp_GrandFatherName;
                        objEmployeesDL.Emp_GrandFatherNameEn = obj.Emp_GrandFatherNameEn;

                        objEmployeesDL.Birth_Date = obj.Birth_Date;
                        objEmployeesDL.WorkStartingDate = obj.WorkStartingDate;

                        objEmployeesDL.Birth_Place = obj.Birth_Place;
                        objEmployeesDL.Hire_Date = obj.Hire_Date;
                        objEmployeesDL.Social_Status_Id = obj.Social_Status_Id;
                        objEmployeesDL.Military_Status_Id = obj.Military_Status_Id;
                        objEmployeesDL.Geneder_Id = obj.Geneder_Id;
                        objEmployeesDL.Religion_Id = obj.Religion_Id;
                        objEmployeesDL.Countery_Id = obj.Countery_Id;
                        objEmployeesDL.City_Id = obj.City_Id;
                        objEmployeesDL.Nationality_Id = obj.Nationality_Id;
                        objEmployeesDL.Project_Id = obj.Project_Id;
                        objEmployeesDL.Contract_Id = obj.Contract_Id;
                        objEmployeesDL.Admin_Id = obj.Admin_Id;
                        objEmployeesDL.Dept_Id = obj.Dept_Id;
                        objEmployeesDL.Job_Id = obj.Job_Id;
                        objEmployeesDL.JobTitle = obj.JobTitle;
                        objEmployeesDL.Grade_Id = obj.Grade_Id;
                        objEmployeesDL.Qualify_Type_Id = "1";
                        objEmployeesDL.Qualify_Id = "1";
                        objEmployeesDL.Shift_Id = obj.Shift_Id;
                        objEmployeesDL.Identity_Type_Id = obj.Identity_Type_Id;
                        objEmployeesDL.Identity_No = obj.Identity_No;
                        objEmployeesDL.Identity_StartDate = obj.Identity_StartDate;
                        objEmployeesDL.Identity_StartDateHijri = obj.Identity_StartDateHijri;
                        objEmployeesDL.Identity_EndDate = obj.Identity_EndDate;
                        objEmployeesDL.Identity_EndDateHijri = obj.Identity_EndDateHijri;
                        objEmployeesDL.Inside_Phone = obj.Inside_Phone;
                        objEmployeesDL.Inside_Mobile1 = obj.Inside_Mobile1;
                        objEmployeesDL.Inside_Mobile2 = obj.Inside_Mobile2;
                        objEmployeesDL.Outside_Phone1 = obj.Outside_Phone1;
                        objEmployeesDL.Outside_Mobile1 = obj.Outside_Mobile1;
                        objEmployeesDL.Outside_Mobile2 = obj.Outside_Mobile2;
                        objEmployeesDL.Fax = obj.Fax;
                        objEmployeesDL.InsideAddress1 = obj.InsideAddress1;
                        objEmployeesDL.InsideAddress2 = obj.InsideAddress2;
                        objEmployeesDL.OutsideAddress1 = obj.OutsideAddress1;
                        objEmployeesDL.OutsideAddress2 = obj.OutsideAddress2; ;
                        objEmployeesDL.BusinessEmail = obj.BusinessEmail;
                        objEmployeesDL.PrivateEmail = obj.PrivateEmail;
                        objEmployeesDL.Manager_Id = obj.Manager_Id;
                        objEmployeesDL.Bank_No1 = obj.Bank_No1;
                        objEmployeesDL.AccountBankNo1 = obj.AccountBankNo1;
                        objEmployeesDL.IBAN_No1 = obj.IBAN_No1;
                        objEmployeesDL.Bank_No2 = obj.Bank_No2;
                        objEmployeesDL.AccountBankNo2 = obj.AccountBankNo2;
                        objEmployeesDL.IBAN_No2 = obj.IBAN_No2;
                        objEmployeesDL.HasFingerPrint = obj.HasFingerPrint;
                        objEmployeesDL.HasAbsence = obj.HasAbsence;
                        objEmployeesDL.HasOverTime = obj.HasOverTime;
                        objEmployeesDL.HasDelay = obj.HasDelay;
                        objEmployeesDL.HasPermission = obj.HasPermission;
                        objEmployeesDL.HasMedicalInsurance = obj.HasMedicalInsurance;
                        objEmployeesDL.Medical_Insurance_No = obj.Medical_Insurance_No;
                        objEmployeesDL.Medical_Insurance_StartDate = obj.Medical_Insurance_StartDate;
                        objEmployeesDL.Medical_Insurance_StartDateHijri = obj.Medical_Insurance_StartDateHijri;
                        objEmployeesDL.Medical_Insurance_EndDate = obj.Medical_Insurance_EndDate;
                        objEmployeesDL.Medical_Insurance_EndDateHijri = obj.Medical_Insurance_EndDateHijri;
                        objEmployeesDL.Notes = obj.Notes;
                        objEmployeesDL.UpdateUser = obj.UpdateUser;
                        objEmployeesDL.UpdateDate = obj.UpdateDate;
                        objEmployeesDL.Prefix = obj.Prefix;
                        objEmployeesDL.ImagePath = obj.ImagePath;
                        objEmployeesDL.FullNameArabic = obj.FullNameArabic;
                        objEmployeesDL.FullNameEn = obj.FullNameEn;
                        objEmployeesDL.Social_Insurance_No = obj.Social_Insurance_No;
                        objEmployeesDL.PassportNo = obj.PassportNo;
                        objEmployeesDL.PassportIssueDate = obj.PassportIssueDate;
                        objEmployeesDL.PassportExpiryDate = obj.PassportExpiryDate;

                        objEmployeesDL.IsCommissioner = obj.IsCommissioner;
                        objEmployeesDL.Commissioner_Serial_no = obj.Commissioner_Serial_no;
                        objEmployeesDL.NeedMandate = obj.NeedMandate;
                        objEmployeesDL.EmpHdrId = obj.EmpHdrId;
                        objEmployeesDL.EmpStatusId = obj.EmpStatusId;
                        objEmployeesDL.HasManager = obj.HasManager;
                        objEmployeesDL.ContractClassify = obj.ContractClassify;
                        objEmployeesDL.StartContract = obj.StartContract;
                        objEmployeesDL.EndContract = obj.EndContract;
                        objEmployeesDL.GradeJob_Id = obj.GradeJob_Id;
                        objEmployeesDL.IsEmpManager = obj.IsEmpManager;
                        objEmployeesDL.ContractPeriodByMonth = obj.ContractPeriodByMonth;


                        objectEmpList.Add(objEmployeesDL);

                    }
                }

                //var str = (from objlinq in objPharmaEntities.Hr_Employees
                //           where objlinq.Rec_Status == 0
                //           && objlinq.Company_Id == strcomapny && objlinq.Branch_Id == strbranch
                //           select objlinq);
                //string sql = ((ObjectQuery)str).ToTraceString();

                return objectEmpList;

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


        public List<Hr_Employees> SearchDataIsExistNew(string strcomapny, string strbranch, decimal strEmpSerialNo, decimal strEmpSearchName)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                var varstrempserialno = strEmpSerialNo;
                var varstrempsearchname = strEmpSearchName;

                //  list<hr_employees> objectlist = objpharmaentities.hr_employees.tolist().where(p => p.emp_serial_no == varstrempserialno);

                //List<Hr_Employees> objectlist = (from objlinq in objPharmaEntities.Hr_Employees
                //                                 where objlinq.Rec_Status == 0
                //                                 && objlinq.Company_Id == strcomapny && objlinq.Branch_Id == strbranch
                //                                 && ((objlinq.Emp_Serial_No == varstrempserialno) || objlinq.Emp_Serial_No == varstrempsearchname)
                //                                 select objlinq).ToList();
                List<Hr_Employees> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Employees>("select *  from Hr_Employees where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'").ToList();

                return objectlist;

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

        //public IEnumerable<Hr_Employees> SearchDataIsExistNew(string strcomapny, string strbranch, string strEmpSerialNo, string strEmpSearchName) 
        //{
        //    var varstrEmpSerialNo = Convert.ToDecimal(strEmpSerialNo);
        //    var varstrEmpSearchName = Convert.ToDecimal(strEmpSearchName);

        //    var objEmployees = from o in objPharmaEntities.Hr_Employees
        //                 select new Employees
        //                 {
        //                     emp = temp,
        //                     CourseName = o.CourseName,
        //                 };
        //    return objEmployees.ToList();
        //}

        public async Task<bool> Update(Hr_Employees objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Employees ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Employees
                                                 where objLinq.Emp_Id == objUpdate.Emp_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                 select objLinq).FirstOrDefault();


                    ObjForUpdate.Emp_Code = objUpdate.Emp_Code;
                    ObjForUpdate.Emp_First_Name = objUpdate.Emp_First_Name;
                    ObjForUpdate.Emp_Meduim_Name = objUpdate.Emp_Meduim_Name;
                    ObjForUpdate.Emp_Last_Name = objUpdate.Emp_Last_Name;
                    ObjForUpdate.Emp_First_NameEn = objUpdate.Emp_First_NameEn;
                    ObjForUpdate.Emp_Meduim_NameEn = objUpdate.Emp_Meduim_NameEn;
                    ObjForUpdate.Emp_Last_NameEn = objUpdate.Emp_Last_NameEn;
                    ObjForUpdate.Emp_Last_NameConv = objUpdate.Emp_Last_NameConv;
                    ObjForUpdate.Birth_Date = objUpdate.Birth_Date;
                    ObjForUpdate.WorkStartingDate = objUpdate.WorkStartingDate;
                    ObjForUpdate.Birth_Place = objUpdate.Birth_Place;
                    ObjForUpdate.Hire_Date = objUpdate.Hire_Date;
                    ObjForUpdate.Social_Status_Id = objUpdate.Social_Status_Id;
                    ObjForUpdate.Military_Status_Id = objUpdate.Military_Status_Id;
                    ObjForUpdate.Geneder_Id = objUpdate.Geneder_Id;
                    ObjForUpdate.Religion_Id = objUpdate.Religion_Id;
                    ObjForUpdate.Countery_Id = objUpdate.Countery_Id;
                    ObjForUpdate.City_Id = objUpdate.City_Id;
                    ObjForUpdate.Nationality_Id = objUpdate.Nationality_Id;
                    ObjForUpdate.Project_Id = objUpdate.Project_Id;
                    ObjForUpdate.Contract_Id = objUpdate.Contract_Id;
                    ObjForUpdate.Admin_Id = objUpdate.Admin_Id;
                    ObjForUpdate.Dept_Id = objUpdate.Dept_Id;
                    ObjForUpdate.Job_Id = objUpdate.Job_Id;
                    ObjForUpdate.JobTitle = objUpdate.JobTitle;
                    ObjForUpdate.Grade_Id = objUpdate.Grade_Id;
                    ObjForUpdate.Qualify_Type_Id = "1";
                    ObjForUpdate.Qualify_Id = "1";
                    ObjForUpdate.Shift_Id = objUpdate.Shift_Id;
                    ObjForUpdate.Identity_Type_Id = objUpdate.Identity_Type_Id;
                    ObjForUpdate.Identity_No = objUpdate.Identity_No;
                    ObjForUpdate.Identity_StartDate = objUpdate.Identity_StartDate;
                    ObjForUpdate.Identity_StartDateHijri = objUpdate.Identity_StartDateHijri;
                    ObjForUpdate.Identity_EndDate = objUpdate.Identity_EndDate;
                    ObjForUpdate.Identity_EndDateHijri = objUpdate.Identity_EndDateHijri;
                    ObjForUpdate.Inside_Phone = objUpdate.Inside_Phone;
                    ObjForUpdate.Inside_Mobile1 = objUpdate.Inside_Mobile1;
                    ObjForUpdate.Inside_Mobile2 = objUpdate.Inside_Mobile2;
                    ObjForUpdate.Outside_Phone1 = objUpdate.Outside_Phone1;
                    ObjForUpdate.Outside_Mobile1 = objUpdate.Outside_Mobile1;
                    ObjForUpdate.Outside_Mobile2 = objUpdate.Outside_Mobile2;
                    ObjForUpdate.Fax = objUpdate.Fax;
                    ObjForUpdate.InsideAddress1 = objUpdate.InsideAddress1;
                    ObjForUpdate.InsideAddress2 = objUpdate.InsideAddress2;
                    ObjForUpdate.OutsideAddress1 = objUpdate.OutsideAddress1;
                    ObjForUpdate.OutsideAddress2 = objUpdate.OutsideAddress2;
                    ObjForUpdate.BusinessEmail = objUpdate.BusinessEmail;
                    ObjForUpdate.PrivateEmail = objUpdate.PrivateEmail;
                    ObjForUpdate.Manager_Id = objUpdate.Manager_Id;
                    ObjForUpdate.Bank_No1 = objUpdate.Bank_No1;
                    ObjForUpdate.AccountBankNo1 = objUpdate.AccountBankNo1;
                    ObjForUpdate.IBAN_No1 = objUpdate.IBAN_No1;
                    ObjForUpdate.Bank_No2 = objUpdate.Bank_No2;
                    ObjForUpdate.AccountBankNo2 = objUpdate.AccountBankNo2;
                    ObjForUpdate.IBAN_No2 = objUpdate.IBAN_No2;
                    ObjForUpdate.HasFingerPrint = objUpdate.HasFingerPrint;
                    ObjForUpdate.HasAbsence = objUpdate.HasAbsence;
                    ObjForUpdate.HasOverTime = objUpdate.HasOverTime;
                    ObjForUpdate.HasDelay = objUpdate.HasDelay;
                    ObjForUpdate.HasPermission = objUpdate.HasPermission;
                    ObjForUpdate.HasMedicalInsurance = objUpdate.HasMedicalInsurance;
                    ObjForUpdate.Medical_Insurance_No = objUpdate.Medical_Insurance_No;
                    ObjForUpdate.Medical_Insurance_StartDate = objUpdate.Medical_Insurance_StartDate;
                    ObjForUpdate.Medical_Insurance_StartDateHijri = objUpdate.Medical_Insurance_StartDateHijri;
                    ObjForUpdate.Medical_Insurance_EndDate = objUpdate.Medical_Insurance_EndDate;
                    ObjForUpdate.Medical_Insurance_EndDateHijri = objUpdate.Medical_Insurance_EndDateHijri;
                    ObjForUpdate.Notes = objUpdate.Notes;
                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = objUpdate.UpdateDate;
                    ObjForUpdate.Prefix = objUpdate.Prefix;
                    ObjForUpdate.ImagePath = objUpdate.ImagePath;
                    ObjForUpdate.FullNameArabic = objUpdate.FullNameArabic;
                    ObjForUpdate.FullNameEn = objUpdate.FullNameEn;
                    ObjForUpdate.Social_Insurance_No = objUpdate.Social_Insurance_No;
                    ObjForUpdate.PassportNo = objUpdate.PassportNo;
                    ObjForUpdate.PassportIssueDate = objUpdate.PassportIssueDate;
                    ObjForUpdate.PassportExpiryDate = objUpdate.PassportExpiryDate;

                    ObjForUpdate.IsCommissioner = objUpdate.IsCommissioner;
                    ObjForUpdate.Commissioner_Serial_no = objUpdate.Commissioner_Serial_no;
                    ObjForUpdate.NeedMandate = objUpdate.NeedMandate;
                    ObjForUpdate.EmpHdrId = objUpdate.EmpHdrId;
                    ObjForUpdate.EmpStatusId = objUpdate.EmpStatusId;
                    ObjForUpdate.HasManager = objUpdate.HasManager;
                    ObjForUpdate.ContractClassify = objUpdate.ContractClassify;
                    ObjForUpdate.GradeJob_Id = objUpdate.GradeJob_Id;
                    ObjForUpdate.IsEmpManager = objUpdate.IsEmpManager;
                    ObjForUpdate.Manager_Id = objUpdate.Manager_Id;

                    ObjForUpdate.StartContract = objUpdate.StartContract;
                    ObjForUpdate.EndContract = objUpdate.EndContract;
                    ObjForUpdate.ContractPeriodByMonth = objUpdate.ContractPeriodByMonth;

                    ObjForUpdate.ContractPeriodByMonth = objUpdate.ContractPeriodByMonth;






                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;


                    rowEffected = await objPharmaEntities.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                         this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }
        public bool UpdateTask(Hr_Employees objUpdate)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            // bool task = Update(objInsert).Result;
            //return task;
            int rowEffected = 0;
            try
            {

                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Employees ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Employees
                                                 where objLinq.Emp_Id == objUpdate.Emp_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                 select objLinq).FirstOrDefault();


                    ObjForUpdate.Emp_Code = objUpdate.Emp_Code;
                    ObjForUpdate.Emp_First_Name = objUpdate.Emp_First_Name;
                    ObjForUpdate.Emp_Meduim_Name = objUpdate.Emp_Meduim_Name;
                    ObjForUpdate.Emp_Last_Name = objUpdate.Emp_Last_Name;
                    ObjForUpdate.Emp_First_NameEn = objUpdate.Emp_First_NameEn;
                    ObjForUpdate.Emp_Meduim_NameEn = objUpdate.Emp_Meduim_NameEn;
                    ObjForUpdate.Emp_Last_NameEn = objUpdate.Emp_Last_NameEn;

                    ObjForUpdate.Emp_GrandFatherName = objUpdate.Emp_GrandFatherName;
                    ObjForUpdate.Emp_GrandFatherNameEn = objUpdate.Emp_GrandFatherNameEn;

                    ObjForUpdate.Emp_Last_NameConv = objUpdate.Emp_Last_NameConv;
                    ObjForUpdate.Birth_Date = objUpdate.Birth_Date;
                    ObjForUpdate.WorkStartingDate = objUpdate.WorkStartingDate;
                    ObjForUpdate.Birth_Place = objUpdate.Birth_Place;
                    ObjForUpdate.Hire_Date = objUpdate.Hire_Date;
                    ObjForUpdate.Social_Status_Id = objUpdate.Social_Status_Id;
                    ObjForUpdate.Military_Status_Id = objUpdate.Military_Status_Id;
                    ObjForUpdate.Geneder_Id = objUpdate.Geneder_Id;
                    ObjForUpdate.Religion_Id = objUpdate.Religion_Id;
                    ObjForUpdate.Countery_Id = objUpdate.Countery_Id;
                    ObjForUpdate.City_Id = objUpdate.City_Id;
                    ObjForUpdate.Nationality_Id = objUpdate.Nationality_Id;
                    ObjForUpdate.Project_Id = objUpdate.Project_Id;
                    ObjForUpdate.Contract_Id = objUpdate.Contract_Id;
                    ObjForUpdate.Admin_Id = objUpdate.Admin_Id;
                    ObjForUpdate.Dept_Id = objUpdate.Dept_Id;
                    ObjForUpdate.Job_Id = objUpdate.Job_Id;
                    ObjForUpdate.JobTitle = objUpdate.JobTitle;
                    ObjForUpdate.Grade_Id = objUpdate.Grade_Id;
                    ObjForUpdate.Qualify_Type_Id = objUpdate.Qualify_Type_Id;
                    ObjForUpdate.Qualify_Id = objUpdate.Qualify_Id;
                    ObjForUpdate.Shift_Id = objUpdate.Shift_Id;
                    ObjForUpdate.Identity_Type_Id = objUpdate.Identity_Type_Id;
                    ObjForUpdate.Identity_No = objUpdate.Identity_No;
                    ObjForUpdate.Identity_StartDate = objUpdate.Identity_StartDate;
                    ObjForUpdate.Identity_StartDateHijri = objUpdate.Identity_StartDateHijri;
                    ObjForUpdate.Identity_EndDate = objUpdate.Identity_EndDate;
                    ObjForUpdate.Identity_EndDateHijri = objUpdate.Identity_EndDateHijri;
                    ObjForUpdate.Inside_Phone = objUpdate.Inside_Phone;
                    ObjForUpdate.Inside_Mobile1 = objUpdate.Inside_Mobile1;
                    ObjForUpdate.Inside_Mobile2 = objUpdate.Inside_Mobile2;
                    ObjForUpdate.Outside_Phone1 = objUpdate.Outside_Phone1;
                    ObjForUpdate.Outside_Mobile1 = objUpdate.Outside_Mobile1;
                    ObjForUpdate.Outside_Mobile2 = objUpdate.Outside_Mobile2;
                    ObjForUpdate.Fax = objUpdate.Fax;
                    ObjForUpdate.InsideAddress1 = objUpdate.InsideAddress1;
                    ObjForUpdate.InsideAddress2 = objUpdate.InsideAddress2;
                    ObjForUpdate.OutsideAddress1 = objUpdate.OutsideAddress1;
                    ObjForUpdate.OutsideAddress2 = objUpdate.OutsideAddress2; ;
                    ObjForUpdate.BusinessEmail = objUpdate.BusinessEmail;
                    ObjForUpdate.PrivateEmail = objUpdate.PrivateEmail;
                    ObjForUpdate.Manager_Id = objUpdate.Manager_Id;
                    ObjForUpdate.Bank_No1 = objUpdate.Bank_No1;
                    ObjForUpdate.AccountBankNo1 = objUpdate.AccountBankNo1;
                    ObjForUpdate.IBAN_No1 = objUpdate.IBAN_No1;
                    ObjForUpdate.Bank_No2 = objUpdate.Bank_No2;
                    ObjForUpdate.AccountBankNo2 = objUpdate.AccountBankNo2;
                    ObjForUpdate.IBAN_No2 = objUpdate.IBAN_No2;
                    ObjForUpdate.HasFingerPrint = objUpdate.HasFingerPrint;
                    ObjForUpdate.HasAbsence = objUpdate.HasAbsence;
                    ObjForUpdate.HasOverTime = objUpdate.HasOverTime;
                    ObjForUpdate.HasDelay = objUpdate.HasDelay;
                    ObjForUpdate.HasPermission = objUpdate.HasPermission;
                    ObjForUpdate.HasMedicalInsurance = objUpdate.HasMedicalInsurance;
                    ObjForUpdate.Medical_Insurance_No = objUpdate.Medical_Insurance_No;
                    ObjForUpdate.Medical_Insurance_StartDate = objUpdate.Medical_Insurance_StartDate;
                    ObjForUpdate.Medical_Insurance_StartDateHijri = objUpdate.Medical_Insurance_StartDateHijri;
                    ObjForUpdate.Medical_Insurance_EndDate = objUpdate.Medical_Insurance_EndDate;
                    ObjForUpdate.Medical_Insurance_EndDateHijri = objUpdate.Medical_Insurance_EndDateHijri;
                    ObjForUpdate.Notes = objUpdate.Notes;
                    ObjForUpdate.Prefix = objUpdate.Prefix;
                    ObjForUpdate.ImagePath = objUpdate.ImagePath;
                    ObjForUpdate.FullNameArabic = objUpdate.FullNameArabic;
                    ObjForUpdate.FullNameEn = objUpdate.FullNameEn;
                    ObjForUpdate.Social_Insurance_No = objUpdate.Social_Insurance_No;
                    ObjForUpdate.PassportNo = objUpdate.PassportNo;
                    ObjForUpdate.PassportIssueDate = objUpdate.PassportIssueDate;
                    ObjForUpdate.PassportExpiryDate = objUpdate.PassportExpiryDate;
                    ObjForUpdate.IsCommissioner = objUpdate.IsCommissioner;
                    ObjForUpdate.Commissioner_Serial_no = objUpdate.Commissioner_Serial_no;
                    ObjForUpdate.NeedMandate = objUpdate.NeedMandate;
                    ObjForUpdate.EmpHdrId = objUpdate.EmpHdrId;
                    ObjForUpdate.GradeJob_Id = objUpdate.GradeJob_Id;
                    ObjForUpdate.EmpStatusId = objUpdate.EmpStatusId;
                    ObjForUpdate.HasManager = objUpdate.HasManager;
                    ObjForUpdate.ContractClassify = objUpdate.ContractClassify;
                    ObjForUpdate.GradeJob_Id = objUpdate.GradeJob_Id;
                    ObjForUpdate.IsEmpManager = objUpdate.IsEmpManager;
                    ObjForUpdate.Manager_Id = objUpdate.Manager_Id;
                    ObjForUpdate.StartContract = objUpdate.StartContract;
                    ObjForUpdate.EndContract = objUpdate.EndContract;
                    ObjForUpdate.ContractPeriodByMonth = objUpdate.ContractPeriodByMonth;

                    ObjForUpdate.DeductInsurance = objUpdate.DeductInsurance;
                    ObjForUpdate.EnrollFPNumber = objUpdate.EnrollFPNumber;
                    ObjForUpdate.Attendance_Type = objUpdate.Attendance_Type;
                    ObjForUpdate.DeliverSalType = objUpdate.DeliverSalType;
                    ObjForUpdate.ResignationDate = objUpdate.ResignationDate;
                    ObjForUpdate.TestPeriodInMonth = objUpdate.TestPeriodInMonth;
                    ObjForUpdate.EndTestPeriodDate = objUpdate.EndTestPeriodDate;



                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;

                    rowEffected = objPharmaEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;


        }

        public bool UpdateTaskBYContext(Hr_Employees objUpdate, AthelHREntities varContext)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            var strErrorMessage = string.Empty;
            // bool task = Update(objInsert).Result;
            //return task;
            int rowEffected = 0;
            try
            {

                if (objUpdate != null) //Definsive Programming
                {
                    //  OpenEntityConnection();
                    Hr_Employees ObjForUpdate = (from objLinq in varContext.Hr_Employees
                                                 where objLinq.Emp_Id == objUpdate.Emp_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                 select objLinq).FirstOrDefault();

                    if (ObjForUpdate != null)
                    {
                        ObjForUpdate.Emp_Code = objUpdate.Emp_Code;
                        ObjForUpdate.Emp_First_Name = objUpdate.Emp_First_Name;
                        ObjForUpdate.Emp_Meduim_Name = objUpdate.Emp_Meduim_Name;
                        ObjForUpdate.Emp_Last_Name = objUpdate.Emp_Last_Name;
                        ObjForUpdate.Emp_First_NameEn = objUpdate.Emp_First_NameEn;
                        ObjForUpdate.Emp_Meduim_NameEn = objUpdate.Emp_Meduim_NameEn;
                        ObjForUpdate.Emp_Last_NameEn = objUpdate.Emp_Last_NameEn;

                        ObjForUpdate.Emp_GrandFatherName = objUpdate.Emp_GrandFatherName;
                        ObjForUpdate.Emp_GrandFatherNameEn = objUpdate.Emp_GrandFatherNameEn;

                        ObjForUpdate.Emp_Last_NameConv = objUpdate.Emp_Last_NameConv;
                        ObjForUpdate.Birth_Date = objUpdate.Birth_Date;
                        ObjForUpdate.WorkStartingDate = objUpdate.WorkStartingDate;
                        ObjForUpdate.Birth_Place = objUpdate.Birth_Place;
                        ObjForUpdate.Hire_Date = objUpdate.Hire_Date;
                        ObjForUpdate.Social_Status_Id = objUpdate.Social_Status_Id;
                        ObjForUpdate.Military_Status_Id = objUpdate.Military_Status_Id;
                        ObjForUpdate.Geneder_Id = objUpdate.Geneder_Id;
                        ObjForUpdate.Religion_Id = objUpdate.Religion_Id;
                        ObjForUpdate.Countery_Id = objUpdate.Countery_Id;
                        ObjForUpdate.City_Id = objUpdate.City_Id;
                        ObjForUpdate.Nationality_Id = objUpdate.Nationality_Id;
                        ObjForUpdate.Project_Id = objUpdate.Project_Id;
                        ObjForUpdate.Contract_Id = objUpdate.Contract_Id;
                        ObjForUpdate.Admin_Id = objUpdate.Admin_Id;
                        ObjForUpdate.Dept_Id = objUpdate.Dept_Id;
                        ObjForUpdate.Job_Id = objUpdate.Job_Id;
                        ObjForUpdate.JobTitle = objUpdate.JobTitle;
                        ObjForUpdate.Grade_Id = objUpdate.Grade_Id;
                        ObjForUpdate.Qualify_Type_Id = objUpdate.Qualify_Type_Id;
                        ObjForUpdate.Qualify_Id = objUpdate.Qualify_Id;
                        ObjForUpdate.Shift_Id = objUpdate.Shift_Id;
                        ObjForUpdate.Identity_Type_Id = objUpdate.Identity_Type_Id;
                        ObjForUpdate.Identity_No = objUpdate.Identity_No;
                        ObjForUpdate.Identity_StartDate = objUpdate.Identity_StartDate;
                        ObjForUpdate.Identity_StartDateHijri = objUpdate.Identity_StartDateHijri;
                        ObjForUpdate.Identity_EndDate = objUpdate.Identity_EndDate;
                        ObjForUpdate.Identity_EndDateHijri = objUpdate.Identity_EndDateHijri;
                        ObjForUpdate.Inside_Phone = objUpdate.Inside_Phone;
                        ObjForUpdate.Inside_Mobile1 = objUpdate.Inside_Mobile1;
                        ObjForUpdate.Inside_Mobile2 = objUpdate.Inside_Mobile2;
                        ObjForUpdate.Outside_Phone1 = objUpdate.Outside_Phone1;
                        ObjForUpdate.Outside_Mobile1 = objUpdate.Outside_Mobile1;
                        ObjForUpdate.Outside_Mobile2 = objUpdate.Outside_Mobile2;
                        ObjForUpdate.Fax = objUpdate.Fax;
                        ObjForUpdate.InsideAddress1 = objUpdate.InsideAddress1;
                        ObjForUpdate.InsideAddress2 = objUpdate.InsideAddress2;
                        ObjForUpdate.OutsideAddress1 = objUpdate.OutsideAddress1;
                        ObjForUpdate.OutsideAddress2 = objUpdate.OutsideAddress2; ;
                        ObjForUpdate.BusinessEmail = objUpdate.BusinessEmail;
                        ObjForUpdate.PrivateEmail = objUpdate.PrivateEmail;
                        ObjForUpdate.Manager_Id = objUpdate.Manager_Id;
                        ObjForUpdate.Bank_No1 = objUpdate.Bank_No1;
                        ObjForUpdate.AccountBankNo1 = objUpdate.AccountBankNo1;
                        ObjForUpdate.IBAN_No1 = objUpdate.IBAN_No1;
                        ObjForUpdate.Bank_No2 = objUpdate.Bank_No2;
                        ObjForUpdate.AccountBankNo2 = objUpdate.AccountBankNo2;
                        ObjForUpdate.IBAN_No2 = objUpdate.IBAN_No2;
                        ObjForUpdate.HasFingerPrint = objUpdate.HasFingerPrint;
                        ObjForUpdate.HasAbsence = objUpdate.HasAbsence;
                        ObjForUpdate.HasOverTime = objUpdate.HasOverTime;
                        ObjForUpdate.HasDelay = objUpdate.HasDelay;
                        ObjForUpdate.HasPermission = objUpdate.HasPermission;
                        ObjForUpdate.HasMedicalInsurance = objUpdate.HasMedicalInsurance;
                        ObjForUpdate.Medical_Insurance_No = objUpdate.Medical_Insurance_No;
                        ObjForUpdate.Medical_Insurance_StartDate = objUpdate.Medical_Insurance_StartDate;
                        ObjForUpdate.Medical_Insurance_StartDateHijri = objUpdate.Medical_Insurance_StartDateHijri;
                        ObjForUpdate.Medical_Insurance_EndDate = objUpdate.Medical_Insurance_EndDate;
                        ObjForUpdate.Medical_Insurance_EndDateHijri = objUpdate.Medical_Insurance_EndDateHijri;
                        ObjForUpdate.Notes = objUpdate.Notes;
                        ObjForUpdate.Prefix = objUpdate.Prefix;
                        ObjForUpdate.ImagePath = objUpdate.ImagePath;
                        ObjForUpdate.FullNameArabic = objUpdate.FullNameArabic;
                        ObjForUpdate.FullNameEn = objUpdate.FullNameEn;
                        ObjForUpdate.Social_Insurance_No = objUpdate.Social_Insurance_No;
                        ObjForUpdate.PassportNo = objUpdate.PassportNo;
                        ObjForUpdate.PassportIssueDate = objUpdate.PassportIssueDate;
                        ObjForUpdate.PassportExpiryDate = objUpdate.PassportExpiryDate;
                        ObjForUpdate.IsCommissioner = objUpdate.IsCommissioner;
                        ObjForUpdate.Commissioner_Serial_no = objUpdate.Commissioner_Serial_no;
                        ObjForUpdate.NeedMandate = objUpdate.NeedMandate;
                        ObjForUpdate.EmpHdrId = objUpdate.EmpHdrId;
                        ObjForUpdate.GradeJob_Id = objUpdate.GradeJob_Id;
                        ObjForUpdate.EmpStatusId = objUpdate.EmpStatusId;

                        ObjForUpdate.HasManager = objUpdate.HasManager;
                        ObjForUpdate.ContractClassify = objUpdate.ContractClassify;
                        ObjForUpdate.IsEmpManager = objUpdate.IsEmpManager;

                        ObjForUpdate.StartContract = objUpdate.StartContract;
                        ObjForUpdate.EndContract = objUpdate.EndContract;
                        ObjForUpdate.ContractPeriodByMonth = objUpdate.ContractPeriodByMonth;

                        ObjForUpdate.DeductInsurance = objUpdate.DeductInsurance;
                        ObjForUpdate.EnrollFPNumber = objUpdate.EnrollFPNumber;
                        ObjForUpdate.Attendance_Type = objUpdate.Attendance_Type;
                        ObjForUpdate.DeliverSalType = objUpdate.DeliverSalType;
                        ObjForUpdate.ResignationDate = objUpdate.ResignationDate;
                        ObjForUpdate.TestPeriodInMonth = objUpdate.TestPeriodInMonth;
                        ObjForUpdate.EndTestPeriodDate = objUpdate.EndTestPeriodDate;





                        ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                        ObjForUpdate.UpdateDate = DateTime.Now;

                        rowEffected = varContext.SaveChanges();
                    }
                    else
                    {
                        rowEffected = -1;
                    }
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                // CloseEntityConnection();
                if (!string.IsNullOrEmpty(strErrorMessage))
                {
                    SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                }
            }
            if (rowEffected > 0)
                return true;
            else
                return false;


        }

        public async Task<bool> Delete(Hr_Employees objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Employees objForDelete = (from objLinq in objPharmaEntities.Hr_Employees
                                                 where objLinq.Emp_Id == objDelete.Emp_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
                                                 select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected = await objPharmaEntities.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public bool DeleteTask(Hr_Employees objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            // bool task = Delete(objInsert).Result;
            // return task;
            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Employees objForDelete = (from objLinq in objPharmaEntities.Hr_Employees
                                                 where objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id && objLinq.Emp_Serial_No == objDelete.Emp_Serial_No && objLinq.EmpHdrId == objDelete.EmpHdrId
                                                 select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected = objPharmaEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public bool DeleteTaskByContext(Hr_Employees objDelete, AthelHREntities varContext)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            string strErrorMessage = string.Empty;
            // bool task = Delete(objInsert).Result;
            // return task;
            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    // OpenEntityConnection();
                    Hr_Employees objForDelete = (from objLinq in varContext.Hr_Employees
                                                 where objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id && objLinq.Emp_Serial_No == objDelete.Emp_Serial_No && objLinq.EmpHdrId == objDelete.EmpHdrId
                                                 select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.EmpStatusId = "6";
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected = varContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                // CloseEntityConnection();
                if (!string.IsNullOrEmpty(strErrorMessage))
                {
                    SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                }

            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public Hr_Employees GetById(string strEmp_ID, string strCompanyId, string strBranchId)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                Hr_Employees JobsForGetEntity = (from objLinq in objPharmaEntities.Hr_Employees
                                                 where objLinq.Emp_Id == strEmp_ID && objLinq.Company_Id == strCompanyId && objLinq.Branch_Id == strBranchId && objLinq.Rec_Status == 0
                                                 select objLinq).FirstOrDefault();
                return JobsForGetEntity;
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
        public List<Hr_Employees> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_Employees> objectList = (from objLinq in objPharmaEntities.Hr_Employees
                                                 where objLinq.Rec_Status == 0
                                                 && objLinq.Company_Id == objLinq.Company_Id && objLinq.Branch_Id == objLinq.Branch_Id
                                                 select objLinq).ToList();
                return objectList;

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

        public string GetNewId(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Employees_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Employees_SelectMaxId()
                //         select anything.Job_Id).Single();
                //foreach (Hr_Employees cs in objPharmaEntities.Hr_Employees)
                //    maxId = cs.Job_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 Emp_Id as Emp_Id  from Hr_Employees where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(Emp_Id))+Emp_Id desc";
                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
                if (maxId != null)
                {
                    nextId = maxId.ToString();

                }
            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            return nextId;
        }

        public string GetImageUser(decimal empSerialNo, string strCompany, string strBranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string strImageName = string.Empty;

            OpenEntityConnection();
            string strsql;
            strsql = "select ImagePath  from Hr_Employees where Branch_Id=" + strBranch + " and Company_Id=" + strCompany + " and Emp_Serial_No = " + empSerialNo + " ";
            strImageName = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();


            return strImageName;
        }

        public bool ChekUserIsCommissioner(decimal empSerialNo, string strCompany, string strBranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            bool result = false;
            byte resultData;

            OpenEntityConnection();
            string strsql;
            strsql = "select IsCommissioner  from Hr_Employees where Branch_Id=" + strBranch + " and Company_Id=" + strCompany + " and Emp_Serial_No = " + empSerialNo + " ";
            resultData = objPharmaEntities.Database.SqlQuery<byte>(strsql).FirstOrDefault<byte>();

            result = (resultData == 1);

            return result;
        }

        public Guid? GetEmpHdrId(string strcomapny, string strbranch, decimal strEmpSerialNo)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();


                Guid varEmpHdrId = objPharmaEntities.Database.SqlQuery<Guid>("select EmpHdrId from Hr_Employees where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "' and Emp_Serial_No='" + strEmpSerialNo + "'").FirstOrDefault();

                return varEmpHdrId;

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




        public string ChkJobIdIsIdentity(string jobId, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                OpenEntityConnection();
                object[] param1 = {
                new SqlParameter("@jobId", jobId),
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id)};

                var result = objPharmaEntities.Database.SqlQuery<string>("exec dbo._SPchkJobIdIsIdentity @jobId,@Company_Id,@Branch_Id", param1).FirstOrDefault<string>();

                result = ((result == null || result == "") ? "0" : result);

                return result;

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return "0";

            }
            finally
            {
                CloseEntityConnection();
            }


        }



        public string ChkEmpCodeIsIdentity(string StrEmpCode, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                OpenEntityConnection();
                object[] param1 = {

                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@EmpCode", StrEmpCode)};

                string strsql = "select FullNameEn from Hr_Employees where Company_Id=@Company_Id and Branch_Id=@Branch_Id and Emp_Code=@EmpCode";

                var result = objPharmaEntities.Database.SqlQuery<string>(strsql, param1).FirstOrDefault<string>();

                result = ((result == null || result == "") ? "0" : result);

                return result;

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return "0";

            }
            finally
            {
                CloseEntityConnection();
            }


        }

        public string ChkEmailIsIdentity(string StrEmail, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                OpenEntityConnection();
                object[] param1 = {

                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@BusinessEmail", StrEmail)};

                string strsql = "select Emp_Code from Hr_Employees where Company_Id=@Company_Id and Branch_Id=@Branch_Id and BusinessEmail=@BusinessEmail";

                var result = objPharmaEntities.Database.SqlQuery<string>(strsql, param1).FirstOrDefault<string>();

                result = ((result == null || result == "") ? "0" : result);

                return result;

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return "0";

            }
            finally
            {
                CloseEntityConnection();
            }


        }

        public string ChkEmployeeWithUserIsIdentity(decimal StrSerialNo, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                OpenEntityConnection();
                object[] param1 = {

                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@EmpSerialNo", StrSerialNo)};

                string strsql = "select UserName from AspNetUsers where Company_Id=@Company_Id and Branch_Id=@Branch_Id and Emp_Serial_No=@EmpSerialNo";

                var result = objPharmaEntities.Database.SqlQuery<string>(strsql, param1).FirstOrDefault<string>();

                result = ((result == null || result == "") ? "0" : result);

                return result;

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return "0";

            }
            finally
            {
                CloseEntityConnection();
            }


        }

        public string ChkUserNameIsIdentity(string StrUserName, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                OpenEntityConnection();
                object[] param1 = {

                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@UserName", StrUserName)};

                string strsql = "select UserName from AspNetUsers where Company_Id=@Company_Id and Branch_Id=@Branch_Id and UserName=@UserName";

                var result = objPharmaEntities.Database.SqlQuery<string>(strsql, param1).FirstOrDefault<string>();

                result = ((result == null || result == "") ? "0" : result);

                return result;

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return "0";

            }
            finally
            {
                CloseEntityConnection();
            }


        }


        public EmployeeUserDL GetEmployeeUserData(string strcomapny, string strbranch, decimal strEmpSerialNo)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                //Hr_Employees objectlist = (from objlinq in objPharmaEntities.Hr_Employees
                //                                 where objlinq.Rec_Status == 0
                //                                 && objlinq.Company_Id == strcomapny && objlinq.Branch_Id == strbranch
                //                                 && ((objlinq.Emp_Serial_No == strEmpSerialNo))
                //                                 select objlinq).FirstOrDefault();
                string strsql;
                strsql = "Select Branch_Id,Company_Id,Emp_First_Name,Emp_Last_Name,Emp_First_NameEn,Emp_Last_NameEn,BusinessEmail,JobTitle,Inside_Mobile1";
                strsql = strsql + ",Project_Id,Admin_Id,Dept_Id,Job_Id,StartContract,EndContract,WorkStartingDate";
                strsql = strsql + " from  Hr_Employees where Branch_Id='" + strbranch + "' and Company_Id='" + strcomapny + "' and Emp_Serial_No =" + strEmpSerialNo + "";

                EmployeeUserDL objectlist = objPharmaEntities.Database.SqlQuery<EmployeeUserDL>(strsql).FirstOrDefault();

                if (objectlist != null)
                {
                    EmployeeUserDL ObjEmployeeUserDL = new EmployeeUserDL();
                    ObjEmployeeUserDL.Branch_Id = objectlist.Branch_Id;
                    ObjEmployeeUserDL.Company_Id = objectlist.Company_Id;
                    ObjEmployeeUserDL.Emp_First_Name = objectlist.Emp_First_Name;
                    ObjEmployeeUserDL.Emp_Last_Name = objectlist.Emp_Last_Name;
                    ObjEmployeeUserDL.Emp_First_NameEn = objectlist.Emp_First_NameEn;
                    ObjEmployeeUserDL.Emp_Last_NameEn = objectlist.Emp_Last_NameEn;
                    ObjEmployeeUserDL.BusinessEmail = objectlist.BusinessEmail;
                    ObjEmployeeUserDL.JobTitle = objectlist.JobTitle;
                    ObjEmployeeUserDL.Inside_Mobile1 = objectlist.Inside_Mobile1;

                    ObjEmployeeUserDL.Project_Id = objectlist.Project_Id;
                    ObjEmployeeUserDL.Admin_Id = objectlist.Admin_Id;
                    ObjEmployeeUserDL.Dept_Id = objectlist.Dept_Id;
                    ObjEmployeeUserDL.Job_Id = objectlist.Job_Id;

                    ObjEmployeeUserDL.StartContract = objectlist.StartContract;
                    ObjEmployeeUserDL.EndContract = objectlist.EndContract;
                    ObjEmployeeUserDL.WorkStartingDate = objectlist.WorkStartingDate;


                    return ObjEmployeeUserDL;
                }
                else
                    return null;




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


        public string GetJob_Id(string Company_Id, string Branch_Id, decimal Emp_Serial_No)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                string result = String.Empty;
                OpenEntityConnection();
                //object[] param1 = {

                //new SqlParameter("@Company_Id",Company_Id),
                //new SqlParameter("@Branch_Id", Branch_Id),
                //new SqlParameter("@UserName", Emp_Serial_No)};

                string strsql = "select Job_Id from  Hr_Employees where Branch_Id='" + Branch_Id + "' and Company_Id='" + Company_Id + "' and Emp_Serial_No =" + Emp_Serial_No + "";

                var obj = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault();

                result = obj.ToString();

                return result;

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return string.Empty;

            }
            finally
            {
                CloseEntityConnection();
            }


        }


        public int GetOpenChkJob(string Company_Id, string Branch_Id, decimal Emp_Serial_No)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                int result = 0;
                OpenEntityConnection();
                //object[] param1 = {

                //new SqlParameter("@Company_Id",Company_Id),
                //new SqlParameter("@Branch_Id", Branch_Id),
                //new SqlParameter("@UserName", Emp_Serial_No)};

                string strsql = "select  [dbo].[FnGetChkJobForSecondent] ('" + Company_Id + "','" + Branch_Id + "','" + Emp_Serial_No + "')";

                var obj = objPharmaEntities.Database.SqlQuery<byte>(strsql).FirstOrDefault();



                result = ((obj == null) ? 0 : Convert.ToInt16(obj));

                return result;

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return 0;

            }
            finally
            {
                CloseEntityConnection();
            }


        }


        public List<EmpsChartDl> GetEmpsChart()
        {
            List<EmpsChartDl> objectList = new List<EmpsChartDl>();

            string sql = "exec  [dbo].[_SPGetEmpsChart]";
            List<EmpsChartDl> list = objPharmaEntities.Database.SqlQuery<EmpsChartDl>(sql).ToList();
            if (list != null)
            {

                foreach (var obj in list)
                {
                    EmpsChartDl objUserMenuDL = new EmpsChartDl();
                    objUserMenuDL.id = obj.id;
                    objUserMenuDL.ArName = obj.ArName;
                    objUserMenuDL.EnName = obj.EnName;
                    objUserMenuDL.Type = obj.Type;
                    objUserMenuDL.Parent = obj.Parent;
                    objUserMenuDL.parent_type = obj.parent_type;
                    objUserMenuDL.level = obj.level;
                    objUserMenuDL.childCount = obj.childCount;
                    objUserMenuDL.ArJob = obj.ArJob;
                    objUserMenuDL.EnJob = obj.EnJob;
                    objUserMenuDL.Image = obj.Image;
                    objectList.Add(objUserMenuDL);
                }
            }
            return objectList;
        }


        public List<EmpTreeDL> GetEmpTree()
        {
            List<EmpTreeDL> objectList = new List<EmpTreeDL>();

            string sql = "exec  [dbo].[_SPGetEmpTree]";
            List<EmpTreeDL> list = objPharmaEntities.Database.SqlQuery<EmpTreeDL>(sql).ToList();
            if (list != null)
            {

                foreach (var obj in list)
                {
                    EmpTreeDL objUserMenuDL = new EmpTreeDL();
                    objUserMenuDL.id = obj.id;
                    objUserMenuDL.ArName = obj.ArName;
                    objUserMenuDL.EnName = obj.EnName;
                    objUserMenuDL.Type = obj.Type;
                    objUserMenuDL.Parent = obj.Parent;
                    objUserMenuDL.parent_type = obj.parent_type;
                    objUserMenuDL.level = obj.level;
                    objUserMenuDL.childCount = obj.childCount;

                    objectList.Add(objUserMenuDL);
                }
            }
            return objectList;
        }


        public AspNetRoles ChkShowAllEmp(string EmpId)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();

                string sql = "select Id,Name, AppearAllEmp from AspNetRoles where AspNetRoles.Id=(select RoleId from AspNetUserRoles where AspNetUserRoles.UserId='" + EmpId + "')";



                AspNetRoles obj = objPharmaEntities.Database.SqlQuery<AspNetRoles>(sql).FirstOrDefault();
                return obj;


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

        public string GetLogo()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();



            try
            {
                OpenEntityConnection();

                var path = new AthelHREntities().Database.SqlQuery<string>("select Small_Logo_Path from Hr_Companies ").FirstOrDefault();

                return path;

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

        public string GetImagePath(string strcomapny)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();



            try
            {
                OpenEntityConnection();

                object[] param1 = {
                new SqlParameter("@selCompany_Id",strcomapny),
             };
                string objlist = objPharmaEntities.Database.SqlQuery<string>("select Small_Logo_Path From Hr_Companies where Company_Id = @selCompany_Id", param1).FirstOrDefault<string>();


                return objlist;
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


        public List<EmployeesNewDL> FillEmployeeBySerialAndRoleinList(string Company_Id, string Branch_Id, decimal EmpSerialNo)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<EmployeesNewDL> objectList = new List<EmployeesNewDL>(); ;
            try
            {

                OpenEntityConnection();


                object[] param1 = {
               new SqlParameter("@Company_Id",Company_Id),
               new SqlParameter("@Branch_Id", Branch_Id),
                 new SqlParameter("@EmpSerialNo", EmpSerialNo)};

                var objlist = objPharmaEntities.Database.SqlQuery<EmployeesNewDL>("exec dbo._SpFillEmployeeBySerialAndRoleInList @Company_Id,@Branch_Id,@EmpSerialNo", param1).ToList();

                if (objlist != null)
                {
                    foreach (var obj in objlist)
                    {
                        EmployeesNewDL objCombDL = new EmployeesNewDL();
                        objCombDL.Emp_Serial_No = obj.Emp_Serial_No;
                        objCombDL.Emp_Code = obj.Emp_Code;
                        objCombDL.FullNameArabic = obj.FullNameArabic;
                        objCombDL.FullNameEn = obj.FullNameEn;
                        objCombDL.Countery_Id = obj.Countery_Id;
                        objCombDL.City_Id = obj.City_Id;
                        objCombDL.Dept_Name = obj.Dept_Name;
                        objCombDL.Dept_NameEn = obj.Dept_NameEn;
                        objCombDL.JobTitle = obj.JobTitle;
                        objCombDL.StartContract = obj.StartContract;
                        objCombDL.EndContract = obj.EndContract;
                        objCombDL.Hire_Date = obj.Hire_Date;
                        objCombDL.EmpStatusId = obj.EmpStatusId;

                        objectList.Add(objCombDL);

                    }
                }


            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                         this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                objectList = null;
                throw ex;

            }
            finally
            {
                CloseEntityConnection();
            }

            return objectList;
        }

    }
}