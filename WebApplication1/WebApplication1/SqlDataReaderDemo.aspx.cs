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
    public partial class SqlDataReaderDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;

            try
            {
                string sqlCommand = "SELECT * FROM [dbo].vwPersonList";
                SqlCommand cmd = new SqlCommand(sqlCommand, sqlConnection);
                sqlConnection.Open();
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add("Name");
                dt.Columns.Add("Gender");
                dt.Columns.Add("Discount");
                int discount = 10;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dr = dt.NewRow();
                        dr["Name"] = reader["Name"];
                        dr["Gender"] = reader["Gender"];
                        dr["Discount"] = discount;
                        dt.Rows.Add(dr);
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
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