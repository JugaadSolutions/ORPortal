﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualState.aspx.cs" Inherits="ManufactureMonitor.ActualState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 1500px; border-collapse: collapse; background-color: #FFFFCC; height: 450px">
        <tr>
            <td colspan="3" style="height: 46px; text-align: center;">
                &nbsp;<asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Width="507px" Height="30px" style="font-size: large">                                          Actual State</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageAlign="Middle" ImageUrl="~/Images/return.jpg" Width="25px" OnClick="ImageButton1_Click" />
                                        </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 30px">
                </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 30px">
                </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 399px;">&nbsp;</td>
            <td style="background-color: #3366FF; color: #FFFFFF; font-size: medium; text-align: center; width: 350px;">Machine Selection</td>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 399px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px;" rowspan="3">
                <table style="width: 100%; border-collapse: collapse; background-color: #99CCFF">
                    <tr>
                        <td>
                <%--<asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" OnSelectedIndexChanging="ListView1_SelectedIndexChanging" textalign="center" Position="Absolute">
                    <LayoutTemplate>  
                <table id="Itemplaceholder" runat="server" textalign="center">  
                      <tr>
                        <td id="Td1" runat="server">Machine:</td>  
                          
                     </tr>
                   
                    </table>
                    </LayoutTemplate>
                    <ItemTemplate>  
                <tr >  
                    <td>  
                        <asp:Label   
                            ID="Label1"  
                            runat="server"  
                            Text='<%# Eval("Machines")%>' 
                            textalign="center" 
                            >  
                        </asp:Label>  
                    </td>
                    <td>
                        <asp:Button
                            ID="Button1"
                            runat="server"
                            Font-Bold="true"
                            CommandName="Select"
                            Text="Show"
                            Forecolour="White">

                        </asp:Button>
                    </td>  
                </tr>                  
            </ItemTemplate> 
                <SelectedItemTemplate>
                    <tr >  
                    <td style="background-color:blue" >  
                        <asp:Label   
                            ID="Label1"  
                            runat="server"  
                            Text='<%# Eval("Machines")%>' 
                            textalign="center" 
                            >  
                        </asp:Label>  
                    </td>  
                </tr>             
                </SelectedItemTemplate> 
                </asp:ListView>--%>
                            <asp:ListBox ID ="MachineSelectionListBox" runat="server"  SelectionMode="Single"/>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; width: 399px; height: 45px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td style="text-align: center; height: 45px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="height: 23px; width: 399px;"></td>
            <td style="height: 23px"></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 399px;">&nbsp;</td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px;">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" Width="66px" />
            </td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
         <tr>
            <td style="width: 450px; height: 40px;"></td>
            <td style="background-color: #99CCFF; text-align: center; width: 350px; height: 40px;">
                &nbsp;</td>
            <td style="text-align: center; height: 40px;"></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
