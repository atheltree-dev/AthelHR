using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


namespace AthelHR
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static AthelHREntities objPharmaEntities = new AthelHREntities();

        [WebMethod]
        public static dynamic GetData()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(objPharmaEntities.Database.Connection.ConnectionString);
            try
            {
                connection.Open();
                string sql = "sp_GetDataTest";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter adb = new SqlDataAdapter(command))
                {
                    adb.Fill(dt);
                }
                //    SqlDataReader dr = command.ExecuteReader();
                connection.Close();
                //ds = dr;
                string htmlData = ConvertDataTableToHTML(dt);
                return htmlData;


            }
            catch (Exception ex)
            {
                connection.Close();
                return false;

            }
        }


        public static string ConvertDataTableToHTML(DataTable dt)
        {
            //style = 'border:1px solid ;'
            string StyleHeader = "class='table table-striped table-bordered'";

            //string Style = "style ='border:1px solid ;'";
            //string WidthHeightStyle = "style ='border:1px solid;width:300px; height:50px; overflow:auto; '";
            string html = "<table " + StyleHeader + ">";
            //add header row
            html += "<thead><tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<th >" + dt.Columns[i].ColumnName + "</th>";
            html += "</tr></thead>";
            html += "<tbody>";

            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    if (j == 0 || j == 1)
                    {
                        html += "<th>" + dt.Rows[i][j].ToString() + "</th>";
                    }
                    else
                    {
                        html += "<td >" + dt.Rows[i][j].ToString() + "</td>";
                    }
                html += "</tr>";

            }
            html += "</tbody>";
            html += "</table>";
            return html;
        }
    }
}