using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid.Views
{
    public partial class PlayControl : UserControl
    {
        
        UserControl ControlActual = new UserControl();
        private Size formOriginalSize;
        public PlayControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Debe ingresar un nombre de usuario");
                }
                else
                {
                    this.Controls.Clear();
                    var ac = new ArkanoidControl();
                    ac.Width = Width;
                    ac.Height = Height;
                    ac.Dock = DockStyle.Fill;
                    ac.AutoSize = true;
                    ControlActual = ac;
                    this.Controls.Add(ControlActual);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnPlay_MouseEnter(object sender, EventArgs e) { BtnPlay.BackColor = Color.Red; }

        private void BtnPlay_MouseLeave(object sender, EventArgs e) { BtnPlay.BackColor = Color.Transparent; }

        private void BtnBack_MouseEnter(object sender, EventArgs e) { BtnBack.BackColor = Color.Red; }

        private void BtnBack_MouseLeave(object sender, EventArgs e) { BtnBack.BackColor = Color.Transparent; }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                var menuForm = new Form1();
                menuForm.Show();
                menuForm.Dock = DockStyle.Fill;
                Hide();
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); throw; }
        }

        private void PlayControl_Resize(object sender, EventArgs e)
        {
            ControlActual.Height = Height;
            ControlActual.Width = Width;
        }
    }
}