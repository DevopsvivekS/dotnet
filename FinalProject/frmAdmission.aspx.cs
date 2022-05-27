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
    public partial class frmAdmission : System.Web.UI.Page
    {
        public static int a;
        public static int b;
        protected void Page_Load(object sender, EventArgs e)
        {

            txtRemaining.Text = String.Empty;
            if (Session["username1"] != null)
            {
                lblUsername.Text = Session["username1"].ToString();
            }
            else
            {
                Response.Redirect("frmAdmission.aspx");
            }

            if (!IsPostBack)
            {
                {

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter("Select distinct subject , Fees from tbl_Subject", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ddlSubject.DataSource = ds;
                    ddlSubject.DataTextField = "Subject";
                    ddlSubject.DataBind();
                    ddlSubject.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---- Select Subject ----", "-1"));

                    con.Close();


                    
            //SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            //SqlCommand cmd2 = new SqlCommand("Select Fees from tbl_Subject where Fees = @Fees", con2);
            //cmd2.CommandType = CommandType.Text;
            //cmd2.Parameters.AddWithValue("@Fees", Session["username1"].ToString());
            //con2.Open();
            //SqlDataReader dr = cmd2.ExecuteReader();
            //if (dr.Read()) //dr.HasRows means 'do we find what we need?'
            //{
            //    txtTotalfee.Text = dr[0].ToString();
            //}
            //con.Close();

        
                }
                if (!IsPostBack)
                {

                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    SqlDataAdapter sda1 = new SqlDataAdapter("Select  Email_Id from tbl_Admission", con1);
                    con1.Open();
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1);
                    grvAdmission.DataSource = ds1;
                    grvAdmission.DataBind();
                    con1.Close();
                }

                
            }

           
            if (!IsPostBack)
            {
                txtAddmissiondate.Text = System.DateTime.Now.ToShortDateString();
                SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                SqlCommand cmd2 = new SqlCommand("Select FirstName, MiddleName, LastName, Email_Id, Mobile_No, Subject, Total_Fees, Amt_Paid, Remaining_Amt, Admission_Date, Next_Installment_Date, Username, FullName from tbl_Admission", con2);
                con2.Open();
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                sda2.Fill(ds2);
                grvAdmission.DataSource = ds2;
                grvAdmission.DataBind();
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
            SqlCommand cmd = new SqlCommand("Insert into tbl_Admission values(@FirstName, @MiddleName, @LastName, @Email_Id, @Mobile_No, @Subject, @Total_Fees, @Amt_Paid, @Remaining_Amt, @Admission_Date, @Next_Installment_Date, @Username, @Password, @FullName)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FirstName", txtFirst.Text);
            cmd.Parameters.AddWithValue("@MiddleName", txtMiddle.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLast.Text);
            cmd.Parameters.AddWithValue("@Email_Id", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Mobile_No", txtMobile.Text);
            cmd.Parameters.AddWithValue("@Subject", ddlSubject.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Total_Fees", txtTotalfee.Text);
            cmd.Parameters.AddWithValue("@Amt_Paid", txtAmountpaid.Text);
            cmd.Parameters.AddWithValue("@Remaining_Amt", txtRemaining.Text);
            cmd.Parameters.AddWithValue("@Admission_Date", txtAddmissiondate.Text);
            cmd.Parameters.AddWithValue("@Next_Installment_Date", DateTime.Now.AddMonths(1).ToShortDateString());
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@FullName", txtFirst.Text + ' ' + txtMiddle.Text + ' ' + txtLast.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            //mail();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("unisoftvns@gmail.com");
            mail.To.Add(txtEmail.Text);
            mail.Subject = "Admission Details";
            mail.Body = "Dear " + txtFirst.Text + "," + "\nYou have registered for subject: " + ddlSubject.Text + "\nFollowing are your login credentials:" + "\nUsername: " + txtUsername.Text + "\nPassword: " + txtPassword.Text + "\nTotal fees of your course: " + txtTotalfee.Text + "\nNow you are paying: " + txtAmountpaid.Text + "\nRemaining fees: " + txtRemaining.Text + "\nNext Installment Date:" + DateTime.Now.AddMonths(1).ToShortDateString() + "\n\nRegards, \nUnisoft Technologies";
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.Credentials = new System.Net.NetworkCredential("unisoftvns@gmail.com", "Unisoft@123");
            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Message Sent');location.href = 'frmAdmission.aspx';", true);

            //public void mail()
            //{

            //    MailMessage mail = new MailMessage();
            //    mail.From = new MailAddress("unisoftvns@gmail.com");
            //    mail.To.Add(txtEmail.Text);
            //    mail.Subject = "Test Mail";
            //    mail.Body = "Dear "+txtFirst+"You have registered for subject: "+ddlSubject+ "";
            //    SmtpClient SmtpServer = new SmtpClient();
            //    SmtpServer.Host = "smtp.gmail.com";
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("unisoftvns@gmail.com", "Unisoft@123");
            //    SmtpServer.Port = 587;
            //    SmtpServer.EnableSsl = true;
            //    SmtpServer.Send(mail);
            //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Message Sent');location.href = 'frmEnquiry.aspx';", true);
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Data Sumitted Sucessfully');location.href = 'frmEnquiry.aspx';", true);

            //}
            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select Image To Change');", true);
                return;
            }
            if (FileUpload1.HasFile)
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                int height = img.Height;
                int width = img.Width;
                decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);
                if (size > 500)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Image File Size Must Not Exceed 500 KB.');", true);
                    return;
                }
                //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                string filename = txtEmail.Text.ToUpper() + ".jpg";//ToUpper() is use to save file name in upper case font
                FileUpload1.PostedFile.SaveAs(Server.MapPath("StudentPhoto/") + filename);// file name from text box
                //FileUpload1.PostedFile.SaveAs(Server.MapPath("StudentPhoto/Unisoft Technologies.jpg"));//for hard value
                //Response.Redirect(Request.Url.AbsoluteUri);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Sumitted Sucessfully');", true);

            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = txtEmail.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select Email_Id from tbl_Admission WHERE Email_Id=@Email_Id", con);
            Session["username1"] = txtUsername.Text; //Creating Session for user
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Email_Id", txtEmail.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows) //dr.HasRows means 'do we find what we need?'
            {
                Response.Write("<script>alert('Email ID is already exist')</script>");
            }
            con.Close();
        }

        protected void txtRemaining_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtAmountpaid_TextChanged(object sender, EventArgs e)
        {
            if (b > a)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Please enter value less than Totalfee');location.href = 'frmAdmission.aspx';", true);

            }
            a = Convert.ToInt32(txtTotalfee.Text);
            b = Convert.ToInt32(txtAmountpaid.Text);

            txtRemaining.Text = (a - b).ToString();


        }

        protected void txtAddmissiondate_TextChanged(object sender, EventArgs e)
        {
            //txtInstallmentdate.Text = System.DateTime.Now.AddMonths(1).ToShortDateString();
        }

        protected void grvAdmission_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string Email_Id = grvAdmission.Rows[rowindex].Cells[4].Text;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("delete from tbl_Admission WHERE Email_Id=@Email_Id", con);
            cmd.Parameters.AddWithValue("@Email_Id", Email_Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Record Deleted');location.href = 'frmAdmission.aspx';", true);


        }

        protected void txtTotalfee_TextChanged(object sender, EventArgs e)
        {



     

      

           
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd2 = new SqlCommand("Select * from tbl_Subject where Subject = @Subject", con2);
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.AddWithValue("@Subject", ddlSubject.SelectedItem.Text);
            con2.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read()) //dr.HasRows means 'do we find what we need?'
            {
                txtTotalfee.Text = dr[2].ToString();
            }
            con2.Close();

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

        }

    }
}

       