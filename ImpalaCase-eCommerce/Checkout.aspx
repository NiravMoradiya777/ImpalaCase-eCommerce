<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="ImpalaCase_eCommerce.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Checkout</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Checkout</h2>
        <div class="form-group">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblFullName" runat="server" AssociatedControlID="txtFullName">Full Name</asp:Label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName"
                InitialValue="" ErrorMessage="Full Name is required." Display="Dynamic" CssClass="text-danger" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblContactNumber" runat="server" AssociatedControlID="txtContactNumber">Contact Number</asp:Label>
            <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" ControlToValidate="txtContactNumber"
                InitialValue="" ErrorMessage="Contact Number is required." Display="Dynamic" CssClass="text-danger" />
            <asp:RegularExpressionValidator ID="revContactNumber" runat="server" ControlToValidate="txtContactNumber"
                ValidationExpression="^\d{10}$" ErrorMessage="Enter a valid 10-digit Contact Number." Display="Dynamic" CssClass="text-danger" />
        </div>

        <!-- Shipping Address -->
        <h4 class="mt-4">Shipping Address</h4>
        <div class="form-group">
            <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress">Address</asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                InitialValue="" ErrorMessage="Address is required." Display="Dynamic" CssClass="text-danger" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity">City</asp:Label>
            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                InitialValue="" ErrorMessage="City is required." Display="Dynamic" CssClass="text-danger" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblZipcode" runat="server" AssociatedControlID="txtZipcode">ZIP Code</asp:Label>
            <asp:TextBox ID="txtZipcode" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvZipcode" runat="server" ControlToValidate="txtZipcode"
                InitialValue="" ErrorMessage="ZIP Code is required." Display="Dynamic" CssClass="text-danger" />
        </div>

        <!-- Payment Information -->
        <p class="mt-4">Payment Information:</p>
        <h4>Cash On Delivery</h4>

        <!-- Submit Button -->
        <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" CssClass="btn btn-primary btn-block" OnClick="btnPlaceOrder_Click" />
    </div>
</asp:Content>
