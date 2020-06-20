using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid.Views
{
    public partial class Menu : Form
    {
        //Declarando sc de tipo ScoreControl
        private ScoreControl sc;

        public Menu()    
        {
            //Propiedad de Menu
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Image.FromFile("../../Resources/fondo1.jpg");
        }
        
        private void Menu_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            
            //Instanciando ScoreControl
            sc = new ScoreControl();
            sc.Dock = DockStyle.Fill;
            sc.Width = Width;
            sc.Height = Height;
            
        }
        
        //Propiedades de botones:
        private void BtnPlay_MouseEnter(object sender, EventArgs e)
        {
                BtnPlay.BackColor = Color.Red;
        }

        private void BtnPlay_MouseLeave(object sender, EventArgs e)
        {
            BtnPlay.BackColor = Color.Transparent;
        }

        private void BtnScore_MouseEnter(object sender, EventArgs e)
        {
            BtnScore.BackColor = Color.Red;
        }
        
        private void BtnScore_MouseLeave(object sender, EventArgs e)
        {
            BtnScore.BackColor = Color.Transparent;
        }

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.Red;
        }

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.Transparent;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            //Abriendo el form Game
            var gameForm = new Game();
            gameForm.Show();
            this.Hide();
        }

        private void BtnScore_Click(object sender, EventArgs e)
        {
            //Cambiando el control que contiene actualemente el tableLayout por ScoreControl
            tableLayoutPanel1.Hide();
            this.Text = "Score";
            Controls.Add(sc);
            
            //Metodo para cambiar de Control
            sc.RemoveScoreControl = () =>
            {
               Controls.Remove(sc);
               this.Text = "Menu";
               tableLayoutPanel1.Show();
            };
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
