using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using BL.UserManagement;
using DAL.UserManagement;
using BOL.UserManagement;
namespace AthelHR
{
    /// <summary>
    /// Summary description for MenuHandler
    /// </summary>
    public class MenuHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

           // string cs = ConfigurationManager.ConnectionStrings["IstConnection"].ConnectionString;

            //List<DAL.APP_Menus> listmenu = new List<DAL.APP_Menus>();

            //    listmenu = MenusBL.GetObject().GetAll();

            List<AppUserMenuDL> listmenu = new List<AppUserMenuDL>();
          //  if (HttpContext.Current.Session["Hr_UserDL"] != null) 
           // {
             //   AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];



            string User_Id = context.Request.QueryString["User_Id"].ToString();  //CurrentUser.Id;
            string Company_Id = context.Request.QueryString["Company_Id"].ToString();///CurrentUser.Company_Id;
            string Branch_Id = context.Request.QueryString["Branch_Id"].ToString();//CurrentUser.Branch_Id;

                listmenu = UserMenuBL.GetObject().SelectByComapnyAndBranch(User_Id, Company_Id, Branch_Id);


                JavaScriptSerializer js = new JavaScriptSerializer();
                // context.Response.Write(js.Serialize(MenuTree));
                context.Response.Write(js.Serialize(listmenu));


           // }
            

           
            

        }
       
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}