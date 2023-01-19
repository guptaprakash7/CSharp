using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class OptionalParameterDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();

            }
        }

        protected void btnSerach_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            string cs = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            try
            {
                SqlCommand sql = new SqlCommand("spSearchEmployees", con);
                sql.CommandType = System.Data.CommandType.StoredProcedure;

                AttachParameter(sql, "@Name", txtName);
                AttachParameter(sql, "@Email", txtEmail);
                AttachParameter(sql, "@Age", txtAge);
                AttachParameter(sql, "@Gender", ddlGender);
                con.Open();
                gvEmployees.DataSource = sql.ExecuteReader();
                gvEmployees.DataBind();

            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }


        private void AttachParameter(SqlCommand command, string parameterName, Control control)
        {
            if (control is TextBox && ((TextBox)control).Text != string.Empty)
            {
                SqlParameter parameter = new SqlParameter(parameterName, ((TextBox)control).Text);
                command.Parameters.Add(parameter);
            }
            else if (control is DropDownList && ((DropDownList)control).SelectedValue != "-1")
            {
                SqlParameter parameter = new SqlParameter (parameterName, ((DropDownList)control).SelectedValue);
                command.Parameters.Add(parameter);
            }
        }
    }
}
