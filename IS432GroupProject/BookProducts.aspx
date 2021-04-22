<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookProducts.aspx.cs" Inherits="IS432GroupProject.BookProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Book Site</h1>
    <p>
        <asp:Button ID="btnUploadBook" class="btn btn-primary js-scroll-trigger" runat="server" Text="Upload a Book" OnClick="btnUploadBook_Click" />
    </p>
    <h2>List of Books you have uploaded:</h2>
    <asp:GridView ID="grdBooks" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" DataKeyNames="BookId" OnRowCommand="grdBooks_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="BookId" HeaderText="BookId" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
            <asp:ImageField DataImageUrlField="Cover" HeaderText="Cover">
                <ControlStyle Height="200px" />
            </asp:ImageField>
            <asp:BoundField DataField="DateAdded" HeaderText="DateAdded" SortExpression="DateAdded" />
            <asp:ButtonField ButtonType="Button" CommandName="EditBook" Text="Edit" />
            <asp:ButtonField ButtonType="Button" CommandName="DeleteBook" Text="Delete" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

    <asp:SqlDataSource 
        ID="SqlDataSource1" 
        runat="server" 
        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
        SelectCommand="GetBooksByUser" 
        SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
</asp:Content>
