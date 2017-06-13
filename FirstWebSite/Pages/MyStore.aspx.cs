using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class Pages_MyStore : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var userGuid = HttpContext.Current.User.Identity.GetUserId();
        GetProductsBySeller(userGuid);
    }

    private void GetProductsBySeller(string userGuid)
    {
        var model = new ProductsModel();
        var products = model.GetProductsBySeller(userGuid);
        CreateProductsTable(products);
    }

    private void CreateProductsTable(List<Product> products)
    {
        var model = new ProductsModel();
        if (products != null)
            foreach (var p in products)
            {
                //create the image  button
                var Image_btn = new ImageButton
                {
                    ImageUrl = string.Format("~/MyImages/Products/{0}", p.ProductImage),
                    PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", p.ProductID),
                    EnableViewState = false
                };

                //creating the Delete link
                var MyStoreDelete_lnk = new LinkButton
                {
                    PostBackUrl = string.Format("~/Pages/MyStore.aspx?productId={0}", p.ProductID),
                    Text = "Delete Item",
                    ID = "del" + p.ProductID
                };

                var MyStoreEdit_lnk = new LinkButton
                {
                    PostBackUrl = string.Format("~/Pages/ProductDescription.aspx?edit={0}", p.ProductID),
                    Text = "Edit Item",
                    ID = "edit" + p.ProductID
                };

                //add an OnClick event
                MyStoreDelete_lnk.Click += Delete_Item;
                MyStoreEdit_lnk.Click += Edit_Item;
                //create HTML tables with two rows
                var table = new Table
                {
                    CssClass = "binTable"
                };

                var tr_1 = new TableRow();
                var tr_2 = new TableRow();

                //create 6 cells for tr_1
                var tc_1 = new TableCell {RowSpan = 2, Width = 50};
                var tc_2 = new TableCell
                {
                    Text = string.Format("<h4>{0}</h4><br/>{1}<br/>In Stock",
                        p.ProductName, "Item Number:" + p.ProductID),
                    HorizontalAlign = HorizontalAlign.Left,
                    Width = 350
                };
                var tc_3 = new TableCell {Text = "Item Price:<hr/>"};
                var tc_6 = new TableCell();
                var tc_7 = new TableCell();

                //create 6 cell for tr_2
                var tc2_1 = new TableCell();
                var tc2_2 = new TableCell {Text = "$" + p.ProductPrice};
                var tc2_5 = new TableCell();
                var tc2_6 = new TableCell();

                //set 'special' controls
                tc_1.Controls.Add(Image_btn);
                tc_6.Controls.Add(MyStoreDelete_lnk);
                tc_7.Controls.Add(MyStoreEdit_lnk);

                //add cells to rows
                tr_1.Cells.Add(tc_1);
                tr_1.Cells.Add(tc_2);
                tr_1.Cells.Add(tc_3);
                tr_1.Cells.Add(tc_6);
                tr_1.Cells.Add(tc_7);

                tr_2.Cells.Add(tc2_1);
                tr_2.Cells.Add(tc2_2);
                tr_2.Cells.Add(tc2_5);

                //add rows to table
                table.Rows.Add(tr_1);
                table.Rows.Add(tr_2);

                //add table to ShoppingBin_pnl
                MyStoreProducts_pnl.Controls.Add(table);
            }
    }

    private void Delete_Item(object sender, EventArgs e)
    {
        var selectedLink = (LinkButton) sender;
        var link = selectedLink.ID.Replace("del", "");
        var productId = Convert.ToInt32(link);

        var model = new ProductsModel();
        model.DeleteProduct(productId);

        //refresh the page
        Response.Redirect("~/Pages/MyStore.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }

    private void Edit_Item(object sender, EventArgs e)
    {
        var selectedLink = (LinkButton) sender;
        var link = selectedLink.ID.Replace("edit", "");
        var productId = Convert.ToInt32(link);

        //redirect to ProductDescription.aspx
        Response.Redirect("~/Pages/ProductDescription.aspx?edit=" + productId, false);
        Context.ApplicationInstance.CompleteRequest();
    }

    protected void MyStoreAddProduct_lnk_Click(object sender, EventArgs e)
    {
        //redirect to Product.aspx
        Response.Redirect("~/Pages/ProductDescription.aspx?edit=", false);
        Context.ApplicationInstance.CompleteRequest();
    }
}