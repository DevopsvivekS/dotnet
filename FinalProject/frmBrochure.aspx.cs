using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class frmBrochure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username1"] != null)
            {
                lblUsername.Text = Session["username1"].ToString();
            }
            else
            {
                Response.Redirect("frmBrochure.aspx");
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

                //string filename = txtTitle.Text.ToUpper() + ".jpg";//ToUpper() is use to save file name in upper case font
                //FileUpload1.PostedFile.SaveAs(Server.MapPath("Brochure/") + filename);// file name from text box
                FileUpload1.PostedFile.SaveAs(Server.MapPath("Brochure/Unisoft Technologies.jpg"));//for hard value
                //Response.Redirect(Request.Url.AbsoluteUri);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Image Uploaded Sucessfully');", true);

            }
        }
    }
}