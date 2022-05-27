<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmChangepassword.aspx.cs" Inherits="FinalProject.frmChangepassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Change Password</title>
    <link href="CSS/animate.css" rel="stylesheet" />
    <link href="CSS/bootstrap.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/background.jpg)">
    <asp:Label ID="lblUsername" runat ="server" Visible="False"></asp:Label>

    <form id="form1" runat="server" style="text-align:center; color: yellow">
        <div class="container-fluid">
        <div class ="row">
            <div class="offset-3 col-lg-6 rounded" style="background-color:brown ; text-align:center ; margin-top:160px"><br />
            <h1 style="color:yellow"><b>CHANGE PASSWORD</b></h1><br />
                <asp:TextBox ID="txtUsername" runat="server" required="true" Class ="rounded" placeholder="Username" style="width:60%"></asp:TextBox><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Username" ControlToValidate="txtUsername"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Style ="color:white"></asp:RegularExpressionValidator>
                <br />
                <asp:TextBox ID="txtOldpassword" runat="server" required="true" Class ="rounded" placeholder="Old Password" style="width:60%" TextMode="Password"></asp:TextBox><br />
                <br />
                <asp:TextBox ID="txtNewpassword" runat="server" required="true" Class ="rounded" placeholder="New Password" style="width:60%" TextMode="Password"></asp:TextBox><br />
                
                <br />
                <asp:TextBox ID="txtConfirmpassword" runat="server" required="true" Class ="rounded" placeholder="Confirm Password" style="width:60%" OnTextChanged="txtConfirmpassword_TextChanged" TextMode="Password"></asp:TextBox><br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Not Matched" ControlToCompare="txtNewpassword" ControlToValidate="txtConfirmpassword" Style ="color:white"></asp:CompareValidator>
                <br />

                <br />
                <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" style="width:30%" OnClick="Button1_Click1" />&nbsp&nbsp
                <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="Logout" style="width:30%" OnClientClick="return confirm ('Are you sure?');" OnClick="btnLogout_Click"/>&nbsp&nbsp
                 <a class="btn btn-dark" href="StudentDashboard.aspx" style="width:30%">Dashboard</a>&nbsp&nbsp
                <br /><br />
                  </div>


        </div>
    
    </div>
    </form>
</body>
</html>