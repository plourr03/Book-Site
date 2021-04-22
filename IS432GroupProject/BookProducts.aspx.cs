using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IS432GroupProject
{
    public partial class BookProducts : System.Web.UI.Page
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
            if(hold == 1)
            {
                SqlDataSource1.SelectCommand = "GetAllBooks";
            }
            else
            {
                SqlDataSource1.SelectParameters.Add("user", user);
            }            
        }

        protected void btnUploadBook_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("BookUpload.aspx?name={0}", user));
        }

        public void grdBooks_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditBook")
            {
                // Convert the row index stored in the CommandArgument property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                int id = Convert.ToInt32(grdBooks.Rows[index].Cells[0].Text);

                Response.Redirect(string.Format("BookEdit.aspx?BookId={0}&name={1}", id, user));
            }
            if (e.CommandName == "DeleteBook")
            {
                // Convert the row index stored in the CommandArgument property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                int id = Convert.ToInt32(grdBooks.Rows[index].Cells[0].Text);

                string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand("DeleteBook", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cnn.Open();
                object o = cmd.ExecuteScalar();
                cnn.Close();

                Response.Redirect(string.Format("BookProducts.aspx?name={0}", user));
            }
            
        }
    }
}