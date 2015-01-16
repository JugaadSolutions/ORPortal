<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LossHourGraph.aspx.cs" Inherits="ManufactureMonitor.LossHourGraph" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" ImageLocation="~/Charts" ImageStorageMode="UseImageLocation" ImageType="Png" IsSoftShadows="true">

    <asp:Panel ID="ChartHolder" runat="server"  HorizontalAlign="Center" Style="margin-left:25%"/>
    
        <%-- <asp:Chart ID="Chart1" runat="server" >
        <Series>
            <asp:Series Name="OR" ChartType="Line" >
                <Points>
                    <asp:DataPoint XValue="1" YValues="100" />
                    <asp:DataPoint XValue="2" YValues="90" />
                </Points>
            </asp:Series>
            
        </Series>
        <Series>
            <asp:Series Name="OA"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>--%>
        <div id="Div1" runat="server" >
        <asp:PlaceHolder ID="ReportDataPlaceHolder" runat="server"   >
   
            </asp:PlaceHolder>
        </div>
     <asp:Button ID="Download" runat="server" Text="Download"  />

</asp:Content>

