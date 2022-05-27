<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminDashboard.aspx.cs" Inherits="FinalProject.a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Dashboard</title>
    <link href="CSS/bootstrap.css" rel="stylesheet" />
    <link href="CSS/animate.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/background.jpg)">
   
    Welcome:<asp:Label ID="lblUsername" runat ="server"></asp:Label>
        
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="offset-3 col-lg-6" style="text-align:center;background-color:brown;">
                    <h2 class="infinite animated flash" style="color:yellow"><b>ADMIN DASHBOARD</b></h2><br />
                    <a class="btn btn-dark" href="frmEnquiry.aspx" style="width:90%">ENQUIRY FORM</a><br /><br />
                    <a class="btn btn-dark" href="frmAdmission.aspx" style="width:90%">STUDENT ADMISSION</a><br /><br />
                    <a class="btn btn-dark" href="frmInstallment.aspx" style="width:90%">STUDENT INSTALLMENT</a><br /><br />
                    <a class="btn btn-dark" href="frmBlog.aspx" style="width:90%">ADMIN BLOG</a><br /><br />
                    <a class="btn btn-dark" href="frmNews.aspx" style="width:90%">LATEST NEWS</a><br /><br />
                    <a class="btn btn-dark" href="frmBrochure.aspx" style="width:90%">ADMIN BROCHURE</a><br /><br />
                    <a class="btn btn-dark" href="frmSubject.aspx" style="width:90%">ADD SUBJECT</a><br /><br />
                    <a class="btn btn-dark" href="frmPassword.aspx" style="width:90%">CHANGE PASSWORD</a><br /><br />
                    <a class="btn btn-dark" href="frmDoubts.aspx" style="width:90%">STUDENT DOUBT</a><br /><br />
                    
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" class="btn btn-danger" style="width:150px" OnClick="btnLogout_Click" OnClientClick="return confirm ('Are you sure?');" /><br />
                    <br />
                </div>
            </div>

        </div>
   
    </form>
</body>
</html>