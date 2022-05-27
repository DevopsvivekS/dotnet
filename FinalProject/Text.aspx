<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Text.aspx.cs" Inherits="FinalProject.Text" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class ="Container"><br /><br />
        <div class ="row">
<%--            <div class ="col-lg-4" style = "background-color:cyan">A</div>
            <div class ="col-lg-4" style = "background-color:blueviolet">B</div>
            <div class ="col-lg-4" style = "background-color:Red">C</div>--%>
            
            <%--<asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>
             <br /><br /><asp:DropDownList ID="ddlSubject" runat="server" required="true" style="text-align:center" CausesValidation="True">
                </asp:DropDownList><br /><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click1" />--%>

            <div class="col-lg-12">
                 <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
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
    
    </div>
<%--        <asp:TextBox ID="txtTest" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /><br /><br />--%>
    </form>
    
    <%--Ancor tag--%>
    <%--Please visit <a href ="https://www.facebook.com" target ="_blank">Facebook</a>Page--%>

    <%--<a href="frmIndex.aspx" class ="btn btn-dark">Student Enquiry</a>--%>

</body>
</html>
