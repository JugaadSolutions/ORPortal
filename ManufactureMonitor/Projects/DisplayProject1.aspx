<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayProject1.aspx.cs" Inherits="ManufactureMonitor.DisplayProject1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; height: 412px;">
        <tr>
            <td style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="441px" style="margin-left: 300px; font-size: medium;" Height="30px">                                    Projects Display</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="border: thin solid #FFAF37; width: 25%; border-collapse: collapse; height: 343px; margin-left: 481px; " >

               
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center; height: 25px;"><strong>Machine Selection</strong></td>
                    </tr>
                    <tr>
                        <td style="text-align: center; height: 269px;">
                            <asp:ListBox ID ="MachineSelectionListBox" runat="server"  SelectionMode="Single" Height="150px" Width="200px"/>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; height: 47px;">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" Width="66px" />
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
