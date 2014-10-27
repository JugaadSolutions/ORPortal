<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LossHourGraph.aspx.cs" Inherits="ManufactureMonitor.LossHourGraph" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart ID="Chart1" runat="server" ImageLocation="~/Charts" ImageStorageMode="UseImageLocation"
         ImageType="Png" IsSoftShadows="true">
    <Series>
        <asp:Series Name="LossHour" YValueType="Double" ChartType="StackedColumn100" Color="Red">
           <Points>
               <asp:DataPoint AxisLabel="Audio" YValues="17" />
               
           </Points>

        </asp:Series>
        <asp:Series Name="LossHour1" YValueType="Double" ChartType="StackedColumn100" Color="Green" >
           <Points>
               
               <asp:DataPoint AxisLabel ="Audio" YValues="15" />
              
           </Points>

        </asp:Series>

         <asp:Series Name="LossHour2" YValueType="Double" ChartType="StackedColumn100" Color="Lime">
           <Points>
               <asp:DataPoint AxisLabel="Audio" YValues="6" />
              
           </Points>

        </asp:Series>
        
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
    </ChartAreas>
</asp:Chart>

    <asp:Panel ID="ChartHolder" runat="server"  HorizontalAlign="Center"/>
</asp:Content>

