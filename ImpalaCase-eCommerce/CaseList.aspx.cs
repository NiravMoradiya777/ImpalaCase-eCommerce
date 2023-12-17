using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImpalaCase_eCommerce
{
    public partial class CaseList : System.Web.UI.Page
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Modify the SelectCommand of the SqlDataSource based on search criteria
            sqlDataSource.SelectCommand = "SELECT Title, Color, Compatible_phone_models, Price, Id FROM phone_case WHERE Title LIKE '%" + txtSearchTitle.Text + "%'";
            gvCases.DataBind();
        }

        protected string GetEditCaseUrl(int caseId)
        {
            var pageUrl = RouteTable.Routes.GetVirtualPath(null, "EditCase", new RouteValueDictionary { { "id", caseId } }).VirtualPath;
            return VirtualPathUtility.ToAbsolute("~" + pageUrl);
        }
    }
}