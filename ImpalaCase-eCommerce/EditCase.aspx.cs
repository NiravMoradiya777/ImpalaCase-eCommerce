using ImpalaCase_eCommerce.DataBaseManager;
using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImpalaCase_eCommerce
{
    public partial class EditCase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["UserType"].ToString() != "Admin")
                {
                    Response.Redirect("/Home");
                }

                int caseId = 0;
                if (int.TryParse((string)RouteData.Values["id"], out caseId))
                {
                    PhoneCaseManager pcManager = new PhoneCaseManager();
                    PhoneCaseModule caseById = pcManager.GetCaseById(caseId);
                    if (caseById != null)
                    {
                        txtId.Text = caseById.Id.ToString();
                        txtTitle.Text = caseById.Title;
                        txtShortDescription.Text = caseById.ShortDescription;
                        txtLongDescription.Text = caseById.LongDescription;
                        txtAbout.Text = caseById.About;
                        txtWeight.Text = caseById.Weight.ToString();
                        // Split Dimensions and set individual fields
                        string[] dimensions = caseById.Dimensions.Replace(" cm", "").Split('x');
                        if (dimensions.Length == 3)
                        {
                            txtLength.Text = dimensions[0];
                            txtWidth.Text = dimensions[1];
                            txtDepth.Text = dimensions[2];
                        }
                        txtColor.Text = caseById.Color;
                        ddlModel.SelectedValue = caseById.CompatiblePhoneModels;
                        txtMaterial.Text = caseById.Material;
                        txtPrice.Text = caseById.Price.ToString();
                        ddlStatus.SelectedValue = caseById.IsActive.ToString();
                    }

                }
                else
                {
                    Response.Redirect("Home");
                }
            }
        }

        protected void btnUpdateCase_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {

                string dimention = txtLength.Text + "x" + txtWidth.Text + "x" + txtDepth.Text + " cm";
                    PhoneCaseManager pcManager = new PhoneCaseManager();

                bool success = pcManager.UpdateCase(new PhoneCaseModule(Int32.Parse(txtId.Text),
                    txtTitle.Text,
                    "",
                    txtShortDescription.Text,
                    txtLongDescription.Text,
                    txtAbout.Text,
                    Decimal.Parse(txtWeight.Text),
                    dimention,
                    txtColor.Text,
                    ddlModel.SelectedValue,
                    txtMaterial.Text,
                    Decimal.Parse(txtPrice.Text),
                    Boolean.Parse(ddlStatus.SelectedValue)
                ));

                if (success)
                {
                    lblMessage.Text = "Case Updated Successfully";
                }
                else
                {
                    lblErrorMessage.Text = "There was some problem updating case please try again!!!";
                }
            }
        }

        protected string GetCaseEditUrl(int caseId)
        {
            var pageUrl = RouteTable.Routes.GetVirtualPath(null, "EditCase", new RouteValueDictionary { { "id", caseId } }).VirtualPath;
            return VirtualPathUtility.ToAbsolute("~" + pageUrl);
        }
    }
}