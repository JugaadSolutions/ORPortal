<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scrap_entry.aspx.cs" Inherits="ManufactureMonitor.Scraps.Scrap_entry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                    ShowHeaderWhenEmpty="True" Width="870px"  AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing"
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
                            HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Project/Model" ReadOnly="true"
                             HeaderText="Project/Model" ShowHeader="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                       <asp:TemplateField HeaderText="Scraps" HeaderStyle-HorizontalAlign="Center" ShowHeader="true" ItemStyle-HorizontalAlign="Center">
                           <ItemTemplate> <%#Eval("Scraps") %></ItemTemplate>
                           <EditItemTemplate>
                               <asp:TextBox ID="ScrapTextbox" runat="server" TextMode="SingleLine" />
                           </EditItemTemplate>
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
</asp:Content>
