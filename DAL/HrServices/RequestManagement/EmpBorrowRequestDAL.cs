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
  public  class EmpBorrowRequestDAL:CommonDB

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


        public  async Task<int> Insert(Hr_EmpBorrowRequest objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_EmpBorrowRequest.Add(objInsert);
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
        public int InsertTask(Hr_EmpBorrowRequest objInsert)
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

                    objPharmaEntities.Hr_EmpBorrowRequest.Add(objInsert);
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
        public List<EmpBorrowRequestDL> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();


                List<EmpBorrowRequestDL> objectList = new List<EmpBorrowRequestDL>();
                var objlist = (from objLinq in objPharmaEntities.Hr_EmpBorrowRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on Convert.ToString(objLinq.Order_Status) equals Reqstatus.RequestStatus_Id
                               select new 
                               {
                                   Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   BorrowStartDate = objLinq.BorrowStartDate,
                                   Borrow_Value = objLinq.Borrow_Value,
                                   Borrow_Period = objLinq.Borrow_Period,
                                   Borrow_MonthValue = objLinq.Borrow_MonthValue,
                                   BorrowDuesDate = objLinq.BorrowDuesDate,
                                   Order_Status = objLinq.Order_Status,
                                   MessageNotesForEmp=objLinq.MessageNotesForEmp,
                                   RequestTypeNameEn = ReqType.Request_NameEn,
                                   StatusNameEn = Reqstatus.RequestStatus_NameEn,
                                   RequestTypeName = ReqType.Request_Name,
                                   StatusName = Reqstatus.RequestStatus_Name
                               }).ToList();

                


        
                                    
                foreach (var obj in objlist)
                {
                    EmpBorrowRequestDL objEmpBorrowRequestDL = new EmpBorrowRequestDL();
                    objEmpBorrowRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpBorrowRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpBorrowRequestDL.Request_Id = obj.Request_Id;
                    objEmpBorrowRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpBorrowRequestDL.BorrowStartDate = obj.BorrowStartDate;
                    objEmpBorrowRequestDL.Borrow_Value = obj.Borrow_Value;
                    objEmpBorrowRequestDL.Borrow_Period = obj.Borrow_Period;
                    objEmpBorrowRequestDL.Borrow_MonthValue = obj.Borrow_MonthValue;
                    objEmpBorrowRequestDL.BorrowDuesDate = obj.BorrowDuesDate;
                    objEmpBorrowRequestDL.MessageNotesForEmp = obj.MessageNotesForEmp;
                    objEmpBorrowRequestDL.Order_Status = obj.Order_Status;
                    objEmpBorrowRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpBorrowRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpBorrowRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpBorrowRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpBorrowRequestDL);

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


        public List<EmpBorrowRequestDL> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpBorrowRequestDL> objectList = new List<EmpBorrowRequestDL>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpBorrowRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on objLinq.Order_Status equals Reqstatus.RequestStatus_Id
                               where objLinq.Company_Id == strcomapny && objLinq.Branch_Id==strbranch
                               select new 
                               {
                                   Rec_Hdr_Id =objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   BorrowStartDate = objLinq.BorrowStartDate,
                                   Borrow_Value = objLinq.Borrow_Value,
                                   Borrow_Period = objLinq.Borrow_Period,
                                   Borrow_MonthValue = objLinq.Borrow_MonthValue,
                                   Reason = objLinq.Reason,
                                   MessageNotesForEmp = objLinq.MessageNotesForEmp,
                                   BorrowDuesDate = objLinq.BorrowDuesDate,
                                   Order_Status = objLinq.Order_Status,
                                   RequestTypeNameEn = ReqType.Request_NameEn,
                                   StatusNameEn = Reqstatus.RequestStatus_NameEn,
                                   RequestTypeName = ReqType.Request_Name,
                                   StatusName = Reqstatus.RequestStatus_Name
                               }).ToList();

                


        
                                    
                foreach (var obj in objlist)
                {
                    EmpBorrowRequestDL objEmpBorrowRequestDL = new EmpBorrowRequestDL();
                    objEmpBorrowRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpBorrowRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpBorrowRequestDL.Request_Id = obj.Request_Id;
                    objEmpBorrowRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpBorrowRequestDL.BorrowStartDate = obj.BorrowStartDate;
                    objEmpBorrowRequestDL.Borrow_Value = obj.Borrow_Value;
                    objEmpBorrowRequestDL.Borrow_Period = obj.Borrow_Period;
                    objEmpBorrowRequestDL.Borrow_MonthValue = obj.Borrow_MonthValue;
                    objEmpBorrowRequestDL.Reason = obj.Reason;
                    objEmpBorrowRequestDL.BorrowDuesDate = obj.BorrowDuesDate;
                    objEmpBorrowRequestDL.MessageNotesForEmp = obj.MessageNotesForEmp;
                    objEmpBorrowRequestDL.Order_Status = obj.Order_Status;
                    objEmpBorrowRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpBorrowRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpBorrowRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpBorrowRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpBorrowRequestDL);

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

        public bool chkBorrowIndivisible(string strRequestType)
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
      


        public Hr_EmpBorrowRequest GetRequestByHdrId(string strCompanyNo, string strBranchNo, Guid RequestHdrId) 
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {

                
                OpenEntityConnection();

                string sql = "select Rec_Hdr_Id,ReferenceNo,Request_Id,Rec_No,TransDate,InsUser,InsDate,Company_Id,Branch_Id";
                sql = sql + ",Emp_Serial_No,BorrowStartDate,Borrow_Value,Borrow_Period,Borrow_MonthValue,Reason,DocumentPath,Order_Status,Commissioner_Serial_no,BorrowDuesDate,MessageNotesForEmp";
                sql = sql + ",Contract_Id,ContractPeriod_Id";
                sql = sql + " from Hr_EmpBorrowRequest where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Rec_Hdr_Id = '" + RequestHdrId + "'";


                Hr_EmpBorrowRequest obj = objPharmaEntities.Database.SqlQuery<Hr_EmpBorrowRequest>(sql).FirstOrDefault();
                return obj;

             //  EmpBorrowRequestDL objectList = new EmpBorrowRequestDL();

                //Hr_EmpBorrowRequest obj = (from objLinq in objPharmaEntities.Hr_EmpBorrowRequest
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


                //Hr_EmpBorrowRequest obj = objPharmaEntities.Hr_EmpBorrowRequest
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

      


        //public async Task<bool> Update(Hr_EmpBorrowRequest objUpdate)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    int rowEffected = 0;
        //    try
        //    {
        //        if (objUpdate != null) //Definsive Programming
        //        {
        //            OpenEntityConnection();
        //            Hr_EmpBorrowRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpBorrowRequest
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
        //public bool UpdateTask(Hr_EmpBorrowRequest objUpdate)
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
        //            Hr_EmpBorrowRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpBorrowRequest
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

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 ReferenceNo  as ReferenceNo  from Hr_EmpBorrowRequest where Company_Id ='" + strcompanyId + "' and Branch_Id= '" + strBranch_Id + "'  order by replicate('0',15-len(ReferenceNo))+ReferenceNo desc").FirstOrDefault<string>();
              
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

        public Hr_EmpBorrow_Settings GetBorrowSettingDataByBranchandCompany(string strCompany_Id, string strBranch_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                Hr_EmpBorrow_Settings ObjEmpBorrow_Settings = (from objLinq in objPharmaEntities.Hr_EmpBorrow_Settings
                                                                   where objLinq.Company_Id == strCompany_Id && objLinq.Branch_Id == strBranch_Id
                                                                   select objLinq).FirstOrDefault();

                if (ObjEmpBorrow_Settings != null)
                {
                    Hr_EmpBorrow_Settings objEmpBorrow_SettingsDL = new Hr_EmpBorrow_Settings();

                    
                    {
                        objEmpBorrow_SettingsDL.Branch_Id = ObjEmpBorrow_Settings.Branch_Id;
                        objEmpBorrow_SettingsDL.Company_Id = ObjEmpBorrow_Settings.Company_Id;
                        objEmpBorrow_SettingsDL.AllowedValueNotExceedTo = ObjEmpBorrow_Settings.AllowedValueNotExceedTo;
                        objEmpBorrow_SettingsDL.AllowExceedMaxValue = ObjEmpBorrow_Settings.AllowExceedMaxValue;


                    }
                    return objEmpBorrow_SettingsDL;
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


        public bool SaveBorrowSettingData(Hr_EmpBorrow_Settings objList)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();


                int Result = 0;
                //   string emSerialNo = (objList.EmpSerialForDocNotify == null ? 0 : objList.EmpSerialForDocNotify).ToString();



                Hr_EmpBorrow_Settings ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpBorrow_Settings
                                                        where objLinq.Company_Id == objList.Company_Id && objLinq.Branch_Id == objList.Branch_Id
                                                        select objLinq).FirstOrDefault();
                if (ObjForUpdate != null)
                {


                    ObjForUpdate.AllowedValueNotExceedTo = objList.AllowedValueNotExceedTo;
                    ObjForUpdate.AllowExceedMaxValue = objList.AllowExceedMaxValue;
                    Result = objPharmaEntities.SaveChanges();

                    return (Result > 0);
                }
                else
                {
                    if (objList != null)
                    {
                        Hr_EmpBorrow_Settings loclDtls = new Hr_EmpBorrow_Settings
                        {
                            Branch_Id = objList.Branch_Id,
                            Company_Id = objList.Company_Id,
                            AllowedValueNotExceedTo = objList.AllowedValueNotExceedTo,
                            AllowExceedMaxValue = objList.AllowExceedMaxValue,
                            

                        };

                        objPharmaEntities.Hr_EmpBorrow_Settings.Add(loclDtls);
                        //saves all above operations within one transaction
                        Result = objPharmaEntities.SaveChanges();
                        return (Result > 0);

                    }
                    else
                        return false;

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


        public List<EmpBorrowFollowUpDL> GetEmpBorrowFollowUp(string Company_Id, string Branch_Id, string FromDate, string ToDate, decimal EmpSerial_No) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {

                OpenEntityConnection();


                List<EmpBorrowFollowUpDL> objectList = new List<EmpBorrowFollowUpDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@EmpSerialNo", EmpSerial_No)};

                var objlist = objPharmaEntities.Database.SqlQuery<EmpBorrowFollowUpDL>("exec dbo.SPGetEmpBorrowFollowUp @Company_Id,@Branch_Id,@FromDate,@ToDate,@EmpSerialNo", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpBorrowFollowUpDL objEmpBorrowFollowUpDL = new EmpBorrowFollowUpDL();

                    objEmpBorrowFollowUpDL.Hdr_IdCol = obj.Hdr_IdCol;
                    objEmpBorrowFollowUpDL.BorrowDuesDateCol = obj.BorrowDuesDateCol;

                    objEmpBorrowFollowUpDL.BorrowStartDateCol = obj.BorrowStartDateCol;
                    objEmpBorrowFollowUpDL.Borrow_PeriodCol = obj.Borrow_PeriodCol;
                    objEmpBorrowFollowUpDL.BorrowEndDateCol = obj.BorrowEndDateCol;
                    objEmpBorrowFollowUpDL.Borrow_ValueCol = obj.Borrow_ValueCol;
                    objEmpBorrowFollowUpDL.Borrow_MonthValueCol = obj.Borrow_MonthValueCol;
                    objEmpBorrowFollowUpDL.Borrow_ValueCreditTillnowCol = obj.Borrow_ValueCreditTillnowCol;
                    objEmpBorrowFollowUpDL.EmpSerialNoCol = obj.EmpSerialNoCol;
                    objEmpBorrowFollowUpDL.EmpBorrow_StatusCol = obj.EmpBorrow_StatusCol;

                    objectList.Add(objEmpBorrowFollowUpDL);

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

        public List<EmpBorrowDetailDL> GetEmpBorrowCreditDetails(string Company_Id, string Branch_Id, decimal EmpSerial_No, Guid RecRequestHdr_Id)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<EmpBorrowDetailDL> objectList = new List<EmpBorrowDetailDL>();

              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_No", EmpSerial_No),
                new SqlParameter("@RecRequestHdr_Id", RecRequestHdr_Id)};



              var objlist = objPharmaEntities.Database.SqlQuery<EmpBorrowDetailDL>("exec dbo.SPGetEmpBorrowCreditDetails @Company_Id,@Branch_Id,@Emp_Serial_No,@RecRequestHdr_Id", param1).ToList();

              foreach (var obj in objlist)
              {
                  EmpBorrowDetailDL objEmpBorrowDetailDL = new EmpBorrowDetailDL();
                  objEmpBorrowDetailDL.TransItemDate = obj.TransItemDate;
                  objEmpBorrowDetailDL.HireItem_Value = obj.HireItem_Value;
                  objEmpBorrowDetailDL.Notes = obj.Notes;
                  
                  objectList.Add(objEmpBorrowDetailDL);

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

        public EmpBorrowStatusDL GetEmpBorrowAvailablity(string Company_Id, string Branch_Id, decimal EmpSerial_No, decimal RquiredBorrowValue, string BorrowDuesDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                EmpBorrowStatusDL objectList = new EmpBorrowStatusDL();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_no", EmpSerial_No),
                new SqlParameter("@RquiredBorrowValue", RquiredBorrowValue),
                new SqlParameter("@BorrowDuesDate", BorrowDuesDate)};



                var objlist = objPharmaEntities.Database.SqlQuery<EmpBorrowStatusDL>("exec dbo.ChkEmpBorrowAvailablity @Company_Id,@Branch_Id,@Emp_Serial_no,@RquiredBorrowValue,@BorrowDuesDate", param1).FirstOrDefault();
                if (objlist != null)
                {
                    EmpBorrowStatusDL objEmpBorrowStatusDL = new EmpBorrowStatusDL();
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
