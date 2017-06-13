<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="ManageProductTypes.aspx.cs" Inherits="Pages_Management_ManageProductTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Name:
    </p>
    <p>
        <asp:TextBox ID="ProductTypeName_txtb" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="ProductTypeSubmit_btn" runat="server" OnClick="ProductTypeSubmit_btn_Click" Text="Submit"/>
    </p>
    <p>
        <asp:Label ID="ProductTypeSubmitResult_lbl" runat="server"></asp:Label>
    </p>
</asp:Content>