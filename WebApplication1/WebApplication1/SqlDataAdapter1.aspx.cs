using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class SqlDataAdapter1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Name, Gender, Email FROM [dbo].[vwPersonList]", sqlConnection);
                DataSet ds = new DataSet();
                sqlData.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch
            {

            }
            finally
            {
            }

        }
    }
}