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
    public partial class Text : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                {

                    //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    //SqlDataAdapter sda = new SqlDataAdapter("Select distinct subject from tbl_Subject", con);
                    //con.Open();
                    //DataSet ds = new DataSet();
                    //sda.Fill(ds);
                    //ddlstatus.DataSource = ds;
                    //ddlstatus.DataTextField = "Subject";
                    //ddlstatus.DataBind();
                    //ddlstatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---- Select Subject ----", "-1"));

                    //con.Close();
                    //ddlSubject.Items.Clear();
                    //ddlSubject.Items.Add("Asp.Net");
                    //ddlSubject.Items.Add("Java");
                    //ddlSubject.Items.Add("PHP");


                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("Select FullName as 'Full Name', Mobile, Email, Subject, Feedback from tbl_Enquiry", con);
                    con.Open(); 
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    
                }
            }
        }

        
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("Insert into tbl_Test values(@Fullname, @Subject)",con );
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@Fullname", txtFullname.Text);
            //cmd.Parameters.AddWithValue("@Subject", ddlSubject.SelectedItem.Text);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Sumitted Sucessfully');location.href = 'Text.aspx';", true);

        }
        //public void mail ()
        //{
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress("unisoftvns@gmail.com");
        //    mail.To.Add(txtTest.Text);
        //    mail.Subject = "Test Mail";
        //    mail.Body = "Hi, How are you?";
        //    SmtpClient SmtpServer = new SmtpClient();
        //    SmtpServer.Host = "smtp.gmail.com";
        //    SmtpServer.Credentials = new System.Net.NetworkCredential("unisoftvns@gmail.com", "Unisoft@123");
        //    SmtpServer.Port = 587;
        //    SmtpServer.EnableSsl = true;
        //    SmtpServer.Send(mail);
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Message Sent');location.href = 'Text.aspx';", true);
        //}

    }
}