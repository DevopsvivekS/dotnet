<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmIndex.aspx.cs" Inherits="FinalProject.frmIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Management System: Unisoft</title>
    <link href="CSS/animate.css" rel="stylesheet" />
    <link href="CSS/bootstrap.css" rel="stylesheet" />
</head>
    <br /><h1 style="color:black; text-align:center"><b>ORAGANIZATION CONTROL & MARKETING SYSTEM</b></h1>
<body style="background-image:url(Images/background.jpg)">
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class ="row">
             <div class="offset-4 col-lg-4 rounded" style="background-color:brown ; text-align:center ; margin-top:120px"><br />
            <h2 class="infinite animated flash" style="color:yellow"><b>ENTER LOGIN CREDENTIALS</b></h2><br />
                <asp:TextBox ID="txtUsername" runat="server" Class="rounded" style="width:90%" placeholder="Enter Username" required ></asp:TextBox><br /><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email ID required" ControlToValidate="txtUsername" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="White"></asp:RegularExpressionValidator><br /><br />
                <asp:TextBox ID="txtPassword" runat="server" Class="rounded" style="width:90%" placeholder="Enter password" TextMode="Password" required ></asp:TextBox><br /><br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is Compulsory" ForeColor="White" ></asp:RequiredFieldValidator><br />
                <br />

                <asp:Button ID="btnLogin" runat="server" Text="Login" Class="btn btn-success" style="width:30%" OnClick="btnLogin_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" Class="btn btn-warning" style="width:30%" OnClick="btnReset_Click"/><br /><br />
             </div>


        </div>
    
    </div>
    </form>
</body>
</html>