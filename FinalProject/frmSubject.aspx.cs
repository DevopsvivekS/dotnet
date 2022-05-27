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
    public partial class frmSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username1"] != null)
            {
                lblUsername.Text = Session["username1"].ToString();
            }
            else
            {
                Response.Redirect("frmSubject.aspx");
            }
            if (!IsPostBack)
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                SqlCommand cmd1 = new SqlCommand("Select distinct Subject from tbl_Subject", con1);
                con1.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1);
                grvSubject.DataSource = ds1;
                grvSubject.DataBind();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("frmIndex.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from tbl_Subject WHERE Subject=@Subject", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(); // use to fetch record from database table
            if (dr.HasRows) //dr.HasRows means 'do we find what we need?'
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Inserted Subject Already Existed');location.href = 'frmSubject.aspx';", true);
                
            }
            else
            {
                con.Close();
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                SqlCommand cmd1 = new SqlCommand("Insert into tbl_Subject Values(@Subject)", con1);
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("@Subject", txtSubject.Text);
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Subject Inserted Sucessfully');location.href = 'frmSubject.aspx';", true);
   
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rowindex =((GridViewRow)(sender as Control). NamingContainer).RowIndex;
            string Subject= grvSubject.Rows[rowindex].Cells[1].Text;


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
             SqlCommand cmd = new SqlCommand("delete from tbl_Subject WHERE Subject=@Subject", con);
            cmd.Parameters.AddWithValue("@Subject", Subject);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

       ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Record Deleted');location.href = 'frmSubject.aspx';", true);
   

        }
    }
}