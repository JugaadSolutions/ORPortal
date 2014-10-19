<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scrap1.aspx.cs" Inherits="ManufactureMonitor.Scrap1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; background-color: #FFFFCC;">
        <tr>
            <td>
                <table style="width: 100%; border-collapse: collapse">
                    <tr>
                        <td style="width: 174px">&nbsp;</td>
                        <td colspan="5" style="text-align: center; ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="600px" style="font-size: medium" Height="33px">                                               Production -Scraps Report</asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td style="text-align: center">&nbsp; <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
                                        </td>
                    </tr>
                    <tr>
                        <td style="width: 174px; height: 23px;"></td>
            <td style="background-color: #FFFFCC; color: #FFFFFF; font-size: medium; text-align: center; height: 23px;" colspan="5"></td>
                        <td style="height: 23px"></td>
                    </tr>
                    <tr>
                        <td style="width: 174px">&nbsp;</td>
                        <td style="width: 241px; background-color: #FFFFCC;">Machine/Line:</td>
                        <td style="width: 200px; background-color: #FFFFCC;">Date From:</td>
                        <td style="width: 214px; background-color: #FFFFCC;">Date To:</td>
                        <td style="background-color: #FFFFCC;" colspan="2">Shift:</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 174px; height: 135px;"></td>
                        <td style="width: 241px; background-color: #FFFFCC; height: 135px;">
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="40px" Width="162px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 200px; background-color: #FFFFCC; text-align: center; height: 135px;">
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="100px" Width="160px" style="margin-left: 18px" ShowGridLines="True">
                                <DayHeaderStyle BackColor="#FFCC66" Height="1px" Font-Bold="True" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#FFAF37" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                        </td>
                        <td style="width: 214px; background-color: #FFFFCC; text-align: center; height: 135px;">
                            <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="100px" Width="160px" style="margin-left: 18px" ShowGridLines="True">
                                <DayHeaderStyle BackColor="#FFCC66" Height="1px" Font-Bold="True" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#FFAF37" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                        </td>
                        <td style="width: 244px; background-color: #FFFFCC; height: 135px;">
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="40px" Width="162px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 60px; background-color: #FFFFCC; height: 135px;">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show" />
                        </td>
                        <td style="height: 135px"></td>
                    </tr>
                    <tr>
                        <td style="width: 174px">&nbsp;</td>
                        <td style="width: 241px; background-color: #FFFFCC;">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Project Summary" />
                        </td>
                        <td style="width: 200px; background-color: #FFFFCC;">&nbsp;</td>
                        <td style="width: 214px; background-color: #FFFFCC;">&nbsp;</td>
                        <td style="background-color: #FFFFCC;" colspan="2">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 174px">&nbsp;</td>
                        <td colspan="5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
