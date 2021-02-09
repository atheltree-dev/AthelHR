using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HrRecords.RecordManagement;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.SqlClient;
using BOL.HrServices.RequestManagement;

namespace DAL.HrRecords.RecordManagement
{
    public class OtherVcationsRecordDAL : CommonDB
    {

        public int InsertTask(Hr_EmpOtherMonthlyValueRecord objInsert)
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


                    objInsert.Rec_Hdr_Id = GetNewHeaderId();
                    objInsert.InsDate = DateTime.Now;//DateTime.Today;

                    objPharmaEntities.Hr_EmpOtherMonthlyValueRecord.Add(objInsert);
                    RowEffected = objPharmaEntities.SaveChanges();
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


        Guid maxId;
        public string GetNewId(string strcompanyId, string strBranch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            //  object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
                //         select anything.Job_Id).Single();
                //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
                //    maxId = cs.Job_Id;

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<Guid>("select newid()").FirstOrDefault<Guid>();

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


        public bool SaveVacationRecordData(List<VcationRecordDL> objList)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                int Result = 0;
                if (objList != null)
                {
                    foreach (var obj in objList)
                    {
                        // data base bind
                        if (obj.RowStatus == 0)
                        {

                        }
                         //Add
                        else if (obj.RowStatus == 1)
                        {

                            Hr_EmpVactionRecord newobj = new Hr_EmpVactionRecord();
                            newobj.Rec_Hdr_Id = GetNewHeaderId();
                            newobj.Company_Id = obj.Company_Id;
                            newobj.Branch_Id = obj.Branch_Id;
                            newobj.Emp_Serial_No = obj.Emp_Serial_No;
                            newobj.Rec_Order_HdrId = GetNewHeaderId();
                            newobj.Rec_Order_No = "0";
                            newobj.Request_Id = obj.Request_Id ;
                            newobj.TransDate = DateTime.Now.ToString("yyyyMMdd");
                            newobj.FromDate = obj.FromDate;
                            newobj.ToDate = obj.ToDate;
                            newobj.BackDate = Convert.ToString(obj.BackDate);
                            newobj.Vaction_Period = obj.Vaction_Period;
                            newobj.PlaceOfResidence = obj.PlaceOfResidence;
                            newobj.Commissioner_Serial_no = obj.Emp_Serial_No;
                            newobj.Reason = obj.Reason;
                            newobj.InsUser =UserNameProperty;
                            newobj.InsDate = DateTime.Now;
                            newobj.DocumentPath = null;
                            newobj.Reason = obj.Reason;
                            newobj.MessageNotesForEmp = obj.MessageNotesForEmpeason;
                            newobj.HireItem_Id = obj.HireItem_Id;
                            newobj.FreeBalancRequest = obj.FreeBalancRequest;
                            newobj.ChargeBalancRequest = obj.ChargeBalancRequest;
                            newobj.AcuallBackDate = obj.AcuallBackDate;
                            newobj.AcuallVaction_Peiod = obj.AcuallVaction_Peiod;
                            newobj.Contract_Id = obj.Contract_Id;
                            newobj.ContractPeriod_Id = obj.ContractPeriod_Id;
                            newobj.Tot_Transferd_Period = obj.Tot_Transferd_Period;
                            newobj.Curr_DiscVac_Period = obj.Curr_DiscVac_Period;
                            newobj.Curr_DiscTransferd_Period = obj.Curr_DiscTransferd_Period;
                            newobj.Prev_Vaction_Period = obj.Prev_Vaction_Period;
                            newobj.CurrAllowedVacTillDate = obj.CurrAllowedVacTillDate;
                            newobj.Vac_Place_Type = null;
                            newobj.Offical_Vaction_Period = obj.Offical_Vaction_Period;
                            newobj.VactionFromPrmEffec = obj.VactionFromPrmEffec;
                            newobj.Confirmed = 0;
                            objPharmaEntities.Hr_EmpVactionRecord.Add(newobj);
                            Result = objPharmaEntities.SaveChanges();

                        }
                        //Edit
                        else if (obj.RowStatus == 2)
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {

                                Hr_EmpVactionRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpVactionRecord
                                                                    where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {
                                    ObjForUpdate.Emp_Serial_No = obj.Emp_Serial_No;
                                    ObjForUpdate.FromDate = obj.FromDate;
                                    ObjForUpdate.ToDate = obj.ToDate;
                                    ObjForUpdate.PlaceOfResidence = obj.PlaceOfResidence;
                                    ObjForUpdate.Reason = obj.Reason;
                                    ObjForUpdate.UpdateUser = UserNameProperty;
                                    ObjForUpdate.UpdateDate = DateTime.Now;




                                    Result = objPharmaEntities.SaveChanges();
                                }
                            }
                            else
                            {

                                Hr_EmpVactionRecord newobj = new Hr_EmpVactionRecord();
                                newobj.Rec_Hdr_Id = GetNewHeaderId();
                                newobj.Company_Id = obj.Company_Id;
                                newobj.Branch_Id = obj.Branch_Id;
                                newobj.Emp_Serial_No = obj.Emp_Serial_No;
                                newobj.Rec_Order_HdrId = GetNewHeaderId();
                                newobj.Rec_Order_No = "0";
                                newobj.Request_Id = obj.Request_Id;
                                newobj.TransDate = DateTime.Now.ToString("yyyyMMdd");
                                newobj.FromDate = obj.FromDate;
                                newobj.ToDate = obj.ToDate;
                                newobj.BackDate = Convert.ToString(obj.BackDate);
                                newobj.Vaction_Period = obj.Vaction_Period;
                                newobj.PlaceOfResidence = obj.PlaceOfResidence;
                                newobj.Commissioner_Serial_no = obj.Emp_Serial_No;
                                newobj.Reason = obj.Reason;
                                newobj.InsUser = UserNameProperty;
                                newobj.InsDate = DateTime.Now;
                                newobj.DocumentPath = null;
                                newobj.Reason = obj.Reason;
                                newobj.MessageNotesForEmp = obj.MessageNotesForEmpeason;
                                newobj.HireItem_Id = obj.HireItem_Id;
                                newobj.FreeBalancRequest = obj.FreeBalancRequest;
                                newobj.ChargeBalancRequest = obj.ChargeBalancRequest;
                                newobj.AcuallBackDate = obj.AcuallBackDate;
                                newobj.AcuallVaction_Peiod = obj.AcuallVaction_Peiod;
                                newobj.Contract_Id = obj.Contract_Id;
                                newobj.ContractPeriod_Id = obj.ContractPeriod_Id;
                                newobj.Tot_Transferd_Period = obj.Tot_Transferd_Period;
                                newobj.Curr_DiscVac_Period = obj.Curr_DiscVac_Period;
                                newobj.Curr_DiscTransferd_Period = obj.Curr_DiscTransferd_Period;
                                newobj.Prev_Vaction_Period = obj.Prev_Vaction_Period;
                                newobj.CurrAllowedVacTillDate = obj.CurrAllowedVacTillDate;
                                newobj.Vac_Place_Type = null;
                                newobj.Offical_Vaction_Period = obj.Offical_Vaction_Period;
                                newobj.VactionFromPrmEffec = obj.VactionFromPrmEffec;
                                newobj.Confirmed = 0;
                                objPharmaEntities.Hr_EmpVactionRecord.Add(newobj);
                                Result = objPharmaEntities.SaveChanges();

                            }

                        }
                        //Delete
                        else if (obj.RowStatus == 3 )
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {
                                Hr_EmpVactionRecord ObjForDelete = (from objLinq in objPharmaEntities.Hr_EmpVactionRecord
                                                                    where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();
                                if (ObjForDelete != null)
                                {
                                    objPharmaEntities.Hr_EmpVactionRecord.Remove(ObjForDelete);
                                    objPharmaEntities.SaveChanges();
                                }
                             
                            }
                            else
                            {

                            }
                         
                        }
                        else
                        {

                        }
                     

                    }


                    return (Result > 0);

                }
                else
                {

                    return (Result < 0);
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



        public List<VcationRecordDL> GetVacationRecordData(decimal EmpSerial_No, string VacationFrom, string VacationTo, string VacationType, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<VcationRecordDL> objectList = new List<VcationRecordDL>();


                object[] param1 = {

                new SqlParameter("@Emp_Serial_No", EmpSerial_No),
                new SqlParameter("@VacationFrom",VacationFrom),//(Convert.ToDateTime(OvertimeFrom)).ToString("yyyyMMdd")),
                new SqlParameter("@VacationTo",VacationTo),// (Convert.ToDateTime(OvertimeTo)).ToString("yyyyMMdd"))
                new SqlParameter("@VacationType",VacationType),
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id)


             };

                //sp_GetEmpOverTimeRecord
                var objlist = objPharmaEntities.Database.SqlQuery<VcationRecordDL>("exec dbo.sp_GetEmpOtherVacationRecord @Emp_Serial_No, @VacationFrom, @VacationTo,@VacationType,@Company_Id,@Branch_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    VcationRecordDL VcationRecordDL = new VcationRecordDL();
                    VcationRecordDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    VcationRecordDL.Company_Id = obj.Company_Id;
                    VcationRecordDL.Branch_Id = obj.Branch_Id;
                    VcationRecordDL.Emp_Serial_No = obj.Emp_Serial_No;
                    VcationRecordDL.FullNameArabic = obj.FullNameArabic;
                    VcationRecordDL.FullNameEn = obj.FullNameEn;
                    VcationRecordDL.TransDate = obj.TransDate;
                    VcationRecordDL.FromDate = obj.FromDate;
                    VcationRecordDL.ToDate = obj.ToDate;
                    VcationRecordDL.FromStartPeriod = obj.FromStartPeriod;
                    VcationRecordDL.ToEndPeriod = obj.ToEndPeriod;
                    VcationRecordDL.Request_Id =obj.Request_Id;
                    VcationRecordDL.PlaceOfResidence = obj.PlaceOfResidence;
                    VcationRecordDL.Reason = obj.Reason;
                    VcationRecordDL.FreeBalancRequest = obj.FreeBalancRequest;
                    VcationRecordDL.ChargeBalancRequest = obj.ChargeBalancRequest;
                    VcationRecordDL.AcuallBackDate = obj.AcuallBackDate;
                    VcationRecordDL.AcuallVaction_Peiod = obj.AcuallVaction_Peiod;
                    VcationRecordDL.Contract_Id = obj.Contract_Id;
                    VcationRecordDL.ContractPeriod_Id = obj.ContractPeriod_Id;
                    VcationRecordDL.Tot_Transferd_Period = obj.Tot_Transferd_Period;
                    VcationRecordDL.Curr_DiscVac_Period = obj.Curr_DiscVac_Period;
                    VcationRecordDL.Curr_DiscTransferd_Period = obj.Curr_DiscTransferd_Period;
                    VcationRecordDL.Prev_Vaction_Period = obj.Prev_Vaction_Period;
                    VcationRecordDL.Vaction_Period = obj.Vaction_Period;
                    VcationRecordDL.CurrAllowedVacTillDate = obj.CurrAllowedVacTillDate;
                    VcationRecordDL.Vac_Place_Type = obj.Vac_Place_Type;
                    VcationRecordDL.Offical_Vaction_Period = obj.Offical_Vaction_Period;
                    VcationRecordDL.VactionFromPrmEffec = obj.VactionFromPrmEffec;
                    VcationRecordDL.RowStatus = obj.RowStatus;
                    VcationRecordDL.Confirmed = obj.Confirmed;
                    objectList.Add(VcationRecordDL);

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


        public List<VacationData> CalcEmpVactionPerRquest(decimal EmpSerial_No,string Company_Id, string Branch_Id,string FromDate, string ToDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<VacationData> objectList = new List<VacationData>();


                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id),
                new SqlParameter("@Emp_Serial_No",EmpSerial_No),
                new SqlParameter("@FromDate",FromDate),
               


             };
                object[] param2 = {

              
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate", ToDate),


             };

                var objlist = objPharmaEntities.Database.SqlQuery<VacationData>("exec dbo.CalcEmpAnnualVactionPerRquest @Company_Id,@Branch_Id,@Emp_Serial_No,@FromDate", param1).ToList();
                var balance= objPharmaEntities.Database.SqlQuery<decimal>("select  dbo.Fn_get_OfficalVacation(@Company_Id,'@Branch_Id',@FromDate,@ToDate)", param2).FirstOrDefault();
                foreach (var obj in objlist)
                {
                    VacationData VacationData = new VacationData();
                    
                    VacationData.Company_Id = obj.Company_Id;
                    VacationData.Branch_Id = obj.Branch_Id;
                    VacationData.Emp_Serial_No = obj.Emp_Serial_No;
                    VacationData.AllowedVacationBal_Col = obj.AllowedVacationBal_Col;
                    VacationData.Net_NoOfActuallyVacationDaysTillDate_Col = obj.Net_NoOfActuallyVacationDaysTillDate_Col;
                    VacationData.NewTransferedAfterFinishingContract_Col = obj.NewTransferedAfterFinishingContract_Col;
                    VacationData.NoOfPerviousAnnaulVacTillDate_Col = obj.NoOfPerviousAnnaulVacTillDate_Col;
                    VacationData.NoOfActuallyVacationDaysTillDate_Col = obj.NoOfActuallyVacationDaysTillDate_Col;
                    VacationData.OfficialVacations = obj.OfficialVacations;
                    VacationData.VactionFromPrmEffect = obj.VactionFromPrmEffect;
                    VacationData.NoOfTransferAnnaulVacTillDate_Col = obj.NoOfTransferAnnaulVacTillDate_Col;
                    VacationData.TotalAvailable = (obj.AllowedVacationBal_Col + obj.NoOfTransferAnnaulVacTillDate_Col);
                    VacationData.RemainBalance =Convert.ToDecimal(balance);
                    VacationData.FromStartPeriod = obj.FromStartPeriod;
                    VacationData.ToEndPeriod = obj.ToEndPeriod;
                    VacationData.Contract_Id = obj.Contract_Id;
                    VacationData.ContractPeriod_Id = obj.ContractPeriod_Id;



                    objectList.Add(VacationData);

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


        public EmpCalcVactionRequestDL GetCalcVactionRequest(string CompanyId, string Branch_Id, decimal Emp_Serial_No, string Request_Id, string StartDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            // int MaxValue = 0;

            EmpCalcVactionRequestDL objEmpCalcVactionRequestDLList = new EmpCalcVactionRequestDL();
            try
            {


                OpenEntityConnection();

                object[] param1 = {
                new SqlParameter("@CompanyId",CompanyId),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No),
                new SqlParameter("@Request_Id", Request_Id),
                new SqlParameter("@StartDate", StartDate) };

                var objlist = objPharmaEntities.Database.SqlQuery<EmpCalcVactionRequestDL>("exec dbo.[CalcEmpVactionPerRquest] @CompanyId,@Branch_Id,@Emp_Serial_No,@Request_Id,@StartDate", param1).FirstOrDefault();

                if (objlist != null)
                {
                    EmpCalcVactionRequestDL objEmpCalcVactionRequestDL = new EmpCalcVactionRequestDL();

                    objEmpCalcVactionRequestDL.Branch_Id_Col = objlist.Branch_Id_Col;
                    objEmpCalcVactionRequestDL.CompanyId_Col = objlist.CompanyId_Col;
                    objEmpCalcVactionRequestDL.Request_Id_Col = objlist.Request_Id_Col;
                    objEmpCalcVactionRequestDL.Emp_Serial_No_Col = objlist.Emp_Serial_No_Col;

                    objEmpCalcVactionRequestDL.HireDate_Col = objlist.HireDate_Col;
                    objEmpCalcVactionRequestDL.TakenDay_Col = objlist.TakenDay_Col;
                    objEmpCalcVactionRequestDL.MaxPeriodYearPerRequest_Col = objlist.MaxPeriodYearPerRequest_Col;
                    objEmpCalcVactionRequestDL.MinPeriodYearPerRequest_Col = objlist.MinPeriodYearPerRequest_Col;
                    objEmpCalcVactionRequestDL.RequestDiscountType_Col = objlist.RequestDiscountType_Col;
                    objEmpCalcVactionRequestDL.RequestRatioValue_Col = objlist.RequestRatioValue_Col;
                    objEmpCalcVactionRequestDL.Contract_Id = objlist.Contract_Id;
                    objEmpCalcVactionRequestDL.ContractPeriod_Id = objlist.ContractPeriod_Id;
                    objEmpCalcVactionRequestDL.FromStartPeriod = objlist.FromStartPeriod;
                    objEmpCalcVactionRequestDL.ToEndPeriod = objlist.ToEndPeriod;





                    return objEmpCalcVactionRequestDL;


                }
                else
                    return null;

                //foreach (var obj in objlist)
                //{
                //    ComboDL objCombDL = new ComboDL();

                //    objCombDL.Id = Convert.ToString(obj.Id);
                //    objCombDL.Name = obj.Name;
                //    objectList.Add(objCombDL);

                //}






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
            return objEmpCalcVactionRequestDLList;

        }

    }
}
