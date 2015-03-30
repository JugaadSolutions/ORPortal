<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scrap_entry.aspx.cs" Inherits="ManufactureMonitor.Scraps.Scrap_entry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel runat="server" ID="MainPanel" ScrollBars="Auto" height="100%" style="text-align:center;">
     <table style="width: 100%; border-collapse: collapse; background-color: #FFFFCC;">
        <tr>
            <td style="width: 173px; height: 40px;"></td>
            <td style="text-align: center; width: 801px; height: 40px;"><strong>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Height="30px" style="font-size: medium; font-weight: bold" Width="600px">                                            Scrap Entry:     </asp:TextBox>
                </strong></td>
            <td style="height: 40px">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 173px; height: 25px;"></td>
            <td >
                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" CellPadding="3" BackColor="#DEBA84" 
                    BorderColor="#663300" BorderStyle="Solid" BorderWidth="1px" CellSpacing="2"  
                    ShowHeaderWhenEmpty="True" Width="870px"  AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing"
                     OnRowUpdating ="GridView1_RowUpdating" >
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
                        <asp:BoundField DataField="Date" ReadOnly="true" HeaderText="Date" ShowHeader="true" 
                            HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="From" ReadOnly="True"
                             HeaderText="From" />
                        <asp:BoundField DataField="To" HeaderText="To" ReadOnly="True" />
                        <asp:BoundField DataField="Project/Model" HeaderStyle-HorizontalAlign="Center" HeaderText="Project/Model" ItemStyle-HorizontalAlign="Center" ReadOnly="true" ShowHeader="true">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                           <asp:BoundField DataField="Actual"  HeaderStyle-HorizontalAlign="Center" HeaderText="Total Pieces" 
                               ItemStyle-HorizontalAlign="Center" ReadOnly="true" ShowHeader="true">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Scraps" ItemStyle-HorizontalAlign="Center" ShowHeader="true">
                            <ItemTemplate>
                                <%#Eval("Scraps") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ScrapTextbox" runat="server" TextMode="SingleLine" />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:CommandField ShowHeader="false"  ShowEditButton="true" EditText="Update" UpdateText="Save"  ShowCancelButton="false"/>
                    </Columns>
                </asp:GridView>
                
            </td>
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td style="width: 173px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
         </asp:Panel>
</asp:Content>
