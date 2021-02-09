using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HrServices.RequestManagement;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Validation;


namespace DAL.HrServices.RequestManagement
{
    public class EmpAllowanceRequestDAL : CommonDB

    {


        public EmpAllowanceRulesDL GetRequestData(string CompanyId, string Branch_Id, decimal Emp_Serial_No, string FromDate, string TODate, string FromCity, string ToCity, byte IsSeason, string AllowanceType, string AllowanceTypeSystem)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                object[] param1 = {
                new SqlParameter("@CompanyId",CompanyId),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@TODate", TODate),
                new SqlParameter("@FromCity", FromCity),
                new SqlParameter("@ToCity", ToCity),
                new SqlParameter("@IsSeason", IsSeason),
                new SqlParameter("@AllowanceType", AllowanceType),
                new SqlParameter("@AllowanceTypeSystem", AllowanceTypeSystem)
                };

                var objlist = objPharmaEntities.Database.SqlQuery<EmpAllowanceRulesDL>("exec dbo.[sp_GetMhanaAllowanceRules] @CompanyId,@Branch_Id,@Emp_Serial_No,@FromDate,@TODate,@FromCity,@ToCity,@IsSeason,@AllowanceType,@AllowanceTypeSystem", param1).FirstOrDefault();

                if (objlist != null)
                {
                    EmpAllowanceRulesDL objEmpAllowanceRulesDL = new EmpAllowanceRulesDL();

                    objEmpAllowanceRulesDL.Company_Id = objlist.Company_Id;
                    objEmpAllowanceRulesDL.Branch_Id = objlist.Branch_Id;
                    objEmpAllowanceRulesDL.GradeJob_Id = objlist.GradeJob_Id;
                    objEmpAllowanceRulesDL.FromDate = objlist.FromDate;
                    objEmpAllowanceRulesDL.ToDate = objlist.ToDate;
                    objEmpAllowanceRulesDL.PeriodByDays = objlist.PeriodByDays;
                    objEmpAllowanceRulesDL.FromCity = objlist.FromCity;
                    objEmpAllowanceRulesDL.ToCity = objlist.ToCity;
                    objEmpAllowanceRulesDL.CitiesDistance = objlist.CitiesDistance;
                    objEmpAllowanceRulesDL.CarRent = objlist.CarRent;
                    objEmpAllowanceRulesDL.DailyAllowance = objlist.DailyAllowance;
                    objEmpAllowanceRulesDL.DailyAllowanceValue = objlist.DailyAllowanceValue;
                    objEmpAllowanceRulesDL.HousingAllowanceValue = objlist.HousingAllowanceValue;
                    objEmpAllowanceRulesDL.TransPortAllowanceValue = objlist.TransPortAllowanceValue;
                    objEmpAllowanceRulesDL.NeedAirLine = objlist.NeedAirLine;





                    return objEmpAllowanceRulesDL;


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


        public List<EmpAllowanceEditRulesDL> GetRulesData()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<EmpAllowanceEditRulesDL> objectList = new List<EmpAllowanceEditRulesDL>();

                var objlist = objPharmaEntities.Database.SqlQuery<EmpAllowanceEditRulesDL>(" SELECT * FROM Vw_GetRulesData").ToList();

                foreach (var obj in objlist)
                {
                    EmpAllowanceEditRulesDL objEmpAllowanceEditRulesDL = new EmpAllowanceEditRulesDL();
                    objEmpAllowanceEditRulesDL.id = obj.id;
                    objEmpAllowanceEditRulesDL.FromCity = obj.FromCity;
                    objEmpAllowanceEditRulesDL.FromCityName = obj.FromCityName;
                    objEmpAllowanceEditRulesDL.FromCityNameEn = obj.FromCityNameEn;
                    objEmpAllowanceEditRulesDL.ToCity = obj.ToCity;
                    objEmpAllowanceEditRulesDL.ToCityName = obj.ToCityName;
                    objEmpAllowanceEditRulesDL.ToCityNameEn = obj.ToCityNameEn;
                    objEmpAllowanceEditRulesDL.Distance = obj.Distance;
                    objEmpAllowanceEditRulesDL.CarRent = obj.CarRent;
                    objEmpAllowanceEditRulesDL.DailyAllowance = obj.DailyAllowance;
                    objEmpAllowanceEditRulesDL.AllowanceValueLess7Day = obj.AllowanceValueLess7Day;
                    objEmpAllowanceEditRulesDL.AllowanceValueMore7Day = obj.AllowanceValueMore7Day;
                    objEmpAllowanceEditRulesDL.MaxValueHousingForMangwithoutSeason = obj.MaxValueHousingForMangwithoutSeason;
                    objEmpAllowanceEditRulesDL.MaxValueHousingForMangwithinSeason = obj.MaxValueHousingForMangwithinSeason;
                    objEmpAllowanceEditRulesDL.MaxValueHousingForSuperVsorwithoutSeason = obj.MaxValueHousingForSuperVsorwithoutSeason;
                    objEmpAllowanceEditRulesDL.MaxValueHousingForSuperVsorwithinSeason = obj.MaxValueHousingForSuperVsorwithinSeason;
                    objEmpAllowanceEditRulesDL.TransPortValueLess7Day = obj.TransPortValueLess7Day;
                    objEmpAllowanceEditRulesDL.TransPortValueMore7Day = obj.TransPortValueMore7Day;
                    objEmpAllowanceEditRulesDL.NeedAirLine = obj.NeedAirLine;


                    objectList.Add(objEmpAllowanceEditRulesDL);

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

        public List<EmpAllowanceEditRulesDL> GetFilteredRulesData(string FromCity, string ToCity)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<EmpAllowanceEditRulesDL> objectList = new List<EmpAllowanceEditRulesDL>();

                var objlist = objPharmaEntities.Database.SqlQuery<EmpAllowanceEditRulesDL>(" SELECT * FROM Vw_GetRulesData where FromCity="+ FromCity + " and ToCity="+ ToCity + "").ToList();

                foreach (var obj in objlist)
                {
                    EmpAllowanceEditRulesDL objEmpAllowanceEditRulesDL = new EmpAllowanceEditRulesDL();
                    objEmpAllowanceEditRulesDL.id = obj.id;
                    objEmpAllowanceEditRulesDL.FromCity = obj.FromCity;
                    objEmpAllowanceEditRulesDL.FromCityName = obj.FromCityName;
                    objEmpAllowanceEditRulesDL.FromCityNameEn = obj.FromCityNameEn;
                    objEmpAllowanceEditRulesDL.ToCity = obj.ToCity;
                    objEmpAllowanceEditRulesDL.ToCityName = obj.ToCityName;
                    objEmpAllowanceEditRulesDL.ToCityNameEn = obj.ToCityNameEn;
                    objEmpAllowanceEditRulesDL.Distance = obj.Distance;
                    objEmpAllowanceEditRulesDL.CarRent = obj.CarRent;
                    objEmpAllowanceEditRulesDL.DailyAllowance = obj.DailyAllowance;
                    objEmpAllowanceEditRulesDL.AllowanceValueLess7Day = obj.AllowanceValueLess7Day;
                    objEmpAllowanceEditRulesDL.AllowanceValueMore7Day = obj.AllowanceValueMore7Day;
                    objEmpAllowanceEditRulesDL.MaxValueHousingForMangwithoutSeason = obj.MaxValueHousingForMangwithoutSeason;
                    objEmpAllowanceEditRulesDL.MaxValueHousingForMangwithinSeason = obj.MaxValueHousingForMangwithinSeason;
                    objEmpAllowanceEditRulesDL.MaxValueHousingForSuperVsorwithoutSeason = obj.MaxValueHousingForSuperVsorwithoutSeason;
                    objEmpAllowanceEditRulesDL.MaxValueHousingForSuperVsorwithinSeason = obj.MaxValueHousingForSuperVsorwithinSeason;
                    objEmpAllowanceEditRulesDL.TransPortValueLess7Day = obj.TransPortValueLess7Day;
                    objEmpAllowanceEditRulesDL.TransPortValueMore7Day = obj.TransPortValueMore7Day;
                    objEmpAllowanceEditRulesDL.NeedAirLine = obj.NeedAirLine;


                    objectList.Add(objEmpAllowanceEditRulesDL);

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

        public bool SaveRuleData(EmpAllowanceEditRulesDL ObjRuleDL)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            var strErrorMessage = string.Empty;

            bool result = true;
            try
            {

                OpenEntityConnection();

                //    result = AddShiftGroup(ObjGroupD);

                if (ObjRuleDL != null)
                {

                    if (ObjRuleDL.id == 0 || ObjRuleDL.id == null)
                    {
                        if (ObjRuleDL.IsEdit == 0)
                        {


                            Hr_MahnaAllowanceRules AllowanceRule = new Hr_MahnaAllowanceRules
                            {
                                FromCity = ObjRuleDL.FromCity,
                                ToCity = ObjRuleDL.ToCity,
                                Distance = ObjRuleDL.Distance,
                                CarRent = ObjRuleDL.CarRent,
                                DailyAllowance = ObjRuleDL.DailyAllowance,
                                AllowanceValueLess7Day = ObjRuleDL.AllowanceValueLess7Day,
                                AllowanceValueMore7Day = ObjRuleDL.AllowanceValueMore7Day,
                                MaxValueHousingForMangwithoutSeason = ObjRuleDL.MaxValueHousingForMangwithoutSeason,
                                MaxValueHousingForMangwithinSeason = ObjRuleDL.MaxValueHousingForMangwithinSeason,
                                MaxValueHousingForSuperVsorwithoutSeason = ObjRuleDL.MaxValueHousingForSuperVsorwithoutSeason,
                                MaxValueHousingForSuperVsorwithinSeason = ObjRuleDL.MaxValueHousingForSuperVsorwithinSeason,
                                TransPortValueLess7Day = ObjRuleDL.TransPortValueLess7Day,
                                TransPortValueMore7Day = ObjRuleDL.TransPortValueMore7Day,
                                NeedAirLine = ObjRuleDL.NeedAirLine,

                            };


                            objPharmaEntities.Hr_MahnaAllowanceRules.Add(AllowanceRule);
                            objPharmaEntities.SaveChanges();
                            return result;

                        }
                    }

                    //return result;


                    else
                    {
                        if (ObjRuleDL.IsEdit == 1)
                        {
                            Hr_MahnaAllowanceRules ObjForUpdate = (from objLinq in objPharmaEntities.Hr_MahnaAllowanceRules
                                                                   where objLinq.id == ObjRuleDL.id
                                                                   select objLinq).FirstOrDefault();

                            if (ObjForUpdate != null)
                            {
                                ObjForUpdate.FromCity = ObjRuleDL.FromCity;
                                ObjForUpdate.ToCity = ObjRuleDL.ToCity;
                                ObjForUpdate.Distance = ObjRuleDL.Distance;
                                ObjForUpdate.CarRent = ObjRuleDL.CarRent;
                                ObjForUpdate.DailyAllowance = ObjRuleDL.DailyAllowance;
                                ObjForUpdate.AllowanceValueLess7Day = ObjRuleDL.AllowanceValueLess7Day;
                                ObjForUpdate.AllowanceValueMore7Day = ObjRuleDL.AllowanceValueMore7Day;
                                ObjForUpdate.MaxValueHousingForMangwithoutSeason = ObjRuleDL.MaxValueHousingForMangwithoutSeason;
                                ObjForUpdate.MaxValueHousingForMangwithinSeason = ObjRuleDL.MaxValueHousingForMangwithinSeason;
                                ObjForUpdate.MaxValueHousingForSuperVsorwithoutSeason = ObjRuleDL.MaxValueHousingForSuperVsorwithoutSeason;
                                ObjForUpdate.MaxValueHousingForSuperVsorwithinSeason = ObjRuleDL.MaxValueHousingForSuperVsorwithinSeason;
                                ObjForUpdate.TransPortValueLess7Day = ObjRuleDL.TransPortValueLess7Day;
                                ObjForUpdate.TransPortValueMore7Day = ObjRuleDL.TransPortValueMore7Day;
                                ObjForUpdate.NeedAirLine = ObjRuleDL.NeedAirLine;

                                objPharmaEntities.SaveChanges();
                                 return result;
                            }
                        }
                    }



                }

                else
                { result = false; }
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

            return result;



        }

        public bool DeleteRule(int? RowId)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                int Result = 0;
                if (RowId != null && RowId != 0)
                {
                    Hr_MahnaAllowanceRules ObjForDelete = (from objLinq in objPharmaEntities.Hr_MahnaAllowanceRules
                                                           where objLinq.id == RowId
                                                           select objLinq).FirstOrDefault();
                    if (ObjForDelete != null)
                    {
                        objPharmaEntities.Hr_MahnaAllowanceRules.Remove(ObjForDelete);
                        objPharmaEntities.SaveChanges();
                        return (Result > 0);

                    }

                    else
                    {
                        return (Result < 0);
                    }
                }                
                else { return (Result < 0); }
        }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException) ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        ex.InnerException.Message.ToString();
                return false;

            }
            finally
            {
                CloseEntityConnection();
            }



        }

        public async Task<int> Insert(Hr_EmpVactionRequest objInsert)
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


            objPharmaEntities.Hr_EmpVactionRequest.Add(objInsert);
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
public int InsertTask(Hr_EmpAllowanceRequest objInsert)
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

            objPharmaEntities.Hr_EmpAllowanceRequest.Add(objInsert);
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
public List<EmpAllowanceRequestDL> GetEmpAllRequests(decimal Emp_Serial_No, string Company_Id, string Branch_Id)
{

    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    try
    {


        OpenEntityConnection();


        List<EmpAllowanceRequestDL> objectList = new List<EmpAllowanceRequestDL>();

        var objlist = (from objLinq in objPharmaEntities.Hr_EmpAllowanceRequest
                       join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                       join Reqstatus in objPharmaEntities.Hr_RequestStatus on objLinq.Order_Status equals Reqstatus.RequestStatus_Id
                       where objLinq.Company_Id == Company_Id && objLinq.Branch_Id == Branch_Id && objLinq.Emp_Serial_No == Emp_Serial_No
                       select new
                       {
                           Rec_Hdr_Id = objLinq.Rec_Hdr_Id,
                           ReferenceNo = objLinq.ReferenceNo,
                           Request_Id = objLinq.Request_Id,
                           Project_Id = objLinq.Project_Id,
                           Emp_Serial_No = objLinq.Emp_Serial_No,
                           TransDate = objLinq.TransDate,
                           Order_Status = objLinq.Order_Status,
                           Commissioner_Serial_no = objLinq.Commissioner_Serial_no,
                           FromDate = objLinq.FromDate,
                           ToDate = objLinq.ToDate,
                           Allowance_Type = objLinq.Allowance_Type,
                           Allowance_Method_Type = objLinq.Allowance_Method_Type,
                           GradeJob_Id = objLinq.GradeJob_Id,
                           FromCity = objLinq.FromCity,
                           ToCity = objLinq.ToCity,
                           MissionDays = objLinq.MissionDays,
                           DailyAllowance = objLinq.DailyAllowance,
                           HousingAllowance = objLinq.HousingAllowance,
                           TransportUsedType = objLinq.TransportUsedType,
                           TransportAllowance = objLinq.TransportAllowance,
                           IsBookingFlight = objLinq.IsBookingFlight,
                           IsSession = objLinq.IsSession,
                           ExpectedTotalValue = objLinq.ExpectedTotalValue,
                           RequestTypeNameEn = ReqType.Request_NameEn,
                           StatusNameEn = Reqstatus.RequestStatus_NameEn,
                           RequestTypeName = ReqType.Request_Name,
                           StatusName = Reqstatus.RequestStatus_Name
                       }).ToList();



        foreach (var obj in objlist)
        {
            EmpAllowanceRequestDL objEmpAllowanceRequestDL = new EmpAllowanceRequestDL();
            objEmpAllowanceRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
            objEmpAllowanceRequestDL.ReferenceNo = obj.ReferenceNo;
            objEmpAllowanceRequestDL.Request_Id = obj.Request_Id;
            objEmpAllowanceRequestDL.Project_Id = obj.Project_Id;
            objEmpAllowanceRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
            objEmpAllowanceRequestDL.TransDate = obj.TransDate;
            objEmpAllowanceRequestDL.Order_Status = obj.Order_Status;
            objEmpAllowanceRequestDL.Commissioner_Serial_no = obj.Commissioner_Serial_no;
            objEmpAllowanceRequestDL.FromDate = obj.FromDate;
            objEmpAllowanceRequestDL.ToDate = obj.ToDate;
            objEmpAllowanceRequestDL.Allowance_Type = obj.Allowance_Type;
            objEmpAllowanceRequestDL.Allowance_Method_Type = obj.Allowance_Method_Type;
            objEmpAllowanceRequestDL.GradeJob_Id = obj.GradeJob_Id;
            objEmpAllowanceRequestDL.FromCity = obj.FromCity;
            objEmpAllowanceRequestDL.ToCity = obj.ToCity;
            objEmpAllowanceRequestDL.MissionDays = obj.MissionDays;
            objEmpAllowanceRequestDL.DailyAllowance = obj.DailyAllowance;
            objEmpAllowanceRequestDL.HousingAllowance = obj.HousingAllowance;
            objEmpAllowanceRequestDL.TransportUsedType = obj.TransportUsedType;
            objEmpAllowanceRequestDL.TransportAllowance = obj.TransportAllowance;
            objEmpAllowanceRequestDL.IsBookingFlight = obj.IsBookingFlight;
            objEmpAllowanceRequestDL.IsSession = obj.IsSession;
            objEmpAllowanceRequestDL.ExpectedTotalValue = obj.ExpectedTotalValue;
            objEmpAllowanceRequestDL.RequestTypeNameEn = obj.RequestTypeName;
            objEmpAllowanceRequestDL.StatusNameEn = obj.StatusNameEn;
            objEmpAllowanceRequestDL.RequestTypeName = obj.RequestTypeName;
            objEmpAllowanceRequestDL.StatusName = obj.StatusName;

            objectList.Add(objEmpAllowanceRequestDL);

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


public List<EmpAllowanceRequestDL> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
{

    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    try
    {


        OpenEntityConnection();


        List<EmpAllowanceRequestDL> objectList = new List<EmpAllowanceRequestDL>();

        var objlist = (from objLinq in objPharmaEntities.Hr_EmpAllowanceRequest
                       join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                       join Reqstatus in objPharmaEntities.Hr_RequestStatus on objLinq.Order_Status equals Reqstatus.RequestStatus_Id
                       where objLinq.Company_Id == strcomapny && objLinq.Branch_Id == strbranch
                       select new
                       {
                           Rec_Hdr_Id = objLinq.Rec_Hdr_Id,
                           ReferenceNo = objLinq.ReferenceNo,
                           Request_Id = objLinq.Request_Id,
                           Project_Id = objLinq.Project_Id,
                           Emp_Serial_No = objLinq.Emp_Serial_No,
                           TransDate = objLinq.TransDate,
                           Order_Status = objLinq.Order_Status,
                           Commissioner_Serial_no = objLinq.Commissioner_Serial_no,
                           FromDate = objLinq.FromDate,
                           ToDate = objLinq.ToDate,
                           Allowance_Type = objLinq.Allowance_Type,
                           Allowance_Method_Type = objLinq.Allowance_Method_Type,
                           GradeJob_Id = objLinq.GradeJob_Id,
                           FromCity = objLinq.FromCity,
                           ToCity = objLinq.ToCity,
                           MissionDays = objLinq.MissionDays,
                           DailyAllowance = objLinq.DailyAllowance,
                           HousingAllowance = objLinq.HousingAllowance,
                           TransportUsedType = objLinq.TransportUsedType,
                           TransportAllowance = objLinq.TransportAllowance,
                           IsBookingFlight = objLinq.IsBookingFlight,
                           IsSession = objLinq.IsSession,
                           ExpectedTotalValue = objLinq.ExpectedTotalValue,
                           RequestTypeNameEn = ReqType.Request_NameEn,
                           StatusNameEn = Reqstatus.RequestStatus_NameEn,
                           RequestTypeName = ReqType.Request_Name,
                           StatusName = Reqstatus.RequestStatus_Name
                       }).ToList();



        foreach (var obj in objlist)
        {
            EmpAllowanceRequestDL objEmpAllowanceRequestDL = new EmpAllowanceRequestDL();
            objEmpAllowanceRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
            objEmpAllowanceRequestDL.ReferenceNo = obj.ReferenceNo;
            objEmpAllowanceRequestDL.Request_Id = obj.Request_Id;
            objEmpAllowanceRequestDL.Project_Id = obj.Project_Id;
            objEmpAllowanceRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
            objEmpAllowanceRequestDL.TransDate = obj.TransDate;
            objEmpAllowanceRequestDL.Order_Status = obj.Order_Status;
            objEmpAllowanceRequestDL.Commissioner_Serial_no = obj.Commissioner_Serial_no;
            objEmpAllowanceRequestDL.FromDate = obj.FromDate;
            objEmpAllowanceRequestDL.ToDate = obj.ToDate;
            objEmpAllowanceRequestDL.Allowance_Type = obj.Allowance_Type;
            objEmpAllowanceRequestDL.Allowance_Method_Type = obj.Allowance_Method_Type;
            objEmpAllowanceRequestDL.GradeJob_Id = obj.GradeJob_Id;
            objEmpAllowanceRequestDL.FromCity = obj.FromCity;
            objEmpAllowanceRequestDL.ToCity = obj.ToCity;
            objEmpAllowanceRequestDL.MissionDays = obj.MissionDays;
            objEmpAllowanceRequestDL.DailyAllowance = obj.DailyAllowance;
            objEmpAllowanceRequestDL.HousingAllowance = obj.HousingAllowance;
            objEmpAllowanceRequestDL.TransportUsedType = obj.TransportUsedType;
            objEmpAllowanceRequestDL.TransportAllowance = obj.TransportAllowance;
            objEmpAllowanceRequestDL.IsBookingFlight = obj.IsBookingFlight;
            objEmpAllowanceRequestDL.IsSession = obj.IsSession;
            objEmpAllowanceRequestDL.ExpectedTotalValue = obj.ExpectedTotalValue;
            objEmpAllowanceRequestDL.RequestTypeNameEn = obj.RequestTypeName;
            objEmpAllowanceRequestDL.StatusNameEn = obj.StatusNameEn;
            objEmpAllowanceRequestDL.RequestTypeName = obj.RequestTypeName;
            objEmpAllowanceRequestDL.StatusName = obj.StatusName;

            objectList.Add(objEmpAllowanceRequestDL);

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


public EmpCalcAnnualVactionRequestDL GetCalcAnnualVactionRequest(string CompanyId, string Branch_Id, decimal Emp_Serial_No, string StartDate)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    // int MaxValue = 0;

    EmpCalcAnnualVactionRequestDL objEmpCalcAnnualVactionRequestDLList = new EmpCalcAnnualVactionRequestDL();
    try
    {


        OpenEntityConnection();

        object[] param1 = {
                new SqlParameter("@CompanyId",CompanyId),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No),
                new SqlParameter("@StartDate", StartDate) };

        var objlist = objPharmaEntities.Database.SqlQuery<EmpCalcAnnualVactionRequestDL>("exec dbo.[CalcEmpAnnualVactionPerRquest] @CompanyId,@Branch_Id,@Emp_Serial_No,@StartDate", param1).FirstOrDefault();

        if (objlist != null)
        {
            EmpCalcAnnualVactionRequestDL objEmpCalcVactionRequestDL = new EmpCalcAnnualVactionRequestDL();

            objEmpCalcVactionRequestDL.Branch_Id_Col = objlist.Branch_Id_Col;
            objEmpCalcVactionRequestDL.CompanyId_Col = objlist.CompanyId_Col;
            objEmpCalcVactionRequestDL.Request_Id_Col = objlist.Request_Id_Col;
            objEmpCalcVactionRequestDL.Emp_Serial_No_Col = objlist.Emp_Serial_No_Col;

            objEmpCalcVactionRequestDL.NoOfActuallyVacationDaysTillDate_Col = objlist.NoOfActuallyVacationDaysTillDate_Col;
            objEmpCalcVactionRequestDL.NoOfPerviousAnnaulVacTillDate_Col = objlist.NoOfPerviousAnnaulVacTillDate_Col;
            objEmpCalcVactionRequestDL.NoOfTransferAnnaulVacTillDate_Col = objlist.NoOfTransferAnnaulVacTillDate_Col;

            objEmpCalcVactionRequestDL.NoOfWorkingDaysFromVacDuesDate_Col = objlist.NoOfWorkingDaysFromVacDuesDate_Col;
            objEmpCalcVactionRequestDL.Net_noOfDaysMustbeWorkToTakeVacation_Col = objlist.Net_noOfDaysMustbeWorkToTakeVacation_Col;
            objEmpCalcVactionRequestDL.Net_NoOfActuallyVacationDaysTillDate_Col = objlist.Net_NoOfActuallyVacationDaysTillDate_Col;
            objEmpCalcVactionRequestDL.AllowedVacationBal_Col = objlist.AllowedVacationBal_Col;
            objEmpCalcVactionRequestDL.NewTransferedAfterFinishingContract_Col = objlist.NewTransferedAfterFinishingContract_Col;

            objEmpCalcVactionRequestDL.Contract_Id = objlist.Contract_Id;
            objEmpCalcVactionRequestDL.ContractPeriod_Id = objlist.ContractPeriod_Id;
            objEmpCalcVactionRequestDL.FromStartPeriod = objlist.FromStartPeriod;
            objEmpCalcVactionRequestDL.ToEndPeriod = objlist.ToEndPeriod;

            objEmpCalcVactionRequestDL.VactionFromPrmEffect_Col = objlist.VactionFromPrmEffect_Col;


            return objEmpCalcVactionRequestDL;


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
    return objEmpCalcAnnualVactionRequestDLList;

}




public EmpBeginVactionRequestDL GetCalcBeginVaction(string CompanyId, string Branch_Id, decimal Emp_Serial_No, string Request_Id, string StartDate, string EndDate)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    // int MaxValue = 0;

    EmpBeginVactionRequestDL objEmpCalcVactionRequestDLList = new EmpBeginVactionRequestDL();
    try
    {


        OpenEntityConnection();

        object[] param1 = {
                new SqlParameter("@CompanyId",CompanyId),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No),
                new SqlParameter("@Request_Id", Request_Id),
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@EndDate", EndDate) };

        var objlist = objPharmaEntities.Database.SqlQuery<EmpBeginVactionRequestDL>("exec dbo.[CalcEmpOpenVactionRules] @CompanyId,@Branch_Id,@Emp_Serial_No,@Request_Id,@StartDate,@EndDate", param1).FirstOrDefault();

        if (objlist != null)
        {
            EmpBeginVactionRequestDL objEmpCalcVactionRequestDL = new EmpBeginVactionRequestDL();


            objEmpCalcVactionRequestDL.VactionPeriodCol = objlist.VactionPeriodCol;
            objEmpCalcVactionRequestDL.FreeVacationCol = objlist.FreeVacationCol;
            objEmpCalcVactionRequestDL.RestBalanceCol = objlist.RestBalanceCol;

            objEmpCalcVactionRequestDL.FromStartPeriod = objlist.FromStartPeriod;
            objEmpCalcVactionRequestDL.ToEndPeriod = objlist.ToEndPeriod;
            objEmpCalcVactionRequestDL.Contract_Id = objlist.Contract_Id;
            objEmpCalcVactionRequestDL.ContractPeriod_Id = objlist.ContractPeriod_Id;



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



public int GetMaxAllowedValue(string strRequestType)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    int MaxValue = 0;


    try
    {
        // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
        //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
        //         select anything.Job_Id).Single();
        //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
        //    maxId = cs.Job_Id;

        OpenEntityConnection();
        var maxAllowed = (from obj in objPharmaEntities.Hr_RequestTypesDtls
                          where obj.RequestTypeId == strRequestType && obj.RequestDiscountType == "1"


                          select obj.RequestTypeValue).FirstOrDefault();


        if (maxAllowed != null)
        {
            MaxValue = Convert.ToInt16(maxAllowed);

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
    return MaxValue;

}


public decimal CalcOfficailVacDays(string strCompanyId, string strBranch_Id, string FromDate, string ToDate)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    object[] param1 = {
                new SqlParameter("@CompanyId",strCompanyId),
                new SqlParameter("@Branch_Id", strBranch_Id),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate)};

    decimal OfficailVacDays = 0;


    try
    {
        // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
        //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
        //         select anything.Job_Id).Single();
        //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
        //    maxId = cs.Job_Id;

        OpenEntityConnection();

        var varOfficailVacDays = objPharmaEntities.Database.SqlQuery<decimal>("select [dbo].[Fn_get_OfficalVacation] (@CompanyId,@Branch_Id,@FromDate,@ToDate)", param1).FirstOrDefault<decimal>();

        if (varOfficailVacDays != null)
        {
            OfficailVacDays = Convert.ToDecimal(varOfficailVacDays);


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
    return OfficailVacDays;

}




public bool chkVactionIndivisible(string strRequestType)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    bool Result = false;


    try
    {
        // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
        //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
        //         select anything.Job_Id).Single();
        //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
        //    maxId = cs.Job_Id;

        OpenEntityConnection();
        var chkResult = (from obj in objPharmaEntities.Hr_RequestTypes
                         where obj.Request_Id == strRequestType
                         select obj.VactionIndivisible).FirstOrDefault();


        if (chkResult != null)
        {
            Result = Convert.ToInt16(chkResult) > 0;

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
    return Result;

}

public bool chkHasAttach(string strRequestType)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    bool Result = false;


    try
    {
        // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
        //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
        //         select anything.Job_Id).Single();
        //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
        //    maxId = cs.Job_Id;

        OpenEntityConnection();
        var chkResult = (from obj in objPharmaEntities.Hr_RequestTypes
                         where obj.Request_Id == strRequestType
                         select obj.AttachIsNecessary).FirstOrDefault();


        if (chkResult != null)
        {
            Result = Convert.ToInt16(chkResult) > 0;

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
    return Result;

}


public EmpAllowanceRequestDL GetRequestByHdrId(string strCompanyNo, string strBranchNo, Guid RequestHdrId)
{

    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    try
    {


        OpenEntityConnection();

        string sql = " select Rec_Hdr_Id,ReferenceNo,Request_Id,Project_Id,Rec_No,TransDate,InsUser,InsDate,Company_Id,Branch_Id,";
        sql = sql + " Emp_Serial_No,FromDate,ToDate,Allowance_Method_Type,Allowance_Type,DocumentPath,Order_Status,Commissioner_Serial_no,MessageNotesForEmp,";
        sql = sql + "Contract_Id,ContractPeriod_Id,TransportAllowance,IsBookingFlight,IsSession,ExpectedTotalValue,Notes,";
        sql = sql + " GradeJob_Id,FromCity,ToCity,MissionDays,DailyAllowance,HousingAllowance,TransportUsedType,";
        sql = sql + "[dbo].[Fn_get_DistinceBetweenCitites](FromCity,ToCity) as CitiesDistance";
        sql = sql + " from Hr_EmpAllowanceRequest where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Rec_Hdr_Id = '" + RequestHdrId + "'";


        EmpAllowanceRequestDL obj = objPharmaEntities.Database.SqlQuery<EmpAllowanceRequestDL>(sql).FirstOrDefault();
        return obj;

        //  EmpVactionRequestDL objectList = new EmpVactionRequestDL();

        //Hr_EmpVactionRequest obj = (from objLinq in objPharmaEntities.Hr_EmpVactionRequest
        //               where objLinq.Company_Id == strCompanyNo && objLinq.Branch_Id==strBranchNo && objLinq.Rec_Hdr_Id == RequestHdrId

        //               select objLinq).FirstOrDefault();


        //                            select new
        //                            {
        //                                Rec_Hdr_Id = objLinq.Rec_Hdr_Id,
        //                                ReferenceNo = objLinq.ReferenceNo,
        //                                Request_Id = objLinq.Request_Id,
        //                                Emp_Serial_No = objLinq.Emp_Serial_No,
        //                                FromDate = objLinq.FromDate,
        //                                ToDate = objLinq.ToDate,
        //                                Reason = objLinq.Reason,
        //                                PlaceOfResidence = objLinq.PlaceOfResidence,
        //                                DocumentPath = objLinq.DocumentPath,
        //                                Order_Status = objLinq.Order_Status
        //                            });


        //Hr_EmpVactionRequest obj = objPharmaEntities.Hr_EmpVactionRequest
        //                      .Where(objLinq => objLinq.Company_Id == strCompanyNo && objLinq.Branch_Id == strBranchNo && objLinq.Rec_Hdr_Id == RequestHdrId)
        //                      .Select(
        //                         objLinq =>
        //                                new
        //                                {
        //                                    Rec_Hdr_Id = objLinq.Rec_Hdr_Id,
        //                                    ReferenceNo = objLinq.ReferenceNo,
        //                                    Request_Id = objLinq.Request_Id,
        //                                    Emp_Serial_No = objLinq.Emp_Serial_No,
        //                                    FromDate = objLinq.FromDate,
        //                                    ToDate = objLinq.ToDate,
        //                                    Reason = objLinq.Reason,
        //                                    PlaceOfResidence = objLinq.PlaceOfResidence,
        //                                    DocumentPath = objLinq.DocumentPath,
        //                                    Order_Status = objLinq.Order_Status
        //                                });

        //  return objLinq;

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


public EmpAllowanceRecordDL GetRecordByHdrId(string strCompanyNo, string strBranchNo, Guid RequestHdrId, decimal Emp_Serial_No)
{

    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    try
    {
        OpenEntityConnection();

        string sql = " select Rec_Hdr_Id,ReferenceNo,Request_Id,Project_Id,Rec_No,TransDate,InsUser,InsDate,Company_Id,Branch_Id,DailyNotes,HousingNotes,TransportNotes,FuelNotes,";
        sql = sql + " Emp_Serial_No,FromDate,ToDate,Rec_Order_No,Allowance_Method_Type,Allowance_Type,Order_Status,Commissioner_Serial_no,IsActualDone,ManagerConfirmed,";
        sql = sql + "Contract_Id,ContractPeriod_Id,TransportAllowance,IsBookingFlight,IsSession,ExpectedTotalValue,ActualDailyAllowance,ActualHousingAllowance,ActualTransportAllowance,";
        sql = sql + "ActualFuelAllowance,HousingAllowanceAttach,TransportAllowanceAttach,FuelAllowanceAttach, GradeJob_Id,FromCity,ToCity,MissionDays,DailyAllowance,HousingAllowance,TransportUsedType,";
        sql = sql + "ManagerConfirmed,ManagerComment,ManagerCommentDate,HRMangerConfirmed,HRMangerComment,HRMangerCommentDate";
        sql = sql + ",isnull(DirectManagerEmp_Serial_No,0) as DirectManagerEmp_Serial_No,isnull(HrManagerEmp_Serial_No,0) as HrManagerEmp_Serial_No";
        sql = sql + ", [dbo].[Fn_get_DistinceBetweenCitites](FromCity,ToCity) as CitiesDistance";
        sql = sql + " from Hr_EmpAllowanceRecord where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Rec_Hdr_Id = '" + RequestHdrId + "'  and Emp_Serial_No = '" + Emp_Serial_No + "'";


        EmpAllowanceRecordDL obj = objPharmaEntities.Database.SqlQuery<EmpAllowanceRecordDL>(sql).FirstOrDefault();
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



public EmpAllowanceRecordDL GetRecordData(string strCompanyNo, string strBranchNo, Guid RequestHdrId, decimal Emp_Serial_No)
{

    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    try
    {
        OpenEntityConnection();

        string sql = " select Rec_Hdr_Id,ReferenceNo,Request_Id,Project_Id,Rec_No,TransDate,InsUser,InsDate,Company_Id,Branch_Id,";
        sql = sql + " Emp_Serial_No,FromDate,ToDate,Rec_Order_No,Allowance_Method_Type,Allowance_Type,Order_Status,Commissioner_Serial_no,";
        sql = sql + "Contract_Id,ContractPeriod_Id,TransportAllowance,IsBookingFlight,IsSession,ExpectedTotalValue,ActualDailyAllowance,ActualHousingAllowance,";
        sql = sql + "ActualTransportAllowance,ActualFuelAllowance, GradeJob_Id,FromCity,ToCity,MissionDays,DailyAllowance,HousingAllowance,TransportUsedType,";
        sql = sql + "DailyNotes,HousingNotes,TransportNotes,FuelNotes,HousingAllowanceAttach, TransportAllowanceAttach,FuelAllowanceAttach,ManagerConfirmed,ManagerComment,ManagerCommentDate";
        sql = sql + ",isnull(DirectManagerEmp_Serial_No,0) as DirectManagerEmp_Serial_No,isnull(HrManagerEmp_Serial_No,0) as HrManagerEmp_Serial_No,HRMangerConfirmed,HRMangerComment,HRMangerCommentDate";
        sql = sql + ", [dbo].[Fn_get_DistinceBetweenCitites](FromCity,ToCity) as CitiesDistance";
        sql = sql + " from Hr_EmpAllowanceRecord where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Rec_Hdr_Id = '" + RequestHdrId + "'  and Emp_Serial_No = '" + Emp_Serial_No + "'";


        EmpAllowanceRecordDL obj = objPharmaEntities.Database.SqlQuery<EmpAllowanceRecordDL>(sql).FirstOrDefault();
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


//public async Task<bool> Update(Hr_EmpVactionRequest objUpdate)
//{
//    StackFrame stackFrame = new StackFrame();
//    MethodBase methodBase = stackFrame.GetMethod();

//    int rowEffected = 0;
//    try
//    {
//        if (objUpdate != null) //Definsive Programming
//        {
//            OpenEntityConnection();
//            Hr_EmpVactionRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpVactionRequest
//                                    where objLinq.Job_Id == objUpdate.Job_Id
//                                    select objLinq).FirstOrDefault();
//            ObjForUpdate.Job_Name = objUpdate.Job_Name;
//            ObjForUpdate.Job_NameEn = objUpdate.Job_NameEn;
//            ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
//            ObjForUpdate.UpdateDate = DateTime.Now;


//            rowEffected = await objPharmaEntities.SaveChangesAsync() ;
//        }

//    }
//    catch (Exception ex)
//    {
//        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
//                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
//        rowEffected = -1;
//        ex.InnerException.Message.ToString();
//    }
//    finally
//    {
//        CloseEntityConnection();
//    }
//    if (rowEffected > 0)
//        return true;
//    else
//        return false;

//}
public bool UpdateRecord(Hr_EmpAllowanceRecord objUpdate)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();


    int rowEffected = 0;
    try
    {

        if (objUpdate != null) //Definsive Programming
        {
            OpenEntityConnection();
            Hr_EmpAllowanceRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpAllowanceRecord
                                                  where objLinq.Rec_Hdr_Id == objUpdate.Rec_Hdr_Id
                                                  select objLinq).FirstOrDefault();
            if (objUpdate != null)
            {
                ObjForUpdate.ActualDailyAllowance = objUpdate.ActualDailyAllowance;
                ObjForUpdate.DailyNotes = objUpdate.DailyNotes;
                ObjForUpdate.ActualHousingAllowance = objUpdate.ActualHousingAllowance;
                ObjForUpdate.HousingAllowanceAttach = objUpdate.HousingAllowanceAttach;
                ObjForUpdate.HousingNotes = objUpdate.HousingNotes;
                ObjForUpdate.ActualTransportAllowance = objUpdate.ActualTransportAllowance;
                ObjForUpdate.TransportAllowanceAttach = objUpdate.TransportAllowanceAttach;
                ObjForUpdate.TransportNotes = objUpdate.TransportNotes;
                ObjForUpdate.ActualFuelAllowance = objUpdate.ActualFuelAllowance;
                ObjForUpdate.FuelAllowanceAttach = objUpdate.FuelAllowanceAttach;
                ObjForUpdate.FuelNotes = objUpdate.FuelNotes;
                ObjForUpdate.IsActualDone = objUpdate.IsActualDone;

                rowEffected = objPharmaEntities.SaveChanges();

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
        CloseEntityConnection();
    }
    if (rowEffected > 0)
        return true;
    else
        return false;


}

public bool UpdateRecordForManagerConfirm(Hr_EmpAllowanceRecord objUpdate)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();


    int rowEffected = 0;
    try
    {

        if (objUpdate != null) //Definsive Programming
        {
            OpenEntityConnection();
            Hr_EmpAllowanceRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpAllowanceRecord
                                                  where objLinq.Rec_Hdr_Id == objUpdate.Rec_Hdr_Id
                                                  select objLinq).FirstOrDefault();
            if (objUpdate != null)
            {
                ObjForUpdate.ManagerConfirmed = objUpdate.ManagerConfirmed;
                ObjForUpdate.ManagerComment = objUpdate.ManagerComment;
                ObjForUpdate.ManagerCommentDate = objUpdate.ManagerCommentDate;
                ObjForUpdate.DirectManagerEmp_Serial_No = objUpdate.DirectManagerEmp_Serial_No;

                rowEffected = objPharmaEntities.SaveChanges();

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
        CloseEntityConnection();
    }
    if (rowEffected > 0)
        return true;
    else
        return false;


}



public bool UpdateRecordForHRManagerConfirm(Hr_EmpAllowanceRecord objUpdate)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();


    int rowEffected = 0;
    try
    {

        if (objUpdate != null) //Definsive Programming
        {
            OpenEntityConnection();
            Hr_EmpAllowanceRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpAllowanceRecord
                                                  where objLinq.Rec_Hdr_Id == objUpdate.Rec_Hdr_Id
                                                  select objLinq).FirstOrDefault();
            if (objUpdate != null)
            {
                ObjForUpdate.HRMangerConfirmed = objUpdate.HRMangerConfirmed;
                ObjForUpdate.ManagerConfirmed = objUpdate.ManagerConfirmed;
                ObjForUpdate.HRMangerComment = objUpdate.HRMangerComment;
                ObjForUpdate.HRMangerCommentDate = objUpdate.HRMangerCommentDate;
                ObjForUpdate.HrManagerEmp_Serial_No = objUpdate.HrManagerEmp_Serial_No;


                rowEffected = objPharmaEntities.SaveChanges();

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
        CloseEntityConnection();
    }
    if (rowEffected > 0)
        return true;
    else
        return false;


}

public string GetNewId(string strcompanyId, string strBranch_Id)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    string nextId = "0";
    object maxId = null;

    try
    {
        // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
        //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
        //         select anything.Job_Id).Single();
        //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
        //    maxId = cs.Job_Id;

        OpenEntityConnection();

        maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 ReferenceNo  as ReferenceNo  from Hr_EmpVactionRequest where Company_Id ='" + strcompanyId + "' and Branch_Id= '" + strBranch_Id + "'  order by replicate('0',15-len(ReferenceNo))+ReferenceNo desc").FirstOrDefault<string>();

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


public bool AddVactionSetting(List<Hr_RequestTypesDtls> ListDtls)
{
    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    var strErrorMessage = string.Empty;
    //  ObjWorkFlow_HdrDL.InsUser = "5";

    // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
    bool result = true;

    using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
    {
        try
        {
            if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
            {
                objPharmaEntities.Database.Connection.Open();
            }

            string RequestType = ListDtls[0].RequestTypeId.ToString();
            result = DeleteRquestType(RequestType);
            //var objRquestType = (from obj1 in objPharmaEntities.Hr_RequestTypesDtls
            //                     where obj1.RequestTypeId == RequestType
            //            select obj1).First();

            ////Delete it from memory
            //objPharmaEntities.Hr_RequestTypesDtls.Remove(objRquestType);
            ////Save to database
            //objPharmaEntities.SaveChanges();

            foreach (Hr_RequestTypesDtls Obj_Dtls in ListDtls)
            {
                if (Obj_Dtls != null)
                {


                    Hr_RequestTypesDtls loclDtls = new Hr_RequestTypesDtls
                    {


                        RequestTypeId = Obj_Dtls.RequestTypeId,
                        RequestDiscountType = Obj_Dtls.RequestDiscountType,
                        ValueType = Obj_Dtls.ValueType,
                        RequestTypeValue = Obj_Dtls.RequestTypeValue,
                        RequestRatioValue = Obj_Dtls.RequestRatioValue,
                    };
                    objPharmaEntities.Hr_RequestTypesDtls.Add(loclDtls);
                    //saves all above operations within one transaction
                    objPharmaEntities.SaveChanges();
                }
            }


            //commit transaction
            dbTran.Commit();
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
            dbTran.Rollback();
            result = false;

        }

        catch (Exception ex)
        {

            //Rollback transaction if exception occurs
            dbTran.Rollback();
            result = false;


        }



        finally
        {
            objPharmaEntities.Database.Connection.Close();
            dbTran.Dispose();

            if (!string.IsNullOrEmpty(strErrorMessage))
            {
                SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());



            }
        }
        return result;

    }

}

public bool DeleteRquestType(string RequestType)
{
    bool result = false;
    List<Hr_RequestTypesDtls> RequestTypesDtlsToDelete;
    //1. Get student from DB
    using (var ctx = new AthelHREntities())
    {


        RequestTypesDtlsToDelete = ctx.Hr_RequestTypesDtls.Where(s => s.RequestTypeId == RequestType).ToList();
    }

    //Create new context for disconnected scenario
    using (var newContext = new AthelHREntities())
    {

        foreach (Hr_RequestTypesDtls Obj_Dtls in RequestTypesDtlsToDelete)
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




public List<Hr_RequestTypesDtls> SelectAllRequestSetting(string RequestTypeId)
{

    StackFrame stackFrame = new StackFrame();
    MethodBase methodBase = stackFrame.GetMethod();

    try
    {


        OpenEntityConnection();


        List<Hr_RequestTypesDtls> objectList = new List<Hr_RequestTypesDtls>();

        var objlist = (from objLinq in objPharmaEntities.Hr_RequestTypesDtls
                       where objLinq.RequestTypeId == RequestTypeId
                       select new
                       {
                           RequestTypeId = objLinq.RequestTypeId,
                           RequestTypeValue = objLinq.RequestTypeValue,
                           RequestDiscountType = objLinq.RequestDiscountType,
                           RequestRatioValue = objLinq.RequestRatioValue,
                           ValueType = objLinq.ValueType

                       }).ToList();

        foreach (var obj in objlist)
        {
            Hr_RequestTypesDtls objRequestTypesDtlsDL = new Hr_RequestTypesDtls();
            objRequestTypesDtlsDL.RequestTypeId = obj.RequestTypeId;
            objRequestTypesDtlsDL.RequestTypeValue = obj.RequestTypeValue;
            objRequestTypesDtlsDL.RequestDiscountType = obj.RequestDiscountType;
            objRequestTypesDtlsDL.RequestRatioValue = obj.RequestRatioValue;
            objRequestTypesDtlsDL.ValueType = obj.ValueType;
            objectList.Add(objRequestTypesDtlsDL);

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

public int InsertVacRecord(Hr_EmpVactionRecord objInsert)
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

            Guid strhdr;
            strhdr = GetNewHeaderId();
            objInsert.Rec_Hdr_Id = strhdr;
            objInsert.Rec_Order_HdrId = strhdr;
            objInsert.Rec_Order_No = "0";

            objInsert.InsDate = DateTime.Now;//DateTime.Today;

            objPharmaEntities.Hr_EmpVactionRecord.Add(objInsert);
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




    }
}
