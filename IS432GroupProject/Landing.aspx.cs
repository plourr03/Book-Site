using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IS432GroupProject
{
    public partial class Landing : System.Web.UI.Page
    {
        private string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["name"];

            lblWelcome.Text = "Welcome " + user;
            ((SiteMaster)this.Master).user = user;
        }
    }
}