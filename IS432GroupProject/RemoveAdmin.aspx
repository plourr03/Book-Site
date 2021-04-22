<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RemoveAdmin.aspx.cs" Inherits="IS432GroupProject.Add_Remove_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>Add/Remove Admin</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Label ID="Label3" runat="server" Text="UserID"></asp:Label>
    <br />
        <h4>List of Admins</h4>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName"  />
            </Columns>
        </asp:GridView>
        <h4>Add Admin</h4>
        <asp:Label ID="Label2" runat="server" Text="Enter Admin UserID"></asp:Label>
        <br />
    <asp:TextBox ID="txtUserNameAdd" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
         <h4>Remove Admin</h4>
        <asp:Label ID="Label1" runat="server" Text="Enter Admin UserID"></asp:Label>
        <br />
    <asp:TextBox ID="TxtusernameRemove" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"/>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="GetAllAdmins" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</div>
    <script>
        $(function () {
            $("#ContentPlaceHolder1_btnSubmit").click(function () {
                var title = $("#ContentPlaceHolder1_txtUserName").val();
            });
    </script>
    </div>
</asp:Content>
