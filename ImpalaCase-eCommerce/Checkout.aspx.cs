using ImpalaCase_eCommerce.DataBaseManager;
using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImpalaCase_eCommerce
{
    public partial class Checkout : System.Web.UI.Page
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

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (IsValid) {
                OrderManager oManager = new OrderManager();
                OrderBundleModule oModule = new OrderBundleModule(0, Convert.ToInt32(Session["Id"]), txtFullName.Text, txtContactNumber.Text, txtAddress.Text, txtCity.Text, txtZipcode.Text, 0.0m, 5.99m, DateTime.Now, "Pending", Convert.ToDecimal(Session["CartTotal"]));
                bool result = oManager.CreateOrder(oModule);
                if (result) {
                    Response.Redirect("/Cart");
                } else
                {
                    lblErrorMessage.Text = "There was some problem placing order please try again!!!";
                }
            }
        }
    }
}