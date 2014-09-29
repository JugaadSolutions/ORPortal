<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scrap1.aspx.cs" Inherits="ManufactureMonitor.Scrap1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; background-color: #FFFFCC;">
        <tr>
            <td>
                <table style="width: 100%; border-collapse: collapse">
                    <tr>
                        <td style="width: 87px">&nbsp;</td>
                        <td colspan="4" style="text-align: center; "><asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="600px" style="font-size: medium" Height="33px">                                               Production - enter scraps</asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td style="text-align: center">&nbsp; <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
                                        </td>
                    </tr>
                    <tr>
                        <td style="width: 87px">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; " colspan="4">Selection Parameters</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 87px">&nbsp;</td>
                        <td style="width: 363px; background-color: #99CCFF;">Machine:</td>
                        <td style="width: 368px; background-color: #99CCFF;">Date:</td>
                        <td style="background-color: #99CCFF;" colspan="2">Shift:</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 87px">&nbsp;</td>
                        <td style="width: 363px; background-color: #99CCFF;">
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="40px" Width="162px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 368px; background-color: #99CCFF; text-align: center;">
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="100px" Width="160px" style="margin-left: 18px">
                                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                <WeekendDayStyle BackColor="#CCCCFF" />
                            </asp:Calendar>
                        </td>
                        <td style="width: 324px; background-color: #99CCFF;">
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="40px" Width="162px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 177px; background-color: #99CCFF;">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 87px">&nbsp;</td>
                        <td style="width: 363px; background-color: #99CCFF;">&nbsp;</td>
                        <td style="width: 368px; background-color: #99CCFF;">&nbsp;</td>
                        <td style="background-color: #99CCFF;" colspan="2">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 87px">&nbsp;</td>
                        <td colspan="4">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
