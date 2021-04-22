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
    public partial class Admin : System.Web.UI.Page
    {
        private string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["name"];
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
                
            }
            else
            {
                Response.Redirect(string.Format("Landing.aspx?name={0}", user));
            }
        }

        protected void btnAddorRemove_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("RemoveAdmin.aspx?name={0}", user));
        }
    }
}