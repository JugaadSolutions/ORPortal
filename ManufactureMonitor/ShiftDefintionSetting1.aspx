<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftDefintionSetting1.aspx.cs" Inherits="ManufactureMonitor.ShiftDefintionSetting1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td colspan="3" style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="616px" style="margin-left: 229px; font-size: medium;" Height="30px">                                                        Machine OFF- Setting</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 452px;">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; width: 350px;">Machine Selection</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 452px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: left; width: 350px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 452px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px;">
                <table  style="width: 100%; border-collapse: collapse; background-color: #99CCFF; text-align:center">
                    <tr>
                        <td>
                            <asp:ListBox ID ="MachineSelectionListBox" runat="server"  SelectionMode="Single"/>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px; width: 452px;"></td>
            <td style="background-color: #99CCFF; width: 350px; height: 23px;"></td>
            <td style="height: 23px"></td>
        </tr>
        <tr>
            <td style="width: 450px; height: 40px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 358px; height: 40px;">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" Width="66px" />
            </td>
            <td style="text-align: center; height: 40px;"></td>
        </tr>
        <tr>
            <td style="height: 30px; width: 452px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px; height: 30px;"></td>
            <td style="text-align: center; height: 30px"></td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
