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
    public partial class BookEdit : System.Web.UI.Page
    {
        private string bookId;
        private string user;

        protected void Page_Load(object sender, EventArgs e)
        {
            bookId = Request.QueryString["BookId"];
            user = Request.QueryString["name"];
            ((SiteMaster)this.Master).user = user;

            if (!IsPostBack)
            {
                string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand("GetBookById", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", bookId);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    txtTitle.Text = reader["Title"].ToString();
                    txtAuthor.Text = reader["Author"].ToString();
                    txtCoverArt.Text = reader["Cover"].ToString();
                }

                cnn.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("BookProducts.aspx?name={0}", user));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string cover = txtCoverArt.Text;

            string cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateBook";
            cmd.Parameters.AddWithValue("@id", bookId);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@cover", cover);

            cnn.Open();
            object o = cmd.ExecuteScalar();
            cnn.Close();

            Response.Redirect(string.Format("BookProducts.aspx?name={0}", user));
        }
    }
}