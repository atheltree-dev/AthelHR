using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
//using BOL.Registeration.Registeration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Validation;


namespace DAL.HrServices.RequestManagement
{
  public  class EmpBeginAnnualVacTransferdBalDAL:CommonDB

    {
     
      public int InsertTask(Hr_EmpBeginAnnualVacTransferdBal objInsert)
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


                  
                  objInsert.Insdate = DateTime.Now;//DateTime.Today;

                  objPharmaEntities.Hr_EmpBeginAnnualVacTransferdBal.Add(objInsert);

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


      public string ChkUserBeginBalIsExist(decimal StrEmp_Serial, string Company_Id, string Branch_Id)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();
          try
          {
              OpenEntityConnection();
              object[] param1 = {
               
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_serial", StrEmp_Serial)};

              string strsql = "select top 1 TotBalByDays from Hr_EmpBeginAnnualVacTransferdBal where Company_Id=@Company_Id and Branch_Id=@Branch_Id and Emp_Serial_No=@Emp_serial";

              var result = Convert.ToString(objPharmaEntities.Database.SqlQuery<decimal>(strsql, param1).FirstOrDefault<decimal>());

              result = ((result == null || result == "") ? "0" : result);

              return result;

              //Rec_No ,ReferenceNo ,Request_Id 
              //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

          }
          catch (Exception ex)
          {
              catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                      this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
              ex.InnerException.Message.ToString();
              return "0";

          }
          finally
          {
              CloseEntityConnection();
          }


      }

      public decimal ChkAboutBeginVacation(decimal Emp_Serial_No, string Company_Id, string Branch_Id, string startContractDataTillNow, string EndContractDataTillNow)
        {
            decimal Fresult;
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            try
            {
                OpenEntityConnection();
                object[] param1 = {
                new SqlParameter("@Company_Id", Company_Id),
                new SqlParameter("@Branch_Id",Branch_Id),
                new SqlParameter("@Emp_Serial_No", Emp_Serial_No),
                new SqlParameter("@startContractDataTillNow",startContractDataTillNow),
                new SqlParameter("@EndContractDataTillNow", EndContractDataTillNow)};

                var result = objPharmaEntities.Database.SqlQuery<decimal>("exec dbo._SpgetChkAboutBeginVacation @Company_Id,@Branch_Id,@Emp_Serial_No,startContractDataTillNow,EndContractDataTillNow", param1).FirstOrDefault<decimal>();

                 Fresult = ((result == null) ? 0 : result);

                return Fresult;

               

                //Rec_No ,ReferenceNo ,Request_Id 
                //,Company_Id ,Branch_Id ,Emp_Serial_No ,TransDate ,FromDate ,ToDate ,BackDate ,Reason ,InsUser ,InsDate ,Order_Status ,PlaceOfResidence ,DocumentPath ,RequestTypeName ,StatusName 

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return 0;

            }
            finally
            {
                CloseEntityConnection();
            }


        }


      
     




    }
}
