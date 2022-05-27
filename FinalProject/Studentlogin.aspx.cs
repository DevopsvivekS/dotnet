using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FinalProject
{
    public partial class Studentlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            //SqlConnection cmd = new SqlConnection("Select= DESKTOP-RDIF7Q9; Initial Catalog= db_Unisoft;integrated security=true;");
            SqlCommand cmd = new SqlCommand("Select * from tbl_login WHERE Username=@username AND Password=@password", con);
            Session["username1"] = txtUsername.Text; //Creating Session for user
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(); // use to fetch record from database table
            if (dr.HasRows) //dr.HasRows means 'do we find what we need?'
            {
                dr.Read();
                Response.Redirect("StudentDashboard.aspx"); //open this form if input data is correct
            }
            else
            {
                con.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert ('Invalid Username or Password'); ", true);
                return;
            }
        }

    }
}