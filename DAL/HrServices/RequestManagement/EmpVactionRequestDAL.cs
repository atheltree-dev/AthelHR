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
  public  class EmpVactionRequestDAL:CommonDB

    {
        public  async Task<int> Insert(Hr_EmpVactionRequest objInsert) 
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
        public int InsertTask(Hr_EmpVactionRequest objInsert)
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

                    objPharmaEntities.Hr_EmpVactionRequest.Add(objInsert);
                    RowEffected =  objPharmaEntities.SaveChanges();
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
        public List<EmpVactionRequestDL> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();


                List<EmpVactionRequestDL> objectList = new List<EmpVactionRequestDL>();
                var objlist = (from objLinq in objPharmaEntities.Hr_EmpVactionRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on Convert.ToString(objLinq.Order_Status) equals Reqstatus.RequestStatus_Id
                               select new 
                               {
                                   Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   FromDate = objLinq.FromDate,
                                   ToDate = objLinq.ToDate,
                                   Order_Status = objLinq.Order_Status,
                                   RequestTypeNameEn = ReqType.Request_NameEn,
                                   StatusNameEn = Reqstatus.RequestStatus_NameEn,
                                   RequestTypeName = ReqType.Request_Name,
                                   StatusName = Reqstatus.RequestStatus_Name
                               }).ToList();

                


        
                                    
                foreach (var obj in objlist)
                {
                    EmpVactionRequestDL objEmpVactionRequestDL = new EmpVactionRequestDL();
                    objEmpVactionRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpVactionRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpVactionRequestDL.Request_Id = obj.Request_Id;
                    objEmpVactionRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpVactionRequestDL.FromDate = obj.FromDate;
                    objEmpVactionRequestDL.ToDate = obj.ToDate;
                    objEmpVactionRequestDL.Order_Status = obj.Order_Status;
                    objEmpVactionRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpVactionRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpVactionRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpVactionRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpVactionRequestDL);

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


        public List<EmpVactionRequestDL> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpVactionRequestDL> objectList = new List<EmpVactionRequestDL>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpVactionRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on objLinq.Order_Status equals Reqstatus.RequestStatus_Id
                               where objLinq.Company_Id == strcomapny && objLinq.Branch_Id==strbranch
                               select new 
                               {
                                   Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   FromDate = objLinq.FromDate,
                                   ToDate = objLinq.ToDate,
                                   Reason = objLinq.Reason,
                                   Order_Status = objLinq.Order_Status,
                                   RequestTypeNameEn = ReqType.Request_NameEn,
                                   StatusNameEn = Reqstatus.RequestStatus_NameEn,
                                   RequestTypeName = ReqType.Request_Name,
                                   StatusName = Reqstatus.RequestStatus_Name
                               }).ToList();

                


        
                                    
                foreach (var obj in objlist)
                {
                    EmpVactionRequestDL objEmpVactionRequestDL = new EmpVactionRequestDL();
                    objEmpVactionRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpVactionRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpVactionRequestDL.Request_Id = obj.Request_Id;
                    objEmpVactionRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpVactionRequestDL.FromDate = obj.FromDate;
                    objEmpVactionRequestDL.ToDate = obj.ToDate;
                    objEmpVactionRequestDL.Reason = obj.Reason;
                    objEmpVactionRequestDL.Order_Status = obj.Order_Status;
                    objEmpVactionRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpVactionRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpVactionRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpVactionRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpVactionRequestDL);

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

      


        public EmpBeginVactionRequestDL GetCalcBeginVaction(string CompanyId, string Branch_Id, decimal Emp_Serial_No, string Request_Id, string StartDate,string EndDate)
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

      
        public Hr_EmpVactionRequest GetRequestByHdrId(string strCompanyNo, string strBranchNo, Guid RequestHdrId) 
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();

                string sql = "select Rec_Hdr_Id,ReferenceNo,Request_Id,Rec_No,TransDate,InsUser,InsDate,Company_Id,Branch_Id,";
                sql = sql + " Emp_Serial_No,FromDate,ToDate,BackDate,Reason,PlaceOfResidence,DocumentPath,Order_Status,Commissioner_Serial_no,MessageNotesForEmp,";
                sql = sql + " FreeBalancRequest,ChargeBalancRequest,Contract_Id,ContractPeriod_Id,Vaction_Period,Tot_Transferd_Period,Curr_DiscVac_Period,";
                sql = sql + " Curr_DiscTransferd_Period,Prev_Vaction_Period,CurrAllowedVacTillDate,Vac_Place_Type,Offical_Vaction_Period,VactionFromPrmEffec,AlternativeEmp_Serial";
                sql = sql + " from Hr_EmpVactionRequest where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Rec_Hdr_Id = '" + RequestHdrId + "'";


                Hr_EmpVactionRequest obj = objPharmaEntities.Database.SqlQuery<Hr_EmpVactionRequest>(sql).FirstOrDefault();
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

        public decimal GetMaximumTransferedDays(string Company_Id, string Branch_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            decimal MaxallowedTransferdays = 0;
            try
            {


                OpenEntityConnection();

                var varMaxallowedTransferdays = objPharmaEntities.Database.SqlQuery<decimal>("select MaxallowedTransferdays from App_Settings where Company_Id="+ Company_Id + " and Branch_Id="+ Branch_Id + "").FirstOrDefault<decimal>();


                if (varMaxallowedTransferdays != 0)
                {
                    MaxallowedTransferdays = Convert.ToDecimal(varMaxallowedTransferdays);


                }

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

            return MaxallowedTransferdays;

        }

        public List<EmpTransferVactionSettlementDL> GetRequestDataHdr(string Company_Id, string Branch_Id, decimal Emp_Serial_No  )
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpTransferVactionSettlementDL> objectList = new List<EmpTransferVactionSettlementDL>();


                object[] param1 = {

                new SqlParameter("@Emp_Serial_No", Emp_Serial_No),
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id)


             };


                var objlist = objPharmaEntities.Database.SqlQuery<EmpTransferVactionSettlementDL>("exec dbo.sp_GetTransferVactionSettlementHdr @Emp_Serial_No,@Company_Id,@Branch_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpTransferVactionSettlementDL EmpTransferVactionSettlementDL = new EmpTransferVactionSettlementDL();

                    EmpTransferVactionSettlementDL.LastTransRec_hdr_Id = obj.LastTransRec_hdr_Id;
                    EmpTransferVactionSettlementDL.Emp_Serial_No = obj.Emp_Serial_No;
                    EmpTransferVactionSettlementDL.FullNameArabic = obj.FullNameArabic;
                    EmpTransferVactionSettlementDL.FullNameEn = obj.FullNameEn; 
                    EmpTransferVactionSettlementDL.NoOfRestVacDays = obj.NoOfRestVacDays;
                    EmpTransferVactionSettlementDL.FromStartPeriod = obj.FromStartPeriod;
                    EmpTransferVactionSettlementDL.ToEndPeriod = obj.ToEndPeriod;

                    
                    objectList.Add(EmpTransferVactionSettlementDL);

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

        public List<EmpTransferVactionSettlementDL> GetRequestDataDtls(string Company_Id, string Branch_Id, decimal Emp_Serial_No)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpTransferVactionSettlementDL> objectList = new List<EmpTransferVactionSettlementDL>();


                object[] param1 = {

                new SqlParameter("@Emp_Serial_No", Emp_Serial_No),
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id)


             };


                var objlist = objPharmaEntities.Database.SqlQuery<EmpTransferVactionSettlementDL>("exec dbo.sp_GetTransferVactionSettlementDtls @Emp_Serial_No,@Company_Id,@Branch_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpTransferVactionSettlementDL EmpTransferVactionSettlementDL = new EmpTransferVactionSettlementDL();

                    EmpTransferVactionSettlementDL.LastTransRec_hdr_Id = obj.LastTransRec_hdr_Id;
                    EmpTransferVactionSettlementDL.Emp_Serial_No = obj.Emp_Serial_No;
                    EmpTransferVactionSettlementDL.FullNameArabic = obj.FullNameArabic;
                    EmpTransferVactionSettlementDL.FullNameEn = obj.FullNameEn;
                    EmpTransferVactionSettlementDL.NoOfRestVacDays = obj.NoOfRestVacDays;
                    EmpTransferVactionSettlementDL.FromStartPeriod = obj.FromStartPeriod;
                    EmpTransferVactionSettlementDL.ToEndPeriod = obj.ToEndPeriod;
                    EmpTransferVactionSettlementDL.NoOfDeservedDays = obj.NoOfDeservedDays;
                    EmpTransferVactionSettlementDL.NoOfVacDays = obj.NoOfVacDays;
                    EmpTransferVactionSettlementDL.ContractPeriod_Id = obj.ContractPeriod_Id;
                    EmpTransferVactionSettlementDL.Contract_Id = obj.Contract_Id;



                    objectList.Add(EmpTransferVactionSettlementDL);

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


        public bool SaveData(List<EmpTransferVactionSettlementDL> objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();

                    foreach (var obj in objUpdate)
                    {
                        Hr_EmployeeContractPeriods ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmployeeContractPeriods
                                                                   where objLinq.Company_Id == obj.Company_Id && objLinq.Branch_Id == obj.Branch_Id
                                                                   && objLinq.ContractPeriod_Id == obj.ContractPeriod_Id
                                                                   select objLinq).FirstOrDefault();
                        ObjForUpdate.NoOfDeservedDays = obj.NoOfRestVacDays;
                        ObjForUpdate.NoOfVacDays = 0;
                        


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
        //public bool UpdateTask(Hr_EmpVactionRequest objUpdate)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //   // bool task = Update(objInsert).Result;
        //    //return task;
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

        //            rowEffected =  objPharmaEntities.SaveChanges();
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
                    objInsert.Rec_Hdr_Id =strhdr;
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
