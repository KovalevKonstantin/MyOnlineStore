using System;
using System.Linq;
using System.Web.UI;
using Microsoft.AspNet.Identity;

public partial class Pages_Product : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        //get selected product's data
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);
            var pmodel = new ProductsModel();
            var p = pmodel.GetProduct(id);

            //fill page with data
            Price_lbl.Text = "Price per item: <br />$ " + p.ProductPrice;
            Title_lbl.Text = p.ProductName;
            Description_lbl.Text = p.ProductDescription;
            ItemNumber_lbl.Text = id.ToString();
            Product_img.ImageUrl = "~/MyImages/Products/" + p.ProductImage;

            //fill amount dropdownlist with number 1 - 20
            var amount = Enumerable.Range(1, 20).ToArray();
            Amount_ddl.DataSource = amount;
            Amount_ddl.AppendDataBoundItems = true;
            Amount_ddl.DataBind();
        }
    }

    protected void Add_btn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            var clientId = Context.User.Identity.GetUserId();

            if (clientId != null)
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var amount = Convert.ToInt32(Amount_ddl.SelectedValue);

                var bin = new Bin
                {
                    Quantity = amount,
                    ClientID = clientId,
                    DatePurchase = DateTime.Now,
                    IsInBin = true,
                    ProductID = id
                };

                var bmodel = new BinModel();
                Result_lbl.Text = bmodel.InsertBin(bin);
                Response.Redirect("~/Pages/Product.aspx?id=" + id, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Result_lbl.Text = "You should Log In to buy a product.";
            }
        }
    }


    protected void ProductMessage_btn_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            var id = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect("~/Pages/FeedBack.aspx?id=" + id, false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}