<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSupplier.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>View Supplier</h1>

    <asp:Repeater ID="SupplierRepeater" runat="server" DataSourceID="SupplierDataSource" ItemType="WestWindSystem.Entities.Supplier">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li>
                <b><%#Item.CompanyName %></b>
                &ndash;
                <%#Item.CompanyName %>
                &ndash;
                <a href="mailto: <%# Item.Email %><%#Item.ContactName %>">(<%#Item.Phone %></a>
               
                <%#Item.Email %>

            </li></ItemTemplate>
        <SeparatorTemplate></SeparatorTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
