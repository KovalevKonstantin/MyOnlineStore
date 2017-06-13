using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

public partial class Pages_Bin : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //get ID of currently logged in user and show the items from the ShoppingBin
        var userId = User.Identity.GetUserId();
        GetPurchasesInBin(userId);
    }

    private void GetPurchasesInBin(string userId)
    {
        var model = new BinModel();
        double subTotal = 0;

        var purchaseList = model.GetOrdersInBin(userId);
        CreateBinTable(purchaseList, out subTotal);

        //Add total to webpage
        var gst = subTotal*0.15;
        double shipping = 10;
        var fullPrice = subTotal + gst + shipping;

        //show all this amounts on the webpage
        Total_lit.Text = "$" + Convert.ToString(subTotal);
        GST_lit.Text = "$" + Convert.ToString(gst);
        Shipping_lit.Text = "$" + Convert.ToString(shipping);
        FinalSum_lit.Text = "$" + Convert.ToString(fullPrice);
    }

    private void CreateBinTable(List<Bin> purchaseList, out double subTotal)
    {
        subTotal = new double();

        var model = new ProductsModel();
        foreach (var bin in purchaseList)
        {
            var product = model.GetProduct(bin.ProductID);

            //create the image  button
            var Image_btn = new ImageButton
            {
                ImageUrl = string.Format("~/MyImages/Products/{0}", product.ProductImage),
                PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", product.ProductID)
            };

            //creating the Delete link
            var Delete_lnk = new LinkButton
            {
                PostBackUrl = string.Format("~/Pages/ShoppingBin.aspx?productId={0}", bin.ID),
                Text = "Delete Item",
                ID = "del" + bin.ID
            };

            //add an OnClick event
            Delete_lnk.Click += Delete_Item;

            //create the Quantity dropdown list
            //generate list with numbers from 1 to 20
            var amount = Enumerable.Range(1, 20).ToArray();
            var Quantity_ddl = new DropDownList
            {
                DataSource = amount,
                AppendDataBoundItems = true,
                AutoPostBack = true,
                ID = bin.ID.ToString()
            };
            Quantity_ddl.DataBind();
            Quantity_ddl.SelectedValue = bin.Quantity.ToString();
            Quantity_ddl.SelectedIndexChanged += Quantity_ddl_SelectedIndexChanged;

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
                    product.ProductName, "Item Number:" + product.ProductID),
                HorizontalAlign = HorizontalAlign.Left,
                Width = 350
            };
            var tc_3 = new TableCell {Text = "Item Price:<hr/>"};
            var tc_4 = new TableCell {Text = "Quantity:<hr/>"};
            var tc_5 = new TableCell {Text = "Item Total:<hr/>"};
            var tc_6 = new TableCell();

            //create 6 cell for tr_2
            var tc2_1 = new TableCell();
            var tc2_2 = new TableCell {Text = "$" + product.ProductPrice};
            var tc2_3 = new TableCell();
            var tc2_4 = new TableCell
            {
                Text = "$" +
                       Math.Round(bin.Quantity*Convert.ToDouble(product.ProductPrice), 2)
            };
            var tc2_5 = new TableCell();
            var tc2_6 = new TableCell();

            //set 'special' controls
            tc_1.Controls.Add(Image_btn);
            tc_6.Controls.Add(Delete_lnk);
            tc2_3.Controls.Add(Quantity_ddl);

            //add cells to rows
            tr_1.Cells.Add(tc_1);
            tr_1.Cells.Add(tc_2);
            tr_1.Cells.Add(tc_3);
            tr_1.Cells.Add(tc_4);
            tr_1.Cells.Add(tc_5);
            tr_1.Cells.Add(tc_6);

            tr_2.Cells.Add(tc2_1);
            tr_2.Cells.Add(tc2_2);
            tr_2.Cells.Add(tc2_3);
            tr_2.Cells.Add(tc2_4);
            tr_2.Cells.Add(tc2_5);
            tr_2.Cells.Add(tc2_6);

            //add rows to table
            table.Rows.Add(tr_1);
            table.Rows.Add(tr_2);

            //add table to ShoppingBin_pnl
            ShoppingBin_pnl.Controls.Add(table);

            //add total quantity of items to subTotal
            subTotal += bin.Quantity*Convert.ToDouble(product.ProductPrice);
        }

        //Add current user's Shopping Bin to user specific session value
        Session[User.Identity.GetUserId()] = purchaseList;
    }

    private void Quantity_ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedList = (DropDownList) sender;
        var quantity = Convert.ToInt32(selectedList.SelectedValue);
        var binId = Convert.ToInt32(selectedList.ID);

        var model = new BinModel();
        model.UpdateQuantity(binId, quantity);

        //refresh the page
        Response.Redirect("~/Pages/ShoppingBin.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }

    private void Delete_Item(object sender, EventArgs e)
    {
        var selectedLink = (LinkButton) sender;
        var link = selectedLink.ID.Replace("del", "");
        var binId = Convert.ToInt32(link);

        var model = new BinModel();
        model.DeleteBin(binId);

        //refresh the page
        Response.Redirect("~/Pages/ShoppingBin.aspx", false);
        Context.ApplicationInstance.CompleteRequest();
    }
}