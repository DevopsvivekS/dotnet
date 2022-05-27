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
    public partial class frmEnquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username1"] != null)
            {
                lblUsername.Text = Session["username1"].ToString();
            }
            else
            {
                Response.Redirect("frmEnquiry.aspx");
            }

            if (!IsPostBack)
            {
                {

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("Select distinct subject from tbl_Subject", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlstatus.DataSource = ds;
                    ddlstatus.DataTextField = "Subject";
                    ddlstatus.DataBind();
                    ddlstatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---- Select Subject ----", "-1"));

                    con.Close();
                    //DropDownList1.Items.Clear();
                    //DropDownList1.Items.Add("Asp.Net");
                    //DropDownList1.Items.Add("Java");
                    //DropDownList1.Items.Add("PHP");


                }

                if (!IsPostBack)
                {

                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    SqlDataAdapter sda1 = new SqlDataAdapter("Select  Email from tbl_Enquiry", con1);
                    con1.Open();
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1);
                    grvEnquiry.DataSource = ds1;
                    grvEnquiry.DataBind();
                    con1.Close();
                }


                if (!IsPostBack)
                {

                    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    SqlCommand cmd2 = new SqlCommand("Select FullName as FullName, Mobile, Email, Subject, Feedback from tbl_Enquiry", con2);
                    con2.Open();
                    SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                    DataSet ds2 = new DataSet();
                    sda2.Fill(ds2);
                    grvEnquiry.DataSource = ds2;
                    grvEnquiry.DataBind();

                }
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("frmIndex.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Insert into tbl_Enquiry values(@FullName, @Mobile, @Email, @Subject, @Feedback)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FullName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Mobile", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Subject", ddlstatus.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Feedback", TextBox4.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Sumitted Sucessfully');location.href = 'frmEnquiry.aspx';", true);

            
            mail();
            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress("unisoftvns@gmail.com");
            //mail.To.Add(TextBox3.Text);
            //mail.Subject = "Test Mail";
            //mail.Body = "Hi, How are you?";
            //SmtpClient SmtpServer = new SmtpClient();
            //SmtpServer.Host = "smtp.gmail.com";
            //SmtpServer.Credentials = new System.Net.NetworkCredential("unisoftvns@gmail.com", "Unisoft@123");
            //SmtpServer.Port = 587;
            //SmtpServer.EnableSsl = true;
            //SmtpServer.Send(mail);
        }
        public void mail()
        {
            
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("unisoftvns@gmail.com");
            mail.To.Add(TextBox3.Text);
            mail.Subject = "Enquiry";
            mail.Body = "Thank You For Contacting.";
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.Credentials = new System.Net.NetworkCredential("unisoftvns@gmail.com", "Unisoft@123");
            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Message Sent');location.href = 'frmEnquiry.aspx';", true);

        }

        protected void grvEnquiry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string Email = grvEnquiry.Rows[rowindex].Cells[3].Text;


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("delete from tbl_Enquiry WHERE Email=@Email", con);
            cmd.Parameters.AddWithValue("@Email", Email);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Record Deleted');location.href = 'frmEnquiry.aspx';", true);
   

        }
    }
}