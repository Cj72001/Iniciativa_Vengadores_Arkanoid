using System;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Model;

namespace Arkanoid.Views
{
    public partial class ArkanoidControl : UserControl
    {
        private CustomPictureBox[,] cpb;
        private Panel scores;
        private Label remainingLives, score;
        private PictureBox heart;
        
        private PictureBox ball;
        private delegate void BallActions();
        private BallActions BallMovement;
        public Action GameEnded;
        public Action GameWon;
        private int xAxis = 3, yAxis = 4;
        
        /*REAL
             int xAxis = 10;
             int yAxis = 5;*/
        /*PRUEBA
         int xAxis = 3;
         int yAxis = 3;*/

        public ArkanoidControl()
        {
            InitializeComponent();
            
            BallMovement = BallBounce;
            BallMovement += MoveBall;
        }
        
        //Metodos que coinciden  con el Delegate de Event
        private void Game_Load(object sender, EventArgs e)
        {
            ScorePanel();
            
            
            //Seteando los elementos para el pictureBox jugador:
            pictureBox1.BackgroundImage = Image.FromFile("../../Resources/Player.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Top = Height - pictureBox1.Height - 80;
            pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);
            
            //Seteando los elementos para el pictureBox ball:
            ball = new PictureBox();
            ball.Width = ball.Height = 20;
            ball.BackgroundImage = Image.FromFile("../../Resources/ball.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch; 
            ball.BackColor = Color.White;
            ball.Top = pictureBox1.Top - ball.Height;
            ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);


            Controls.Add(ball);
            LoadTiles();
        }
        
        private void LoadTiles()
        {
            int pbWidth = (Width - xAxis) / xAxis;
            int pbHeight = (int)(Height * 0.3) / yAxis;
            
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
                    
                    //Posicion de left y top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight + scores.Height + 1;

                    if (i == 0)
                    {
                        cpb[i,j].BackgroundImage = Image.FromFile("../../Resources/10.png");
                        cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        cpb[i, j].Tag = "tileTag";
                        Controls.Add(cpb[i,j]);
                    }
                    
                    else
                    {
                        cpb[i,j].BackgroundImage = Image.FromFile("../../Resources/" + GRN() + ".png");
                        cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        cpb[i, j].Tag = "tileTag";
                        Controls.Add(cpb[i,j]);
                    }
                    // int imageBack = 0;
                    // if (i % 2 == 0 && j % 2 == 0)
                    //     imageBack = 3;
                    //
                    // else if (i % 2 == 0 && j % 2 != 0)
                    //     imageBack = 4;
                    //
                    // else if (i % 2 != 0 && j % 2 != 0)
                    //     imageBack = 4;
                    //
                    // else
                    //     imageBack = 3;
                    //
                    // cpb[i,j].BackgroundImage = Image.FromFile("../../Resources/"+ imageBack +"10.png");
                    // cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            
        }

        private int GRN()
        {
            return new Random().Next(1, 8);
        }


        private void Game_MouseMove(object sender, MouseEventArgs e)
        {
            if (!GameData.GameStarted)
            {
                if (e.X < (Width - pictureBox1.Width))
                {
                    pictureBox1.Left = e.X;
                    ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);
                }
            }

            else
            {
                if(e.X < (Width - pictureBox1.Width))
                    pictureBox1.Left = e.X;
            }
        }
        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(!GameData.GameStarted)
                return;

            GameData.ticksMade += 0.01;
            BallMovement?.Invoke();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                GameData.GameStarted = true;
                timer1.Start();
            }
                
        }

        private void BallBounce()
        {
            if (ball.Bottom > Height)
            {
                GameData.lives--;
                GameData.GameStarted = false; 
                timer1.Stop();
                RepositionItems();
                UpdateItems();

                if (GameData.lives == 0)
                {
                    timer1.Stop();
                    GameEnded?.Invoke();
                }
                
            }
                
            if (ball.Left < 0 || ball.Right > Width)
            {
                GameData.dirX = -GameData.dirX;
                return;
            }

            if (ball.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                GameData.dirY = -GameData.dirY;
            }

            for (int i = 0; i < yAxis; i++) // for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < xAxis; j++) // for (int j = 10; j < 1; j++)
                {
                    if (cpb[i,j]!=null && ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {
                        //Para los bloques blindados
                        if (i == 0)
                        {
                            GameData.dirY = -GameData.dirY;
                            return;
                        }
                        
                        //Para ver si se destruyeron todos los bloques, para ganar la partida
                        
                        if (i == 1 && j == 0)
                        {
                            if (cpb[1, 1] == null &&
                                cpb[1, 2] == null)
                            {
                                Controls.Remove(cpb[i, j]);
                                timer1.Stop();
                                GameWon?.Invoke();
                                return;
                            }
                        }

                        if (i == 1 && j == 1)
                        {
                            if (cpb[1, 0] == null && 
                                cpb[1, 2] == null)
                            {
                                Controls.Remove(cpb[i, j]);
                                timer1.Stop();
                                GameWon?.Invoke();
                                return;
                            }
                        }

                        if (i == 1 && j == 2)
                        {
                            if (cpb[1, 0] == null && 
                                cpb[1, 1] == null)
                            {
                                Controls.Remove(cpb[i, j]);
                                timer1.Stop();
                                GameWon?.Invoke();
                                return;
                            }
                        }
                        
                        //El escore depende de la distancia que parque el tick
                        GameData.score += (int)(cpb[i, j].Golpes * GameData.ticksMade);
                        cpb[i, j].Golpes--;

                        if (cpb[i, j].Golpes == 0)
                        {
                            Controls.Remove(cpb[i,j]);
                            cpb[i, j] = null;
                        }
                            

                        GameData.dirY = -GameData.dirY;
                        

                        score.Text = GameData.score.ToString();
                        return;
                    }
                }
            }
        }
        
        private void MoveBall()
        {
            ball.Left += GameData.dirX;
            ball.Top += GameData.dirY;
        }

        private void ScorePanel()
        {
            //Instanciando panel
            scores = new Panel();
            
            //Seteando elementos de panel
            scores.Width = Width;
            scores.Height = (int)(Height * 0.07);

            scores.Top = scores.Left = 0;
            
            scores.BackColor = Color.Blue;
            
            //Instanciando pictureBox
            heart = new PictureBox();

            heart.Height = heart.Width = scores.Height; 
            heart.Left = 20;
            heart.BackgroundImage = Image.FromFile("../../Resources/Heart.png");
            heart.BackgroundImageLayout = ImageLayout.Stretch;
            


            //Instanciando labels
            remainingLives = new Label();
            score = new Label();

            //Setenado elementos de los labels
            remainingLives.ForeColor = score.ForeColor = Color.White;
            remainingLives.Text = "x " + GameData.lives.ToString();
            score.Text = GameData.score.ToString();

            remainingLives.Font = score.Font = new Font(remainingLives.Font.Name, 24F);
            remainingLives.TextAlign = score.TextAlign = ContentAlignment.MiddleCenter;

            remainingLives.Left = heart.Right + 5;
            score.Left = Width - 100;

            remainingLives.Height = score.Height = scores.Height;
            
            
            scores.Controls.Add(remainingLives);
            scores.Controls.Add(score);
            scores.Controls.Add(heart);

            Controls.Add(scores);
        }

        private void RepositionItems()
        {
            pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);
            ball.Top = pictureBox1.Top - ball.Height;
            ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);
        }

        private void UpdateItems()
        {
            remainingLives.Text = "x " + GameData.lives.ToString();
        }
    }
}