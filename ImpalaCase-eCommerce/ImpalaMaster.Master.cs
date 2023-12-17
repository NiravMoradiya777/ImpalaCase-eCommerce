using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImpalaCase_eCommerce
{
    public partial class ImpalaMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUserType();
            }
        }

        private void CheckUserType()
        {
            if (Session["UserType"] == null) Session["UserType"] = "";

            if (Session["UserType"].ToString() == "Admin")
            {
                adminPanel.Visible = true;
            }
            else
            {
                adminPanel.Visible = false;
            }

            if (!string.IsNullOrEmpty(Session["UserType"].ToString()))
            {
                userPanel.Visible = true;
            }
            else
            {
                guestMenuPanel.Visible = true;
            }
        }
    }
}