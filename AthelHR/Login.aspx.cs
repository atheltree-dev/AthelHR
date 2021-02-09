using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL.UserManagement;
using BL.HrServices.RequestManagement;
using DAL;
using System.Web.Http;
using AthelHR.UserIdentity.Controllers;
using AthelHR.UserIdentity.Enum;
using BOL.UserManagement;
using System.Data.SqlClient;
using BOL.Login;
using BL.Login;

namespace AthelHR
{
    public partial class Login : System.Web.UI.Page
    {
        private static LoginBL ObjBL = LoginBL.GetObject();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        [AllowAnonymous]
        public static dynamic GetUserNameByMailOrName(string varusername)
        {
            return UserMenuBL.GetObject().GetUserNameByMailOrName(varusername);
        }

        [WebMethod]
        public static dynamic SelectByNameAndPassword(string LoginName, string Password, string CompanyId, string BranchNo)
        {

            int result = 0;
            List<string> roles = new List<string>();
            roles.Add("Admin");
            CustomUserAuthorizeController auth = new CustomUserAuthorizeController();
            int value = auth.validate(roles);

            if (value == (int)UserStatusEnum.UserStatus.Authorized)
            {
                Hr_Users obj = UsersBL.GetObject().SelectByNameAndPassword(LoginName, Password, CompanyId, BranchNo);
                if (obj != null && obj.UserId != null)
                {
                    result = 1;
                    HttpContext.Current.Session["Hr_UserDL"] = obj;
                }
                else
                {
                    result = 0;
                }
            }

            return result;
            // return Ok(result);

        }

        [WebMethod]
        public static dynamic GetBranchAndCompanyName(string Company_Id, string Branch_Id)
        {

            if (HttpContext.Current.Session["Hr_UserDL"] != null)
            {
                AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];

                ObjBL.UserNameProperty = CurrentUser.UserName;
                return ObjBL.GetBranchAndCompanyName(Company_Id, Branch_Id);
            }
            else
                return null;



        }

        [WebMethod]
        public static dynamic SetBranchAndCompanyName(string strCompanyName, string strBranchName, string strCompanyNameEN, string strBranchNameEN, string strLang)
        {
            bool result = true;

            HttpContext.Current.Session["CompanyName"] = strCompanyName;
            HttpContext.Current.Session["BranchName"] = strBranchName;
            HttpContext.Current.Session["CompanyNameEN"] = strCompanyNameEN;
            HttpContext.Current.Session["BranchNameEN"] = strBranchNameEN;


            HttpContext.Current.Session["LANG"] = strLang;
            if (HttpContext.Current.Session["LastMenuActivate"] != null)
            {
                HttpContext.Current.Session.Remove("LastMenuActivate");
            }
            return result;
        }

        //[WebMethod]
        //public static dynamic SetBranchAndCompanyName(string strCompanyName, string strBranchName,string strLang)
        //{
        //    bool result = true;

        //    HttpContext.Current.Session["CompanyName"] = strCompanyName;
        //    HttpContext.Current.Session["BranchName"] = strBranchName;
        //    HttpContext.Current.Session["LANG"] = strLang;
        //    if (HttpContext.Current.Session["LastMenuActivate"] != null) 
        //    {
        //        HttpContext.Current.Session.Remove("LastMenuActivate");
        //    }
        //    return result;
        //}


        [WebMethod]

        public static dynamic setUserData(AspNetUserDL objUser)
        {

            bool result = true;

            if (objUser != null && objUser.Id != null)
            {

                HttpContext.Current.Session["Hr_UserDL"] = objUser;

            }
            else
            {
                result = false;
            }

            return result;

            // return Ok(result);

        }



        [WebMethod]
        public static dynamic GetLogo()
        {

            return ObjBL.GetLogo();

        }








    }
}