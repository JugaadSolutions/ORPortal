<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftSetting_Add.aspx.cs" Inherits="ManufactureMonitor.ShiftSetting_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td colspan="7" style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="853px" style="margin-left: 191px; font-size: medium;" Height="30px">                                                                           Shift Definition</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 361px; height: 23px;"></td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; height: 23px;" colspan="5">Machine:</td>
            <td style="text-align: center; height: 23px;">&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 361px; height: 29px;"></td>
            <td style="background-color: #99CCFF; text-align: left; height: 29px;" colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; From:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; To:</td>
            <td style="text-align: center; height: 29px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 361px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="background-color: #99CCFF; text-align: center; width: 170px; height: 30px;">Shift:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox2" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox3" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="background-color: #99CCFF; text-align: center; width: 221px; height: 30px; font-size: large;"><strong>-</strong></td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox4" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox5" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="background-color: #99CCFF; text-align: center; width: 801px; " rowspan="6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Day of Shift Beginning:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;<span style="font-size: large"> </span>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="169px" TextAlign="Left" Width="90px">
                </asp:CheckBoxList>
            </td>
            <td style="text-align: center; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 361px;"></td>
            <td style="background-color: #99CCFF; width: 170px; height: 30px; text-align: center;">Rest 1:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox6" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox7" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="background-color: #99CCFF; width: 221px; height: 30px; font-size: large; text-align: center;"><strong>-</strong></td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox26" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox27" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="height: 30px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 361px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 170px; height: 30px;">Rest 2:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox10" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox11" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="background-color: #99CCFF; text-align: center; width: 221px; height: 30px; font-size: large;"><strong>-</strong></td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox12" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox13" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 361px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 170px; height: 30px;">Rest 3:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox14" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox15" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="background-color: #99CCFF; text-align: center; width: 221px; height: 30px; font-size: large;"><strong>-</strong></td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox16" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox17" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px"></td>
        </tr>
        <tr>
            <td style="height: 30px; width: 361px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 170px; height: 30px;">Rest 4:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox18" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox19" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="background-color: #99CCFF; text-align: center; width: 221px; height: 30px; font-size: large;"><strong>-</strong></td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox20" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox21" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 361px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 170px; height: 30px;">Rest 5:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox22" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox23" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="background-color: #99CCFF; text-align: center; width: 221px; height: 30px; font-size: large;"><strong>-</strong></td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">
                <asp:TextBox ID="TextBox24" runat="server" Width="20px"></asp:TextBox>
&nbsp;<span style="font-size: large">:</span>
                <asp:TextBox ID="TextBox25" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 361px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 170px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">&nbsp;&nbsp;&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 221px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 801px; height: 30px;">&nbsp;</td>
            <td style="text-align: center; height: 30px">&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 361px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 170px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 221px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 801px; height: 30px;">&nbsp;</td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 361px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 170px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 221px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 621px; height: 30px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 801px; height: 30px;">&nbsp;</td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="7">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
