<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftDefinitionSetting.aspx.cs" Inherits="ManufactureMonitor.ShiftDefinitionSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="766px" style="margin-left: 100px; font-size: medium;" Height="30px">                                                                               Shift Definition</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="border: thin solid #FFAF37; width: 39%; border-collapse: collapse; height: 315px; margin-left: 377px; background-color: #FFFFCC; ">
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center;" colspan="2">Shifts Selection</td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 187px;" rowspan="4">
                <asp:ListBox ID="ShiftSelectionListBox" runat="server" SelectionMode="Single" Height="150px" Width="391px" />
                        </td>
                        <td style="text-align: center; height: 47px;">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Edit" Width="66px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; height: 31px;">
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Add" Width="66px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" Width="66px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                <asp:Button ID="Button5" runat="server" Text="Time Points" OnClick="Button5_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
