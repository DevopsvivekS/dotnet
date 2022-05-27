<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInstallment.aspx.cs" Inherits="FinalProject.frmInstallment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Installment</title>
    <link href="CSS/animate.css" rel="stylesheet" />
    <link href="CSS/bootstrap.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/background.jpg)">
    <asp:Label ID="lblUsername" runat ="server" Visible="False"></asp:Label><br />
    <form id="form2" runat="server" style="text-align:center; color: grey">
        <h1><u  style="color:red;background-color:yellow"><b>INSTALLMENT FORM</b></u></h1>
        <div class="container">
            <div class="row">
                <div class="offset-3 col-lg-6" style="text-align:center;background-color:brown;margin-top:1%; color: #FFFFFF;"><br />
                    <asp:DropDownList ID="ddl_Name" Width="70%" runat="server" style="text-align:center; top: 0px; left: 0px;" Class ="offset-3 col-lg-6 rounded" CausesValidation="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_Name_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Name" ControlToValidate="ddl_Name" Style ="color:white" InitialValue="-1"></asp:RequiredFieldValidator><br />
                    <br />   
                     Contact No. : &nbsp &nbsp&nbsp &nbsp&nbsp &nbsp &nbsp<asp:TextBox ID="txtContactno" placeholder ="Contact No." class="rounded" Width="50%" runat="server" required ="true" MaxLength="10" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox><br />
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Number"  style="color:white" Display="Static" ValidationExpression="\d+" ControlToValidate="txtContactno"></asp:RegularExpressionValidator>
                    <br />
                     Email ID : &nbsp &nbsp  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp &nbsp &nbsp<asp:TextBox ID="txtEmailid" placeholder ="Email ID" class="rounded" Width="50%" runat="server" required ="true" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox> <br />
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid Email" ControlToValidate="txtEmailid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Style ="color:white"></asp:RegularExpressionValidator>&nbsp&nbsp
                    <br />
                     Subject Name : &nbsp &nbsp&nbsp &nbsp<asp:TextBox ID="txtSubject" placeholder ="Subject Name" class="rounded" Width="50%" runat="server" required ="true" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox> <br /><br />
                     Total Fees  :  &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp &nbsp   <asp:TextBox ID="txtTotalfees" placeholder ="Total Fees" class="rounded" Width="50%" runat="server" required ="true" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Fee in Number"  style="color:white" Display="Static" ValidationExpression="\d+" ControlToValidate="txtTotalfees"></asp:RegularExpressionValidator>
                   <br />
                     Remaining Fees : &nbsp &nbsp   <asp:TextBox ID="txtRemainingfees" placeholder ="Remaining Fees" class="rounded" Width="50%" runat="server" required ="true" BackColor="#CCCCCC" OnTextChanged="txtRemainingfees_TextChanged" ReadOnly="True"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter Remaing Fee in Number"  style="color:white" Display="Static" ValidationExpression="\d+" ControlToValidate="txtRemainingfees"></asp:RegularExpressionValidator>
                   <br />
                     Amount Paying :   &nbsp &nbsp  <asp:TextBox ID="txtAmtpaying" placeholder ="Amount Paying" class="rounded" Width="50%" runat="server" required ="true" AutoPostBack="True" OnTextChanged="txtAmtpaying_TextChanged"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter Amount in Number"  style="color:white" Display="Static" ValidationExpression="\d+" ControlToValidate="txtAmtpaying"></asp:RegularExpressionValidator>
                   <br />
                     Admission Date :   &nbsp &nbsp <asp:TextBox ID="txtAdmissiondate" placeholder ="Admission Date(eg.01-01-2021)" class="rounded" Width="50%" runat="server" required ="true" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox> <br /><br />
                     Next Inst. Date :  &nbsp &nbsp <asp:TextBox ID="txtNextinstdate" placeholder ="Next Installment Date(eg.01-01-2021)" class="rounded" Width="50%" runat="server" required ="true" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox> <br /><br />

                <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" style="width:150px" OnClick="Button1_Click" />&nbsp&nbsp
                <a class="btn btn-dark" href="adminDashboard.aspx" style="width:150px">Dashboard</a>&nbsp&nbsp
                <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="Logout" style="width:150px" OnClientClick="return confirm ('Are you sure?');" OnClick="btnLogout_Click"/>&nbsp&nbsp
                 <br /><br />

                </div>
            </div>

        </div>
    </form>
</body>
</html>
