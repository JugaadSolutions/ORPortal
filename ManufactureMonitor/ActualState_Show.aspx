<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualState_Show.aspx.cs" Inherits="ManufactureMonitor.ActualState_Show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse; border: 1px solid #FF9B6A">
        <tr>
            <td style="text-align: left; background-color: #000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BackColor="#999999" Height="40px" style="margin-left: 0px" Width="653px" Font-Bold="True" Font-Size="X-Large"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" BackColor="Lime" Height="40px" style="margin-top: 0px" Font-Bold="True" Font-Size="X-Large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000">
                <asp:Label ID="ActualTimeIntervalLabel" runat="server" style="color: #FFFFFF; font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox3" runat="server" BackColor="Black" Height="150px" style="margin-top: 0px; margin-left: 0px;" BorderColor="White" ForeColor="Silver" Width="400px" Font-Bold="True" Font-Size="XX-Large"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:TextBox ID="TextBox4" runat="server" BackColor="Black" Height="150px" style="margin-top: 0px" BorderColor="White" ForeColor="#FFCC00" Width="400px" Font-Bold="True" Font-Size="XX-Large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000; height: 100px;">
                <asp:Label ID="ActualStateLabel" runat="server" style="color: #FFFFFF; font-size: xx-large; margin-right: 0px;" Font-Size="XX-Large" Height="100px" Width="1000px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000">
                <asp:Label ID="ActualShiftLabel" runat="server" style="color: #FFFFFF; font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="TextBox5" runat="server" BackColor="Black" Height="100px" style="margin-top: 0px; margin-left: 0px;" BorderColor="White" ForeColor="Silver" Width="200px" Font-Bold="True" Font-Size="Large"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox6" runat="server" BackColor="Black" Height="100px" style="margin-top: 0px" BorderColor="White" ForeColor="#FFCC00" Width="200px" Font-Bold="True" Font-Size="Large"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" style="color: #FFFFFF; font-size: x-large" Font-Bold="True" Font-Size="Large" Height="100px" Width="200px"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image2" runat="server" Height="100px" Width="100px" />
            </td>
        </tr>
    </table>
</asp:Content>
