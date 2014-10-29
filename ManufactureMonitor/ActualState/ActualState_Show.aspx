<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualState_Show.aspx.cs" Inherits="ManufactureMonitor.ActualState_Show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <asp:Panel runat="server" ID="MainPanel" Height="100%" Width="100%" HorizontalAlign="Center" >
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="5000" />
        <table style="width: 800px; border-collapse: collapse; height: 500px; background-color: #000000; 
                    text-align:center; margin-bottom: 4px;" align="center" >
        <tr>
            <td style="height: 50px; text-align: left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="ProjectTextBox" runat="server" BackColor="Silver" BorderColor="White" 
                    BorderStyle="Inset" BorderWidth="3px" Enabled="False" 
                    Font-Bold="True" ForeColor="Black" Font-Size="XX-Large" Height="40px" Width="608px"
                     style="text-align:center"></asp:TextBox>
                &nbsp;
                <asp:TextBox ID="SystimeTextBox" runat="server" BackColor="Lime" BorderColor="White" 
                    BorderStyle="Inset" BorderWidth="3px" Enabled="False" Font-Bold="True" 
                    Font-Size="XX-Large" ForeColor="Black" Height="40px" Width="120px" style="text-align:center"></asp:TextBox>
            </td>
        </tr>
            <tr>
                <td style="height: 20px; text-align: left" colspan="2">
                    <asp:Label ID="TimeIntervalLabel" runat="server" style="color: #FFFFFF; font-size: medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 110px; text-align: left;" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="SessionPlanTextBox" runat="server" BackColor="Black" BorderColor="White" BorderStyle="Solid" BorderWidth="3px" Enabled="False" Font-Bold="True" Font-Size="60pt" ForeColor="White" Height="100px" Width="300px" style="text-align:center"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="SessionActualTextBox" runat="server" BackColor="Black" BorderColor="White" BorderStyle="Solid" BorderWidth="3px" Enabled="False" Font-Bold="True" Font-Size="60pt" ForeColor="Yellow" Height="100px" Width="300px" style="text-align:center"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 130px; width: 473px;">
                    <asp:TextBox ID="TextBox7" runat="server" BackColor="Black" BorderColor="Black" BorderStyle="Solid" BorderWidth="0px" Enabled="False" Font-Bold="True" Font-Size="80pt" ForeColor="White" Height="100%" style="text-align: center" Width="400px">100%</asp:TextBox>
                </td>
                <td style="height: 130px">
                    <asp:Image ID="SessionSmiley" runat="server" Height="150px" ImageAlign="Middle" Width="150px" ImageUrl="~/Images/GREEN_SMILEY.png" />
                </td>
            </tr>
            <tr>
                <td runat="server" id="PointerCell" style="height: 40px; text-align:left " colspan="2">
                    
                    <div runat="server" id="div1" >
                    
                    <asp:Image ID="Pointer" runat="server" Height="40px"  ImageAlign="Middle" ImageUrl="~/Images/greenTriangle.PNG" Width="40px" 
                         />
                      </div>  
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 30px; text-align: left;">
                    <asp:Label ID="RedTextBox" runat="server" BackColor="Red" 
                        BorderColor="Red" Enabled="False" Height="30px" 
                        style="text-align:center" Width="120px" />
                    <asp:Label ID="OrangeTextBox" runat="server" BackColor="OrangeRed" 
                        BorderColor="OrangeRed" Enabled="False"  Height="30px" 
                        style="text-align:center" Width="120px" />
                    <asp:Label ID="GreenTextBox" runat="server" BackColor="Lime" 
                        BorderColor="Lime" Enabled="False"  Height="30px" 
                        style="text-align:center; " Width="120px" />
                </td>
            </tr>
            <tr>
                <td style="height: 17px; text-align: left" colspan="2">
                    <asp:Label ID="ShiftLabel" runat="server" style="color: #FFFFFF; font-size: medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox5" runat="server" BackColor="Black" BorderColor="White" BorderStyle="Solid" BorderWidth="2px" Enabled="False" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Height="40px" Width="120px" style="text-align:center">P</asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server" BackColor="Black" BorderColor="White" BorderStyle="Solid" BorderWidth="2px" Enabled="False" Font-Bold="True" Font-Size="X-Large" ForeColor="#FFFF66" Height="40px" Width="120px" style="text-align:center">A</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="ShiftORLabel" runat="server" style="color: #FFFFFF; font-size: x-large" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="40px" Width="50px">70%</asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="ShiftSmiley" runat="server" Height="50px" Width="50px" ImageAlign="Top" ImageUrl="~/Images/GREENSMILEY_small.PNG" />
                </td>
            </tr>
    </table>
                        </ContentTemplate>
                    
                    </asp:UpdatePanel>
        </asp:Panel>
        </div>
    
</asp:Content>
