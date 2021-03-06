﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProblemAccumulation.aspx.cs" Inherits="ManufactureMonitor.ProblemAccumulation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table  style="border: thin solid #FFAF37; width: 100%; text-align:center; height: 300px;">
        <tr>
            <td colspan="4" style="background-color: #FFFFCC; height: 32px; text-align: center;"><strong>
                <asp:TextBox ID="TextBox1" runat="server" Height="30px" style="font-weight: bold; font-size: medium; margin-left: 201px" Width="550px">                              Stop time problem accumulation - all shifts</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" OnClick="ImageButton1_Click" Width="25px" style="margin-left: 0px" />
                </strong>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="background-color: #FFFFCC; height: 32px;">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 115px">&nbsp;</td>
            <td>
                <table  style="border: thin solid #FFAF37; width: 78%; text-align:center; height: 287px;" align="center">
                    <tr>
                        <td colspan="5" style="background-color: #FFAF37; height: 32px; text-align: left;"><strong style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Selection Parameters</strong></td>
                    </tr>
                    <tr>
                         <td style="height: 23px; width: 105px">Machines:</td>
                         <td style="height: 23px; width: 307px;">Date From:</td>
                         <td style="height: 23px; width: 271px;">Date To:</td>
                         <td style="height: 23px; width: 167px;">Shifts:</td>
                         <td style="height: 23px; width: 321px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 105px; height: 42px">
                            <asp:ListBox ID="MachineSelectionListBox" runat="server" Height="150px" OnSelectedIndexChanged="MachineSelectionListBox_SelectedIndexChanged"
                                 Width="200px" AutoPostBack="true"></asp:ListBox>
                        </td>
                        <td style="height: 42px; width: 307px;">
                            <asp:Calendar ID="datefrom" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" 
                                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="140px"  Width="195px" style="margin-left: 28px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#FFAF37" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                
                            </asp:Calendar>
                        </td>
                        <td style="height: 42px; width: 271px;">
                            <asp:Calendar ID="dateto" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px"
                                 DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="140px"  Width="195px" style="margin-left: 8px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#FFAF37" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                
                            </asp:Calendar>
                        </td>
                        <td style="height: 42px; width: 167px;">
                           
                            <asp:ListBox ID="ShiftSelectionListBox" runat="server" Height="150px" Width="150px" style="margin-left: 15px"></asp:ListBox>
                        </td>
                        <td style="height: 42px; width: 321px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 67px">
                            <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="2px" Text="Show" Height="45px" Width="80px" OnClick="Button1_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" ImageAlign="AbsBottom" ImageUrl="~/Images/excelicon.jpg" OnClick="ImageButton2_Click" Width="40px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="PieGraph" runat="server" Height="40px" ImageAlign="AbsBottom" ImageUrl="~/Images/pie_chart_yellow.png"  OnClick="PieGraph_Click" Width="40px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="height: 1px; text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left; height: 29px; width: 400px;">&nbsp;</td>
            <td style="text-align: left; height: 29px;">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
