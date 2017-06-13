using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

public partial class Pages_ChangePassword : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void PopUpConfirm_btn_Click(object sender, EventArgs e)
    {
        PopUpResult_lit.Text = "";
        var userStore = new UserStore<IdentityUser>();

        //merge userStore DB with the existing Products DB
        userStore.Context.Database.Connection.ConnectionString =
            ConfigurationManager.ConnectionStrings["OnlineShopDB"].ConnectionString;

        //check if Username or Password is empty
        var manager = new UserManager<IdentityUser>(userStore);

        var user = manager.Find(HttpContext.Current.User.Identity.Name, PopUpOldPass_txtb.Text);
        if (user != null)
            if (PopUpNewPass_txtb.Text == PopUpConfirmPass_txtb.Text)
            {
                user.PasswordHash = manager.PasswordHasher.HashPassword(PopUpNewPass_txtb.Text);
                var result = manager.Update(user);
                if (!result.Succeeded)
                    PopUpResult_lit.Text = "Cannot change the Password! Try again latter.";
            }
            else
            {
                PopUpResult_lit.Text = "Confirmation Password does not match!";
            }
        else
            PopUpResult_lit.Text = "Invalid Old Password!";

        Response.Redirect("~/Pages/Profile.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }
}