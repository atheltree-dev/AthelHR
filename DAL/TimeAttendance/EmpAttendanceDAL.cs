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
    public class EmpAttendanceDAL : CommonDB

    {



        public List<GetDetailsShiftAfterCalcDL> GetDetailsShiftAfterCalc(string Company_Id, string Branch_Id, string EmpCheckIn, string EmpCheckOut, string shiftId)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<GetDetailsShiftAfterCalcDL> objectList = new List<GetDetailsShiftAfterCalcDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@EmpCheckIn", EmpCheckIn),
                new SqlParameter("@EmpCheckOut", EmpCheckOut),
                new SqlParameter("@shiftIdPara", shiftId)};

                var objlist = objPharmaEntities.Database.SqlQuery<GetDetailsShiftAfterCalcDL>("exec dbo._CalcNewShiftDetails @Company_Id,@Branch_Id,@EmpCheckIn,@EmpCheckOut,@shiftIdPara", param1).ToList();

                foreach (var obj in objlist)
                {
                    GetDetailsShiftAfterCalcDL objEmpAttendanceDL = new GetDetailsShiftAfterCalcDL();
                      
                        objEmpAttendanceDL.Shift_Id =obj.Shift_Id;
                        objEmpAttendanceDL.Shift_FromTime =obj.Shift_FromTime;
                        objEmpAttendanceDL.Shift_ToTime =obj.Shift_ToTime;
                        objEmpAttendanceDL.BeforeCheck_In_EffectInMin =obj.BeforeCheck_In_EffectInMin;
                        objEmpAttendanceDL.AfterCheck_In_EffectInMin =obj.AfterCheck_In_EffectInMin;
                        objEmpAttendanceDL.BeforeCheck_OUT_EffectInMin =obj.BeforeCheck_OUT_EffectInMin;
                        objEmpAttendanceDL.AfterCheck__OUT_EffectInMin =obj.AfterCheck__OUT_EffectInMin;
                        objEmpAttendanceDL.ShortName = obj.ShortName;
                        objEmpAttendanceDL.WorkingPeriodWithShftInMinute = obj.WorkingPeriodWithShftInMinute;
                    
                        

                        objectList.Add(objEmpAttendanceDL);

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

        public List<EmpAttendanceDL> GetEmpAttendance(string Company_Id, string Branch_Id, decimal Emp_Serial_no,string FromDate,string ToDate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpAttendanceDL> objectList = new List<EmpAttendanceDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                 new SqlParameter("@Emp_Serial_no", Emp_Serial_no),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate)};

              //  new SqlParameter("@Month_No", MonthNo)};




                var objlist = objPharmaEntities.Database.SqlQuery<EmpAttendanceDL>("exec dbo._SpSelectEmpAttendance @Company_Id,@Branch_Id,@Emp_Serial_no,@FromDate,@ToDate", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpAttendanceDL objEmpAttendanceDL = new EmpAttendanceDL();
                        objEmpAttendanceDL.Rec_Hdr_Id =obj.Rec_Hdr_Id;
                        objEmpAttendanceDL.Dtls_Id =obj.Dtls_Id;
                        objEmpAttendanceDL.Emp_Serial_No =obj.Emp_Serial_No;
                        objEmpAttendanceDL.Company_Id =obj.Company_Id;
                        objEmpAttendanceDL.Branch_Id =obj.Branch_Id;;
                        objEmpAttendanceDL.Transdate =obj.Transdate;
                        objEmpAttendanceDL.Shift_Id =obj.Shift_Id;
                        objEmpAttendanceDL.Shift_FromTime =obj.Shift_FromTime;
                        objEmpAttendanceDL.Shift_ToTime =obj.Shift_ToTime;
                        objEmpAttendanceDL.Emp_Check_InTime = obj.Emp_Check_InTime;
                        objEmpAttendanceDL.Emp_Check_OutTime = obj.Emp_Check_OutTime;
                        objEmpAttendanceDL.BeforeCheck_In =obj.BeforeCheck_In;
                        objEmpAttendanceDL.BeforeCheck_In_EffectInMin =obj.BeforeCheck_In_EffectInMin;
                        objEmpAttendanceDL.AfterCheck_In =obj.AfterCheck_In;
                        objEmpAttendanceDL.AfterCheck_In_EffectInMin =obj.AfterCheck_In_EffectInMin;
                        objEmpAttendanceDL.BeforeCheck_OUT =obj.BeforeCheck_OUT;
                        objEmpAttendanceDL.BeforeCheck_OUT_EffectInMin =obj.BeforeCheck_OUT_EffectInMin;
                        objEmpAttendanceDL.AfterCheck__OUT =obj.AfterCheck__OUT;
                        objEmpAttendanceDL.AfterCheck__OUT_EffectInMin =obj.AfterCheck__OUT_EffectInMin;
                        objEmpAttendanceDL.FullNameEn =obj.FullNameEn;
                        objEmpAttendanceDL.FullNameArabic =obj.FullNameArabic;
                        objEmpAttendanceDL.DayTypeName =obj.DayTypeName;
                        objEmpAttendanceDL.DayTypeNameEn =obj.DayTypeNameEn;
                        objEmpAttendanceDL.Admin_Id =obj.Admin_Id;
                        objEmpAttendanceDL.Dept_Id = obj.Dept_Id;
                        

                    
                        objEmpAttendanceDL.Shift_Name = obj.Shift_Name;
                        objEmpAttendanceDL.Shift_NameEn = obj.Shift_NameEn;
                        objEmpAttendanceDL.Dept_Name = obj.Dept_Name;
                        objEmpAttendanceDL.Dept_NameEn = obj.Dept_NameEn;
                        objEmpAttendanceDL.Admin_Name = obj.Admin_Name;
                        objEmpAttendanceDL.Admin_NameEn = obj.Admin_NameEn;
                        objEmpAttendanceDL.Row_Status = 0;
                        objEmpAttendanceDL.WorkingPeriodWithShftInMinute = obj.WorkingPeriodWithShftInMinute;

                        objectList.Add(objEmpAttendanceDL);

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



        public bool SaveData(List<UpdateEmpAttendanceDL> ListDtls, string UserName)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            bool Result;

            try
            {
                OpenEntityConnection();

              
                 Result = true ;


                foreach (UpdateEmpAttendanceDL Obj_Dtls in ListDtls)
                  {
                      if (Obj_Dtls != null)
                      {
                         

                          
                               Hr_EmpAttendance_Dtls loclDtlsUpdate = (from objLinq in objPharmaEntities.Hr_EmpAttendance_Dtls
                                                           where objLinq.Rec_Hdr_Id == Obj_Dtls.Rec_Hdr_Id && objLinq.Dtls_Id == Obj_Dtls.Dtls_Id 
                                                           select objLinq).FirstOrDefault();
                          if (loclDtlsUpdate !=null)
                          {
                              if (Obj_Dtls.Row_Status == 1)
                              { 
                              loclDtlsUpdate.BeforeCheck_In = Convert.ToString(Obj_Dtls.BeforeCheck_In);
                              loclDtlsUpdate.AfterCheck_In = Convert.ToString(Obj_Dtls.AfterCheck_In);
                              loclDtlsUpdate.BeforeCheck_OUT = Convert.ToString(Obj_Dtls.BeforeCheck_OUT);
                              loclDtlsUpdate.AfterCheck__OUT = Convert.ToString(Obj_Dtls.AfterCheck__OUT);

                                loclDtlsUpdate.BeforeCheck_In_EffectInMin=Obj_Dtls.BeforeCheck_In_EffectInMin;

                                loclDtlsUpdate.AfterCheck_In_EffectInMin=Obj_Dtls.AfterCheck_In_EffectInMin;

                                loclDtlsUpdate.BeforeCheck_OUT_EffectInMin=Obj_Dtls.BeforeCheck_OUT_EffectInMin;

                                loclDtlsUpdate.AfterCheck__OUT_EffectInMin=Obj_Dtls.AfterCheck__OUT_EffectInMin;

                                loclDtlsUpdate.WorkingPeriodWithShftInMinute=Obj_Dtls.WorkingPeriodWithShftInMinute;

                                loclDtlsUpdate.Shift_Id=Obj_Dtls.Shift_Id;
                                loclDtlsUpdate.Shift_FromTime=Obj_Dtls.Shift_FromTime;
                                loclDtlsUpdate.Shift_ToTime=Obj_Dtls.Shift_ToTime;

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
