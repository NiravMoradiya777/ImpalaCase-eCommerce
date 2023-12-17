<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="ImpalaCase_eCommerce.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Shop</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="row justify-content-center" style="padding: 25px;">
        <div class="col-md-8">
            <div class="d-flex">
                <asp:TextBox runat="server" ID="txtSearchTitle" CssClass="form-control mr-sm-2" placeholder="Search by title" />
                <asp:TextBox runat="server" ID="txtSearchModel" CssClass="form-control mr-sm-2" placeholder="Search by Model" />
                <asp:Button runat="server" ID="search" CssClass="btn btn-outline-success my-2 my-sm-0" Text="Search" OnClick="search_Click" />
            </div>
            <div class="d-flex justify-content-left md-3 mt-2">
                <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlSortData" CssClass="form-control" OnSelectedIndexChanged="ddlSortData_SelectedIndexChanged">
                    <asp:ListItem Text="Sorted By" Value="" />
                    <asp:ListItem Text="Title" Value="Title" />
                    <asp:ListItem Text="Lower Price First" Value="Price" />
                    <asp:ListItem Text="Higher Price First" Value="Price DESC" />
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <section>
        <div class="container py-5">
            <div class="row justify-content-center">
                <asp:Repeater runat="server" ID="CaseRepeater" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        <div class="col-md-6 col-lg-4 mb-4">
                            <div class="card h-100">
                                <div class="d-flex justify-content-center">
                                    <asp:Image runat="server" CssClass="card-img-top w-50" ImageUrl='<%# "./images/" + Eval("Image") %>' AlternateText='<%# Eval("Image") %>' />
                                </div>
                                <div class="card-body p-4">
                                    <div class="text-center">
                                        <h5 class="fw-bolder"><%# Eval("Title") %></h5>
                                        $ <%# Eval("Price") %>
                                    </div>
                                </div>
                                <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                                    <div class="text-center">
                                        <a class="btn btn-outline-dark mt-auto" href='<%# GetCaseDetailURL(Convert.ToInt32(Eval("Id"))) %>'>View Detail</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT * FROM phone_case"></asp:SqlDataSource>
            </div>
        </div>
    </section>
</asp:Content>
