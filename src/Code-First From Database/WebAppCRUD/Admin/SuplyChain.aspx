<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuplyChain.aspx.cs" Inherits="WebAppCRUD.Admin.SuplyChain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Active Suppliers</h1>

    <asp:ObjectDataSource ID="SupplierDataSource" runat="server"></asp:ObjectDataSource>

    <asp:Repeater ID="SupplierSummaryRepeater" runat="server"></asp:Repeater>


</asp:Content>
