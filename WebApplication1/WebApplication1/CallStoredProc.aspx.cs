using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CallStoredProc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                SqlCommand sql = new SqlCommand("getPersonByName", sqlConnection);
                sql.CommandType = System.Data.CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@Name", $"{TextBox1.Text}%");
                sqlConnection.Open();
				GridView1.DataSource = sql.ExecuteReader();
                GridView1.DataBind();

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