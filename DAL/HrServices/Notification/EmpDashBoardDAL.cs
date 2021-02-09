using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

using BOL.HrServices.Notification;

namespace DAL.HrServices.Notification
{
  public  class EmpDashBoardDAL:CommonDB

    {

      public List<EmpDashBoardDL> GetCountEmpRequest(string strcomapny, string strbranch, decimal Empserial_no)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpDashBoardDL> objectList = new List<EmpDashBoardDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",strcomapny),
                new SqlParameter("@Branch_Id", strbranch),
                new SqlParameter("@Emp_Seial_No", Empserial_no)};

                var objlist = objPharmaEntities.Database.SqlQuery<EmpDashBoardDL>("exec dbo.GetCountEmpRequest @Company_Id,@Branch_Id,@Emp_Seial_No", param1).ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);


                foreach (var obj in objlist)
                {
                    EmpDashBoardDL objEmpDashBoardDL = new EmpDashBoardDL();
                    objEmpDashBoardDL.Approved = obj.Approved;
                    objEmpDashBoardDL.Inprogress = obj.Inprogress;
                    objEmpDashBoardDL.Reject = obj.Reject;
                    objEmpDashBoardDL.AllRequest = obj.AllRequest;
                    objectList.Add(objEmpDashBoardDL);

                }



                //var objlist = (from objLinq in objPharmaEntities.Hr_EmpDashBoard
                //               //join VactionWorkFlow in objPharmaEntities.Hr_EmpVactionRequestWorkFlow on objLinq.RequestHdrId equals VactionWorkFlow.Hdr_Id
                //               join ReqType in objPharmaEntities.Hr_RequestTypes on objLinq.RequestType equals ReqType.Request_Id
                //               where objLinq.Company_Id == strcomapny && objLinq.Branch_Id == strbranch && objLinq.Emp_Serial_No == Empserial_no
                //               select new
                //               {
                //                   NotifyHdrId = objLinq.NotifyHdrId,
                //                   RequestHdrId = objLinq.RequestHdrId,
                //                   RequestType = objLinq.RequestType,
                //                   RequestGroupType = ReqType.RequestType,
                //                   Emp_Serial_No = objLinq.Emp_Serial_No,
                //                   RequestTypeNameEn = ReqType.Request_NameEn,
                //                   RequestTypeName = ReqType.Request_Name,
                //                   DetailWorkFlowId = objLinq.DetailWorkFlowId,
                //                   JobName = objLinq.Job_Name,
                //                   JobNameEn = objLinq.Job_NameEn,
                //                   SenderName = objLinq.SenderName,
                //                   SenderNameEn = objLinq.SenderNameEn,
                //                   CommissionerName = objLinq.CommissionerName,
                //                   CommissionerNameEn = objLinq.CommissionerNameEn
                //               }).ToList();


                ////    RequestHdrId,RequestType,Emp_Serial_No,SenderEmpName,SenderEmpNameEn
                ////RequestTypeName,RequestTypeNameEn



                //foreach (var obj in objlist)
                //{
                //    EmpDashBoardDL objEmpDashBoardDL = new EmpDashBoardDL();
                //    objEmpDashBoardDL.NotifyHdrId = obj.NotifyHdrId;
                //    objEmpDashBoardDL.RequestHdrId = obj.RequestHdrId;
                //    objEmpDashBoardDL.RequestType = obj.RequestType;
                //    objEmpDashBoardDL.RequestGroupType = obj.RequestGroupType;
                //    objEmpDashBoardDL.Emp_Serial_No = obj.Emp_Serial_No;
                //    objEmpDashBoardDL.DetailWorkFlowId = obj.DetailWorkFlowId;
                //    objEmpDashBoardDL.RequestTypeNameEn = obj.RequestTypeNameEn;
                //    objEmpDashBoardDL.RequestTypeName = obj.RequestTypeName;
                //    objEmpDashBoardDL.JobName = obj.JobName;
                //    objEmpDashBoardDL.JobNameEn = obj.JobNameEn;
                //    objEmpDashBoardDL.SenderName = obj.SenderName;
                //    objEmpDashBoardDL.SenderNameEn = obj.SenderNameEn;

                //    objEmpDashBoardDL.SenderNameEn = obj.SenderNameEn;
                //    objEmpDashBoardDL.SenderNameEn = obj.SenderNameEn;

                //    objEmpDashBoardDL.CommissionerName = obj.CommissionerName;
                //    objEmpDashBoardDL.CommissionerNameEn = obj.CommissionerNameEn;
                //    objectList.Add(objEmpDashBoardDL);

                //}


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

    }
}
