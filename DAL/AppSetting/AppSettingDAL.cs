using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.AppSetting;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace DAL.AppSetting
{
    public class AppSettingDAL : CommonDB

    {
        
        public AppSettingDL GetDataByBranchandCompany(string strCompany_Id, string strBranch_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                App_Settings ObjlistAppSetting = (from objLinq in objPharmaEntities.App_Settings
                                             where objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id
                                             select objLinq).FirstOrDefault();

                if (ObjlistAppSetting != null)
                {
                    AppSettingDL objAppSettingDL = new AppSettingDL();

                    {
                        objAppSettingDL.Branch_Id = ObjlistAppSetting.Branch_Id;
                        objAppSettingDL.Company_Id = ObjlistAppSetting.Company_Id;
                        objAppSettingDL.EmpSerialForDocNotify = ObjlistAppSetting.EmpSerialForDocNotify;
                        objAppSettingDL.CalcWithGrade = ObjlistAppSetting.CalcWithGrade;
                        objAppSettingDL.UseTimeInWorkFlowRequest = ObjlistAppSetting.UseTimeInWorkFlowRequest;
                        objAppSettingDL.PerioddayToForwordRequest = ObjlistAppSetting.PerioddayToForwordRequest;
                        objAppSettingDL.PeriodDayToNotifyFinishContract = ObjlistAppSetting.PeriodDayToNotifyFinishContract;

                        objAppSettingDL.PayrollDay = ObjlistAppSetting.PayrollDay;
                        objAppSettingDL.AllowedPeriodForStopRequestEffect = ObjlistAppSetting.AllowedPeriodForStopRequestEffect;

                        objAppSettingDL.WorkingHoursPerDay = ObjlistAppSetting.WorkingHoursPerDay;
                        objAppSettingDL.ApplyPermissionDiscount = ObjlistAppSetting.ApplyPermissionDiscount;

                        objAppSettingDL.VacAllownaceBOrA = "1";
                        objAppSettingDL.chkVacAfterMonth = ObjlistAppSetting.chkVacAfterMonth;
                        objAppSettingDL.chkPaidByLastSal = ObjlistAppSetting.chkPaidByLastSal;
                        objAppSettingDL.chkAbilityTransferVac = ObjlistAppSetting.chkAbilityTransferVac;
                        objAppSettingDL.chkAbilityTrncferToNext = ObjlistAppSetting.chkAbilityTrncferToNext;
                        objAppSettingDL.MaxTrnsferPeriod = ObjlistAppSetting.MaxTrnsferPeriod;

                        objAppSettingDL.VacTransferAllownceSalaryItem = ObjlistAppSetting.VacTransferAllownceSalaryItem;
                        objAppSettingDL.VacAllownceSalaryItem = ObjlistAppSetting.VacAllownceSalaryItem;

                        objAppSettingDL.AbsenceSalaryItem = ObjlistAppSetting.AbsenceSalaryItem;
                        objAppSettingDL.DelySalaryItem = ObjlistAppSetting.DelySalaryItem;
                        objAppSettingDL.ExtraSalaryItem = ObjlistAppSetting.ExtraSalaryItem;
                        objAppSettingDL.VacTicketHireItem_Id = ObjlistAppSetting.VacTicketHireItem_Id;
                        objAppSettingDL.AbsenceCalcWayByDay = ObjlistAppSetting.AbsenceCalcWayByDay;
                        objAppSettingDL.SalPrevDuesDHireItem_Id = ObjlistAppSetting.SalPrevDuesDHireItem_Id;
                        objAppSettingDL.IntegratedWithGL = ObjlistAppSetting.IntegratedWithGL;
                        objAppSettingDL.CalcSalDayRateWay = ObjlistAppSetting.CalcSalDayRateWay;
                        objAppSettingDL.SalDayRate = ObjlistAppSetting.SalDayRate;
                        objAppSettingDL.SalCalcWay = ObjlistAppSetting.SalCalcWay;
                        //objAppSettingDL.CustomerCompany_Code = ObjlistAppSetting.CustomerCompany_Code;
                        objAppSettingDL.MaxallowedTransferdays = ObjlistAppSetting.MaxallowedTransferdays;
                        objAppSettingDL.FlightRservationManEmail = ObjlistAppSetting.FlightRservationManEmail;
                        //objAppSettingDL.PeriodDayToNotifyFinishTesting = ObjlistAppSetting.PeriodDayToNotifyFinishTesting;



                    }
                    return objAppSettingDL;
                }
                else
                {
                    return null;
                }


                

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



        public bool SaveData(AppSettingDL objList)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

              
                int Result = 0 ;
                string emSerialNo = (objList.EmpSerialForDocNotify == null ? 0 : objList.EmpSerialForDocNotify).ToString();
               


                        App_Settings ObjForUpdate = (from objLinq in objPharmaEntities.App_Settings
                                                                   where objLinq.Company_Id == objList.Company_Id && objLinq.Branch_Id == objList.Branch_Id
                                                                   select objLinq).FirstOrDefault();
                if (ObjForUpdate !=null)
                {
                    //bool resultupdate = objPharmaEntities.ChangeTracker.HasChanges();
                    //if (resultupdate)
                    //{
                        ObjForUpdate.EmpSerialForDocNotify = Convert.ToDecimal(emSerialNo);
                        ObjForUpdate.CalcWithGrade = objList.CalcWithGrade;
                        ObjForUpdate.UseTimeInWorkFlowRequest = objList.UseTimeInWorkFlowRequest;
                        ObjForUpdate.PerioddayToForwordRequest = objList.PerioddayToForwordRequest;
                        ObjForUpdate.PeriodDayToNotifyFinishContract = objList.PeriodDayToNotifyFinishContract;
                        ObjForUpdate.PayrollDay = objList.PayrollDay;
                        ObjForUpdate.AllowedPeriodForStopRequestEffect = objList.AllowedPeriodForStopRequestEffect;
                        ObjForUpdate.WorkingHoursPerDay = objList.WorkingHoursPerDay;
                        ObjForUpdate.ApplyPermissionDiscount = objList.ApplyPermissionDiscount;
                        ObjForUpdate.VacAllownaceBOrA = "1";
                        ObjForUpdate.chkVacAfterMonth = objList.chkVacAfterMonth;
                        ObjForUpdate.chkPaidByLastSal = objList.chkPaidByLastSal;
                        ObjForUpdate.chkAbilityTransferVac = objList.chkAbilityTransferVac;
                        ObjForUpdate.chkAbilityTrncferToNext = objList.chkAbilityTrncferToNext;
                        ObjForUpdate.MaxTrnsferPeriod = objList.MaxTrnsferPeriod;

                        ObjForUpdate.VacTransferAllownceSalaryItem = objList.VacTransferAllownceSalaryItem;
                        ObjForUpdate.VacAllownceSalaryItem = objList.VacAllownceSalaryItem;

                        ObjForUpdate.AbsenceSalaryItem = objList.AbsenceSalaryItem;
                        ObjForUpdate.DelySalaryItem = objList.DelySalaryItem;
                        ObjForUpdate.ExtraSalaryItem = objList.ExtraSalaryItem;
                        ObjForUpdate.VacTicketHireItem_Id = objList.VacTicketHireItem_Id;
                        ObjForUpdate.AbsenceCalcWayByDay = objList.AbsenceCalcWayByDay;
                        ObjForUpdate.SalPrevDuesDHireItem_Id = objList.SalPrevDuesDHireItem_Id;
                        ObjForUpdate.IntegratedWithGL = objList.IntegratedWithGL;
                        ObjForUpdate.CalcSalDayRateWay = objList.CalcSalDayRateWay;
                        ObjForUpdate.SalDayRate = objList.SalDayRate;
                        ObjForUpdate.SalCalcWay = objList.SalCalcWay;
                        //ObjForUpdate.CustomerCompany_Code = objList.CustomerCompany_Code;
                        ObjForUpdate.MaxallowedTransferdays = objList.MaxallowedTransferdays;
                        ObjForUpdate.FlightRservationManEmail = objList.FlightRservationManEmail;
                        //ObjForUpdate.PeriodDayToNotifyFinishTesting = objList.PeriodDayToNotifyFinishTesting;


                    Result = objPharmaEntities.SaveChanges();
                        Result = 1;
                        return (Result > 0);
                    //}
                    //else 
                    //{
                    //    return true;
                    //}
                    
                }else
                {
                    App_Settings loclDtls = new App_Settings
                    {
                        Branch_Id = objList.Branch_Id,
                        Company_Id = objList.Company_Id,
                        EmpSerialForDocNotify = Convert.ToDecimal(emSerialNo),
                        CalcWithGrade = objList.CalcWithGrade,
                        UseTimeInWorkFlowRequest = objList.UseTimeInWorkFlowRequest,
                        PerioddayToForwordRequest = objList.PerioddayToForwordRequest,
                        WorkingHoursPerDay = objList.WorkingHoursPerDay,
                        PeriodDayToNotifyFinishContract = objList.PeriodDayToNotifyFinishContract,
                        PayrollDay = objList.PayrollDay,
                        AllowedPeriodForStopRequestEffect = objList.AllowedPeriodForStopRequestEffect,
                        ApplyPermissionDiscount = objList.ApplyPermissionDiscount,
                        VacAllownaceBOrA = objList.VacAllownaceBOrA,
                        chkVacAfterMonth = objList.chkVacAfterMonth,
                        chkPaidByLastSal = objList.chkPaidByLastSal,
                        chkAbilityTransferVac = objList.chkAbilityTransferVac,
                        chkAbilityTrncferToNext = objList.chkAbilityTrncferToNext,
                        MaxTrnsferPeriod = objList.MaxTrnsferPeriod,
                        VacTransferAllownceSalaryItem = objList.VacTransferAllownceSalaryItem,
                        VacAllownceSalaryItem = objList.VacAllownceSalaryItem,

                        AbsenceSalaryItem = objList.AbsenceSalaryItem,
                        DelySalaryItem = objList.DelySalaryItem,
                        ExtraSalaryItem = objList.ExtraSalaryItem,
                        VacTicketHireItem_Id = objList.VacTicketHireItem_Id,
                        AbsenceCalcWayByDay = objList.AbsenceCalcWayByDay,
                        SalPrevDuesDHireItem_Id = objList.SalPrevDuesDHireItem_Id,
                        IntegratedWithGL = objList.IntegratedWithGL,
                        CalcSalDayRateWay = objList.CalcSalDayRateWay,
                        SalDayRate = objList.SalDayRate,
                        SalCalcWay = objList.SalCalcWay,
                        //CustomerCompany_Code = objList.CustomerCompany_Code,
                        MaxallowedTransferdays = objList.MaxallowedTransferdays,
                        FlightRservationManEmail = objList.FlightRservationManEmail,
                        //PeriodDayToNotifyFinishTesting = objList.PeriodDayToNotifyFinishTesting



                    };

                    objPharmaEntities.App_Settings.Add(loclDtls);
                    //saves all above operations within one transaction
                    Result = objPharmaEntities.SaveChanges();
                    return (Result > 0);

                }

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


        public string GetEmployeeForNotifyDoc(string strCompany, string strBranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string resultData = "0";
            decimal result;
            OpenEntityConnection();
            string strsql;
            strsql = "select EmpSerialForDocNotify  from App_Settings where Branch_Id=" + strBranch + " and Company_Id=" + strCompany + " ";
            result = objPharmaEntities.Database.SqlQuery<decimal>(strsql).FirstOrDefault<decimal>();

            resultData = result.ToString();

            return resultData;
        }

        public byte GetCalcWithGrade(string strCompany, string strBranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            byte resultData = 0;
            byte result;
            OpenEntityConnection();
            string strsql;
            strsql = "select CalcWithGrade  from App_Settings where Branch_Id=" + strBranch + " and Company_Id=" + strCompany + " ";
            result = objPharmaEntities.Database.SqlQuery<byte>(strsql).FirstOrDefault<byte>();

            resultData = result;

            return resultData;
        }

        public string GetCustomerCompany_Code(string strCompany, string strBranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string resultData = "0";
            string result;
            OpenEntityConnection();
            string strsql;
            strsql = "select CustomerCompany_Code  from App_Settings where Branch_Id=" + strBranch + " and Company_Id=" + strCompany + " ";
            result = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();

            resultData = result.ToString();

            return resultData;
        }
        //public App_Settings GetMultiCompanies()
        //{
        //    var MultiCompanies = objPharmaEntities.Database.SqlQuery<App_Settings>("select * from App_Settings").FirstOrDefault<App_Settings>();
        //    return MultiCompanies;
        //}

    }
}
