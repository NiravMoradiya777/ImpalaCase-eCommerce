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
    public partial class CaseDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int caseId = 0;
                if (int.TryParse((string)RouteData.Values["id"], out caseId))
                {
                    PhoneCaseManager pcManager = new PhoneCaseManager();
                    PhoneCaseModule caseDetails = pcManager.GetCaseById(caseId);
                    if (caseDetails != null)
                    {
                        lblTitle.Text = caseDetails.Title;
                        lblPrice.Text = "$" + caseDetails.Price.ToString();
                        lblShortDescription.Text = caseDetails.ShortDescription;
                        lblAbout.Text = caseDetails.About;
                        lblLongDescription.Text = caseDetails.LongDescription;
                        lblWeight.Text = caseDetails.Weight + "Kg";
                        lblDimensions.Text = caseDetails.Dimensions;
                        lblColour.Text = caseDetails.Color;
                        lblModel.Text = caseDetails.CompatiblePhoneModels;
                        lblMaterial.Text = caseDetails.Material;
                        imgProduct.ImageUrl = "./images/" + caseDetails.Image;
                        phNoDataFound.Visible = false;
                        phShowData.Visible = true;
                    }
                    else
                    {
                        phNoDataFound.Visible = true;
                        phShowData.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("Home");
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (Session["Email"] == null || Session["Email"].ToString() == "")
            {
                Response.Redirect("/Login");
            }
            else
            {
                //Add to cart
                CartManager cManager = new CartManager();

                List<CartModule> cartWithCaseId = cManager.GetCartByCaseIdAndLoginId(Int32.Parse(RouteData.Values["id"].ToString()), Convert.ToInt32(Session["Id"]));

                if (cartWithCaseId.Count > 0)
                {
                    bool result = cManager.UpdateCartQty(cartWithCaseId[0].Id, Int32.Parse(txtQuantity.Text));
                    if (result)
                    {
                        lblMessage.Text = "Your cart has been updated!!";
                    }
                    else
                    {
                        lblErrorMessage.Text = "There was some problem adding to the cart please try again!!!";
                    }
                }
                else
                {
                    bool result = cManager.AddToCart(new CartModule(0, Convert.ToInt32(Session["Id"]), Int32.Parse(RouteData.Values["id"].ToString()), Int32.Parse(txtQuantity.Text)));
                    if (result)
                    {
                        lblMessage.Text = "Added to the cart";
                    }
                    else
                    {
                        lblErrorMessage.Text = "There was some problem adding to the cart please try again!!!";
                    }
                }
            }
        }
    }
}