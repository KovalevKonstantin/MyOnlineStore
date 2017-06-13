<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="MyStore.aspx.cs" Inherits="Pages_MyStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br/>
    <asp:LinkButton ID="MyStoreAddProduct_lnk" runat="server" Text="Add Product" CssClass="button" OnClick="MyStoreAddProduct_lnk_Click"></asp:LinkButton>
    <br/>
    <br/>
    <asp:Panel ID="MyStoreProducts_pnl" runat="server">

    </asp:Panel>
</asp:Content>