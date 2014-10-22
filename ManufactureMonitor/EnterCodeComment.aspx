<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnterCodeComment.aspx.cs" Inherits="ManufactureMonitor.EnterCodeComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="border: thin solid #FFAF37; width: 49%; border-collapse: collapse; height: 168px; margin-left: 262px; " border="1">
        <tr>
            <td style="background-color: #FFAF37; text-align: center;" colspan="2"><strong>Enter Code and Comment</strong></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 219px;"><strong>Problem No:</strong></td>
            <td style="text-align: left; width: 686px;">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 219px;"><strong>Comment:</strong></td>
            <td style="text-align: left; width: 686px;">
                <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Width="66px" />
            </td>
        </tr>
    </table>
</asp:Content>
