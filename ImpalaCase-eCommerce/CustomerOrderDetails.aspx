<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="CustomerOrderDetails.aspx.cs" Inherits="ImpalaCase_eCommerce.CustomerOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customer's Orders Detail</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="container mt-5">

        <div class="row">
            <div class="col-md-6">
                <h4>
                    <asp:Label ID="lblOrderNo" runat="server" CssClass="info-label" Text=""></asp:Label></h4>
                <table class="table table-striped">
                    <tr>
                        <td>Full Name</td>
                        <td>
                            <asp:Label ID="lblFullName" runat="server" CssClass="info-label" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Contact Number</td>
                        <td>
                            <asp:Label ID="lblContactNumber" runat="server" CssClass="info-label" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Address</td>
                        <td>
                            <asp:Label ID="lblAddress" runat="server" CssClass="info-label" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>City</td>
                        <td>
                            <asp:Label ID="lblCity" runat="server" CssClass="info-label" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>ZIP</td>
                        <td>
                            <asp:Label ID="lblZIP" runat="server" CssClass="info-label" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Discount</td>
                        <td>
                            <asp:Label ID="lblDiscount" runat="server" CssClass="info-label" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Shipping Price</td>
                        <td>
                            <asp:Label ID="lblShippingPrice" runat="server" CssClass="info-label" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Status</td>
                        <td>
                            <asp:Label ID="lblStatus" runat="server" CssClass="info-label" Text=""></asp:Label></td>
                    </tr>
                </table>
                <br />
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                    <asp:ListItem Text="Processing" Value="Processing"></asp:ListItem>
                    <asp:ListItem Text="Shipped" Value="Shipped"></asp:ListItem>
                    <asp:ListItem Text="Delivered" Value="Delivered"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <asp:GridView ID="gvSubOrders" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
            <Columns>
                <asp:ImageField DataImageUrlField="Image" HeaderText="Image" ControlStyle-Width="50" ControlStyle-Height="100" DataImageUrlFormatString="~/Images/{0}">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:ImageField>
                <asp:BoundField DataField="Title" HeaderText="Product Title" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C2}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
