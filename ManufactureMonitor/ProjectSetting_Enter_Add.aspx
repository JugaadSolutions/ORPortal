<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectSetting_Enter_Add.aspx.cs" Inherits="ManufactureMonitor.ProjectSetting_Enter_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td colspan="4" style="height: 51px; text-align: center">&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="600px" style="font-size: medium" Height="30px">                                                                Project definition</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" OnClick="ImageButton1_Click" Width="25px" style="margin-left: 72px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 461px;">&nbsp;</td>
            <td style="background-color: #FFAF37; color: #FFFFFF; font-size: medium; text-align: center; " colspan="2"> Project Definition</td>
            <td style="background-color: #FFFFCC; ">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 461px; height: 30px;"></td>
            <td style="background-color: #FFFFCC; ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="background-color: #FFFFCC; "></td>
            <td style="background-color: #FFFFCC; height: 30px;"></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 461px; height: 30px;"></td>
            <td style="background-color: #FFFFCC; "><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name:</strong></td>
            <td style="background-color: #FFFFCC; ">
                <asp:TextBox ID="TextBox2" runat="server" Width="183px"></asp:TextBox>
            </td>
            <td style="background-color: #FFFFCC; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 461px;"></td>
            <td style="background-color: #FFFFCC; "><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cycle time [s]:</strong></td>
            <td style="background-color: #FFFFCC; ">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
            <td style="height: 30px; background-color: #FFFFCC;"></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 461px; height: 30px;"></td>
            <td style="background-color: #FFFFCC; "><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></td>
            <td style="background-color: #FFFFCC; ">
                &nbsp; </td>
            <td style="background-color: #FFFFCC; height: 30px;"></td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; width: 461px;"></td>
            <td style="background-color: #FFFFCC; "><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></td>
            <td style="background-color: #FFFFCC; ">
                &nbsp;</td>
            <td style="background-color: #FFFFCC;">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 461px;"></td>
            <td style="background-color: #FFFFCC; ">
                <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="45px" Text="Save" Width="103px" OnClick="Button1_Click" />
            </td>
            <td style="background-color: #FFFFCC; ">
                <asp:Button ID="DontSaveButton" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="45px" Text="Don't Save" Width="103px" OnClick="DontSaveButton_Click" />
            </td>
            <td style="background-color: #FFFFCC;"></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">&nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
