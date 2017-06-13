<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="ForgotPass.aspx.cs" Inherits="Pages_ForgotPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="ForgotPass_pnl" runat="server" CssClass="panel" HorizontalAlign="Center">
        <asp:Label ID="ForgotPassMail_lbl" runat="server" Text="Email to send the recovery link"></asp:Label>
        <br/>
        <asp:TextBox ID="ForgotPassMail_txtb" runat="server" CssClass="inputs"></asp:TextBox>
        <br/>
        <asp:Literal ID="ForgotPassResult_lit" runat="server"></asp:Literal>
        <br/>
        <asp:Button ID="ForgotPassConfirm_btn" runat="server" Text="Confirm" CssClass="button" OnClick="ForgotPassConfirm_btn_Click"/>
        <br/>
    </asp:Panel>
</asp:Content>