using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImpalaCase_eCommerce
{
    public partial class OrderHistory : System.Web.UI.Page
    {
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

        protected void rptOrders_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptSubOrders = e.Item.FindControl("rptSubOrders") as Repeater;
                rptSubOrders.DataSource = sqlDataSourceSubOrders;

                Label lblBundleId = e.Item.FindControl("lblBundleId") as Label;
                if (lblBundleId != null)
                {
                    sqlDataSourceSubOrders.SelectParameters["BundleId"].DefaultValue = lblBundleId.Text;
                }

                rptSubOrders.DataBind();
            }
        }
    }
}