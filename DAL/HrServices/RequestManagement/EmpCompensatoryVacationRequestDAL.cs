using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HrServices.RequestManagement;
namespace DAL.HrServices.RequestManagement
{
  public  class EmpCompensatoryVacationRequestDAL : CommonDB

    {
        public  async Task<int> Insert(Hr_EmpSecondmentRequest objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_EmpSecondmentRequest.Add(objInsert);
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
        public int InsertTask(Hr_EmpCompensatoryVacationRequest objInsert)
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

                    objPharmaEntities.Hr_EmpCompensatoryVacationRequest.Add(objInsert);
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
        public List<EmpSecondmentRequestDL> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();


                List<EmpSecondmentRequestDL> objectList = new List<EmpSecondmentRequestDL>();
                var objlist = (from objLinq in objPharmaEntities.Hr_EmpSecondmentRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on Convert.ToString(objLinq.Order_Status) equals Reqstatus.RequestStatus_Id
                               select new
                               {
                                   Rec_Hdr_Id = objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   FromSecondmentDate = objLinq.FromSecondmentDate,

                                   ToSecondmentDate = objLinq.ToSecondmentDate,
                                   ExpectedValue = objLinq.ExpectedValue,
                                   City = objLinq.City,
                                   State = objLinq.State,
                                   Notes = objLinq.Notes,
                                   SecondmentType = objLinq.SecondmentType,
                                   Order_Status = objLinq.Order_Status,

                                   RequestTypeNameEn = ReqType.Request_NameEn,
                                   StatusNameEn = Reqstatus.RequestStatus_NameEn,
                                   RequestTypeName = ReqType.Request_Name,
                                   StatusName = Reqstatus.RequestStatus_Name
                               }).ToList();






                foreach (var obj in objlist)
                {
                    EmpSecondmentRequestDL objEmpSecondmentRequestDL = new EmpSecondmentRequestDL();
                    objEmpSecondmentRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpSecondmentRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpSecondmentRequestDL.Request_Id = obj.Request_Id;
                    objEmpSecondmentRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpSecondmentRequestDL.FromSecondmentDate = obj.FromSecondmentDate;
                    objEmpSecondmentRequestDL.ToSecondmentDate = obj.ToSecondmentDate;
                    objEmpSecondmentRequestDL.ExpectedValue = obj.ExpectedValue;
                    objEmpSecondmentRequestDL.City = obj.City;
                    objEmpSecondmentRequestDL.State = obj.State;
                    objEmpSecondmentRequestDL.Notes = obj.Notes;
                    objEmpSecondmentRequestDL.SecondmentType = obj.SecondmentType;

                    objEmpSecondmentRequestDL.Order_Status = obj.Order_Status;
                    objEmpSecondmentRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpSecondmentRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpSecondmentRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpSecondmentRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpSecondmentRequestDL);

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


        public List<EmpCompensatoryVacationRequestDL> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpCompensatoryVacationRequestDL> objectList = new List<EmpCompensatoryVacationRequestDL>();

                var objlist = (from objLinq in objPharmaEntities.Hr_EmpCompensatoryVacationRequest
                               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.Request_Id equals ReqType.Request_Id
                               join Reqstatus in objPharmaEntities.Hr_RequestStatus on objLinq.Order_Status equals Reqstatus.RequestStatus_Id
                               where objLinq.Company_Id == strcomapny && objLinq.Branch_Id == strbranch
                               select new
                               {
                                   Rec_Hdr_Id = objLinq.Rec_Hdr_Id,
                                   ReferenceNo = objLinq.ReferenceNo,
                                   Request_Id = objLinq.Request_Id,
                                   Emp_Serial_No = objLinq.Emp_Serial_No,
                                   FromDate = objLinq.FromDate,
                                   ToDate = objLinq.ToDate,
                                   Notes = objLinq.Notes,
                                   Order_Status = objLinq.Order_Status,
                                   RequestTypeNameEn = ReqType.Request_NameEn,
                                   StatusNameEn = Reqstatus.RequestStatus_NameEn,
                                   RequestTypeName = ReqType.Request_Name,
                                   StatusName = Reqstatus.RequestStatus_Name
                               }).ToList();






                foreach (var obj in objlist)
                {
                    EmpCompensatoryVacationRequestDL objEmpSecondmentRequestDL = new EmpCompensatoryVacationRequestDL();
                    objEmpSecondmentRequestDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    objEmpSecondmentRequestDL.ReferenceNo = obj.ReferenceNo;
                    objEmpSecondmentRequestDL.Request_Id = obj.Request_Id;
                    objEmpSecondmentRequestDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpSecondmentRequestDL.FromDate = obj.FromDate;
                    objEmpSecondmentRequestDL.ToDate = obj.ToDate;
                    objEmpSecondmentRequestDL.Notes = obj.Notes;
                    objEmpSecondmentRequestDL.Order_Status = obj.Order_Status;
                    objEmpSecondmentRequestDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                    objEmpSecondmentRequestDL.StatusNameEn = obj.StatusNameEn;
                    objEmpSecondmentRequestDL.RequestTypeName = obj.RequestTypeName;
                    objEmpSecondmentRequestDL.StatusName = obj.StatusName;
                    objectList.Add(objEmpSecondmentRequestDL);

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

        public bool chkSecondmentIndivisible(string strRequestType)
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
      


        public Hr_EmpCompensatoryVacationRequest GetRequestByHdrId(string strCompanyNo, string strBranchNo, Guid RequestHdrId) 
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();

                string sql = "select Rec_Hdr_Id,ReferenceNo,Request_Id,Rec_No,TransDate,InsUser,InsDate,Company_Id,Branch_Id";
                sql = sql + ",Emp_Serial_No,FromDate,ToDate,Notes,DocumentPath,Order_Status,Commissioner_Serial_no";
                sql = sql + " from Hr_EmpCompensatoryVacationRequest where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Rec_Hdr_Id = '" + RequestHdrId + "'";


                Hr_EmpCompensatoryVacationRequest obj = objPharmaEntities.Database.SqlQuery<Hr_EmpCompensatoryVacationRequest>(sql).FirstOrDefault();
                return obj;

             //  EmpSecondmentRequestDL objectList = new EmpSecondmentRequestDL();

                //Hr_EmpSecondmentRequest obj = (from objLinq in objPharmaEntities.Hr_EmpSecondmentRequest
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


                //Hr_EmpSecondmentRequest obj = objPharmaEntities.Hr_EmpSecondmentRequest
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

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 ReferenceNo  as ReferenceNo  from Hr_EmpSecondmentRequest where Company_Id ='" + strcompanyId + "' and Branch_Id= '" + strBranch_Id + "'  order by replicate('0',15-len(ReferenceNo))+ReferenceNo desc").FirstOrDefault<string>();
              
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



        public bool UpdateSecondmentRequest(Guid Hdr_Id, decimal ActullValue)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            // bool task = Delete(objInsert).Result;
            // return task;
            int rowEffected = 0;
            try
            {

                OpenEntityConnection();
                Hr_EmpSecondmentRequest objForReview = (from objLinq in objPharmaEntities.Hr_EmpSecondmentRequest
                                            where objLinq.Rec_Hdr_Id==Hdr_Id
                                            select objLinq).FirstOrDefault();
                if (objForReview != null)
                {

                    objForReview.ExpectedValue = ActullValue;

                    objForReview.Notes = "The Expected Value has been changed";
                    

                    rowEffected = objPharmaEntities.SaveChanges();
                }
                else
                {
                    rowEffected = 0;
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



    }
}
