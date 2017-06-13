<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="ProductDescription.aspx.cs" Inherits="Pages_ProductDescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%= btnUpload.ClientID %>").click();
            }
        }
    </script>
    <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none"/>
    <table>
        <tr>
            <td rowspan="4">
                <asp:Image ID="MyStoreProduct_img" runat="server" CssClass="detailsImage" EnableViewState="False"/>
                <br/>
                <asp:FileUpload ID="FileUpload1" runat="server"/>
                <br/>
                <asp:Literal ID="MyStoreImageUploadResult_lit" runat="server"></asp:Literal>
            </td>
            <td>
                <h2>
                    Product Title:
                    <asp:TextBox ID="MyStoreProductTitle_txtb" runat="server" Text="Product Name"></asp:TextBox>
                    <hr/>
                </h2>
            </td>
            <td>
                Product Type:
                <asp:DropDownList ID="MyStoreProductType_ddl" runat="server" DataSourceID="SqlDataSource1" DataTextField="Type" DataValueField="TypeID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineShopDB %>" SelectCommand="SELECT * FROM [ProductTypes] ORDER BY [Type]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                Product Description
                <asp:TextBox ID="MyStoreProductDescription_txtb" runat="server" CssClass="detailsDescription" TextMode="MultiLine" Text="Product Description"></asp:TextBox>
            </td>
            <td>
                Product Price:
                <asp:TextBox ID="MyStoreProductPrice_txtb" runat="server" CssClass="detailsPrice" TextMode="Number" Text="Product Price"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Product Number:
                <asp:Label ID="MyStoreItemNumber_lbl" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <br/>
                <asp:Button ID="MyStoreAddItem_btn" runat="server" Text="Add Product" CssClass="button" OnClick="Add_btn_Click"/>
                <br/>
                <asp:Label ID="MyStoreResult_lbl" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>