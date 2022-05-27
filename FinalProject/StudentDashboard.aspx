<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDashboard.aspx.cs" Inherits="FinalProject.StudentDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Student Dashboard</title>
    <link href="CSS/bootstrap.css" rel="stylesheet" />
    <link href="CSS/animate.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/background.jpg)">
   
    Welcome:<asp:Label ID="lblUsername" runat ="server"></asp:Label><br />
     <br /><br />
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="offset-3 col-lg-6" style="text-align:center;background-color:brown;">
                   <br />
                    <h1 style="color:yellow; text-align:center"><b><u>SELECT MENU : STUDENT</u></b></h1><br />
                    <a class="btn btn-dark"  style="width:90%" download href="Brochure/Unisoft Technologies.jpg">DOWNLOAD BROCHURE</a><br /><br />
                    <a class="btn btn-dark" href="frmNoticeboard.aspx"  style="width:90%">LATEST NOTICE</a><br /><br />
                    <a class="btn btn-dark"  href="frmBlogofadmin.aspx" style="width:90%">LATEST ADMIN BLOG</a><br /><br />
                    <a class="btn btn-dark"  href="frmPostdoubt.aspx" style="width:90%">ASK YOUR DOUBT</a><br /><br />
                    <a class="btn btn-dark" href="frmChangepassword.aspx" style="width:90%">CHANGE PASSWORD</a><br /><br />
                    

                    <asp:Button ID="btnLogout" runat="server" Text="Logout" class="btn btn-danger" style="width:150px" OnClick="btnLogout_Click" OnClientClick="return confirm ('Are you sure?');" /><br />
                    <br />
                </div>
            </div>

        </div>
   
    </form>
</body>
</html>
