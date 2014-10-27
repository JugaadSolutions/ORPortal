<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ManufactureMonitor.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="border: 3px solid #CC6666; width: 100%; border-collapse: collapse; background-color: #FFFFCC; height: 400px; margin-left: 1%;">
        <tr>
            <td style="text-align: center; width: 303px; height: 38px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="200px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Enabled="False">                 Shift Data</asp:TextBox>
            </td>
            <td style="width: 313px; text-align: center; height: 38px;">
                <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="200px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" style="margin-left:13px" Enabled="False">                   Settings</asp:TextBox>
            </td>
            <td style="text-align: left; width: 399px; height: 38px;">
                <asp:TextBox ID="TextBox3" runat="server" Height="30px" Width="200px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Enabled="False">                Parameters</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 303px; height: 3px;">
                 <div id="Div1" onmouseover="Dark('Div1')" onmouseout="Light('Div1')" style="width: 200px; height: 30px; margin-left: 90px">
                <asp:Button ID="Button1" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Actual State" Width="200px" style="margin-top:0px; margin-left: 0px; margin-right: 0px;" OnClick="Button1_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;
           </div> 
            </td>
            <td style="width: 313px; text-align: center; height: 3px;">
                <div id="Div2" onmouseover="Dark('Div2')" onmouseout="Light('Div2')" style="width: 200px; height: 30px; margin-left: 71px; text-align:center">
                <asp:Button ID="Button2" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Project Assignment" Width="200px" OnClick="Button2_Click" style="margin-left: 0px; margin-right: 0px" />
            &nbsp;
            </div></td>
            <td style="text-align: center; width: 399px; height: 3px;">
                <div id="Div3" onmouseover="Dark('Div3')" onmouseout="Light('Div3')" style="width: 200px; height: 30px; margin-left: 6px; text-align:center">
                <asp:Button ID="Button3" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Parameter Setting" Width="200px" OnClick="Button3_Click" style="margin-left: 0px" />
            </div></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 303px; height: 1px;">
                <div id="Div4" onmouseover="Dark('Div4')" onmouseout="Light('Div4')" style="width: 200px; height: 30px; margin-left: 91px; text-align:center">
                <asp:Button ID="Button4" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Shift Histroy" Width="200px" OnClick="Button4_Click" style="margin-left: 0px" />
                </div>
            </td>
            <td style="width: 313px; text-align: center; height: 1px;">
                <div id="Div5" onmouseover="Dark('Div5')" onmouseout="Light('Div5')" style="width: 200px; height: 30px; margin-left: 74px; text-align:center">
                <asp:Button ID="Button5" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Machines OFF Setting" Width="200px" OnClick="Button5_Click" />
            </div></td>
            <td style="text-align: left; width: 399px; height: 1px;">
                &nbsp;&nbsp;
                <div id="Div6" onmouseover="Dark('Div6')" onmouseout="Light('Div6')" style="width: 200px; height: 30px; margin-left: 6px; text-align:center">
                <asp:Button ID="Button6" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Parameters-Display" Width="200px" OnClick="Button6_Click" />
           </div> </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 303px; height: 38px;">
                <div id="Div7" onmouseover="Dark('Div7')" onmouseout="Light('Div7')" style="width: 200px; height: 30px; margin-left: 93px; text-align:center">
                <asp:Button ID="Button7" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Scraps" Width="200px" OnClick="Button7_Click" style="margin-left: 0px" />
            </div></td>
            <td rowspan="2" style="width: 313px; text-align: center">
                &nbsp;&nbsp;
                <asp:TextBox ID="TextBox4" runat="server" Height="30px" Width="200px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" style="margin-left: 3px" Enabled="False">                   Projects</asp:TextBox>
            </td>
            <td rowspan="2" style="text-align: left; width: 399px;">
                <asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="200px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Enabled="False">                    Shifts</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 303px; height: 2px;">
                <div id="Div8" onmouseover="Dark('Div8')" onmouseout="Light('Div8')" style="width: 200px; height: 30px; margin-left: 96px; text-align:center">
                <asp:Button ID="Button8" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="OR and OA accumulation" Width="200px" OnClick="Button8_Click" style="margin-left: 0px" />
            </div></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 303px; height: 22px;">
                <div id="Div9" onmouseover="Dark('Div9')" onmouseout="Light('Div9')" style="width: 200px; height: 30px; margin-left: 94px; text-align:center">
                <asp:Button ID="Button9" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Summary Report" Width="201px" OnClick="Button9_Click" />
            </div></td>
            <td style="width: 313px; text-align: center; height: 22px;">
                <div id="Div10" onmouseover="Dark('Div10')" onmouseout="Light('Div10')" style="width: 200px; height: 30px; margin-left: 69px; text-align:center">
                <asp:Button ID="Button10" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Projects-Setting" Width="200px" OnClick="Button10_Click" style="margin-left: 0px" />
            </div></td>
            <td style="text-align: left; width: 399px; height: 22px;">
                <div id="Div11" onmouseover="Dark('Div11')" onmouseout="Light('Div11')" style="width: 200px; height: 30px;  text-align:left">
                <asp:Button ID="Button11" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" 
                    Text="Shift Definition-Setting" Width="200px" OnClick="Button11_Click"/>
           </div> 

            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 303px; height: 26px;">
                <asp:TextBox ID="TextBox6" runat="server" Height="30px" Width="200px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" style="margin-left: 86px" Enabled="False">                Stop Times</asp:TextBox>
            </td>
            <td style="width: 313px; text-align: center; height: 26px;">
                <div id="Div12" onmouseover="Dark('Div12')" onmouseout="Light('Div12')" style="width: 200px; height: 30px; margin-left: 67px; text-align:center">
                <asp:Button ID="Button12" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Projects-Display" Width="200px" OnClick="Button12_Click" style="margin-left: 0px" />
            </div></td>
            <td style="text-align: left; width: 399px; height: 26px;">
                <div id="Div13" onmouseover="Dark('Div13')" onmouseout="Light('Div13')" style="width: 200px; height: 30px; margin-left: 6px; text-align:center">
                <asp:Button ID="Button13" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Shift Definition-Display" Width="200px" OnClick="Button13_Click" />
            </div></td>
        </tr>
        <tr>
            <td style="text-align: center; height: 30px; width: 303px;">
                <div id="Div14" onmouseover="Dark('Div14')" onmouseout="Light('Div14')" style="width: 200px; height: 30px; margin-left: 95px; text-align:center">
                <asp:Button ID="Button14" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Time sequence" Width="200px" OnClick="Button14_Click" style="margin-left: 0px" />
            </div></td>
            <td style="width: 313px; text-align: center; height: 30px;">
                <asp:TextBox ID="TextBox7" runat="server" Height="30px" Width="200px" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" style="margin-left: 7px" Enabled="False">                  Problems</asp:TextBox>
            </td>
            <td style="text-align: left; height: 30px; width: 399px;">
                <div id="Div15" onmouseover="Dark('Div15')" onmouseout="Light('Div15')" style="width: 200px; height: 30px; margin-left: 6px; text-align:center">
                <asp:Button ID="Button17" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Inputs from machines" Width="200px" style="margin-left: 0px" OnClick="Button17_Click" />
            </div></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 303px; height: 41px;">
                <div id="Div16" onmouseover="Dark('Div16')" onmouseout="Light('Div16')" style="width: 200px; height: 30px; margin-left: 95px; text-align:center">
                <asp:Button ID="Button15" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Enter problem code,comment" Width="200px" OnClick="Button15_Click" style="margin-left: 0px" />
             </div></td>
            <td style="width: 313px; text-align: center; height: 41px;">
                <div id="Div17" onmouseover="Dark('Div17')" onmouseout="Light('Div17')" style="width: 200px; height: 30px; margin-left: 64px; text-align:center">
                <asp:Button ID="Button18" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Stop Problems-Setting" Width="200px" OnClick="Button18_Click" style="margin-left: 0px" />
            </div></td>
            <td style="text-align: center; width: 399px; height: 41px;">
                <div id="Div18" onmouseover="Dark('Div18')" onmouseout="Light('Div18')" style="width: 200px; height: 30px; margin-left: 6px; text-align:center">
                <asp:Button ID="Button19" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Password Change" Width="200px" OnClick="Button19_Click" />
            </div></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 303px; height: 48px;">
                <div id="Div19" onmouseover="Dark('Div19')" onmouseout="Light('Div19')" style="width: 199px; height: 30px; margin-left: 94px; text-align:center">
                <asp:Button ID="Button16" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Problem accumulation" Width="200px" OnClick="Button16_Click" style="margin-left: 0px" />
           </div> </td>
            <td style="width: 313px; text-align: center; height: 48px;">
                <div id="Div20" onmouseover="Dark('Div20')" onmouseout="Light('Div20')" style="width: 200px; height: 30px; margin-left: 67px; text-align:center">
                <asp:Button ID="Button20" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Height="30px" Text="Stop Problems-Display" Width="200px" OnClick="Button20_Click" style="margin-left: 0px" />
            </div></td>
            <td style="text-align: center; width: 399px; height: 48px;"></td>
        </tr>
        </table>
</asp:Content>
