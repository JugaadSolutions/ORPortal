<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectAssignment.aspx.cs" Inherits="ManufactureMonitor.ProjectAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td colspan="3" style="height: 51px; text-align: center">
                &nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray"  BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="600px" Height="30px" style="font-size: large">                              Project Assigment</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>

        <tr>
            <td style="text-align: center; height: 30px; " colspan="3">
                <table style="border: thin solid #FFAF37; width: 23%; border-collapse: collapse; height: 259px; margin-left: 444px; background-color: #FFFFCC; ">
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center;" colspan="2">Shift Selection</td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 137px"> <b>Project Assigned:</b></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="font-size: large"><strong>&nbsp;</strong></span><span style="font-size: small"><strong>New Project:</strong></span><span style="font-size: large"><span style="font-size: small"><strong>&nbsp; </strong></span><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></span></td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                 
                <asp:Label ID="ProjectAssignedLabel" runat="server"></asp:Label>
                 
                        </td>
                        <td style="text-align: center">
                            <asp:ListBox ID="ProjectSelectionListBox" runat="server" SelectionMode="Single" Height="150px" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 137px;">
                <asp:Button ID="SaveButton" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="38px" Text="Save" Width="103px" OnClick="SaveButton_Click" />
                        </td>
                        <td style="text-align: center">
                <asp:Button ID="DontSaveButton" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="38px" Text="Don't Save" Width="103px" OnClick="DontSaveButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; width: 392px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; ">&nbsp;</td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
