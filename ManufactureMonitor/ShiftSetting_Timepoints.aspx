<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftSetting_Timepoints.aspx.cs" Inherits="ManufactureMonitor.ShiftSetting_Timepoints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td colspan="4" style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="753px" style="margin-left: 0px; font-size: medium;" Height="30px">                                                                            Shift Definition</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 316px;">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; width: 350px;" colspan="2">&nbsp; Shift :</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 316px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: left; width: 350px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Time Points:</td>
            <td style="background-color: #99CCFF; text-align: left; width: 350px;">&nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 316px;" rowspan="2">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px;" rowspan="4">
                <asp:TextBox ID="TextBox2" runat="server" Height="165px" Width="74px"></asp:TextBox>
            </td>
            <td style="background-color: #99CCFF; text-align: left; width: 350px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Edit" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="text-align: center" rowspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #99CCFF; text-align: left; width: 350px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="Delete" />
            </td>
        </tr>
        <tr>
            <td style="height: 23px; width: 316px;" rowspan="2"></td>
            <td style="background-color: #99CCFF; width: 350px; height: 23px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" Text="Add" OnClick="Button4_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="height: 23px" rowspan="2"></td>
        </tr>
        <tr>
            <td style="background-color: #99CCFF; width: 350px; height: 23px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button5" runat="server" Text="Shift Selection" OnClick="Button5_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 316px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px;">&nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 316px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px; height: 30px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px; height: 30px;"></td>
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
