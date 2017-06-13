using System;
using System.Collections;
using System.IO;
using System.Web.UI;

public partial class Pages_Management_ManageProducts : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImages();

            //chech if the url contains an "id" parameter
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
            }
        }
    }

    protected void ManageProductsSubmit_btn_Click(object sender, EventArgs e)
    {
        var model = new ProductsModel();
        var p = CreateProduct();

        //chech if the url contains an "id" parameter
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            //if TRUE --> update existing row
            var id = Convert.ToInt32(Request.QueryString["id"]);
            ManageProductsSubmitResult_lbl.Text = model.UpdateProduct(id, p);
        }
        else
        {
            //if FALSE --> create a new row
            ManageProductsSubmitResult_lbl.Text = model.InsertProduct(p);
        }
    }

    private void FillPage(int id)
    {
        //get selected product from DB
        var pmodel = new ProductsModel();
        var p = pmodel.GetProduct(id);

        //fill text boxes
        ManageProductsDescription_txtb.Text = p.ProductDescription;
        ManageProductsName_txtb.Text = p.ProductName;
        ManageProductsPrice_txtb.Text = p.ProductPrice.ToString();

        //set dropdownlist values
        ManageProductsImage_ddl.SelectedValue = p.ProductImage;
        ManageProductsTypeList_ddl.SelectedValue = p.ProductTypeID.ToString();
    }

    private void GetImages()
    {
        try
        {
            //get all filepaths
            var images = Directory.GetFiles(Server.MapPath("~/MyImages/Products/"));

            //get all filenames and add them to an arraylist
            var imageList = new ArrayList();
            foreach (var image in images)
            {
                var imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.OrdinalIgnoreCase) + 1);
                imageList.Add(imageName);
            }

            //set the arrayList as a dropdownview's datasource and refresh
            ManageProductsImage_ddl.DataSource = imageList;
            ManageProductsImage_ddl.AppendDataBoundItems = true;
            ManageProductsImage_ddl.DataBind();
        }
        catch (Exception e)
        {
            ManageProductsSubmitResult_lbl.Text = e.ToString();
        }
    }

    private Product CreateProduct()
    {
        var p = new Product();
        p.ProductName = ManageProductsName_txtb.Text;
        p.ProductPrice = Convert.ToDouble(ManageProductsPrice_txtb.Text);
        p.ProductTypeID = Convert.ToInt32(ManageProductsTypeList_ddl.SelectedValue);
        p.ProductDescription = ManageProductsDescription_txtb.Text;
        p.ProductImage = ManageProductsImage_ddl.SelectedValue;
        return p;
    }
}