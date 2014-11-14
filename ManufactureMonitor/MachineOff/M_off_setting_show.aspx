<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="M_off_setting_show.aspx.cs" Inherits="ManufactureMonitor.M_off_setting_show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height:100%">
    <asp:Panel runat="server" ID="MainPanel" Height="100%" Width="100%" HorizontalAlign="Center" ScrollBars="Auto" >
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick" />
        
    <table style="width: 100%; height:100%; border-collapse: collapse" >
        <tr>
            <td colspan="3" style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="708px" style="margin-left: 0px; font-size: medium;" Height="30px">                                                                    Machine OFF- Setting</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 417px; height: 33px;"></td>
            <td style="background-color: #FFAF37; color: #FFFFFF; font-size: medium; text-align: center; width: 450px; height: 33px;">Machine:</td>
            <td style="text-align: center; height: 33px;"></td>
        </tr>
        <tr>
            <td style="width: 417px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 450px;">
                <table style="border: thin solid #FFAF37; width: 100%; height:100%; border-collapse: collapse; background-color: #FFFFCC; font-weight: 700;">
                    <tr>
                        <td colspan="2" style="height: 43px; text-align: left;"> &nbsp;&nbsp;
                            <asp:Image ID="StopImage" runat="server" Height="50px" ImageAlign="Top" ImageUrl="~/Images/STOP.png" Width="50px" />
                            <br />
                            <asp:Button ID="Button2" runat="server" Text="Machine OFF Immediately" Width="256px" style="margin-left:20%" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 226px; height: 19px;">Date:</td>
                        <td style="height: 19px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" >
                            
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" style="margin-left:112px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Font-Size="7pt" />
                                <NextPrevStyle VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="white" />
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" />
                                <TitleStyle BackColor="#FFAF37" BorderColor="Black" Font-Bold="True" />
                               
                                <WeekendDayStyle BackColor="#FFFFCC" />
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" >
                            
                            Time:</td>
                    </tr>
                    <tr>
                        <td style="width: 226px" >
                            
                            From:</td>
                        <td >
                            
                            To:</td>
                    </tr>
                    <tr>
                        <td style="width: 226px; bottom: 25%;">
                            <asp:TextBox ID="from1" runat="server" Height="25px" Width="30px"></asp:TextBox>
&nbsp; :&nbsp;
                            <asp:TextBox ID="from2" runat="server" Height="25px" Width="30px"></asp:TextBox>
                        </td>
                        <td style="bottom: 25%">
                            <asp:TextBox ID="To1" runat="server" Height="25px" Width="30px"></asp:TextBox>
&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="To2" runat="server" Height="25px" Width="30px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 40px"><asp:Button ID="Button3" runat="server" Text="Machine OFF retroactively" Width="256px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 40px"><asp:Button ID="Button4" runat="server" Text="Cancel Machine OFF retroactively" Width="256px" OnClick="Button4_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 39px">
                <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="30px" Text="Next Machine" Width="152px" OnClick="Button1_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 39px"></td>
                    </tr>
                </table>
            </td>
            <td style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 23px; width: 417px;"></td>
            <td style="background-color: #FFFFCC; "></td>
            <td style="height: 23px"></td>
        </tr>
        <tr>
            <td style="width: 417px; height: 40px;"></td>
            <td style="background-color: #FFFFCC; ">
                &nbsp;</td>
            <td style="text-align: center; height: 40px;"></td>
        </tr>
        <tr>
            <td style="height: 30px; width: 417px;"></td>
            <td style="background-color: #FFFFCC; "></td>
            <td style="text-align: center; height: 30px"></td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
    </table>
       </ContentTemplate>
                    
                    </asp:UpdatePanel>
        </asp:Panel>
        </div>
</asp:Content>
