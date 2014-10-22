<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayProject1.aspx.cs" Inherits="ManufactureMonitor.DisplayProject1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="616px" style="margin-left: 229px; font-size: medium;" Height="30px">                                         Machine Selection To Display Projects</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="border: thin solid #FFAF37; width: 21%; border-collapse: collapse; height: 168px; margin-left: 481px; border-color= #FFAF37;" border="1">
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center;"><strong>Machine Selection</strong></td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:ListBox ID ="MachineSelectionListBox" runat="server"  SelectionMode="Single"/>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" Width="66px" />
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
