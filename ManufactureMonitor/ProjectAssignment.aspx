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
            <td style="text-align: center; width: 392px;">&nbsp;</td>
            <td style="background-color: #FFAF37; color: #000000; font-size: medium; text-align: center; font-weight: 700;" colspan="2">Project Selection</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 392px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; width: 127px;"> <b>Project Assigned:</b></td>
            <td style="background-color: #FFFFCC; width: 90px;"><b>New Project:</b></td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 392px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; width: 127px;">
                 
                <asp:Label ID="ProjectAssignedLabel" runat="server"></asp:Label>
                 
            </td>
            <td style="background-color: #FFFFCC; width: 90px;">
                            <asp:ListBox ID="MachineSelectionListBox" runat="server" SelectionMode="Single" />
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px; width: 392px;"></td>
            <td style="background-color: #FFFFCC; width: 127px; text-align: center;">
                <asp:Button ID="SaveButton" runat="server" OnClick="Button1_Click" Text="Save" Width="66px" />
            </td>
            <td style="background-color: #FFFFCC; width: 90px;">
                <asp:Button ID="DontSaveButton" runat="server" OnClick="Button1_Click" Text="Don'tSave" Width="66px" />
            </td>
            <td style="height: 23px"></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 392px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; " colspan="2">
                &nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; width: 392px;"></td>
            <td style="background-color: #FFFFCC; " colspan="2"></td>
            <td style="text-align: center; height: 30px"></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
