using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Play : Form
    {
        public Play()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }

        private void Play_Resize(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Debe ingresar un nombre de usuario");
                }else
                {
                    var game = new Game();
                    game.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Play_Load(object sender, EventArgs e)
        {
            
            // label1.BackgroundImageLayout = ImageLayout.Stretch;
            // button1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }
    }
}