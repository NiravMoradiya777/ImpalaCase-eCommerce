using ImpalaCase_eCommerce.DataBaseManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImpalaCase_eCommerce
{
    public partial class Cart : System.Web.UI.Page
    {
        private double cartTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["Email"].ToString() == "")
                {
                    Response.Redirect("/Home");
                }
            }
        }

        protected void GridViewCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the data for the current row
                DataRowView rowView = e.Row.DataItem as DataRowView;

                if (rowView != null)
                {
                    double price = Convert.ToDouble(rowView["Price"]);
                    int quantity = Convert.ToInt32(rowView["Qty"]);

                    double total = price * quantity;

                    // Update the cart total
                    cartTotal += total;
                    lblProductTotal.Text = string.Format("{0:C}", cartTotal);
                }
            }
        }

        protected void GridViewCart_DataBound(object sender, EventArgs e)
        {
            lblProductTotal.Text = "$" + cartTotal.ToString();
            lblSubTotal.Text = "$" + (cartTotal + 5.99).ToString();
            lblTotalHeading.Text = "$" + (cartTotal + 5.99).ToString();
            Session["CartTotal"] = (cartTotal + 5.99);
        }

        protected void GridViewCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveItem")
            {
                CartManager cManager = new CartManager();
                int cartId = Convert.ToInt32(e.CommandArgument);
                bool result = cManager.DeleteCartItem(cartId);

                if (result)
                {
                    // Rebind the GridView to reflect the updated cart contents
                    GridViewCart.DataBind();
                    lblMessage.Text = "Case Removed From Cart!";
                }
                else
                {
                    lblErrorMessage.Text = "There was some problem removing case from cart please try again!!!";
                }
            }
        }

        protected string GetSeeProductUrl(int caseId)
        {
            var pageUrl = RouteTable.Routes.GetVirtualPath(null, "CaseDetails", new RouteValueDictionary { { "id", caseId } }).VirtualPath;
            return VirtualPathUtility.ToAbsolute("~" + pageUrl);
        }

    }
}