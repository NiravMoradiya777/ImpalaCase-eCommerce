<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ImpalaCase_eCommerce.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="container">
        <h2 class="text-center m-5">Cart List</h2>
        <div class="form-group">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
        </div>
        <asp:GridView ID="GridViewCart" runat="server" CssClass="table mt-2" AutoGenerateColumns="False"
            DataSourceID="SqlDataSourceCart" OnRowDataBound="GridViewCart_RowDataBound" OnDataBound="GridViewCart_DataBound" OnRowCommand="GridViewCart_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src='<%# "./images/" + Eval("Image") %>' alt="" border="3" height="100" width="50" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <%# string.Format("{0:C}", Convert.ToDouble(Eval("Price")) * Convert.ToInt32(Eval("Qty"))) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# GetSeeProductUrl(Convert.ToInt32(Eval("Case_Id"))) %>'>See Product</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LnkRemove" runat="server" CommandName="RemoveItem" CommandArgument='<%# Eval("Id") %>'
                            Text="Remove" CssClass="btn btn-danger btn-sm"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="card-deck mb-3 text-center w-50 float-right m-5">
            <div class="card mb-4 box-shadow lg-4">
                <div class="card-header">
                    <h4 class="my-0 font-weight-normal">Cart Total</h4>
                </div>
                <div class="card-body">
                    <table class="table">
                        <tr>
                            <td>
                                <h6>Product Total</h6>
                            </td>
                            <td>
                                <asp:Label ID="lblProductTotal" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <h6>Shipping</h6>
                            </td>
                            <td>
                                <h6>$5.99</h6>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h6>Sub Total</h6>
                            </td>
                            <td>
                                <asp:Label ID="lblSubTotal" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <h1 class="card-title pricing-card-title"><small class="text-muted">Total</small> /
                        <asp:Label ID="lblTotalHeading" runat="server"></asp:Label></h1>
                    <a CssClass="btn btn-lg btn-block btn-outline-primary" href='/Checkout'>Checkout</a>
                </div>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSourceCart" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT C.*, Ca.Title, Ca.Price, Ca.Image FROM Cart C INNER JOIN phone_case Ca ON C.Case_Id = Ca.Id  WHERE Login_Id = @LoginId">
        <SelectParameters>
            <asp:SessionParameter Name="LoginId" SessionField="Id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
