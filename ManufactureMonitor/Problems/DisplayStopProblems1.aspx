﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayStopProblems1.aspx.cs" Inherits="ManufactureMonitor.DisplayStopProblems1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; background-color: #FFFFCC; height: 387px;">
        <tr>
            <td style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="664px" 
                    style="margin-left: 177px; font-size: medium;" Height="30px">                                                                   Stop Problems</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="border: thin solid #FFAF37; width: 21%; border-collapse: collapse; height: 327px; margin-left: 481px; border-color: #FFAF37;" >
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center;"><strong>Machine Selection</strong></td>
                    </tr>
                    <tr>
                        <td style="text-align: center; height: 225px;">
                            <asp:ListBox ID ="MachineSelectionListBox" runat="server"  SelectionMode="Single" Height="150px" Width="200px"/>
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
    </table>
</asp:Content>