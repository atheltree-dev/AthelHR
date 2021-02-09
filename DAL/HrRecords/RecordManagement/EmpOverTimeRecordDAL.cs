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
    public class EmpOverTimeRecordDAL : CommonDB
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


        public bool SaveOverTimeRecordData(List<EmpOverTimeRecordDL> objList)
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
                        // data base bind
                        if (obj.RecStatus == 0)
                        {

                        }
                         //Add
                        else if (obj.RecStatus == 1)
                        {

                            Hr_EmpOverTimeRecord newobj = new Hr_EmpOverTimeRecord();
                            newobj.Rec_Hdr_Id = maxId;
                            newobj.Company_Id = obj.Company_Id;
                            newobj.Branch_Id = obj.Branch_Id;
                            newobj.Emp_Serial_No = obj.Emp_Serial_No;
                            newobj.TransDate = DateTime.Now.ToString("yyyyMMdd");
                            newobj.OverTimeDate = (Convert.ToDateTime(obj.OverTimeDate)).ToString("yyyyMMdd");
                            newobj.Request_Id = "10";
                            newobj.Rec_Order_No = "0";
                            newobj.Rec_Order_HdrId = maxId;
                            newobj.FromTime = obj.FromTime;
                            newobj.ToTime = obj.ToTime;
                            newobj.OverTime_Period = obj.OverTime_Period;
                            newobj.InsUser = UserNameProperty;
                            newobj.InsDate = DateTime.Now;
                            newobj.DocumentPath = null;
                            newobj.Commissioner_Serial_no = obj.Emp_Serial_No;
                            newobj.DayType = obj.DayType;
                            newobj.HireItem_Id = "0011";
                            newobj.Confirmed = 0;
                            objPharmaEntities.Hr_EmpOverTimeRecord.Add(newobj);
                            Result = objPharmaEntities.SaveChanges();

                        }
                        //Edit
                        else if (obj.RecStatus == 2)
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {

                                Hr_EmpOverTimeRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpOverTimeRecord
                                                                     where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {

                                    ObjForUpdate.OverTimeDate = (Convert.ToDateTime(obj.OverTimeDate)).ToString("yyyyMMdd");
                                    ObjForUpdate.FromTime = obj.FromTime;
                                    ObjForUpdate.ToTime = obj.ToTime;
                                    ObjForUpdate.OverTime_Period = obj.OverTime_Period;
                                    ObjForUpdate.DayType = obj.DayType;
                                    ObjForUpdate.Emp_Serial_No = obj.Emp_Serial_No;




                                    Result = objPharmaEntities.SaveChanges();
                                }
                            }
                            else
                            {
                                Hr_EmpOverTimeRecord newobj = new Hr_EmpOverTimeRecord();
                                newobj.Rec_Hdr_Id = maxId;
                                newobj.Company_Id = obj.Company_Id;
                                newobj.Branch_Id = obj.Branch_Id;
                                newobj.Emp_Serial_No =obj.Emp_Serial_No;
                                newobj.TransDate = DateTime.Now.ToString("yyyyMMdd");
                                newobj.OverTimeDate = (Convert.ToDateTime(obj.OverTimeDate)).ToString("yyyyMMdd");
                                newobj.Request_Id = "10";
                                newobj.Rec_Order_No = "0";
                                newobj.Rec_Order_HdrId = maxId;
                                newobj.FromTime = obj.FromTime;
                                newobj.ToTime = obj.ToTime;
                                newobj.OverTime_Period = obj.OverTime_Period;
                                newobj.InsUser = UserNameProperty;
                                newobj.InsDate = DateTime.Now;
                                newobj.DocumentPath = null;
                                newobj.Commissioner_Serial_no = obj.Emp_Serial_No;
                                newobj.DayType = obj.DayType;
                                newobj.HireItem_Id = "0011";
                                newobj.Confirmed = 0;
                                objPharmaEntities.Hr_EmpOverTimeRecord.Add(newobj);
                                Result = objPharmaEntities.SaveChanges();
                            }

                        }
                        //Delete
                        else if (obj.RecStatus == 3 )
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {
                                Hr_EmpOverTimeRecord ObjForDelete = (from objLinq in objPharmaEntities.Hr_EmpOverTimeRecord
                                                                     where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();
                                if (ObjForDelete != null)
                                {
                                    objPharmaEntities.Hr_EmpOverTimeRecord.Remove(ObjForDelete);
                                    objPharmaEntities.SaveChanges();
                                }
                             
                            }
                            else
                            {

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



        public List<EmpOverTimeRecordDL> GetOverTimeRecordData(decimal EmpSerial_No, string OvertimeFrom, string OvertimeTo, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpOverTimeRecordDL> objectList = new List<EmpOverTimeRecordDL>();


                object[] param1 = {

                new SqlParameter("@Emp_Serial_No", EmpSerial_No),
                new SqlParameter("@OvertimeFrom",OvertimeFrom),
                new SqlParameter("@OvertimeTo",OvertimeTo),
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id),



             };


                var objlist = objPharmaEntities.Database.SqlQuery<EmpOverTimeRecordDL>("exec dbo.sp_GetEmpOverTimeRecord @Emp_Serial_No, @OvertimeFrom, @OvertimeTo,@Company_Id,@Branch_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpOverTimeRecordDL EmpOverTimeRecordDL = new EmpOverTimeRecordDL();
                    EmpOverTimeRecordDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    EmpOverTimeRecordDL.Company_Id = obj.Company_Id;
                    EmpOverTimeRecordDL.Branch_Id = obj.Branch_Id;
                    EmpOverTimeRecordDL.Emp_Serial_No = obj.Emp_Serial_No;
                    EmpOverTimeRecordDL.FullNameArabic = obj.FullNameArabic;
                    EmpOverTimeRecordDL.FullNameEn = obj.FullNameEn;
                    EmpOverTimeRecordDL.TransDate = obj.TransDate;
                    EmpOverTimeRecordDL.OverTimeDate = obj.OverTimeDate;
                    // EmpOverTimeRecordDL.Rec_Order_No = "0";
                    // EmpOverTimeRecordDL.Rec_Order_HdrId = maxId;
                    EmpOverTimeRecordDL.FromTime = obj.FromTime;
                    EmpOverTimeRecordDL.ToTime = obj.ToTime;
                    EmpOverTimeRecordDL.OverTime_Period = obj.OverTime_Period;
                    // EmpOverTimeRecordDL.InsUser = UserNameProperty;
                    // EmpOverTimeRecordDL.InsDate = DateTime.Now;
                    // EmpOverTimeRecordDL.DocumentPath =null;
                    EmpOverTimeRecordDL.Commissioner_Serial_no = obj.Emp_Serial_No;
                    EmpOverTimeRecordDL.DayType = obj.DayType;
                    // EmpOverTimeRecordDL. = "0011";
                    EmpOverTimeRecordDL.Confirmed = obj.Confirmed;
                    objectList.Add(EmpOverTimeRecordDL);

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
