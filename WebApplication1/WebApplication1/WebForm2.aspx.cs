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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                SqlCommand sql = new SqlCommand("SELECT Name, Gender, Email FROM [dbo].[vwPersonList]; SELECT * FROM tblEmployee;", sqlConnection);
                sqlConnection.Open();

                using(SqlDataReader rdr = sql.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    if (rdr.NextResult())
                    {
                        GridView2.DataSource = rdr;
                        GridView2.DataBind();
                    }
                }               
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}