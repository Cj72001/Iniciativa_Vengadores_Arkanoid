using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid.Views
{
    public partial class PlayControl : UserControl
    {

        private Rectangle BtnBack1OriginalRect;
        private Rectangle BtnPlay1OriginalRect;
        private Rectangle textBox1OriginalRect;
        
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
                Hide();
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); throw; }
        }
    }
}