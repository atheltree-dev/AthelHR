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
using PharmaERP.UserIdentity.Controllers;
using PharmaERP.UserIdentity.Enum;

namespace PharmaERP
{
    public partial class Login_Old : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         [WebMethod]

        [Authorize(Roles = "Admin")]

        public static dynamic SelectByNameAndPassword(string LoginName, string Password, string CompanyId, string BranchNo)
        {
            
            int result = 0;
            List<string> roles = new List<string>();
            roles.Add("Admin");
            CustomUserAuthorizeController auth = new CustomUserAuthorizeController();
           int value=  auth.validate(roles);

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
        public static dynamic SetBranchAndCompanyName(string strCompanyName, string strBranchName,string strLang)
        {
            bool result = true;
            
            HttpContext.Current.Session["CompanyName"] = strCompanyName;
            HttpContext.Current.Session["BranchName"] = strBranchName;
            HttpContext.Current.Session["LANG"] = strLang;

            return result;
        }


       

        

        


    }
}