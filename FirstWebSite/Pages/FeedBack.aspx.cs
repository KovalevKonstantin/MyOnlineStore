using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;

public partial class Pages_FeedBack : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillPage();
    }

    private void FillPage()
    {
        var check = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;
        if (check)
        {
            var model = new UserInfoModel();
            var info = model.GetUserInformation(HttpContext.Current.User.Identity.GetUserId());
            FeedBackEmail_txtb.Text = info.EmailAddress;
            FeedBackEmail_txtb.Enabled = false;
            FeedBackFirstName_txtb.Text = info.FirstName;
            FeedBackFirstName_txtb.Enabled = false;
            FeedBackLastName_txtb.Text = info.LastName;
            FeedBackLastName_txtb.Enabled = false;
        }
    }

    protected void FeedBackSubmit_btn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(FeedBackMessage_txtb.Text))
            if (string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                var fb = new FeedBack();
                fb.Date = DateTime.Now;
                fb.FeedBack1 = FeedBackMessage_txtb.Text;
                var umodel = new UserInfoModel();
                fb.UserID = umodel.GetUserIDByGUID(HttpContext.Current.User.Identity.GetUserId());
                var fmodel = new FeedBackModel();

                FeedBackSubmitResult_lit.Text = fmodel.InsertFeedBack(fb);
            }
            else
            {
                var ms = new Message();
                ms.Date = DateTime.Now;
                ms.FeedBack = FeedBackMessage_txtb.Text;
                ms.ProductID = Convert.ToInt32(Request.QueryString["id"]);
                var umodel = new UserInfoModel();
                ms.UserID = umodel.GetUserIDByGUID(HttpContext.Current.User.Identity.GetUserId());
                var mmodel = new MessagesModel();

                FeedBackSubmitResult_lit.Text = mmodel.InsertMessage(ms);
            }
    }
}