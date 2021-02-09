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
    public class GradeJobGroupsDAL : CommonDB

    {
        public  async Task<int> Insert(Hr_GradeJobGroups objInsert) 
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


                    objPharmaEntities.Hr_GradeJobGroups.Add(objInsert);
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
        public int InsertTask(Hr_GradeJobGroups objInsert)
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


                    objPharmaEntities.Hr_GradeJobGroups.Add(objInsert);
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



        public List<Hr_GradeJobGroups> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                List<Hr_GradeJobGroups> objlist = new List<Hr_GradeJobGroups>();

                string sql = "select [Company_Id],[Branch_Id],[GradeJob_Code]";
                sql = sql + ",[GradeJob_Id],[GradeJob_Name],[GradeJob_NameEn],[GradeJob_NameConv],[GradeJob_AccountNo],[InsUser],[InsDate]";
                sql = sql + ",[UpdateUser],UpdateDate,DeleteUser,DeleteDate,Rec_Status,Prefix";

                sql = sql + " from Hr_GradeJobGroups where Rec_Status = 0 and Company_Id='" + strcomapny + "' and Branch_Id='" + strbranch + "'";
                sql = sql + " Order by Id";

              


                List<Hr_GradeJobGroups> objectlist = objPharmaEntities.Database.SqlQuery<Hr_GradeJobGroups>(sql).ToList();

                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        Hr_GradeJobGroups objHr_GradeJobGroups = new Hr_GradeJobGroups();
                        objHr_GradeJobGroups.Company_Id = obj.Company_Id;
                        objHr_GradeJobGroups.Branch_Id = obj.Branch_Id;
                        objHr_GradeJobGroups.GradeJob_Code = obj.GradeJob_Code;
                        objHr_GradeJobGroups.GradeJob_Id = obj.GradeJob_Id;
                        objHr_GradeJobGroups.GradeJob_Name = obj.GradeJob_Name;
                        objHr_GradeJobGroups.GradeJob_NameEn = obj.GradeJob_NameEn;
                        objHr_GradeJobGroups.GradeJob_AccountNo = obj.GradeJob_AccountNo;
                        objHr_GradeJobGroups.Prefix = obj.Prefix;
                        
                        

                        objlist.Add(objHr_GradeJobGroups);

                    }

                }


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



        public List<Hr_GradeJobGroups> SelectAll()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                List<Hr_GradeJobGroups> objlist = new List<Hr_GradeJobGroups>();

                OpenEntityConnection();
                string sql = "select [Company_Id],[Branch_Id],[GradeJob_Code]";
                sql = sql + ",[GradeJob_Id],[GradeJob_Name],[GradeJob_NameEn],[GradeJob_NameConv],[GradeJob_AccountNo],[InsUser],[InsDate]";
                sql = sql + ",[UpdateUser],UpdateDate,DeleteUser,DeleteDate,Rec_Status,Prefix,Id";

                sql = sql + " from Hr_GradeJobGroups where Rec_Status = 0 ";
                sql = sql + " Order by Id";
                //  List<Hr_GradeJobGroups> objectList = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                //                       where objLinq.Rec_Status == 0 && objLinq.Branch_Id == strbranch && objLinq.Company_Id == strcomapny
                //              select objLinq).ToList();



                List<Hr_GradeJobGroups> objectlist = objPharmaEntities.Database.SqlQuery<Hr_GradeJobGroups>(sql).ToList();

                if (objectlist != null)
                {
                    foreach (var obj in objectlist)
                    {
                        Hr_GradeJobGroups objHr_GradeJobGroups = new Hr_GradeJobGroups();
                        objHr_GradeJobGroups.Company_Id = obj.Company_Id;
                        objHr_GradeJobGroups.Branch_Id = obj.Branch_Id;
                        objHr_GradeJobGroups.GradeJob_Code = obj.GradeJob_Code;
                        objHr_GradeJobGroups.GradeJob_Id = obj.GradeJob_Id;
                        objHr_GradeJobGroups.GradeJob_Name = obj.GradeJob_Name;
                        objHr_GradeJobGroups.GradeJob_NameEn = obj.GradeJob_NameEn;
                        objHr_GradeJobGroups.GradeJob_AccountNo = obj.GradeJob_AccountNo;
                        objHr_GradeJobGroups.Prefix = obj.Prefix;



                        objlist.Add(objHr_GradeJobGroups);

                    }

                }

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


      

        //public IEnumerable<Hr_GradeJobGroups> SearchDataIsExistNew(string strcomapny, string strbranch, string strEmpSerialNo, string strEmpSearchName) 
        //{
        //    var varstrEmpSerialNo = Convert.ToDecimal(strEmpSerialNo);
        //    var varstrEmpSearchName = Convert.ToDecimal(strEmpSearchName);

        //    var objGradeJobGroups = from o in objPharmaEntities.Hr_GradeJobGroups
        //                 select newGradeJobGroups
        //                 {
        //                     emp = temp,
        //                     CourseName = o.CourseName,
        //                 };
        //    return objGradeJobGroups.ToList();
        //}

        public async Task<bool> Update(Hr_GradeJobGroups objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_GradeJobGroups ObjForUpdate = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                                            where objLinq.GradeJob_Id == objUpdate.GradeJob_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                            select objLinq).FirstOrDefault();


                    if (ObjForUpdate != null) 
                    {
                        ObjForUpdate.GradeJob_Name = objUpdate.GradeJob_Name;
                        ObjForUpdate.GradeJob_NameEn = objUpdate.GradeJob_NameEn;
                        ObjForUpdate.GradeJob_NameConv = objUpdate.GradeJob_NameConv;
                        ObjForUpdate.GradeJob_AccountNo = objUpdate.GradeJob_AccountNo;
                        ObjForUpdate.GradeJob_Code = objUpdate.GradeJob_Code;



                        ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                        ObjForUpdate.UpdateDate = DateTime.Now;
                        rowEffected = await objPharmaEntities.SaveChangesAsync();
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
        public bool UpdateTask(Hr_GradeJobGroups objUpdate)
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
                    Hr_GradeJobGroups ObjForUpdate = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                                                 where objLinq.GradeJob_Id == objUpdate.GradeJob_Id && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                 select objLinq).FirstOrDefault();


                    if (ObjForUpdate != null)
                    {
                        ObjForUpdate.GradeJob_Name = objUpdate.GradeJob_Name;
                        ObjForUpdate.GradeJob_NameEn = objUpdate.GradeJob_NameEn;
                        ObjForUpdate.GradeJob_NameConv = objUpdate.GradeJob_NameConv;
                        ObjForUpdate.GradeJob_AccountNo = objUpdate.GradeJob_AccountNo;
                        ObjForUpdate.GradeJob_Code = objUpdate.GradeJob_Code;

                        ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                        ObjForUpdate.UpdateDate = DateTime.Now;

                        rowEffected = objPharmaEntities.SaveChanges();
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

        public bool UpdateTaskWithOutBranch(Hr_GradeJobGroups objUpdate)
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
                    Hr_GradeJobGroups ObjForUpdate = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                                                      where objLinq.GradeJob_Id == objUpdate.GradeJob_Id 
                                                      //&& objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                      select objLinq).FirstOrDefault();



                    if (ObjForUpdate != null)
                    {
                        ObjForUpdate.GradeJob_Name = objUpdate.GradeJob_Name;
                        ObjForUpdate.GradeJob_NameEn = objUpdate.GradeJob_NameEn;
                        ObjForUpdate.GradeJob_NameConv = objUpdate.GradeJob_NameConv;
                        ObjForUpdate.GradeJob_AccountNo = objUpdate.GradeJob_AccountNo;
                        ObjForUpdate.GradeJob_Code = objUpdate.GradeJob_Code;

                        ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                        ObjForUpdate.UpdateDate = DateTime.Now;

                        rowEffected = objPharmaEntities.SaveChanges();
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

        public async Task<bool> Delete(Hr_GradeJobGroups objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_GradeJobGroups objForDelete = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                                                 where objLinq.GradeJob_Id == objDelete.GradeJob_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public bool DeleteTask(Hr_GradeJobGroups objDelete)
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
                    Hr_GradeJobGroups objForDelete = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                                                       where objLinq.GradeJob_Id == objDelete.GradeJob_Id && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public bool DeleteTaskWithOutBranch(Hr_GradeJobGroups objDelete)
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
                    Hr_GradeJobGroups objForDelete = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                                                      where objLinq.GradeJob_Id == objDelete.GradeJob_Id
                                                      //&& objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
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

        public Hr_GradeJobGroups GetById(string strGradeJob_Id, string strCompanyId, string strBranchId )
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                Hr_GradeJobGroups AdminsForGetEntity = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                                                 where objLinq.GradeJob_Id == strGradeJob_Id && objLinq.Company_Id == strCompanyId && objLinq.Branch_Id == strBranchId && objLinq.Rec_Status == 0
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
        public Hr_GradeJobGroups GetByIdWithOutBranch(string strGradeJob_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                Hr_GradeJobGroups AdminsForGetEntity = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                                                        where objLinq.GradeJob_Id == strGradeJob_Id && objLinq.Rec_Status == 0
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

        public List<Hr_GradeJobGroups> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_GradeJobGroups> objectList = (from objLinq in objPharmaEntities.Hr_GradeJobGroups
                                                 where objLinq.Rec_Status == 0
                                                 && objLinq.Company_Id == objLinq.Company_Id && objLinq.Branch_Id == objLinq.Branch_Id
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

        public string GetNewId(string strcomapny , string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
             object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_GradeJobGroups_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_GradeJobGroups_SelectMaxId()
                //         select anything.GradeJob_Id).Single();
                //foreach (Hr_GradeJobGroups cs in objPharmaEntities.Hr_GradeJobGroups)
                //    maxId = cs.GradeJob_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 GradeJob_Id as GradeJob_Id  from Hr_GradeJobGroups where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(GradeJob_Id))+GradeJob_Id desc";
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


        public string GetNewIdWithOutBranch()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_GradeJobGroups_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_GradeJobGroups_SelectMaxId()
                //         select anything.GradeJob_Id).Single();
                //foreach (Hr_GradeJobGroups cs in objPharmaEntities.Hr_GradeJobGroups)
                //    maxId = cs.GradeJob_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 GradeJob_Id as GradeJob_Id  from Hr_GradeJobGroups order by replicate('0',15-len(GradeJob_Id))+GradeJob_Id desc";
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
