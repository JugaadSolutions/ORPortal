<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelMachineOff.aspx.cs" Inherits="ManufactureMonitor.MachineOff.CancelMachineOff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="border: thin solid #FFAF37; width: 42%; border-collapse: collapse; height: 315px; margin-left: 470px; background-color: #FFFFCC; font-weight: 700;">
        <tr>
            <td style="background-color: #FFFFCC; text-align: center;" colspan="2">Cancel Machine OFF</td>
        </tr>
        <tr>
            <td style="background-color: #FFAF37; text-align: center;" colspan="2">Machine:
                <asp:Label ID="MachineLabel" runat="server"></asp:Label>
                Shift:<asp:Label ID="ShiftLabel" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cancel Machine OFF:</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 188px;" rowspan="3">
                <asp:ListBox ID="CancelMachineSelectionListBox" runat="server" SelectionMode="Single" Height="150px" Width="261px" style="margin-left: 22px"  />
            </td>
            <td style="text-align: center; height: 47px; width: 18px;">
                <asp:Button ID="EnterButton" runat="server" OnClick="EnterButton_Click" Text="Enter" Width="66px" textalign="center" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 31px; width: 18px;">
                <asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Back" Width="66px" textalign="center"  />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 18px;">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
