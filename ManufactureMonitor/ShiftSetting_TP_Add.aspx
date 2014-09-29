<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftSetting_TP_Add.aspx.cs" Inherits="ManufactureMonitor.ShiftSetting_TP_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td colspan="4" style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="753px" style="margin-left: 0px; font-size: medium;" Height="30px">                                                                       Shift Definition</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 445px;">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; " colspan="2">&nbsp;Shift Selection</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 445px; height: 30px;"></td>
            <td style="background-color: #99CCFF; text-align: left; width: 263px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Time Points:</td>
            <td style="background-color: #99CCFF; text-align: left; width: 189px; height: 30px;">&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Width="20px"></asp:TextBox>
                &nbsp;&nbsp; <span style="font-size: large"><strong>&nbsp;: </strong></span>&nbsp;&nbsp;
                <asp:TextBox ID="TextBox3" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px;"></td>
        </tr>
        <tr>
            <td style="width: 445px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; " rowspan="2" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp; </td>
            <td style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 445px;"></td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 445px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 263px;">
                <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="38px" Text="Save" Width="103px" />
            </td>
            <td style="background-color: #99CCFF; text-align: center; width: 189px;">
                <asp:Button ID="Button2" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="38px" Text="Don't Save" Width="103px" />
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 445px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 263px; height: 30px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 189px; height: 30px;"></td>
            <td style="text-align: center; height: 30px"></td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
