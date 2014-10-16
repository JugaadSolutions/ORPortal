<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommonProblemsSetting.aspx.cs" Inherits="ManufactureMonitor.CommonProblemsSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; height: 396px;">
        <tr>
            <td colspan="3" style="height: 51px; text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="626px" Height="30px" style="font-size: large; margin-left: 0px;">                                  Common machine stop problem definition</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 415px;">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; width: 490px;">Common Problem Selection</td>
            <td style="text-align: center">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 415px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: left; width: 490px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Common Problem:</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 415px;" rowspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="background-color: #99CCFF; text-align: center; width: 490px;" rowspan="5">
                <asp:ListBox ID="ProblemSelectionListBox" runat="server" SelectionMode="Single" Height="226px" Width="167px" />
            </td>
            <td style="text-align: left; height: 29px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" BorderStyle="Outset" Height="37px" Text="Edit" Width="80px" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Height="37px" OnClick="Button3_Click" Text="Add" Width="80px" />
            </td>
        </tr>
        <tr>
            <td style="height: 23px; width: 415px;"></td>
            <td style="height: 23px; text-align: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" BorderStyle="Outset" Height="37px" Text="Delete" Width="80px" OnClick="Button4_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 18px; width: 415px;"></td>
            <td style="text-align: center; height: 18px;"></td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; width: 415px;"></td>
            <td style="text-align: center; height: 30px"></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
