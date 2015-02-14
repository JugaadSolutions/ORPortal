<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StopProblemSetting.aspx.cs" Inherits="ManufactureMonitor.StopProblemSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="575px" style="font-size: medium; margin-left: 48px" Height="30px">                                                 Stop Problem Setting</asp:TextBox>
                &nbsp;&nbsp;&nbsp; 
                <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <table style="border: thin solid #FFAF37; width: 42%; border-collapse: collapse; height: 259px; margin-left: 444px; background-color: #FFFFCC; ">
                    <tr>
                        <td style="background-color: #FFAF37; text-align: center;" colspan="2">Problem Selection</td>
                    </tr>
                    <tr>
                        <td rowspan="3" style="width: 53px">
                            <asp:ListBox ID="ShiftSelectionListBox" runat="server" SelectionMode="Single" Height="210px" style="margin-left: 28px" Width="325px" />
                        </td>
                        <td style="width: 822px; height: 17px;">
                <asp:Button ID="Add" runat="server" OnClick="Add_Click" Text="Add" Width="66px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 822px">
                <asp:Button ID="Edit" runat="server" OnClick="Edit_Click" Text="Edit" Width="66px" style="height: 26px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 822px">
                <asp:Button ID="Delete" runat="server" OnClick="Delete_Click" Text="Delete" Width="66px" style="height: 26px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            &nbsp;</td>
                    </tr>
                    </table>
                </td>
        </tr>
        <tr>
            <td style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
