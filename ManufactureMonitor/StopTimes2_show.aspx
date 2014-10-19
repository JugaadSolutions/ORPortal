<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StopTimes2_show.aspx.cs" Inherits="ManufactureMonitor.StopTimes2_show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
            <td style="background-color: #0053A6; color: #FFFFFF; font-size: medium; text-align: center; width: 435px; " rowspan="2">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="809px" Height="179px">
                    <Columns>
                        <asp:HyperLinkField Text="Update" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </td>
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td style="width: 273px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
