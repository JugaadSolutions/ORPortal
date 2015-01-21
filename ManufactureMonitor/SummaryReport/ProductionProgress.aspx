<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductionProgress.aspx.cs" Inherits="ManufactureMonitor.SummaryReport.ProductionProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel ID="MainPanel" runat="server" HorizontalAlign="Center" ScrollBars="Auto" Height="100%">
    
        <div id="Div1" runat="server" >
        <asp:PlaceHolder ID="ReportDataPlaceHolder" runat="server"   >
   
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="StackedDataPlaceHolder" runat="server">
   
            </asp:PlaceHolder>
        </div>
      
         <div id="Div2" runat="server" >
        
        </div>
       
    </asp:Panel>
</asp:Content>
