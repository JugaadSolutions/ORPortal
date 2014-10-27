<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TimeSequence1.aspx.cs" Inherits="ManufactureMonitor.TimeSequence1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table  style=" width: 1200px; text-align:center; height: 300px;">
        <tr>
            <td colspan="2" style="background-color: #FFFFCC; height: 32px; ">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server" Width="455px" BorderColor="#333333" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" ForeColor="Black" Height="20px" style="font-size: medium; margin-left: 0px;"> Stop Times- Times sequence of machine stop times</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" OnClick="ImageButton1_Click" Width="25px" />
            </td>
            <td colspan="2" style="background-color: #FFFFCC; height: 32px; width: 268435456px;">
                &nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style="background-color: #FFFFCC; height: 32px; text-align: left;">    
        <tr>
            <td style="background-color: #FFFFCC; height: 32px; ">
                <table  style="border: thin solid #FFAF37; width: 91%; text-align:center; height: 287px; margin-left: 108px;" align="left">
                    <tr>
                        <td colspan="5" style="background-color: #FFAF37; height: 32px; text-align: left;"><strong style="text-align: left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Selection Parameters</strong></td>
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
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
                                BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" 
                                Height="140px"  Width="195px" style="margin-left: 28px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#FFAF37" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                
                            </asp:Calendar>
                        </td>
                        <td style="height: 42px; width: 271px;">
                            <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" 
                                BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" 
                                Height="140px"  Width="195px" style="margin-left: 8px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#FFAF37" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                               
                            </asp:Calendar>
                        </td>
                        <td style="height: 42px; width: 167px;">
                           
                            <asp:ListBox ID="ShiftSelectionListBox" runat="server" Height="150px" Width="150px"></asp:ListBox>
                        </td>
                        <td style="height: 42px; width: 321px;">
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="16px" Width="166px">
                                <asp:ListItem>Project Summary</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 1px; ">
                            <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="2px" Text="Show" Height="45px" Width="80px" OnClick="Button1_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                </table>
            </td>
        </tr>
        
            </td>
            <td colspan="2" style="background-color: #FFFFCC; height: 32px; text-align: left;">&nbsp;</td>
            <td style="background-color: #FFFFCC; height: 32px; text-align: left; width: 268435456px;">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left"></td>
        </tr>
    </table>
</asp:Content>
