using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

public partial class Pages_Management_Profile : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillPage();
    }

    private void FillPage()
    {
        var model = new UserInfoModel();
        var info = model.GetUserInformation(HttpContext.Current.User.Identity.GetUserId());
        if (info != null)
        {
            ProfileFirstName_txtb.Text = info.FirstName;
            ProfileLastName_txtb.Text = info.LastName;
            ProfileAddress_txtb.Text = info.Address;
            ProfilePostCode_txtb.Text = Convert.ToString(info.PostalCode);
            ProfilePhone_txtb.Text = Convert.ToString(info.Phone);
            ProfileMail_txtb.Text = info.EmailAddress;
            //ProfileMail_txtb.Enabled = false;
        }
    }

    protected void ProfileUpdate_btn_Click(object sender, EventArgs e)
    {
        ProfileResult_ltr.Text = "";
        try
        {
            var info = new UserInformation();
            var model = new UserInfoModel();
            info = model.GetUserInformation(HttpContext.Current.User.Identity.GetUserId());
            info.FirstName = ProfileFirstName_txtb.Text;
            info.LastName = ProfileLastName_txtb.Text;
            info.Address = ProfileAddress_txtb.Text;
            info.PostalCode = Convert.ToInt32(ProfilePostCode_txtb.Text);
            info.Phone = Convert.ToInt32(ProfilePhone_txtb.Text);
            info.EmailAddress = ProfileMail_txtb.Text;
            model.UpdateInformation(info);
            var userStore = new UserStore<IdentityUser>();

            //merge userStore DB with the existing Products DB
            userStore.Context.Database.Connection.ConnectionString =
                ConfigurationManager.ConnectionStrings["OnlineShopDB"].ConnectionString;

            var manager = new UserManager<IdentityUser>(userStore);
            var user = manager.FindById(HttpContext.Current.User.Identity.GetUserId());
            var provider = new DpapiDataProtectionProvider("E-Comerce Online Shop");
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            userManager.UserTokenProvider =
                new DataProtectorTokenProvider<IdentityUser>(provider.Create("EmailConfirmation"));
            if (user.Email != ProfileMail_txtb.Text)
            {
                user.Email = ProfileMail_txtb.Text;
                manager.Update(user);
                var emailConfirmationCode = manager.GenerateEmailConfirmationToken(user.Id);
                var callbackurl = "http://example.com/ConfirmEmail";
                callbackurl += string.Format("?userId={0}&code={1}", user.Id,
                    HttpUtility.UrlEncode(emailConfirmationCode));
                var htmlContent = string.Format(
                    @"Thank you for updating your email. Please confirm the email by clicking this link: 
                    <br><a href='{0}'>Confirm new email</a>",
                    callbackurl);
                manager.SendEmail(user.Id, "Email confirmation", htmlContent);
                ProfileResult_ltr.Text =
                    "User information has been updated successfully! Confirmation letter has been sent to your eMail: " +
                    user.Email;
            }

            ProfileResult_ltr.Text = "User information has been updated successfully!";
        }
        catch (Exception ex)
        {
            ProfileResult_ltr.Text = "Error: " + ex;
        }
    }
}