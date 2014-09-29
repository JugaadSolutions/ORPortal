<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ManufactureMonitor.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="border: 3px solid #CC6666; width: 85%; border-collapse: collapse; background-color: #FFFFCC; height: 660px; margin-left: 83px;">
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">&nbsp;</td>
            <td style="width: 490px; text-align: center">&nbsp;</td>
            <td style="text-align: center; width: 399px;">&nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="230px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True">                 Shift Data</asp:TextBox>
            </td>
            <td style="width: 490px; text-align: center">
                <asp:TextBox ID="TextBox2" runat="server" Height="34px" Width="230px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" style="margin-left:63px">                   Settings</asp:TextBox>
            </td>
            <td style="text-align: center; width: 399px;">
                <asp:TextBox ID="TextBox3" runat="server" Height="34px" Width="230px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True">                Parameters</asp:TextBox>
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px; height: 45px;">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td style="text-align: center; width: 517px; height: 45px;">
                 <div id="Div1" onmouseover="Dark('Div1')" onmouseout="Light('Div1')" style="width: 230px; height: 45px; margin-left: 61px">
                <asp:Button ID="Button1" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Actual State" Width="230px" style="margin-top:0px; margin-left: 0px; margin-right: 0px;" OnClick="Button1_Click"/>
            &nbsp;&nbsp;
           </div> 
            </td>
            <td style="width: 490px; text-align: center; height: 45px;">
                <div id="Div2" onmouseover="Dark('Div2')" onmouseout="Light('Div2')" style="width: 230px; height: 45px; margin-left: 37px; text-align:center">
                <asp:Button ID="Button2" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Project Assignment" Width="230px" OnClick="Button2_Click" style="margin-left: 0px; margin-right: 0px" />
            </div></td>
            <td style="text-align: center; width: 399px; height: 45px;">
                <asp:Button ID="Button3" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Parameter Setting" Width="230px" OnClick="Button3_Click" />
            </td>
            <td style="height: 45px"></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">
                <asp:Button ID="Button4" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Shift Histroy" Width="230px" OnClick="Button4_Click" />
            </td>
            <td style="width: 490px; text-align: center">
                <asp:Button ID="Button5" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Machines OFF Setting" Width="230px" OnClick="Button5_Click" />
            </td>
            <td style="text-align: center; width: 399px;">
                <asp:Button ID="Button6" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Parameters-Display" Width="230px" OnClick="Button6_Click" />
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">
                <asp:Button ID="Button7" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Scarps" Width="230px" OnClick="Button7_Click" />
            </td>
            <td rowspan="2" style="width: 490px; text-align: center">
                <asp:TextBox ID="TextBox4" runat="server" Height="34px" Width="230px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True">                   Projects</asp:TextBox>
            </td>
            <td rowspan="2" style="text-align: center; width: 399px;">
                <asp:TextBox ID="TextBox5" runat="server" Height="34px" Width="230px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True">                    Shifts</asp:TextBox>
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">
                <asp:Button ID="Button8" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="OR and MOR accumulation" Width="230px" OnClick="Button8_Click" />
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">
                <asp:Button ID="Button9" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Project Summary" Width="230px" OnClick="Button9_Click" />
            </td>
            <td style="width: 490px; text-align: center">
                <asp:Button ID="Button10" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Projects-Setting" Width="230px" OnClick="Button10_Click" />
            </td>
            <td style="text-align: center; width: 399px;">
                <asp:Button ID="Button11" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Shift Definition-Setting" Width="230px" OnClick="Button11_Click"/>
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">
                <asp:TextBox ID="TextBox6" runat="server" Height="34px" Width="230px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True">                Stop Times</asp:TextBox>
            </td>
            <td style="width: 490px; text-align: center">
                <asp:Button ID="Button12" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Projects-Display" Width="230px" OnClick="Button12_Click" />
            </td>
            <td style="text-align: center; width: 399px;">
                <asp:Button ID="Button13" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Shift Definition-Display" Width="230px" OnClick="Button13_Click" />
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; height: 62px; width: 10px;"></td>
            <td style="text-align: center; height: 62px; width: 517px;">
                <asp:Button ID="Button14" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Time sequence" Width="230px" OnClick="Button14_Click" />
            </td>
            <td style="width: 490px; text-align: center; height: 62px;">
                <asp:TextBox ID="TextBox7" runat="server" Height="34px" Width="230px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True">                  Problems</asp:TextBox>
            </td>
            <td style="text-align: center; height: 62px; width: 399px;">
                <asp:Button ID="Button17" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Inputs from machines" Width="230px" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">
                <asp:Button ID="Button15" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Enter problem code,comment" Width="230px" OnClick="Button15_Click" />
            </td>
            <td style="width: 490px; text-align: center">
                <asp:Button ID="Button18" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Stop Problems-Setting" Width="230px" OnClick="Button18_Click" />
            </td>
            <td style="text-align: center; width: 399px;">
                <asp:Button ID="Button19" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Password Change" Width="230px" OnClick="Button19_Click" />
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">
                <asp:Button ID="Button16" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Problem accumulation" Width="230px" OnClick="Button16_Click" />
            </td>
            <td style="width: 490px; text-align: center">
                <asp:Button ID="Button20" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="45px" Text="Stop Problems-Display" Width="230px" OnClick="Button20_Click" />
            </td>
            <td style="text-align: center; width: 399px;">&nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 10px;">&nbsp;</td>
            <td style="text-align: center; width: 517px;">&nbsp;</td>
            <td style="width: 490px; text-align: center">&nbsp;</td>
            <td style="text-align: center; width: 399px;">&nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        </table>
</asp:Content>
