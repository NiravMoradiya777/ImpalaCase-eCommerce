<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="ImpalaCase_eCommerce.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customer Orders</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Customer Orders</h2>
        <asp:GridView ID="gvOrders" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataSourceID="sqlDataSourceOrders" OnRowCommand="gvOrders_RowCommand">
            <Columns>
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="Id" HeaderText="Order No" />
                <asp:BoundField DataField="Full_Name" HeaderText="Full Name" />
                <asp:BoundField DataField="Contact_Number" HeaderText="Contact Number" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="ZIP" HeaderText="ZIP" />
                <asp:BoundField DataField="Status" HeaderText="Order Status" />
                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C2}" />
                <asp:TemplateField HeaderText="View Details">
                    <ItemTemplate>
                        <asp:Button ID="btnViewDetails" runat="server" CssClass="btn btn-primary" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="sqlDataSourceOrders" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT ob.OrderDate, ob.Id, ob.Full_Name, ob.Contact_Number, ob.Address, ob.City, ob.ZIP, ob.Discount, ob.ShippingPrice, ob.Status, ob.Total
                              FROM orderbundle ob"></asp:SqlDataSource>
    </div>
</asp:Content>
