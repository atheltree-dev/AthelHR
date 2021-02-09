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
  public  class CompaniesDAL:CommonDB

    {
        public  async Task<int> Insert(Hr_Companies objInsert) 
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
                    
                    
                    objPharmaEntities.Hr_Companies.Add(objInsert);
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
        public int InsertTask(Hr_Companies objInsert)
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


                    objPharmaEntities.Hr_Companies.Add(objInsert);
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

        public async Task<bool> Update(Hr_Companies objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Companies ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Companies
                                            where objLinq.Company_Id == objUpdate.Company_Id
                                            select objLinq).FirstOrDefault();
                    if (ObjForUpdate != null) { 
                    ObjForUpdate.Company_Name = objUpdate.Company_Name;
                    ObjForUpdate.Company_NameEn = objUpdate.Company_NameEn;
                    ObjForUpdate.Company_Code = objUpdate.Company_Code;
                    ObjForUpdate.Company_AccountNo = objUpdate.Company_AccountNo;
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
        public bool UpdateTask(Hr_Companies objUpdate)
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
                    Hr_Companies ObjForUpdate = (from objLinq in objPharmaEntities.Hr_Companies
                                            where objLinq.Company_Id == objUpdate.Company_Id
                                            select objLinq).FirstOrDefault();
                    if (ObjForUpdate != null)
                    {
                        ObjForUpdate.Company_Name = objUpdate.Company_Name;
                        ObjForUpdate.Company_NameEn = objUpdate.Company_NameEn;
                        ObjForUpdate.Company_Code = objUpdate.Company_Code;
                        ObjForUpdate.Company_AccountNo = objUpdate.Company_AccountNo;
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

        public async Task<bool> Delete(Hr_Companies objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_Companies objForDelete = (from objLinq in objPharmaEntities.Hr_Companies
                                            where objLinq.Company_Id == objDelete.Company_Id
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

        public bool DeleteTask(Hr_Companies objDelete)
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
                    Hr_Companies objForDelete = (from objLinq in objPharmaEntities.Hr_Companies
                                            where objLinq.Company_Id == objDelete.Company_Id
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

        public Hr_Companies GetById(string Company_ID)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_Companies CompaniesForGetEntity = (from objLinq in objPharmaEntities.Hr_Companies
                                            where objLinq.Company_Id == Company_ID && objLinq.Rec_Status == 0
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
        public List<Hr_Companies> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();
                
                string sql ="select  Company_Id, Company_Code, Company_Name, Company_NameEn, Company_NameConv, Company_AccountNo, InsUser, InsDate, UpdateUser," ;
                sql = sql + " UpdateDate, DeleteUser, DeleteDate, Rec_Status, Prefix, Field_AR, Field_En, Logo_Path,ResponsibleEmpId,Id,Small_Logo_Path";
                sql = sql + " From  dbo.Hr_Companies  where Rec_Status = 0";
                    sql = sql + " Order by Id ";

               // List<Hr_Companies> objectList = (from objLinq in objPharmaEntities.Hr_Companies
                       //                     where objLinq.Rec_Status == 0
                        //                 select objLinq).ToList();
             //   return objectList;
                  List<Hr_Companies> objectlist = objPharmaEntities.Database.SqlQuery<Hr_Companies>(sql).ToList();

                

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
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Companies_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Companies_SelectMaxId()
                //         select anything.Company_Id).Single();
                //foreach (Hr_Companies cs in objPharmaEntities.Hr_Companies)
                //    maxId = cs.Company_Id;

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<string>("select top 1 Company_Id  as Company_Id  from Hr_Companies  order by replicate('0',15-len(Company_Id))+Company_Id desc").FirstOrDefault<string>();
              
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
