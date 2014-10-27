<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualState.aspx.cs" Inherits="ManufactureMonitor.ActualState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 1500px; border-collapse: collapse; background-color: #FFFFCC; height: 450px">
        <tr>
            <td style="height: 46px; text-align: center;">
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="507px" Height="30px" style="font-size: large">                                          Actual State</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
                                        </td>
        </tr>
        <tr>
            <td style="height: 30px">

                

                &nbsp;</td>

        </tr>
        <tr>
            <td style="height: 30px">
                <table style="border: thin solid #FFAF37; width: 23%; border-collapse: collapse; height: 259px; margin-left: 533px; background-color: #FFFFCC; ">
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center;">Machine Selection</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:ListBox ID="MachineSelectionListBox" runat="server" Height="150px" Width="200px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
