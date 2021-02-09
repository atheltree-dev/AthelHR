using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

using BOL;

namespace DAL.HrServices.Notification
{
    public class EmpVaildRequestDelayResultDAL : CommonDB

    {
        public MessageResultDL ChkVaildRequestDelayDate(string Company_Id, string Branch_Id,string transdate)
        {
            StackFrame stackFrame = new StackFrame();
            MethodBase methodBase = stackFrame.GetMethod();

            MessageResultDL objectList = new MessageResultDL(); ;
            try
            {

                OpenEntityConnection();

                

                object[] param1 = { 
                    new SqlParameter("@Company_Id",Company_Id),               
                    new SqlParameter("@Branch_Id", Branch_Id),
                    new SqlParameter("@Transdate", transdate)};


                var objlist = objPharmaEntities.Database.SqlQuery<MessageResultDL>("exec dbo._SPChkVaildRequestDelayDate @Company_Id,@Branch_Id,@Transdate", param1).FirstOrDefault();

                

                if (objlist != null)
                {
                    objectList.MessageType = objlist.MessageType;
                    objectList.Message = objlist.Message;
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
