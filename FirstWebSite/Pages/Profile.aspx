<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Pages_Management_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span style="color: red">
        <asp:Literal ID="ProfileResult_ltr" runat="server"></asp:Literal>
    </span>
    <br/>
    <asp:Label ID="ProfileFirstName_lbl" runat="server" Text="First Name"></asp:Label>
    <br/>
    <asp:TextBox ID="ProfileFirstName_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="ProfileLastName_lbl" runat="server" Text="Last Name"></asp:Label>
    <br/>
    <asp:TextBox ID="ProfileLastName_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="ProfileAddress_lbl" runat="server" Text="Address"></asp:Label>
    <br/>
    <asp:TextBox ID="ProfileAddress_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="ProfilePostCode_lbl" runat="server" Text="Post Code"></asp:Label>
    <br/>
    <asp:TextBox ID="ProfilePostCode_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="ProfilePhone_lbl" runat="server" Text="Phone"></asp:Label>
    <br/>
    <asp:TextBox ID="ProfilePhone_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="ProfileMail_lbl" runat="server" Text="eMail"></asp:Label>
    <br/>
    <asp:TextBox ID="ProfileMail_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <table>
        <tr>
            <td>
                <asp:Button ID="ProfileUpdate_btn" runat="server" CssClass="button" Width="100px" Text="Update" OnClick="ProfileUpdate_btn_Click"/>
                <asp:Button ID="ProfileChangePass_btn" runat="server" CssClass="button" Width="250px" Text="Change Password" PostBackUrl="~/Pages/ChangePassword.aspx"/>
                <br/>
            </td>
        </tr>
    </table>
</asp:Content>