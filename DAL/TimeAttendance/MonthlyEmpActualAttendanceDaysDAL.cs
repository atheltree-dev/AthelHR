using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.TimeAttendance;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DAL.TimeAttendance
{
    public class MonthlyEmpActualAttendanceDaysDAL : CommonDB

    {



        //public List<GetDetailsShiftAfterCalcDL> GetDetailsShiftAfterCalc(string Company_Id, string Branch_Id, string EmpCheckIn, string EmpCheckOut, string shiftId)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {


        //        OpenEntityConnection();


        //        List<GetDetailsShiftAfterCalcDL> objectList = new List<GetDetailsShiftAfterCalcDL>();

        //        object[] param1 = { 
        //        new SqlParameter("@Company_Id",Company_Id),
        //        new SqlParameter("@Branch_Id", Branch_Id),
        //        new SqlParameter("@EmpCheckIn", EmpCheckIn),
        //        new SqlParameter("@EmpCheckOut", EmpCheckOut),
        //        new SqlParameter("@shiftIdPara", shiftId)};

        //        var objlist = objPharmaEntities.Database.SqlQuery<GetDetailsShiftAfterCalcDL>("exec dbo._CalcNewShiftDetails @Company_Id,@Branch_Id,@EmpCheckIn,@EmpCheckOut,@shiftIdPara", param1).ToList();

        //        foreach (var obj in objlist)
        //        {
        //            GetDetailsShiftAfterCalcDL objEmpAttendanceDL = new GetDetailsShiftAfterCalcDL();
                      
        //                objEmpAttendanceDL.Shift_Id =obj.Shift_Id;
        //                objEmpAttendanceDL.Shift_FromTime =obj.Shift_FromTime;
        //                objEmpAttendanceDL.Shift_ToTime =obj.Shift_ToTime;
        //                objEmpAttendanceDL.BeforeCheck_In_EffectInMin =obj.BeforeCheck_In_EffectInMin;
        //                objEmpAttendanceDL.AfterCheck_In_EffectInMin =obj.AfterCheck_In_EffectInMin;
        //                objEmpAttendanceDL.BeforeCheck_OUT_EffectInMin =obj.BeforeCheck_OUT_EffectInMin;
        //                objEmpAttendanceDL.AfterCheck__OUT_EffectInMin =obj.AfterCheck__OUT_EffectInMin;
        //                objEmpAttendanceDL.ShortName = obj.ShortName;
        //                objEmpAttendanceDL.WorkingPeriodWithShftInMinute = obj.WorkingPeriodWithShftInMinute;
                    
                        

        //                objectList.Add(objEmpAttendanceDL);

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

        public List<MonthlyEmpActualAttendanceDaysDL> GetMonthlyEmpActualAttendanceDays(decimal Emp_Serial_No, string MonthNo, byte Vacation)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<MonthlyEmpActualAttendanceDaysDL> objectList = new List<MonthlyEmpActualAttendanceDaysDL>();
                object[] param1 = {
                new SqlParameter("@Emp_Serial_No",Emp_Serial_No),
                new SqlParameter("@MonthNo",MonthNo),
                new SqlParameter("@Vacation",Vacation),
                };

                //var objlist = objPharmaEntities.Database.SqlQuery<MonthlyEmpActualAttendanceDaysDL>("exec dbo.Sp_GetMonthlyEmpActualAttendanceDays '201908'").ToList();
                var objlist = objPharmaEntities.Database.SqlQuery<MonthlyEmpActualAttendanceDaysDL>("exec dbo.Sp_GetMonthlyEmpActualAttendanceDays @Emp_Serial_No , @MonthNo , @Vacation ", param1).ToList();

                foreach (var obj in objlist)
                {
                    MonthlyEmpActualAttendanceDaysDL objEmpAttendanceDL = new MonthlyEmpActualAttendanceDaysDL();
                        objEmpAttendanceDL.Internal_serial_Id =obj.Internal_serial_Id;
                        objEmpAttendanceDL.Emp_Serial_No =obj.Emp_Serial_No;
                        objEmpAttendanceDL.FullNameArabic =obj.FullNameArabic;
                        objEmpAttendanceDL.FullNameEn =obj.FullNameEn;;
                        objEmpAttendanceDL.Mont_No =obj.Mont_No;
                        objEmpAttendanceDL.MonthDaysNum =obj.MonthDaysNum;
                        objEmpAttendanceDL.AttendsDaysNum = obj.AttendsDaysNum;
                        objEmpAttendanceDL.AnnualVacDaysNum = obj.AnnualVacDaysNum;
                        objEmpAttendanceDL.CompellingVacDaysNum = obj.CompellingVacDaysNum;
                        objEmpAttendanceDL.SickDasysNum = obj.SickDasysNum;
                        objEmpAttendanceDL.VacDaysNumWithoutSalary = obj.VacDaysNumWithoutSalary;
                        objEmpAttendanceDL.OtherDaysNum = obj.OtherDaysNum;
                        objEmpAttendanceDL.AbsenceDaysNum = obj.AbsenceDaysNum;
                        objEmpAttendanceDL.DaysNumFromStartingContractInThisMonth = obj.DaysNumFromStartingContractInThisMonth;
                        objEmpAttendanceDL.Apporval_Status = obj.Apporval_Status;
                        objEmpAttendanceDL.CalculatedDaysNum = obj.CalculatedDaysNum;
                        objEmpAttendanceDL.OvertimePeriodByHour = obj.OvertimePeriodByHour;
                        objEmpAttendanceDL.DelayPeriodByHour = obj.DelayPeriodByHour;





                    objectList.Add(objEmpAttendanceDL);

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


        public List<MonthlyEmpActualAttendanceDaysDL> GetMonthlyEmpActualAttendanceDays( )
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<MonthlyEmpActualAttendanceDaysDL> objectList = new List<MonthlyEmpActualAttendanceDaysDL>();
               

                var objlist = objPharmaEntities.Database.SqlQuery<MonthlyEmpActualAttendanceDaysDL>("exec dbo.Sp_GetMonthlyEmpActualAttendanceDaysByMonth ").ToList();

                foreach (var obj in objlist)
                {
                    MonthlyEmpActualAttendanceDaysDL objEmpAttendanceDL = new MonthlyEmpActualAttendanceDaysDL();
                    objEmpAttendanceDL.Internal_serial_Id = obj.Internal_serial_Id;
                    objEmpAttendanceDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpAttendanceDL.FullNameArabic = obj.FullNameArabic;
                    objEmpAttendanceDL.FullNameEn = obj.FullNameEn; ;
                    objEmpAttendanceDL.Mont_No = obj.Mont_No;
                    objEmpAttendanceDL.MonthDaysNum = obj.MonthDaysNum;
                    objEmpAttendanceDL.AttendsDaysNum = obj.AttendsDaysNum;
                    objEmpAttendanceDL.AnnualVacDaysNum = obj.AnnualVacDaysNum;
                    objEmpAttendanceDL.CompellingVacDaysNum = obj.CompellingVacDaysNum;
                    objEmpAttendanceDL.SickDasysNum = obj.SickDasysNum;
                    objEmpAttendanceDL.VacDaysNumWithoutSalary = obj.VacDaysNumWithoutSalary;
                    objEmpAttendanceDL.OtherDaysNum = obj.OtherDaysNum;
                    objEmpAttendanceDL.AbsenceDaysNum = obj.AbsenceDaysNum;
                    objEmpAttendanceDL.DaysNumFromStartingContractInThisMonth = obj.DaysNumFromStartingContractInThisMonth;
                    objEmpAttendanceDL.Apporval_Status = obj.Apporval_Status;
                    objEmpAttendanceDL.OvertimePeriodByHour = obj.OvertimePeriodByHour;
                    objEmpAttendanceDL.DelayPeriodByHour = obj.DelayPeriodByHour;




                    objectList.Add(objEmpAttendanceDL);

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


        public bool SaveData(List<Hr_MonthlyEmpActualAttendanceDays> ListDtls)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            bool Result;

            try
            {
                OpenEntityConnection();


                Result = false;


                foreach (Hr_MonthlyEmpActualAttendanceDays Obj_Dtls in ListDtls)
                {
                    if (Obj_Dtls != null)
                    {



                        Hr_MonthlyEmpActualAttendanceDays loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_MonthlyEmpActualAttendanceDays
                                                                            where objLinq.Internal_serial_Id == Obj_Dtls.Internal_serial_Id && objLinq.Emp_Serial_No == Obj_Dtls.Emp_Serial_No
                                                                            select objLinq).FirstOrDefault();
                        if (loclDtlsUpdate != null)
                        {
                             
                                loclDtlsUpdate.Apporval_Status = Obj_Dtls.Apporval_Status;

                               
                                objPharmaEntities.SaveChanges();
                            // Result = (objPharmaEntities.SaveChanges() > 0);
                            Result = true;
                         
                        }



                    }

                }
                return Result;




            }
            catch (Exception ex)
            {
                Result = false;
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
