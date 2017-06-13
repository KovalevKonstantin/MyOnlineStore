<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="Pages_FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BorderColor="#FFCC00" BorderStyle="Solid" CssClass="panel">
        <asp:Label ID="FeedBackFirstName_lbl" runat="server" Text="First Name"></asp:Label>
        <br/>
        <asp:TextBox ID="FeedBackFirstName_txtb" runat="server" CssClass="inputs"></asp:TextBox>
        <br/>
        <asp:Label ID="FeedBackLastName_lbl" runat="server" Text="Last Name"></asp:Label>
        <br/>
        <asp:TextBox ID="FeedBackLastName_txtb" runat="server" CssClass="inputs"></asp:TextBox>
        <br/>
        <asp:Label ID="FeedBackEmail_lbl" runat="server" Text="Your email"></asp:Label>
        <br/>
        <asp:TextBox ID="FeedBackEmail_txtb" runat="server" CssClass="inputs"></asp:TextBox>
        <br/>
        <asp:Label ID="FeedBackMessage_lbl" runat="server" Text="Message"></asp:Label>
        <br/>
        <asp:TextBox ID="FeedBackMessage_txtb" runat="server" CssClass="inputs" Height="120px" TextMode="MultiLine" Width="100%"></asp:TextBox>
        <br/>
        <asp:Button ID="FeedBackSubmit_btn" runat="server" CssClass="button" Text="Submit" OnClick="FeedBackSubmit_btn_Click"/>
        <br/>
        <asp:Literal ID="FeedBackSubmitResult_lit" runat="server"></asp:Literal>
    </asp:Panel>
</asp:Content>