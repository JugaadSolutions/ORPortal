<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommonProblemsSetting_ADD.aspx.cs" Inherits="ManufactureMonitor.CommonProblemsSetting_ADD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td colspan="3" style="height: 51px; text-align: center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="529px" Height="30px" style="font-size: medium">                        Common machine stop problem definition</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" OnClick="ImageButton1_Click" Width="25px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="height: 51px; text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 245px;">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; " colspan="2">Commom Problem Definition</td>
            <td style="background-color: #FFFFCC; ">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 245px; height: 30px;"></td>
            <td style="background-color: #99CCFF; text-align: left; width: 266px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="background-color: #99CCFF; width: 336px; height: 30px;"></td>
            <td style="background-color: #FFFFCC; height: 30px;"></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 245px; height: 30px;"></td>
            <td style="background-color: #99CCFF; text-align: left; width: 266px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Problem No:</td>
            <td style="background-color: #99CCFF; width: 336px; height: 30px; ">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td style="background-color: #FFFFCC; height: 30px;"></td>
        </tr>
        <tr>
            <td style="height: 30px; width: 245px;">&nbsp;&nbsp;</td>
            <td style="background-color: #99CCFF; width: 266px; height: 30px; text-align: left;">      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      Problem Description:</td>
            <td style="height: 30px; background-color: #99CCFF; width: 336px; ">
                <asp:TextBox ID="TextBox3" runat="server" Width="582px"></asp:TextBox>
                &nbsp;</td>
            <td style="height: 30px; background-color: #FFFFCC;"></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 245px; height: 30px;"></td>
            <td style="background-color: #99CCFF; text-align: left; width: 266px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Type:</td>
            <td style="background-color: #99CCFF; height: 30px; width: 336px; ">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="320px">
                </asp:RadioButtonList>
            </td>
            <td style="background-color: #FFFFCC; height: 30px;"></td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; width: 245px;"></td>
            <td style="background-color: #99CCFF; text-align: left; width: 266px; height: 30px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Valid:</td>
            <td style="background-color: #99CCFF; width: 336px; ">
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </td>
            <td style="background-color: #FFFFCC;">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; width: 245px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; height: 30px;" colspan="2">
                <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="45px" Text="Save" Width="103px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="42px" Text="Don't Save" Width="125px" />
            </td>
            <td style="background-color: #FFFFCC;">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">&nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
