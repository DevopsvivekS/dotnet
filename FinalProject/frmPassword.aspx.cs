using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Security.Permissions;
using System.IO;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Web.UI.WebControls.WebParts;

namespace FinalProject
{
    public partial class frmPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username1"] != null)
            {
                txtUsername.Text = Session["username1"].ToString();
            }
            else
            {
                Response.Redirect("frmPassword.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("frmIndex.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from tbl_login WHERE Username=@Username AND Password=@password", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtOldpassword.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(); // use to fetch record from database table
            if (dr.HasRows) //dr.HasRows means 'do we find what we need?'
            {
                con.Close();
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                SqlCommand cmd1 = new SqlCommand("Update tbl_login set Password= @Password Where Username = @Username", con1);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd1.Parameters.AddWithValue("@Password", txtNewpassword.Text);
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Password Changed Sucessfully');location.href = 'frmIndex.aspx';", true);
                
            }
            else
            {
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Old Password is Incorrect');location.href = 'frmPassword.aspx';", true);

            }
        }
    }
}