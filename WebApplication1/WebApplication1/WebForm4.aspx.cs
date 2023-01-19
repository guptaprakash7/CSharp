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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                SqlCommand sql = new SqlCommand("INSERT INTO tblPerson(Name, GenderId, Email)VALUES('Soumya', 2, 'Soumya@gmail.com')", sqlConnection);
                sqlConnection.Open();
                int totalRowAffected = sql.ExecuteNonQuery();
                Response.Write($"total rows inserted {totalRowAffected}");
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}