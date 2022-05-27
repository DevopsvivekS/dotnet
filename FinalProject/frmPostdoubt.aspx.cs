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
    public partial class frmPostdoubt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username1"] != null)
            {
                lblUsername.Text = Session["username1"].ToString();
            }
            else
            {
                Response.Redirect("frmPostdoubt.aspx");
            }
            //Fetch data from another table
  
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select FullName from tbl_Admission where Username = @Username", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Username", Session["username1"].ToString());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) //dr.HasRows means 'do we find what we need?'
            {
                txtName.Text = dr[0].ToString();
            }
            con.Close();

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
            SqlCommand cmd = new SqlCommand("Insert into tbl_Doubt values(@FullName, @Doubt)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FullName", txtName.Text);
            cmd.Parameters.AddWithValue("@Doubt", txtDoubt.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Doubt Posted Sucessfully');location.href = 'frmPostdoubt.aspx';", true);
        }
    }
}