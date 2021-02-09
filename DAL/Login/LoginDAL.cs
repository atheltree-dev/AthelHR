using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.Login;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DAL.Login
{
    public class LoginDAL : CommonDB
    {





        public List<LoginDL> GetBranchAndCompanyName(string Company_Id, string Branch_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();



            try
            {
                OpenEntityConnection();

                List<LoginDL> objectList = new List<LoginDL>();


                object[] param1 = {

                new SqlParameter("@Company_Id", Company_Id),
                 new SqlParameter("@Branch_Id", Branch_Id),

            };
                var objlist = new AthelHREntities().Database.SqlQuery<LoginDL>("select Company_Name,Company_NameEn,Branch_Name,Branch_NameEn from Hr_Companies a,Hr_Branches b where b.Company_Id = a.Company_Id AND a.Company_Id=@Company_Id AND b.Branch_Id=@Branch_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    LoginDL LoginDL = new LoginDL();
                    LoginDL.Company_Name = obj.Company_Name;
                    LoginDL.Company_NameEn = obj.Company_NameEn;
                    LoginDL.Branch_Name = obj.Branch_Name;
                    LoginDL.Branch_NameEn = obj.Branch_NameEn;
                    objectList.Add(LoginDL);

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

        public string GetLogo()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();



            try
            {
                OpenEntityConnection();

               
                var path = new AthelHREntities().Database.SqlQuery<string>("select Logo_Path from Hr_Companies ").FirstOrDefault();

               
                return path;
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
