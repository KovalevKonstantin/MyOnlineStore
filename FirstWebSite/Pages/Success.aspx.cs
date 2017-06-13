using System;
using System.Collections.Generic;
using System.Web.UI;
using Microsoft.AspNet.Identity;

public partial class Pages_Success : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var bins = (List<Bin>) Session[User.Identity.GetUserId()];
        var model = new BinModel();
        model.MarkPurchaseAsPayd(bins);

        Session[User.Identity.GetUserId()] = null;
    }
}