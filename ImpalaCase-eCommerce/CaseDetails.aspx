<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="CaseDetails.aspx.cs" Inherits="ImpalaCase_eCommerce.CaseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Case Details</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainBody" runat="server">
    <div class="form-group">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
    </div>

    <div class="form-group">
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
    </div>
    <div>
        <div class="container py-5">
            <div class="row" style="padding: 25px;">
                <asp:PlaceHolder ID="phNoDataFound" runat="server" Visible="false">
                    <div class="col-md-12 col-lg-4 mb-4 mb-lg-0">
                        <h1>No case found</h1>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phShowData" runat="server" Visible="false">
                    <section class="py-5">
                        <a href="/shop">< Continue Shopping</a>
                        <div class="container px-4 px-lg-5">
                            <div class="row gx-4 gx-lg-5">
                                <div class="col-md-6">
                                    <asp:Image ID="imgProduct" runat="server" CssClass="card-img-top mb-5 mb-md-0 w-75" />
                                </div>
                                <div class="col-md-6 p-5">
                                    <h1 class="display-5 fw-bolder">
                                        <asp:Label runat="server" ID="lblTitle" />
                                    </h1>
                                    <div class="fs-5 mb-5">
                                        <asp:Label runat="server" ID="lblPrice" CssClass="h4" />
                                    </div>
                                    <p class="lead">
                                        <asp:Label runat="server" ID="lblShortDescription" />
                                    </p>
                                    <div class="fs-5">
                                        <h3>About this item</h3>
                                    </div>
                                    <p class="lead">
                                        <asp:Label runat="server" ID="lblAbout" />
                                    </p>
                                    <div class="d-flex">
                                        <div style="overflow: hidden; padding-right: .5em;">
                                            <label for="txtQuantity">Quantity: </label>
                                            <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control text-center me-3 ml-2" Text="1" MaxLength="3" />
                                            <asp:RequiredFieldValidator ID="rfvWeight" runat="server" ControlToValidate="txtQuantity"
                                                InitialValue="" ErrorMessage="Quantity is required" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revWeight" runat="server" ControlToValidate="txtQuantity"
                                                ValidationExpression="^\d+$" ErrorMessage="Please enter a valid numeric value."
                                                Display="Dynamic" CssClass="text-danger" />
                                        </div>
                                    </div>
                                    <asp:Button runat="server" ID="btnAddToCart" Text="Add to Cart" CssClass="btn btn-dark p-2 pl-5 pr-5 ml-2 m-2" OnClick="btnAddToCart_Click" />
                                </div>
                            </div>
                        </div>
                    </section>
                    <div class="container mt-5">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="underlined-title-container">
                                    <h4 class="underlined-title active" id="description-title">Description</h4>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="content active" id="description-content">
                                    <p>
                                        <asp:Label runat="server" ID="lblLongDescription" />
                                    </p>
                                </div>
                                <div class="col-md-12">
                                    <div class="underlined-title-container">
                                        <h4 class="underlined-title" id="additionalInfo-title">Additional Information</h4>
                                    </div>
                                </div>
                                <div class="content" id="additionalInfo-content">
                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <td>Weight</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblWeight" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Dimensions</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblDimensions" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Colour</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblColour" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Compatible phone models</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblModel" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Material</td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblMaterial" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>
