﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scrap_show.aspx.cs" Inherits="ManufactureMonitor.Scrap_show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; background-color: #FFFFCC;">
        <tr>
            <td style=" height: 40px; width: 209px;"></td>
            <td style="text-align: center; width: 801px; height: 40px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Height="30px" style="font-size: medium; font-weight: bold" Width="600px">                                            Scrap Report-</asp:TextBox>
                </td>
            <td style="height: 40px">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr Style="width:800px">
            <td style="width: 200px" ></td>
            <td style="width: 800px" >
                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" 
                    CellPadding="3" BackColor="#DEBA84" BorderColor="#663300" 
                    BorderStyle="Solid" BorderWidth="1px" CellSpacing="2"
                    ShowHeaderWhenEmpty="True" Width="100%" AutoGenerateColumns="False">
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#FF9966" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" ShowHeader="true" />
                        <asp:BoundField DataField="Actual" HeaderText="OK Pieces" ShowHeader="true" />
                        <asp:BoundField DataField="Scraps" HeaderText="Rejection" ShowHeader="true" />
                        <asp:BoundField DataField="Rejection" HeaderText="[%] Rejection" ShowHeader="true" />

                    </Columns>
                </asp:GridView>
                <asp:Panel ID="TotalPanel" runat="server" Width="100%">
                <asp:Label ID="TotalLabel" runat="server" Font-Size="Medium" ForeColor="#996633" Height="30px" Text="Total:" Width="164px"></asp:Label><asp:TextBox ID="ActualTotal" 
                runat="server" BorderColor="#996633" BorderStyle="Solid" BorderWidth="1px" Height="30px" Width="185px"></asp:TextBox><asp:TextBox ID="ScrapsTotal" 
                    runat="server" BorderColor="#996633" BorderStyle="Solid" BorderWidth="1px" Height="30px" Width="176px"></asp:TextBox><asp:TextBox ID="RejectionTotal" 
                        runat="server" BorderColor="#996633" BorderStyle="Solid" BorderWidth="1px" Height="30px" Width="220px"></asp:TextBox>
                    </asp:Panel>
            </td>
            
        </tr>
     <tr>
            <td style="width: 209px"> </td>
        </tr>
    </table>
</asp:Content>
