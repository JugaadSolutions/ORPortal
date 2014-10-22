<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommonProblemsSetting.aspx.cs" Inherits="ManufactureMonitor.CommonProblemsSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; height: 396px;">
        <tr>
            <td style="height: 51px; text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="626px" Height="30px" style="font-size: large; margin-left: 0px;">                                  Common machine stop problem definition</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <table style="border: thin solid #FFAF37; width: 23%; border-collapse: collapse; height: 348px; margin-left: 476px; background-color: #FFFFCC; ">
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center;" colspan="2">Common Problem Selection</td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp; Problems:&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 205px;" rowspan="3">
                            <asp:ListBox ID="ProblemSelectionListBox" runat="server" Height="200px" Width="150px"></asp:ListBox>
                        </td>
                        <td style="text-align: center">
                <asp:Button ID="Button2" runat="server" BorderStyle="Outset" Height="37px" Text="Edit" Width="80px" OnClick="Button2_Click" BorderWidth="1px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                <asp:Button ID="Button3" runat="server" Height="37px" OnClick="Button3_Click" Text="Add" Width="80px" BorderStyle="Outset" BorderWidth="1px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                <asp:Button ID="Button4" runat="server" BorderStyle="Outset" Height="37px" Text="Delete" Width="80px" OnClick="Button4_Click" BorderWidth="1px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 19px"></td>
                    </tr>
                </table>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
