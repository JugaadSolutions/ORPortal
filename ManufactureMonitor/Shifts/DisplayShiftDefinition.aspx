<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayShiftDefinition.aspx.cs" Inherits="ManufactureMonitor.DisplayShiftDefinition" %>
<asp:Content ID="Content1"  ContentPlaceHolderID="MainContent" runat="server" >
     <div style="height:100%">
               <asp:Panel runat="server" ID="MainPanel" ScrollBars="Auto" height="100%">
    <table style="width: 130%; background-color: #FFFFCC; margin-right: 4px;">
        <tr>
            <td style=" width: 1086px;">
                
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Width="600px" Height="32px" style="font-size: medium; 
font-weight: bold; margin-left: 337px;">                           Representation of shift definitions - Condenser </asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="BackButton" runat="server" ImageUrl="~/Images/return.jpg" ImageAlign="Middle" OnClick="BackButton_Click" CssClass="auto-style4" Height="25px" Width="25px" style="margin-left: 0px" />
                
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 1086px; " >
                <table style="width: 800px; border-collapse:collapse; background-color: #FF9966; height: 20px; margin-bottom: 0px; margin-left: 304px; border-color:#663300; border-style:solid; border-width:2px;" >
                    <tr style="color: #FFFFFF"  >
                        <td style="border: thin solid #DEBA84; height: 20px; " colspan="2" >Shifts</td>
                        <td style="border: thin solid #DEBA84; height: 20px; width: 32px; " colspan="2">1st Rest</td>
                        <td style="border: thin solid #DEBA84; height: 20px; width: 32px; " colspan="2">2nd Rest</td>
                        <td style="border: thin solid #DEBA84; height: 20px; width: 32px; " colspan="2">3rd Rest</td>
                        <td style="border: thin solid #DEBA84; height: 20px; width: 32px; " colspan="2">4th Rest</td> 
                        <td style="border: thin solid #DEBA84; height: 20px; width: 32px; " colspan="2">5th Rest</td>
                        <td style="border: thin solid #DEBA84; height: 20px; width: 281px; " colspan="7"> Day of Shift Beginning</td>
                    </tr>
                     </table>
            </td>
            </tr>
        <tr>
                    <td style="width: 1086px; text-align: center;">
                     <table style="width: 800px; border-collapse:collapse; background-color: #FF9966; height: 32px; margin-bottom: 0px; margin-left: 304px; border-color:#663300; border-style:solid; border-width:2px;">
                    <tr style="color: #FFFFFF">
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;"> From</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;"> To</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;">From</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;"> To</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;">From</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;"> To</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;">From</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;"> To</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;">From</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;"> To</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;"> From</td>
                        <td style="border: thin solid #DEBA84; height: 32px; width: 32px; text-align: center;"> To</td>
                        <td style="border: thin solid #DEBA84; height: 30px; width: 30px; text-align: center;">Mon</td>
                        <td style="border: thin solid #DEBA84; height: 30px; width: 30px; text-align: center;">Tue</td>
                        <td style="border: thin solid #DEBA84; height: 30px; width: 30px; text-align: center;">Wed</td>
                        <td style="border: thin solid #DEBA84; height: 30px; width: 30px; text-align: center;">Thu</td>
                        <td style="border: thin solid #DEBA84; height: 30px; width: 30px; text-align: center;">Fri</td>
                        <td style="border: thin solid #DEBA84; height: 30px; width: 30px; text-align: center;">Sat</td>
                        <td style="border: thin solid #DEBA84; height: 30px; width: 30px; text-align: center;">Sun</td>
                    </tr>
                         
                 </table>
                        </td>
               
        </tr>
        <tr>
            <td style="text-align: center; width: 1086px;">
                    
                    <asp:GridView ID="GridView1" runat="server" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84" 
                        BorderStyle="None" BorderWidth="1px" CellSpacing="2"  Width="800px" Style="margin-left: 304px" ShowHeader="false"  OnDataBound="GridView1_DataBound" >
                        
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#FF9966" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
        </tr>
        <tr>
            <td style="width: 1086px;">
                
                
                <asp:TextBox ID="TextBox2" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Width="529px"
                     Height="30px" style="font-size: large;  margin-left: 400px;">                                         Sessions</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style=" width: 1086px;">
                
                <asp:TextBox ID="FirstShiftTextBox" runat="server" BorderColor="#663300" BorderStyle="Solid"
                     BorderWidth="1px" Width="368px" Height="30px" 
                    style="font-size: 12px;  margin-left: 485px;" 
                    BackColor="#FF9966"  ForeColor="Black" Font-Bold="False"></asp:TextBox>
                
                    <br />
                    <asp:GridView ID="FirstShiftGrid" runat="server" CellPadding="3" BackColor="#DEBA84" 
                        BorderColor="#663300" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2"  ShowHeader="False" Width="368px" style="margin-left: 485px">
                        
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#FF9966" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                    
                    <br />
                
                <asp:TextBox ID="SecondShiftTextBox" runat="server" BorderColor="#663300" BorderStyle="Solid" 
                    BorderWidth="1px" Width="368px" Height="30px" style="font-size: 12px;  margin-left: 485px;" 
                    BackColor="#FF9966"  ForeColor="Black"></asp:TextBox>
               
                    
                    <br />
                    
                    <asp:GridView ID="SecondShiftGrid" runat="server" CellPadding="3" BackColor="#DEBA84" BorderColor="#663300" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2"  ShowHeader="False" Width="368px" style="margin-left:485px" >
                       
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#FF9966" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                    <br />
                
                <asp:TextBox ID="ThirdShiftTextBox" runat="server" BorderColor="#663300" BorderStyle="Solid" 
                    BorderWidth="1px" Width="368px" Height="30px" style="font-size: 12px; margin-left: 485px;" 
                    BackColor="#FF9966"  ForeColor="Black"></asp:TextBox>
                
                    <br />
                    
                    <asp:GridView ID="ThirdShiftGrid" runat="server" CellPadding="3" BackColor="#DEBA84" BorderColor="#663300" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2"  ShowHeader="False" Width="368px" style="margin-left:488px">
                       
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#FF9966" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                    <br />
                </td>
        </tr>
        </table>
                    </asp:Panel>
        </div>
         
</asp:Content>
