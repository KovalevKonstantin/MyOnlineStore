<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Literal ID="LoginResult_lit" runat="server"></asp:Literal>
    <br/>
    <asp:Label ID="LoginUsername_lbl" runat="server" Text="User Name"></asp:Label>
    <br/>
    <asp:TextBox ID="LoginUsername_txtb" runat="server" CssClass="inputs"></asp:TextBox>
    <br/>
    <asp:Label ID="LoginPassword_lbl" runat="server" Text="Password"></asp:Label>
    <br/>
    <asp:TextBox ID="LoginPassword_txtb" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br/>
    <table>
        <tr>
            <td>
                <asp:Button ID="LoginSubmit_btn" runat="server" CssClass="button" OnClick="LoginSubmit_btn_Click" Text="Log In"/>
                <asp:Button ID="ProfileForgotPass" runat="server" CssClass="button" Width="250px" Text="Forgot Password" OnClick="ProfileForgotPass_Click"/>
            </td>
        </tr>
    </table>
    <br/>
</asp:Content>