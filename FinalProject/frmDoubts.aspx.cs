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
    public partial class frmDoubts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username1"] != null)
            {
                lblUsername.Text = Session["username1"].ToString();
            }
            else
            {
                Response.Redirect("frmDoubt.aspx");
            }


            if (!IsPostBack)
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                SqlDataAdapter sda1 = new SqlDataAdapter("Select  FullName from tbl_Doubt", con1);
                con1.Open();
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1);
                grvDoubt.DataSource = ds1;
                grvDoubt.DataBind();
                con1.Close();
            }


            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Select FullName, Doubt from tbl_Doubt", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                grvDoubt.DataSource = ds;
                grvDoubt.DataBind();
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
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string FullName = grvDoubt.Rows[rowindex].Cells[1].Text;


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("delete from tbl_Doubt WHERE FullName=@FullName", con);
            cmd.Parameters.AddWithValue("@FullName", FullName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Record Deleted');location.href = 'frmDoubts.aspx';", true);
   

        }
    }
}