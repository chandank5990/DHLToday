using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing.Imaging;
using PQScan.PDFToImage;
using Spire.Pdf;
using System.Net;
using System.Net.NetworkInformation;

namespace uidstatus
{
    public partial class DrawingInPopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Article = Request.QueryString["Article"];
            if (Article.Length > 6)
            {
                string pdfpath = "W:\\test\\Access\\Planos\\" + Article.Substring(0, 6) + "\\" + Article + ".PC.pdf";
                string path = pdfpath;
                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(path);
                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
                    Response.End();
                    Response.Flush();
                }
            }
        }
    }
}