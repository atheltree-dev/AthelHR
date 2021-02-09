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
namespace DAL.HrServices.RequestManagement
{
  public  class EmpAccomdationFeeFollowupDAL:CommonDB

    {
       public class EmpAccomdationFeeDetailDL
      {
          public string TransItemDate { get; set; }

          public decimal HireItem_Value { get; set; }
          public string Notes { get; set; }
           

      }

       public class EmpAccomdationFeeStatusDL
       {
           public string ResultStatus { get; set; }

           public string ResultMessage { get; set; }

       }


        //public  async Task<int> Insert(Hr_EmpAccomdationFeeRequest objInsert) 
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    int RowEffected = 0;
        //    try
        //    {
        //        if (objInsert != null)
        //        {
        //            OpenEntityConnection();
        //            objInsert.InsDate = DateTime.Now;//DateTime.Today;
                    
                    
        //            objPharmaEntities.Hr_EmpAccomdationFeeRequest.Add(objInsert);
        //            RowEffected = await objPharmaEntities.SaveChangesAsync();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString()); 
        //        RowEffected = -1;
        //        ex.InnerException.Message.ToString();


        //    }
        //    finally 
        //    {
        //        CloseEntityConnection();
        //    }
        //    return RowEffected;   
        //}


        // Calling the method of using Async
        //public  int test() {
        //    int task =  Insert().Result;
        //    return task;
         
        //}
        //public int InsertTask(Hr_EmpAccomdationFeeRequest objInsert)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    //int result = Insert(objInsert).Result;
        //    //return result;

        //    int RowEffected = 0;
        //    try
        //    {
        //        if (objInsert != null)
        //        {
        //            OpenEntityConnection();
                    

        //            objInsert.Rec_Hdr_Id = GetNewHeaderId();
        //            objInsert.InsDate = DateTime.Now;//DateTime.Today;

        //            objPharmaEntities.Hr_EmpAccomdationFeeRequest.Add(objInsert);
        //            RowEffected =  objPharmaEntities.SaveChanges();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        RowEffected = -1;
        //        ex.InnerException.Message.ToString();


        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }
        //    return RowEffected;


        //}
        //public List<EmpAccomdationFeeRequestDL> GetAll()
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {
        //        OpenEntityConnection();


        //        List<EmpAccomdationFeeRequestDL> objectList = new List<EmpAccomdationFeeRequestDL>();
        //        var objlist = (from objLinq in objPharmaEntities.Hr_EmpAccomdationFeeRequest
        //                       join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
        //                       join Reqstatus in objPharmaEntities.Hr_RequestStatus on Convert.ToString(objLinq.Order_Status) equals Reqstatus.RequestStatus_Id
        //                       select new 
        //                       {
        //                           Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
        //                           ReferenceNo = objLinq.ReferenceNo,
        //                           Request_Id = objLinq.Request_Id,
        //                           Emp_Serial_No = objLinq.Emp_Serial_No,
        //                           AccomdationFeeStartDate = objLinq.AccomdationFeeStartDate,
        //                           AccomdationFee_Value = objLinq.AccomdationFee_Value,
        //                           AccomdationFee_Period = objLinq.AccomdationFee_Period,
        //                           AccomdationFee_MonthValue = objLinq.AccomdationFee_MonthValue,
        //                           AccomdationFeeDuesDate = objLinq.AccomdationFeeDuesDate,
        //                           Order_Status = objLinq.Order_Status,
        //                           MessageNotesForEmp=objLinq.MessageNotesForEmp,
        //                           RequestTypeNameEn = ReqType.Request_NameEn,
        //                           StatusNameEn = Reqstatus.RequestStatus_NameEn,
        //                           RequestTypeName = ReqType.Request_Name,
        //                           StatusName = Reqstatus.RequestStatus_Name
        //                       }).ToList();

                


        
                                    
        //        foreach (var obj in objlist)
        //        {
        //            EmpAccomdationFeeRequestDL objEmpAccomdationFeeRequestDL = new EmpAccomdationFeeRequestDL();
        //            objEmpAccomdationFeeRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
        //            objEmpAccomdationFeeRequestDL.ReferenceNo = obj.ReferenceNo;
        //            objEmpAccomdationFeeRequestDL.Request_Id = obj.Request_Id;
        //            objEmpAccomdationFeeRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
        //            objEmpAccomdationFeeRequestDL.AccomdationFeeStartDate = obj.AccomdationFeeStartDate;
        //            objEmpAccomdationFeeRequestDL.AccomdationFee_Value = obj.AccomdationFee_Value;
        //            objEmpAccomdationFeeRequestDL.AccomdationFee_Period = obj.AccomdationFee_Period;
        //            objEmpAccomdationFeeRequestDL.AccomdationFee_MonthValue = obj.AccomdationFee_MonthValue;
        //            objEmpAccomdationFeeRequestDL.AccomdationFeeDuesDate = obj.AccomdationFeeDuesDate;
        //            objEmpAccomdationFeeRequestDL.MessageNotesForEmp = obj.MessageNotesForEmp;
        //            objEmpAccomdationFeeRequestDL.Order_Status = obj.Order_Status;
        //            objEmpAccomdationFeeRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
        //            objEmpAccomdationFeeRequestDL.StatusNameEn = obj.StatusNameEn;
        //            objEmpAccomdationFeeRequestDL.RequestTypeName = obj.RequestTypeName;
        //            objEmpAccomdationFeeRequestDL.StatusName = obj.StatusName;
        //            objectList.Add(objEmpAccomdationFeeRequestDL);

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


        //public List<EmpAccomdationFeeRequestDL> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {


        //        OpenEntityConnection();


        //        List<EmpAccomdationFeeRequestDL> objectList = new List<EmpAccomdationFeeRequestDL>();

        //        var objlist = (from objLinq in objPharmaEntities.Hr_EmpAccomdationFeeRequest
        //                       join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
        //                       join Reqstatus in objPharmaEntities.Hr_RequestStatus on objLinq.Order_Status equals Reqstatus.RequestStatus_Id
        //                       where objLinq.Company_Id == strcomapny && objLinq.Branch_Id==strbranch
        //                       select new 
        //                       {
        //                           Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
        //                           ReferenceNo = objLinq.ReferenceNo,
        //                           Request_Id = objLinq.Request_Id,
        //                           Emp_Serial_No = objLinq.Emp_Serial_No,
        //                           AccomdationFeeStartDate = objLinq.AccomdationFeeStartDate,
        //                           AccomdationFee_Value = objLinq.AccomdationFee_Value,
        //                           AccomdationFee_Period = objLinq.AccomdationFee_Period,
        //                           AccomdationFee_MonthValue = objLinq.AccomdationFee_MonthValue,
        //                           Reason = objLinq.Reason,
        //                           MessageNotesForEmp = objLinq.MessageNotesForEmp,
        //                           AccomdationFeeDuesDate = objLinq.AccomdationFeeDuesDate,
        //                           Order_Status = objLinq.Order_Status,
        //                           RequestTypeNameEn = ReqType.Request_NameEn,
        //                           StatusNameEn = Reqstatus.RequestStatus_NameEn,
        //                           RequestTypeName = ReqType.Request_Name,
        //                           StatusName = Reqstatus.RequestStatus_Name
        //                       }).ToList();

                


        
                                    
        //        foreach (var obj in objlist)
        //        {
        //            EmpAccomdationFeeRequestDL objEmpAccomdationFeeRequestDL = new EmpAccomdationFeeRequestDL();
        //            objEmpAccomdationFeeRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
        //            objEmpAccomdationFeeRequestDL.ReferenceNo = obj.ReferenceNo;
        //            objEmpAccomdationFeeRequestDL.Request_Id = obj.Request_Id;
        //            objEmpAccomdationFeeRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
        //            objEmpAccomdationFeeRequestDL.AccomdationFeeStartDate = obj.AccomdationFeeStartDate;
        //            objEmpAccomdationFeeRequestDL.AccomdationFee_Value = obj.AccomdationFee_Value;
        //            objEmpAccomdationFeeRequestDL.AccomdationFee_Period = obj.AccomdationFee_Period;
        //            objEmpAccomdationFeeRequestDL.AccomdationFee_MonthValue = obj.AccomdationFee_MonthValue;
        //            objEmpAccomdationFeeRequestDL.Reason = obj.Reason;
        //            objEmpAccomdationFeeRequestDL.AccomdationFeeDuesDate = obj.AccomdationFeeDuesDate;
        //            objEmpAccomdationFeeRequestDL.MessageNotesForEmp = obj.MessageNotesForEmp;
        //            objEmpAccomdationFeeRequestDL.Order_Status = obj.Order_Status;
        //            objEmpAccomdationFeeRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
        //            objEmpAccomdationFeeRequestDL.StatusNameEn = obj.StatusNameEn;
        //            objEmpAccomdationFeeRequestDL.RequestTypeName = obj.RequestTypeName;
        //            objEmpAccomdationFeeRequestDL.StatusName = obj.StatusName;
        //            objectList.Add(objEmpAccomdationFeeRequestDL);

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

        //public bool chkAccomdationFeeIndivisible(string strRequestType)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    bool Result = false;
        

        //    try
        //    {
        //        // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
        //        //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
        //        //         select anything.Job_Id).Single();
        //        //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
        //        //    maxId = cs.Job_Id;

        //        OpenEntityConnection();
        //    var chkResult = (from obj in objPharmaEntities.Hr_RequestTypes
        //                    where obj.Request_Id == strRequestType 
        //                    select obj.VactionIndivisible).FirstOrDefault();


        //    if (chkResult != null)
        //        {
        //            Result = Convert.ToInt16(chkResult) > 0;

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }
        //    return Result;

        //}

        //public bool chkHasAttach(string strRequestType)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    bool Result = false;
        

        //    try
        //    {
        //        // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
        //        //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
        //        //         select anything.Job_Id).Single();
        //        //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
        //        //    maxId = cs.Job_Id;

        //        OpenEntityConnection();
        //    var chkResult = (from obj in objPharmaEntities.Hr_RequestTypes
        //                    where obj.Request_Id == strRequestType 
        //                    select obj.AttachIsNecessary).FirstOrDefault();


        //    if (chkResult != null)
        //        {
        //            Result = Convert.ToInt16(chkResult) > 0;

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }
        //    return Result;

        //}
      


        //public Hr_EmpAccomdationFeeRequest GetRequestByHdrId(string strCompanyNo, string strBranchNo, Guid RequestHdrId) 
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {

                
        //        OpenEntityConnection();

        //        string sql = "select Rec_Hdr_Id,ReferenceNo,Request_Id,Rec_No,TransDate,InsUser,InsDate,Company_Id,Branch_Id";
        //        sql = sql + ",Emp_Serial_No,AccomdationFeeStartDate,AccomdationFee_Value,AccomdationFee_Period,AccomdationFee_MonthValue,Reason,DocumentPath,Order_Status,Commissioner_Serial_no,AccomdationFeeDuesDate,MessageNotesForEmp";
        //        sql = sql + ",Contract_Id,ContractPeriod_Id";
        //        sql = sql + " from Hr_EmpAccomdationFeeRequest where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Rec_Hdr_Id = '" + RequestHdrId + "'";


        //        Hr_EmpAccomdationFeeRequest obj = objPharmaEntities.Database.SqlQuery<Hr_EmpAccomdationFeeRequest>(sql).FirstOrDefault();
        //        return obj;



           
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

      


        //public async Task<bool> Update(Hr_EmpAccomdationFeeRequest objUpdate)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    int rowEffected = 0;
        //    try
        //    {
        //        if (objUpdate != null) //Definsive Programming
        //        {
        //            OpenEntityConnection();
        //            Hr_EmpAccomdationFeeRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpAccomdationFeeRequest
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
        //public bool UpdateTask(Hr_EmpAccomdationFeeRequest objUpdate)
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
        //            Hr_EmpAccomdationFeeRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpAccomdationFeeRequest
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



        //public string GetNewId(string strcompanyId, string strBranch_Id)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    string nextId = "0";
        //     object maxId = null;

        //    try
        //    {
        //        // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Jobs_SelectMaxId");
        //        //maxId = (from anything in objPharmaEntities.SP_Hr_Jobs_SelectMaxId()
        //        //         select anything.Job_Id).Single();
        //        //foreach (Hr_Jobs cs in objPharmaEntities.Hr_Jobs)
        //        //    maxId = cs.Job_Id;

        //        OpenEntityConnection();

        //        maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 ReferenceNo  as ReferenceNo  from Hr_EmpAccomdationFeeRequest where Company_Id ='" + strcompanyId + "' and Branch_Id= '" + strBranch_Id + "'  order by replicate('0',15-len(ReferenceNo))+ReferenceNo desc").FirstOrDefault<string>();
              
        //        if (maxId != null)
        //        {
        //            nextId = maxId.ToString();

                
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }
        //    return nextId;
        //}

      


      


        public List<EmpAccomdationFeeFollowUpDL> GetEmpAccomdationFeeFollowUp(string Company_Id, string Branch_Id, string FromDate, string ToDate, decimal EmpSerial_No) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {

                OpenEntityConnection();


                List<EmpAccomdationFeeFollowUpDL> objectList = new List<EmpAccomdationFeeFollowUpDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@EmpSerialNo", EmpSerial_No)};

                var objlist = objPharmaEntities.Database.SqlQuery<EmpAccomdationFeeFollowUpDL>("exec dbo.SPGetEmpAccomdationFeeFollowUp @Company_Id,@Branch_Id,@FromDate,@ToDate,@EmpSerialNo", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpAccomdationFeeFollowUpDL objEmpAccomdationFeeFollowUpDL = new EmpAccomdationFeeFollowUpDL();

                    objEmpAccomdationFeeFollowUpDL.Hdr_IdCol = obj.Hdr_IdCol;
                    objEmpAccomdationFeeFollowUpDL.AccomdationFeeDuesDateCol = obj.AccomdationFeeDuesDateCol;

                    objEmpAccomdationFeeFollowUpDL.AccomdationFeeStartDateCol = obj.AccomdationFeeStartDateCol;
                    objEmpAccomdationFeeFollowUpDL.AccomdationFee_PeriodCol = obj.AccomdationFee_PeriodCol;
                    objEmpAccomdationFeeFollowUpDL.AccomdationFeeEndDateCol = obj.AccomdationFeeEndDateCol;
                    objEmpAccomdationFeeFollowUpDL.AccomdationFee_ValueCol = obj.AccomdationFee_ValueCol;
                    objEmpAccomdationFeeFollowUpDL.AccomdationFee_MonthValueCol = obj.AccomdationFee_MonthValueCol;
                    objEmpAccomdationFeeFollowUpDL.AccomdationFee_ValueCreditTillnowCol = obj.AccomdationFee_ValueCreditTillnowCol;
                    objEmpAccomdationFeeFollowUpDL.EmpSerialNoCol = obj.EmpSerialNoCol;
                    objEmpAccomdationFeeFollowUpDL.EmpAccomdationFee_StatusCol = obj.EmpAccomdationFee_StatusCol;

                    objectList.Add(objEmpAccomdationFeeFollowUpDL);

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

        public List<EmpAccomdationFeeDetailDL> GetEmpAccomdationFeeCreditDetails(string Company_Id, string Branch_Id, decimal EmpSerial_No, Guid RecRequestHdr_Id)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<EmpAccomdationFeeDetailDL> objectList = new List<EmpAccomdationFeeDetailDL>();

              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_No", EmpSerial_No),
                new SqlParameter("@RecRequestHdr_Id", RecRequestHdr_Id)};



              var objlist = objPharmaEntities.Database.SqlQuery<EmpAccomdationFeeDetailDL>("exec dbo.SPGetEmpAccomdationFeeCreditDetails @Company_Id,@Branch_Id,@Emp_Serial_No,@RecRequestHdr_Id", param1).ToList();

              foreach (var obj in objlist)
              {
                  EmpAccomdationFeeDetailDL objEmpAccomdationFeeDetailDL = new EmpAccomdationFeeDetailDL();
                  objEmpAccomdationFeeDetailDL.TransItemDate = obj.TransItemDate;
                  objEmpAccomdationFeeDetailDL.HireItem_Value = obj.HireItem_Value;
                  objEmpAccomdationFeeDetailDL.Notes = obj.Notes;
                  
                  objectList.Add(objEmpAccomdationFeeDetailDL);

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

        //public EmpAccomdationFeeStatusDL GetEmpAccomdationFeeAvailablity(string Company_Id, string Branch_Id, decimal EmpSerial_No, decimal RquiredAccomdationFeeValue, string AccomdationFeeDuesDate)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {


        //        OpenEntityConnection();


        //        EmpAccomdationFeeStatusDL objectList = new EmpAccomdationFeeStatusDL();

        //        object[] param1 = { 
        //        new SqlParameter("@Company_Id",Company_Id),
        //        new SqlParameter("@Branch_Id", Branch_Id),
        //        new SqlParameter("@Emp_Serial_no", EmpSerial_No),
        //        new SqlParameter("@RquiredAccomdationFeeValue", RquiredAccomdationFeeValue),
        //        new SqlParameter("@AccomdationFeeDuesDate", AccomdationFeeDuesDate)};



        //        var objlist = objPharmaEntities.Database.SqlQuery<EmpAccomdationFeeStatusDL>("exec dbo.ChkEmpAccomdationFeeAvailablity @Company_Id,@Branch_Id,@Emp_Serial_no,@RquiredAccomdationFeeValue,@AccomdationFeeDuesDate", param1).FirstOrDefault();
        //        if (objlist != null)
        //        {
        //            EmpAccomdationFeeStatusDL objEmpAccomdationFeeStatusDL = new EmpAccomdationFeeStatusDL();
        //            objEmpAccomdationFeeStatusDL.ResultStatus = objlist.ResultStatus;
        //            objEmpAccomdationFeeStatusDL.ResultMessage = objlist.ResultMessage;
        //            return objEmpAccomdationFeeStatusDL;
        //        }
        //        else

        //            return null;

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



      


    }
}
