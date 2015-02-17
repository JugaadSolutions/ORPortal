<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StopTimes2_show.aspx.cs" Inherits="ManufactureMonitor.StopTimes2_show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="MainPanel" ScrollBars="Auto" height="100%">
    <table style="width: 100%; border-collapse: collapse; background-color: #FFFFCC;">
        <tr>
            <td style="width: 273px; height: 40px;"></td>
            <td style="text-align: center; width: 755px; height: 40px;"><strong>
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Height="30px" style="font-size: medium; font-weight: bold" Width="500px">                                Stop Times Enter code and comment</asp:TextBox>
                </strong></td>
            <td style="height: 40px">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 273px; height: 25px;"></td>
            <td >
                <asp:GridView ID="GridView1" runat="server"  style="margin-left: 108px; text-align:center;" BackColor="#DEBA84" BorderColor="#663300" BorderStyle="solid" BorderWidth="1px" 
                    CellPadding="3" CellSpacing="2" Width="721px" Height="179px"  AutoGenerateColumns="false">
                    <Columns>
                        <asp:HyperLinkField Text="Update" DataNavigateUrlFields="ProblemCode,StopType,Machine_Id,SlNo" 
                            DataNavigateUrlFormatString =
                            "~/EnterCodeComment/EnterCodeComment.aspx?ProblemCode={0}&Type={1}&Machine_Id={2}&SlNo={3}" />
                        <asp:BoundField HeaderText ="From" DataField="From" />
                        <asp:BoundField HeaderText ="To" DataField="To" />
                        <asp:BoundField HeaderText ="Duration[s]" DataField="Duration" />
                        <asp:BoundField HeaderText ="Stop Type" DataField="StopType" />
                        <asp:BoundField HeaderText ="Problem" DataField="Problem" />
                        <asp:BoundField HeaderText ="Comment" DataField="Comment" />
                    </Columns>
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
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td style="width: 273px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        </asp:Panel>
</asp:Content>
