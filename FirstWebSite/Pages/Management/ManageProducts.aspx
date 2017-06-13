<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Pages_Management_ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Name:
    </p>
    <p>
        <asp:TextBox ID="ManageProductsName_txtb" runat="server"></asp:TextBox>
    </p>
    <p>
        Type:
    </p>
    <p>
        <asp:DropDownList ID="ManageProductsTypeList_ddl" runat="server" DataSourceID="SqlDataSource1" DataTextField="Type" DataValueField="TypeID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineShopDB %>" SelectCommand="SELECT * FROM [ProductTypes] ORDER BY [Type]"></asp:SqlDataSource>
    </p>
    <p>
        Price:
    </p>
    <p>
        <asp:TextBox ID="ManageProductsPrice_txtb" runat="server"></asp:TextBox>
    </p>
    <p>
        Image:
    </p>
    <p>
        <asp:DropDownList ID="ManageProductsImage_ddl" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Description:
    </p>
    <p>
        <asp:TextBox ID="ManageProductsDescription_txtb" runat="server" Height="98px" TextMode="MultiLine" Width="340px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="ManageProductsSubmit_btn" runat="server" Text="Submit" OnClick="ManageProductsSubmit_btn_Click"/>
    </p>
    <p>
        <asp:Label ID="ManageProductsSubmitResult_lbl" runat="server"></asp:Label>
    </p>
</asp:Content>