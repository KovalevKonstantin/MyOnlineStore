<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="ShoppingBin.aspx.cs" Inherits="Pages_Bin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="ShoppingBin_pnl" runat="server">

    </asp:Panel>
    <table>
        <tr>
            <td>
                <b>Total: </b>
            </td>
            <td>
                <asp:Literal ID="Total_lit" runat="server" Text=""></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <b>GST: </b>
            </td>
            <td>
                <asp:Literal ID="GST_lit" runat="server" Text=""></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <b>Shipping: </b>
            </td>
            <td>
                <asp:Literal ID="Shipping_lit" runat="server" Text=""></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <b>Final Sum: </b>
            </td>
            <td>
                <asp:Literal ID="FinalSum_lit" runat="server" Text=""></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="ContinueShopping_lnkb" runat="server" PostBackUrl="~/Index.aspx"
                                Text="Continue Shopping"/>
                OR
                <asp:Button ID="CheckOut_btn" runat="server" PostBackUrl="~/Pages/Success.aspx"
                            CssClass="button" Width="250px" Text="Checkout"/>
            </td>
        </tr>
    </table>
</asp:Content>