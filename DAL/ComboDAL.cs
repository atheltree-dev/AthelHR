using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace DAL
{

   public class ComboDAL:CommonDB
    {
       public List<ComboDL> FillGeneralComboAll(string FldId1, string FldName1, string TblName, string Strwhere)
       {
           StackFrame stackFrame = new StackFrame();
           MethodBase methodBase = stackFrame.GetMethod();

           List<ComboDL> objectList = new List<ComboDL>(); ;
           try{
           
           OpenEntityConnection();
           Strwhere = ( Strwhere.Trim().Length == 0 ? "@" : Strwhere);
              //var para1 = new SqlParameter("@FldIdName",FldId1);
              // var para2 = new SqlParameter("@FldName", FldName1);
              // var para3 = new SqlParameter("@TblName", TblName);
              // var para4 = new SqlParameter("@Strwhere", Strwhere);
              // object[] param = { para1, para2, para3, para4 };

               object[] param1 = { 
               new SqlParameter("@FldIdName",FldId1),
               new SqlParameter("@FldName", FldName1),
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


               var objlist = objPharmaEntities.Database.SqlQuery<ComboDL>("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1).ToList();

               //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);

               if (objlist != null)
               {
                   foreach (var obj in objlist)
                   {
                       ComboDL objCombDL = new ComboDL();
                       objCombDL.Id = Convert.ToString(obj.Id);
                       objCombDL.Name = obj.Name;
                       objectList.Add(objCombDL);

                   }
               }

          
           }
           catch (Exception ex)
           {
               catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
               objectList = null;
               throw ex;

           }
           finally
           {
               CloseEntityConnection();
           }

           return objectList;
       }

       public List<ComboDL> FillGeneralComboAllWithOutCondtion(string FldId1, string FldName1, string TblName, string Strwhere)
       {
           StackFrame stackFrame = new StackFrame();
           MethodBase methodBase = stackFrame.GetMethod();

           List<ComboDL> objectList = new List<ComboDL>(); ;
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
               new SqlParameter("@FldName", FldName1),
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


               var objlist = objPharmaEntities.Database.SqlQuery<ComboDL>("exec dbo.SP_GeneralAnyComboWithOutResStatus @FldIdName,@FldName,@TblName,@Strwhere", param1).ToList();

               //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);

               if (objlist != null)
               {
                   foreach (var obj in objlist)
                   {
                       ComboDL objCombDL = new ComboDL();
                       objCombDL.Id = Convert.ToString(obj.Id);
                       objCombDL.Name = obj.Name;
                       objectList.Add(objCombDL);

                   }

               }

           }
           catch (Exception ex)
           {
               catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
               objectList = null;
               throw ex;

           }
           finally
           {
               CloseEntityConnection();
           }

           return objectList;
       }

       public List<EmpRptDL> FillEmployeeBySerialAndRole(string Company_Id, string Branch_Id, decimal EmpSerialNo)
       {
           StackFrame stackFrame = new StackFrame();
           MethodBase methodBase = stackFrame.GetMethod();

           List<EmpRptDL> objectList = new List<EmpRptDL>(); ;
           try
           {

               OpenEntityConnection();
               
               
               object[] param1 = { 
               new SqlParameter("@Company_Id",Company_Id),
               new SqlParameter("@Branch_Id", Branch_Id),
                 new SqlParameter("@EmpSerialNo", EmpSerialNo)};

               //               object[] params = {
               //                new SqlParameter("@ParametterWithNummvalue", DBNull.Value),
               //                new SqlParameter("@In_Parameter", "Value"),
               //                new SqlParameter("@Out_Parameter", SqlDbType.INT) 
               //{Direction = ParameterDirection.Output}};

               //            YourDbContext.Database.ExecuteSqlCommand("exec StoreProcedure_Name @ParametterWithNummvalue, @In_Parameter, @Out_Parameter", params);
               //            YourDbContext.SaveChanges();

               //Var ReturnValue = ((SqlParameter)params[2]).Value


               var objlist = objPharmaEntities.Database.SqlQuery<EmpRptDL>("exec dbo._SpFillEmployeeBySerialAndRole @Company_Id,@Branch_Id,@EmpSerialNo", param1).ToList();

               //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);

               if (objlist != null)
               {
                   foreach (var obj in objlist)
                   {
                       EmpRptDL objCombDL = new EmpRptDL();
                       objCombDL.Id = Convert.ToString(obj.Id);
                       objCombDL.Name = obj.Name;
                       objCombDL.FullNameArabic = obj.FullNameArabic;
                       objectList.Add(objCombDL);

                   }
               }


           }
           catch (Exception ex)
           {
               catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
               objectList = null;
               throw ex;

           }
           finally
           {
               CloseEntityConnection();
           }

           return objectList;
       }


       public List<EmpRptDL> FillEmployeeBySerialAndRoleWithShow(string Company_Id, string Branch_Id, decimal EmpSerialNo)
       {
           StackFrame stackFrame = new StackFrame();
           MethodBase methodBase = stackFrame.GetMethod();

           List<EmpRptDL> objectList = new List<EmpRptDL>(); ;
           try
           {

               OpenEntityConnection();


               object[] param1 = { 
               new SqlParameter("@Company_Id",Company_Id),
               new SqlParameter("@Branch_Id", Branch_Id),
                 new SqlParameter("@EmpSerialNo", EmpSerialNo)};

               //               object[] params = {
               //                new SqlParameter("@ParametterWithNummvalue", DBNull.Value),
               //                new SqlParameter("@In_Parameter", "Value"),
               //                new SqlParameter("@Out_Parameter", SqlDbType.INT) 
               //{Direction = ParameterDirection.Output}};

               //            YourDbContext.Database.ExecuteSqlCommand("exec StoreProcedure_Name @ParametterWithNummvalue, @In_Parameter, @Out_Parameter", params);
               //            YourDbContext.SaveChanges();

               //Var ReturnValue = ((SqlParameter)params[2]).Value


               var objlist = objPharmaEntities.Database.SqlQuery<EmpRptDL>("exec dbo._SpFillEmployeeBySerialAndRoleWithShow @Company_Id,@Branch_Id,@EmpSerialNo", param1).ToList();

               //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);

               if (objlist != null)
               {
                   foreach (var obj in objlist)
                   {
                       EmpRptDL objCombDL = new EmpRptDL();
                       objCombDL.Id = Convert.ToString(obj.Id);
                       objCombDL.Name = obj.Name;
                       objCombDL.FullNameArabic = obj.FullNameArabic;
                       objectList.Add(objCombDL);

                   }
               }


           }
           catch (Exception ex)
           {
               catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
               objectList = null;
               throw ex;

           }
           finally
           {
               CloseEntityConnection();
           }

           return objectList;
       }


       public List<EmpRptDL> FillEmployeeBySerialAndRoleWithPara(string Company_Id, string Branch_Id, decimal EmpSerialNo, string wherestr)
       {
           StackFrame stackFrame = new StackFrame();
           MethodBase methodBase = stackFrame.GetMethod();

           List<EmpRptDL> objectList = new List<EmpRptDL>(); ;
           try
           {

               OpenEntityConnection();


               object[] param1 = { 
               new SqlParameter("@Company_Id",Company_Id),
               new SqlParameter("@Branch_Id", Branch_Id),
               new SqlParameter("@EmpSerialNo", EmpSerialNo),
               new SqlParameter("@wherestr", wherestr) };

               var objlist = objPharmaEntities.Database.SqlQuery<EmpRptDL>("exec dbo._SpFillEmployeeBySerialAndRoleWithPara @Company_Id,@Branch_Id,@EmpSerialNo,@wherestr", param1).ToList();

               if (objlist != null)
               {
                   foreach (var obj in objlist)
                   {
                       EmpRptDL objCombDL = new EmpRptDL();
                       objCombDL.Id = Convert.ToString(obj.Id);
                       objCombDL.Name = obj.Name;
                       objCombDL.FullNameArabic = obj.FullNameArabic;
                       objectList.Add(objCombDL);

                   }
               }


           }
           catch (Exception ex)
           {
               catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
               objectList = null;
               throw ex;

           }
           finally
           {
               CloseEntityConnection();
           }

           return objectList;
       }





    }
}
