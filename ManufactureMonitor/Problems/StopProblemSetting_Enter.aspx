<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StopProblemSetting_Enter.aspx.cs" Inherits="ManufactureMonitor.StopProblemSetting_Enter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <script type="text/javascript">
       function alertRedirect() {
           alert("Alert");
           if (alert) {
               window.location('../StopProblemSetting_Enter.aspx?MachineId=');
           }
       }
   </script>
    <table style="width: 100%; border-collapse: collapse">
        <tr>
            <td colspan="3" style="height: 51px; text-align: center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="529px" Height="30px" style="font-size: medium">                                    Stop Problem Setting</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" OnClick="ImageButton1_Click" Width="25px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="height: 51px; text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 245px;">&nbsp;</td>
            <td style="background-color: #FFAF37; color: #FFFFFF; font-size: medium; text-align: center; " colspan="2">Specific Problem Definition</td>
            <td style="background-color: #FFFFCC; ">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #FFFFCC;"></td>
            <td style="background-color: #FFFFCC; ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="background-color: #FFFFCC; "></td>
            <td style="background-color: #FFFFCC; "></td>
        </tr>
        <tr>
            <td style="background-color: #FFFFCC;"></td>
            <td style="background-color: #FFFFCC; ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Problem No:</td>
            <td style="background-color: #FFFFCC; ">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td style="background-color: #FFFFCC; "></td>
        </tr>
        <tr>
            <td style="background-color: #FFFFCC;">&nbsp;&nbsp;</td>
            <td style="background-color: #FFFFCC; ">      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      Problem Description:</td>
            <td style="background-color: #FFFFCC; ">
                <asp:TextBox ID="TextBox3" runat="server" Width="582px"></asp:TextBox>
                &nbsp;</td>
            <td style="background-color: #FFFFCC;"></td>
        </tr>
        <tr>
            <td style="background-color: #FFFFCC;"></td>
            <td style="background-color: #FFFFCC; ">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Type:</td>
            <td style="background-color: #FFFFCC; ">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="497px" RepeatDirection="Horizontal"  AutoPostBack="true"
                    OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Value="1">Non-Operation time 1</asp:ListItem>
                    <asp:ListItem Value="2">Non-Operation time 2</asp:ListItem>
                    <asp:ListItem Value="3">Idle time</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td style="background-color: #FFFFCC; "></td>
        </tr>
        <tr>
            <td style="background-color: #FFFFCC;"></td>
            <td style="background-color: #FFFFCC; ">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="background-color: #FFFFCC; ">
                <asp:RadioButtonList ID="Operation2Selection" runat="server" style="margin-left: 148px" Width="212px" 
                    SelectionMode="Single" >
                    <asp:ListItem Text ="Unknown(Speed Loss)" />
                    <asp:ListItem Text ="Change Over Loss" />
                    <asp:ListItem Text ="Defects & Rework Loss" />
                    <asp:ListItem Text ="Other Loss" />

                </asp:RadioButtonList>
            </td>
            <td style="background-color: #FFFFCC;">&nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #FFFFCC;">&nbsp;</td>
            <td style="background-color: #FFFFCC; text-align: center; " colspan="2">
                <asp:Button ID="Button1" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="45px" Text="Save" Width="103px" OnClick="Button1_Click"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" BorderColor="Gray" BorderStyle="Outset" BorderWidth="3px" Font-Names="Calibri" Font-Size="Medium" Height="42px" Text="Cancel" Width="125px" OnClick="Button2_Click"  />
            </td>
            <td style="background-color: #FFFFCC;">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">&nbsp;</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
