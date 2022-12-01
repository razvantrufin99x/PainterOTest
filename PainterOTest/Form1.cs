using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PainterOTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        Pen p = new Pen(Color.Black);
        Brush b = new SolidBrush(Color.Black);
        Font f;
        int prevx=0, prevy=0;
        bool ismd = false;
        private Bitmap MyImage;


        private  void  Form1_Paint(object sender, PaintEventArgs e)
        {
            //
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = true;
            prevx = e.X;
            prevy = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismd == true)
            {
                
                g.DrawLine(p, e.X, e.Y, prevx, prevy);
                prevx = e.X;
                prevy = e.Y;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f = Font;
            g = pictureBox1.CreateGraphics();
        }

        private  void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void DrawImagePointF(PaintEventArgs e)
        {

            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");

            // Create point for upper-left corner of image.
            PointF ulCorner = new PointF(100.0F, 100.0F);

            // Draw image to screen.
            g.DrawImage(newImage, ulCorner);


            //sample 2

            GraphicsPath path = new GraphicsPath();
            Pen penJoin = new Pen(Color.FromArgb(255, 0, 0, 255), 8);

            path.StartFigure();
            path.AddLine(new Point(50, 200), new Point(100, 200));
            path.AddLine(new Point(100, 200), new Point(100, 250));

            penJoin.LineJoin = LineJoin.Bevel;
            g.DrawPath(penJoin, path);

            //sample 3

            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            g.DrawLine(pen, 20, 10, 300, 100);


        }

        private void LoadNewPict()
        {
            // You should replace the bold image 
            // in the sample below with an icon of your own choosing.
            // Note the escape character used (@) when specifying the path.
            pictureBox1.Image = Image.FromFile
            (System.Environment.GetFolderPath
            (System.Environment.SpecialFolder.Personal)
            + @"\Image.gif");
        }

        private void StretchPic(){
   // Stretch the picture to fit the control.
   pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
   // Load the picture into the control.
   // You should replace the bold image 
   // in the sample below with an icon of your own choosing.
   // Note the escape character used (@) when specifying the path.
   pictureBox1.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Image.gif");
}



        public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
        {
            // Sets up an image object to be displayed.
            if (MyImage != null)
            {
                MyImage.Dispose();
            }

            // Stretches the image to fit the pictureBox.
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage = new Bitmap(fileToDisplay);
            pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox1.Image = (Image)MyImage;
        }




    }
}
