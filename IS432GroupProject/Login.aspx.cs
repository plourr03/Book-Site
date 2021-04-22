using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;



namespace IS432GroupProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    StatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
                    LoginStatus.Visible = true;
                }
            }
        }
        protected void SignIn(object sender, EventArgs e)
        {
           
        }
        protected void btnregister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnSignOn_Click(object sender, EventArgs e)
        { 
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(txtUsername.Text, txtPassword.Text);
            string messagepass;

            if (user != null)
            {
                string name = txtUsername.Text;
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                Response.Redirect(string.Format("Landing.aspx?name={0}", name));
            }
            else
            {
                messagepass = "User or Password is incorrect";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + messagepass + "');", true);
            }
         

            
        }
    }
}