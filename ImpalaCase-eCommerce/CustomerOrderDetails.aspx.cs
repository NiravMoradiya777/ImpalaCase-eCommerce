using ImpalaCase_eCommerce.DataBaseManager;
using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImpalaCase_eCommerce
{
    public partial class CustomerOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["UserType"].ToString() != "Admin")
                {
                    Response.Redirect("/Home");
                }

                OrderManager oManager = new OrderManager();
                int bundleId = Convert.ToInt32((string)RouteData.Values["id"]);
                if (bundleId > 0)
                {
                    OrderBundleModule mainOrder = oManager.GetMainOrder(bundleId);
                    if (mainOrder != null)
                    {
                        lblFullName.Text = mainOrder.FullName;
                        lblContactNumber.Text = mainOrder.ContactNumber;
                        lblAddress.Text = mainOrder.Address;
                        lblCity.Text = mainOrder.City;
                        lblZIP.Text = mainOrder.ZIP;
                        lblDiscount.Text = mainOrder.Discount.ToString("C2");
                        lblShippingPrice.Text = mainOrder.ShippingPrice.ToString("C2");
                        lblStatus.Text = mainOrder.Status;
                        ddlStatus.SelectedValue = mainOrder.Status;

                        List<OrdersWithTitleModule> subOrders = oManager.GetSubOrders(bundleId);
                        gvSubOrders.DataSource = subOrders;
                        gvSubOrders.DataBind();
                    }
                }

            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderManager oManager = new OrderManager();
            int bundleId = Convert.ToInt32((string)RouteData.Values["id"]);
            string selectedStatus = ddlStatus.SelectedValue;
            oManager.UpdateOrderBundleStatus(bundleId, selectedStatus);
        }

    }
}