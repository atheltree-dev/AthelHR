using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Reflection;

namespace DAL
{
    public class CommonDB
    {
        
        #region PrivateVariables

        static readonly string PasswordHash = "password@pharma.com";
        static readonly string SaltKey = "itteam@pharma.com";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        
        //private SqlConnection SqlConn;

        #endregion

        #region Public Attributes
      //  public static string dbOwner = ConfigurationManager.AppSettings["DB_OwnerName"].ToString();
      
       // public string ConnectionString = new ConfigurationManager.ConnectionStrings["strAthelHREntities"].ConnectionString;
      //  public static string ConnectionString =  ConfigurationManager.ConnectionStrings["IstConnection"].ConnectionString;

        public string UserNameProperty { set; get; }
        public AthelHREntities objPharmaEntities;
       // DBEntityCls objDBEntityCls;
        
        #endregion

        #region Constructor

        public CommonDB()
        {

            
 

            if (objPharmaEntities ==null)
            {
                
                objPharmaEntities = new AthelHREntities();
                //objPharmaEntities = new AthelHREntities();
                
              //  objPharmaEntities.Database.Connection.ConnectionString = ConnectionString;
            }
            

            //if (SqlConn == null)
            //{
            //    SqlConn = new SqlConnection();
            //    SqlConn.ConnectionString = ConnectionString;
            //}
        }
        public  void OpenEntityConnection()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            if (objPharmaEntities.Database.Connection.State != ConnectionState.Open)
            {
                try
                {

                    

                    objPharmaEntities.Database.Connection.Open();

                }
                catch (Exception ex)
                {
                    catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                    throw ex;
                }
            }
        }

        public void CloseEntityConnection()
        {
            if (objPharmaEntities.Database.Connection.State == ConnectionState.Open)
            {
                objPharmaEntities.Database.Connection.Close();
            }
        }

        

        public string FnConvertNameToBiny() 
        {
            return "";
        }


        //[EdmFunction("AthelHREntities.Store", "FnConvertNameToBiny")]
        //public static string ConvertNameToBiny(string  strOriginalName)
        //{
        //    //throw new NotSupportedException("Direct calls are not supported.");

        //    string result = "0";
        //    result = objPharmaEntities.Database.SqlQuery<string>("SELECT [dbo].[FnConvertNameToBiny](" + strOriginalName + "'").First();
        //    return result;
        //}

       

        public string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {

                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }


       

        #endregion

        

        public void catchEntityvalidation(DbEntityValidationException ex, string errorCode, string UserName, string StrClassName, string strFunctionName)
            {
             //////   // Retrieve the error messages as a list of strings.
             //////   var errorMessages = ex.EntityValidationErrors
             //////           .SelectMany(x => x.ValidationErrors)
             //////           .Select(x => x.ErrorMessage);

             //////   // Join the list to a single string.
             //////   var fullErrorMessage = string.Join("; ", errorMessages);

             //////   // Combine the original exception message with the new one.
             //////   var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

               
             //////   // Throw a new DbEntityValidationException with the improved exception message.

             ////////   throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

             //////   //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage

               Exception raise = ex;

                 foreach (var validationErrors in ex.EntityValidationErrors)

                 {

                     foreach (var validationError in validationErrors.ValidationErrors)

                     {

                          string message = string.Format("{0}:{1}",

                              validationErrors.Entry.Entity.ToString(),

                            validationError.ErrorMessage);

                          // raise a new exception nesting

                         // the current instance as InnerException

                         raise = new InvalidOperationException(message, raise);

                         SaveErrorLog(errorCode, message, UserName, StrClassName, strFunctionName);


                     }

                 }

                 throw raise;


               

                
            }
         public bool SaveErrorLog(string errorCode, string errorMessage,string UserName ,string StrClassName,string strFunctionName) 
         {
             bool result = false;

           
            //int result = Insert(objInsert).Result;
            //return result;

            int RowEffected = 0;
            try
            {
                
                 
                    OpenEntityConnection();
                   

              //  string 
                    errorMessage = errorMessage.Replace(".", "");
                    string sql = "insert into App_ErrorLog (Error_Id,Error_Message,UserName,ClassName,FunctionName) values ('" + errorCode + "','" + errorMessage + "','" + UserName + "','" + StrClassName + "','" + strFunctionName + "') ";
                     RowEffected = objPharmaEntities.Database.ExecuteSqlCommand(sql);
                    
                  //  objPharmaEntities.App_ErrorLog.Add(objAppError);
                  //  RowEffected =  objPharmaEntities.SaveChanges();
                   
                

            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

             //   SaveErrorLog(exceptionMessage);
                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage



                //List<string> errorMessages = new List<string>();
                //foreach (DbEntityValidationResult validationResult in ex.EntityValidationErrors)
                //{
                //    string entityName = validationResult.Entry.Entity.GetType().Name;
                //    foreach (DbValidationError error in validationResult.ValidationErrors)
                //    {
                //        errorMessages.Add(entityName + "." + error.PropertyName + ": " + error.ErrorMessage);
                //    }
                //}


            }
            catch (Exception ex)
            {
             //   catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex);
                RowEffected = -1;
                ex.InnerException.Message.ToString();


            }
            finally
            {
                CloseEntityConnection();
            }

            result = RowEffected > 0;
             return result;
         }
         public Guid GetNewHeaderId() 
         {
              StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            Guid NewHdr;
             
             try
             {
                 OpenEntityConnection();
                 NewHdr = objPharmaEntities.Database.SqlQuery<Guid>("exec dbo.GetNewGuidID").FirstOrDefault<Guid>();
                 
                  
             }
            catch (Exception ex)
                {
                    catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                       NewHdr = Guid.NewGuid();
                    throw ex;
                
                }
             finally
             {
                 CloseEntityConnection();
             }
             return NewHdr; 
         }

         public string ChkAnyPendingRequest(string FldId1, string TblName, string Strwhere)
         {
             StackFrame stackFrame = new StackFrame();
             MethodBase methodBase = stackFrame.GetMethod();

             string Result = String.Empty;
             try
             {

                 OpenEntityConnection();
                 Strwhere = (Strwhere.Length == 0 ? "@" : Strwhere);
                 //var para1 = new SqlParameter("@FldIdName",FldId1);
                 // var para2 = new SqlParameter("@FldName", FldName1);
                 // var para3 = new SqlParameter("@TblName", TblName);
                 // var para4 = new SqlParameter("@Strwhere", Strwhere);
                 // object[] param = { para1, para2, para3, para4 };

                 object[] param1 = { 
               new SqlParameter("@FldIdName",FldId1),
                new SqlParameter("@TblName", TblName),
                 new SqlParameter("@Strwhere", Strwhere)};

                 //               object[] params = {
                 //                new SqlParameter("@ParametterWithNummvalue", DBNull.Value),
                 //                new SqlParameter("@In_Parameter", "Value"),
                 //                new SqlParameter("@Out_Parameter", SqlDbType.INT) 
                 //{Direction = ParameterDirection.Output}};

                 //            YourDbContext.Database.ExecuteSqlCommand("exec StoreProcedure_Name @ParametterWithNummvalue, @In_Parameter, @Out_Parameter", params);
                 //            YourDbContext.SaveChanges();

                 //Var ReturnValue = ((SqlParameter)params[2]).Value


                 string objlist = objPharmaEntities.Database.SqlQuery<string>("exec dbo.SP_ChkAnyPendingRequest @FldIdName,@TblName,@Strwhere", param1).FirstOrDefault();

                 //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);

                 if (objlist != null) 
                 {
                     Result = objlist;
                 }

                 
             }
             catch (Exception ex)
             {
                 catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                          this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                 Result = null;
                 throw ex;

             }
             finally
             {
                 CloseEntityConnection();
             }

             return Result;
         }


         public string ChkVaildRequestDate(string Company_Id, string Branch_Id, decimal Emp_serial_No, string fromDate, string toDate)
         {
             StackFrame stackFrame = new StackFrame();
             MethodBase methodBase = stackFrame.GetMethod();

             string Result = String.Empty;
             try
             {

                 OpenEntityConnection();
                 object[] param1 = { 
                    new SqlParameter("@Company_Id",Company_Id),
                    new SqlParameter("@Branch_Id", Branch_Id),
                    new SqlParameter("@Emp_serial_No", Emp_serial_No),
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)};

                 //               object[] params = {
                 //                new SqlParameter("@ParametterWithNummvalue", DBNull.Value),
                 //                new SqlParameter("@In_Parameter", "Value"),
                 //                new SqlParameter("@Out_Parameter", SqlDbType.INT) 
                 //{Direction = ParameterDirection.Output}};

                 //            YourDbContext.Database.ExecuteSqlCommand("exec StoreProcedure_Name @ParametterWithNummvalue, @In_Parameter, @Out_Parameter", params);
                 //            YourDbContext.SaveChanges();

                 //Var ReturnValue = ((SqlParameter)params[2]).Value


                 string objlist = objPharmaEntities.Database.SqlQuery<string>("exec dbo._SPChkVaildRequestDate @Company_Id,@Branch_Id,@Emp_serial_No,@fromDate,@toDate", param1).FirstOrDefault();

                 //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);

                 if (objlist != null)
                 {
                     Result = objlist;
                 }


             }
             catch (Exception ex)
             {
                 catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                          this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                 Result = null;
                 throw ex;

             }
             finally
             {
                 CloseEntityConnection();
             }

             return Result;
         }



        //private string TestConnectionEF()
        //{
        //    using (var db = new AthelHREntities())
        //    {
        //        try
        //        {
        //            db.Database.Connection.Open();
        //            if (db.Database.Connection.State == ConnectionState.Open)
        //            {
        //                Console.WriteLine(@"INFO: ConnectionString: " + db.Database.Connection.ConnectionString
        //                    + "\n DataBase: " + db.Database.Connection.Database
        //                    + "\n DataSource: " + db.Database.Connection.DataSource
        //                    + "\n ServerVersion: " + db.Database.Connection.ServerVersion
        //                    + "\n TimeOut: " + db.Database.Connection.ConnectionTimeout);
        //                db.Database.Connection.Close();
        //                return null;
        //            }
        //            return "ERROR";
        //        }
        //        catch (Exception ex)
        //        {
        //            return ex.Message + " \n PING: " + TryPing(db.Database.Connection.DataSource).ToString();
        //        }
        //    }
        //}

        //public string GetNumberOFWorkDays(Guid leaveID)
        //{
        //    using (var ctx = new INTERNAL_IntranetDemoEntities())
        //    {
        //        return ctx.ExecuteStoreQuery<string>(
        //                      "SELECT [dbo].[fnCalculateNumberOFWorkDays](@leaveID)",
        //                      new SqlParameter { ParameterName = "leaveID", Value = leaveID }
        //                   ).FirstOrDefault();
        //    }
        //}

         //public static void InsertIntoMembers(DataTable dataTable)
         //{
         //    using (var connection = new SqlConnection(@"data source=;persist security info=True;user id=;password=;initial catalog=;MultipleActiveResultSets=True;App=EntityFramework"))
         //    {
         //        SqlTransaction transaction = null;
         //        connection.Open();
         //        try
         //        {
         //            transaction = connection.BeginTransaction();
         //            using (var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, transaction))
         //            {
         //                sqlBulkCopy.DestinationTableName = "Members";
         //                sqlBulkCopy.ColumnMappings.Add("Firstname", "Firstname");
         //                sqlBulkCopy.ColumnMappings.Add("Lastname", "Lastname");
         //                sqlBulkCopy.ColumnMappings.Add("DOB", "DOB");
         //                sqlBulkCopy.ColumnMappings.Add("Gender", "Gender");
         //                sqlBulkCopy.ColumnMappings.Add("Email", "Email");

         //                sqlBulkCopy.ColumnMappings.Add("Address1", "Address1");
         //                sqlBulkCopy.ColumnMappings.Add("Address2", "Address2");
         //                sqlBulkCopy.ColumnMappings.Add("Address3", "Address3");
         //                sqlBulkCopy.ColumnMappings.Add("Address4", "Address4");
         //                sqlBulkCopy.ColumnMappings.Add("Postcode", "Postcode");

         //                sqlBulkCopy.ColumnMappings.Add("MobileNumber", "MobileNumber");
         //                sqlBulkCopy.ColumnMappings.Add("TelephoneNumber", "TelephoneNumber");

         //                sqlBulkCopy.ColumnMappings.Add("Deleted", "Deleted");

         //                sqlBulkCopy.WriteToServer(dataTable);
         //            }
         //            transaction.Commit();
         //        }
         //        catch (Exception)
         //        {
         //            transaction.Rollback();
         //        }

         //    }
         //}


    }
}
