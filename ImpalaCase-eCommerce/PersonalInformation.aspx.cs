using ImpalaCase_eCommerce.DataBaseManager;
using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ImpalaCase_eCommerce
{
    public partial class PersonalInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null || Session["Email"].ToString() == "")
                {
                    Response.Redirect("/Home");
                }
                else
                {
                    int loginId = Convert.ToInt32(Session["Id"]);
                    PersonalInformationManager pInfoManager = new PersonalInformationManager();
                    UserDetailsModule userDetails = pInfoManager.GetUserDetails(loginId);

                    if (userDetails != null)
                    {
                        txtFName.Text = userDetails.FirstName;
                        txtMName.Text = userDetails.MiddleName;
                        txtLName.Text = userDetails.LastName;
                        txtDOB.Text = userDetails.DateOfBirth.ToString("yyyy-MM-dd");
                        txtAddress.Text = userDetails.Address;
                        txtId.Value = userDetails.Id.ToString();
                    }
                }
            }
        }

        protected void btnAddInfo_Click(object sender, EventArgs e)
        {
            int loginId = Convert.ToInt32(Session["Id"]);
            string fName = txtFName.Text;
            string mName = txtMName.Text;
            string lName = txtLName.Text;
            DateTime dob = DateTime.Parse(txtDOB.Text);
            string address = txtAddress.Text;

            UserDetailsModule userDetails = new UserDetailsModule(Convert.ToInt32(txtId.Value), loginId, fName, mName, lName, dob, address);
            PersonalInformationManager pInfoManager = new PersonalInformationManager();

            bool updateResult = false;
            if (userDetails.Id == 0)
            {
                updateResult = pInfoManager.InsertUserDetails(userDetails);
            }
            else
            {
                updateResult = pInfoManager.UpdateUserDetails(userDetails);
            }

            if (updateResult) {
                lblMessage.Text = "Data Updated Successfully!";
            } else
            {
                lblErrorMessage.Text = "There was some problem updating information please try again!!!";
            }
        }
    }
}