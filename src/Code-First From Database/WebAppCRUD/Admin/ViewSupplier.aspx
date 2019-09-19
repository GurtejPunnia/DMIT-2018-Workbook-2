<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSupplier.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>View Supplier</h1>
    <asp:ListView ID="SupplierListView" runat="server" DataSourceID="SupplierDataSource" ItemType="WestWindSystem.Entities.Supplier">
    <LayoutTemplate>

        <table class="table table-hover table-condensed">
            <thead>
                <tr>
                     <th>ID</th>
                     <th>Company</th>
                     <th>Contact</th>
                     <th>Contact Title</th>
                     <th>Address</th>
                     <th>Phone</th>
                     <th>Email</th>
                     <th>Fax</th>
                </tr>
            </thead>
            <tbody>
                <tr runat="server" id="itemPlaceholder"></tr>
            </tbody>
        </table>
    </LayoutTemplate>
        <ItemTemplate>

             <tr>
                     <td><%# Item.SupplierID %></td>
                     <td><%# Item.CompanyName %></td>
                     <td><%# Item.ContactName %></td>
                     <td><%# Item.ContactTitle %></td>
                     <td><%# Item.AddressID %></td>
                     <td><%# Item.Phone %></td>
                     <td><%# Item.Email %></td>
                     <td><%# Item.Fax %></td>
                    
                </tr>

        </ItemTemplate>
    </asp:ListView>


    

    <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
