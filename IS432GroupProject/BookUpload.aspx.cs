using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using SD = System.Drawing;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;

namespace IS432GroupProject
{
    public partial class BookUpload : System.Web.UI.Page
    {
        private string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["name"];
            ((SiteMaster)this.Master).user = user;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Upload Original Image Here
            string uploadFileName = "";
            string uploadFilePath = "";
            if (FU1.HasFile)
            {
                string ext = Path.GetExtension(FU1.FileName).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".png")
                {
                    uploadFileName = Guid.NewGuid().ToString() + ext;
                    uploadFilePath = Path.Combine(Server.MapPath("~/UploadImages"), uploadFileName);
                    try
                    {
                        FU1.SaveAs(uploadFilePath);
                        imgUpload.ImageUrl = "~/UploadImages/" + uploadFileName;
                        panCrop.Visible = true;
                        txtCoverArt.Text = uploadFileName;
                    }
                    catch (Exception)
                    {
                        lblMsg.Text = "Error! Please try again.";
                    }
                }
                else
                {
                    lblMsg.Text = "Selected file type not allowed!";
                }
            }
            else
            {
                lblMsg.Text = "Please select file first!";
            }
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
            cmd.CommandText = "AddBook";
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@cover", cover);
            cmd.Parameters.AddWithValue("@user", user);

            cnn.Open();
            object o = cmd.ExecuteScalar();
            cnn.Close();

            Response.Redirect(string.Format("BookProducts.aspx?name={0}", user));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("BookProducts.aspx?name={0}", user));
        }

        protected async void btnAuthor_Click(object sender, EventArgs e)
        {

            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/UploadImages"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(X.Value), Convert.ToInt32(Y.Value), Convert.ToInt32(W.Value), Convert.ToInt32(H.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "crop_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/UploadImages"), cropFileName);
                    bitMap.Save(cropFilePath);

                }
                catch (Exception ex)
                {
                    throw;
                }
                ApiOCR apiOCR = new ApiOCR();
                //await apiOCR.MakeOCRRequest(cropFilePath);
                string results = await apiOCR.MakeOCRRequest(cropFilePath);

                if (results != null)
                {
                    //System.Diagnostics.Debug.WriteLine(apiOCR.response.StatusCode);
                    // string jsonParse = apiOCR.JsonParse;
                    string jsonParse = results;

                    txtAuthor.Text = jsonParse;
                }
            }
        }

        protected async void btnTitle_Click(object sender, EventArgs e)
        {

            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/UploadImages"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(Convert.ToInt32(X.Value), Convert.ToInt32(Y.Value), Convert.ToInt32(W.Value), Convert.ToInt32(H.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "crop_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/UploadImages"), cropFileName);
                    bitMap.Save(cropFilePath);

                }
                catch (Exception ex)
                {
                    throw;
                }
                ApiOCR apiOCR = new ApiOCR();
                //await apiOCR.MakeOCRRequest(cropFilePath);
                string results = await apiOCR.MakeOCRRequest(cropFilePath);

                if (results != null)
                {
                    //System.Diagnostics.Debug.WriteLine(apiOCR.response.StatusCode);
                    // string jsonParse = apiOCR.JsonParse;
                    string jsonParse = results;

                    txtTitle.Text = jsonParse;
                }
            }

        }
    }
}