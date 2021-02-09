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
    public class CustodyTypesDAL : CommonDB

    {
        //public string ObjForUpdateCustody_Desc { get; private set; }


        public async Task<int> Insert(Hr_Countries objInsert)
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


                    objPharmaEntities.Hr_Countries.Add(objInsert);
                    RowEffected = await objPharmaEntities.SaveChangesAsync();
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
        // Calling the method of using Async
        //public  int test() {
        //    int task =  Insert().Result;
        //    return task;

        //}
        public int InsertTask(Hr_Custodies objInsert)
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
                    objInsert.InsDate = DateTime.Now;//DateTime.Today;
                    objInsert.InsUser = UserNameProperty;


                    objPharmaEntities.Hr_Custodies.Add(objInsert);
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

        public async Task<bool> Update(Hr_Custodies objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Custodies ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Custodies
                                                 where objLinq.Custody_Id == objUpdate.Custody_Id
                                                 select objLinq).FirstOrDefault();
                    //ObjForUpdate.Country_Name = objUpdate.Country_Name;
                    //ObjForUpdate.Country_NameEn = objUpdate.Country_NameEn;
                    //ObjForUpdate.Country_Code = objUpdate.Country_Code;
                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;


                    rowEffected = await objPharmaEntities.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }
        public bool UpdateTask(Hr_Custodies objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            // bool task = Update(objInsert).Result;
            //return task;
            int rowEffected = 0;
            try
            {

                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Custodies ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Custodies
                                                 where objLinq.Custody_Id == objUpdate.Custody_Id
                                                 select objLinq).FirstOrDefault();

                    ObjForUpdate.Custody_Name = objUpdate.Custody_Name;
                    ObjForUpdate.Custody_NameEn = objUpdate.Custody_NameEn;

                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;

                    rowEffected = objPharmaEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;


        }

        public async Task<bool> Delete(Hr_Custodies objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Countries objForDelete = (from objLinq in objPharmaEntities.Hr_Countries
                                                 where objLinq.Country_Id == objDelete.Custody_Id
                                                 select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected = await objPharmaEntities.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public bool DeleteTask(Hr_Custodies objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            // bool task = Delete(objInsert).Result;
            // return task;
            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Custodies objForDelete = (from objLinq in objPharmaEntities.Hr_Custodies
                                                 where objLinq.Custody_Id == objDelete.Custody_Id
                                                 select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected = objPharmaEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public Hr_Custodies GetById(string Custody_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_Custodies CountriesForGetEntity = (from objLinq in objPharmaEntities.Hr_Custodies
                                                      where objLinq.Custody_Id == Custody_Id && objLinq.Rec_Status == 0
                                                      select objLinq).FirstOrDefault();
                return CountriesForGetEntity;
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
        public List<Hr_Custodies> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<Hr_Custodies> objectList = (from objLinq in objPharmaEntities.Hr_Custodies
                                                 where objLinq.Rec_Status == 0
                                                 orderby objLinq.Id
                                                 select objLinq).ToList();
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

        public string GetNewId()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Countries_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Countries_SelectMaxId()
                //         select anything.Country_Id).Single();
                //foreach (Hr_Countries cs in objPharmaEntities.Hr_Countries)
                //    maxId = cs.Country_Id;

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 Custody_Id  as Custody_Id  from Hr_Custodies  order by replicate('0',15-len(Custody_Id))+Custody_Id desc").FirstOrDefault<string>();

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

    }
}
