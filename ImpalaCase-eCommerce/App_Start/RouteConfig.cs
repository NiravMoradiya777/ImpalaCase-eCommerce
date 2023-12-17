using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace ImpalaCase_eCommerce
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // ignore WebResource.axd file
            routes.Ignore("{resource}.axd/{*pathInfo}");

            // map static routes
            routes.MapPageRoute("Home", "Home", "~/Home.aspx");
            routes.MapPageRoute("AddCase", "AddCase", "~/AddCase.aspx");
            routes.MapPageRoute("CaseList", "CaseList", "~/CaseList.aspx");
            routes.MapPageRoute("Shop", "Shop", "~/Shop.aspx");
            routes.MapPageRoute("Login", "Login", "~/Login.aspx");
            routes.MapPageRoute("PersonalInformation", "PersonalInformation", "~/PersonalInformation.aspx");
            routes.MapPageRoute("OrderHistory", "OrderHistory", "~/OrderHistory.aspx");
            routes.MapPageRoute("LogOut", "LogOut", "~/LogOut.aspx");
            routes.MapPageRoute("Cart", "Cart", "~/Cart.aspx");
            routes.MapPageRoute("Checkout", "Checkout", "~/Checkout.aspx");
            routes.MapPageRoute("Orders", "Orders", "~/Orders.aspx");

            // Define a route for case editing
            routes.MapPageRoute("EditCase", "EditCase/{id}", "~/EditCase.aspx");
            routes.MapPageRoute("CaseDetails", "CaseDetails/{id}", "~/CaseDetails.aspx");
            routes.MapPageRoute("CustomerOrderDetails", "CustomerOrderDetails/{id}", "~/CustomerOrderDetails.aspx");
        }
    }
}
