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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (Cache["Data"] == null)
            {
                string connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(connString);
                try
                {
                    //string sqlCommand = $"SELECT Name, Gender, Email FROM[dbo].[vwPersonList] WHERE Name Like '{TextBox1.Text}%'";
                    string sqlCommand = $"SELECT Name, Gender, Email FROM[dbo].[vwPersonList]";
                    SqlDataAdapter sql = new SqlDataAdapter(sqlCommand, sqlConnection);
                    DataSet dataSet = new DataSet();
                    sql.Fill(dataSet);
                    sqlConnection.Open();
                    GridView1.DataSource = dataSet;
                    GridView1.DataBind();

                    Cache["Data"] = dataSet;
                    Label1.Text = "Data loaded from database";

                }
                catch (SqlException ex)
                {

                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            else
            {
                GridView1.DataSource = (DataSet)Cache["Data"];
                GridView1.DataBind();
                Label1.Text = "Data loaded from cache";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null)
            {
                Cache.Remove("Data");
                Label1.Text = "Data Set removed from the cache.";
            }
            else
            {
                Label1.Text = "There is nothing in the cache.";
            }
        }
    }
}