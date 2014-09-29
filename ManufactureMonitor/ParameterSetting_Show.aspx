<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParameterSetting_Show.aspx.cs" Inherits="ManufactureMonitor.ParameterSetting_Show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; height: 402px;">
        <tr>
            <td colspan="4" style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="753px" style="margin-left: 156px; font-size: medium;" Height="30px">                                                                           Setting Of Parameter  </asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 406px;">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; " colspan="2">Machine:</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 406px; height: 30px;"></td>
            <td style="background-color: #99CCFF; text-align: left; height: 30px;" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="text-align: center; height: 30px;"></td>
        </tr>
        <tr>
            <td style="width: 406px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="background-color: #99CCFF; text-align: center; width: 213px; height: 30px;">Time to Stop[s]:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 232px; height: 30px;">
                <asp:TextBox ID="TextBox2" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;"></td>
            <td style="background-color: #99CCFF; width: 213px; height: 30px; text-align: center;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ratio Pulses:Pieces:</td>
            <td style="background-color: #99CCFF; width: 232px; height: 30px; position: absolute;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox3" runat="server" Width="20px" Height="20px" style="margin-top: 0px"></asp:TextBox>
                <strong><span style="font-size: large">: </span></strong><asp:TextBox ID="TextBox4" runat="server" Width="20px" Height="20px" style="margin-top: 0px"></asp:TextBox>
            </td>
            <td style="height: 30px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 406px; height: 30px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 213px; height: 30px;">&nbsp; OR red MIN[%]:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 232px; height: 30px;">
                <asp:TextBox ID="TextBox5" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px;"></td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 213px; height: 30px;">&nbsp;&nbsp; OR red MAX[%]:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 232px; height: 30px;">
                <asp:TextBox ID="TextBox6" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px"></td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 213px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR orange MIN[%]:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 232px; height: 30px;">
                <asp:TextBox ID="TextBox7" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 213px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR orange MAX[%]:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 232px; height: 30px;">
                <asp:TextBox ID="TextBox8" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 213px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp; OR green MIN[%]:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 232px; height: 30px;">
                <asp:TextBox ID="TextBox9" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 213px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp; OR greenMAX[%]:</td>
            <td style="background-color: #99CCFF; text-align: center; width: 232px; height: 30px;">
                <asp:TextBox ID="TextBox10" runat="server" Width="20px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; height: 30px;" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" BorderStyle="Outset" BorderWidth="3px" Text="Save" Width="78px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" BorderStyle="Outset" BorderWidth="3px" Text="Don't Save" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
