using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_Management : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Products_grdv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //get selected row
        var row = Products_grv.Rows[e.NewEditIndex];

        //get ID of selected products
        var rowID = Convert.ToInt32(row.Cells[1].Text);

        //redirect user to ManageProducts page along with the selected rowId
        Response.Redirect("~/Pages/Management/ManageProducts.aspx?id=" + rowID, false);
        Context.ApplicationInstance.CompleteRequest();
    }
}