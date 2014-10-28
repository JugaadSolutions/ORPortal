<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftHistroy_Show.aspx.cs" Inherits="ManufactureMonitor.ShiftHistroy_Show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="align-content:center;  height:100%">
    <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid" 
        BorderWidth="3px" Height="30px" style="font-size: medium; font-weight: bold; text-align:center; width:100%" 
        >  
           Shift history - production in the shifts</asp:TextBox>
        <asp:Panel runat="server" ID="MainPanel" ScrollBars="Auto" height="100%" style="text-align:center;"/>
        </div>
</asp:Content>
