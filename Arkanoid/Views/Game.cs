using System;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Model;

namespace Arkanoid
{
    public partial class Game : Form
    {
        private CustomPictureBox[,] cpb;
        public Game()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }

        private void Game_Resize(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        
        private void Game_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("../../Resources/Player.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Top = (Height - pictureBox1.Height) - 80;
            LoadTiles();
        }

        private void LoadTiles()
        {
            int xAxis = 10;
            int yAxis = 5;

            int pbHeight = (int)(Height * 0.3) / yAxis;
            int pbWidth = (Width - xAxis) / xAxis;
            
            cpb = new CustomPictureBox[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i,j] = new CustomPictureBox();

                    if (i == 0)
                        cpb[i, j].Golpes = 2;

                    else
                        cpb[i, j].Golpes = 1;

                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;

                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight;
                    
                    cpb[i,j].BackgroundImage = Image.FromFile("../../Resources/" + GRN() + ".png");
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    cpb[i, j].Tag = "tileTag";
                    
                    Controls.Add(cpb[i,j]);
                }
            }
            
        }

        private int GRN()
        {
            return new Random().Next(1, 7);
        }

        
    }
}