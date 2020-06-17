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
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams handleParam = base.CreateParams;
        //        handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
        //        return handleParam;
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void BttnStartGame_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Hide();
            Controls.Add(ca);
        }

        private void BttnViewTop_Click(object sender, EventArgs e)
        {
            FormTop ft = new FormTop();

            ft.CloseAction = () =>
            {
                Show();
            };

            ft.Show();
            Hide();
        }

        private void BttnExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
