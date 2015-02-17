<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayParameters.aspx.cs" Inherits="ManufactureMonitor.DisplayParameters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td style="text-align: center; ">
                &nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Width="576px" BorderColor="#333333" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" ForeColor="Black" Height="30px" style="font-size: medium; margin-left: 298px">                                          Representation of parameters</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="BackButton" runat="server" ImageUrl="~/Images/return.jpg" ImageAlign="Middle" OnClick="BackButton_Click" CssClass="auto-style4" Height="25px" Width="25px" style="margin-left: 0px" />
            
            </td>
        </tr>
        <tr>
            <td style="height: 23px; text-align: left">
                <div style="text-align: center; height: 163px;">
                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Left" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2" ShowHeaderWhenEmpty="True" Width="912px" style="margin-left: 246px; text-align: center;">
                    
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
                </div>
&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
