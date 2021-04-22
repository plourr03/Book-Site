<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookUpload.aspx.cs" Inherits="IS432GroupProject.BookUpload" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <h3>Upload Book</h3>
                
                <table>
                    <tr>
                        <td>
                            Select Image File : 
                        </td>
                        <td>
                            <asp:FileUpload ID="FU1" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="panCrop" runat="server" Visible="false">
                    <table width="600PX">
                        <tr>
                            <td>
                                <asp:Image ID="imgUpload" runat="server" Width="100%"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAuthor" runat="server" Text="Crop Author" OnClick="btnAuthor_Click"  />
                                <asp:Button ID="btnTitle" runat="server" Text="Crop Title" OnClick="btnTitle_Click" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                                <asp:HiddenField ID="X" runat="server" />
                                <asp:HiddenField ID="Y" runat="server" />
                                <asp:HiddenField ID="W" runat="server" />
                                <asp:HiddenField ID="H" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <Label for ="txtTitle">Title:</Label>
    <br />    
    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />

        <Label for="txtAuthor"> Author: </Label><br />

    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox><br />

    
    <Label for="txtCoverArt"> Cover Art: </Label><br />

    <asp:TextBox ID="txtCoverArt" runat="server"></asp:TextBox><br />

    
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        <script src="js/jquery.min.js"></script>  
    <script src="js/jquery.Jcrop.js"></script>


 <script type="text/javascript">
     $(document).ready(function () {
         $('#<%=imgUpload.ClientID%>').Jcrop({
         onSelect: SelectCropArea
     });
     });

     function uploadComplete(sender, e) {
         //hide ajax wheel
         $('#<%=panCrop.ClientID%>').show();
            var filename = e.get_fileName();
            $(sender._element).siblings("input[type=text]").val(filename);
                 $('#<%=imgUpload.ClientID%>').attr("src", "CoverTemp/" + filename);
                 jcrop_api.setImage("CoverTemp/" + filename);
                 $(sender._element).find('input').val('');


             }
     function SelectCropArea(c) {
         $('#<%=X.ClientID%>').val(parseInt(c.x));
    $('#<%=Y.ClientID%>').val(parseInt(c.y));
$('#<%=W.ClientID%>').val(parseInt(c.w));
 $('#<%=H.ClientID%>').val(parseInt(c.h));
     }
 </script>
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
                    else if (author == "") {
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
