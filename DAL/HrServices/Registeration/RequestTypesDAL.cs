using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Data.Entity.Validation;


namespace DAL.HrServices.Registeration
{
  public  class RequestTypesDAL:CommonDB

    {
      public bool AddNewDataWithDtls(Hr_RequestTypes ObjHdrDL, List<Hr_RequestTypesDtls> ListDtls)
      {
          StackFrame stackFrame = new StackFrame();
          MethodBase methodBase = stackFrame.GetMethod();

          var strErrorMessage = string.Empty;
          //  ObjWorkFlow_HdrDL.InsUser = "5";
          ObjHdrDL.InsDate = DateTime.Now;
          // ObjCommTransHeaderDL.InsDate = DateTime.Now.ToString("dd/MM/yyyy");
          bool result = true;

          using (System.Data.Entity.DbContextTransaction dbTran = objPharmaEntities.Database.BeginTransaction())
          {
              try
              {
                  if (objPharmaEntities.Database.Connection.State == System.Data.ConnectionState.Closed)
                  {
                      objPharmaEntities.Database.Connection.Open();
                  }


                  Hr_RequestTypes loclHdr = new Hr_RequestTypes
                  {
                      Request_Id = ObjHdrDL.Request_Id,
                      Request_Name = ObjHdrDL.Request_Name,
                      Request_NameEn = ObjHdrDL.Request_NameEn,
                      AttachIsNecessary = ObjHdrDL.AttachIsNecessary,
                      RequestType = ObjHdrDL.RequestType,
                      VactionIndivisible = ObjHdrDL.VactionIndivisible,
                      SendOnlyToManger = ObjHdrDL.SendOnlyToManger,
                      InsUser = ObjHdrDL.InsUser,
                      InsDate = ObjHdrDL.InsDate
                  };
                  
                  objPharmaEntities.Hr_RequestTypes.Add(loclHdr);
                  //saves all above operations within one transaction
                  objPharmaEntities.SaveChanges();

               

                  foreach (Hr_RequestTypesDtls Obj_Dtls in ListDtls)
                  {
                      if (Obj_Dtls != null)
                      {
                          Hr_RequestTypesDtls loclDtls = new Hr_RequestTypesDtls
                          {

                              RequestTypeId = loclHdr.Request_Id,
                              RequestDiscountType = Obj_Dtls.RequestDiscountType,
                              RequestTypeValue = Obj_Dtls.RequestTypeValue,
                              RequestRatioValue = Obj_Dtls.RequestRatioValue,
                          };
                          objPharmaEntities.Hr_RequestTypesDtls.Add(loclDtls);
                          //saves all above operations within one transaction
                          objPharmaEntities.SaveChanges();
                      }
                  }


                  //commit transaction
                  dbTran.Commit();
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
                  strErrorMessage = fullErrorMessage;
                  // Throw a new DbEntityValidationException with the improved exception message.
                  throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                  //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage
                  dbTran.Rollback();
                  result = false;

              }

              catch (Exception ex)
              {

                  //Rollback transaction if exception occurs
                  dbTran.Rollback();
                  result = false;


              }



              finally
              {
                  objPharmaEntities.Database.Connection.Close();
                  dbTran.Dispose();

                  if (!string.IsNullOrEmpty(strErrorMessage))
                  {
                      SaveErrorLog(System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(), strErrorMessage, this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());



                  }
              }
              return result;

          }
      }

        public  async Task<int> Insert(Hr_RequestTypes  objInsert) 
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int RowEffected = 0;
            try
            {
                if (objInsert != null)
                {
                    OpenEntityConnection();
                    objInsert.InsDate = DateTime.Now;//DateTime.Today;
                    
                    
                    objPharmaEntities.Hr_RequestTypes.Add(objInsert);
                    RowEffected = await objPharmaEntities.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                RowEffected = -1;
                ex.InnerException.Message.ToString();


            }
            finally 
            {
                CloseEntityConnection();
            }
            return RowEffected;   
        }
        // Calling the method of using Async
        //public  int test() {
        //    int task =  Insert().Result;
        //    return task;
         
        //}
        public int InsertTask(Hr_RequestTypes objInsert)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            //int result = Insert(objInsert).Result;
            //return result;

            int RowEffected = 0;
            try
            {
                if (objInsert != null)
                {
                    OpenEntityConnection();
                    objInsert.InsDate = DateTime.Now;//DateTime.Today;


                    objPharmaEntities.Hr_RequestTypes.Add(objInsert);
                    RowEffected =  objPharmaEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                RowEffected = -1;
                ex.InnerException.Message.ToString();


            }
            finally
            {
                CloseEntityConnection();
            }
            return RowEffected;


        }

        public async Task<bool> Update(Hr_RequestTypes objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_RequestTypes ObjForUpdate = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                            where objLinq.Request_Id == objUpdate.Request_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.Request_Name = objUpdate.Request_Name;
                    ObjForUpdate.Request_NameEn = objUpdate.Request_NameEn;
                    ObjForUpdate.RequestType = objUpdate.RequestType;
                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;
                    

                    rowEffected = await objPharmaEntities.SaveChangesAsync() ;
                }
                
            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }
        public bool UpdateTask(Hr_RequestTypes objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

           // bool task = Update(objInsert).Result;
            //return task;
            int rowEffected = 0;
            try
            {

                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_RequestTypes ObjForUpdate = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                            where objLinq.Request_Id == objUpdate.Request_Id
                                            && objLinq.Company_Id==objUpdate.Company_Id && objLinq.Branch_Id==objUpdate.Branch_Id
                                            select objLinq).FirstOrDefault();
                    ObjForUpdate.Request_Name = objUpdate.Request_Name;
                    ObjForUpdate.Request_NameEn = objUpdate.Request_NameEn;
                    ObjForUpdate.RequestType = objUpdate.RequestType;
                    ObjForUpdate.AttachIsNecessary = objUpdate.AttachIsNecessary;
                    ObjForUpdate.VactionIndivisible = objUpdate.VactionIndivisible;
                    ObjForUpdate.SendOnlyToManger = objUpdate.SendOnlyToManger;

                    ObjForUpdate.ChkJoinHireItem = objUpdate.ChkJoinHireItem;
                    ObjForUpdate.HireItem_Id = objUpdate.HireItem_Id;

                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;

                    rowEffected =  objPharmaEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;


        }

        public bool UpdateTaskWithOutBranch(Hr_RequestTypes objUpdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            // bool task = Update(objInsert).Result;
            //return task;
            int rowEffected = 0;
            try
            {

                if (objUpdate != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_RequestTypes ObjForUpdate = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                                    where objLinq.Request_Id == objUpdate.Request_Id
                                                   // && objLinq.Company_Id == objUpdate.Company_Id && objLinq.Branch_Id == objUpdate.Branch_Id
                                                    select objLinq).FirstOrDefault();
                    ObjForUpdate.Request_Name = objUpdate.Request_Name;
                    ObjForUpdate.Request_NameEn = objUpdate.Request_NameEn;
                    ObjForUpdate.RequestType = objUpdate.RequestType;
                    ObjForUpdate.AttachIsNecessary = objUpdate.AttachIsNecessary;
                    ObjForUpdate.VactionIndivisible = objUpdate.VactionIndivisible;
                    ObjForUpdate.SendOnlyToManger = objUpdate.SendOnlyToManger;

                    ObjForUpdate.ChkJoinHireItem = objUpdate.ChkJoinHireItem;
                    ObjForUpdate.HireItem_Id = objUpdate.HireItem_Id;

                    ObjForUpdate.UpdateUser = objUpdate.UpdateUser;
                    ObjForUpdate.UpdateDate = DateTime.Now;

                    rowEffected = objPharmaEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;


        }

        public async Task<bool> Delete(Hr_RequestTypes objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_RequestTypes objForDelete = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                            where objLinq.Request_Id == objDelete.Request_Id
                                            && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
                                            select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected = await objPharmaEntities.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public bool DeleteTask(Hr_RequestTypes objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

           // bool task = Delete(objInsert).Result;
           // return task;
            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_RequestTypes objForDelete = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                            where objLinq.Request_Id == objDelete.Request_Id
                                            && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
                                            select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected =  objPharmaEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public bool DeleteTaskWithOutBranch(Hr_RequestTypes objDelete)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            // bool task = Delete(objInsert).Result;
            // return task;
            int rowEffected = 0;
            try
            {
                if (objDelete != null) //Definsive Programming
                {
                    OpenEntityConnection();
                    Hr_RequestTypes objForDelete = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                                    where objLinq.Request_Id == objDelete.Request_Id
                                                   // && objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
                                                    select objLinq).FirstOrDefault();
                    objForDelete.Rec_Status = 1;
                    objForDelete.DeleteUser = objDelete.DeleteUser;
                    objForDelete.DeleteDate = DateTime.Now;

                    rowEffected = objPharmaEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                catchEntityvalidation((System.Data.Entity.Validation.DbEntityValidationException)ex, System.Runtime.InteropServices.Marshal.GetExceptionCode().ToString(),
                        this.UserNameProperty.ToString(), this.GetType().Name.ToString(), methodBase.Name.ToString());
                rowEffected = -1;
                ex.InnerException.Message.ToString();
            }
            finally
            {
                CloseEntityConnection();
            }
            if (rowEffected > 0)
                return true;
            else
                return false;

        }

        public Hr_RequestTypes GetById(string Request_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_RequestTypes JobsForGetEntity = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                            where objLinq.Request_Id == Request_Id && objLinq.Rec_Status == 0
                                            select objLinq).FirstOrDefault();
                return JobsForGetEntity;
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
        public Hr_RequestTypes GetByIdWithOutBranch(string Request_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();
                Hr_RequestTypes JobsForGetEntity = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                                    where objLinq.Request_Id == Request_Id && objLinq.Rec_Status == 0
                                                    select objLinq).FirstOrDefault();
                return JobsForGetEntity;
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
        public List<Hr_RequestTypes> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_RequestTypes> objectList = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                            where objLinq.Rec_Status == 0
                                            //&& objLinq.Company_Id == objDelete.Company_Id && objLinq.Branch_Id == objDelete.Branch_Id
                                         select objLinq).ToList();
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
        public List<Hr_RequestTypes> SelectAllByCompanyAndBranch(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_RequestTypes> objectList = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                            where objLinq.Rec_Status == 0
                                            && objLinq.Company_Id == strcomapny && objLinq.Branch_Id == strbranch
                                                    select objLinq).ToList();
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

        public List<Hr_RequestTypes> SelectAll()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            try
            {
                OpenEntityConnection();

                List<Hr_RequestTypes> objectList = (from objLinq in objPharmaEntities.Hr_RequestTypes
                                                    where objLinq.Rec_Status == 0
                                                  //  && objLinq.Company_Id == strcomapny && objLinq.Branch_Id == strbranch
                                                    select objLinq).ToList();
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

        public string GetNewId(string strcomapny, string strbranch)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 Request_Id as Request_Id  from Hr_RequestTypes where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " order by replicate('0',15-len(Request_Id))+Request_Id desc";
                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
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


        public string GetHireItem(string strcomapny, string strbranch,string VarRequest_Id)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            
            string Result = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select HireItem_Id as HireItem_Id  from Hr_RequestTypes where Branch_Id=" + strbranch + " and Company_Id=" + strcomapny + " and Request_Id =" + VarRequest_Id + "";
                Result = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();

                if (Result != null)
                {
                    return Result; 

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
            return Result;
        }


        public string GetNewIdWithOutBranch()
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            string nextId = "0";
            object maxId = null;

            try
            {
                // maxId = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_Hr_Administrations_SelectMaxId");
                //maxId = (from anything in objPharmaEntities.SP_Hr_Administrations_SelectMaxId()
                //         select anything.Admin_Id).Single();
                //foreach (Hr_Administrations cs in objPharmaEntities.Hr_Administrations)
                //    maxId = cs.Admin_Id;

                OpenEntityConnection();
                string strsql;
                strsql = "select top 1 Request_Id as Request_Id  from Hr_RequestTypes  order by replicate('0',15-len(Request_Id))+Request_Id desc";
                maxId = objPharmaEntities.Database.SqlQuery<string>(strsql).FirstOrDefault<string>();
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


      



       


    }
}
