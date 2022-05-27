<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPostdoubt.aspx.cs" Inherits="FinalProject.frmPostdoubt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Post Your Doubts</title>
<link href="CSS/animate.css" rel="stylesheet" />
    <link href="CSS/bootstrap.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/background.jpg)">
    <asp:Label ID="lblUsername" runat ="server" Visible="False"></asp:Label>

    <form id="form1" runat="server" style="text-align:center">
       <br /> <h1 style="color:black"><b>ASK YOUR DOUBT</b></h1>
   <div class ="container-fluid">
        <div class ="row">
            <div class="offset-3 col-lg-6 rounded" style="background-color:brown ; text-align:center ; margin-top:120px"><br />
           
                <br /><asp:TextBox ID="txtName" runat="server" Class ="rounded" Width="600px" placeholder ="Enter Full Name"  BackColor="#CCCCCC"></asp:TextBox>
                <br /><br /><asp:TextBox ID="txtDoubt" runat="server" Width="600px" Height="100px" Class ="rounded" placeholder ="Write Your Doubt (Max.100)" required="true" TextMode="MultiLine" MaxLength="100"></asp:TextBox>&nbsp&nbsp
                
                <br /><br />
                <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" style="width:150px" OnClick="Button1_Click" />&nbsp&nbsp
                <asp:Button ID="btnLogout" class="btn btn-danger" runat="server" Text="Logout" style="width:150px" OnClientClick="return confirm ('Are you sure?');" OnClick="btnLogout_Click"/>&nbsp&nbsp
                <a class="btn btn-dark" href="StudentDashboard.aspx" style="width:150px">Dashboard</a>&nbsp&nbsp
                <br /><br />

            </div>
    </div>
    </div>
    </form>
</body>
</html>
