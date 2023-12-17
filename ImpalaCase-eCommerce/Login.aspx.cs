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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] != null && Session["Email"].ToString() != "") {
                Response.Redirect("/Home");
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            LoginManager lManager = new LoginManager();
            LoginModule loginDetails = lManager.ValidateCredentials(txtEmail.Text, txtPassword.Text);
            if (loginDetails != null) {
                Session["Id"] = loginDetails.Id;
                Session["Email"] = loginDetails.Email;
                Session["UserType"] = loginDetails.UserType;
                Response.Redirect("/Home");
            } else
            {
                lblLoginErrorMsg.Text = "Wrong Cradentials!";
            }
        }

        protected void signUpButton_Click(object sender, EventArgs e)
        {
            LoginManager lManager = new LoginManager();
            bool result = lManager.CreateUser(txtSignUpEmail.Text, txtSignUpPassword.Text, "Customer");
            if (result) {
                Response.Redirect("/Login");
            } else
            {
                lblSIgnUpErrorMsg.Text = "There was some problem creating account please try again!!!";
            }
        }
    }
}