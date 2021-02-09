using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.TimeAttendance;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DAL.TimeAttendance
{
    public class EmpFinalFingerPrintDAL : CommonDB

    {

        public List<EmpFinalFingerPrintDL> GetFinalFingerPrint(string Company_Id, string Branch_Id, decimal Emp_Serial_no, string FromDate, string ToDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpFinalFingerPrintDL> objectList = new List<EmpFinalFingerPrintDL>();

                object[] param1 = {
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_no", Emp_Serial_no),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate)};

                var objlist = objPharmaEntities.Database.SqlQuery<EmpFinalFingerPrintDL>("exec dbo._SpSelectFinalFingerPrint @Company_Id,@Branch_Id,@Emp_Serial_no,@FromDate,@ToDate", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpFinalFingerPrintDL objEmpFinalFingerPrintDL = new EmpFinalFingerPrintDL();
                    objEmpFinalFingerPrintDL.Rec_Id = obj.Rec_Id;
                    objEmpFinalFingerPrintDL.EnrollNumber = obj.EnrollNumber;
                    objEmpFinalFingerPrintDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpFinalFingerPrintDL.TMachineNumber = obj.TMachineNumber;
                    objEmpFinalFingerPrintDL.InOutMode = obj.InOutMode;
                    objEmpFinalFingerPrintDL.Branch_Id = obj.Branch_Id; ;
                    objEmpFinalFingerPrintDL.transdate = obj.transdate;
                    objEmpFinalFingerPrintDL.InOutModeName = obj.InOutModeName;
                    objEmpFinalFingerPrintDL.DateTimeEnroll = obj.DateTimeEnroll;
                    objEmpFinalFingerPrintDL.FullNameEn = obj.FullNameEn;
                    objEmpFinalFingerPrintDL.FullNameArabic = obj.FullNameArabic;
                    objEmpFinalFingerPrintDL.Admin_Id = obj.Admin_Id;
                    objEmpFinalFingerPrintDL.Dept_Id = obj.Dept_Id;
                    objEmpFinalFingerPrintDL.Dept_Name = obj.Dept_Name;
                    objEmpFinalFingerPrintDL.Dept_NameEn = obj.Dept_NameEn;
                    objEmpFinalFingerPrintDL.Admin_Name = obj.Admin_Name;
                    objEmpFinalFingerPrintDL.Admin_NameEn = obj.Admin_NameEn;
                    objEmpFinalFingerPrintDL.Row_Status = 0;
                    objEmpFinalFingerPrintDL.DataInputType = obj.DataInputType;


                    objectList.Add(objEmpFinalFingerPrintDL);

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

        public List<EmpHaveProblemInFinalFPDL> GetEmployeeHaveFpProblem(string Company_Id, string Branch_Id, string FromDate, string ToDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpHaveProblemInFinalFPDL> objectList = new List<EmpHaveProblemInFinalFPDL>();

                object[] param1 = {
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate)};

                var objlist = objPharmaEntities.Database.SqlQuery<EmpHaveProblemInFinalFPDL>("exec dbo._getEmployeeHaveFpProblem @Company_Id,@Branch_Id,@FromDate,@ToDate", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpHaveProblemInFinalFPDL objEmpHaveProblemInFinalFPDL = new EmpHaveProblemInFinalFPDL();
                    objEmpHaveProblemInFinalFPDL.EnrollNumber = obj.EnrollNumber;
                    objEmpHaveProblemInFinalFPDL.FullNameEn = obj.FullNameEn;
                    objEmpHaveProblemInFinalFPDL.FullNameArabic = obj.FullNameArabic;
                    objEmpHaveProblemInFinalFPDL.Status = obj.Status;
                    objEmpHaveProblemInFinalFPDL.StatusName = obj.StatusName;
                    objEmpHaveProblemInFinalFPDL.TimeFPIn = obj.TimeFPIn;
                    objEmpHaveProblemInFinalFPDL.TimeFPOut = obj.TimeFPOut;
                    objEmpHaveProblemInFinalFPDL.Emp_Serial_No = obj.Emp_Serial_No;
                    objEmpHaveProblemInFinalFPDL.Transdate = obj.Transdate;


                    objectList.Add(objEmpHaveProblemInFinalFPDL);

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



        public int SaveData(Hr_FinalFingerPrint objInsert)
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

                    objInsert.Rec_Id = GetNewHeaderId();
                    objPharmaEntities.Hr_FinalFingerPrint.Add(objInsert);
                    RowEffected = objPharmaEntities.SaveChanges();
                }



            }
            catch (Exception ex)
            {
                RowEffected = -1;
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();


            }
            finally
            {
                CloseEntityConnection();
            }
            return RowEffected;

        }


        public bool SaveUpdateData(List<UpdateFinalFingerPrintDL> ListDtls, string UserName)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            bool Result;

            try
            {
                OpenEntityConnection();


                Result = true;


                foreach (UpdateFinalFingerPrintDL Obj_Dtls in ListDtls)
                {
                    if (Obj_Dtls != null)
                    {



                        Hr_FinalFingerPrint loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_FinalFingerPrint
                                                              where objLinq.Rec_Id == Obj_Dtls.Rec_Id
                                                              select objLinq).FirstOrDefault();
                        if (loclDtlsUpdate != null)
                        {
                            if (Obj_Dtls.Row_Status == 1)
                            {
                                loclDtlsUpdate.InOutMode = Convert.ToString(Obj_Dtls.InOutMode);
                                loclDtlsUpdate.UpdateFPStatus = 1;

                                loclDtlsUpdate.UpdateDate = DateTime.Now;
                                loclDtlsUpdate.UpdateUser = UserName;
                                objPharmaEntities.SaveChanges();
                                // Result = (objPharmaEntities.SaveChanges() > 0);
                            }
                            //  dbTran.Commit();
                        }



                    }

                }
                return Result;




            }
            catch (Exception ex)
            {
                Result = false;
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



        public bool DeleteRow(Guid RowID)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            bool Result;

            try
            {
                OpenEntityConnection();

                Result = true;
                if (RowID != Guid.Empty)
                {
                    Hr_FinalFingerPrint loclDtlsDelete = (from objLinq in objPharmaEntities.Hr_FinalFingerPrint
                                                          where objLinq.Rec_Id == RowID
                                                          select objLinq).FirstOrDefault();
                    if (loclDtlsDelete != null)
                    {
                        objPharmaEntities.Hr_FinalFingerPrint.Remove(loclDtlsDelete);
                        objPharmaEntities.SaveChanges();
                        Result = true;
                    }
                    else
                    {
                        Result = false; ;
                    }
                }

                return Result;



            }
            catch (Exception ex)
            {
                Result = false;
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




    }
}
