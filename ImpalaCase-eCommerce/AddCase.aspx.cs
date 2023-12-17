using ImpalaCase_eCommerce.DataBaseManager;
using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImpalaCase_eCommerce
{
    public partial class AddCase : System.Web.UI.Page
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

        protected void btnAddCase_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {

                string dimention = txtLength.Text + "x" + txtWidth.Text + "x" + txtDepth.Text + " cm";
                HttpPostedFile file = fileToUpload.PostedFile;

                if (file != null && file.ContentLength > 0)
                {
                    // Get the file extension
                    string fileExtension = Path.GetExtension(file.FileName).ToLower();

                    // List of allowed image extensions
                    string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    // Check if the file extension is Image
                    if (imageExtensions.Contains(fileExtension))
                    {
                        // Get the filename
                        string fileName = Path.GetFileName(file.FileName);

                        // Construct the path to save the file
                        string filePath = Server.MapPath("~/Images/") + fileName;

                        // Save the file to the specified path
                        file.SaveAs(filePath);

                        PhoneCaseManager pcManager = new PhoneCaseManager();

                        bool success = pcManager.AddCase(new PhoneCaseModule(0,
                            txtTitle.Text,
                            file.FileName,
                            txtShortDescription.Text,
                            txtLongDescription.Text,
                            txtAbout.Text,
                            Decimal.Parse(txtWeight.Text),
                            dimention,
                            txtColor.Text,
                            ddlModel.SelectedValue,
                            txtMaterial.Text,
                            Decimal.Parse(txtPrice.Text)
                        ));

                        if (success)
                        {
                            lblMessage.Text = "Case Addedd Successfully";
                        }
                        else
                        {
                            lblErrorMessage.Text = "There was some problem adding case please try again!!!";
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = "File should be image only";
                    }
                }
            }
        }
    }
}