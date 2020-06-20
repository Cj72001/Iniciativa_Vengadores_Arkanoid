using System;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Model;

namespace Arkanoid.Views
{
    public partial class ArkanoidControl : UserControl
    {
        private CustomPictureBox[,] cpb;
        private Panel scorePanel;
        private Label remainingLives, score;
        private PictureBox heart;
        
        private PictureBox ball;
        private delegate void BallActions();
        private BallActions BallMovement;
        public Action GameEnded; 
        public Action GameWon;
        public Action <int, string> DataGame; //RECIBIENDO SCORE y NOMBRE DEL USUARIO
        private int xAxis = 3, yAxis = 4;
        private string nick;

        /*REAL
             int xAxis = 10;
             int yAxis = 5;*/
        /*PRUEBA
         int xAxis = 3;
         int yAxis = 3;*/

        public ArkanoidControl()
        {
            InitializeComponent();
            
            BallMovement = BounceBall;
            BallMovement += MoveBall;
        }
        public ArkanoidControl(string nombre)
        {
            InitializeComponent();
            nick = nombre;
            BallMovement = BounceBall;
            BallMovement += MoveBall;
        }
        
        
        //Metodos que coinciden  con el Delegate de Event
        private void Game_Load(object sender, EventArgs e)
        {
            ScorePanel();
            
            //Seteando los elementos para el pictureBox jugador:
            playerPb.BackgroundImage = Image.FromFile("../../Resources/Player.png");
            playerPb.BackgroundImageLayout = ImageLayout.Stretch;
            playerPb.Top = Height - playerPb.Height - 80;
            playerPb.Left = (Width / 2) - (playerPb.Width / 2);
            
            //Seteando los elementos para el pictureBox ball:
            ball = new PictureBox();
            ball.Width = ball.Height = 20;
            ball.BackgroundImage = Image.FromFile("../../Resources/Ball.png");
            playerPb.BackgroundImageLayout = ImageLayout.Stretch; 
            ball.BackColor = Color.White;
            ball.Top = playerPb.Top - ball.Height;
            ball.Left = playerPb.Left + (playerPb.Width / 2) - (ball.Width / 2);
            
            //Suscribiendo metodo para insertar datos a BD
            DataGame = InsertValuesDB;


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
                        cpb[i, j].Hits = 2;

                    else
                        cpb[i, j].Hits = 1; 

                    //Tamano de cpb
                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;
                    
                    //Posicion de left y top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight + scorePanel.Height + 1;

                    if (i == 0)
                    {
                        //Seteando imagen de cpb en i==0
                        cpb[i,j].BackgroundImage = Image.FromFile("../../Resources/10.png");
                        cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        cpb[i, j].Tag = "tileTag";
                        Controls.Add(cpb[i,j]);
                    }
                    
                    else
                    {
                        //Seteando imagen de cpb 
                        cpb[i,j].BackgroundImage = Image.FromFile("../../Resources/" + GRN() + ".png");
                        cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        cpb[i, j].Tag = "tileTag";
                        Controls.Add(cpb[i,j]);
                    }
                }
            }
            
        }

        private int GRN()
        {
            return new Random().Next(1, 8);
        }


        private void Game_MouseMove(object sender, MouseEventArgs e)
        {
            if (!GameData.gameStarted)
            {
                if (e.X < (Width - playerPb.Width))
                {
                    playerPb.Left = e.X;
                    ball.Left = playerPb.Left + (playerPb.Width / 2) - (ball.Width / 2);
                }
            }

            else
            {
                if(e.X < (Width - playerPb.Width))
                    playerPb.Left = e.X;
            }
        }
        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(!GameData.gameStarted)
                return;

            GameData.ticksMade += 0.01;
            BallMovement?.Invoke();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                GameData.gameStarted = true;
                timer1.Start();
            }
                
        }

        private void BounceBall()
        {
            //Pierde vida si:
            if (ball.Bottom > Height)
            {
                GameData.lives--;
                GameData.gameStarted = false; 
                timer1.Stop();
                RepositionItems();
                UpdateItems();

                //Terminando juego
                if (GameData.lives == 0)
                {
                    timer1.Stop();
                    GameEnded?.Invoke();
                    
                    var nombre = "NombredeUsuario";
                    DataGame?.Invoke(GameData.score, nombre);
                }
                
            }
                
            if (ball.Left < 0 || ball.Right > Width)
            {
                GameData.dirX = -GameData.dirX;
                return;
            }

            if (ball.Bounds.IntersectsWith(playerPb.Bounds))
            {
                GameData.dirY = -GameData.dirY;
            }

            //Cargar tiles:
            for (int i = 0; i < yAxis; i++) 
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
                        GameData.score += (int)(cpb[i, j].Hits * GameData.ticksMade);
                        cpb[i, j].Hits--;

                        if (cpb[i, j].Hits == 0)
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

        //Se encarga de inicializar todos los elementos del panel de puntaje + vidas
        private void ScorePanel()
        {
            //Instanciando panel
            scorePanel = new Panel();
            
            //Seteando elementos de panel
            scorePanel.Width = Width;
            scorePanel.Height = (int)(Height * 0.07);

            scorePanel.Top = scorePanel.Left = 0;
            
            scorePanel.BackColor = Color.Blue;
            
            //Instanciando pictureBox
            heart = new PictureBox();

            heart.Height = heart.Width = scorePanel.Height; 
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

            remainingLives.Height = score.Height = scorePanel.Height;
            
            
            scorePanel.Controls.Add(remainingLives);
            scorePanel.Controls.Add(score);
            scorePanel.Controls.Add(heart);

            Controls.Add(scorePanel);
        }

        private void RepositionItems()
        {
            playerPb.Left = (Width / 2) - (playerPb.Width / 2);
            ball.Top = playerPb.Top - ball.Height;
            ball.Left = playerPb.Left + (playerPb.Width / 2) - (ball.Width / 2);
        }

        private void UpdateItems()
        {
            remainingLives.Text = "x " + GameData.lives.ToString();
        }

        //MANDAR DATOS DEL JUGADOR A LA BD
        public static void InsertValuesDB(int score, string nombreUsuario)
        {
            
                DBConnetion.RealizarAccion("INSERT INTO USUARIO (name, score)"+
                                           $"VALUES ('{nombreUsuario}', '{score}')");
            
        }
    }
}