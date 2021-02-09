using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BL;
using BL.AppSetting;
using DAL;
using BL.HR.Registeration;
using BL.HrServices.Notification;
using BOL.UserManagement;
using BL.UserManagement;
using AthelHR.UserIdentity.Controllers;
using AthelHR.UserIdentity.Enum;
namespace MetronicAdmin
{
    
    public partial class Helper : System.Web.UI.Page
    {
        private static EmployeesBL ObjBL = EmployeesBL.GetObject();

        public static bool Islogin;
        class DataUserCurrentLogin
        {
            public string BranchIdProp {set; get; }
            public  string BranchNameProp{set;get;}
            public string  CompanyIdProp {set; get;}
            public string CompanyNameProp{set;get;}
            public string UserIdProp { set; get; }
            public string UserNameProp { set; get; }
            public decimal EmpSerialNoProp { set; get; }
            public string BranchNameENProp { set; get; }
            public string CompanyNameENProp { set; get; }

            
        }

      public  class LastMenuActivateDL
        {
            public string LastMenu0 { set; get; }
            public string LastMenu1 { set; get; }
            public string LastMenu2 { set; get; }
           
        }

        public Helper()
        {

           //if (HttpContext.Current.Session["Hr_UserDL"] == null)
           // {
           //     Response.Redirect(@"~\Login.aspx");
             
           // }
           
        }


        


        [WebMethod]
        public static dynamic GotoLoginScreen(bool prvIslogin)
        {

            Islogin = prvIslogin;
            return true;
          
           
        }

        protected void ChkvalidLoginScr() 
        {
            if (!Islogin ) 
            { 
            Response.Redirect(@"~/login.aspx",true);
            }
        }

        [WebMethod]
        public static dynamic SetSessionLang(string strlang)
        {
            string strlocalLang ="";
            if (strlang == "") {
             strlocalLang = "EN";
            }else{
            strlocalLang =strlang;
            }
            HttpContext.Current.Session["LANG"] = strlocalLang;
            return strlocalLang;
           
        }


        [WebMethod]
        public static dynamic GetSessionLang()
        {
            string lang = "EN";
            if (HttpContext.Current.Session["LANG"] != null) 
            {
                lang = HttpContext.Current.Session["LANG"].ToString();
            }
            
            return lang;

        }


             [WebMethod]
        public static dynamic GetCalcWithGrade(string strCompany, string strBranch)
        {
            if (HttpContext.Current.Session["Hr_UserDL"] != null)
            {
               // AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];
                AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];

                AppSettingBL.GetObject().UserNameProperty = CurrentUser.UserName;
                return AppSettingBL.GetObject().GetCalcWithGrade(strCompany, strBranch);
            }
            else
                return 0;

        }
        [WebMethod]
        public static dynamic FillGeneralComboAll(string StrFldId, string StrFldName, string StrTblName, string StrWhere)
        {
            return CommonBL.GetObject().FillGeneralComboAll(StrFldId, StrFldName, StrTblName, StrWhere);
        }

        [WebMethod]
        public static dynamic FillGeneralComboAllWithOutCondtion(string StrFldId, string StrFldName, string StrTblName, string StrWhere)
        {
            return CommonBL.GetObject().FillGeneralComboAllWithOutCondtion(StrFldId, StrFldName, StrTblName, StrWhere);
        }

        
        [WebMethod]
        public static dynamic FillEmployeeBySerialAndRole(string Company_Id, string Branch_Id, decimal EmpSerialNo)
        {
            return CommonBL.GetObject().FillEmployeeBySerialAndRole(Company_Id, Branch_Id, EmpSerialNo);

        }
        
        [WebMethod]
        public static dynamic FillEmployeeBySerialAndRoleWithShow(string Company_Id, string Branch_Id, decimal EmpSerialNo)
        {
            return CommonBL.GetObject().FillEmployeeBySerialAndRoleWithShow(Company_Id, Branch_Id, EmpSerialNo);

        }
        [WebMethod]
        public static dynamic FillEmployeeBySerialAndRoleWithPara(string Company_Id, string Branch_Id, decimal EmpSerialNo, string StrWhere)
        {
            return CommonBL.GetObject().FillEmployeeBySerialAndRoleWithPara(Company_Id, Branch_Id, EmpSerialNo, StrWhere);

        }
        


        [WebMethod]
        public static dynamic ChkAnyPendingRequest(string FldId1, string TblName, string Strwhere)
        {
            return CommonBL.GetObject().ChkAnyPendingRequest(FldId1,TblName,Strwhere);
        }

        //[WebMethod]
        //public static dynamic GetPublicUserName()
        //{
        //    string Result = "0";
        //    if (HttpContext.Current.Session["Hr_UserDL"] != null)
        //    {
        //        AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];
        //        Result = CurrentUser.UserName;
        //    }
        //    return Result;

        //}

        //[WebMethod]
        //public static dynamic GetBranchId()
        //{
        //    string Result = "0";
        //    if (HttpContext.Current.Session["Hr_UserDL"] != null)
        //    {
        //        AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];
        //        Result = CurrentUser.Branch_Id;
        //    }
        //    return Result;

        //}

        //[WebMethod]
        //public static dynamic GetUserData()
        //{
            
        //    if (HttpContext.Current.Session["Hr_UserDL"] != null)
        //    {
        //        DataUserCurrentLogin objDataUserName= new DataUserCurrentLogin();
                
        //       // AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];
        //        AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];

        //        string strcomp = HttpContext.Current.Session["CompanyName"].ToString().Trim();
        //        string strBrnch = HttpContext.Current.Session["BranchName"].ToString().Trim();

        //        objDataUserName.CompanyNameProp = String.Join("", strcomp.Where(c => c != '\n' && c != '\r' && c != '\t'));
        //        objDataUserName.BranchNameProp = String.Join("", strBrnch.Where(c => c != '\n' && c != '\r' && c != '\t'));


        //        objDataUserName.BranchIdProp = CurrentUser.Branch_Id;
        //        objDataUserName.CompanyIdProp = CurrentUser.Company_Id;
        //        objDataUserName.UserIdProp = CurrentUser.Id;
        //        objDataUserName.UserNameProp = CurrentUser.UserName;
        //        objDataUserName.EmpSerialNoProp = CurrentUser.Emp_Serial_No;
        //        return objDataUserName;
        //    }
        //    else 
        //    {
        //        return null;
        //    }
            

        //}


        [WebMethod]
        public static dynamic GetUserData()
        {


            if (HttpContext.Current.Session["Hr_UserDL"] != null)
            {
                DataUserCurrentLogin objDataUserName = new DataUserCurrentLogin();

                // AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];
                AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];

                string strcomp = HttpContext.Current.Session["CompanyName"].ToString().Trim();
                string strBrnch = HttpContext.Current.Session["BranchName"].ToString().Trim();
                string strcompEN = HttpContext.Current.Session["CompanyNameEN"].ToString().Trim();
                string strBrnchEN = HttpContext.Current.Session["BranchNameEN"].ToString().Trim();


                objDataUserName.CompanyNameProp = String.Join("", strcomp.Where(c => c != '\n' && c != '\r' && c != '\t'));
                objDataUserName.BranchNameProp = String.Join("", strBrnch.Where(c => c != '\n' && c != '\r' && c != '\t'));
                objDataUserName.CompanyNameENProp = String.Join("", strcompEN.Where(c => c != '\n' && c != '\r' && c != '\t'));
                objDataUserName.BranchNameENProp = String.Join("", strBrnchEN.Where(c => c != '\n' && c != '\r' && c != '\t'));




                objDataUserName.BranchIdProp = CurrentUser.Branch_Id;
                objDataUserName.CompanyIdProp = CurrentUser.Company_Id;
                objDataUserName.UserIdProp = CurrentUser.Id;
                objDataUserName.UserNameProp = CurrentUser.UserName;
                objDataUserName.EmpSerialNoProp = CurrentUser.Emp_Serial_No;
                return objDataUserName;
            }
            else
            {
                return null;
            }


        }


        [WebMethod]
        public static dynamic RemoveFile(string fileName)
        {
            bool result = false;
            //  List<HttpPostedFile> files = (List<HttpPostedFile>)HttpContext.Current.Session["Files"];
            //  files.RemoveAll(f => f.FileName.ToLower().EndsWith(fileName.ToLower()));

            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("~/AttachFilesApp/EmployeeImages/" + fileName)))
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/AttachFilesApp/EmployeeImages/" + fileName));
                result = true;
            }

            return result;
        }

        [WebMethod]
        public static dynamic RemoveFileLogo(string fileName)
        {
            bool result = false;
            //  List<HttpPostedFile> files = (List<HttpPostedFile>)HttpContext.Current.Session["Files"];
            //  files.RemoveAll(f => f.FileName.ToLower().EndsWith(fileName.ToLower()));

            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("~/AttachFilesApp/CompLogoAttach/" + fileName)))
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/AttachFilesApp/CompLogoAttach/" + fileName));
                result = true;
            }

            return result;
        }

        [WebMethod]
        public static dynamic GetImageUser(decimal empSerialNo, string strCompany, string strBranch)
        {

            if (HttpContext.Current.Session["Hr_UserDL"] != null)
            {
                string StrImageUser = string.Empty;

                StrImageUser = ObjBL.GetImageUser(empSerialNo, strCompany, strBranch);

                return StrImageUser;
            }
            else
            {
                return null;
            }


        }
        
        
        
            [WebMethod]
        public static dynamic CheckEmpHasNotification(string strcomapny, string strbranch, decimal Empserial_no)
        {
             
            return EmpNotifyBL.GetObject().SelectAllByCompanyAndBranch(strcomapny, strbranch, Empserial_no);

        }


        //[WebMethod]
        //public static dynamic SelectAllByCompanyAndBranch(string strcomapny, string strbranch,decimal Empserial_no)
        //{
             
        //    return EmpRequestNotifyBL.GetObject().SelectAllByCompanyAndBranch(strcomapny, strbranch, Empserial_no);

        //}

          [WebMethod]
        public static dynamic FnLogout()
        {
            if (HttpContext.Current.Session["Hr_UserDL"] != null || HttpContext.Current.Session["LastMenuActivate"] != null) 
            {
                HttpContext.Current.Session.Remove("Hr_UserDL");
                HttpContext.Current.Session.Remove("LastMenuActivate");
            }
            
            return true;

        }

        [WebMethod]
          public static dynamic ChekUserIsCommissioner(decimal empSerialNo, string strCompany, string strBranch)
        {

            if (HttpContext.Current.Session["Hr_UserDL"] != null)
            {
                //AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];
                AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];
                ObjBL.UserNameProperty = CurrentUser.UserName;
                bool result;
                result = ObjBL.ChekUserIsCommissioner(empSerialNo, strCompany, strBranch);

                return result;
            }
            else
            {
                return false;
            }


        }

        [WebMethod]
        public static dynamic GetNewHeaderId()
        {

            if (HttpContext.Current.Session["Hr_UserDL"] != null)
            {

               // Guid result;
               // result = CommonBL.GetObject().GetNewHdrId();

                return CommonBL.GetObject().GetNewHdrId();
            }
            else
            {
                return Guid.NewGuid();
            }


        }


        [WebMethod]
        public static dynamic GlobalRemoveFile(string fileName, string PathFile)
        {
            bool result = false;
            //  List<HttpPostedFile> files = (List<HttpPostedFile>)HttpContext.Current.Session["Files"];
            //  files.RemoveAll(f => f.FileName.ToLower().EndsWith(fileName.ToLower()));
            
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("~/" + PathFile + "/" + fileName)))
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/" + PathFile + "/" + fileName));
                result = true;
            }

            return result;
        }
        
        

         [WebMethod]
        public static dynamic ChkJobIdIsIdentity(string jobId,string Company_Id, string Branch_Id)
        {
            return ObjBL.ChkJobIdIsIdentity(jobId, Company_Id, Branch_Id);
        }

        [WebMethod]
         public static dynamic ChkEmpCodeIsIdentity(string EmpCode, string Company_Id, string Branch_Id)
        {
            return ObjBL.ChkEmpCodeIsIdentity(EmpCode, Company_Id, Branch_Id);
        }

        

        [WebMethod]
         public static dynamic ChkEmailIsIdentity(string StrEmail, string Company_Id, string Branch_Id)
        {
            return ObjBL.ChkEmailIsIdentity(StrEmail, Company_Id, Branch_Id);
        }

        

        [WebMethod]
        public static dynamic ChkEmployeeWithUserIsIdentity(decimal StrSerialNo, string Company_Id, string Branch_Id)
        {
            return ObjBL.ChkEmployeeWithUserIsIdentity(StrSerialNo, Company_Id, Branch_Id);
        }

        [WebMethod]
        public static dynamic ChkUserNameIsIdentity(string StrUserName, string Company_Id, string Branch_Id)
        {
            return ObjBL.ChkUserNameIsIdentity(StrUserName, Company_Id, Branch_Id);

        }
        
         [WebMethod]
        public static dynamic ChkVaildRequestDate(string Company_Id, string Branch_Id, decimal Emp_serial_No, string fromDate, string toDate)
        {
            return CommonBL.GetObject().ChkVaildRequestDate( Company_Id,  Branch_Id,  Emp_serial_No,  fromDate,  toDate);

        }


        [WebMethod]
         public static dynamic GetRolePageByUser(string Company_Id, string Branch_Id, string User_Id, string PageName)
        {
            
           
            CustomUserAuthorizeController auth = new CustomUserAuthorizeController();
            int value = auth.validateUserAuhontiacted();
            if (value == (int)UserStatusEnum.UserStatus.Authuntizated)
            {
                return AppUsersMenuPriviledgeBL.GetObject().GetUserPageByUser(Company_Id, Branch_Id, User_Id, PageName);
            }
            else 
            {
                return -1;
            }

            
        }



        [WebMethod]
        public static dynamic CheckUserAuthontication()
        {


            CustomUserAuthorizeController auth = new CustomUserAuthorizeController();
            int value = auth.validateUserAuhontiacted();
            return value;


        }

        [WebMethod]
        public static dynamic GetRolesByUser(List<string> roles)
        {
            //List<string> roles = new List<string>();
            //roles.Add("Admin");
            CustomUserAuthorizeController auth = new CustomUserAuthorizeController();
            int value = auth.validate(roles);
            return value;

        }

        [WebMethod]
        public static dynamic SetLastMenuActivate(MetronicAdmin.Helper.LastMenuActivateDL objLastMenuActivateDL)
        {
            bool result = true;

            HttpContext.Current.Session["LastMenuActivate"] = objLastMenuActivateDL;

            return result;
        }

        [WebMethod]
        public static dynamic getLastMenuActivate()
        {
            LastMenuActivateDL obj = new LastMenuActivateDL();
            if (HttpContext.Current.Session["LastMenuActivate"] != null) 
            {
                obj =(LastMenuActivateDL)HttpContext.Current.Session["LastMenuActivate"];
            }
            
            return obj;
        }

        [WebMethod]
        public static dynamic GetEmployeeUserData(string strcomapny, string strbranch, decimal strEmpSerialNo) 
        {
            return ObjBL.GetEmployeeUserData(strcomapny, strbranch, strEmpSerialNo);
        }


  //GetEmpTree
        [WebMethod]
        public static dynamic GetEmpTreeForMenu()
        {
            return ObjBL.GetEmpTree();
        }

        [WebMethod]
        public static dynamic ChkShowAllEmp(string EmpId)
        {
            if (HttpContext.Current.Session["Hr_UserDL"] != null)
            {
                AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];
                ObjBL.UserNameProperty = CurrentUser.UserName;
                return ObjBL.ChkShowAllEmp(EmpId);
            }
            else
                return null;

        }

         [WebMethod]
        public static dynamic GetCustomerCompany_Code(string strCompany, string strBranch)
        {
            if (HttpContext.Current.Session["Hr_UserDL"] != null)
            {
                // AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];

                return AppSettingBL.GetObject().GetCustomerCompany_Code(strCompany, strBranch);
            }
            else
                return "1";

        }

         [WebMethod]
         public static dynamic GetLogo()
         {
              if (HttpContext.Current.Session["Hr_UserDL"] != null)
             {
                 return ObjBL.GetLogo();
                     }
             else
                 return "1";


         }

         [WebMethod]
         public static dynamic GetImagePath(string strcomapny)
         {
             if (HttpContext.Current.Session["Hr_UserDL"] != null)
             {
                 // AspNetUserDL CurrentUser = (AspNetUserDL)HttpContext.Current.Session["Hr_UserDL"];

                 return ObjBL.GetImagePath(strcomapny);
             }
             else
                 return "1";

         }

         //[WebMethod]
         //public static dynamic GetMultiCompanies()
         //{
         //    //var MultiCompanies = Common.objPharmaEntities.Database.SqlQuery<App_Settings>("select MultiCompanies,DefaultHomePage from App_Settings").FirstOrDefault<App_Settings>();
         //    //return MultiCompanies;
         //    return AppSettingBL.GetObject().GetMultiCompanies();
         //}

    }
}