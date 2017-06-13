<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Literal ID="RegisterStatus_lit" runat="server"></asp:Literal>
    <br/>
    <asp:Label ID="RegisterUsername_lbl" runat="server" Text="User Name"></asp:Label>
    <br/>
    <asp:TextBox ID="RegisterUserName_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="RegisterPassword_lbl" runat="server" Text="Password"></asp:Label>
    <br/>
    <asp:TextBox ID="RegisterPassword_txtb" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br/>
    <asp:Label ID="RegisterConfirmPass_lbl" runat="server" Text="Confirm Password"></asp:Label>
    <br/>
    <asp:TextBox ID="RegisterConfirmPass_txtb" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br/>
    <asp:Label ID="RegisterFirstName_lbl" runat="server" Text="First Name"></asp:Label>
    <br/>
    <asp:TextBox ID="RegisterFirstName_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="RegisterLastName_lbl" runat="server" Text="Last Name"></asp:Label>
    <br/>
    <asp:TextBox ID="RegisterLastName_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="RegisterAddress_lbl" runat="server" Text="Address"></asp:Label>
    <br/>
    <asp:TextBox ID="RegisterAddress_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="RegisterPostCode_lbl" runat="server" Text="Post Code"></asp:Label>
    <br/>
    <asp:TextBox ID="RegisterPostCode_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="RegisterPhone_lbl" runat="server" Text="Phone"></asp:Label>
    <br/>
    <asp:TextBox ID="RegisterPhone_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="RegisterMail_lbl" runat="server" Text="eMail"></asp:Label>
    <br/>
    <asp:TextBox ID="RegisterMail_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Button ID="RegisterSubmit_btn" runat="server" CssClass="button" OnClick="RegisterSubmit_btn_Click" Text="Register"/>
    <br/>
</asp:Content>