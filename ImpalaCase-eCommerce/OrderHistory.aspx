<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="ImpalaCase_eCommerce.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order History</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="container py-5">
        <asp:SqlDataSource ID="sqlDataSourceOrders" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM orderbundle WHERE Login_Id = @LoginId ORDER BY OrderDate DESC">
            <SelectParameters>
                <asp:SessionParameter Name="LoginId" SessionField="Id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:Repeater ID="rptOrders" runat="server" DataSourceID="sqlDataSourceOrders" OnItemDataBound="rptOrders_ItemDataBound">
            <ItemTemplate>
                <section class="h-100 gradient-custom">
                    <div class="container py-5 h-100">
                        <div class="row d-flex justify-content-center align-items-center h-100">
                            <div class="col-lg-10 col-xl-8">
                                <div class="card" style="border-radius: 10px; margin: 0 auto;">
                                    <div class="card-header px-4">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <p>
                                                        Order Date:
                                                        <asp:Label ID="lblOrderDate" runat="server" Text='<%# DateTime.Parse(Eval("OrderDate").ToString()).ToString("yyyy-MM-dd") %>' />
                                                    </p>
                                                </td>
                                                <td class="text-right">
                                                    <p>
                                                        Order No <span style="color: #a8729a;">
                                                            <asp:Label ID="lblBundleId" runat="server" Text='<%# Eval("Id") %>' /></span>
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <p>
                                                        Order Status:
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' />
                                                    </p>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                        <asp:Repeater ID="rptSubOrders" runat="server">
                                            <ItemTemplate>
                                                <div class="card shadow-0 border mb-4">
                                                    <div class="card-body">
                                                        <div class="row" style="margin-top: 10px;">
                                                            <div class="col-md-2">
                                                                <asp:Image ID="imgCase" runat="server" ImageUrl='<%# "./images/" + Eval("Image") %>'
                                                                    Width="80" Height="150" CssClass="img-fluid" AlternateText='<%# Eval("Image") %>' />
                                                            </div>
                                                            <div class="col-md-2 text-center d-flex justify-content-center align-items-center">
                                                                <p class="text-muted mb-0">
                                                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' />
                                                                </p>
                                                            </div>
                                                            <div class="col-md-2 text-center d-flex justify-content-center align-items-center">
                                                                <p class="text-muted mb-0 small">
                                                                    Qty:
                                                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Qty") %>' />
                                                                </p>
                                                            </div>
                                                            <div class="col-md-2 text-center d-flex justify-content-center align-items-center">
                                                                <p class="text-muted mb-0 small">
                                                                    $
                                                                    <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Eval("UnitPrice") %>' />
                                                                </p>
                                                            </div>
                                                            <div class="col-md-2 text-center d-flex justify-content-center align-items-center">
                                                                <p class="text-muted mb-0 small">
                                                                    $
                                                                    <asp:Label ID="lblTotalPrice" runat="server" Text='<%# (Convert.ToDecimal(Eval("Qty")) * Convert.ToDecimal(Eval("UnitPrice"))).ToString("0.00") %>' />
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </ItemTemplate>
        </asp:Repeater>

        <asp:SqlDataSource ID="sqlDataSourceSubOrders" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT o.Id, o.Case_Id, o.UnitPrice, o.Qty, pc.Title, pc.Image FROM orders o INNER JOIN phone_case pc ON o.Case_Id = pc.Id WHERE o.Bundle_Id = @BundleId">
            <SelectParameters>
                <asp:Parameter Name="BundleId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
