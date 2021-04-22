<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookEdit.aspx.cs" Inherits="IS432GroupProject.BookEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Book Site</h1>
    <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label>
    <br />
    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Author"></asp:Label>
    <br />
    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Cover Art URL"></asp:Label>
    <br />
    <asp:TextBox ID="txtCoverArt" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

    <script>
        $(function () {
            $("#ContentPlaceHolder1_btnSubmit").click(function () {
                var title = $("#ContentPlaceHolder1_txtTitle").val();
                var author = $("#ContentPlaceHolder1_txtAuthor").val();
                var cover = $("#ContentPlaceHolder1_txtCoverArt").val();

                if (title == "") {
                    window.alert("Your book must have a title. Please try again.");
                    return false;
                }
                else if (author == "")
                {
                    window.alert("Your book must have an author. Please try again.");
                    return false;
                }
                else if (cover == "") {
                    window.alert("Your book must have a cover. Please try again.");
                    return false;
                }
                else {
                    return true;
                }
            });
        });
    </script>
</asp:Content>
