using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        //get a list of all products from DB
        var pmodel = new ProductsModel();
        var plist = pmodel.GetAllProducts();

        //make sure products exist in the DB
        if (plist != null)
            foreach (var p in plist)
            {
                var ppanel = new Panel();
                var ibutton = new ImageButton();
                var PName_lbl = new Label();
                var PPrice_lbl = new Label();

                //set childcontrols' properties
                ibutton.ImageUrl = "~/MyImages/Products/" + p.ProductImage;
                ibutton.CssClass = "productImage";
                ibutton.PostBackUrl = "~/Pages/Product.aspx?id=" + p.ProductID;

                PName_lbl.Text = p.ProductName;
                PName_lbl.CssClass = "productName";

                PPrice_lbl.Text = "$ " + p.ProductPrice;
                PPrice_lbl.CssClass = "productPrice";

                //add child control to the panel
                ppanel.Controls.Add(ibutton);
                ppanel.Controls.Add(new Literal {Text = "<br />"});
                ppanel.Controls.Add(PName_lbl);
                ppanel.Controls.Add(new Literal {Text = "<br />"});
                ppanel.Controls.Add(PPrice_lbl);

                //add dynamic Panels to static Parent panel
                Products_pnl.Controls.Add(ppanel);
            }
        else
            Products_pnl.Controls.Add(new Literal {Text = "No products found!"});
    }
}