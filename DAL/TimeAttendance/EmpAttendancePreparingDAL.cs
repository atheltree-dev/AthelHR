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
    public class EmpAttendancePreparingDAL : CommonDB

    {

        public bool FillFinalFingerPrint(string fromDate, string Todate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {

                OpenEntityConnection();
                object[] param1 = { 
                //new SqlParameter("@Company_Id",Company_Id),
                //new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@FromTransDate", fromDate),
                new SqlParameter("@ToTransDate", Todate)
                                  };

                bool Result;

                var objlist = objPharmaEntities.Database.SqlQuery<string>("exec [dbo].[_FillFinalFingerPrint] @FromTransDate,@ToTransDate", param1).FirstOrDefault<string>();

                Result = (objlist == null ? false : true);

                return Result;


                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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



        public bool FillTimeAttendance(string Company_Id, string Branch_Id, string fromDate, string Todate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {

                OpenEntityConnection();
                object[] param1 = { 
                new SqlParameter("@Company_IdPara",Company_Id),
                new SqlParameter("@Branch_IdPara", Branch_Id),
                new SqlParameter("@FromTransDate", fromDate),
                new SqlParameter("@ToTransDate", Todate)
                                  };

                bool Result;

                var objlist = objPharmaEntities.Database.SqlQuery<string>("exec [dbo].[_FillEmpAttendance] @Company_IdPara,@Branch_IdPara,@FromTransDate,@ToTransDate", param1).FirstOrDefault<string>();

                Result = (objlist == null ? false : true);

                return Result;


                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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


       


        public bool FillEmpDailySheet(string Company_Id, string Branch_Id, string fromDate, string Todate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {

                OpenEntityConnection();
                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
               new SqlParameter("@FromTransDate", fromDate),
                new SqlParameter("@ToTransDate", Todate)
                                  };

                bool Result;

                var objlist = objPharmaEntities.Database.SqlQuery<string>("exec [dbo].[_FillEmpDailySheet] @Company_Id,@Branch_Id,@FromTransDate,@ToTransDate", param1).FirstOrDefault<string>();

                Result = (objlist == null ? false : true);

                return Result;


                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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

        public bool ConfirmDailyTimeSheet(string Company_Id, string Branch_Id, string fromDate, string Todate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {

                OpenEntityConnection();
                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@FromTransDate", fromDate),
                new SqlParameter("@ToTransDate", Todate)
                                  };

                bool Result;

                var objlist = objPharmaEntities.Database.SqlQuery<string>("exec [dbo].[_ConfirmDailyTimeSheet] @Company_Id,@Branch_Id,@FromTransDate,@ToTransDate", param1).FirstOrDefault<string>();

                Result = (objlist == null ? false : true);

                return Result;


                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

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

      

    }
}
