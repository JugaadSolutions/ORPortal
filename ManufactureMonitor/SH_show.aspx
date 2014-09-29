<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SH_show.aspx.cs" Inherits="ManufactureMonitor.SH_show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 106px">&nbsp;</td>
            <td style="text-align: center; width: 879px"><strong>
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Height="30px" style="font-size: medium; font-weight: bold" Width="512px">                                          Shift history - production in the shifts</asp:TextBox>
                </strong></td>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" OnClick="ImageButton1_Click" Width="25px" />
            </td>
        </tr>
        <tr>
            <td style="width: 106px">&nbsp;</td>
            <td style="width: 879px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
