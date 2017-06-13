using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

public partial class Pages_Account_Register : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //test timer with blink

    protected void RegisterSubmit_btn_Click(object sender, EventArgs e)
    {
        var userStore = new UserStore<IdentityUser>();

        //merge userStore DB with the existing Products DB
        userStore.Context.Database.Connection.ConnectionString =
            ConfigurationManager.ConnectionStrings["OnlineShopDB"].ConnectionString;

        var manager = new UserManager<IdentityUser>(userStore);

        //creating a new user
        var user = new IdentityUser();
        user.UserName = RegisterUserName_txtb.Text;

        if (RegisterPassword_txtb.Text == RegisterConfirmPass_txtb.Text)
            if (!string.IsNullOrWhiteSpace(RegisterMail_txtb.Text))
            {
                user.Email = RegisterMail_txtb.Text;
                try
                {
                    //create user object
                    //DB will be created automatically
                    var result = manager.Create(user, RegisterPassword_txtb.Text);
                    if (result.Succeeded)
                    {
                        var info = new UserInformation
                        {
                            Address = RegisterAddress_txtb.Text,
                            FirstName = RegisterFirstName_txtb.Text,
                            LastName = RegisterLastName_txtb.Text,
                            PostalCode = Convert.ToInt32(RegisterPostCode_txtb.Text),
                            Phone = Convert.ToInt32(RegisterPhone_txtb.Text),
                            EmailAddress = RegisterMail_txtb.Text,
                            GUID = user.Id
                        };

                        var model = new UserInfoModel();
                        model.InsertUserInformation(info);

                        //store user in DB
                        var authentificationManager = HttpContext.Current.GetOwinContext().Authentication;
                        //set to login a new user by Cookie
                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        //log in the new user and redirect to homepage
                        authentificationManager.SignIn(new AuthenticationProperties(), userIdentity);
                        Response.Redirect("~/Index.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        RegisterStatus_lit.Text = result.Errors.FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    RegisterStatus_lit.Text = ex.ToString();
                }
            }
            else
            {
                RegisterStatus_lit.Text = "Please, provide your Email!";
            }
        else
            RegisterStatus_lit.Text = "Passwords do not match!";
    }
}