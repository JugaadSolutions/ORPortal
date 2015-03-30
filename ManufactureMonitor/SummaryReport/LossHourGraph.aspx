<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LossHourGraph.aspx.cs" Inherits="ManufactureMonitor.LossHourGraph" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"  >
    <asp:Panel ID="MainPanel" runat="server" HorizontalAlign="Center" ScrollBars="Auto" Height="100%">
    
        <div id="Div1" runat="server" >
       <asp:PlaceHolder ID="StackedDataPlaceHolder" runat="server">
   
            </asp:PlaceHolder>
           
        </div>
      
         <div id="Div2" runat="server" >
               <asp:PlaceHolder ID="ReportDataPlaceHolder" runat="server"   >
   
            </asp:PlaceHolder>
        
        </div>
       
    </asp:Panel>
   
</asp:Content>

