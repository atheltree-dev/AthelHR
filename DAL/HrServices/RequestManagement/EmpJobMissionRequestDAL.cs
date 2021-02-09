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
  public  class EmpJobMissionRequestDAL:CommonDB

    {

      public class EmpPermissionStatusDL
      {
          public string ResultStatus { get; set; }

          public string ResultMessage { get; set; }

      }

        public  async Task<int> Insert(Hr_EmpJobMissionRequest objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_EmpJobMissionRequest.Add(objInsert);
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
        public int InsertTask(Hr_EmpJobMissionRequest objInsert)
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

                    objPharmaEntities.Hr_EmpJobMissionRequest.Add(objInsert);
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
        public List<EmpJobMissionRequestDL> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();


                List<EmpJobMissionRequestDL> objectList = new List<EmpJobMissionRequestDL>();
                var objlist = (from objLinq in objPharmaEntities.Hr_EmpJobMissionRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on Convert.ToString(objLinq.Order_Status) equals Reqstatus.RequestStatus_Id
                               select new 
                               {
                                   Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   PermissionDate = objLinq.PermissionDate,
                                   FromTime = objLinq.FromTime,
                                   ToTime = objLinq.ToTime,
                                   Order_Status = objLinq.Order_Status,
                                   RequestTypeNameEn = ReqType.Request_NameEn,
                                   StatusNameEn = Reqstatus.RequestStatus_NameEn,
                                   RequestTypeName = ReqType.Request_Name,
                                   StatusName = Reqstatus.RequestStatus_Name
                               }).ToList();

                


        
                                    
                foreach (var obj in objlist)
                {
                    EmpJobMissionRequestDL objEmpJobMissionRequestDL = new EmpJobMissionRequestDL();
                    objEmpJobMissionRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpJobMissionRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpJobMissionRequestDL.Request_Id = obj.Request_Id;
                    objEmpJobMissionRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpJobMissionRequestDL.PermissionDate = obj.PermissionDate;
                    objEmpJobMissionRequestDL.FromTime = obj.FromTime;
                    objEmpJobMissionRequestDL.ToTime = obj.ToTime;
                    objEmpJobMissionRequestDL.Order_Status = obj.Order_Status;
                    objEmpJobMissionRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpJobMissionRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpJobMissionRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpJobMissionRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpJobMissionRequestDL);

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


        public List<EmpJobMissionRequestDL> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpJobMissionRequestDL> objectList = new List<EmpJobMissionRequestDL>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpJobMissionRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on objLinq.Order_Status equals Reqstatus.RequestStatus_Id
                               where objLinq.Company_Id == strcomapny && objLinq.Branch_Id==strbranch
                               select new 
                               {
                                   Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   PermissionDate = objLinq.PermissionDate,
                                   FromTime = objLinq.FromTime,
                                   ToTime = objLinq.ToTime,
                                   Reason = objLinq.Reason,
                                   MessageNotesForEmp = objLinq.MessageNotesForEmp,
                                   
                                   Order_Status = objLinq.Order_Status,
                                   RequestTypeNameEn = ReqType.Request_NameEn,
                                   StatusNameEn = Reqstatus.RequestStatus_NameEn,
                                   RequestTypeName = ReqType.Request_Name,
                                   StatusName = Reqstatus.RequestStatus_Name
                               }).ToList();

                


        
                                    
                foreach (var obj in objlist)
                {
                    EmpJobMissionRequestDL objEmpJobMissionRequestDL = new EmpJobMissionRequestDL();
                    objEmpJobMissionRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpJobMissionRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpJobMissionRequestDL.Request_Id = obj.Request_Id;
                    objEmpJobMissionRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpJobMissionRequestDL.PermissionDate = obj.PermissionDate;
                    objEmpJobMissionRequestDL.FromTime = obj.FromTime;
                    objEmpJobMissionRequestDL.ToTime = obj.ToTime;
                    objEmpJobMissionRequestDL.Reason = obj.Reason;
                    objEmpJobMissionRequestDL.MessageNotesForEmp = obj.MessageNotesForEmp;
                    
                    objEmpJobMissionRequestDL.Order_Status = obj.Order_Status;
                    objEmpJobMissionRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpJobMissionRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpJobMissionRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpJobMissionRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpJobMissionRequestDL);

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

        public bool chkPermissionIndivisible(string strRequestType)
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
      


        public Hr_EmpJobMissionRequest GetRequestByHdrId(string strCompanyNo, string strBranchNo, Guid RequestHdrId) 
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                

                OpenEntityConnection();

                string sql = "select Rec_Hdr_Id,ReferenceNo,Request_Id,Rec_No,TransDate,InsUser,InsDate,Company_Id,Branch_Id";
                sql = sql + ",Emp_Serial_No,PermissionDate,FromTime,ToTime,Reason,DocumentPath,Order_Status,Commissioner_Serial_no,MessageNotesForEmp";
                sql = sql + ",Contract_Id,ContractPeriod_Id";
                sql = sql + " from Hr_EmpJobMissionRequest where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Rec_Hdr_Id = '" + RequestHdrId + "'";


                Hr_EmpJobMissionRequest obj = objPharmaEntities.Database.SqlQuery<Hr_EmpJobMissionRequest>(sql).FirstOrDefault();
                return obj;

             //  EmpJobMissionRequestDL objectList = new EmpJobMissionRequestDL();

                //Hr_EmpJobMissionRequest obj = (from objLinq in objPharmaEntities.Hr_EmpJobMissionRequest
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


                //Hr_EmpJobMissionRequest obj = objPharmaEntities.Hr_EmpJobMissionRequest
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

      


        //public async Task<bool> Update(Hr_EmpJobMissionRequest objUpdate)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    int rowEffected = 0;
        //    try
        //    {
        //        if (objUpdate != null) //Definsive Programming
        //        {
        //            OpenEntityConnection();
        //            Hr_EmpJobMissionRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpJobMissionRequest
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
        //public bool UpdateTask(Hr_EmpJobMissionRequest objUpdate)
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
        //            Hr_EmpJobMissionRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpJobMissionRequest
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

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 ReferenceNo  as ReferenceNo  from Hr_EmpJobMissionRequest where Company_Id ='" + strcompanyId + "' and Branch_Id= '" + strBranch_Id + "'  order by replicate('0',15-len(ReferenceNo))+ReferenceNo desc").FirstOrDefault<string>();
              
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

        //public Hr_EmpPermission_Settings GetPermmissionSettingDataByBranchandCompany(string strCompany_Id, string strBranch_Id)
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();


        //    try
        //    {
        //        OpenEntityConnection();

        //        Hr_EmpPermission_Settings ObjEmpPermission_Settings = (from objLinq in objPharmaEntities.Hr_EmpPermission_Settings
        //                                          where objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id
        //                                          select objLinq).FirstOrDefault();

        //        if (ObjEmpPermission_Settings != null)
        //        {
        //            Hr_EmpPermission_Settings objEmpPermission_SettingsDL = new Hr_EmpPermission_Settings();

        //            {
        //                objEmpPermission_SettingsDL.Branch_Id = ObjEmpPermission_Settings.Branch_Id;
        //                objEmpPermission_SettingsDL.Company_Id = ObjEmpPermission_Settings.Company_Id;
        //                objEmpPermission_SettingsDL.AllowedValueInMonthByHour = ObjEmpPermission_Settings.AllowedValueInMonthByHour;
        //                objEmpPermission_SettingsDL.AllowedValueInDayByHour = ObjEmpPermission_Settings.AllowedValueInDayByHour;
        //                objEmpPermission_SettingsDL.PeriodForDay = ObjEmpPermission_Settings.PeriodForDay;
        //                objEmpPermission_SettingsDL.HourNoForDiscount = ObjEmpPermission_Settings.HourNoForDiscount;
        //                objEmpPermission_SettingsDL.AllowToExceedMonthValue = ObjEmpPermission_Settings.AllowToExceedMonthValue;
        //                objEmpPermission_SettingsDL.AllowToExceedDayValue = ObjEmpPermission_Settings.AllowToExceedDayValue;
        //                objEmpPermission_SettingsDL.OnlyApplyDiscount = ObjEmpPermission_Settings.OnlyApplyDiscount;
                        
                        
                            
                        
        //            }
        //            return objEmpPermission_SettingsDL;
        //        }
        //        else
        //        {
        //            return null;
        //        }




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


        //public bool SavePermmissionSettingData(Hr_EmpPermission_Settings objList)
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();


        //    try
        //    {
        //        OpenEntityConnection();


        //        int Result = 0;
        //     //   string emSerialNo = (objList.EmpSerialForDocNotify == null ? 0 : objList.EmpSerialForDocNotify).ToString();



        //        Hr_EmpPermission_Settings ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpPermission_Settings
        //                                     where objLinq.Company_Id == objList.Company_Id && objLinq.Branch_Id == objList.Branch_Id
        //                                     select objLinq).FirstOrDefault();
        //        if (ObjForUpdate != null)
        //        {
        //            ObjForUpdate.AllowedValueInMonthByHour = objList.AllowedValueInMonthByHour;
        //            ObjForUpdate.AllowedValueInDayByHour = objList.AllowedValueInDayByHour;
        //            ObjForUpdate.PeriodForDay = objList.PeriodForDay;
        //            ObjForUpdate.HourNoForDiscount = objList.HourNoForDiscount;

        //            ObjForUpdate.AllowToExceedMonthValue = objList.AllowToExceedMonthValue;
        //            ObjForUpdate.AllowToExceedDayValue = objList.AllowToExceedDayValue;
        //            ObjForUpdate.OnlyApplyDiscount = objList.OnlyApplyDiscount;
                    

                    

        //            Result = objPharmaEntities.SaveChanges();

        //            return (Result > 0);
        //        }
        //        else
        //        {
        //            if (objList != null)
        //            {
        //                Hr_EmpPermission_Settings loclDtls = new Hr_EmpPermission_Settings
        //                {
        //                    Branch_Id = objList.Branch_Id,
        //                    Company_Id = objList.Company_Id,
        //                    AllowedValueInMonthByHour = objList.AllowedValueInMonthByHour,
        //                    AllowedValueInDayByHour = objList.AllowedValueInDayByHour,
        //                    PeriodForDay = objList.PeriodForDay,
        //                    HourNoForDiscount = objList.HourNoForDiscount,
        //                    AllowToExceedMonthValue = objList.AllowToExceedMonthValue,
        //                    AllowToExceedDayValue = objList.AllowToExceedDayValue,
        //                    OnlyApplyDiscount = objList.OnlyApplyDiscount,
                          


        //                };

        //                objPharmaEntities.Hr_EmpPermission_Settings.Add(loclDtls);
        //                //saves all above operations within one transaction
        //                Result = objPharmaEntities.SaveChanges();
        //                return (Result > 0);

        //            }
        //            else
        //                return false;

        //        }
 
                   

        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //        return false;

        //    }
        //    finally
        //    {
        //        CloseEntityConnection();
        //    }


        //}
        public EmpPermissionStatusDL GetEmpPermissionAvailablity(string Company_Id, string Branch_Id, decimal EmpSerial_No, string FromTime, string ToTime, string PermissionDuesDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                EmpPermissionStatusDL objectList = new EmpPermissionStatusDL();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_no", EmpSerial_No),
                new SqlParameter("@FromTime", FromTime),
                new SqlParameter("@ToTime", ToTime),
                new SqlParameter("@PermissionDuesDate", PermissionDuesDate)};



                var objlist = objPharmaEntities.Database.SqlQuery<EmpPermissionStatusDL>("exec dbo.ChkEmpPermissionAvailablity @Company_Id,@Branch_Id,@Emp_Serial_no,@FromTime,@ToTime,@PermissionDuesDate", param1).FirstOrDefault();
                if (objlist != null)
                {
                    EmpPermissionStatusDL objEmpBorrowStatusDL = new EmpPermissionStatusDL();
                    objEmpBorrowStatusDL.ResultStatus = objlist.ResultStatus;
                    objEmpBorrowStatusDL.ResultMessage = objlist.ResultMessage;
                    return objEmpBorrowStatusDL;
                }
                else

                    return null;

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




    }
}
