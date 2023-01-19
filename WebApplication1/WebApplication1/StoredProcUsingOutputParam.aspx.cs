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
    public partial class StoredProcUsingOutputParam : System.Web.UI.Page
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
                SqlCommand sql = new SqlCommand("spAddPerson", sqlConnection);
                sql.CommandType = System.Data.CommandType.StoredProcedure;
                int genderId = Convert.ToInt32(TextBox2.Text);
                sql.Parameters.AddWithValue("@Name", $"{TextBox1.Text}");
                sql.Parameters.AddWithValue("@GenderId", genderId);
                sql.Parameters.AddWithValue("@Email", $"{TextBox3.Text}");

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@PersonId";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                sql.Parameters.Add(outputParameter);

                sqlConnection.Open();
                sql.ExecuteNonQuery();
                string personId = outputParameter.Value.ToString();

                Label4.Text = personId;
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