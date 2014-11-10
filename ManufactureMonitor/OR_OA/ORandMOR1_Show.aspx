<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ORandMOR1_Show.aspx.cs" Inherits="ManufactureMonitor.ORandMOR1_Show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div style="align-content:center;  height:100%">
    <asp:TextBox ID="TextBox1" runat="server" BorderColor="Gray" BorderStyle="Solid"  
        BorderWidth="3px" Height="30px" style="font-size: medium; font-weight: bold; text-align:center; width:80%; margin-left:10%;
        margin-right:10%" 
        >  
           OR - OA Accumulation </asp:TextBox>
        <asp:Panel runat="server" ID="MainPanel" ScrollBars="Auto" height="100%" style="text-align:center;"/>
        </div>
</asp:Content>
