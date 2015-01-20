<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StackedLossGraph.aspx.cs" Inherits="ManufactureMonitor.MachineOff.CancelMachineOff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"
     ImageLocation="~/Charts" ImageStorageMode="UseImageLocation" ImageType="Png" IsSoftShadows="true">
    <asp:Panel ID="MainPanel" runat="server" HorizontalAlign="Center" ScrollBars="Auto">

     <div id="Div1" runat="server" >
        <asp:PlaceHolder ID="ReportDataPlaceHolder" runat="server"   >
   
            </asp:PlaceHolder>
        </div>
        </asp:Panel>
     
</asp:Content>
