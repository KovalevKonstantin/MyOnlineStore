<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineShopMaster.master" AutoEventWireup="true" CodeFile="Management.aspx.cs" Inherits="Pages_Management_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:LinkButton ID="ManagementAddP_lbtn" runat="server" CssClass="button" PostBackUrl="~/Pages/Management/ManageProducts.aspx">Add a new Product</asp:LinkButton>
<br/>
<br/>
<div style="height: 400px; overflow: scroll; width: 100%;">
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search"/>
    <hr/>
    <asp:GridView ID="Products_grv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="ProductID" DataSourceID="sqlProducts" GridLines="None" Width="100%">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"/>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID"/>
            <asp:BoundField DataField="ProductTypeID" HeaderText="ProductTypeID" SortExpression="ProductTypeID"/>
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName"/>
            <asp:BoundField DataField="ProductPrice" HeaderText="ProductPrice" SortExpression="ProductPrice"/>
            <asp:BoundField DataField="ProductDescription" HeaderText="ProductDescription" SortExpression="ProductDescription"/>
            <asp:BoundField DataField="ProductImage" HeaderText="ProductImage" SortExpression="ProductImage"/>
            <asp:BoundField DataField="SellerID" HeaderText="SellerID" SortExpression="SellerID"/>
        </Columns>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black"/>
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF"/>
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"/>
        <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White"/>
        <SortedAscendingCellStyle BackColor="#F1F1F1"/>
        <SortedAscendingHeaderStyle BackColor="#594B9C"/>
        <SortedDescendingCellStyle BackColor="#CAC9C9"/>
        <SortedDescendingHeaderStyle BackColor="#33276A"/>
    </asp:GridView>
    <asp:SqlDataSource ID="sqlProducts" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineShopDB %>" DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" InsertCommand="INSERT INTO [Products] ([ProductTypeID], [ProductName], [ProductPrice], [ProductDescription], [ProductImage], [SellerID]) VALUES (@ProductTypeID, @ProductName, @ProductPrice, @ProductDescription, @ProductImage, @SellerID)" SelectCommand="SELECT * FROM [Products] ORDER BY [ProductName]" UpdateCommand="UPDATE [Products] SET [ProductTypeID] = @ProductTypeID, [ProductName] = @ProductName, [ProductPrice] = @ProductPrice, [ProductDescription] = @ProductDescription, [ProductImage] = @ProductImage, [SellerID] = @SellerID WHERE [ProductID] = @ProductID" FilterExpression="ProductName LIKE '{0}%'">
        <DeleteParameters>
            <asp:Parameter Name="ProductID" Type="Int32"/>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ProductTypeID" Type="Int32"/>
            <asp:Parameter Name="ProductName" Type="String"/>
            <asp:Parameter Name="ProductPrice" Type="Double"/>
            <asp:Parameter Name="ProductDescription" Type="String"/>
            <asp:Parameter Name="ProductImage" Type="String"/>
            <asp:Parameter Name="SellerID" Type="Int32"/>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ProductTypeID" Type="Int32"/>
            <asp:Parameter Name="ProductName" Type="String"/>
            <asp:Parameter Name="ProductPrice" Type="Double"/>
            <asp:Parameter Name="ProductDescription" Type="String"/>
            <asp:Parameter Name="ProductImage" Type="String"/>
            <asp:Parameter Name="SellerID" Type="Int32"/>
            <asp:Parameter Name="ProductID" Type="Int32"/>
        </UpdateParameters>
        <FilterParameters>
            <asp:ControlParameter Name="ProductName" ControlID="txtSearch" PropertyName="Text"/>
        </FilterParameters>
    </asp:SqlDataSource>
</div>
<br/>
<asp:LinkButton ID="ManagementAddPType_lbtn" runat="server" CssClass="button" PostBackUrl="~/Pages/Management/ManageProductTypes.aspx">Add a new Product Type</asp:LinkButton>
<br/>
<br/>
<asp:GridView ID="ProductType_grv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="TypeID" DataSourceID="sqlProductTypes" GridLines="None" Width="50%">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"/>
        <asp:BoundField DataField="TypeID" HeaderText="TypeID" InsertVisible="False" ReadOnly="True" SortExpression="TypeID"/>
        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type"/>
    </Columns>
    <FooterStyle BackColor="#C6C3C6" ForeColor="Black"/>
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF"/>
    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"/>
    <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White"/>
    <SortedAscendingCellStyle BackColor="#F1F1F1"/>
    <SortedAscendingHeaderStyle BackColor="#594B9C"/>
    <SortedDescendingCellStyle BackColor="#CAC9C9"/>
    <SortedDescendingHeaderStyle BackColor="#33276A"/>
</asp:GridView>
<asp:SqlDataSource ID="sqlProductTypes" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineShopDB %>" DeleteCommand="DELETE FROM [ProductTypes] WHERE [TypeID] = @TypeID" InsertCommand="INSERT INTO [ProductTypes] ([Type]) VALUES (@Type)" SelectCommand="SELECT * FROM [ProductTypes] ORDER BY [Type]" UpdateCommand="UPDATE [ProductTypes] SET [Type] = @Type WHERE [TypeID] = @TypeID">
    <DeleteParameters>
        <asp:Parameter Name="TypeID" Type="Int32"/>
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Type" Type="String"/>
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Type" Type="String"/>
        <asp:Parameter Name="TypeID" Type="Int32"/>
    </UpdateParameters>
</asp:SqlDataSource>
<br/>
Orders:<br/>
<asp:GridView ID="Orders_grv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="ID" DataSourceID="sqlOrders" GridLines="None" Width="100%">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"/>
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID"/>
        <asp:BoundField DataField="ClientID" HeaderText="ClientID" SortExpression="ClientID"/>
        <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"/>
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"/>
        <asp:BoundField DataField="DatePurchase" HeaderText="DatePurchase" SortExpression="DatePurchase"/>
        <asp:CheckBoxField DataField="IsInBin" HeaderText="IsInBin" SortExpression="IsInBin"/>
    </Columns>
    <FooterStyle BackColor="#C6C3C6" ForeColor="Black"/>
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF"/>
    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"/>
    <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White"/>
    <SortedAscendingCellStyle BackColor="#F1F1F1"/>
    <SortedAscendingHeaderStyle BackColor="#594B9C"/>
    <SortedDescendingCellStyle BackColor="#CAC9C9"/>
    <SortedDescendingHeaderStyle BackColor="#33276A"/>
</asp:GridView>
<asp:SqlDataSource ID="sqlOrders" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineShopDB %>" DeleteCommand="DELETE FROM [Bin] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Bin] ([ClientID], [ProductID], [Quantity], [DatePurchase], [IsInBin]) VALUES (@ClientID, @ProductID, @Quantity, @DatePurchase, @IsInBin)" SelectCommand="SELECT * FROM [Bin] ORDER BY [ClientID], [DatePurchase]" UpdateCommand="UPDATE [Bin] SET [ClientID] = @ClientID, [ProductID] = @ProductID, [Quantity] = @Quantity, [DatePurchase] = @DatePurchase, [IsInBin] = @IsInBin WHERE [ID] = @ID">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32"/>
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="ClientID" Type="String"/>
        <asp:Parameter Name="ProductID" Type="Int32"/>
        <asp:Parameter Name="Quantity" Type="Int32"/>
        <asp:Parameter Name="DatePurchase" Type="DateTime"/>
        <asp:Parameter Name="IsInBin" Type="Boolean"/>
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="ClientID" Type="String"/>
        <asp:Parameter Name="ProductID" Type="Int32"/>
        <asp:Parameter Name="Quantity" Type="Int32"/>
        <asp:Parameter Name="DatePurchase" Type="DateTime"/>
        <asp:Parameter Name="IsInBin" Type="Boolean"/>
        <asp:Parameter Name="ID" Type="Int32"/>
    </UpdateParameters>
</asp:SqlDataSource>
<br/>
<div style="height: 400px; overflow: scroll; width: 100%;">
    Users:<asp:GridView ID="Users_grv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="id" DataSourceID="sqlUsers" GridLines="None" Width="100%">
        <Columns>
            <asp:CommandField ShowEditButton="True"/>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"/>
            <asp:BoundField DataField="GUID" HeaderText="GUID" SortExpression="GUID"/>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"/>
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"/>
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"/>
            <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode"/>
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone"/>
            <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress"/>
            <asp:CheckBoxField DataField="IsBlocked" HeaderText="IsBlocked" SortExpression="IsBlocked"/>
        </Columns>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black"/>
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF"/>
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"/>
        <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White"/>
        <SortedAscendingCellStyle BackColor="#F1F1F1"/>
        <SortedAscendingHeaderStyle BackColor="#594B9C"/>
        <SortedDescendingCellStyle BackColor="#CAC9C9"/>
        <SortedDescendingHeaderStyle BackColor="#33276A"/>
    </asp:GridView>
    <asp:SqlDataSource ID="sqlUsers" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineShopDB %>" DeleteCommand="DELETE FROM [UserInformation] WHERE [id] = @id" InsertCommand="INSERT INTO [UserInformation] ([GUID], [FirstName], [LastName], [Address], [PostalCode], [Phone], [EmailAddress], [IsBlocked]) VALUES (@GUID, @FirstName, @LastName, @Address, @PostalCode, @Phone, @EmailAddress, @IsBlocked)" SelectCommand="SELECT * FROM [UserInformation] ORDER BY [id]" UpdateCommand="UPDATE [UserInformation] SET [GUID] = @GUID, [FirstName] = @FirstName, [LastName] = @LastName, [Address] = @Address, [PostalCode] = @PostalCode, [Phone] = @Phone, [EmailAddress] = @EmailAddress, [IsBlocked] = @IsBlocked WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32"/>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="GUID" Type="String"/>
            <asp:Parameter Name="FirstName" Type="String"/>
            <asp:Parameter Name="LastName" Type="String"/>
            <asp:Parameter Name="Address" Type="String"/>
            <asp:Parameter Name="PostalCode" Type="Int32"/>
            <asp:Parameter Name="Phone" Type="Int32"/>
            <asp:Parameter Name="EmailAddress" Type="String"/>
            <asp:Parameter Name="IsBlocked" Type="Boolean"/>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="GUID" Type="String"/>
            <asp:Parameter Name="FirstName" Type="String"/>
            <asp:Parameter Name="LastName" Type="String"/>
            <asp:Parameter Name="Address" Type="String"/>
            <asp:Parameter Name="PostalCode" Type="Int32"/>
            <asp:Parameter Name="Phone" Type="Int32"/>
            <asp:Parameter Name="EmailAddress" Type="String"/>
            <asp:Parameter Name="IsBlocked" Type="Boolean"/>
            <asp:Parameter Name="id" Type="Int32"/>
        </UpdateParameters>
    </asp:SqlDataSource>
</div>
<br/>
Feedbacks:<br/>
<asp:GridView ID="FeedBacks_grv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="ID" DataSourceID="sqlFeedback" GridLines="None" Width="100%">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"/>
        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"/>
        <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID"/>
        <asp:BoundField DataField="FeedBack" HeaderText="FeedBack" SortExpression="FeedBack"/>
        <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments"/>
        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"/>
        <asp:CheckBoxField DataField="Checked" HeaderText="Checked" SortExpression="Checked"/>
    </Columns>
    <FooterStyle BackColor="#C6C3C6" ForeColor="Black"/>
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF"/>
    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"/>
    <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White"/>
    <SortedAscendingCellStyle BackColor="#F1F1F1"/>
    <SortedAscendingHeaderStyle BackColor="#594B9C"/>
    <SortedDescendingCellStyle BackColor="#CAC9C9"/>
    <SortedDescendingHeaderStyle BackColor="#33276A"/>
</asp:GridView>
<asp:SqlDataSource ID="sqlFeedback" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineShopDB %>" DeleteCommand="DELETE FROM [FeedBacks] WHERE [ID] = @ID" InsertCommand="INSERT INTO [FeedBacks] ([ID], [UserID], [FeedBack], [Checked], [Comments], [Date]) VALUES (@ID, @UserID, @FeedBack, @Checked, @Comments, @Date)" SelectCommand="SELECT * FROM [FeedBacks] ORDER BY [Date]" UpdateCommand="UPDATE [FeedBacks] SET [UserID] = @UserID, [FeedBack] = @FeedBack, [Checked] = @Checked, [Comments] = @Comments, [Date] = @Date WHERE [ID] = @ID">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32"/>
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="ID" Type="Int32"/>
        <asp:Parameter Name="UserID" Type="Int32"/>
        <asp:Parameter Name="FeedBack" Type="String"/>
        <asp:Parameter Name="Checked" Type="Boolean"/>
        <asp:Parameter Name="Comments" Type="String"/>
        <asp:Parameter Name="Date" Type="DateTime"/>
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="UserID" Type="Int32"/>
        <asp:Parameter Name="FeedBack" Type="String"/>
        <asp:Parameter Name="Checked" Type="Boolean"/>
        <asp:Parameter Name="Comments" Type="String"/>
        <asp:Parameter Name="Date" Type="DateTime"/>
        <asp:Parameter Name="ID" Type="Int32"/>
    </UpdateParameters>
</asp:SqlDataSource>
<br/>
Users&#39; Messages:<br/>
<asp:GridView ID="Messages_grv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="ID" DataSourceID="sqlMessages" GridLines="None" Width="100%">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"/>
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID"/>
        <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"/>
        <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID"/>
        <asp:BoundField DataField="FeedBack" HeaderText="FeedBack" SortExpression="FeedBack"/>
        <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments"/>
        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"/>
        <asp:CheckBoxField DataField="Checked" HeaderText="Checked" SortExpression="Checked"/>
    </Columns>
    <FooterStyle BackColor="#C6C3C6" ForeColor="Black"/>
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF"/>
    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right"/>
    <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White"/>
    <SortedAscendingCellStyle BackColor="#F1F1F1"/>
    <SortedAscendingHeaderStyle BackColor="#594B9C"/>
    <SortedDescendingCellStyle BackColor="#CAC9C9"/>
    <SortedDescendingHeaderStyle BackColor="#33276A"/>
</asp:GridView>
<asp:SqlDataSource ID="sqlMessages" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineShopDB %>" DeleteCommand="DELETE FROM [Messages] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Messages] ([ProductID], [UserID], [FeedBack], [Checked], [Comments], [Date]) VALUES (@ProductID, @UserID, @FeedBack, @Checked, @Comments, @Date)" SelectCommand="SELECT * FROM [Messages] ORDER BY [Date]" UpdateCommand="UPDATE [Messages] SET [ProductID] = @ProductID, [UserID] = @UserID, [FeedBack] = @FeedBack, [Checked] = @Checked, [Comments] = @Comments, [Date] = @Date WHERE [ID] = @ID">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32"/>
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="ProductID" Type="Int32"/>
        <asp:Parameter Name="UserID" Type="Int32"/>
        <asp:Parameter Name="FeedBack" Type="String"/>
        <asp:Parameter Name="Checked" Type="Boolean"/>
        <asp:Parameter Name="Comments" Type="String"/>
        <asp:Parameter Name="Date" Type="DateTime"/>
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="ProductID" Type="Int32"/>
        <asp:Parameter Name="UserID" Type="Int32"/>
        <asp:Parameter Name="FeedBack" Type="String"/>
        <asp:Parameter Name="Checked" Type="Boolean"/>
        <asp:Parameter Name="Comments" Type="String"/>
        <asp:Parameter Name="Date" Type="DateTime"/>
        <asp:Parameter Name="ID" Type="Int32"/>
    </UpdateParameters>
</asp:SqlDataSource>
<br/>
</asp:Content>