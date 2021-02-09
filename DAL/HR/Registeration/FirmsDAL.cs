using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HR.Registeration;
namespace DAL.HR.Registeration
{
  public  class FirmsDAL:CommonDB

    {
        public  async Task<int> Insert(Hr_Firms objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_Firms.Add(objInsert);
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
        public int InsertTask(Hr_Firms objInsert)
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


                    objPharmaEntities.Hr_Firms.Add(objInsert);
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

        public async Task<bool> Update(Hr_Firms objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Firms ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Firms
                                            where objLinq.Firm_Id == objUpdate.Firm_Id
                                            select objLinq).FirstOrDefault();
                    if (ObjForUpdate != null) { 
                    ObjForUpdate.Firm_Name = objUpdate.Firm_Name;
                    ObjForUpdate.Firm_NameEn = objUpdate.Firm_NameEn;
                    ObjForUpdate.Firm_Code = objUpdate.Firm_Code;
                    ObjForUpdate.Firm_AccountNo = objUpdate.Firm_AccountNo;
                    ObjForUpdate.Prefix = objUpdate.Prefix;
                    ObjForUpdate.Field_AR = objUpdate.Field_AR;
                    ObjForUpdate.Field_En = objUpdate.Field_En;
                    ObjForUpdate.Logo_Path = objUpdate.Logo_Path;
                    ObjForUpdate.Small_Logo_Path = objUpdate.Small_Logo_Path;
                    ObjForUpdate.ResponsibleEmpId = objUpdate.ResponsibleEmpId;

                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;
                    

                    rowEffected = await objPharmaEntities.SaveChangesAsync() ;
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
        public bool UpdateTask(Hr_Firms objUpdate)
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
                    Hr_Firms ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Firms
                                            where objLinq.Firm_Id == objUpdate.Firm_Id
                                            select objLinq).FirstOrDefault();
                    if (ObjForUpdate != null)
                    {
                        ObjForUpdate.Firm_Name = objUpdate.Firm_Name;
                        ObjForUpdate.Firm_NameEn = objUpdate.Firm_NameEn;
                        ObjForUpdate.Firm_Code = objUpdate.Firm_Code;
                        ObjForUpdate.Firm_AccountNo = objUpdate.Firm_AccountNo;
                        ObjForUpdate.Prefix = objUpdate.Prefix;
                        ObjForUpdate.Field_AR = objUpdate.Field_AR;
                        ObjForUpdate.Field_En = objUpdate.Field_En;
                        ObjForUpdate.Logo_Path = objUpdate.Logo_Path;
                        ObjForUpdate.Small_Logo_Path = objUpdate.Small_Logo_Path;
                        ObjForUpdate.ResponsibleEmpId = objUpdate.ResponsibleEmpId;
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

        public async Task<bool> Delete(Hr_Firms objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Firms objForDelete = (from objLinq in objPharmaEntities.Hr_Firms
                                            where objLinq.Firm_Id == objDelete.Firm_Id
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

        public bool DeleteTask(Hr_Firms objDelete)
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
                    Hr_Firms objForDelete = (from objLinq in objPharmaEntities.Hr_Firms
                                            where objLinq.Firm_Id == objDelete.Firm_Id
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

        public Hr_Firms GetById(string Firm_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_Firms CompaniesForGetEntity = (from objLinq in objPharmaEntities.Hr_Firms
                                            where objLinq.Firm_Id == Firm_ID && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return CompaniesForGetEntity;
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
        public List<Hr_Firms> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                
                string sql ="select  Firm_Id, Firm_Code, Firm_Name, Firm_NameEn, Firm_NameConv, Firm_AccountNo, InsUser, InsDate, UpdateUser," ;
                sql = sql + " UpdateDate, DeleteUser, DeleteDate, Rec_Status, Prefix, Field_AR, Field_En, Logo_Path,ResponsibleEmpId,Id,Small_Logo_Path, IsGroup , GroupId";
                sql = sql + " From  dbo.Hr_Firms  where Rec_Status = 0 ";
                    sql = sql + " Order by Id ";

               // List<Hr_Firms> objectList = (from objLinq in objPharmaEntities.Hr_Firms
                       //                     where objLinq.Rec_Status == 0
                        //                 select objLinq).ToList();
             //   return objectList;
                  List<Hr_Firms> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Firms>(sql).ToList();

                

                return objectlist;



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
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Firms_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Firms_SelectMaxId()
                //         select anything.Firm_Id).Single();
                //foreach (Hr_Firms cs in objPharmaEntities.Hr_Firms)
                //    maxId = cs.Firm_Id;

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 Firm_Id  as Firm_Id  from Hr_Firms  order by replicate('0',15-len(Firm_Id))+Firm_Id desc").FirstOrDefault<string>();
              
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


        public List<OrgChartDL> GetOrgChart()
        {
            List<OrgChartDL> objectList = new List<OrgChartDL>();

            string sql = "exec  [dbo].[_SPGetOrgChart]";
            List<OrgChartDL> list = objPharmaEntities.Database.SqlQuery<OrgChartDL>(sql).ToList();
            if (list != null)
            {

                foreach (var obj in list)
                {
                    OrgChartDL objUserMenuDL = new OrgChartDL();
                    objUserMenuDL.id = obj.id;
                    objUserMenuDL.ArName = obj.ArName;
                    objUserMenuDL.EnName = obj.EnName;
                    objUserMenuDL.Type = obj.Type;
                    objUserMenuDL.Parent = obj.Parent;
                    objUserMenuDL.parent_type = obj.parent_type;
                    objUserMenuDL.level = obj.level;
                    objUserMenuDL.childCount = obj.childCount;
                    
                    objectList.Add(objUserMenuDL);
                }
            }
                    return objectList;
        }

    }
}
