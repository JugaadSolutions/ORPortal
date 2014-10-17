<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectAssignment.aspx.cs" Inherits="ManufactureMonitor.ProjectAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td colspan="4" style="height: 51px; text-align: center">
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="600px" Height="30px" style="font-size: large">                                                Project Assigment</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 422px;">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; " colspan="2">Project Selection</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 422px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: left; width: 203px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Project Assigned:</td>
            <td style="background-color: #99CCFF; text-align: left; width: 197px;">New Project:</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 422px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 203px;">
                 
                <asp:Label ID="ProjectAssignedLabel" runat="server"></asp:Label>
                 
            </td>
            <td style="background-color: #99CCFF; text-align: center; width: 197px;">
                            <asp:ListBox ID="MachineSelectionListBox" runat="server" SelectionMode="Single" />
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px; width: 422px;"></td>
            <td style="background-color: #99CCFF; width: 203px; text-align: center;">
                <asp:Button ID="SaveButton" runat="server" OnClick="Button1_Click" Text="Save" Width="66px" />
            </td>
            <td style="background-color: #99CCFF; width: 197px; text-align: center;">
                <asp:Button ID="DontSaveButton" runat="server" OnClick="Button1_Click" Text="Don'tSave" Width="66px" />
            </td>
            <td style="height: 23px"></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 422px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; " colspan="2">
                &nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; width: 422px;"></td>
            <td style="background-color: #99CCFF; text-align: center; height: 30px;" colspan="2"></td>
            <td style="text-align: center; height: 30px"></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
