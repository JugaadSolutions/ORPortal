﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParameterSetting.aspx.cs" Inherits="ManufactureMonitor.ParameterSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="523px" style="margin-left: 303px; font-size: medium;" Height="30px">                                         Parameter Of  Setting</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="border: thin solid #FFAF37; width: 33%; border-collapse: collapse; height: 324px; margin-left: 450px; background-color: #FFFFCC; ">
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center;">Machine Selection</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center; height: 223px;">
                            <asp:ListBox ID="MachineSelectionListBox" runat="server" Height="150px" Width="200px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" Height="38px" Width="74px" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </td>
        </tr>
    </table>
</asp:Content>
