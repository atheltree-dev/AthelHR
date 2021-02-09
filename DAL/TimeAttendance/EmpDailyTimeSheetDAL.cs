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
    public class EmpDailyTimeSheetDAL : CommonDB

    {

        public List<EmpDailyTimeSheetDL> GetEmpDailySheet(string Company_Id, string Branch_Id, decimal Emp_Serial_no, string FromDate, string ToDate, string strwhere)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpDailyTimeSheetDL> objectList = new List<EmpDailyTimeSheetDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@Emp_Serial_no", Emp_Serial_no),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@StrWhere", strwhere)};
               // new SqlParameter("@Month_No", MonthNo)};

                var objlist = objPharmaEntities.Database.SqlQuery<EmpDailyTimeSheetDL>("exec dbo._SpSelectEmpDailySheet @Company_Id,@Branch_Id,@Emp_Serial_no,@FromDate,@ToDate,@StrWhere", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpDailyTimeSheetDL objEmpDailyTimeSheetDL = new EmpDailyTimeSheetDL();
                        objEmpDailyTimeSheetDL.Rec_Hdr_Id =obj.Rec_Hdr_Id;
                        
                        objEmpDailyTimeSheetDL.Emp_Serial_No =obj.Emp_Serial_No;
                        objEmpDailyTimeSheetDL.Company_Id =obj.Company_Id;
                        objEmpDailyTimeSheetDL.Branch_Id =obj.Branch_Id;;
                        objEmpDailyTimeSheetDL.Transdate =obj.Transdate;
                        objEmpDailyTimeSheetDL.Shift_Id =obj.Shift_Id;
                        
                        objEmpDailyTimeSheetDL.Emp_Check_InTime = obj.Emp_Check_InTime;
                        objEmpDailyTimeSheetDL.Emp_Check_OutTime = obj.Emp_Check_OutTime;
                        
                        
                        objEmpDailyTimeSheetDL.ExtraAmountInMinut = obj.ExtraAmountInMinut;    
                        objEmpDailyTimeSheetDL.OvertimePeriodFrmRqustInMinute = obj.OvertimePeriodFrmRqustInMinute;
   
                        objEmpDailyTimeSheetDL.DelyAmountInMinut = obj.DelyAmountInMinut;
                        objEmpDailyTimeSheetDL.PermissionPeriodFrmRqustInMinute = obj.PermissionPeriodFrmRqustInMinute;

                        objEmpDailyTimeSheetDL.EmpInVacation = obj.EmpInVacation;
                    
                        objEmpDailyTimeSheetDL.ApplyExtra = obj.ApplyExtra;
                        objEmpDailyTimeSheetDL.ApplyDely = obj.ApplyDely;
                        objEmpDailyTimeSheetDL.ApplyAbsence = obj.ApplyAbsence;

                        objEmpDailyTimeSheetDL.FullNameEn =obj.FullNameEn;
                        objEmpDailyTimeSheetDL.FullNameArabic =obj.FullNameArabic;
                        objEmpDailyTimeSheetDL.DayTypeName =obj.DayTypeName;
                        objEmpDailyTimeSheetDL.DayTypeNameEn =obj.DayTypeNameEn;
                        objEmpDailyTimeSheetDL.Admin_Id =obj.Admin_Id;
                        objEmpDailyTimeSheetDL.Dept_Id = obj.Dept_Id;
                        objEmpDailyTimeSheetDL.ShortName = obj.ShortName;
                        objEmpDailyTimeSheetDL.WeekSysDayName = obj.WeekSysDayName;
                        objEmpDailyTimeSheetDL.WeekSysDayNameEn = obj.WeekSysDayNameEn;
                        objEmpDailyTimeSheetDL.Shift_Name = obj.Shift_Name;
                        objEmpDailyTimeSheetDL.Shift_NameEn = obj.Shift_NameEn;
                        objEmpDailyTimeSheetDL.Dept_Name = obj.Dept_Name;
                        objEmpDailyTimeSheetDL.Dept_NameEn = obj.Dept_NameEn;
                        objEmpDailyTimeSheetDL.Admin_Name = obj.Admin_Name;
                        objEmpDailyTimeSheetDL.Admin_NameEn = obj.Admin_NameEn;
                        objEmpDailyTimeSheetDL.DiffDelyInMinut = obj.DiffDelyInMinut;
                        objEmpDailyTimeSheetDL.DiffExtraInMinut = obj.DiffExtraInMinut;

                        objEmpDailyTimeSheetDL.DayType = obj.DayType;
                        objEmpDailyTimeSheetDL.DayCode = obj.DayCode;

                        objEmpDailyTimeSheetDL.Row_Status = 0;
                        

                        objectList.Add(objEmpDailyTimeSheetDL);

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



        public bool SaveData(List<UpdateEmpDailyTimeSheetDL> ListDtls, string UserName)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            bool Result;

            try
            {
                OpenEntityConnection();

              
                 Result = true ;


                foreach (UpdateEmpDailyTimeSheetDL Obj_Dtls in ListDtls)
                  {
                      if (Obj_Dtls != null)
                      {



                          Hr_DailyTimeSheet loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_DailyTimeSheet
                                                              where objLinq.Rec_Hdr_Id == Obj_Dtls.Rec_Hdr_Id 
                                                           select objLinq).FirstOrDefault();
                          if (loclDtlsUpdate !=null)
                          {
                              if (Obj_Dtls.Row_Status == 1)
                              { 
                              loclDtlsUpdate.ApplyDely = Convert.ToString(Obj_Dtls.ApplyDely);
                              loclDtlsUpdate.ApplyExtra = Convert.ToString(Obj_Dtls.ApplyExtra);
                              loclDtlsUpdate.ApplyAbsence = Convert.ToString(Obj_Dtls.ApplyAbsence);
                              
                              loclDtlsUpdate.UpdateDate =  DateTime.Now;
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


      

    }
}
