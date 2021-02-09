using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HrServices.RequestManagement;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Reflection;

namespace DAL.HrServices.RequestManagement
{
    public class EmpOverTimeRequestWorkFlowDAL : CommonDB

    {




        public bool UpdateTask(Hr_EmpOverTimeRequestWorkFlow objUpdate)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          // bool task = Update(objInsert).Result;
          //return task;
          int rowEffected = 0;
          try
          {

              if (objUpdate != null) //Definsive Programming
              {
                  OpenEntityConnection();

                  Hr_EmpOverTimeRequestWorkFlow ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpOverTimeRequestWorkFlow
                                                               where objLinq.Hdr_Id == objUpdate.Hdr_Id && objLinq.DtlsID == objUpdate.DtlsID && objLinq.Company_Id == objUpdate.Company_Id
                                                               && objLinq.Branch_Id == objUpdate.Branch_Id && (objLinq.Emp_Serial_No == objUpdate.Emp_Serial_No || objLinq.Alternate_Emp_Serial_No == objUpdate.Emp_Serial_No)
                                                               && objLinq.RequestType == objUpdate.RequestType
                                                       select objLinq).FirstOrDefault();
                  ObjForUpdate.EmpReplay = objUpdate.EmpReplay;
                  ObjForUpdate.RequestStatus = objUpdate.RequestStatus;
                  ObjForUpdate.EmpComment = objUpdate.EmpComment;
                  
                  ObjForUpdate.EmpNameReplay = objUpdate.EmpNameReplay;
                  ObjForUpdate.DateReplay = DateTime.Now;

                  rowEffected = objPharmaEntities.SaveChanges();
              }
              
          }
          catch (DbEntityValidationException ex)
          {
                  var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

          }
          catch (Exception ex)
          {
             // catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                   //   this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
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


      public List<EmpVactionRequestWorkFlowDL> GetRequestHistory(string strCompanyNo, string strBranchNo,Guid RequestHdrId) 
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          try
          {


              OpenEntityConnection();


              List<EmpVactionRequestWorkFlowDL> objectList = new List<EmpVactionRequestWorkFlowDL>();




              string sql = "select [Company_Id],[Branch_Id],[Hdr_Id],[EmpComment],[FullNameArabic],[FullNameEn],";
              sql = sql + "case when WorkFlowOrder ='0' then 'Direct Manager' else [Job_NameEn] end as Job_NameEn,case when WorkFlowOrder ='0' then 'مدير' else [Job_Name] end Job_Name,";
              sql = sql + "[Sender_Serial_No],[Reciever_Serial_no],[Reciever_Arabic_Name],[Reciever_English_Name],Reciever_imagePath,Sender_imagePath";
              sql = sql + ",EmpReplay,DateReplay,case when EmpReplay = 0 then 'Pendening' else case when EmpReplay =1 then 'Approved' else case when EmpReplay =2 then 'Rejected' else 'Not Replay' end end end as EmpReplayStatus,";
              sql = sql + " case when (Reciever_Serial_no <> Alternate_Emp_Serial_No) then ALternativeEmpNameEn +' as '+ AlternativeJoibNameEn + ' (Authorized) ' else '' end  as Notes,";
              sql = sql + "Alternate_Emp_Serial_No,Alternate_Job_Id,AlternativeJoibNameEn,AlternativeJoibName,ALternativeEmpName,ALternativeEmpNameEn";
              sql = sql + " FROM [VwEmpOverTimeRequestWorkFlowHistory] where  Company_Id='" + strCompanyNo + "' and Branch_Id='" + strBranchNo + "' and Hdr_Id = '" + RequestHdrId + "'";
              sql = sql + " order by WorkFlowOrder ";
              var objlist = objPharmaEntities.Database.SqlQuery<EmpVactionRequestWorkFlowDL>(sql).ToList();

              

              foreach (var obj in objlist)
              {
                  string NewDate = string.Empty;
                  if (obj.DateReplay != null) {
                      char varchar = Convert.ToString(obj.DateReplay).Contains("/") ? '/' : '-';
                      string[] strDateReplay = Convert.ToString(obj.DateReplay).Split(varchar);
                      NewDate = strDateReplay[1] + "/" + strDateReplay[0] + "/" + strDateReplay[2];
                  }
                  
                  obj.EmpComment = (obj.EmpComment == null) ? "" : obj.EmpComment;
                  obj.Reciever_imagePath = (obj.Reciever_imagePath == null) ? "" : obj.Reciever_imagePath;
                  obj.Sender_imagePath = (obj.Sender_imagePath == null) ? "" : obj.Sender_imagePath;
                 // obj.DateReplay = (obj.DateReplay == null) ? "" : obj.DateReplay;

                  
                  EmpVactionRequestWorkFlowDL objEmpVactionRequestWorkFlowDL = new EmpVactionRequestWorkFlowDL();
                  objEmpVactionRequestWorkFlowDL.Hdr_Id = obj.Hdr_Id;
                  objEmpVactionRequestWorkFlowDL.Company_Id = obj.Company_Id;
                  objEmpVactionRequestWorkFlowDL.Branch_Id = obj.Branch_Id;
                  objEmpVactionRequestWorkFlowDL.EmpComment = obj.EmpComment;
                  objEmpVactionRequestWorkFlowDL.FullNameArabic = obj.FullNameArabic;
                  objEmpVactionRequestWorkFlowDL.FullNameEn = obj.FullNameEn;
                  objEmpVactionRequestWorkFlowDL.Job_Name = obj.Job_Name;
                  objEmpVactionRequestWorkFlowDL.Job_NameEn = obj.Job_NameEn;
                  objEmpVactionRequestWorkFlowDL.Sender_Serial_No = obj.Sender_Serial_No;
                  objEmpVactionRequestWorkFlowDL.Reciever_Serial_no = obj.Reciever_Serial_no;
                  objEmpVactionRequestWorkFlowDL.Reciever_Arabic_Name = obj.Reciever_Arabic_Name;
                  objEmpVactionRequestWorkFlowDL.Reciever_English_Name = obj.Reciever_English_Name;

                  objEmpVactionRequestWorkFlowDL.Reciever_imagePath = obj.Reciever_imagePath;
                  objEmpVactionRequestWorkFlowDL.Sender_imagePath = obj.Sender_imagePath;
                  objEmpVactionRequestWorkFlowDL.EmpReplay = obj.EmpReplay;
                  objEmpVactionRequestWorkFlowDL.DateReplay = obj.DateReplay;
                  objEmpVactionRequestWorkFlowDL.strDateReplay = NewDate;
                  objEmpVactionRequestWorkFlowDL.EmpReplayStatus = obj.EmpReplayStatus;
                  objEmpVactionRequestWorkFlowDL.Notes = obj.Notes;
                  objEmpVactionRequestWorkFlowDL.Alternate_Emp_Serial_No = obj.Alternate_Emp_Serial_No;
                  objEmpVactionRequestWorkFlowDL.Alternate_Job_Id = obj.Alternate_Job_Id;
                  objEmpVactionRequestWorkFlowDL.AlternativeJoibNameEn = obj.AlternativeJoibNameEn;
                  objEmpVactionRequestWorkFlowDL.AlternativeJoibName = obj.AlternativeJoibName;
                  objEmpVactionRequestWorkFlowDL.ALternativeEmpName = obj.ALternativeEmpName;
                  objEmpVactionRequestWorkFlowDL.ALternativeEmpNameEn = obj.ALternativeEmpNameEn;
                  objectList.Add(objEmpVactionRequestWorkFlowDL);

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

     

    }
}
