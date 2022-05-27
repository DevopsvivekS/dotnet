<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBrochure.aspx.cs" Inherits="FinalProject.frmBrochure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Brochure</title>
<link href="CSS/animate.css" rel="stylesheet" />
    <link href="CSS/bootstrap.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/background.jpg)">
    <asp:Label ID="lblUsername" runat ="server" Visible="False"></asp:Label>

    <form id="form1" runat="server" style="text-align:center; color: yellow">
        <div class="container-fluid">
        <div class ="row">
            <div class="offset-3 col-lg-6 rounded" style="background-color:brown ; text-align:center ; margin-top:160px"><br />
            <h1><u style="color:yellow"><b>UPLOAD BROCHURE</b></u></h1><br />
                <%--<asp:TextBox ID="txtTitle" runat="server" required="true" Class ="rounded" placeholder="File Name" style="width:60%" TextMode="SingleLine" MaxLength="30"></asp:TextBox><br />--%>
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" style ="color:white" />  

                <br /><br />
                <h6 style ="color:yellow ; text-align:center">File Max Size : 500 KB</h6>
                <br />
                <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" style="width:20%" OnClick="Button1_Click" />&nbsp&nbsp
                <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="Logout" style="width:20%" OnClientClick="return confirm ('Are you sure?');" OnClick="btnLogout_Click"/>&nbsp&nbsp
                 <a class="btn btn-dark" href="adminDashboard.aspx" style="width:20%">Dashboard</a>&nbsp&nbsp
                <br /><br />
                  </div>


        </div>
    
    </div>
    </form>
</body>
</html>
