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
    public partial class CallStoredProcUsingDataAdaptor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            SqlConnection sql = new SqlConnection(conn);

            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Name, Gender, Email FROM [dbo].[vwPersonList]; SELECT * FROM tblEmployee;", sql);
           
            DataSet ds = new DataSet();
            sqlData.Fill(ds);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

            GridView2.DataSource = ds.Tables[1];
            GridView2.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            SqlConnection sql = new SqlConnection(conn);

            SqlDataAdapter sqlData = new SqlDataAdapter("getPersonByName", sql);
            sqlData.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("Name", TextBox1.Text);
            DataSet ds = new DataSet();
            sqlData.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
    }
}