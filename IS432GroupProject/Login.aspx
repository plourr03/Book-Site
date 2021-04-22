<%@ Page Title="" Language="C#" MasterPageFile="~/login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IS432GroupProject.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex h-100 align-items-center">
        <div class="mx-auto text-center">
            <h1 class="mx-auto my-0 text-uppercase">Book Site</h1>
            <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
            <p>
               <asp:Literal runat="server" ID="StatusText" />
            </p>
         </asp:PlaceHolder>
            <asp:TextBox ID="txtUsername" CssClass="Sign-On" placeholder="Username..." runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPassword" CssClass="Sign-on" placeholder="Password..." runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnSignOn" class="btn btn-primary js-scroll-trigger" runat="server" Text="Sign In" OnClick="btnSignOn_Click" />
            <asp:Button ID="btnregister" runat="server" Text="Register" class="btn btn-primary js-scroll-trigger" OnClick="btnregister_Click" />
        </div>
    </div>
    <script>
        $(function () {
            $("#ContentPlaceHolder1_btnSignOn").click(function () {
                var username = $("#ContentPlaceHolder1_txtUsername").val();
                var password = $("#ContentPlaceHolder1_txtPassword").val();

                if (username == "" || password == "") {
                    window.alert("Username or password is incorrect. Please try again.");
                    return false;
                }
                else {
                    return true;
                }
            });
        });
    </script>
</asp:Content>
