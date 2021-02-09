using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.UserManagement;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
namespace DAL.UserManagement
{
    public class UserMenuDAL:CommonDB
    {
        //AthelHREntities objPharmaEntities;
        public UserMenuDAL()
        {
            //objPharmaEntities = new AthelHREntities();
        }

        public string GetUserNameByMailOrName(string varusername) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = String.Empty;
            object username = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 UserName as UserName  from AspNetUsers where UserName='" + varusername + "' or Email='" + varusername + "'";
                username = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
                if (username != null)
                {
                    nextId = username.ToString();

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
        public List<AppUserMenuDL> SelectByComapnyAndBranch(string User_Id, string Company_Id, string Branch_Id)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<AppUserMenuDL> objectList = new List<AppUserMenuDL>();

                object[] param1 = { 
                new SqlParameter("@Company_Id",Company_Id),
                new SqlParameter("@Branch_Id", Branch_Id),
                new SqlParameter("@UserId", User_Id)};

                var objlist = objPharmaEntities.Database.SqlQuery<AppUserMenuDL>("exec  [dbo].[_SPGetUserMenuAndRoles] @Company_Id,@Branch_Id,@UserId", param1).ToList();
                if (objlist != null) 
                {
                
                    foreach (var obj in objlist)
                    {
                        AppUserMenuDL objUserMenuDL = new AppUserMenuDL();
                        objUserMenuDL.MenuId = obj.MenuId;
                        objUserMenuDL.MenuName = obj.MenuName;
                        objUserMenuDL.MenuNameEn = obj.MenuNameEn;
                        objUserMenuDL.ParentId = obj.ParentId;
                        objUserMenuDL.LevelId = obj.LevelId;
                        objUserMenuDL.IsVisiable = obj.IsVisiable;
                        objUserMenuDL.CanInsert = obj.CanInsert;
                        objUserMenuDL.CanUpdate = obj.CanUpdate;
                        objUserMenuDL.CanDelete = obj.CanDelete;
                        objUserMenuDL.CanSearch = obj.CanSearch;
                        objUserMenuDL.PathUrl = obj.PathUrl;
                        objUserMenuDL.PageName = obj.PageName;
                        objUserMenuDL.isActive = obj.isActive;
                        objectList.Add(objUserMenuDL);

                    }
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

      

       


    }
}
