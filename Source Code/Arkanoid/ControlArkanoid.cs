using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class ControlArkanoid : UserControl
    {
        private CustomPictureBox[,] cpb;
        private Panel scores;
        private Label vidasRestantes, puntaje;
        private PictureBox ball;

        // Para trabajar con pic + label
        private PictureBox corazon;

        // Para trabajar con n pic
        private PictureBox[] corazones;

        private delegate void AccionesPelota();
        private readonly AccionesPelota MovimientoPelota;
        public Action TerminarJuego;

        public ControlArkanoid()
        {
            InitializeComponent();

            MovimientoPelota = RebotarPelota;
            MovimientoPelota += MoverPelota;
        }

        // Metodos que coinciden con el delegate de Event
        private void ControlArkanoid_Load(object sender, EventArgs e)
        {
            PanelPuntajes();
            
            // Seteando los atributos para picBox jugador
            pictureBox1.BackgroundImage = Image.FromFile("../../Img/Player.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            pictureBox1.Top = Height - pictureBox1.Height - 80;
            pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);

            // Seteando los atributos para picBox pelota
            ball = new PictureBox();
            ball.Width = ball.Height = 20;

            ball.BackgroundImage = Image.FromFile("../../Img/Ball.png");
            ball.BackgroundImageLayout = ImageLayout.Stretch;

            ball.Top = pictureBox1.Top - ball.Height;
            ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);

            Controls.Add(ball);

            LoadTiles();
        }

        private void LoadTiles()
        {
            int xAxis = 10, yAxis = 5;

            int pbWidth = (Width - (xAxis - 5)) / xAxis;
            int pbHeight = (int)(Height * 0.3) / yAxis;

            cpb = new CustomPictureBox[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i, j] = new CustomPictureBox();

                    if (i == 0)
                        cpb[i, j].Golpes = 2;
                    else
                        cpb[i, j].Golpes = 1;

                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;

                    // Posicion de left, y posicion de top
                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight + scores.Height + 1;

                    int imageBack = 0;

                    if (i % 2 == 0 && j % 2 == 0)
                        imageBack = 3;
                    else if (i % 2 == 0 && j % 2 != 0)
                        imageBack = 4;
                    else if (i % 2 != 0 && j % 2 == 0)
                        imageBack = 4;
                    else
                        imageBack = 3;

                    cpb[i, j].BackgroundImage = Image.FromFile("../../Img/" + imageBack + ".png");
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    cpb[i, j].Tag = "tileTag";

                    Controls.Add(cpb[i, j]);
                }
            }
        }

        private void ControlArkanoid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DatosJuego.juegoIniciado)
            {
                if (e.X < (Width - pictureBox1.Width))
                {
                    pictureBox1.Left = e.X;
                    ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);
                }
            }
            else
            {
                if (e.X < (Width - pictureBox1.Width))
                    pictureBox1.Left = e.X;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!DatosJuego.juegoIniciado)
                return;

            DatosJuego.ticksRealizados += 0.01;
            MovimientoPelota?.Invoke();
        }

        private void ControlArkanoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                DatosJuego.juegoIniciado = true;
                timer1.Start();
            }
        }

        private void RebotarPelota()
        {
            if (ball.Top < 0)
                DatosJuego.dirY = -DatosJuego.dirY;

            if (ball.Bottom > Height)
            {
                DatosJuego.vidas--;
                DatosJuego.juegoIniciado = false;
                timer1.Stop();

                ReposicionarElementos();
                ActualizarElementos();

                if (DatosJuego.vidas == 0)
                {
                    timer1.Stop();
                    TerminarJuego?.Invoke();
                }
            }

            if (ball.Left < 0 || ball.Right > Width)
            {
                DatosJuego.dirX = -DatosJuego.dirX;
                return;
            }

            if (ball.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                DatosJuego.dirY = -DatosJuego.dirY;
            }

            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (cpb[i, j] != null && ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {
                        DatosJuego.puntaje += (int)(cpb[i, j].Golpes * DatosJuego.ticksRealizados);
                        cpb[i, j].Golpes--;

                        if (cpb[i, j].Golpes == 0)
                        {
                            Controls.Remove(cpb[i, j]);
                            cpb[i, j] = null;
                        }

                        DatosJuego.dirY = -DatosJuego.dirY;

                        puntaje.Text = DatosJuego.puntaje.ToString();
                        return;
                    }
                }
            }
        }

        private void MoverPelota()
        {
            ball.Left += DatosJuego.dirX;
            ball.Top += DatosJuego.dirY;
        }

        private void PanelPuntajes()
        {
            // Instanciar panel
            scores = new Panel();

            // Setear elementos del panel
            scores.Width = Width;
            scores.Height = (int)(Height * 0.07);

            scores.Top = scores.Left = 0;

            scores.BackColor = Color.Black;

            #region Label + PictureBox
            // Instanciar pb
            corazon = new PictureBox();

            corazon.Height = corazon.Width = scores.Height;

            corazon.Top = 0;
            corazon.Left = 20;

            corazon.BackgroundImage = Image.FromFile("../../Img/Heart.png");
            corazon.BackgroundImageLayout = ImageLayout.Stretch;
            #endregion

            #region N cantidad de PictureBox
            corazones = new PictureBox[DatosJuego.vidas];

            for(int i = 0; i < DatosJuego.vidas; i++)
            {
                // Instanciacion de pb
                corazones[i] = new PictureBox();

                corazones[i].Height = corazones[i].Width = scores.Height;

                corazones[i].BackgroundImage = Image.FromFile("../../Img/Heart.png");
                corazones[i].BackgroundImageLayout = ImageLayout.Stretch;

                corazones[i].Top = 0;

                if (i == 0)
                    // corazones[i].Left = 20;
                    corazones[i].Left = scores.Width / 2;
                else
                {
                    corazones[i].Left = corazones[i - 1].Right + 5;
                }
            }
            #endregion

            // Instanciar labels
            vidasRestantes = new Label();
            puntaje = new Label();

            // Setear elementos de los labels
            vidasRestantes.ForeColor = puntaje.ForeColor = Color.White;

            vidasRestantes.Text = "x " + DatosJuego.vidas.ToString();
            puntaje.Text = DatosJuego.puntaje.ToString();

            vidasRestantes.Font = puntaje.Font = new Font("Microsoft YaHei", 24F);
            vidasRestantes.TextAlign = puntaje.TextAlign = ContentAlignment.MiddleCenter;

            vidasRestantes.Left = corazon.Right + 5;
            puntaje.Left = Width - 100;

            vidasRestantes.Height = puntaje.Height = scores.Height;

            scores.Controls.Add(corazon);
            scores.Controls.Add(vidasRestantes);
            scores.Controls.Add(puntaje);

            foreach(var pb in corazones)
            {
                scores.Controls.Add(pb);
            }

            Controls.Add(scores);
        }

        private void ReposicionarElementos()
        {
            pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);
            ball.Top = pictureBox1.Top - ball.Height;
            ball.Left = pictureBox1.Left + (pictureBox1.Width / 2) - (ball.Width / 2);
        }

        private void ActualizarElementos()
        {
            vidasRestantes.Text = "x " + DatosJuego.vidas.ToString();

            scores.Controls.Remove(corazones[DatosJuego.vidas]);
            corazones[DatosJuego.vidas] = null;
        }
    }
}
