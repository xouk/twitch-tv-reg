using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using SimpleAntiGate;
using System.Drawing.Drawing2D;

namespace twitch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Авторизация
            webBrowser1.Show();
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate("https://secure.twitch.tv/signup");
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                Application.DoEvents();

            webBrowser1.Document.Focus(); screanShot();
            HtmlElementCollection allelements = webBrowser1.Document.All;
            foreach (HtmlElement webpageelement in allelements)
            {
                if (webpageelement.GetAttribute("name") == "email")
                {
                    webpageelement.SetAttribute("value", textBox1.Text + "@mektown.ru");
                }      
                
                if (webpageelement.GetAttribute("name") == "login")
                {
                    webpageelement.SetAttribute("value", textBox1.Text);
                }
                if (webpageelement.GetAttribute("name") == "password")
                {
                    webpageelement.SetAttribute("value", "twitch123");
                }
               

                if (webpageelement.GetAttribute("name") == "password")
                {
                    webpageelement.SetAttribute("value", "twitch123");
                }
                if (webpageelement.GetAttribute("name") == "date[month]")
                {
                    Random random = new Random();
                    webpageelement.Focus();
                    webpageelement.SetAttribute("value", random.Next(0, 12).ToString());
                }

                if (webpageelement.GetAttribute("name") == "password")
                {
                    webpageelement.Focus();
                }
            }

           
 
            
          
            }


     private void screanShot()
     {

         Bitmap bitmap = new Bitmap(600, 600);
         Rectangle bitmapRect = new Rectangle(0, 0, 1300, 1300);
         // This is a method of the WebBrowser control, and the most important part
         webBrowser1.DrawToBitmap(bitmap, bitmapRect);

         // Generate a thumbnail of the screenshot (optional)
         System.Drawing.Image origImage = bitmap;
         System.Drawing.Image origThumbnail = new Bitmap(1000, 1000, origImage.PixelFormat);

         Graphics oGraphic = Graphics.FromImage(origThumbnail);
         oGraphic.CompositingQuality = CompositingQuality.HighQuality;
         oGraphic.SmoothingMode = SmoothingMode.HighQuality;
         oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
         Rectangle oRectangle = new Rectangle(0, 0, 1000, 1000);
         oGraphic.DrawImage(origImage, oRectangle);

         // Save the file in PNG format
         origThumbnail.Save("Screenshot.bmp");
         origImage.Dispose();

     }
    }
}


