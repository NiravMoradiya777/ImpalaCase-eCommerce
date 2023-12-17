<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="PersonalInformation.aspx.cs" Inherits="ImpalaCase_eCommerce.PersonalInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Personal Information</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="p-5 form-modal">
        <h1 style="text-align: center; margin: 30px;">Personal Information</h1>
        <div class="form-group">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
        </div>
        <div class="form-group">
            <asp:HiddenField ID="txtId" runat="server" Value="0" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblFName" runat="server" AssociatedControlID="txtFName">First Name</asp:Label>
            <asp:TextBox ID="txtFName" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblMName" runat="server" AssociatedControlID="txtMName">Middle Name</asp:Label>
            <asp:TextBox ID="txtMName" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblLName" runat="server" AssociatedControlID="txtLName">Last Name</asp:Label>
            <asp:TextBox ID="txtLName" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDOB" runat="server" AssociatedControlID="txtDOB">Date Of Birth</asp:Label>
            <asp:TextBox ID="txtDOB" type="date" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress">Address</asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
        </div>
        <asp:Button ID="btnAddInfo" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnAddInfo_Click" />
        <hr />
    </div>
</asp:Content>
