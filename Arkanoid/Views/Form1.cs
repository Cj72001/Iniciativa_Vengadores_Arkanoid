using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Form1 : Form
    {
        public Form1()    
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }


        private void button1_MouseEnter(object sender, EventArgs e)
        {
                button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }
        
        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.BackgroundImage = Image.FromFile("../../Resources/arkanoid 3.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.BackgroundImageLayout = ImageLayout.Stretch;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var play = new Game();
                play.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // try
            // {
            //     var play = new Play();
            //     play.Show();
            //     Hide();
            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show(ex.Message);
            // }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var score = new Score();
                score.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}