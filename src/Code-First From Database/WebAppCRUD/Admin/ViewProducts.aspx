<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="WebAppCRUD.Admin.ViewProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">View Products</h1>
    <asp:GridView ID="ProductGridView" runat="server" ItemType="WestWindSystem.Entities.Product" DataSourceID="ProductsDataSource" CssClass="table table-hover" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"></asp:BoundField>
            <asp:BoundField DataField="ProductName" HeaderText="Name" SortExpression="ProductName"></asp:BoundField>
           <asp:TemplateField HeaderText="Supplier">
               <ItemTemplate>
                   <asp:DropDownList ID="SupplierDropDown" runat="server" SelectedValue="<%# Item.SupplierID %>" DataTextField="CompanyName" DataValueField="SupplierID" Enabled="false" DataSourceID="SupplierDataSource"> </asp:DropDownList>
               </ItemTemplate>
           </asp:TemplateField>

               <asp:TemplateField HeaderText="Category">
               <ItemTemplate>
                   <asp:DropDownList ID="CategoryDropDown" runat="server" SelectedValue="<%# Item.CategoryID %>" DataTextField="CategoryName" DataValueField="CategoryID" Enabled="false" DataSourceID="CategoriesDataSource"> </asp:DropDownList>
               </ItemTemplate>
           </asp:TemplateField>
           
            <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty / Unit" SortExpression="QuantityPerUnit"></asp:BoundField>
            <asp:BoundField DataField="MinimumOrderQuantity" HeaderText="Min Qty" SortExpression="MinimumOrderQuantity"></asp:BoundField>
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice"></asp:BoundField>
            <asp:BoundField DataField="UnitsOnOrder" HeaderText="On Order" SortExpression="UnitsOnOrder"></asp:BoundField>
            <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource runat="server" ID="ProductsDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListProducts" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server"
        ID="SupplierDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server"
        ID="CategoriesDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategories" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
    
</asp:Content>
