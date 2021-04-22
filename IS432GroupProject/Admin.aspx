<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="IS432GroupProject.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div>
        <h2>Admin</h2>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
    <h4>
        Add/Remove Admins
    </h4>
       <asp:Button ID="btnRemove_add" CssClass="btn btn-primary js-scroll-trigger" ForeColor="Black" runat="server" Text="Remove or Add Admin" OnClick="btnAddorRemove_Click" />
       
</div>
</asp:Content>
