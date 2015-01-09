<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_off_setting.aspx.cs" Inherits="ManufactureMonitor.M_off_setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="548px" style="margin-left: 360px; font-size: medium;" Height="30px">                                                 Machine OFF- Setting</asp:TextBox>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="border: thin solid #FFAF37; width: 35%; border-collapse: collapse; height: 290px; margin-left: 460px; background-color: #FFFFCC; ">
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center; width: 443px;">Machine Selection</td>
                    </tr>
                    <tr>
                        <td style="width: 443px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 443px;">
                            <asp:ListBox ID="MachineSelectionListBox" runat="server" Height="150px" Width="200px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 443px;">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" Height="32px" Width="70px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 443px">&nbsp;</td>
                    </tr>
                </table>
                </td>
        </tr>
    </table>
</asp:Content>
