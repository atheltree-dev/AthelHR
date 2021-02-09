using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Data;

// For execute any sqlcommand
using System.Data.Entity;

using System.Data.SqlClient;
using System.Data.Entity.Validation;
using BOL.TimeAttendance;

namespace DAL.IntegrationGL.IntegrationManagement
{
  public  class MontlyPayrollPostingSettingDAL : CommonDB

    {

    
    
     

      public bool FillPayrollPostingData(string Company_Id, string Branch_Id, string MonthNo, decimal Emp_Serial_No)
        {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();
          try
          {
             OpenEntityConnection();
              object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo),
                 new SqlParameter("@Emp_Serial_No", Emp_Serial_No)};


              object objlist = objPharmaEntities.Database.SqlQuery<List<string>>("exec dbo._SPMontlyPayrollPosting @Company_Id,@Branch_Id,@MonthNo,@Emp_Serial_No", param1).ToList();

                bool Result;
                Result = (objlist == null?false:true);

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


        public bool FillPayrollPaymentPostingData(string Company_Id, string Branch_Id, string MonthNo, decimal Emp_Serial_No,string AccruedHireitem_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                OpenEntityConnection();
                object[] param1 = {
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@MonthNo", MonthNo),
                new SqlParameter("@AccruedHireitem_Id", AccruedHireitem_Id),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No)};



                object objlist = objPharmaEntities.Database.SqlQuery<List<string>>("exec dbo._SPMontlyPayrollPaymentPosting @Company_Id, @Branch_Id,@MonthNo,@AccruedHireitem_Id,@Emp_Serial_No", param1).ToList();

                bool Result;
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
