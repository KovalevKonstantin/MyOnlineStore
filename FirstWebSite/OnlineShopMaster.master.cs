using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;

public partial class OnlineShopMaster : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = Context.User.Identity;
        if (user.IsAuthenticated)
        {
            Login_lnk.Visible = false;
            Register_lnk.Visible = false;

            Logout_lnkb.Visible = true;
            Status_lit.Visible = true;
            Profile_lnk.Visible = true;
            MyStore_lnk.Visible = true;

            var model = new BinModel();
            var userId = HttpContext.Current.User.Identity.GetUserId();
            Status_lit.Text = string.Format("{0} ({1})", Context.User.Identity.Name,
                model.GetAmountOfPurchases(userId));
        }
        else
        {
            Login_lnk.Visible = true;
            Register_lnk.Visible = true;

            Logout_lnkb.Visible = false;
            Status_lit.Visible = false;
            Profile_lnk.Visible = false;
            MyStore_lnk.Visible = false;
        }
    }

    protected void Logout_lnkb_Click(object sender, EventArgs e)
    {
        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut();
        Response.Redirect("~/Index.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }
}