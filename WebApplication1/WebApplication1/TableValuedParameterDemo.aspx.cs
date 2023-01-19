using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
	public partial class TableValuedParameterDemo : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		private DataTable GetEmployeeData()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("Id");
			dt.Columns.Add("Name");
			dt.Columns.Add("Gender");
			dt.Columns.Add("Salary");
			dt.Columns.Add("DeptId");

			dt.Rows.Add(txtId1.Text, txtName1.Text, txtGender1.Text, 0, 1);
			dt.Rows.Add(txtId2.Text, txtName2.Text, txtGender2.Text, 0, 1);
			dt.Rows.Add(txtId3.Text, txtName3.Text, txtGender3.Text, 0, 1);
			dt.Rows.Add(txtId4.Text, txtName4.Text, txtGender4.Text, 0, 1);
			dt.Rows.Add(txtId5.Text, txtName5.Text, txtGender5.Text, 0, 1);

			return dt;
		}
		protected void btnInsert_Click(object sender, EventArgs e)
		{
			string connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
			SqlConnection conn = new SqlConnection(connString);

			SqlCommand sql = new SqlCommand("sp_InsertIntoEmployees", conn);
			sql.CommandType = CommandType.StoredProcedure;

			SqlParameter parameter = new SqlParameter()
			{
				ParameterName = "@EmpTableVar",
				Value = GetEmployeeData()
				
			};
			sql.Parameters.Add(parameter);
			conn.Open();
			sql.ExecuteNonQuery();
			conn.Close();
		}

		protected void btnFillDummyData_Click(object sender, EventArgs e)
		{
			txtId1.Text = "6";
			txtId2.Text = "7";
			txtId3.Text = "8";
			txtId4.Text = "9";
			txtId5.Text = "10";

			txtName1.Text = "John";
			txtName2.Text = "Mike";
			txtName3.Text = "Sara";
			txtName4.Text = "Pam";
			txtName5.Text = "Todd";

			txtGender1.Text = "Male";
			txtGender2.Text = "Male";
			txtGender3.Text = "Female";
			txtGender4.Text = "Female";
			txtGender5.Text = "Male";
		}
	}
}