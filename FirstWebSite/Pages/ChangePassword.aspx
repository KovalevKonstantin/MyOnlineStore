<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Pages_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="ModalPanel" runat="server" CssClass="panel" HorizontalAlign="Center">
        <asp:Label ID="PopUpOldPass_lbl" runat="server" Text="Old Password"></asp:Label>
        <br/>
        <asp:TextBox ID="PopUpOldPass_txtb" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
        <br/>
        <asp:Label ID="PopUpNewPass_lbl" runat="server" Text="New Password"></asp:Label>
        <br/>
        <asp:TextBox ID="PopUpNewPass_txtb" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
        <br/>
        <asp:Label ID="PopUpConfirmPass_lbl" runat="server" Text="Confirm Password"></asp:Label>
        <br/>
        <asp:TextBox ID="PopUpConfirmPass_txtb" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
        <br/>
        <asp:Literal ID="PopUpResult_lit" runat="server"></asp:Literal>
        <br/>
        <asp:Button ID="PopUpConfirm_btn" runat="server" Text="Confirm" CssClass="button" OnClick="PopUpConfirm_btn_Click"/>
        <br/>
    </asp:Panel>
</asp:Content>