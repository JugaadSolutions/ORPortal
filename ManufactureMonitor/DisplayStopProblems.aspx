<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayStopProblems.aspx.cs" Inherits="ManufactureMonitor.DisplayStopProblems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p style="background-color: #FFFFCC">
        <table style="width: 100%; border-collapse: collapse">
            <tr>
                <td style="text-align: right; width: 960px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="600px" BorderColor="#333333" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" ForeColor="Black" Height="30px" style="font-size: large">                                        Reprentation of Project List</asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="BackButton" runat="server" ImageUrl="~/Images/return.jpg" ImageAlign="Right" OnClick="BackButton_Click" CssClass="auto-style4" Height="25px" Width="25px" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 23px; text-align: center">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="3" AutoGenerateColumns="true" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" ShowHeaderWhenEmpty="True" Width="1119px" style="margin-left:100px">
                       
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#FF9966" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
    </p>
</asp:Content>
