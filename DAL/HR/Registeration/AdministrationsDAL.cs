using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Objects;
using System.Diagnostics;
using System.Reflection;


namespace DAL.HR.Registeration
{
    public class AdministrationsDAL : CommonDB

    {
        public  async Task<int> Insert(Hr_Administrations objInsert) 
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


                    objPharmaEntities.Hr_Administrations.Add(objInsert);
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
        public int InsertTask(Hr_Administrations objInsert)
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


                    objPharmaEntities.Hr_Administrations.Add(objInsert);
                    RowEffected =  objPharmaEntities.SaveChanges();
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

      

        public List<Hr_Administrations> SelectAllByCompanyAndBranch(string strcomapny, string strbranch) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<Hr_Administrations> objlist = new List<Hr_Administrations>();
            try
            {
                OpenEntityConnection();
                string sql ="select [Company_Id],[Branch_Id],[Admin_Code]";
                sql = sql + ",[Admin_Id],[Admin_Name],[Admin_NameEn],[Admin_NameConv],[Admin_AccountNo],[InsUser],[InsDate]";
                sql = sql + ",[UpdateUser],UpdateDate,DeleteUser,DeleteDate,Rec_Status,Prefix,Id,IsParent,HasParent,ParentAdmin_Id";
               
                sql = sql + " from Hr_Administrations where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";
                sql = sql + " Order by Id ";

              //  List<Hr_Administrations> objectList = (from objLinq in objPharmaEntities.Hr_Administrations
                                //                       where objLinq.Rec_Status == 0 && objLinq.Branch_Id == strbranch && objLinq.Company_Id == strcomapny
                                //              select objLinq).ToList();



                List<Hr_Administrations> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Administrations>(sql).ToList();

                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        Hr_Administrations obj1 = new Hr_Administrations();
                        obj1.Company_Id = obj.Company_Id;
                        obj1.Branch_Id = obj.Branch_Id;
                        obj1.Admin_Code = obj.Admin_Code;
                        obj1.Admin_Id = obj.Admin_Id;
                        obj1.Admin_Name = obj.Admin_Name;
                        obj1.Admin_NameEn = obj.Admin_NameEn;
                        obj1.Admin_NameConv = obj.Admin_NameConv;
                        obj1.Admin_AccountNo = obj.Admin_AccountNo;
                        obj1.InsUser = obj.InsUser;
                        obj1.InsDate = obj.InsDate;
                        obj1.UpdateUser = obj.UpdateUser;
                        obj1.UpdateDate = obj.UpdateDate;
                        obj1.DeleteUser = obj.DeleteUser;
                        obj1.DeleteDate = obj.DeleteDate;
                        obj1.Rec_Status = obj.Rec_Status;
                        obj1.Prefix = obj.Prefix;
                        obj1.IsParent=obj.IsParent;
                        obj1.HasParent=obj.HasParent;
                        obj1.ParentAdmin_Id = obj.ParentAdmin_Id;
                        objlist.Add(obj1);

                    }

                }


                //var str = (from objlinq in objPharmaEntities.Hr_Administrations
                //           where objlinq.Rec_Status == 0
                //           && objlinq.Company_Id == strcomapny && objlinq.Branch_Id == strbranch
                //           select objlinq);
                //string sql = ((ObjectQuery)str).ToTraceString();

                return objlist;

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

        

      

        //public IEnumerable<Hr_Administrations> SearchDataIsExistNew(string strcomapny, string strbranch, string strEmpSerialNo, string strEmpSearchName) 
        //{
        //    var varstrEmpSerialNo = Convert.ToDecimal(strEmpSerialNo);
        //    var varstrEmpSearchName = Convert.ToDecimal(strEmpSearchName);

        //    var objAdministrations = from o in objPharmaEntities.Hr_Administrations
        //                 select new Administrations
        //                 {
        //                     emp = temp,
        //                     CourseName = o.CourseName,
        //                 };
        //    return objAdministrations.ToList();
        //}

        public async Task<bool> Update(Hr_Administrations objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Administrations ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Administrations
                                            where objLinq.Admin_Id == objUpdate.Admin_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                            select objLinq).FirstOrDefault();



                    ObjForUpdate.Admin_Name = objUpdate.Admin_Name;
                    ObjForUpdate.Admin_NameEn = objUpdate.Admin_NameEn;
                    ObjForUpdate.Admin_NameConv = objUpdate.Admin_NameConv;
                    ObjForUpdate.Admin_AccountNo = objUpdate.Admin_AccountNo;


                    

                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;
                    

                    rowEffected = await objPharmaEntities.SaveChangesAsync() ;
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
        public bool UpdateTask(Hr_Administrations objUpdate)
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
                    Hr_Administrations ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Administrations
                                                 where objLinq.Admin_Id == objUpdate.Admin_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                 select objLinq).FirstOrDefault();


                    if (ObjForUpdate != null) 
                    { 
                    ObjForUpdate.Admin_Name = objUpdate.Admin_Name;
                    ObjForUpdate.Admin_NameEn = objUpdate.Admin_NameEn;
                    ObjForUpdate.Admin_Code = objUpdate.Admin_Code;
                    ObjForUpdate.Admin_NameConv = objUpdate.Admin_NameConv;
                    ObjForUpdate.Admin_AccountNo = objUpdate.Admin_AccountNo;
                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;

                    ObjForUpdate.IsParent = objUpdate.IsParent;
                    ObjForUpdate.HasParent = objUpdate.HasParent;
                    ObjForUpdate.ParentAdmin_Id = objUpdate.ParentAdmin_Id;

                    rowEffected =  objPharmaEntities.SaveChanges();
                    }
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

        public async Task<bool> Delete(Hr_Administrations objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Administrations objForDelete = (from objLinq in objPharmaEntities.Hr_Administrations
                                                 where objLinq.Admin_Id == objDelete.Admin_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public bool DeleteTask(Hr_Administrations objDelete)
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
                    Hr_Administrations objForDelete = (from objLinq in objPharmaEntities.Hr_Administrations
                                                       where objLinq.Admin_Id == objDelete.Admin_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
                                            select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected =  objPharmaEntities.SaveChanges();
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

        public Hr_Administrations GetById(string strAdmin_Id, string strCompanyId, string strBranchId )
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                Hr_Administrations AdminsForGetEntity = (from objLinq in objPharmaEntities.Hr_Administrations
                                                 where objLinq.Admin_Id == strAdmin_Id && objLinq.Company_Id == strCompanyId && objLinq.Branch_Id == strBranchId && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return AdminsForGetEntity;
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
        public List<Hr_Administrations> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            List<Hr_Administrations> objlist = new List<Hr_Administrations>();

            try
            {
                OpenEntityConnection();

                string sql = "select *  from Hr_Administrations  order by replicate('0',15-len(Admin_Id))+Admin_Id ";

                List<Hr_Administrations> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Administrations>(sql).ToList();



                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        Hr_Administrations obj1 = new Hr_Administrations();
                        obj1.Admin_Id = obj.Admin_Id;
                        obj1.Admin_Name = obj.Admin_Name;
                        obj1.Admin_NameEn = obj.Admin_NameEn;
                        obj1.Admin_NameConv = obj.Admin_NameConv;
                        obj1.Company_Id = obj.Company_Id;
                        obj1.Branch_Id = obj.Branch_Id;
                        obj1.IsParent = obj.IsParent;
                        obj1.HasParent = obj.HasParent;
                        obj1.ParentAdmin_Id = obj.ParentAdmin_Id;

                        objlist.Add(obj1);

                    }

                }

                //List<Hr_Administrations> objectList = (from objLinq in objPharmaEntities.Hr_Administrations
                //                                 where objLinq.Rec_Status == 0
                //                                 && objLinq.Company_Id == objLinq.Company_Id && objLinq.Branch_Id == objLinq.Branch_Id
                //                         select objLinq).ToList();
                return objlist;

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

        public string GetNewId(string strcomapny , string strbranch)
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
                strsql = "select top 1 Admin_Id as Admin_Id  from Hr_Administrations where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(Admin_Id))+Admin_Id desc";
                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
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
