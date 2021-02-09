using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HrServices.RequestManagement;
using System.Data.SqlClient;
using BOL.CustodyManagment;

namespace DAL.CustodyManagment
{
    public class EmpCustodyDAL : CommonDB

    {
        public string ObjForUpdateCustody_Desc { get; private set; }

        public List<Hr_Custodies> GetCastodyData(string CastodyType)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<Hr_Custodies> objectList = new List<Hr_Custodies>();


                object[] param1 = {

                new SqlParameter("@CastodyType", CastodyType),


             };


                var objlist = objPharmaEntities.Database.SqlQuery<Hr_Custodies>("exec dbo.sp_GetCastodyData @CastodyType", param1).ToList();

                foreach (var obj in objlist)
                {
                    Hr_Custodies CustodiesdDL = new Hr_Custodies();
                    CustodiesdDL.Custody_Id = obj.Custody_Id;
                    CustodiesdDL.Custody_Name = obj.Custody_Name;
                    CustodiesdDL.Custody_NameEn = obj.Custody_NameEn;
                    CustodiesdDL.Custody_NameConv = obj.Custody_NameConv;
                    CustodiesdDL.InsUser = obj.InsUser;
                    CustodiesdDL.InsDate = obj.InsDate;
                    CustodiesdDL.UpdateUser = obj.UpdateUser;
                    CustodiesdDL.DeleteUser = obj.DeleteUser;
                    CustodiesdDL.DeleteDate = obj.DeleteDate;
                    CustodiesdDL.Rec_Status = obj.Rec_Status;

                    objectList.Add(CustodiesdDL);

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


        public bool SaveCastodyData(List<Hr_Custodies> objList)
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
                        if (obj.Rec_Status == 0)
                        {

                        }
                        //Add
                        else if (obj.Rec_Status == 1)
                        {

                            Hr_Custodies newobj = new Hr_Custodies();
                            newobj.Custody_Id = GetNewId();
                            newobj.Custody_Name = obj.Custody_Name;
                            newobj.Custody_NameEn = obj.Custody_NameEn;
                            newobj.Custody_NameConv = obj.Custody_NameConv;
                            newobj.InsUser = UserNameProperty;
                            newobj.InsDate = DateTime.Now;
                            newobj.UpdateUser = null;
                            newobj.UpdateDate = null;
                            newobj.DeleteUser = null;
                            newobj.DeleteDate = null;



                            objPharmaEntities.Hr_Custodies.Add(newobj);
                            Result = objPharmaEntities.SaveChanges();

                        }
                        //Edit
                        else if (obj.Rec_Status == 2)
                        {
                            if (obj.Custody_Id != null && obj.Custody_Id != "")
                            {

                                Hr_Custodies ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Custodies
                                                             where objLinq.Custody_Id == obj.Custody_Id
                                                             select objLinq).FirstOrDefault();

                                if (ObjForUpdate != null)
                                {

                                    ObjForUpdate.Custody_Name = obj.Custody_Name;
                                    ObjForUpdate.Custody_NameEn = obj.Custody_NameEn;
                                    ObjForUpdate.UpdateUser = UserNameProperty;
                                    ObjForUpdate.UpdateDate = DateTime.Now;




                                    Result = objPharmaEntities.SaveChanges();
                                }
                            }
                            else
                            {
                                Hr_Custodies newobj = new Hr_Custodies();
                                newobj.Custody_Id = GetNewId();
                                newobj.Custody_Name = obj.Custody_Name;
                                newobj.Custody_NameEn = obj.Custody_NameEn;
                                newobj.Custody_NameConv = obj.Custody_NameConv;
                                newobj.InsUser = UserNameProperty;
                                newobj.InsDate = DateTime.Now;
                                newobj.UpdateUser = null;
                                newobj.UpdateDate = null;
                                newobj.DeleteUser = null;
                                newobj.DeleteDate = null;



                                objPharmaEntities.Hr_Custodies.Add(newobj);
                                Result = objPharmaEntities.SaveChanges();
                            }

                        }
                        //Delete
                        else if (obj.Rec_Status == 3)
                        {
                            if (obj.Custody_Id != null && obj.Custody_Id != "")
                            {
                                Hr_Custodies ObjForDelete = (from objLinq in objPharmaEntities.Hr_Custodies
                                                             where objLinq.Custody_Id == obj.Custody_Id
                                                             select objLinq).FirstOrDefault();
                                if (ObjForDelete != null)
                                {
                                    ObjForDelete.Rec_Status = 3;
                                    ObjForDelete.DeleteUser = UserNameProperty;
                                    ObjForDelete.DeleteDate = DateTime.Now;
                                    //  objPharmaEntities.Hr_Custodies.Remove(ObjForDelete);
                                    Result = objPharmaEntities.SaveChanges();
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

        public string GetNewId()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 Custody_Id as Custody_Id  from Hr_Custodies order by replicate('0',15-len(Custody_Id))+Custody_Id desc";

                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
                if (maxId != null)
                {
                    maxId = (Convert.ToInt32(maxId)) + 1;
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



        public string GetNewRec_Id()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 Rec_Id as Rec_Id  from Hr_EmpCustodies order by replicate('0',15-len(Rec_Id))+Rec_Id desc";

                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
                if (maxId != null)
                {
                    maxId = (Convert.ToInt32(maxId)) + 1;
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

        public List<EmpCastodyDL> GetEmpCastodyData(decimal Emp_Serial_No, string Custody_Serial_No, string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EmpCastodyDL> objectList = new List<EmpCastodyDL>();


                object[] param1 = {

                new SqlParameter("@Emp_Serial_No", Emp_Serial_No),
                new SqlParameter("@Custody_Serial_No", Custody_Serial_No),
                new SqlParameter("@Company_Id", Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id)


             };


                var objlist = objPharmaEntities.Database.SqlQuery<EmpCastodyDL>("exec dbo.sp_GetEmpCastodyData @Emp_Serial_No ,@Custody_Serial_No, @Company_Id , @Branch_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    EmpCastodyDL EmpCastodyDL = new EmpCastodyDL();


                    EmpCastodyDL.Hdr_Id = obj.Hdr_Id;
                    EmpCastodyDL.Rec_Id = obj.Rec_Id;
                    EmpCastodyDL.Rec_No = obj.Rec_No;
                    EmpCastodyDL.Company_Id = obj.Company_Id;
                    EmpCastodyDL.Branch_Id = obj.Branch_Id;
                    EmpCastodyDL.Emp_Serial_No = obj.Emp_Serial_No;
                    EmpCastodyDL.FullNameArabic = obj.FullNameArabic;
                    EmpCastodyDL.FullNameEn = obj.FullNameEn;
                    EmpCastodyDL.Custody_Id = obj.Custody_Id;
                    EmpCastodyDL.Transdate = obj.Transdate;
                    EmpCastodyDL.Custody_Name = obj.Custody_Name;
                    EmpCastodyDL.Custody_NameEn = obj.Custody_NameEn;
                    EmpCastodyDL.Custody_Serial_No = obj.Custody_Serial_No;
                    EmpCastodyDL.Custody_Status = obj.Custody_Status;
                    EmpCastodyDL.Custody_Desc = obj.Custody_Desc;
                    EmpCastodyDL.Custody_Note = obj.Custody_Note;
                    EmpCastodyDL.Received_Date = obj.Received_Date;
                    EmpCastodyDL.Delivery_Date = obj.Delivery_Date;
                    EmpCastodyDL.InsUser = obj.InsUser;
                    EmpCastodyDL.InsDate = obj.InsDate;

                    objectList.Add(EmpCastodyDL);

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


        public bool SaveEmpCastodyData(EmpCastodyDL ObjEmpCastodyDL)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            var strErrorMessage = string.Empty;

            bool result = true;
            try
            {

                OpenEntityConnection();

                //    result = AddShiftGroup(ObjGroupD);

                if (ObjEmpCastodyDL != null)
                {

                    if (ObjEmpCastodyDL.Hdr_Id == Guid.Empty || ObjEmpCastodyDL.Hdr_Id == null)
                    {
                        if (ObjEmpCastodyDL.IsEdit == 0)
                        {


                            Hr_EmpCustodies EmpCustodies = new Hr_EmpCustodies
                            {
                                Hdr_Id = GetNewHeaderId(),
                                Rec_Id = GetNewRec_Id(),
                                Company_Id = ObjEmpCastodyDL.Company_Id,
                                Branch_Id = ObjEmpCastodyDL.Branch_Id,
                                Emp_Serial_No = ObjEmpCastodyDL.Emp_Serial_No,
                                Transdate = ObjEmpCastodyDL.Transdate,
                                Custody_Id = ObjEmpCastodyDL.Custody_Id,
                                Custody_Serial_No = ObjEmpCastodyDL.Custody_Serial_No,
                                Custody_Status = ObjEmpCastodyDL.Custody_Status,
                                Custody_Desc = ObjEmpCastodyDL.Custody_Desc,
                                Custody_Note = ObjEmpCastodyDL.Custody_Note,
                                Received_Date = ObjEmpCastodyDL.Received_Date,
                                // Delivery_Date = ObjEmpCastodyDL.Delivery_Date,
                                Ins_User = UserNameProperty,
                                Ins_Date = DateTime.Now
                            };


                            objPharmaEntities.Hr_EmpCustodies.Add(EmpCustodies);
                            objPharmaEntities.SaveChanges();
                            return result;

                        }
                    }

                    //return result;


                    else
                    {
                        if (ObjEmpCastodyDL.IsEdit == 1)
                        {
                            Hr_EmpCustodies ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpCustodies
                                                            where objLinq.Hdr_Id == ObjEmpCastodyDL.Hdr_Id
                                                            select objLinq).FirstOrDefault();

                            if (ObjForUpdate != null)
                            {
                                ObjForUpdate.Emp_Serial_No = ObjEmpCastodyDL.Emp_Serial_No;
                                ObjForUpdate.Custody_Id = ObjEmpCastodyDL.Custody_Id;
                                ObjForUpdate.Transdate = ObjEmpCastodyDL.Transdate;
                                ObjForUpdate.Received_Date = ObjEmpCastodyDL.Received_Date;
                                ObjForUpdate.Custody_Serial_No = ObjEmpCastodyDL.Custody_Serial_No;
                                ObjForUpdate.Custody_Status = ObjEmpCastodyDL.Custody_Status;
                                ObjForUpdate.Custody_Desc = ObjEmpCastodyDL.Custody_Desc;
                                ObjForUpdate.Custody_Note = ObjEmpCastodyDL.Custody_Note;


                                objPharmaEntities.SaveChanges();
                                return result;
                            }
                        }
                    }



                }

                else
                { result = false; }
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


        public bool SaveTransferData(EmpCastodyDL ObjTransferCastodyDL)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();
            var strErrorMessage = string.Empty;

            bool result = true;
            try
            {

                OpenEntityConnection();


                if (ObjTransferCastodyDL != null)
                {

                    if (ObjTransferCastodyDL.Hdr_Id != Guid.Empty && ObjTransferCastodyDL.Hdr_Id != null)
                    {

                        //Hr_EmpCustodies_History EmpCustodies = new Hr_EmpCustodies_History
                        //{
                        //    Hdr_Id = ObjTransferCastodyDL.Hdr_Id,
                        //    //Rec_Id = GetNewRec_Id(),
                        //    Company_Id = ObjTransferCastodyDL.Company_Id,
                        //    Branch_Id = ObjTransferCastodyDL.Branch_Id,
                        //    Emp_Serial_No = ObjTransferCastodyDL.Emp_Serial_No,
                        //    Emp_Serial_No_New = ObjTransferCastodyDL.Emp_Serial_No_New,
                        //    Transdate = ObjTransferCastodyDL.Transdate,
                        //    Custody_Id = ObjTransferCastodyDL.Custody_Id,
                        //    Custody_Serial_No = ObjTransferCastodyDL.Custody_Serial_No,
                        //    Custody_Status = ObjTransferCastodyDL.Custody_Status,
                        //    Custody_Status_New = ObjTransferCastodyDL.Custody_Status_New,
                        //    Custody_Desc = ObjTransferCastodyDL.Custody_Desc,
                        //    Custody_Note = ObjTransferCastodyDL.Custody_Note,
                        //    Received_Date = ObjTransferCastodyDL.Received_Date,
                        //    // Delivery_Date = ObjEmpCastodyDL.Delivery_Date,
                        //    Ins_User = UserNameProperty,
                        //    Ins_Date = DateTime.Now
                        //};


                        //objPharmaEntities.Hr_EmpCustodies_History.Add(EmpCustodies);
                        //objPharmaEntities.SaveChanges();
                        //return result;

                        Hr_EmpCustodies ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpCustodies
                                                        where objLinq.Hdr_Id == ObjTransferCastodyDL.Hdr_Id
                                                        select objLinq).FirstOrDefault();

                        if (ObjForUpdate != null)
                        {
                            ObjForUpdate.Emp_Serial_No = ObjTransferCastodyDL.Emp_Serial_No;
                            ObjForUpdate.Transdate = ObjTransferCastodyDL.Transdate;
                            ObjForUpdate.Received_Date = ObjTransferCastodyDL.Received_Date;
                            ObjForUpdate.Custody_Status = ObjTransferCastodyDL.Custody_Status;
                            ObjForUpdate.Custody_Desc = ObjTransferCastodyDL.Custody_Desc;
                            ObjForUpdate.Custody_Note = ObjTransferCastodyDL.Custody_Note;


                            objPharmaEntities.SaveChanges();
                            return result;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }


                }
                else
                { return false; }


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


        public bool DeleteCastody(Guid RowId)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                int Result = 0;
                if (RowId != null && RowId != Guid.Empty)
                {
                    Hr_EmpCustodies ObjForDelete = (from objLinq in objPharmaEntities.Hr_EmpCustodies
                                                    where objLinq.Hdr_Id == RowId
                                                    select objLinq).FirstOrDefault();
                    if (ObjForDelete != null)
                    {
                        objPharmaEntities.Hr_EmpCustodies.Remove(ObjForDelete);
                        objPharmaEntities.SaveChanges();
                        return (Result > 0);

                    }

                    else
                    {
                        return (Result < 0);
                    }
                }
                else { return (Result < 0); }
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
