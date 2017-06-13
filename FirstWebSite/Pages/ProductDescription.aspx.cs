using System;
using System.IO;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;

public partial class Pages_ProductDescription : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FileUpload1.Attributes["onchange"] = "UploadFile(this)";
        if (!IsPostBack)
            FillPage();
    }


    private void FillPage()
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["edit"]))
        {
            var productId = Convert.ToInt32(Request.QueryString["edit"]);
            var pmodel = new ProductsModel();
            var p = pmodel.GetProduct(productId);

            //fill page with data
            MyStoreProductPrice_txtb.Text = Convert.ToString(p.ProductPrice);
            MyStoreProductTitle_txtb.Text = p.ProductName;
            MyStoreProductDescription_txtb.Text = p.ProductDescription;
            MyStoreItemNumber_lbl.Text = productId.ToString();
            MyStoreProduct_img.ImageUrl = "~/MyImages/Products/" + p.ProductImage;
            MyStoreProduct_img.DataBind();
            MyStoreProductType_ddl.SelectedValue = p.ProductTypeID.ToString();
        }
    }

    protected void Add_btn_Click(object sender, EventArgs e)
    {
        var p = new Product();
        if (string.IsNullOrWhiteSpace(MyStoreProductTitle_txtb.Text) ||
            string.IsNullOrWhiteSpace(MyStoreProductPrice_txtb.Text)
            || string.IsNullOrWhiteSpace(MyStoreProductDescription_txtb.Text))
        {
            MyStoreResult_lbl.Text =
                "Please, provide all information about the product including: Image, Title, Description, and Price";
        }
        else
        {
            p.ProductName = MyStoreProductTitle_txtb.Text;
            p.ProductPrice = Convert.ToDouble(MyStoreProductPrice_txtb.Text);
            p.ProductTypeID = Convert.ToInt32(MyStoreProductType_ddl.SelectedValue);
            p.ProductDescription = MyStoreProductDescription_txtb.Text;
            p.ProductImage = Path.GetFileName(MyStoreImageUploadResult_lit.Text);
            var umodel = new UserInfoModel();
            p.SellerID = umodel.GetUserIDByGUID(HttpContext.Current.User.Identity.GetUserId());
            var pmodel = new ProductsModel();
            if (!string.IsNullOrWhiteSpace(Request.QueryString["edit"]))
            {
                var productId = Convert.ToInt32(Request.QueryString["edit"]);
                MyStoreResult_lbl.Text = pmodel.UpdateProduct(productId, p);
            }
            else
            {
                MyStoreResult_lbl.Text = pmodel.InsertProduct(p);
            }
            Response.Redirect("~/Pages/MyStore.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }

    protected void Upload(object sender, EventArgs e)
    {
        var filename = Path.GetFileName(FileUpload1.FileName);
        FileUpload1.SaveAs(Server.MapPath("~/MyImages/Products/" + filename));
        MyStoreProduct_img.ImageUrl = string.Format("~/MyImages/Products/{0}", filename);
        MyStoreProduct_img.DataBind();
        MyStoreImageUploadResult_lit.Text = MyStoreProduct_img.ImageUrl;
    }
}