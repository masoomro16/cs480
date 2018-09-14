/* 
    Maira Soomro
    CS 480
    Assignment #3 - Mandelbrot Set
    This program implements the Mandelbrot Set and allows for zooming 

*/ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Mandelbrot_Set
{
    public partial class Mandelbrot : Form
    {

        double newMax_real = 0;
        double newMin_real = 0;
        double newMax_img = 0; 
        double newMin_img = 0;
        double zoomF = 0;

        // prevents from clicking unless mandelbrot is not plotted first 
        bool mandelDrawn = false; 
        bool mouseDown = false;
        
        // private 
        private Bitmap img;

        int xStart, yStart;  // where the mouse down was clicked
        int xEnd, yEnd;  // where the mouse was released

        SolidBrush caramelBrush = new SolidBrush(Color.FromArgb(209, 171, 89));
        SolidBrush blackBrush = new SolidBrush(Color.FromArgb(11, 5, 0));

        private void mandelSet_Click(object sender, EventArgs e)
        {

        }

        public Mandelbrot()
        {
            InitializeComponent();
            zoomFactor.Text = "1"; 

        }

        /* plot graph button */
        private void button1_Click(object sender, EventArgs e)
        {
            // set zoom 
            if (zoomFactor.Text != null)
                zoomF = double.Parse(zoomFactor.Text);

            // call mandelBrot function 
            drawMandelbrot(mandelSet, 2, -2, 2, -2);
            mandelSet.Image = img;
        }


        // function draws mandelBrot set
        private void drawMandelbrot(PictureBox picture, double maxReal, double minReal, double maxImg, double minImg)
        {
            

            img = new Bitmap(picture.Width, picture.Height);

            mandelDrawn = true;
            Cursor.Current = Cursors.WaitCursor;

            double realX = 0, realY = 0;
            double comX = 0, comY = 0;
            double realX_tmp = 0;
            double xDiff = 0, yDiff = 0; 

            // declare real and imaginary values 
            newMax_real = maxReal;
            newMin_real = minReal;
            newMax_img = maxImg;
            newMin_img = minImg;

            double ar = Math.Abs(minReal);
            double ai = Math.Abs(minImg);

            int iWd = img.Size.Width;
            int iHt = img.Size.Height;

            // set iterations 
            int maxItr = 1024;
            int currItr = 0;

            xDiff = ((maxReal - minReal) / (double)iWd);
            yDiff = ((maxImg - minImg) / (double)iHt);

            // map out mandelbrot set
            for (int row = 0; row < iWd; row++)
            {
                // rows 
                comX = (xDiff * row) - ar;
                for (int col = 0; col < iHt; col++)
                {
                    // columns
                    realX = 0;
                    realY = 0;
                    comY = (yDiff * col) - ai;
                    currItr = 0;

                    while ((realX * realX + realY * realY <= 4) && (currItr < maxItr))
                    {
                        currItr++;
                        realX_tmp = realX;
                        realX = (realX * realX) - (realY * realY) + comX;
                        realY = (2 * realX_tmp * realY) + comY;
                    }

                    // color the graphs
                    if (currItr != maxItr)
                       img.SetPixel(row, col, Color.FromArgb(currItr % 128 * 2, currItr % 32 * 7, currItr % 16 * 14));
                    else
                        img.SetPixel(row, col, Color.Black);

                }
               Cursor.Current = Cursors.Default;

            }
            mandelSet.Image = img; 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            drawMandelbrot(mandelSet, 2, -2, 2, -2);
            mandelSet.Refresh();
            mandelSet.Image = img;
        }

        private void mandelSet_Paint(object sender, PaintEventArgs e)
        {

        }


        // event handler for when the rectangle is drawn
        private void mandelSet_MouseDown(object sender, MouseEventArgs e)
        {

            if (mandelDrawn)
            {
                // mouse is down 
                mouseDown = true;
                xStart = e.X; // start point x
                yStart = e.Y; // start point y
                mandelSet.Refresh();

            }

            else
                return; 
            }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mandelSet_MouseMove(object sender, MouseEventArgs e)
        {
                if (!mouseDown) return;

                xEnd = e.X; 
                yEnd = e.Y;

            // Make a bitmap to display the selection rectangle 
            Bitmap newImg = new Bitmap(img);
            Graphics g = Graphics.FromImage(newImg);
            g.DrawRectangle(Pens.Blue,(int)(Math.Min(xStart, xEnd)), (int)(Math.Min(yStart, yEnd)),
                (int)(Math.Abs(xStart - xEnd)), (int)(Math.Abs(yStart - yEnd)));
            mandelSet.Image = newImg;
        }


        // event handler for when the rectangle is drawn and mouse is lifted up 
        private void mandelSet_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            xEnd = e.X;
            yEnd = e.Y;

            double jumpX, jumpY;
            double mandelWidth = mandelSet.Size.Width;
            double mandelHeight = mandelSet.Size.Width;

            // change to user specified factors?? 
            jumpX = (newMax_real - newMin_real) / mandelWidth;
            newMax_real = (double)xEnd * jumpX + newMin_real;
            newMin_real = (double)xStart * jumpX + newMin_real;

            jumpY = (newMax_img - newMin_img) / mandelHeight;
            newMax_img = (double)yEnd * jumpY + newMin_img;
            newMin_img = (double)yStart * jumpY + newMin_img;

            // call mandelBrot function to redraw
            drawMandelbrot(mandelSet, newMax_real, newMin_real, newMax_img, newMin_img);

            // set the image to mandelSet
            mandelSet.Image = img;
 
        }

        private void mandelSet_MouseClick(object sender, MouseEventArgs e)
        {

        }


     }

}