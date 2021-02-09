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

namespace DAL.HrRecords.RecordManagement
{
    public class RecordsConfirmationDAL : CommonDB
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


        public bool SaveRecordData(List<RecordsConfirmationDL> objList)
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
                      
                         if (obj.Record_ID == 0)
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {

                                Hr_EmpOverTimeRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpOverTimeRecord
                                                                     where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {
                                    ObjForUpdate.Confirmed = 1;
                                    Result = objPharmaEntities.SaveChanges();
                                }
                            }
                           
                        }
                        else if (obj.Record_ID == 1)
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {

                                Hr_EmpPermissionRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpPermissionRecord
                                                                       where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {
                                    ObjForUpdate.Confirmed = 1;
                                    Result = objPharmaEntities.SaveChanges();
                                }
                            }
                        }

                        else if (obj.Record_ID == 2)
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {

                                Hr_EmpDelayRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpDelayRecord
                                                                  where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                       select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {
                                    ObjForUpdate.Confirmed = 1;
                                    Result = objPharmaEntities.SaveChanges();
                                }
                            }
                        }

                        else if (obj.Record_ID == 3)
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {

                                Hr_EmpVactionRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpVactionRecord
                                                                    where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                  select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {
                                    ObjForUpdate.Confirmed = 1;
                                    Result = objPharmaEntities.SaveChanges();
                                }
                            }
                        }

                        else if (obj.Record_ID == 4)
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {

                                Hr_EmpAbsenceRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpAbsenceRecord
                                                                    where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                    select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {
                                    ObjForUpdate.Confirmed = 1;
                                    Result = objPharmaEntities.SaveChanges();
                                }
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



        public List<RecordsConfirmationDL> GetRecordData(decimal EmpSerial_No, string FromDate, string ToDate,string Record, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<RecordsConfirmationDL> objectList = new List<RecordsConfirmationDL>();


                object[] param1 = {

                new SqlParameter("@Emp_Serial_No", EmpSerial_No),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Record",Record),
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id)

             };


                var objlist = objPharmaEntities.Database.SqlQuery<RecordsConfirmationDL>("exec dbo.sp_GetRecordsData @Emp_Serial_No, @FromDate, @ToDate,@Record,@Company_Id,@Branch_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    RecordsConfirmationDL RecordsConfirmationDL = new RecordsConfirmationDL();
                    RecordsConfirmationDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    RecordsConfirmationDL.Record_ID = obj.Record_ID;
                    RecordsConfirmationDL.RecordName_En = obj.RecordName_En;
                    RecordsConfirmationDL.RecordName_Ar = obj.RecordName_Ar;
                    RecordsConfirmationDL.Emp_Serial_No = obj.Emp_Serial_No;
                    RecordsConfirmationDL.Emp_FullNameArabic = obj.Emp_FullNameArabic;
                    RecordsConfirmationDL.Emp_FullNameEn = obj.Emp_FullNameEn;
                    RecordsConfirmationDL.TransDate = obj.TransDate;
                    RecordsConfirmationDL.FromTime = obj.FromTime;
                    RecordsConfirmationDL.ToTime = obj.ToTime;
                    RecordsConfirmationDL.Duration = obj.Duration;

                    objectList.Add(RecordsConfirmationDL);

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
    }
}
