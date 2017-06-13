using System;
using System.Configuration;
using System.Net.Mail;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SendGrid;

public partial class Pages_ForgotPass : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ForgotPassConfirm_btn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ForgotPassMail_txtb.Text))
        {
            var userStore = new UserStore<IdentityUser>();

            //merge userStore DB with the existing Products DB
            userStore.Context.Database.Connection.ConnectionString =
                ConfigurationManager.ConnectionStrings["OnlineShopDB"].ConnectionString;

            var manager = new UserManager<IdentityUser>(userStore);

            //Find the user with the given Email.
            var user = manager.FindByEmail(ForgotPassMail_txtb.Text);

            if (user != null)
            {
                user.PasswordHash = manager.PasswordHasher.HashPassword("12345678");
                manager.Update(user);

                // api key from SendGrid.
                var apiKey = "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";
                // create a Web transport, using API Key
                var transportWeb = new Web(apiKey);
                // Create the email object first, then add the properties.
                SendGridMessage myMessage = new SendGridMessage();
                myMessage.AddTo(ForgotPassMail_txtb.Text);
                myMessage.From = new MailAddress("tiz00003nt@myntec.ac.nz", "E-Comerce Online Shop");
                myMessage.Subject = "Password Recovery";
                myMessage.Html =
                    string.Format(
                        "Hi {0},<br /><br />Your temporary password is {1}. Please, do not forget to change it!<br /><br />Kind Regards.<br />E-Comerce Online Shop.",
                        user.UserName, "12345678");
                // Send the email, which returns an awaitable task.
                transportWeb.DeliverAsync(myMessage);

                ForgotPassResult_lit.Text = "Temporary password has been sent to the email:" + ForgotPassMail_txtb.Text;
            }
            else
            {
                ForgotPassResult_lit.Text = "Sorry, this email addres is not registered.";
            }
        }
        else
        {
            ForgotPassResult_lit.Text = "Please, enter your Email address.";
        }
    }
}