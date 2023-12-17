<%@ Page Title="" Language="C#" MasterPageFile="~/ImpalaMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ImpalaCase_eCommerce.Home" %>
<asp:Content ID="cHead" ContentPlaceHolderID="head" runat="server">
    <title>Home</title>
</asp:Content>
<asp:Content ID="cMainBody" ContentPlaceHolderID="cphMainBody" runat="server">

    <h1>Home</h1>

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <!-- Hero -->
    <style>
        /* Default height for small devices */
        #intro-example {
            height: 400px;
        }

        /* Height for devices larger than 992px */
        @media (min-width: 992px) {
            #intro-example {
                height: 600px;
            }
        }
    </style>
    <div id="intro-example" class="p-5 text-center bg-image"
        style="background-image: url('Images/Home Page Photo - Copy.png'); width: 130%;margin-left:-180px;">
        <div class="mask" style="background-color: rgba(0, 0, 0, 0.7);">
            <div class="d-flex justify-content-center align-items-center h-100">
                <div class="text-white">
                    <h1 class="mb-3">Impala Case</h1>
                    <h5 class="mb-4">Best Cover For Your Phones
                    </h5>

                </div>
            </div>
        </div>
    </div>
    <!-- Hero -->
</asp:Content>