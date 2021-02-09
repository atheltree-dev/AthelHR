using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HrServices.RequestManagement;
using System.Data;
using System.Data.SqlClient;
namespace DAL.HrServices.RequestManagement
{
  public  class EditEmpBorrowRequestDAL : CommonDB

    {
       public class EmpBorrowDetailDL
      {
          public string TransItemDate { get; set; }

          public decimal HireItem_Value { get; set; }
          public string Notes { get; set; }
           

      }

       public class EmpBorrowStatusDL
       {
           public string ResultStatus { get; set; }

           public string ResultMessage { get; set; }

       }


   
        public List<EditEmpBorrowRequestDL> SelectBorrowData(decimal EmpSerial_No, string BorrowFrom, string BorrowTo)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EditEmpBorrowRequestDL> objectList = new List<EditEmpBorrowRequestDL>();

                object[] param1 = {

                new SqlParameter("@Emp_Serial_No", EmpSerial_No),
                new SqlParameter("@BorrowFrom",BorrowFrom), //(Convert.ToDateTime(BorrowFrom)).ToString("yyyyMMdd")),
                new SqlParameter("@BorrowTo",BorrowTo) //(Convert.ToDateTime(BorrowTo)).ToString("yyyyMMdd"))


             };

                var objlist = objPharmaEntities.Database.SqlQuery<EditEmpBorrowRequestDL>("exec dbo.sp_GetBorrowData @Emp_Serial_No,@BorrowFrom,@BorrowTo", param1).ToList();

                foreach (var obj in objlist)
                {
                    EditEmpBorrowRequestDL EditEmpBorrowRequestDL = new EditEmpBorrowRequestDL();
                    EditEmpBorrowRequestDL.Hdr_Id = obj.Hdr_Id;
                    EditEmpBorrowRequestDL.FullNameArabic = obj.FullNameArabic;
                    EditEmpBorrowRequestDL.FullNameEn = obj.FullNameEn;
                    EditEmpBorrowRequestDL.Borrow_Value = obj.Borrow_Value;
                    EditEmpBorrowRequestDL.Borrow_Status = obj.Borrow_Status;
                    EditEmpBorrowRequestDL.BorrowStartDate = obj.BorrowStartDate;
                    EditEmpBorrowRequestDL.EndContract = obj.EndContract;
                    objectList.Add(EditEmpBorrowRequestDL);

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


        public List<EditEmpBorrowDetailsDL> GetBorrowDetail(Guid BorrowHdr_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {


                OpenEntityConnection();


                List<EditEmpBorrowDetailsDL> objectList = new List<EditEmpBorrowDetailsDL>();

                object[] param1 = {

                new SqlParameter("@BorrowHdr_Id", BorrowHdr_Id)

             };

                var objlist = objPharmaEntities.Database.SqlQuery<EditEmpBorrowDetailsDL>("exec dbo.sp_GetBorrowDetailsData @BorrowHdr_Id", param1).ToList();

                foreach (var obj in objlist)
                {
                    EditEmpBorrowDetailsDL EditEmpBorrowDetailsDL = new EditEmpBorrowDetailsDL();
                    EditEmpBorrowDetailsDL.Dtls_Id = obj.Dtls_Id;
                    EditEmpBorrowDetailsDL.Borrow_Month_No = obj.Borrow_Month_No;
                    EditEmpBorrowDetailsDL.Borrow_Month_Status = obj.Borrow_Month_Status;
                    EditEmpBorrowDetailsDL.Borrow_Month_Value = obj.Borrow_Month_Value;
                   // EditEmpBorrowDetailsDL.Borrow_Value = obj.Borrow_Value;
                  
               //     EditEmpBorrowDetailsDL.BorrowStartDate = obj.BorrowStartDate;
                    objectList.Add(EditEmpBorrowDetailsDL);

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

        Guid maxId;
         byte MaxRowId;
        public string GetNewIdAndRow()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
          
            //  object maxId = null;

            try
            {
            

                OpenEntityConnection();

                maxId = objPharmaEntities.Database.SqlQuery<Guid>("select newid() from Hr_EmpBorrow_Dtls ").FirstOrDefault<Guid>();
                MaxRowId = objPharmaEntities.Database.SqlQuery<byte>("SELECT TOP 1 RowId from Hr_EmpBorrow_Dtls ORDER BY RowId  DESC ").FirstOrDefault<byte>();

                if (maxId != null)
                {
                    nextId = maxId.ToString();


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




        public bool SaveData(List<EditEmpBorrowDetailsDL> objList)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                GetNewIdAndRow();
                int Result = 0;
                foreach (var obj in objList)
                {
                    if (obj.Borrow_Month_Status == 6 || obj.Borrow_Month_Status == 5)
                    {
                        Hr_EmpBorrow_Dtls ObjForUpdate = (from objLinq in objPharmaEntities.Hr_EmpBorrow_Dtls
                                                          where objLinq.Dtls_Id == obj.Dtls_Id
                                                          select objLinq).FirstOrDefault();
                        if (ObjForUpdate != null && obj.Borrow_Month_Status == 6)
                        {


                            ObjForUpdate.Borrow_Month_Value = obj.Borrow_Month_Value;
                            ObjForUpdate.Borrow_Month_Status = obj.Borrow_Month_Status;
                          //  List<string>  deletion = objPharmaEntities.Database.SqlQuery<List<string>>("DELETE FROM Hr_HiringEmpDuesRequestEffect WHERE Request_Dtls_Id='"+ ObjForUpdate .Dtls_Id +"';").FirstOrDefault();
                            Result = objPharmaEntities.SaveChanges();

                          

                        }


                        if (ObjForUpdate != null && obj.Borrow_Month_Status == 5)
                        {


                            ObjForUpdate.Borrow_Month_Value = obj.Borrow_Month_Value;
                            ObjForUpdate.Borrow_Month_Status = obj.Borrow_Month_Status;
                           

                            Hr_HiringEmpDuesRequestEffect ObjForUpdateRequestEffect = (from objLinq in objPharmaEntities.Hr_HiringEmpDuesRequestEffect
                                                                          where objLinq.Request_Dtls_Id == ObjForUpdate.Dtls_Id
                                                                           select objLinq).FirstOrDefault();
                            if (ObjForUpdateRequestEffect!=null)
                            {
                                ObjForUpdateRequestEffect.HireItem_Value = obj.Borrow_Month_Value;
                            }

                            Result = objPharmaEntities.SaveChanges();
                        }


                    }

                    else if (obj.Borrow_Month_Status == 2 && obj.Dtls_Id ==Guid.Empty)
                    {
                        Hr_EmpBorrow_Dtls newobj = new Hr_EmpBorrow_Dtls();
                        newobj.Dtls_Id = maxId;
                        newobj.Borrow_Month_No = obj.Borrow_Month_No;
                        newobj.Borrow_Month_Status = obj.Borrow_Month_Status;
                        newobj.Borrow_Month_Value = obj.Borrow_Month_Value;
                        newobj.Branch_Id = obj.Branch_Id;
                        newobj.Company_Id = obj.Company_Id;
                        newobj.Hdr_Id = obj.Hdr_Id;
                        newobj.RowId =Convert.ToByte(MaxRowId + 1);


                        objPharmaEntities.Hr_EmpBorrow_Dtls.Add(newobj);
                        Result = objPharmaEntities.SaveChanges();
                        GetNewIdAndRow();
                    }
                    else
                    {

                    }
                }

                    return (Result > 0);
            }

            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                ex.InnerException.Message.ToString();
                return false;

            }
            finally
            {
                CloseEntityConnection();
            }



        }




       
    
      


    }
}
