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
    public class PermissionRecordDAL : CommonDB
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


        public bool SavePermissionRecordData(List<PermissionRecordDL> objList)
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

                            Hr_EmpPermissionRecord newobj = new Hr_EmpPermissionRecord();
                            newobj.Rec_Hdr_Id = GetNewHeaderId();
                            newobj.Company_Id = obj.Company_Id;
                            newobj.Branch_Id = obj.Branch_Id;
                            newobj.Emp_Serial_No = obj.Emp_Serial_No;
                            newobj.TransDate = DateTime.Now.ToString("yyyyMMdd");
                            newobj.PermissionDate = obj.PermissionDate;
                            newobj.Request_Id = "10";
                            newobj.Rec_Order_No = "0";
                            newobj.Rec_Order_HdrId = maxId;
                            newobj.FromTime = obj.FromTime;
                            newobj.ToTime = obj.ToTime;
                            newobj.Permission_Period = obj.Permission_Period;
                            newobj.InsUser = UserNameProperty;
                            newobj.InsDate = DateTime.Now;
                            newobj.DocumentPath = null;
                            newobj.Commissioner_Serial_no = obj.Emp_Serial_No;
                            newobj.Permission_Type = obj.Permission_Type;
                            newobj.HireItem_Id = "0011";
                            newobj.Permission_Reason_Id = obj.Permission_Reason_Id;
                            newobj.Permission_Reason_Sub_Id = obj.Permission_Reason_Sub_Id;
                            newobj.Confirmed = 0;


                            objPharmaEntities.Hr_EmpPermissionRecord.Add(newobj);
                            Result = objPharmaEntities.SaveChanges();

                        }
                        //Edit
                        else if (obj.RecStatus == 2)
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {

                                Hr_EmpPermissionRecord ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpPermissionRecord
                                                                       where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {

                                    ObjForUpdate.PermissionDate = obj.PermissionDate;
                                    ObjForUpdate.FromTime = obj.FromTime;
                                    ObjForUpdate.ToTime = obj.ToTime;
                                    ObjForUpdate.Permission_Period = obj.Permission_Period;
                                    ObjForUpdate.Permission_Type = obj.Permission_Type;
                                    ObjForUpdate.Emp_Serial_No = obj.Emp_Serial_No;
                                    ObjForUpdate.Permission_Reason_Id = obj.Permission_Reason_Id;
                                    ObjForUpdate.Permission_Reason_Sub_Id = obj.Permission_Reason_Sub_Id;



                                    Result = objPharmaEntities.SaveChanges();
                                }
                            }
                            else
                            {
                                Hr_EmpPermissionRecord newobj = new Hr_EmpPermissionRecord();
                                newobj.Rec_Hdr_Id = GetNewHeaderId();
                                newobj.Company_Id = obj.Company_Id;
                                newobj.Branch_Id = obj.Branch_Id;
                                newobj.Emp_Serial_No = obj.Emp_Serial_No;
                                newobj.TransDate = DateTime.Now.ToString("yyyyMMdd");
                                newobj.PermissionDate = obj.PermissionDate;
                                newobj.Request_Id = "10";
                                newobj.Rec_Order_No = "0";
                                newobj.Rec_Order_HdrId = maxId;
                                newobj.FromTime = obj.FromTime;
                                newobj.ToTime = obj.ToTime;
                                newobj.Permission_Period = obj.Permission_Period;
                                newobj.InsUser = UserNameProperty;
                                newobj.InsDate = DateTime.Now;
                                newobj.DocumentPath = null;
                                newobj.Commissioner_Serial_no = obj.Emp_Serial_No;
                                newobj.Permission_Type = obj.Permission_Type;
                                newobj.HireItem_Id = "0011";
                                newobj.Permission_Reason_Id = obj.Permission_Reason_Id;
                                newobj.Permission_Reason_Sub_Id = obj.Permission_Reason_Sub_Id;
                                newobj.Confirmed = 0;


                                objPharmaEntities.Hr_EmpPermissionRecord.Add(newobj);
                                Result = objPharmaEntities.SaveChanges();
                            }

                        }
                        //Delete
                        else if (obj.RecStatus == 3 )
                        {
                            if (obj.Rec_Hdr_Id != Guid.Empty)
                            {
                                Hr_EmpPermissionRecord ObjForDelete = (from objLinq in objPharmaEntities.Hr_EmpPermissionRecord
                                                                       where objLinq.Rec_Hdr_Id == obj.Rec_Hdr_Id
                                                                     select objLinq).FirstOrDefault();
                                if (ObjForDelete != null)
                                {
                                    objPharmaEntities.Hr_EmpPermissionRecord.Remove(ObjForDelete);
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



        public List<PermissionRecordDL> GetPermissionRecordData(decimal EmpSerial_No, string FromDate, string ToDate, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<PermissionRecordDL> objectList = new List<PermissionRecordDL>();


                object[] param1 = {

                new SqlParameter("@Emp_Serial_No", EmpSerial_No),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id)

             };


                var objlist = objPharmaEntities.Database.SqlQuery<PermissionRecordDL>("exec dbo.sp_GetPermissionRecord @Emp_Serial_No, @FromDate, @ToDate,@Company_Id,@Branch_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    PermissionRecordDL PermissionRecordDL = new PermissionRecordDL();
                    PermissionRecordDL.Rec_Hdr_Id = obj.Rec_Hdr_Id;
                    PermissionRecordDL.Company_Id = obj.Company_Id;
                    PermissionRecordDL.Branch_Id = obj.Branch_Id;
                    PermissionRecordDL.Emp_Serial_No = obj.Emp_Serial_No;
                    PermissionRecordDL.FullNameArabic = obj.FullNameArabic;
                    PermissionRecordDL.FullNameEn = obj.FullNameEn;
                    PermissionRecordDL.TransDate = obj.TransDate;
                    PermissionRecordDL.PermissionDate = obj.PermissionDate;
                    // PermissionRecordDL.Rec_Order_No = "0";
                    // PermissionRecordDL.Rec_Order_HdrId = maxId;
                    PermissionRecordDL.FromTime = obj.FromTime;
                    PermissionRecordDL.ToTime = obj.ToTime;
                    PermissionRecordDL.Permission_Period = obj.Permission_Period;
                    // PermissionRecordDL.InsUser = UserNameProperty;
                    // PermissionRecordDL.InsDate = DateTime.Now;
                    // PermissionRecordDL.DocumentPath =null;
                    PermissionRecordDL.Commissioner_Serial_no = obj.Emp_Serial_No;
                    PermissionRecordDL.Permission_Type = obj.Permission_Type;
                    PermissionRecordDL.PermissionType_Name = obj.PermissionType_Name;
                    PermissionRecordDL.PermissionType_NameEn = obj.PermissionType_NameEn;
                    // PermissionRecordDL. = "0011";
                    PermissionRecordDL.Permission_Reason_Id = obj.Permission_Reason_Id;
                    PermissionRecordDL.PermissionReason_Name = obj.PermissionReason_Name;
                    PermissionRecordDL.PermissionReason_NameEn = obj.PermissionReason_NameEn;
                    PermissionRecordDL.Permission_Reason_Sub_Id = obj.Permission_Reason_Sub_Id;
                    PermissionRecordDL.PermissionSubReason_Name = obj.PermissionSubReason_Name;
                    PermissionRecordDL.PermissionSubReason_NameEn = obj.PermissionSubReason_NameEn;
                    PermissionRecordDL.Confirmed = obj.Confirmed;


                    objectList.Add(PermissionRecordDL);

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
