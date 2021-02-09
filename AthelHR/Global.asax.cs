using BL.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AthelHR
{
    public class Global : System.Web.HttpApplication
    {
        private static AppSettingBL ObjBL = AppSettingBL.GetObject();

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

            Response.Redirect("~/Login.aspx");

            //var MultiCompanies = ObjBL.GetMultiCompanies();
            //if (MultiCompanies.MultiCompanies == 1)
            //{
            //    Response.Redirect("" + MultiCompanies.DefaultHomePage + "");
            //}
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}


        }

    }
}