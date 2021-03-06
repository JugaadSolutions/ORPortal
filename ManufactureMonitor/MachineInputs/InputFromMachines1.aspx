﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InputFromMachines1.aspx.cs" Inherits="ManufactureMonitor.InputFromMachines1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table  style="border: thin solid #FFAF37; width: 90%; text-align:center; height: 567px;">
        <tr>
            <td colspan="7" style="background-color: #FFFFCC; height: 32px;"><strong>
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Height="31px" style="font-size: medium; font-weight: bold; margin-left: 106px" Width="600px">                              Time Sequence of product pulses from machines</asp:TextBox>
                </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="7" style="background-color: #FFFFCC; height: 30px; text-align: left; color: #000000;">
                <table  style="border: thin solid #FFAF37; width: 52%; text-align:center; height: 224px;" align="center">
                    <tr>
                        <td colspan="3" style="background-color: #FFAF37; height: 32px; text-align: left;"><strong style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Selection Parameters</strong></td>
                    </tr>
                    <tr>
                         <td style="height: 23px; width: 296px; text-align: left;"><b>&nbsp;&nbsp; Machines:</b></td>
                         <td style="height: 23px; text-align: left; width: 321px;"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date:</b></td>
                         <td style="height: 23px; text-align: left;"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Shifts:</b></td>
                    </tr>
                    <tr>
                        <td style="width: 296px; height: 42px">
                            &nbsp;<asp:ListBox ID="MachineSelectionListBox" runat="server" Height="150px" OnSelectedIndexChanged="MachineSelectionListBox_SelectedIndexChanged"
                                 Width="200px" AutoPostBack="true"></asp:ListBox>
                        </td>
                        <td style="height: 42px; width: 321px;">
                            <asp:Calendar ID="date" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" 
                                BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                                ForeColor="#663399" Height="140px"  Width="195px" style="margin-left: 6px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#FFAF37" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                
                            </asp:Calendar>
                        </td>
                        <td style="height: 42px; ">
                           
                            <asp:ListBox ID="ShiftSelectionListBox" runat="server" Height="150px" Width="150px" style="margin-left: 0px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 76px">
                            <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="2px" Text="Show" Height="45px" Width="80px" OnClick="Button1_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" ImageAlign="AbsBottom" ImageUrl="~/Images/excelicon.jpg" OnClick="ImageButton2_Click" Width="40px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 23px; width: 42px">&nbsp;</td>
            <td style="height: 23px; width: 429px;">&nbsp;</td>
            <td style="height: 23px; width: 277px;">&nbsp;</td>
            <td style="height: 23px; width: 256px;">&nbsp;</td>
            <td style="height: 23px; " colspan="2">&nbsp;</td>
            <td style="height: 23px; width: 157px;"></td>
        </tr>
        <tr>
            <td style="width: 42px; height: 42px">&nbsp;</td>
            <td style="height: 42px; width: 429px;">
                &nbsp;</td>
            <td style="height: 42px; width: 277px;">
                &nbsp;</td>
            <td style="height: 42px; width: 256px;">
                &nbsp;</td>
            <td style="height: 42px; width: 143px;">
                &nbsp;</td>
            <td style="height: 42px; text-align: left;">&nbsp;</td>
            <td style="height: 42px; width: 157px;">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="7" style="height: 1px">
                <div style="text-align: left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
    </table>
</asp:Content>
