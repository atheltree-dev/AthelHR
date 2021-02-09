using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
namespace AthelHR
{
    /// <summary>
    /// Summary description for GlobalFileUploder
    /// </summary>
    public class GlobalFileUploder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string strNewFileName = "";
            string str_NewFileName = "";
            string strPath = "";
            string strCompany_Id = "";
            string strBranch_Id = "";


            context.Response.ContentType = "text/plain";
            try
            {

                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;
                    strPath = (string)context.Request["strfilePath"];
                    strNewFileName = (string)context.Request["NewfileName"];
                     strCompany_Id = (string)context.Request["strCompany_Id"]; 
                    strBranch_Id = (string)context.Request["strBranch_Id"];

                    string dirFullPath = HttpContext.Current.Server.MapPath("~/" + strPath + "/");

                    string[] files1;
                    int numFiles;
                    files1 = System.IO.Directory.GetFiles(dirFullPath);
                    numFiles = files1.Length;
                    numFiles = numFiles + 1;


                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        string fname;
                        if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string fileExtension = file.ContentType;

                        if (!string.IsNullOrEmpty(fname))
                        {
                            if (strNewFileName == "CompanyInternalRegulation")
                            {
                                fileExtension = Path.GetExtension(fname);
                                str_NewFileName = strNewFileName + fileExtension;
                                string pathToSave_100 = HttpContext.Current.Server.MapPath("~/" + strPath + "/") + str_NewFileName;
                                file.SaveAs(pathToSave_100);
                            }
                            else
                            {
                                fileExtension = Path.GetExtension(fname);
                                str_NewFileName = strNewFileName + strCompany_Id.ToString() + "_" + strBranch_Id.ToString() + "_" + numFiles.ToString() + Guid.NewGuid().ToString() + fileExtension;
                                string pathToSave_100 = HttpContext.Current.Server.MapPath("~/" + strPath + "/") + str_NewFileName;
                                file.SaveAs(pathToSave_100);
                            }
                          
                        }


                    }
                }
                context.Response.ContentType = "text/plain";
                context.Response.Write(str_NewFileName);


            }
            catch (Exception ex)
            {
                context.Response.Write("Error :" + ex.Message);
            }
            



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