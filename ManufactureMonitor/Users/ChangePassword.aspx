<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ManufactureMonitor.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table  style="width: 1500px; border-collapse: collapse; background-color: #FFFFCC; height: 203px;">
        <tr>
            <td style="width: 289px">&nbsp;</td>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <strong>
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Height="30px" Width="390px" Font-Bold="True">                                      Change Password</asp:TextBox>
                </strong>
            </td>
            <td style="width: 263px">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" OnClick="ImageButton1_Click" Width="25px" />
            </td>
        </tr>
        <tr>
            <td style="width: 289px">&nbsp;</td>
            <td style="background-color: #FFAF37; color: #000000; font-size: medium; text-align: center; font-weight: 700;" colspan="2">User Identification</td>
        </tr>
        <tr>
            <td style="width: 289px; height: 19px;"></td>
            <td style="width: 160px; height: 19px;">Name:</td>
            <td style="width: 125px; height: 19px;">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td style="width: 263px; height: 19px;"></td>
        </tr>
        <tr>
            <td style="width: 289px">&nbsp;</td>
            <td style="width: 160px">Old Password:</td>
            <td style="width: 125px">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="width: 263px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 289px; height: 24px;"></td>
            <td style="width: 160px; height: 24px;">New Password:</td>
            <td style="width: 125px; height: 24px;">
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="width: 263px; height: 24px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 289px">&nbsp;</td>
            <td style="width: 160px">Confirm Password:</td>
            <td style="width: 125px">
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" Width="128px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox4" ControlToValidate="TextBox5" ErrorMessage="Password Not Matching"></asp:CompareValidator>
            </td>
            <td style="width: 263px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 289px">&nbsp;</td>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="2px" Text="Save" Height="40px" Width="80px" OnClick="Button1_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="40px" Text="Cancel" Width="100px" OnClick="Button2_Click" />
            </td>
            <td style="width: 263px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 289px">&nbsp;</td>
            <td style="width: 160px">&nbsp;</td>
            <td style="width: 125px">&nbsp;</td>
            <td style="width: 263px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
