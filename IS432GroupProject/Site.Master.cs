using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace IS432GroupProject
{
    public partial class SiteMaster : MasterPage
    {
        public string user;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect(string.Format("~/Login.aspx?name={0}", user));
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("Landing.aspx?name={0}", user));
        }

        protected void btnBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("BookProducts.aspx?name={0}", user));
        }
        
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("Admin.aspx?name={0}", user));
            /*   user = Request.QueryString["name"];
               ((SiteMaster)this.Master).user = user;

               int hold = 0;

               //check admin credentials
               string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

               SqlConnection cnn = new SqlConnection(cnnString);
               SqlCommand cmd = new SqlCommand("GetUserRoleByUsername", cnn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@user", user);
               cnn.Open();
               SqlDataReader reader = cmd.ExecuteReader();

               while (reader.Read())
               {
                   hold = Convert.ToInt32(reader["RoleId"]);
               }
               cnn.Close();


               //if addmin
               if (hold == 1)
               {
                   Response.Redirect(string.Format("Admin.aspx?name={0}", user));
               }
               else
               {
                   string messagepass = "User does not have correct privileges";
                   Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + messagepass + "');", true);

               }*/
        }

    }
    
}