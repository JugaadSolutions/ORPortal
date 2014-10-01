<%@ Page Title="Index Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ManufactureMonitor.Index" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <table style="width: 99%; border-collapse: collapse; background-color: #FFFFCC; height: 407px; margin-top: 0em; margin-right: 0px; " align="center">
    <tr>
        <td style="width: 1044px; height: 428px;">
            <table style="border: 3px solid #CC6666; width: 938px; border-collapse: collapse; margin-left: 167px; margin-top: 0em; height: 426px;">
                <tr>
                    <td style="width: 117px; text-align: center;" rowspan="7">&nbsp;</td>
                    <td style="text-align: center; height: 23px;" colspan="2"></td>
                    <td style="height: 23px; width: 1103px; text-align: center;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="background-color: #FFCC66; height: 68px; text-align: center;" colspan="2">
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" ForeColor="Black" Height="34px"  Width="414px" Font-Bold="True" style="margin-left: 0px">                                    Machine Groups</asp:TextBox>
                    </td>
                    <td style="width: 1103px; text-align: center; height: 68px;">
                        
                            <asp:TextBox ID="TextBox2" runat="server" BorderColor="#CC0000" BorderStyle="Solid" BorderWidth="3px" ForeColor="Black" Height="34px"  Width="235px" Font-Bold="True" style="margin-left: 0px">                      Problems</asp:TextBox>
                        
                       
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCC66; width: 434px; height: 89px; text-align:center">
                        <div id="Div1" onmouseover="Dark('Div1')" onmouseout="Light('Div1')" style="position:absolute; width: 182px; height: 45px; margin-left: 3px; top: 218px; left: 265px;">
                        <asp:Button ID="Button1"  runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Text="Che" Width="182px" Font-Names="Arial" Height="45px" style="margin-top: 0px" OnClick="Button1_Click" />
                            </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td style="background-color: #FFCC66; width: 243px; height: 89px; text-align:center">
                         <div id="Div2" onmouseover="Dark('Div2')" onmouseout="Light('Div2')"style="position:absolute; width: 182px; height: 45px; margin-left: 3px; top: 219px; left: 492px;">
                        <asp:Button ID="Button2" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Text="TubeFinal" Width="182px" Font-Names="Arial" Height="45px" style="margin-top:0px; margin-left: 0px;" OnClick="Button2_Click" />
                    </div>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    <td style="width: 1103px; text-align: center; height: 89px;">
                        <div id="Div3" onmouseover="Dark('Div3')" onmouseout="Light('Div3')"style="position:absolute; width: 235px; height: 45px; margin-left: 3px; text-align: center; top: 215px; left: 780px;">
                        <asp:Button ID="Button4" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Font-Size="Small" Height="45px" Text="Common Problems-Setting" Width="235px" Font-Names="Arial" style="margin-top:0px; margin-left: 0px;" OnClick="Button4_Click"  />
                   </div> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCC66; text-align: center; height: 48px; width: 434px;">
                        <div id="Div4" onmouseover="Dark('Div4')" onmouseout="Light('Div4')"style="position:absolute; width: 182px; height: 45px; margin-left: 3px; top: 271px; left: 262px; margin-top: 0px;">
                        <asp:Button ID="Button3" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Text="AirCleaner" Width="182px" Font-Names="Arial" Height="45px" style="margin-top:0px" OnClick="Button3_Click"/>
                   </div> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <br />
                    </td>
                    <td style="background-color: #FFCC66; text-align: center; height: 48px; width: 243px;"></td>
                    <td style="width: 1103px; text-align: center; height: 48px;">
                         <div id="Div5" onmouseover="Dark('Div5')" onmouseout="Light('Div5')"style="position:absolute; width: 235px; height: 45px; margin-left: 3px; top: 275px; left: 781px;">
                        <asp:Button ID="Button5" runat="server" BackColor="#FF9966" BorderColor="#CC6666" BorderStyle="Solid" BorderWidth="3px" Text="Common Problems-Display" Width="235px" Font-Names="Arial" Height="45px" style="margin-top:0px; margin-left: 0px;" OnClick="Button5_Click" />
                        </div> </td>
                </tr>
                <tr>
                    <td style="background-color: #FFCC66; text-align: center;" colspan="2">&nbsp;</td>
                    <td style="width: 1103px; text-align: center;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="background-color: #FFCC66; height: 17px; text-align: center;" colspan="2"></td>
                    <td style="width: 1103px; height: 17px;"></td>
                </tr>
                <tr>
                    <td style="text-align: center; height: 39px;" colspan="2"></td>
                    <td style="height: 39px; width: 1103px;"></td>
                </tr>
                </table>
        </td>
    </tr>
</table>
    
</asp:Content>
