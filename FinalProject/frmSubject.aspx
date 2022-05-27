<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSubject.aspx.cs" Inherits="FinalProject.frmSubject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Subject</title>
    <link href="CSS/animate.css" rel="stylesheet" />
    <link href="CSS/bootstrap.css" rel="stylesheet" />
</head>
<body style="background-image:url(Images/background.jpg)">
    <asp:Label ID="lblUsername" runat ="server" Visible="False"></asp:Label>

    <form id="form1" runat="server" style="text-align:center">
       
   <div class ="container-fluid">
        <div class ="row">
            <div class="col-lg-12" style ="text-align :center">
               <br /> <h1 style="color:black"><b>ENTER NEW SUBJECT</b></h1>

                <br /><asp:TextBox ID="txtSubject" runat="server" Width="80%" Class ="rounded" placeholder ="Enter Subject"></asp:TextBox>&nbsp&nbsp
               
                <br /><br />
                <asp:Button ID="btnSubmit" class="btn btn-success" runat="server" Text="Submit" style="width:150px" OnClick="btnSubmit_Click" />&nbsp&nbsp
                <a class="btn btn-dark" href="adminDashboard.aspx" style="width:150px">Dashboard</a>&nbsp&nbsp
                <asp:Button ID="btnLogout" class="btn btn-danger" runat="server" Text="Logout" style="width:150px" OnClientClick="return confirm ('Are you sure?');" OnClick="btnLogout_Click"/>&nbsp&nbsp


            </div>
    </div>
    </div>
      
          <div class ="container-fluid">
               <div class ="row">
         <div class ="col-lg-3">
                 <br /><br />
                     
            <div style ="overflow-x:scroll">
                <asp:GridView ID="grvSubject" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%" style="text-align:center">
                    <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                   <asp:Button ID="Button1" runat="server" Text="Delete" OnClick="Button1_Click" OnClientClick="return confirm('are you Sure?')" />
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
                   </div>
             
            </div>
    </form>
</body>
</html>
