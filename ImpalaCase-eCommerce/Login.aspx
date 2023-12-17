<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ImpalaCase_eCommerce.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
    <style>
        /* Add custom styles here */
        .container {
            text-align: center;
        }

        #authTabsContent {
            padding-top: 20px;
        }

        .tab-pane {
            padding: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 border rounded p-4 bg-light">
                <ul class="nav nav-tabs nav-fill mb-3" id="authTabs" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="login-tab" data-toggle="tab" href="#login" role="tab" aria-controls="login" aria-selected="true">Login</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="signup-tab" data-toggle="tab" href="#signup" role="tab" aria-controls="signup" aria-selected="false">Sign Up</a>
                    </li>
                </ul>
                <div class="tab-content" id="authTabsContent">
                    <div class="tab-pane fade show active" id="login" role="tabpanel" aria-labelledby="login-tab">
                        <h2 class="text-center">Login</h2>
                        <div class="form-group">
                            <asp:Label ID="lblLoginErrorMsg" runat="server" CssClass="text-danger"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" placeholder="Email" />
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Email is required." CssClass="text-danger" Display="Dynamic" ValidationGroup="loginValidations" />
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control mb-3" placeholder="Password" />
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Password is required." CssClass="text-danger" Display="Dynamic" ValidationGroup="loginValidations" />
                        <asp:Button ID="loginButton" runat="server" Text="Login" CssClass="btn btn-primary btn-block" OnClick="loginButton_Click" ValidationGroup="loginValidations" />
                    </div>
                    <div class="tab-pane fade" id="signup" role="tabpanel" aria-labelledby="signup-tab">
                        <h2 class="text-center">Sign Up</h2>
                        <div class="form-group">
                            <asp:Label ID="lblSIgnUpErrorMsg" runat="server" CssClass="text-danger"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtSignUpEmail" runat="server" CssClass="form-control mb-3" placeholder="Email" />
                        <asp:RequiredFieldValidator ID="rfvSignupEmail" runat="server" ControlToValidate="txtSignUpEmail"
                            ErrorMessage="Email is required." CssClass="text-danger" Display="Dynamic" ValidationGroup="signUpValidations" />
                        <asp:TextBox ID="txtSignUpPassword" runat="server" TextMode="Password" CssClass="form-control mb-3" placeholder="Password" />
                        <asp:RequiredFieldValidator ID="rfvSignupPassword" runat="server" ControlToValidate="txtSignUpPassword"
                            ErrorMessage="Password is required." CssClass="text-danger" Display="Dynamic" ValidationGroup="signUpValidations" />
                        <asp:TextBox ID="signupConfirmPassword" runat="server" TextMode="Password" CssClass="form-control mb-3" placeholder="Confirm Password" />
                        <asp:RequiredFieldValidator ID="rfvSignupConfirmPassword" runat="server" ControlToValidate="signupConfirmPassword"
                            ErrorMessage="Confirm Password is required." CssClass="text-danger" Display="Dynamic" ValidationGroup="signUpValidations" />
                        <asp:CompareValidator ID="cvPasswordMatch" runat="server" ControlToValidate="signupConfirmPassword"
                            ControlToCompare="txtSignUpPassword" Operator="Equal" Type="String"
                            ErrorMessage="Passwords must match." CssClass="text-danger" Display="Dynamic" ValidationGroup="signUpValidations" />
                        <asp:Button ID="signupButton" runat="server" Text="Sign Up" CssClass="btn btn-success btn-block" OnClick="signUpButton_Click" ValidationGroup="signUpValidations" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
