using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HrServices.RequestManagement;
using BOL;
using System.Data;
using System.Data.SqlClient;
namespace DAL.HrServices.RequestManagement
{
  public  class EmpBorrowDelayRequestDAL:CommonDB

    {

      public class EmpBorrowDelayStatusDL
      {
          public string ResultStatus { get; set; }

          public string ResultMessage { get; set; }

      }

        public  async Task<int> Insert(Hr_EmpBorrowDelayRequest objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_EmpBorrowDelayRequest.Add(objInsert);
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
        public int InsertTask(Hr_EmpBorrowDelayRequest objInsert)
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

                    objPharmaEntities.Hr_EmpBorrowDelayRequest.Add(objInsert);
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
        public List<EmpBorrowDelayRequestDL> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();


                List<EmpBorrowDelayRequestDL> objectList = new List<EmpBorrowDelayRequestDL>();
                var objlist = (from objLinq in objPharmaEntities.Hr_EmpBorrowDelayRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on Convert.ToString(objLinq.Order_Status) equals Reqstatus.RequestStatus_Id
                               select new 
                               {
                                   Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   Borrow_Month_No = objLinq.Borrow_Month_No,
                                   BorrowName = objLinq.BorrowName,
                                   BorrowHdr_Id = objLinq.BorrowHdr_Id,
                                   Borrow_Month_Dtls = objLinq.Borrow_Month_Dtls,
                                   Order_Status = objLinq.Order_Status,
                                   RequestTypeNameEn = ReqType.Request_NameEn,
                                   StatusNameEn = Reqstatus.RequestStatus_NameEn,
                                   RequestTypeName = ReqType.Request_Name,
                                   StatusName = Reqstatus.RequestStatus_Name
                               }).ToList();

                


        
                                    
                foreach (var obj in objlist)
                {
                    EmpBorrowDelayRequestDL objEmpBorrowDelayRequestDL = new EmpBorrowDelayRequestDL();
                    objEmpBorrowDelayRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpBorrowDelayRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpBorrowDelayRequestDL.Request_Id = obj.Request_Id;
                    objEmpBorrowDelayRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpBorrowDelayRequestDL.Borrow_Month_No = obj.Borrow_Month_No;
                    objEmpBorrowDelayRequestDL.BorrowName = obj.BorrowName;
                    objEmpBorrowDelayRequestDL.BorrowHdr_Id = obj.BorrowHdr_Id;
                    objEmpBorrowDelayRequestDL.Borrow_Month_Dtls = obj.Borrow_Month_Dtls;
                    objEmpBorrowDelayRequestDL.Order_Status = obj.Order_Status;
                    objEmpBorrowDelayRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpBorrowDelayRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpBorrowDelayRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpBorrowDelayRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpBorrowDelayRequestDL);

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


        public List<EmpBorrowDelayRequestDL> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpBorrowDelayRequestDL> objectList = new List<EmpBorrowDelayRequestDL>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpBorrowDelayRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on objLinq.Order_Status equals Reqstatus.RequestStatus_Id
                               where objLinq.Company_Id == strcomapny && objLinq.Branch_Id==strbranch
                               select new 
                               {
                                   Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   Borrow_Month_No = objLinq.Borrow_Month_No,
                                   BorrowName = objLinq.BorrowName,
                                   BorrowHdr_Id = objLinq.BorrowHdr_Id,
                                   Borrow_Month_Dtls = objLinq.Borrow_Month_Dtls,
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
                    EmpBorrowDelayRequestDL objEmpBorrowDelayRequestDL = new EmpBorrowDelayRequestDL();
                    objEmpBorrowDelayRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpBorrowDelayRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpBorrowDelayRequestDL.Request_Id = obj.Request_Id;
                    objEmpBorrowDelayRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpBorrowDelayRequestDL.Borrow_Month_No = obj.Borrow_Month_No;
                    objEmpBorrowDelayRequestDL.BorrowHdr_Id = obj.BorrowHdr_Id;
                    objEmpBorrowDelayRequestDL.Borrow_Month_Dtls = obj.Borrow_Month_Dtls;
                    objEmpBorrowDelayRequestDL.Reason = obj.Reason;
                    objEmpBorrowDelayRequestDL.MessageNotesForEmp = obj.MessageNotesForEmp;
                    objEmpBorrowDelayRequestDL.BorrowName = obj.BorrowName;
                    objEmpBorrowDelayRequestDL.Order_Status = obj.Order_Status;
                    objEmpBorrowDelayRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpBorrowDelayRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpBorrowDelayRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpBorrowDelayRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpBorrowDelayRequestDL);

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

        public bool chkBorrowDelayIndivisible(string strRequestType)
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
      


        public Hr_EmpBorrowDelayRequest GetRequestByHdrId(string strCompanyNo, string strBranchNo, Guid RequestHdrId) 
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                

                OpenEntityConnection();

                string sql = "select Rec_Hdr_Id,ReferenceNo,Request_Id,Rec_No,TransDate,InsUser,InsDate,Company_Id,Branch_Id";
                sql = sql + ",Emp_Serial_No,Borrow_Month_No,BorrowName,BorrowHdr_Id,Borrow_Month_Dtls,Reason,DocumentPath,Order_Status,Commissioner_Serial_no,MessageNotesForEmp";
                sql = sql + " from Hr_EmpBorrowDelayRequest where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Rec_Hdr_Id = '" + RequestHdrId + "'";


                Hr_EmpBorrowDelayRequest obj = objPharmaEntities.Database.SqlQuery<Hr_EmpBorrowDelayRequest>(sql).FirstOrDefault();
                return obj;

             //  EmpBorrowDelayRequestDL objectList = new EmpBorrowDelayRequestDL();

                //Hr_EmpBorrowDelayRequest obj = (from objLinq in objPharmaEntities.Hr_EmpBorrowDelayRequest
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


                //Hr_EmpBorrowDelayRequest obj = objPharmaEntities.Hr_EmpBorrowDelayRequest
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

      


        //public async Task<bool> Update(Hr_EmpBorrowDelayRequest objUpdate)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    int rowEffected = 0;
        //    try
        //    {
        //        if (objUpdate != null) //Definsive Programming
        //        {
        //            OpenEntityConnection();
        //            Hr_EmpBorrowDelayRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpBorrowDelayRequest
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
        //public bool UpdateTask(Hr_EmpBorrowDelayRequest objUpdate)
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
        //            Hr_EmpBorrowDelayRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpBorrowDelayRequest
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

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 ReferenceNo  as ReferenceNo  from Hr_EmpBorrowDelayRequest where Company_Id ='" + strcompanyId + "' and Branch_Id= '" + strBranch_Id + "'  order by replicate('0',15-len(ReferenceNo))+ReferenceNo desc").FirstOrDefault<string>();
              
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


        public List<ComboDL> FillEmpBorrow(string Company_Id, string Branch_Id, decimal EmpSerialNo)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<ComboDL> objectList = new List<ComboDL>(); ;
            try
            {

                OpenEntityConnection();
               
                //var para1 = new SqlParameter("@FldIdName",FldId1);
                // var para2 = new SqlParameter("@FldName", FldName1);
                // var para3 = new SqlParameter("@TblName", TblName);
                // var para4 = new SqlParameter("@Strwhere", Strwhere);
                // object[] param = { para1, para2, para3, para4 };

                object[] param1 = { 
               new SqlParameter("@Company_Id",Company_Id),               
                new SqlParameter("@Branch_Id", Branch_Id),
                 new SqlParameter("@EmpSerialNo", EmpSerialNo)};

                //               object[] params = {
                //                new SqlParameter("@ParametterWithNummvalue", DBNull.Value),
                //                new SqlParameter("@In_Parameter", "Value"),
                //                new SqlParameter("@Out_Parameter", SqlDbType.INT) 
                //{Direction = ParameterDirection.Output}};

                //            YourDbContext.Database.ExecuteSqlCommand("exec StoreProcedure_Name @ParametterWithNummvalue, @In_Parameter, @Out_Parameter", params);
                //            YourDbContext.SaveChanges();

                //Var ReturnValue = ((SqlParameter)params[2]).Value


                var objlist = objPharmaEntities.Database.SqlQuery<ComboDL>("exec dbo._SPFillEmpBorrowDrpList @Company_Id,@Branch_Id,@EmpSerialNo", param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);

                if (objlist != null)
                {
                    foreach (var obj in objlist)
                    {
                        ComboDL objCombDL = new ComboDL();
                        objCombDL.Id = Convert.ToString(obj.Id);
                        objCombDL.Name = obj.Name;
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


        public List<ComboDL> FillEmpBorrowMonthDtls(string Company_Id, string Branch_Id, decimal EmpSerialNo,Guid BorrowHdr_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<ComboDL> objectList = new List<ComboDL>(); ;
            try
            {

                OpenEntityConnection();

                //var para1 = new SqlParameter("@FldIdName",FldId1);
                // var para2 = new SqlParameter("@FldName", FldName1);
                // var para3 = new SqlParameter("@TblName", TblName);
                // var para4 = new SqlParameter("@Strwhere", Strwhere);
                // object[] param = { para1, para2, para3, para4 };

                object[] param1 = { 
                    new SqlParameter("@Company_Id",Company_Id),               
                    new SqlParameter("@Branch_Id", Branch_Id),
                    new SqlParameter("@EmpSerialNo", EmpSerialNo),
                    new SqlParameter("@Borrow_Hdr_Id", BorrowHdr_Id)};

                //               object[] params = {
                //                new SqlParameter("@ParametterWithNummvalue", DBNull.Value),
                //                new SqlParameter("@In_Parameter", "Value"),
                //                new SqlParameter("@Out_Parameter", SqlDbType.INT) 
                //{Direction = ParameterDirection.Output}};

                //            YourDbContext.Database.ExecuteSqlCommand("exec StoreProcedure_Name @ParametterWithNummvalue, @In_Parameter, @Out_Parameter", params);
                //            YourDbContext.SaveChanges();

                //Var ReturnValue = ((SqlParameter)params[2]).Value


                var objlist = objPharmaEntities.Database.SqlQuery<ComboDL>("exec dbo._SPFillEmpBorrowMonthDtlsDrpList @Company_Id,@Branch_Id,@EmpSerialNo,@Borrow_Hdr_Id", param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);

                if (objlist != null)
                {
                    foreach (var obj in objlist)
                    {
                        ComboDL objCombDL = new ComboDL();
                        objCombDL.Id = Convert.ToString(obj.Id);
                        objCombDL.Name = obj.Name;
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


        public MessageResultDL ChkChkContractWithDelayBorrow(string Company_Id, string Branch_Id, decimal Emp_Serial_no, Guid Borrow_Hdr)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            MessageResultDL objectList = new MessageResultDL(); ;
            try
            {

                OpenEntityConnection();



                object[] param1 = { 
                    new SqlParameter("@Company_Id",Company_Id),               
                    new SqlParameter("@Branch_Id", Branch_Id),
                    new SqlParameter("@Emp_Serial_no", Emp_Serial_no),
                    new SqlParameter("@Borrow_Hdr", Borrow_Hdr)};


                var objlist = objPharmaEntities.Database.SqlQuery<MessageResultDL>("exec dbo._SPChkContractWithDelayBorrow @Company_Id,@Branch_Id,@Emp_Serial_no,@Borrow_Hdr", param1).FirstOrDefault();



                if (objlist != null)
                {
                    objectList.MessageType = objlist.MessageType;
                    objectList.Message = objlist.Message;
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



        //public Hr_EmpBorrowDelay_Settings GetPermmissionSettingDataByBranchandCompany(string strCompany_Id, string strBranch_Id)
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();


        //    try
        //    {
        //        OpenEntityConnection();

        //        Hr_EmpBorrowDelay_Settings ObjEmpBorrowDelay_Settings = (from objLinq in objPharmaEntities.Hr_EmpBorrowDelay_Settings
        //                                          where objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id
        //                                          select objLinq).FirstOrDefault();

        //        if (ObjEmpBorrowDelay_Settings != null)
        //        {
        //            Hr_EmpBorrowDelay_Settings objEmpBorrowDelay_SettingsDL = new Hr_EmpBorrowDelay_Settings();

        //            {
        //                objEmpBorrowDelay_SettingsDL.Branch_Id = ObjEmpBorrowDelay_Settings.Branch_Id;
        //                objEmpBorrowDelay_SettingsDL.Company_Id = ObjEmpBorrowDelay_Settings.Company_Id;
        //                objEmpBorrowDelay_SettingsDL.AllowedValueInMonthByHour = ObjEmpBorrowDelay_Settings.AllowedValueInMonthByHour;
        //                objEmpBorrowDelay_SettingsDL.AllowedValueInDayByHour = ObjEmpBorrowDelay_Settings.AllowedValueInDayByHour;
        //                objEmpBorrowDelay_SettingsDL.PeriodForDay = ObjEmpBorrowDelay_Settings.PeriodForDay;
        //                objEmpBorrowDelay_SettingsDL.HourNoForDiscount = ObjEmpBorrowDelay_Settings.HourNoForDiscount;
        //                objEmpBorrowDelay_SettingsDL.AllowToExceedMonthValue = ObjEmpBorrowDelay_Settings.AllowToExceedMonthValue;
        //                objEmpBorrowDelay_SettingsDL.AllowToExceedDayValue = ObjEmpBorrowDelay_Settings.AllowToExceedDayValue;
        //                objEmpBorrowDelay_SettingsDL.OnlyApplyDiscount = ObjEmpBorrowDelay_Settings.OnlyApplyDiscount;
                        
                        
                            
                        
        //            }
        //            return objEmpBorrowDelay_SettingsDL;
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


        //public bool SavePermmissionSettingData(Hr_EmpBorrowDelay_Settings objList)
        //{

        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();


        //    try
        //    {
        //        OpenEntityConnection();


        //        int Result = 0;
        //     //   string emSerialNo = (objList.EmpSerialForDocNotify == null ? 0 : objList.EmpSerialForDocNotify).ToString();



        //        Hr_EmpBorrowDelay_Settings ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpBorrowDelay_Settings
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
        //                Hr_EmpBorrowDelay_Settings loclDtls = new Hr_EmpBorrowDelay_Settings
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

        //                objPharmaEntities.Hr_EmpBorrowDelay_Settings.Add(loclDtls);
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
        //public EmpBorrowDelayStatusDL GetEmpBorrowDelayAvailablity(string Company_Id, string Branch_Id, decimal EmpSerial_No, string BorrowHdr_Id, string ToTime, string BorrowDelayDuesDate)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    try
        //    {


        //        OpenEntityConnection();


        //        EmpBorrowDelayStatusDL objectList = new EmpBorrowDelayStatusDL();

        //        object[] param1 = { 
        //        new SqlParameter("@Company_Id",Company_Id),
        //        new SqlParameter("@Branch_Id", Branch_Id),
        //        new SqlParameter("@Emp_Serial_no", EmpSerial_No),
        //        new SqlParameter("@BorrowHdr_Id", BorrowHdr_Id),
        //        new SqlParameter("@ToTime", ToTime),
        //        new SqlParameter("@BorrowDelayDuesDate", BorrowDelayDuesDate)};



        //        var objlist = objPharmaEntities.Database.SqlQuery<EmpBorrowDelayStatusDL>("exec dbo.ChkEmpBorrowDelayAvailablity @Company_Id,@Branch_Id,@Emp_Serial_no,@BorrowHdr_Id,@ToTime,@BorrowDelayDuesDate", param1).FirstOrDefault();
        //        if (objlist != null)
        //        {
        //            EmpBorrowDelayStatusDL objEmpBorrowStatusDL = new EmpBorrowDelayStatusDL();
        //            objEmpBorrowStatusDL.ResultStatus = objlist.ResultStatus;
        //            objEmpBorrowStatusDL.ResultMessage = objlist.ResultMessage;
        //            return objEmpBorrowStatusDL;
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
