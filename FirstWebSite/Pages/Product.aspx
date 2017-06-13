<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Pages_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td rowspan="4">
                <asp:Image ID="Product_img" runat="server" CssClass="detailsImage"/>
            </td>
            <td>
                <h2>
                    <asp:Label ID="Title_lbl" runat="server" Text="Label"></asp:Label>
                    <hr/>
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Description_lbl" runat="server" CssClass="detailsDescription"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Price_lbl" runat="server" CssClass="detailsPrice"></asp:Label>
                <br/>
                Quantity:
                <asp:DropDownList ID="Amount_ddl" runat="server"></asp:DropDownList><br/>
                <asp:Button ID="Add_btn" runat="server" Text="Add Product" CssClass="button" OnClick="Add_btn_Click"/>
                <br/>
                <asp:Label ID="Result_lbl" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Product Number: <asp:Label ID="ItemNumber_lbl" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Available" CssClass="productPrice"></asp:Label>
            </td>
            <td>
                <asp:Button ID="ProductMessage_btn" runat="server" CssClass="button" OnClick="ProductMessage_btn_Click" Text="Message to Seller"/>
            </td>
        </tr>
    </table>
</asp:Content>