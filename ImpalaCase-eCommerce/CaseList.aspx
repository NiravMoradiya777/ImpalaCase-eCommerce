<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="CaseList.aspx.cs" Inherits="ImpalaCase_eCommerce.CaseList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="container">
        <h2 class="text-center m-5">Case List</h2>

        <asp:Panel runat="server" CssClass="form-inline my-3 my-lg-3 float-right">
            <asp:TextBox ID="txtSearchTitle" runat="server" CssClass="form-control mr-sm-2" placeholder="Search by title"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-outline-success my-2 my-sm-0" Text="Search" OnClick="btnSearch_Click" />
        </asp:Panel>

        <asp:SqlDataSource ID="sqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT Title, Color, Compatible_phone_models, Price, Id FROM phone_case"></asp:SqlDataSource>

        <asp:GridView ID="gvCases" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataSourceID="sqlDataSource" ShowHeaderWhenEmpty="true">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Color" HeaderText="Color" />
                <asp:BoundField DataField="Compatible_phone_models" HeaderText="Compatible Phone Model" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <a href='<%# GetEditCaseUrl(Convert.ToInt32(Eval("Id"))) %>'>Edit</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
