using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                SqlCommand sql = new SqlCommand("SELECT COUNT(1) FROM [dbo].[vwPersonList]", sqlConnection);
                sqlConnection.Open();
                int totalPerson = Convert.ToInt32(sql.ExecuteScalar());
                Response.Write(totalPerson);

            }
            catch(Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}