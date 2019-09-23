<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSupplier.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSupplier" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="my" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>View Supplier</h1>
    <my:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:Label ID="Messagelabel" runat="server"></asp:Label>
    <asp:ListView ID="SupplierListView" InsertItemPosition="FirstItem" runat="server" DataSourceID="SupplierDataSource" ItemType="WestWindSystem.Entities.Supplier" DataKeyNames="SupplierID">
    <LayoutTemplate>

        <table class="table table-hover table-condensed">
            <thead>
                <tr>
                     <th>ID</th>
                     <th>Company</th>
                     <th>Contact</th>
                     <th>Address</th>
                     <th>Phone / Fax</th>
                </tr>
            </thead>
            <tbody>
                <tr runat="server" id="itemPlaceholder"></tr>
            </tbody>
        </table>
    </LayoutTemplate>
        <ItemTemplate>

             <tr>
                     <td>
                         <asp:LinkButton ID="EditSupplier" runat="server" CssClass="btn btn-info glyphicon glyphicon-pencil" CommandName="Edit">
                             Edit
                         </asp:LinkButton>
                         <asp:LinkButton ID="Delete" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this supplier?')" CommandName="Delete">Delete</asp:LinkButton>
                     </td>
                     <td><%# Item.CompanyName %></td>
                     <td> <b><%# Item.ContactName %></b>

                         &ndash;
                         
                         <i><%# Item.ContactTitle %></i>

                         

                         <%# Item.Email %>


                     </td>
                    
                     <td><%# Item.Address.Address1 %>
                         <br />
                         <%# Item.Address.City %>
                          <%# Item.Address.Region %>
                         &nbsp;&nbsp;
                          <%# Item.Address.PostalCode %>
                         <br />
                          <%# Item.Address.Country %>
                     </td>

                     <td><%# Item.Phone %> 
                         <br />
                         <%# Item.Fax %>
                     </td>
                     
                    
                    
                </tr>

        </ItemTemplate>

        <InsertItemTemplate>
            <tr class="bg-info">
                <th>
                    <asp:LinkButton ID="AddSupplier" runat="server" CssClass="btn btn-success glyphicon glyphicon-plus" CommandName="Insert">Add</asp:LinkButton>
                    <asp:LinkButton ID="CancelInsert" runat="server" CssClass="btn btn-default" CommandName="Cancel">Clear</asp:LinkButton>
                </th>
                     
                     <th><asp:TextBox ID="CompanyName" runat="server" Text="<%# BindItem.CompanyName %>" placeholder="Enter Company Name"></asp:TextBox> <br /></th>
                     <th><asp:TextBox ID="Contact" runat="server" Text="<%# BindItem.ContactName %>" placeholder="Contact Name"></asp:TextBox> <br />
                     <asp:TextBox ID="JobTitle" runat="server" Text="<%# BindItem.ContactTitle %>" placeholder="Job Title"></asp:TextBox> <br />
                        <asp:TextBox ID="Email" runat="server" Text="<%# BindItem.Email %>" placeholder="Email"></asp:TextBox> <br />

                         </th>
                <th> 
                    <asp:DropDownList ID="AddressDropDown" runat="server" SelectedValue="<%# BindItem.AddressID %>" DataSourceID="AddressDataSource" AppendDataBoundItems="true" DataTextField="Address1" DataValueField="AddressID">
                        <asp:ListItem Value ="">[Select address on file]</asp:ListItem>
                    </asp:DropDownList>
                </th>

                <th> <asp:TextBox ID="Phone" runat="server" Text="<%# BindItem.Phone %>" placeholder=" Phone #"></asp:TextBox> <br /> 

                     <asp:TextBox ID="Fax" runat="server" Text="<%# BindItem.Fax %>" placeholder=" Fax"></asp:TextBox> <br />

                </th>

                     
                </tr>
        </InsertItemTemplate>




        <EditItemTemplate>
            <tr class="bg-success">
                <th>
                    <asp:LinkButton ID="UpdateSupplier" runat="server" CssClass="btn btn-success glyphicon glyphicon-ok" CommandName="Save">Add</asp:LinkButton>
                    <asp:LinkButton ID="CancelUpdate" runat="server" CssClass="btn btn-default" CommandName="Cancel">Cancel</asp:LinkButton>
                </th>
                     
                     <th><asp:TextBox ID="CompanyName" runat="server" Text="<%# BindItem.CompanyName %>" placeholder="Enter Company Name"></asp:TextBox> <br /></th>
                     <th><asp:TextBox ID="Contact" runat="server" Text="<%# BindItem.ContactName %>" placeholder=" Contact Name"></asp:TextBox> <br />
                     <asp:TextBox ID="JobTitle" runat="server" Text="<%# BindItem.ContactTitle %>" placeholder=" Job Title"></asp:TextBox> <br />
                        <asp:TextBox ID="Email" runat="server" Text="<%# BindItem.Email %>" placeholder=" Email"></asp:TextBox> <br />

                         </th>
                <th> 
                    <asp:DropDownList ID="AddressDropDown" runat="server" SelectedValue="<%# BindItem.AddressID %>" DataSourceID="AddressDataSource" AppendDataBoundItems="true" DataTextField="Address1" DataValueField="AddressID">
                        <asp:ListItem Value ="">[Select address on file]</asp:ListItem>
                    </asp:DropDownList>
                </th>

                <th> <asp:TextBox ID="Phone" runat="server" Text="<%# BindItem.Phone %>" placeholder=" Phone #"></asp:TextBox> <br /> 

                     <asp:TextBox ID="Fax" runat="server" Text="<%# BindItem.Fax %>" placeholder=" Fax"></asp:TextBox> <br />

                </th>

                     
                </tr>
        </EditItemTemplate>
    </asp:ListView>


    

    <asp:ObjectDataSource ID="AddressDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController" DataObjectTypeName="WestWindSystem.Entities.Supplier"
        InsertMethod="AddSupplier" OnInserted="CheckForExceptions" OnUpdated="CheckForExceptions" OnDeleted="CheckForExceptions" DeleteMethod="DeleteSupplier" UpdateMethod="UpdateSupplier">
    </asp:ObjectDataSource>
</asp:Content>
