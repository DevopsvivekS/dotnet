<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAdmission.aspx.cs" Inherits="FinalProject.frmAdmission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Admission</title>
    <link href="CSS/animate.css" rel="stylesheet" />
    <link href="CSS/bootstrap.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/background.jpg)">
    <asp:Label ID="lblUsername" runat ="server" Visible="False"></asp:Label>
    <br />
    <form id="form1" runat="server" style="text-align:center">
        <h1><u style="color:red;background-color:yellow"><b>STUDENT ADDMISSION FORM</b></u></h1>
   <div class ="container-fluid">
        <div class ="row">
            <div class="col-lg-12" style ="text-align :center">


                <br /><br /><asp:TextBox ID="txtFirst" runat="server" Width="200px" Class ="rounded" placeholder ="FirstName" ValidationGroup="b"></asp:TextBox>&nbsp&nbsp
                <asp:TextBox ID="txtMiddle" runat="server" Width="200px" Class ="rounded" placeholder ="MiddleName"  ValidationGroup="b"></asp:TextBox>&nbsp&nbsp
                <asp:TextBox ID="txtLast" runat="server" Width="200px" Class ="rounded" placeholder ="LastName" ValidationGroup="b"></asp:TextBox>&nbsp&nbsp
                <asp:TextBox ID="txtEmail" runat="server" Width="200px" Class ="rounded" placeholder ="Email Id"   AutoPostBack="True" OnTextChanged="txtEmail_TextChanged" ValidationGroup="b"></asp:TextBox>&nbsp&nbsp
                <asp:TextBox ID="txtMobile" runat="server" Width="200px" Class ="rounded" placeholder ="Mobile Number"  CausesValidation="True" MaxLength="10"></asp:TextBox>&nbsp&nbsp
                <asp:DropDownList ID="ddlSubject" runat="server" Width="200px"  Class ="rounded" CausesValidation="True" style ="text-align:center" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>&nbsp&nbsp
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid Email" ControlToValidate="txtEmail" ValidationGroup="b" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Style ="color:red"></asp:RegularExpressionValidator>&nbsp&nbsp
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Number"  style="color:red;background-color:yellow" ValidationGroup="b" Display="Static" ValidationExpression="\d+" ControlToValidate="txtMobile"></asp:RegularExpressionValidator>&nbsp&nbsp
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Subject" ControlToValidate="ddlSubject" Style ="color:red" ValidationGroup="b" InitialValue="-1"></asp:RequiredFieldValidator>&nbsp&nbsp


                <br />
                <asp:TextBox ID="txtTotalfee" runat="server" Width="200px" Class ="rounded" placeholder ="Total Fees" AutoPostBack="True" ValidationGroup="b" OnTextChanged="txtTotalfee_TextChanged"></asp:TextBox>&nbsp&nbsp
                <asp:TextBox ID="txtAmountpaid" runat="server" Width="200px" Class ="rounded" placeholder ="Amount Paid" AutoPostBack="True" ValidationGroup="b" OnTextChanged="txtAmountpaid_TextChanged"></asp:TextBox>&nbsp&nbsp
                <asp:TextBox ID="txtRemaining" runat="server" Width="200px" Class ="rounded" placeholder ="Remaining Amount" AutoPostBack="True" ValidationGroup="b" OnTextChanged="txtRemaining_TextChanged"></asp:TextBox>&nbsp&nbsp
                <asp:TextBox ID="txtAddmissiondate" runat="server" Width="200px"  Class ="rounded" placeholder ="Admission Date(eg.10-Jan-2021)" ValidationGroup="b"  AutoPostBack="True" OnTextChanged="txtAddmissiondate_TextChanged" ></asp:TextBox>&nbsp&nbsp
                <%--<asp:TextBox ID="txtInstallmentdate" runat="server" Width="200px" required="true" Class ="rounded" placeholder ="Installment Date(eg.10-Jan-2021)" ></asp:TextBox>&nbsp&nbsp--%>
                <asp:TextBox ID="txtUsername" runat="server" Width="200px" Class ="rounded" placeholder ="Student Username"  BackColor="#CCCCCC" ReadOnly="True" ValidationGroup="b"></asp:TextBox>&nbsp&nbsp
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Vaild Username" ControlToValidate="txtUsername" Style ="color:red"  ValidationGroup="b" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                <br />
                <asp:TextBox ID="txtPassword" runat="server" Width="200px" Class ="rounded"  placeholder ="Student Password" TextMode="Password" ValidationGroup="b"></asp:TextBox>&nbsp&nbsp
                <asp:TextBox ID="txtRepassword" runat="server" Width="200px" Class ="rounded"   placeholder ="Re-Enter Password" TextMode="Password" ValidationGroup="b"></asp:TextBox>&nbsp&nbsp
                <asp:FileUpload ID="FileUpload1" runat="server" style ="color:red"/>&nbsp&nbsp
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Not Matched" ControlToCompare="txtPassword" ControlToValidate="txtRepassword" Style ="color:red"></asp:CompareValidator>

                <br /><br />
                <asp:Button ID="btnSubmit" class="btn btn-success" runat="server" Text="Submit" style="width:150px" OnClick="btnSubmit_Click" />&nbsp&nbsp
                <asp:Button ID="btnExport" class="btn btn-warning" runat="server" Text="Export to Pdf" style="width:150px" OnClick="btnExport_Click"/>&nbsp&nbsp
                 <a class="btn btn-dark" href="adminDashboard.aspx" style="width:150px">Dashboard</a>&nbsp&nbsp
                <asp:Button ID="btnLogout" class="btn btn-danger" runat="server" Text="Logout" style="width:150px" OnClientClick="return confirm ('Are you sure?');" OnClick="btnLogout_Click"/>&nbsp&nbsp

                   
            </div>

    </div>
    </div>
        <div class ="col-lg-12">
                 <br /><br />
            <div style ="overflow-x:scroll">
                <asp:GridView ID="grvAdmission" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%" style="text-align:center ; font-size:10px" OnSelectedIndexChanged="grvAdmission_SelectedIndexChanged">

                       <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="Delete" OnClick="Button1_Click" OnClientClick="return confirm('are you Sure?')" ValidationGroup="a" />
                     </ItemTemplate>


                 </asp:TemplateField>
                        </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                </div>
            </div>

        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.22/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
    <script type="text/javascript">
        $("body").on("click", "#btnExport", function () {
            html2canvas($('[id*=grvAdmission]')[0], {
                onrendered: function (canvas) {
                    var data = canvas.toDataURL();
                    var docDefinition = {
                        content: [{
                            image: data,
                            width: 500
                        }]
                    };
                    pdfMake.createPdf(docDefinition).download("Unisoft-ENQUIRY.pdf");
                }
            });
        });
    </script>
    </form>
</body>
</html>
