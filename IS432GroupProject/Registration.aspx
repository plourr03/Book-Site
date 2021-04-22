<%@ Page Title="" Language="C#" MasterPageFile="~/login.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="IS432GroupProject.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex h-100 align-items-center">
        <div>
            <div class="mx-auto text-center">
                <h1 class="mx-auto my-0 text-uppercase">Registration</h1>
                <br />
               
                <br />
                <asp:TextBox ID="txtUsername" CssClass="Sign-On" placeholder="Username..." runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtFirstName" placeholder="First Name..." runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtLastName" placeholder="Last Name..." runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtEmail" placeholder="Email..." runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPassword" CssClass="passwordTextbox" TextMode="Password" placeholder="Password..." runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtConfirmPassword" CssClass="passwordTextbox" TextMode="Password" placeholder="Confirm Password..." runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-primary js-scroll-trigger" OnClick="btnRegister_Click" />
                <asp:Button ID="btnCancel" class="btn btn-primary js-scroll-trigger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
    <script>
        $(function () {

            $("#ContentPlaceHolder1_btnRegister").click(function () {
                var username = $("#ContentPlaceHolder1_txtUsername").val();
                var firstName = $("#ContentPlaceHolder1_txtFirstName").val();
                var lastName = $("#ContentPlaceHolder1_txtLastName").val();
                var email = $("#ContentPlaceHolder1_txtEmail").val();
                var password = $("#ContentPlaceHolder1_txtPassword").val();
                var confirmPassword = $("#ContentPlaceHolder1_txtConfirmPassword").val();

                if (username.length < 4) {
                    window.alert("Username must be at least 4 characters long. Please try again.");
                    return false;
                }
                else if (firstName == "") {
                    window.alert("Please enter your first name.");
                    return false;
                }
                else if (lastName == "") {
                    window.alert("Please enter your last name.");
                    return false;
                }
                else if (!email.includes("@")) {
                    window.alert("Email must be a valid email. Please try again.");
                    return false;
                }
                else if (password.length < 12) {
                    window.alert("Password must be at least 12 characters long. Please try again.");
                    return false;
                }
                else if (password != confirmPassword) {
                    window.alert("Passwords do not match. Please try again.");
                    return false;
                }
                else {
                    return true;
                }
            });
        });
    </script>



</asp:Content>
