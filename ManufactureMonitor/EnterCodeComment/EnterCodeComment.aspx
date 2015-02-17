<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnterCodeComment.aspx.cs" Inherits="ManufactureMonitor.EnterCodeComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="border: thin solid #FFAF37; width: 49%;  height: 168px; margin-left: 350px; " >
        <tr>
            <td style="background-color: #FFAF37; text-align: center;" colspan="2"><strong>Enter Code and Comment</strong></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 219px;">Problem No:</td>
            <td style="text-align: left; width: 686px;">
                <asp:DropDownList ID="CodeSelection" runat="server" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 219px;">Comment:</td>
            <td style="text-align: left; width: 686px;">
                <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Width="82px" BorderStyle="Outset" Height="32px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cancel" Width="81px" BorderStyle="Outset" Height="32px" />
            </td>
        </tr>
    </table>
</asp:Content>
