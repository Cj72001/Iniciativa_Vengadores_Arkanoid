using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Form1 : Form
    {
        private ControlArkanoid ca;
        
        public Form1()
        {
            InitializeComponent();
            
            // Maximizar ventana en su creacion
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;

            MinimizeBox = MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(Width, Height);



            tableLayoutPanel1.BackColor = Color.Transparent;
            
            BackgroundImage = Image.FromFile("../../Img/bg.png");
            BackgroundImageLayout = ImageLayout.Stretch;

            ca = new ControlArkanoid();

            ca.Dock = DockStyle.Fill;

            ca.Width = Width;
            ca.Height = Height;

            ca.FinishGame = () =>
            {
                ca = null;
                ca = new ControlArkanoid();

                MessageBox.Show("Has perdido");

                ca.Hide();
                tableLayoutPanel1.Show();
            };
        }

        protected override void OnResize(EventArgs e)
        {
            
        }

        private void BttnStartGame_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Hide();
            Controls.Add(ca);
        }

        private void BttnViewTop_Click(object sender, EventArgs e)
        {
            FormTop ft = new FormTop
            {
                CloseAction = () =>
                {
                    Show();
                }
            };

            ft.Show();
            Hide();
        }

        private void BttnExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            Width = ClientSize.Width;
            Height = ClientSize.Height;
            Location = new Point(0,0);
        }
    }
}
