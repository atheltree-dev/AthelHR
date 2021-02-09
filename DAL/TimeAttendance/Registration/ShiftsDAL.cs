using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
//using BOL.Registeration.Registeration;
using System.Data;

// For execute any sqlcommand
using System.Data.Entity;

using System.Data.SqlClient;
using System.Data.Entity.Validation;
using BOL.TimeAttendance.Registration;

namespace DAL.TimeAttendance.Registration
{
    public class ShiftsDAL : CommonDB

    {

        public class HiringEmpDetailseDuesDL
        {
            public string Company_Id { get; set; }
            public string Branch_Id { get; set; }
            public decimal? Emp_Serial_no { get; set; }
            public string MonthNo { get; set; }
            public string HireItem_Id { get; set; }
            public string HireItem_Name { get; set; }
            public string HireItem_NameEn { get; set; }
            public decimal? NetAccrued_days { get; set; }
            public decimal? NetAccrued_Amount { get; set; }
            public byte IsPayed { get; set; }
            public byte TransType { get; set; }
            public byte IsOpening { get; set; }


        }

        public class HiringEmpHiringNotAdoptDL
        {


            public Guid Hdr_Id { get; set; }
            public string NameAr { get; set; }

            public string NameEn { get; set; }

            public decimal Emp_Serial_No { get; set; }

        }

        public class HiringEmpHiringNotAdoptDtlsDL
        {


            public Guid Hdr_Id { get; set; }
            public Guid Dtls_Id { get; set; }
            public string HireItemId { get; set; }

            public string HireItemName { get; set; }

            public decimal HireItemValue { get; set; }
            public Nullable<byte> Confirmed { get; set; }

        }




        

     

        //public bool AddShiftGroup(Hr_ShiftGroups ObjGroupDL)
        //{
        //    StackFrame stackFrame = new StackFrame();
        //    MethodBase methodBase = stackFrame.GetMethod();

        //    var strErrorMessage = string.Empty;

        //    bool result = true;


        //    try
        //    {
        //        if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //        {
        //            objPharmaEntities.Database.Connection.Open();
        //        }
        //        if (ObjGroupDL.Rec_Status == 0)
        //        {
        //            if (ObjGroupDL.ShiftGroup_Id == null || ObjGroupDL.ShiftGroup_Id == "")
        //            {


        //                Hr_ShiftGroups ShiftGroups = new Hr_ShiftGroups
        //                {
        //                    Company_Id = ObjGroupDL.Company_Id,
        //                    Branch_Id = ObjGroupDL.Branch_Id,
        //                    ShiftGroup_Id = GetNewId(ObjGroupDL.Company_Id, ObjGroupDL.Branch_Id),
        //                    ShiftGroup_Name = ObjGroupDL.ShiftGroup_Name,
        //                    ShiftGroup_NameEn = ObjGroupDL.ShiftGroup_NameEn,
        //                    ShiftGroup_ShortName = ObjGroupDL.ShiftGroup_ShortName,
        //                    ShiftGroup_NameConv = ObjGroupDL.ShiftGroup_NameConv,
        //                    InsUser = UserNameProperty,
        //                    InsDate = DateTime.Now,
        //                    UpdateUser = null,
        //                    UpdateDate = null,
        //                    DeleteDate = null,
        //                    DeleteUser = null,
        //                    Rec_Status = ObjGroupDL.Rec_Status,

        //                };


        //                objPharmaEntities.Hr_ShiftGroups.Add(ShiftGroups);
        //                //saves all above operations within one transaction
        //                objPharmaEntities.SaveChanges();
        //            }

        //            return result;
        //        }

        //        else if (ObjGroupDL.Rec_Status == 1)
        //        {
        //            if (ObjGroupDL.ShiftGroup_Id != null && ObjGroupDL.ShiftGroup_Id != "")
        //            {

        //                Hr_ShiftGroups ObjForUpdate = (from objLinq in objPharmaEntities.Hr_ShiftGroups
        //                                               where objLinq.ShiftGroup_Id == ObjGroupDL.ShiftGroup_Id
        //                                               select objLinq).FirstOrDefault();

        //                if (ObjForUpdate != null)
        //                {

        //                    ObjForUpdate.ShiftGroup_Name = ObjGroupDL.ShiftGroup_Name;
        //                    ObjForUpdate.ShiftGroup_NameEn = ObjGroupDL.ShiftGroup_NameEn;
        //                    ObjForUpdate.UpdateDate = DateTime.Now;
        //                    ObjForUpdate.UpdateUser = UserNameProperty;


        //                    objPharmaEntities.SaveChanges();
        //                    return result;
        //                }
        //            }
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
        //                this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
        //        ex.InnerException.Message.ToString();
        //        return false;

        //    }
        //    finally
        //    {

        //    }



        //}


        public List<ShiftsDL> SelectShitGroups(string Company_Id, string Branch_Id, string ShiftGroup_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<ShiftsDL> objectList = new List<ShiftsDL>();

                object[] param1 = {
               new SqlParameter("@Company_Id", Company_Id),
               new SqlParameter("@Branch_Id", Branch_Id),
               new SqlParameter("@ShiftGroup_Id", ShiftGroup_Id)

                };

                var objlist = objPharmaEntities.Database.SqlQuery<ShiftsDL>("exec dbo.sp_GetShiftGroupData @Company_Id,@Branch_Id, @ShiftGroup_Id", param1).ToList();


                foreach (var obj in objlist)
                {
                    ShiftsDL ShiftsDL = new ShiftsDL();
                    ShiftsDL.Company_Id = obj.Company_Id;
                    ShiftsDL.Branch_Id = obj.Branch_Id;
                    ShiftsDL.ShiftGroup_Id = obj.ShiftGroup_Id;
                    ShiftsDL.ShiftGroup_Name = obj.ShiftGroup_Name;
                    ShiftsDL.ShiftGroup_NameConv = obj.ShiftGroup_NameConv;
                    ShiftsDL.ShiftGroup_NameEn = obj.ShiftGroup_NameEn;
                    ShiftsDL.ShiftGroup_ShortName = obj.ShiftGroup_ShortName;
                    ShiftsDL.Id = obj.Id;
                    ShiftsDL.InsDate = obj.InsDate;
                    ShiftsDL.InsUser = obj.InsUser;
                    ShiftsDL.UpdateDate = obj.UpdateDate;
                    ShiftsDL.UpdateUser = obj.UpdateUser;
                    ShiftsDL.DeleteDate = obj.DeleteDate;
                    ShiftsDL.DeleteUser = obj.DeleteUser;
                    ShiftsDL.Rec_Status = obj.Rec_Status;




                    objectList.Add(ShiftsDL);

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

        public List<ShiftsDetailsDL> GetShiftDetails(string Company_Id, string Branch_Id, string ShiftGroupID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<ShiftsDetailsDL> objectList = new List<ShiftsDetailsDL>();

                object[] param1 = {

                new SqlParameter("@Company_Id", Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@ShiftGroupID", ShiftGroupID),
             };

                var objlist = objPharmaEntities.Database.SqlQuery<ShiftsDetailsDL>("exec dbo.sp_GetShiftDetails @Company_Id,@Branch_Id,@ShiftGroupID", param1).ToList();

                foreach (var obj in objlist)
                {
                    ShiftsDetailsDL ShiftsDetailsDL = new ShiftsDetailsDL();


                    ShiftsDetailsDL.Company_Id = obj.Company_Id;
                    ShiftsDetailsDL.Branch_Id = obj.Branch_Id;
                    ShiftsDetailsDL.Shift_Id = obj.Shift_Id;
                    ShiftsDetailsDL.Shift_Hdr_Id = obj.Shift_Hdr_Id;
                    ShiftsDetailsDL.Shift_Name = obj.Shift_Name;
                    ShiftsDetailsDL.Shift_NameEn = obj.Shift_NameEn;
                    ShiftsDetailsDL.ShortName = obj.ShortName;
                    ShiftsDetailsDL.Shift_NameConv = obj.Shift_NameConv;
                    ShiftsDetailsDL.From_Time = obj.From_Time;
                    ShiftsDetailsDL.To_Time = obj.To_Time;
                    ShiftsDetailsDL.Shift_DurationByMin = obj.Shift_DurationByMin;
                    ShiftsDetailsDL.BreakFrom_Time = obj.BreakFrom_Time;
                    ShiftsDetailsDL.BreakTo_Time = obj.BreakTo_Time;
                    ShiftsDetailsDL.Break_DurationByMin = obj.Break_DurationByMin;
                    ShiftsDetailsDL.AllowedPeriodToCalcByMin = obj.AllowedPeriodToCalcByMin;
                    ShiftsDetailsDL.InsUser = obj.InsUser;
                    ShiftsDetailsDL.InsDate = obj.InsDate;
                    ShiftsDetailsDL.UpdateUser = obj.UpdateUser;
                    ShiftsDetailsDL.UpdateDate = obj.UpdateDate;
                    ShiftsDetailsDL.DeleteUser = obj.DeleteUser;
                    ShiftsDetailsDL.DeleteDate = obj.DeleteDate;
                    ShiftsDetailsDL.Rec_Status = obj.Rec_Status;
                    ShiftsDetailsDL.ShiftGroup_Id = obj.Company_Id;


                    objectList.Add(ShiftsDetailsDL);

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


        public string GetNewId(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 ShiftGroup_Id as ShiftGroup_Id  from Hr_ShiftGroups where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(ShiftGroup_Id))+ShiftGroup_Id desc";
                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
                if (maxId != null)
                {
                    nextId = (Convert.ToInt16(maxId) + 1).ToString();

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


        public bool SaveShiftsData(Hr_ShiftGroups ObjGroupDL, List<ShiftsDetailsDL> ShiftsDetailsDL)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            var strErrorMessage = string.Empty;

            bool result = true;
            var GroupID = GetNewId(ObjGroupDL.Company_Id, ObjGroupDL.Branch_Id);
            try
            {

                OpenEntityConnection();

                //    result = AddShiftGroup(ObjGroupD);

                if (ObjGroupDL != null && ShiftsDetailsDL != null)
                {

                    if (ObjGroupDL.Rec_Status == 0)
                {
                    if (ObjGroupDL.ShiftGroup_Id == null || ObjGroupDL.ShiftGroup_Id == "")
                    {


                        Hr_ShiftGroups ShiftGroups = new Hr_ShiftGroups
                        {
                            Company_Id = ObjGroupDL.Company_Id,
                            Branch_Id = ObjGroupDL.Branch_Id,
                            ShiftGroup_Id = GroupID,
                            ShiftGroup_Name = ObjGroupDL.ShiftGroup_Name,
                            ShiftGroup_NameEn = ObjGroupDL.ShiftGroup_NameEn,
                            ShiftGroup_ShortName = ObjGroupDL.ShiftGroup_ShortName,
                            ShiftGroup_NameConv = ObjGroupDL.ShiftGroup_NameConv,
                            InsUser = UserNameProperty,
                            InsDate = DateTime.Now,
                            UpdateUser = null,
                            UpdateDate = null,
                            DeleteDate = null,
                            DeleteUser = null,
                            Rec_Status = ObjGroupDL.Rec_Status,

                        };


                        objPharmaEntities.Hr_ShiftGroups.Add(ShiftGroups);
                        //saves all above operations within one transaction
                        objPharmaEntities.SaveChanges();
                    }

                    //return result;
                }

                else if (ObjGroupDL.Rec_Status == 1)
                {
                    if (ObjGroupDL.ShiftGroup_Id != null && ObjGroupDL.ShiftGroup_Id != "")
                    {

                        Hr_ShiftGroups ObjForUpdate = (from objLinq in objPharmaEntities.Hr_ShiftGroups
                                                       where objLinq.ShiftGroup_Id == ObjGroupDL.ShiftGroup_Id
                                                       select objLinq).FirstOrDefault();

                        if (ObjForUpdate != null)
                        {

                            ObjForUpdate.ShiftGroup_Name = ObjGroupDL.ShiftGroup_Name;
                            ObjForUpdate.ShiftGroup_NameEn = ObjGroupDL.ShiftGroup_NameEn;
                            ObjForUpdate.UpdateDate = DateTime.Now;
                            ObjForUpdate.UpdateUser = UserNameProperty;


                            objPharmaEntities.SaveChanges();
                           // return result;
                        }
                    }
                }



                //if (ShiftsDetailsDL != null)
                //    {
                        foreach (var obj in ShiftsDetailsDL)
                        {
                            var HdrId = GetNewHeaderId();
                            // data base bind
                            if (obj.Rec_Status == 0)
                            {

                            }
                            //Add
                            else if (obj.Rec_Status == 1)
                            {

                                Hr_Shifts newobj = new Hr_Shifts();
                                newobj.Company_Id = obj.Company_Id;
                                newobj.Branch_Id = obj.Branch_Id;
                                newobj.Shift_Id = GetNewShiftId(obj.Company_Id, obj.Branch_Id);
                                newobj.Shift_Hdr_Id = HdrId;
                                newobj.Shift_Name = obj.Shift_Name;
                                newobj.Shift_NameEn = obj.Shift_NameEn;
                                newobj.AllowedPeriodToCalcByMin = obj.AllowedPeriodToCalcByMin;
                                newobj.Shift_NameConv = obj.Shift_NameConv;
                                newobj.ShortName = obj.ShortName;
                                newobj.From_Time = obj.From_Time;
                                newobj.To_Time = obj.To_Time;
                                newobj.Shift_DurationByMin = obj.Shift_DurationByMin;
                                newobj.BreakFrom_Time = obj.BreakFrom_Time;
                                newobj.BreakTo_Time = obj.BreakTo_Time;
                                newobj.Break_DurationByMin = obj.Break_DurationByMin;
                                newobj.InsUser = UserNameProperty;
                                newobj.InsDate = DateTime.Now;
                                newobj.UpdateDate = null;
                                newobj.UpdateUser = null;
                                newobj.DeleteDate = null;
                                newobj.DeleteUser = null;
                                newobj.Rec_Status = obj.Rec_Status;
                                newobj.ShiftGroup_Id = ((ObjGroupDL.ShiftGroup_Id == null || ObjGroupDL.ShiftGroup_Id == "") ? GroupID : obj.ShiftGroup_Id);





                            objPharmaEntities.Hr_Shifts.Add(newobj);
                                objPharmaEntities.SaveChanges();

                            }
                            //Edit
                            else if (obj.Rec_Status == 2)
                            {
                                if (obj.Shift_Id != null && obj.Shift_Id != "")
                                {

                                    Hr_Shifts ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Shifts
                                                              where objLinq.Shift_Id == obj.Shift_Id
                                                              select objLinq).FirstOrDefault();

                                    if (ObjForUpdate != null)
                                    {

                                        ObjForUpdate.Shift_Name = obj.Shift_Name;
                                        ObjForUpdate.Shift_NameEn = obj.Shift_NameEn;
                                        ObjForUpdate.AllowedPeriodToCalcByMin = obj.AllowedPeriodToCalcByMin;
                                        ObjForUpdate.From_Time = obj.From_Time;
                                        ObjForUpdate.To_Time = obj.To_Time;
                                        ObjForUpdate.Shift_DurationByMin = obj.Shift_DurationByMin;
                                        ObjForUpdate.BreakFrom_Time = obj.BreakFrom_Time;
                                        ObjForUpdate.BreakTo_Time = obj.BreakTo_Time;
                                        ObjForUpdate.Break_DurationByMin = obj.Break_DurationByMin;
                                        ObjForUpdate.UpdateUser = UserNameProperty;
                                        ObjForUpdate.UpdateDate = DateTime.Now;
                                        objPharmaEntities.SaveChanges();
                                    }
                                }
                                else
                                {
                                    Hr_Shifts newobj = new Hr_Shifts();
                                    newobj.Company_Id = obj.Company_Id;
                                    newobj.Branch_Id = obj.Branch_Id;
                                    newobj.Shift_Id = GetNewShiftId(obj.Company_Id, obj.Branch_Id);
                                    newobj.Shift_Hdr_Id = HdrId;
                                    newobj.Shift_Name = obj.Shift_Name;
                                    newobj.Shift_NameEn = obj.Shift_NameEn;
                                    newobj.AllowedPeriodToCalcByMin = obj.AllowedPeriodToCalcByMin;
                                    newobj.Shift_NameConv = obj.Shift_NameConv;
                                    newobj.ShortName = obj.ShortName;
                                    newobj.From_Time = obj.From_Time;
                                    newobj.To_Time = obj.To_Time;
                                    newobj.Shift_DurationByMin = obj.Shift_DurationByMin;
                                    newobj.BreakFrom_Time = obj.BreakFrom_Time;
                                    newobj.BreakTo_Time = obj.BreakTo_Time;
                                    newobj.Break_DurationByMin = obj.Break_DurationByMin;
                                    newobj.InsUser = UserNameProperty;
                                    newobj.InsDate = DateTime.Now;
                                    newobj.UpdateDate = null;
                                    newobj.UpdateUser = null;
                                    newobj.DeleteDate = null;
                                    newobj.DeleteUser = null;
                                    newobj.Rec_Status = obj.Rec_Status;
                                    newobj.ShiftGroup_Id = ((ObjGroupDL.ShiftGroup_Id == null || ObjGroupDL.ShiftGroup_Id == "") ? GroupID : obj.ShiftGroup_Id);



                                objPharmaEntities.Hr_Shifts.Add(newobj);
                                    objPharmaEntities.SaveChanges();
                                }

                            }
                            //Delete
                            else if (obj.Rec_Status == 3)
                            {
                                if (obj.Shift_Id != null && obj.Shift_Id != "")
                                {
                                    Hr_Shifts ObjForDelete = (from objLinq in objPharmaEntities.Hr_Shifts
                                                              where objLinq.Shift_Id == obj.Shift_Id
                                                              select objLinq).FirstOrDefault();
                                    if (ObjForDelete != null)
                                    {
                                        ObjForDelete.Rec_Status = obj.Rec_Status;
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


                        return result;

                   // }
                    //else
                    //{

                    //    return false;
                    //}

                }

                else
                {

                    result = false;
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

            return result;


        
    }


        public string GetNewShiftId(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 Shift_Id as Shift_Id  from Hr_Shifts where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(Shift_Id))+Shift_Id desc";
                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
                if (maxId != null)
                {
                    nextId =(Convert.ToInt16(maxId)+1).ToString();

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



    }
}
