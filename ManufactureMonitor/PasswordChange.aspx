﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="ManufactureMonitor.PasswordChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" style="width: 1079px; border-collapse: collapse; background-color: #FFFFCC">
        <tr>
            <td style="width: 158px">&nbsp;</td>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Height="30px" Width="478px" style="font-weight: bold; font-size: medium">                                      Change Password</asp:TextBox>
            </td>
            <td style="width: 263px">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" OnClick="ImageButton1_Click" Width="25px" />
            </td>
        </tr>
        <tr>
            <td style="width: 158px">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; " colspan="2">User Identification</td>
            </tr>
        <tr>
            <td style="width: 158px">&nbsp;</td>
            <td style="width: 239px">Name:</td>
            <td style="width: 150px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td style="width: 263px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 158px">&nbsp;</td>
            <td style="width: 239px">Password:</td>
            <td style="width: 150px">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="width: 263px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 158px">&nbsp;</td>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="2px" Text="Enter" Height="45px" Width="137px" OnClick="Button1_Click" />
                        </td>
            <td style="width: 263px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 158px">&nbsp;</td>
            <td style="width: 239px">&nbsp;</td>
            <td style="width: 150px">&nbsp;</td>
            <td style="width: 263px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
