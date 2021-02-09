using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using BOL.HrServices.Registeration;
namespace DAL.HrServices.Registeration
{
    public class AssignWorkFlowRequestDAL : CommonDB

    {
        
      


      

       

      
        public List<AssignWorkFlowToRequestDL> GetAll()
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                List<AssignWorkFlowToRequestDL> objectList = new List<AssignWorkFlowToRequestDL>();

                var objlist = objPharmaEntities.Database.SqlQuery<AssignWorkFlowToRequestDL>("exec dbo._SPAssignWorkFlowToRequest").ToList();

                //var objlist = objPharmaEntities.Database.ExecuteSqlCommand("exec dbo.SP_GeneralAnyCombo @FldIdName,@FldName,@TblName,@Strwhere", param1);


                foreach (var obj in objlist)
                {
                    AssignWorkFlowToRequestDL objAssignWorkFlowToRequestDL = new AssignWorkFlowToRequestDL();
                    objAssignWorkFlowToRequestDL.Request_Id = obj.Request_Id;
                    objAssignWorkFlowToRequestDL.Request_Name = obj.Request_Name;
                    objAssignWorkFlowToRequestDL.Request_NameEn = obj.Request_NameEn;
                    objAssignWorkFlowToRequestDL.WorkFlow_Id = obj.WorkFlow_Id;
                    objAssignWorkFlowToRequestDL.WorkFlow_Name = obj.WorkFlow_Name;
                    objAssignWorkFlowToRequestDL.WorkFlow_NameEn = obj.WorkFlow_NameEn;
                    objAssignWorkFlowToRequestDL.status = obj.status;
                    objectList.Add(objAssignWorkFlowToRequestDL);

                }

                
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



        public bool SaveData(List<AssignWorkFlowToRequestDL> objList)
        {

            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();


            try
            {
                OpenEntityConnection();

                int Result = 0 ;
                foreach (var obj in objList)
                {
                    if (obj.status == 0 && obj.WorkFlow_Id != "-1")
                    {
                        Hr_AssignWorkFlowToRequest newobj = new Hr_AssignWorkFlowToRequest();
                        newobj.Request_Id = obj.Request_Id;
                        newobj.WorkFlow_Id = obj.WorkFlow_Id;
                        objPharmaEntities.Hr_AssignWorkFlowToRequest.Add(newobj);
                        Result = objPharmaEntities.SaveChanges();

                    }
                    else 
                    {
                        Hr_AssignWorkFlowToRequest ObjForUpdate = (from objLinq in objPharmaEntities.Hr_AssignWorkFlowToRequest
                                                                   where objLinq.Request_Id == obj.Request_Id
                                                                   select objLinq).FirstOrDefault();
                        ObjForUpdate.WorkFlow_Id = obj.WorkFlow_Id;


                        Result = objPharmaEntities.SaveChanges();

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
