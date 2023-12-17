using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace ImpalaCase_eCommerce
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void search_Click(object sender, EventArgs e)
        {
            performSearch();
        }

        protected void ddlSortData_SelectedIndexChanged(object sender, EventArgs e)
        {
            performSearch();
        }

        private void performSearch() {
            String orderBy = "Title";
            if (ddlSortData.SelectedValue != "")
            { orderBy = ddlSortData.SelectedValue; }
            // Modify the SelectCommand of the SqlDataSource based on search criteria
            SqlDataSource1.SelectCommand = "SELECT * FROM phone_case where Title like '%" + txtSearchTitle.Text + "%' and Compatible_phone_models like '%" + txtSearchModel.Text + "%' order by " + orderBy;
            CaseRepeater.DataBind();
        }

        protected string GetCaseDetailURL(int caseId)
        {
            var pageUrl = RouteTable.Routes.GetVirtualPath(null, "CaseDetails", new RouteValueDictionary { { "id", caseId } }).VirtualPath;
            return VirtualPathUtility.ToAbsolute("~" + pageUrl);
        }
    }
}