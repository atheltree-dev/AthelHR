using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.Payroll.Definition;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Payroll.Definition
{
    public class EmpAccruedOpenningBalanceDAL : CommonDB

    {
        public class EmpBorrowDetailDL
        {
            public string TransItemDate { get; set; }

            public decimal HireItem_Value { get; set; }
            public string Notes { get; set; }


        }

        public class EmpBorrowStatusDL
        {
            public string ResultStatus { get; set; }

            public string ResultMessage { get; set; }

        }



        public List<EmpAccruedOpenningBalanceDL> SelectEmpData(string Company_Id, string Branch_Id, decimal? EmpSerial_No, string EndDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpAccruedOpenningBalanceDL> objectList = new List<EmpAccruedOpenningBalanceDL>();
                //string temp =(Convert.ToDateTime(EndDate)).ToString("dd/MM/yyyy");
               // string EndDateFormatted = (Convert.ToDateTime(EndDate)).ToString("yyyyMMdd");
                object[] param1 = {

                new SqlParameter("@Company_Id", Company_Id ),
                new SqlParameter("@Branch_Id", Branch_Id ),
                new SqlParameter("@Emp_Serial_No", EmpSerial_No ),
                new SqlParameter("@EndDate", EndDate )


             };

                var objlist = objPharmaEntities.Database.SqlQuery<EmpAccruedOpenningBalanceDL>("exec dbo._getEmpAccruedOpenningBalanceHdr @Company_Id,@Branch_Id, @Emp_Serial_No,@EndDate", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpAccruedOpenningBalanceDL EmpAccruedOpenningBalanceDL = new EmpAccruedOpenningBalanceDL();
                    EmpAccruedOpenningBalanceDL.Company_Id = obj.Company_Id;
                    EmpAccruedOpenningBalanceDL.Branch_Id = obj.Branch_Id;
                    EmpAccruedOpenningBalanceDL.Emp_Serial_No = obj.Emp_Serial_No;
                    EmpAccruedOpenningBalanceDL.FullNameArabic = obj.FullNameArabic;
                    EmpAccruedOpenningBalanceDL.FullNameEn = obj.FullNameEn;
                    EmpAccruedOpenningBalanceDL.Emp_Code = obj.Emp_Code;
                    EmpAccruedOpenningBalanceDL.Hire_Date = obj.Hire_Date;
                    EmpAccruedOpenningBalanceDL.StartContract = obj.StartContract;
                    EmpAccruedOpenningBalanceDL.EndContract = obj.EndContract;
                    EmpAccruedOpenningBalanceDL.WorkStartingDate = obj.WorkStartingDate;
                    EmpAccruedOpenningBalanceDL.TotalWorkingDaysTillNow = obj.TotalWorkingDaysTillNow;
                    EmpAccruedOpenningBalanceDL.NoDaysFromStartCntrctTillDate = obj.NoDaysFromStartCntrctTillDate;
                    EmpAccruedOpenningBalanceDL.Month_No = obj.Month_No;
                    objectList.Add(EmpAccruedOpenningBalanceDL);

                }



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

        public List<EmpAccruedOpenningBalanceDetailsDL> GetEmpDetail(string Company_Id, string Branch_Id, decimal EmpSerial_No, string EndDate, string ToEndPeriod, decimal TotalWorkingDaysTillNow, decimal NoDaysFromStartCntrctTillDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpAccruedOpenningBalanceDetailsDL> objectList = new List<EmpAccruedOpenningBalanceDetailsDL>();
              //  object EndDateFormatted= (Convert.ToDateTime(EndDate)).ToString("yyyyMMdd");
                object[] param1 = {

                new SqlParameter("@Company_Id", Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@EmpSerial_No", EmpSerial_No),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@ToEndPeriod", ToEndPeriod),
                new SqlParameter("@TotalWorkingDaysTillNow", TotalWorkingDaysTillNow),
                new SqlParameter("@NoDaysFromStartCntrctTillDate", NoDaysFromStartCntrctTillDate),


             };

                var objlist = objPharmaEntities.Database.SqlQuery<EmpAccruedOpenningBalanceDetailsDL>("exec dbo._getEmpAccruedOpenningBalanceDtls @Company_Id,@Branch_Id,@EmpSerial_No,@EndDate,@ToEndPeriod,@TotalWorkingDaysTillNow,@NoDaysFromStartCntrctTillDate", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpAccruedOpenningBalanceDetailsDL EmpAccruedOpenningBalanceDetailsDL = new EmpAccruedOpenningBalanceDetailsDL();
                    EmpAccruedOpenningBalanceDetailsDL.Company_Id = obj.Company_Id;
                    EmpAccruedOpenningBalanceDetailsDL.Branch_Id = obj.Branch_Id;
                    EmpAccruedOpenningBalanceDetailsDL.Emp_Serial_No = obj.Emp_Serial_No;
                    EmpAccruedOpenningBalanceDetailsDL.HireItemId = obj.HireItemId;
                    EmpAccruedOpenningBalanceDetailsDL.HireItem_Name = obj.HireItem_Name;
                    EmpAccruedOpenningBalanceDetailsDL.HireItem_NameEn = obj.HireItem_NameEn;
                    EmpAccruedOpenningBalanceDetailsDL.FixedMOnthlyPercentagePerEmp = obj.FixedMOnthlyPercentagePerEmp;
                    EmpAccruedOpenningBalanceDetailsDL.SalDailyPkg = obj.SalDailyPkg;
                    EmpAccruedOpenningBalanceDetailsDL.VactionPeriod = obj.VactionPeriod;
                    EmpAccruedOpenningBalanceDetailsDL.TransferedDays = obj.TransferedDays;
                    EmpAccruedOpenningBalanceDetailsDL.TransferedValues = obj.TransferedValues;
                    EmpAccruedOpenningBalanceDetailsDL.AllowedDaysBalTillDate = obj.AllowedDaysBalTillDate;
                    EmpAccruedOpenningBalanceDetailsDL.AllowedBalTillDateValues = obj.AllowedBalTillDateValues;
                    EmpAccruedOpenningBalanceDetailsDL.TotAllowedDaysBalTillDate = obj.TotAllowedDaysBalTillDate;
                    EmpAccruedOpenningBalanceDetailsDL.TotAllowedBalTillDateValues = obj.TotAllowedBalTillDateValues;
                    EmpAccruedOpenningBalanceDetailsDL.PayedDaysBalTillDate = obj.PayedDaysBalTillDate;
                    EmpAccruedOpenningBalanceDetailsDL.PayedBalTillDateValues = obj.PayedBalTillDateValues;
                    EmpAccruedOpenningBalanceDetailsDL.RemainDaysBalTillDate = obj.RemainDaysBalTillDate;
                    EmpAccruedOpenningBalanceDetailsDL.RemainBalTillDateValues = obj.RemainBalTillDateValues;
                    

                    objectList.Add(EmpAccruedOpenningBalanceDetailsDL);

                }



                return objectList;

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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


       

         
        public Guid GetNewId()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

           

            Guid NewHdr;

            try
            {
                OpenEntityConnection();

                NewHdr = objPharmaEntities.Database.SqlQuery<Guid>("select newid() from Hr_EmpAccruedOpenningBalance ").FirstOrDefault<Guid>();
            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                       this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                NewHdr = Guid.NewGuid();
                throw ex;
            }
            finally
            {
                CloseEntityConnection();
            }
            return NewHdr;
        }


       

        public bool SaveData(List<EmpAccruedOpenningBalanceSaveDL> ListVacationDL, List<EmpAccruedOpenningBalanceSaveDL> LisAirTicketDL, List<EmpAccruedOpenningBalanceSaveDL> ListEndOfServiceDL)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

               
                int Result = 0;
               
                foreach (var obj in ListVacationDL)
                {
                   List<Hr_EmpAccruedOpenningBalance>ObjForDelete = (from objLinq in objPharmaEntities.Hr_EmpAccruedOpenningBalance
                                                                 where objLinq.Emp_Serial_no == obj.Emp_Serial_No
                                                                 select objLinq).ToList();
                    if (ObjForDelete != null)
                    {
                        objPharmaEntities.Hr_EmpAccruedOpenningBalance.RemoveRange(ObjForDelete);
                        objPharmaEntities.SaveChanges();
                    }



                    Hr_EmpAccruedOpenningBalance newobj = new Hr_EmpAccruedOpenningBalance();
                        newobj.Rec_Hdr_Id = GetNewId();
                        newobj.Company_Id = obj.Company_Id;
                        newobj.Branch_Id = obj.Branch_Id;
                        newobj.Emp_Serial_no = obj.Emp_Serial_No;
                        newobj.Transdate = obj.Transdate;
                        newobj.MonthNo = obj.MonthNo;
                        newobj.SalDailyPkg = obj.SalDailyPkg;
                        newobj.FixedPercntage = obj.FixedPercntage;
                        newobj.Accrued_HireItem_Id = obj.Accrued_HireItem_Id;
                        newobj.HireItemValueBal = obj.HireItemValueBal;
                        newobj.DaysBal = obj.DaysBal;
                        newobj.HireItemValueTransfer = obj.HireItemValueTransfer;
                        newobj.DaysTransfer = obj.DaysTransfer;
                        newobj.HireItemValuePayed = obj.DaysTransfer;
                        newobj.DaysPayed = obj.DaysTransfer;
                        newobj.HireItemValueRemain = obj.HireItemValueRemain;
                        newobj.DaysRemain = obj.DaysRemain;
                        newobj.IsPosted = 0 ;
                        newobj.Ins_User = UserNameProperty ;
                        newobj.Ins_Date = DateTime.Now ;

                  


                        objPharmaEntities.Hr_EmpAccruedOpenningBalance.Add(newobj);
                    Result = objPharmaEntities.SaveChanges();


                }

                foreach (var obj in LisAirTicketDL)
                {

                    Hr_EmpAccruedOpenningBalance newobj = new Hr_EmpAccruedOpenningBalance();
                    newobj.Rec_Hdr_Id = GetNewId();
                    newobj.Company_Id = obj.Company_Id;
                    newobj.Branch_Id = obj.Branch_Id;
                    newobj.Emp_Serial_no = obj.Emp_Serial_No;
                    newobj.Transdate = obj.Transdate;
                    newobj.MonthNo = obj.MonthNo;
                    newobj.SalDailyPkg = obj.SalDailyPkg;
                    newobj.FixedPercntage = obj.FixedPercntage;
                    newobj.Accrued_HireItem_Id = obj.Accrued_HireItem_Id;
                    newobj.HireItemValueBal = obj.HireItemValueBal;
                    newobj.DaysBal = obj.DaysBal;
                    newobj.HireItemValueTransfer = obj.HireItemValueTransfer;
                    newobj.DaysTransfer = obj.DaysTransfer;
                    newobj.HireItemValuePayed = obj.DaysTransfer;
                    newobj.DaysPayed = obj.DaysTransfer;
                    newobj.HireItemValueRemain = obj.HireItemValueRemain;
                    newobj.DaysRemain = obj.DaysRemain;
                    newobj.IsPosted = 0;
                    newobj.Ins_User = UserNameProperty;
                    newobj.Ins_Date = DateTime.Now;




                    objPharmaEntities.Hr_EmpAccruedOpenningBalance.Add(newobj);
                    Result = objPharmaEntities.SaveChanges();


                }

                foreach (var obj in ListEndOfServiceDL)
                {

                    Hr_EmpAccruedOpenningBalance newobj = new Hr_EmpAccruedOpenningBalance();
                    newobj.Rec_Hdr_Id = GetNewId();
                    newobj.Company_Id = obj.Company_Id;
                    newobj.Branch_Id = obj.Branch_Id;
                    newobj.Emp_Serial_no = obj.Emp_Serial_No;
                    newobj.Transdate = obj.Transdate;
                    newobj.MonthNo = obj.MonthNo;
                    newobj.SalDailyPkg = obj.SalDailyPkg;
                    newobj.FixedPercntage = obj.FixedPercntage;
                    newobj.Accrued_HireItem_Id = obj.Accrued_HireItem_Id;
                    newobj.HireItemValueBal = obj.HireItemValueBal;
                    newobj.DaysBal = obj.DaysBal;
                    newobj.HireItemValueTransfer = obj.HireItemValueTransfer;
                    newobj.DaysTransfer = obj.DaysTransfer;
                    newobj.HireItemValuePayed = obj.DaysTransfer;
                    newobj.DaysPayed = obj.DaysTransfer;
                    newobj.HireItemValueRemain = obj.HireItemValueRemain;
                    newobj.DaysRemain = obj.DaysRemain;
                    newobj.IsPosted = 0;
                    newobj.Ins_User = UserNameProperty;
                    newobj.Ins_Date = DateTime.Now;




                    objPharmaEntities.Hr_EmpAccruedOpenningBalance.Add(newobj);
                    Result = objPharmaEntities.SaveChanges();


                }
                //Result = objPharmaEntities.SaveChanges();

                return (Result > 0);
            }

            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return false;

            }
            finally
            {
                CloseEntityConnection();
            }



        }









    }
}
