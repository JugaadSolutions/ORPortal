<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ORandMOR1.aspx.cs" Inherits="ManufactureMonitor.ORandMOR1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table  style="border: thin solid #FFAF37; width: 100%; text-align:center; height: 381px;">
        <tr>
            <td colspan="3" style="background-color: #FFFFCC; height: 12px;"><strong>
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Height="31px" style="font-size: medium; font-weight: bold; margin-left: 0px" Width="600px">                                             Project summary - all shifts</asp:TextBox>
                </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="background-color: #FFFFCC; height: 32px; text-align: left; width: 116px;"></td>
            <td style="background-color: #FFFFCC; height: 32px; text-align: left;">
                <table  style="border: thin solid #FFAF37; width: 78%; text-align:center; height: 287px;" align="left">
                    <tr>
                        <td colspan="5" style="background-color: #FFAF37; height: 32px; text-align: left;"><strong style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Selection Parameters</strong></td>
                    </tr>
                    <tr>
                         <td style="height: 23px; width: 105px">Machines:</td>
                         <td style="height: 23px; width: 260px;">Date From:</td>
                         <td style="height: 23px; width: 271px;">Date To:</td>
                         <td style="height: 23px; width: 167px;">Shifts:</td>
                         <td style="height: 23px; width: 321px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 105px; height: 42px">
                            <asp:ListBox ID="MachineSelectionListBox" runat="server" Height="150px" OnSelectedIndexChanged="MachineSelectionListBox_SelectedIndexChanged"
                                 Width="200px" AutoPostBack="true"></asp:ListBox>
                        </td>
                        <td style="height: 42px; width: 260px;">
                            <asp:Calendar ID="datefrom" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest"
                                 Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="140px"  Width="195px" style="margin-left: 28px">
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
                           
                            <asp:ListBox ID="ShiftSelectionListBox" runat="server" Height="150px" Width="150px" style="margin-left: 11px"></asp:ListBox>
                        </td>
                        <td style="height: 42px; width: 321px;">
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="16px" Width="166px">
                                <asp:ListItem>Project Summary</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 70px; ">
                            <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="2px" Text="Show" Height="45px" Width="80px" OnClick="Button1_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" ImageAlign="AbsBottom" ImageUrl="~/Images/excelicon.jpg" OnClick="ImageButton2_Click" Width="40px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                </table>
            </td>
            <td style="background-color: #FFFFCC; height: 32px; text-align: left;"></td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="height: 81px">
                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
