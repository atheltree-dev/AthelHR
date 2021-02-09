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
    public class AbsenceRecordDAL : CommonDB
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


        public bool SaveDelayRecordData(List<AbsenceRecordDL> objList)
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

                            Hr_EmpAbsenceRecord newobj = new Hr_EmpAbsenceRecord();
                            newobj.Rec_Hdr_Id = GetNewHeaderId();
                            newobj.Company_Id = obj.Company_Id;
                            newobj.Branch_Id = obj.Branch_Id;
                            newobj.Emp_Serial_No = obj.Emp_Serial_No;
                            newobj.TransDate = obj.TransDate;
                            newobj.InsUser = UserNameProperty;
                            newobj.InsDate = DateTime.Now;
                            newobj.HireItem_Id = "0011";
                            newobj.Confirmed = 0;


                            objPharmaEntities.Hr_EmpAbsenceRecord.Add(newobj);
                            Result = objPharmaEntities.SaveChanges();

                        }
                        //Edit
                        else if (obj.RecStatus == 2)
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {

                                Hr_EmpAbsenceRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpAbsenceRecord
                                                                    where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {

                                    ObjForUpdate.TransDate = obj.TransDate;
                                    ObjForUpdate.Emp_Serial_No = obj.Emp_Serial_No;
                                



                                    Result = objPharmaEntities.SaveChanges();
                                }
                            }
                            else
                            {
                                Hr_EmpAbsenceRecord newobj = new Hr_EmpAbsenceRecord();
                                newobj.Rec_Hdr_Id = GetNewHeaderId();
                                newobj.Company_Id = obj.Company_Id;
                                newobj.Branch_Id = obj.Branch_Id;
                                newobj.Emp_Serial_No = obj.Emp_Serial_No;
                                newobj.TransDate = obj.TransDate;
                                newobj.InsUser = UserNameProperty;
                                newobj.InsDate = DateTime.Now;
                                newobj.HireItem_Id = "0011";
                                newobj.Confirmed = 0;



                                objPharmaEntities.Hr_EmpAbsenceRecord.Add(newobj);
                                Result = objPharmaEntities.SaveChanges();
                            }

                        }
                        //Delete
                        else if (obj.RecStatus == 3 )
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {
                                Hr_EmpAbsenceRecord ObjForDelete = (from objLinq in objPharmaEntities.Hr_EmpAbsenceRecord
                                                                    where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();
                                if (ObjForDelete != null)
                                {
                                    objPharmaEntities.Hr_EmpAbsenceRecord.Remove(ObjForDelete);
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



        public List<AbsenceRecordDL> GetAbsenceRecordData(decimal EmpSerial_No, string FromDate, string ToDate, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<AbsenceRecordDL> objectList = new List<AbsenceRecordDL>();


                object[] param1 = {

                new SqlParameter("@Emp_Serial_No", EmpSerial_No),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id)

             };


                var objlist = objPharmaEntities.Database.SqlQuery<AbsenceRecordDL>("exec dbo.sp_GetAbsenceRecord @Emp_Serial_No, @FromDate, @ToDate,@Company_Id,@Branch_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    AbsenceRecordDL AbsenceRecordDL = new AbsenceRecordDL();
                    AbsenceRecordDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    AbsenceRecordDL.Company_Id = obj.Company_Id;
                    AbsenceRecordDL.Branch_Id = obj.Branch_Id;
                    AbsenceRecordDL.Emp_Serial_No = obj.Emp_Serial_No;
                    AbsenceRecordDL.FullNameArabic = obj.FullNameArabic;
                    AbsenceRecordDL.FullNameEn = obj.FullNameEn;
                    AbsenceRecordDL.TransDate = obj.TransDate;
                    AbsenceRecordDL.Confirmed = obj.Confirmed;

                    objectList.Add(AbsenceRecordDL);

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
