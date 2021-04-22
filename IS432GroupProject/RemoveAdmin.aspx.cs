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
    public partial class Add_Remove_Admin : System.Web.UI.Page
    {
        private string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["name"];
            ((SiteMaster)this.Master).user = user;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
             string Username = txtUserNameAdd.Text; 
 int role = 1;

            string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddAdmin";
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@roleID", role);

            cnn.Open();
            object o = cmd.ExecuteScalar();
            cnn.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Username = TxtusernameRemove.Text;
           

            string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RemoveAdmin";
            cmd.Parameters.AddWithValue("@Username", Username);
            


            cnn.Open();
           
                object o = cmd.ExecuteScalar();
            
            cnn.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}