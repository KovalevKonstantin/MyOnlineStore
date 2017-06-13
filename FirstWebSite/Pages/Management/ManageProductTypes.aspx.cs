using System;
using System.Web.UI;

public partial class Pages_Management_ManageProductTypes : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ProductTypeSubmit_btn_Click(object sender, EventArgs e)
    {
        var model = new ProductTypeTypesModel();
        var p = CreateProductType();

        ProductTypeSubmitResult_lbl.Text = model.InsertProductType(p);
    }

    private ProductType CreateProductType()
    {
        var p = new ProductType();
        p.Type = ProductTypeName_txtb.Text;

        return p;
    }
}