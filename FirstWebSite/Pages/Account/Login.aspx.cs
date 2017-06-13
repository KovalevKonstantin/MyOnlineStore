using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

public partial class Pages_Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void LoginSubmit_btn_Click(object sender, EventArgs e)
    {
        var userStore = new UserStore<IdentityUser>();

        //merge userStore DB with the existing Products DB
        userStore.Context.Database.Connection.ConnectionString =
            ConfigurationManager.ConnectionStrings["OnlineShopDB"].ConnectionString;

        //check if Username or Password is empty
        var manager = new UserManager<IdentityUser>(userStore);

        var user = manager.Find(LoginUsername_txtb.Text, LoginPassword_txtb.Text);
        if (user != null)
        {
            var umodel = new UserInfoModel();
            var info = umodel.GetUserInformation(user.Id);
            if (info.IsBlocked)
            {
                LoginResult_lit.Text =
                    "Your account has been blocked by administrator. Please, contact him for further details.";
                return;
            }
            //OWIN functionality
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            //Sign In the user
            authenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, userIdentity);
            //redirecting user to homepage
            Response.Redirect("~/Index.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else
        {
            LoginResult_lit.Text = "Invalid Username or Password!";
        }
    }

    protected void ProfileForgotPass_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/ForgotPass.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }
}