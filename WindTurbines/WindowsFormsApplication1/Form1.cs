/* Maira Soomro 
 * Assignment #4
 * CS 480 
 * ---------
 * Propeller 
 * This program will simulate a propeller 
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

namespace WindowsFormsApplication1
{
    public partial class propeller : Form
    {
        // make bitmap, make graphic
        Bitmap bmp = new Bitmap(600, 600);
        Graphics prop, prop2, square;

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        // Settings
        int radius = 500 / 2 - 50;
        int center = 600 / 2;
        int angle = 180;

        // brushes to draw pen with
        SolidBrush mustardBrush = new SolidBrush(Color.FromArgb(227, 208, 129));
        SolidBrush pinkBrush = new SolidBrush(Color.FromArgb(179, 57, 81));
        SolidBrush blueBrush = new SolidBrush(Color.FromArgb(145, 199, 177));
        SolidBrush dblueBrush = new SolidBrush(Color.FromArgb(32, 99, 122));
        public propeller()
        {
            InitializeComponent();
            player.SoundLocation = "wind.wav";
            player.Play(); 
        }

        private void propeller_Load(object sender, EventArgs e)
        {
            prop = Graphics.FromImage(bmp); //Binding the graphics to the Bitmap
            prop2 = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

         /*   pictureBox1.BackgroundImage = Image.FromFile
(System.Environment.GetFolderPath
(System.Environment.SpecialFolder.Personal)
+ @"/mountains1.png");*/
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            // create pen, use pen to draw shape
            // and use defined color 
            Pen drawingPen = new Pen(mustardBrush, 3);

            // create graphic
            Graphics center = e.Graphics;
            Graphics center2 = e.Graphics;
            Graphics center3 = e.Graphics;

            // apply anti aliasing for smooth lines
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // make circle
            center.FillEllipse(mustardBrush, 290, 290, 25, 25);
            center2.FillEllipse(mustardBrush, 73, 290, 25, 25);
            center3.FillEllipse(mustardBrush, 517, 295, 15, 15);

        }

        private int[] coordinates(int input_ang, int rad, int center)
        {
            int[] coordinates = new int[2];
            input_ang %= 360;
            input_ang *= 1;

            if (input_ang >= 0 && input_ang <= 180)
            {
                coordinates[0] = center + (int)(rad * Math.Sin(Math.PI * input_ang / 180));
                coordinates[1] = center - (int)(rad * Math.Cos(Math.PI * input_ang / 180));
            }
            else
            {
                coordinates[0] = center - (int)(rad * -Math.Sin(Math.PI * input_ang / 180));
                coordinates[1] = center - (int)(rad * Math.Cos(Math.PI * input_ang / 180));
            }
            return coordinates;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            prop = Graphics.FromImage(bmp);
           prop2 = Graphics.FromImage(bmp);
            square = Graphics.FromImage(bmp);

            prop.Clear(Color.Beige);
            pictureBox1.Image = bmp;
            
            Image image = new Bitmap("mountains1.png");
            TextureBrush tBrush = new TextureBrush(image);

            Rectangle rect = new Rectangle(0, 0, 600, 600);
            // make triangle base
            square.FillRectangle(tBrush, rect);
            
            //pictureBox1.Image = Image.FromFile("mountains1.png");
            //smooth jagged edges
            prop.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            prop2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            // --------------------------------------------------------------------
            //  First Propeller 
            // --------------------------------------------------------------------
            // points to define triangular base
            Point topPt2 = new Point(85, 300);
            Point leftPt2 = new Point(60, 400);
            Point rightPt2 = new Point(110, 400);
            Point[] trianglePts2 = { topPt2, leftPt2, rightPt2 };
            prop2.FillPolygon(pinkBrush, trianglePts2);

            // ----- BLADE 1 ----- //
            // Points for first propeller blade
            Point bOne21 = new Point(85, 300);
            Point bOne22 = new Point(coordinates(angle + 100, radius / 4, 85)[0], coordinates(angle + 100, radius / 4, 300)[1]);
            Point bOne23 = new Point(coordinates(angle + 140, radius/2, 85)[0], coordinates(angle + 140, radius/2, 300)[1]);

            // put it all together
            Point[] blade21 = { bOne21, bOne22, bOne23 };

            // fill it in 
            prop.FillPolygon(blueBrush, blade21);

            // ----- BLADE 2 ----- //
            // Points for first propeller blade
            Point bOne31 = new Point(85, 300);
            Point bOne32 = new Point(coordinates(angle + 200, radius / 4, 85)[0], coordinates(angle + 200, radius / 4, 300)[1]);
            Point bOne33 = new Point(coordinates(angle + 240, radius / 2, 85)[0], coordinates(angle + 240, radius / 2, 300)[1]);
            Point[] blade31 = { bOne31, bOne32, bOne33 };
            prop.FillPolygon(blueBrush, blade31);

            // ----- BLADE 3 ----- //
            // Points for first propeller blade
            Point bOne41 = new Point(85, 300);
            Point bOne42 = new Point(coordinates(angle + 340, radius / 4, 85)[0], coordinates(angle + 340, radius / 4, 300)[1]);
            Point bOne43 = new Point(coordinates(angle + 380, radius / 2, 85)[0], coordinates(angle + 380, radius / 2, 300)[1]);
            Point[] blade41 = { bOne41, bOne42, bOne43 };
            prop.FillPolygon(blueBrush, blade41);


            // --------------------------------------------------------------------
            //  Second Propeller 
            // --------------------------------------------------------------------
            // points to define triangular base
            Point topPt = new Point(305, 290);
            Point leftPt = new Point(260, 530);
            Point rightPt = new Point(335, 530);
            Point[] trianglePts = { topPt, leftPt, rightPt };

            // make triangle base
            prop.FillPolygon(pinkBrush, trianglePts);

            // Points for first propeller blade
            Point bOne1 = new Point(center, center);
            Point bOne2 = new Point(coordinates(angle + 140, radius / 2, center)[0], coordinates(angle + 140, radius / 2, center)[1]);
            Point bOne3 = new Point(coordinates(angle + 180, radius, center)[0], coordinates(angle + 180, radius, center)[1]);

            // put it all together
            Point[] blade1 = { bOne1, bOne2, bOne3 };

            // fill it in 
            prop.FillPolygon(dblueBrush, blade1);

            // points for second propeller blade
            Point bTwo1 = new Point(center, center);
            Point bTwo2 = new Point(coordinates(angle + 240, radius / 2, center)[0], coordinates(angle + 240, radius / 2, center)[1]);
            Point bTwo3 = new Point(coordinates(angle + 280, radius, center)[0], coordinates(angle + 280, radius, center)[1]);
            Point[] blade2 = { bTwo1, bTwo2, bTwo3 };
            prop.FillPolygon(dblueBrush, blade2);

            // points for third propeller blade
            Point bThree1 = new Point(center, center);
            Point bThree2 = new Point(coordinates(angle + 360, radius / 2, center)[0], coordinates(angle + 360, radius / 2, center)[1]);
            Point bThree3 = new Point(coordinates(angle + 400, radius, center)[0], coordinates(angle + 400, radius, center)[1]);
            Point[] blade3 = { bThree1, bThree2, bThree3 };
            prop.FillPolygon(dblueBrush, blade3);



            // --------------------------------------------------------------------
            //  third Propeller 
            // --------------------------------------------------------------------

            // points to define triangular base
            Point tPt = new Point(525, 300);
            Point lPt = new Point(515, 370);
            Point rPt = new Point(535, 370);
            Point[] tPts = { tPt, lPt, rPt };

            // make triangle base
            prop.FillPolygon(pinkBrush, tPts);

            // Points for first propeller blade 
            
            Point blThree1 = new Point(525, 300);
            Point blThree2 = new Point(coordinates(angle + 140, radius / 8, 525)[0], coordinates(angle + 140, radius / 8, 300)[1]);
            Point blThree3 = new Point(coordinates(angle + 180, radius/4, 525)[0], coordinates(angle + 180, radius/4, 300)[1]);

            // put it all together
            Point[] blThree = { blThree1, blThree2, blThree3 };

            // fill it in 
            prop.FillPolygon(blueBrush, blThree);


            // ---- second

            // Points for first propeller blade 
            Point blThree12 = new Point(525, 300);
            Point blThree22 = new Point(coordinates(angle + 240, radius / 8, 525)[0], coordinates(angle + 240, radius / 8, 300)[1]);
            Point blThree32 = new Point(coordinates(angle + 280, radius / 4, 525)[0], coordinates(angle + 280, radius / 4, 300)[1]);
            Point[] blThree222 = { blThree12, blThree22, blThree32 };
            prop.FillPolygon(blueBrush, blThree222);


            // ---- third

            // Points for first propeller blade 
            Point blThree123 = new Point(525, 300);
            Point blThree223 = new Point(coordinates(angle + 380, radius / 8, 525)[0], coordinates(angle + 380, radius / 8, 300)[1]);
            Point blThree323 = new Point(coordinates(angle + 420, radius / 4, 525)[0], coordinates(angle + 420, radius / 4, 300)[1]);
            Point[] blThree1222 = { blThree123, blThree223, blThree323};
            prop.FillPolygon(blueBrush, blThree1222);

            prop.Dispose();
            if (angle == 360)
            {
                angle = 0;
            }
            else
            {
                angle++;
            }
        }


    }
}
