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

            System.Windows.Forms.HtmlDocument doc = webBrowser1.Document;
            HtmlElementCollection cjlection = doc.GetElementsByTagName("input");

            foreach (HtmlElement f in cjlection)
                if (f.Name == "login") { f.InnerText = textBox1.Text; }
            
            foreach (HtmlElement f in cjlection)
                if (f.Name == "password") { f.InvokeMember("click"); f.InnerText = "password"; f.InvokeMember("click"); }

            foreach (HtmlElement f in cjlection)
                if (f.Name == "email") {f.InnerText = textBox1.Text + "@mektown.ru"; }

            screanShot();
            textBox2.Text = webBrowser1.DocumentText; 
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
         //origImage.Dispose();

     }

















    }
}


