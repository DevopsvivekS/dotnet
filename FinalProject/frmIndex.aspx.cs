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
    public partial class frmIndex : System.Web.UI.Page
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
            //SqlConnection cmd = new SqlConnection("Select= LAPTOP-K7GQN2UV; Initial Catalog= db_Unisoft;integrated security=true;");

            SqlCommand cmd = new SqlCommand("Select * from tbl_login WHERE Username=@Username AND Password=@Password", con);
            Session["username1"] = txtUsername.Text; //Creating Session for user
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows) //dr.HasRows means 'do we find what we need?'
            {
                dr.Read();
                Response.Redirect("adminDashboard.aspx"); //open this form if input data is correct
            }

            else
            {
                con.Close();
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                SqlCommand cmd1 = new SqlCommand("Select * from tbl_Admission WHERE Username=@Username AND Password=@Password", con1);
                Session["username1"] = txtUsername.Text; //Creating Session for user
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd1.Parameters.AddWithValue("@Password", txtPassword.Text);
                con1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader(); // use to fetch record from database table
                if (dr1.HasRows) //dr.HasRows means 'do we find what we need?'
                {
                    dr1.Read();
                    Response.Redirect("StudentDashboard.aspx"); //open this form if input data is correct

            }


                else
                {

                    con1.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert ('Invalid Username or Password'); ", true);
                    return;
                }

            }
        }
    }
}
