<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParameterSetting_Show.aspx.cs" Inherits="ManufactureMonitor.ParameterSetting_Show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table style="width: 100%; border-collapse: collapse; height: 402px;">
        <tr>
            <td colspan="4" style="height: 46px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="753px" style="margin-left: 156px; font-size: medium;" Height="30px">                                                                           Setting Of Parameter  </asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
            </td>
        </tr>

        <tr>
            <td style="width: 406px;">&nbsp;</td>
            <td style="background-color:#FFAF37; color: #FFFFFF; font-size: medium; text-align: center; " colspan="2">Machine:</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 406px; height: 30px;"></td>
            <td style="background-color: #FFFFCC; " colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="text-align: center; height: 30px;"></td>
        </tr>
        <tr>
            <td style="width: 406px; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="background-color: #FFFFCC; text-align: left; width: 238px; "><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Time to Stop[%]:</b></td>
            <td style="background-color: #FFFFCC; text-align: center; ">
                &nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;"></td>
            <td style="background-color: #FFFFCC; width: 238px; text-align: left;"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ratio Pulses:Pieces:</b></td>
            <td style="background-color: #FFFFCC; text-align: center;">&nbsp;
                <asp:TextBox ID="TextBox3" runat="server" Width="30px" Height="20px" style="margin-top: 0px"></asp:TextBox>
                <strong><span style="font-size: large">: </span></strong><asp:TextBox ID="TextBox4" runat="server" Width="30px" Height="20px" style="margin-top: 0px"></asp:TextBox>
            </td>
            <td style="height: 30px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 406px; height: 30px;"></td>
            <td style="background-color: #FFFFCC; text-align: left; width: 238px; "><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR red MIN[%]:</b></td>
            <td style="background-color: #FFFFCC; text-align: center; ">
                <asp:TextBox ID="TextBox5" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px;"></td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;"></td>
            <td style="background-color: #FFFFCC; text-align: left; width: 238px; "><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR red MAX[%]:</b></td>
            <td style="background-color: #FFFFCC; text-align: center; ">
                <asp:TextBox ID="TextBox6" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px"></td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; text-align: left; width: 238px; "><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR orange MIN[%]:</b></td>
            <td style="background-color: #FFFFCC; text-align: center; ">
                <asp:TextBox ID="TextBox7" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; text-align: left; width: 238px; "><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR orange MAX[%]:</b></td>
            <td style="background-color: #FFFFCC; text-align: center; ">
                <asp:TextBox ID="TextBox8" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; text-align: left; width: 238px; "><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR green MIN[%]:</b></td>
            <td style="background-color: #FFFFCC; text-align: center; ">
                <asp:TextBox ID="TextBox9" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; text-align: left; width: 238px; "><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR greenMAX[%]:</b></td>
            <td style="background-color: #FFFFCC; text-align: center; ">
                <asp:TextBox ID="TextBox10" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; text-align: left; width: 238px; "><b>&nbsp;&nbsp;&nbsp;&nbsp; Man Power Popup&nbsp; Delay[mins]:</b></td>
            <td style="background-color: #FFFFCC; text-align: center; ">
                <asp:TextBox ID="TextBox11" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; text-align: left; width: 238px; "><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Stop Close Duration[mins]:</b></td>
            <td style="background-color: #FFFFCC; text-align: center; ">
                <asp:TextBox ID="TextBox12" runat="server" Width="30px"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; " colspan="2">&nbsp;</td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 406px;">&nbsp;</td>
            <td style="background-color: #FFFFCC; text-align: center;" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" BorderStyle="Outset" BorderWidth="3px" Text="Save" Width="78px" 
                    OnClick="Button1_Click"  />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" BorderStyle="Outset" BorderWidth="3px" Text="Cancel" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td style="text-align: center; height: 30px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
    
</asp:Content>
