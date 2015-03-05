<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftSetting_TP_Add.aspx.cs" Inherits="ManufactureMonitor.ShiftSetting_TP_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="753px" style="margin-left: 0px; font-size: medium;" Height="30px">                                                                       Shift Definition</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <table style="border: thin solid #FFAF37; width: 23%; border-collapse: collapse; height: 259px; margin-left: 444px; background-color: #FFFFCC; ">
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center;" colspan="2">Time Points</td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 137px"><strong>From</strong>:</td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Width="30px" Height="25px"></asp:TextBox>
                            <span style="font-size: large"><strong>&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp; </strong></span>
                <asp:TextBox ID="TextBox3" runat="server" Width="30px" Height="25px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 137px"><strong>To:</strong></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox4" runat="server" Width="30px" Height="25px"></asp:TextBox>
                            <span style="font-size: large"><strong>&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp; </strong></span>
                <asp:TextBox ID="TextBox5" runat="server" Width="30px" Height="25px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <strong>Name:</strong></td>
                        <td style="text-align: center">
                            <asp:DropDownList ID="SessionNameDropDown" runat="server">
                                <asp:ListItem Value="-1">SELECT</asp:ListItem>
                                <asp:ListItem>FIRST</asp:ListItem>
                                <asp:ListItem>SECOND</asp:ListItem>
                                <asp:ListItem>THIRD</asp:ListItem>
                                <asp:ListItem>FOURTH</asp:ListItem>
                                <asp:ListItem>FIFTH</asp:ListItem>
                                <asp:ListItem>SIXTH</asp:ListItem>
                                <asp:ListItem>SEVENTH</asp:ListItem>
                                <asp:ListItem>EIGHTH</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 137px;">
                <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="38px" Text="Save" Width="103px" OnClick="Button1_Click" />
                        </td>
                        <td style="text-align: center">
                <asp:Button ID="Button2" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="38px" Text="Cancel" Width="103px" OnClick="Button2_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
