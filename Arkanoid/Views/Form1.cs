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
            private Rectangle button1OriginalRect;
            private Rectangle button2OriginalRect;
            private Rectangle button3OriginalRect;
            private Size formOriginalSize;
            
        public Form1()    
        {
            InitializeComponent();
            // Height = ClientSize.Height;
            // Width = ClientSize.Width;
            // WindowState = FormWindowState.Maximized;
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
        
         // private void resizeChildrenControls()
         // {
         //     resizeControl(button1OriginalRect, button1);
         //     resizeControl(button2OriginalRect, button2);
         //     resizeControl(button3OriginalRect, button3);                            
         // }
         //
         // private void resizeControl(Rectangle OriginalControlRect, Control control)
         // {
         //     float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
         //     float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
         //        
         //        
         //     int newX = (int)(OriginalControlRect.X * xRatio);
         //     int newY = (int)(OriginalControlRect.Y * yRatio);
         //        
         //     int newWidth = (int)(OriginalControlRect.Width * xRatio);
         //     int newHeight = (int)(OriginalControlRect.Height * yRatio);
         //        
         //     control.Location = new Point(newX, newY);
         //     control.Size = new Size(newWidth, newHeight);                            
         // }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
            //resizeChildrenControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.BackgroundImage = Image.FromFile("../../Resources/arkanoid 3.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            // button1.BackgroundImageLayout = ImageLayout.Stretch;  
            
            // formOriginalSize = this.Size;
            // button1OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            // button2OriginalRect = new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);
            // button3OriginalRect = new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                var play = new Play();
                play.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
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