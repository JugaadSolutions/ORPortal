<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OR_OAGraph.aspx.cs" Inherits="ManufactureMonitor.OR_OAGraph" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <div id="Div1" runat="server" >
        <asp:PlaceHolder ID="ReportDataPlaceHolder" runat="server"   >
   
            </asp:PlaceHolder>
        </div>
     <asp:Button ID="Download" runat="server" Text="Download"  />
</asp:Content>
