using SoundInTheory.DynamicImage.Fluent;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Tesseract;
using OCRApp.Class;
using System.Web;

namespace OCRApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load (object sender, EventArgs e)
        {

        }

        protected void FileUploadBtn_Click (object sender, EventArgs e)
        {
            string strFileName, strFileExtension, strFilePath, strFolder;

            strFolder = Server.MapPath("./images/");
            // Retrieve the name of the file that is posted.
            strFileName = Guid.NewGuid().ToString();
            strFileName = Regex.Replace(strFileName, @"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$",
                                        "$0");
            strFileExtension = Path.GetExtension(fileUpload.PostedFile.FileName);
            // Create the folder if it does not exist.
            if (!Directory.Exists(strFolder))
            {
                Directory.CreateDirectory(strFolder);
            }
            // Save the uploaded file to the server.
            strFilePath = strFolder + strFileName + strFileExtension;
            if (File.Exists(strFilePath))
            {
                lblUploadResult.Text = strFileName + " already exists on the server!";
            }
            else
            {
                fileUpload.PostedFile.SaveAs(strFilePath);
                fileUrl.Value = strFilePath;
                fileUploadImage.ImageUrl = string.Format($"/images/{strFileName + strFileExtension}");
                lblUploadResult.Text = strFileName + " has been successfully uploaded.";
                frmConfirmation.Visible = true;
            }
        }

        protected void ProcessBtn_Click (object sender, EventArgs e)
        {
            string renderedText = string.Empty;
            string imagePath = fileUrl.Value;
            byte[] bytes = File.ReadAllBytes(imagePath);
            MemoryStream ms = new MemoryStream(bytes);
            using (Bitmap bmp = (Bitmap)Image.FromStream(ms))
            {
                renderedText = ProcessImage(bmp);
            }
                

            lblProcessedImage.Text = renderedText != "" ? renderedText : "Image is unclear";
            processedImage.Visible = true;
        }

        private string ProcessImage(Bitmap image)
        {
            using (var engine = new TesseractEngine(Server.MapPath(@"~/tessdata"), "eng", EngineMode.Default))
            {
                var page = engine.Process(image);
                return page.GetText();
            }
        }
    }
}