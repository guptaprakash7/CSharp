using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1
{
    public partial class CommandBuilder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            SqlConnection sql = new SqlConnection(conn);
            string sqlQuery = "SELECT * FROM [dbo].[tblStudents] WHERE ID = " + txtStudentID.Text;
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlQuery, sql);

            DataSet ds = new DataSet();
            sqlData.Fill(ds, "Students");

            ViewState["SQL_QUERY"] = sqlQuery;
            ViewState["DATASET"] = ds;

            if (ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr =  ds.Tables["Students"].Rows[0];
                txtStudentName.Text = dr["Name"].ToString();
                txtTotalMarks.Text = dr["TotalMarks"].ToString();
                ddlGender.SelectedValue = dr["Gender"].ToString();

            }
            else 
            {
                lblStatus.Text = $"No student record with ID = {txtStudentID.Text}";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            SqlConnection sql = new SqlConnection(conn);
            SqlDataAdapter sqlData = new SqlDataAdapter(ViewState["SQL_QUERY"].ToString(), sql);

            SqlCommandBuilder builder = new SqlCommandBuilder(sqlData);
            DataSet ds = (DataSet)ViewState["DATASET"];
            if (ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["Students"].Rows[0];
                dr["Name"] = txtStudentName.Text;
                dr["Gender"] = ddlGender.SelectedValue;
                dr["TotalMarks"] = txtTotalMarks.Text;
                //dr["Id"] = txtStudentID.Text;
            }
           
            int rowsUpdated = sqlData.Update(ds, "Students"); 

            if(rowsUpdated > 0)
            {
                lblStatus.Text = $"{rowsUpdated} row(s) updated";
            }
            else
            {
                lblStatus.Text = "No rows updated";
            }
            lblStatus.Text = builder.GetUpdateCommand().CommandText;
        }
    }
}