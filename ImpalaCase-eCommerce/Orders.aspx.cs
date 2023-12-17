using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImpalaCase_eCommerce
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["UserType"].ToString() != "Admin")
                {
                    Response.Redirect("/Home");
                }
            }
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int bundleId = Convert.ToInt32(e.CommandArgument);
                RouteValueDictionary parameters = new RouteValueDictionary();
                parameters.Add("id", bundleId);

                string url = RouteTable.Routes.GetVirtualPath(null, "CustomerOrderDetails", parameters).VirtualPath;
                Response.Redirect(url);
            }
        }
    }
}