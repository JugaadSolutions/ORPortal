<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftHistroy1.aspx.cs" Inherits="ManufactureMonitor.ShiftHistroy1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; background-color: #FFFFCC">
        <tr>
            <td style="width: 133px; height: 64px;"></td>
            <td style="text-align: center; width: 968px; height: 64px;">
               
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox3" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Height="35px" Width="456px" style="font-size: large">              Shift history - production in the shifts</asp:TextBox>
                
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
                
            </td>
            <td style="height: 64px"></td>
        </tr>
        <tr>
            <td style="width: 133px">&nbsp;</td>
            <td style="text-align: center; width: 968px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 133px; text-align: center">&nbsp;</td>
            <td style="text-align: center; width: 968px">
                <table  style="border: thin solid #FFAF37; width: 102%; text-align:center; height: 201px;">
                    <tr>
                        <td colspan="5" style="background-color: #FFAF37; height: 32px;"><strong>Selection Parameters</strong></td>
                    </tr>
                    <tr>
                         <td style="height: 23px; width: 105px">Machines:</td>
                         <td style="height: 23px; width: 176px;">Date From:</td>
                         <td style="height: 23px; width: 396px;">Date To:</td>
                         <td style="height: 23px; width: 398px;">Shifts:</td>
                         <td style="height: 23px; width: 276px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 105px; height: 42px">
                            <asp:ListBox ID="MachineSelectionListBox" runat="server" Height="150px" OnSelectedIndexChanged="MachineSelectionListBox_SelectedIndexChanged"
                                 Width="200px" AutoPostBack="true"></asp:ListBox>
                        </td>
                        <td style="height: 42px; width: 176px;">
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
                                BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="140px" 
                                 Width="185px" style="margin-left: 9px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#FFAF37" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                

                            </asp:Calendar>
                        </td>
                        <td style="height: 42px; width: 396px;">
                            <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" 
                                BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="140px" 
                                 Width="195px" style="margin-left: 18px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#FFAF37" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                
                            </asp:Calendar>
                        </td>
                        <td style="height: 42px; width: 398px; margin-left:10px">
                           <asp:ListBox ID="ShiftSelectionListBox" runat="server" Height="150px" Width="150px"
                               style="margin-left:29px" ></asp:ListBox>
                        </td>
                        <td style="height: 42px; width: 276px;">
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="16px" Width="166px">
                                <asp:ListItem>Project Summary</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 97px">
                            <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="2px" Text="Show" Height="45px" Width="80px" OnClick="Button1_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" ImageUrl="~/Images/excelicon.jpg" OnClick="ImageButton2_Click" Width="40px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                </table>
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 133px">&nbsp;</td>
            <td style="text-align: center; width: 968px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 133px">&nbsp;</td>
            <td style="text-align: center; width: 968px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 133px">&nbsp;</td>
            <td style="text-align: center; width: 968px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 133px">&nbsp;</td>
            <td style="text-align: center; width: 968px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 133px">&nbsp;</td>
            <td style="text-align: center; width: 968px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
