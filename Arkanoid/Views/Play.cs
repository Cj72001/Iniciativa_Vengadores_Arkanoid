using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Arkanoid
{
    public partial class Play : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle textBox1OriginalRect;
        private Size formOriginalSize;
        
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
            resizeChildrenControls();
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
        
        private void resizeChildrenControls()
                 {
                     resizeControl(button1OriginalRect, button1);
                     resizeControl(textBox1OriginalRect, textBox1);                          
                 }
                 
                 private void resizeControl(Rectangle OriginalControlRect, Control control)
                 {
                     float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
                     float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
                        
                        
                     int newX = (int)(OriginalControlRect.X * xRatio);
                     int newY = (int)(OriginalControlRect.Y * yRatio);
                        
                     int newWidth = (int)(OriginalControlRect.Width * xRatio);
                     int newHeight = (int)(OriginalControlRect.Height * yRatio);
                        
                     control.Location = new Point(newX, newY);
                     control.Size = new Size(newWidth, newHeight);                            
                 }

        private void Play_Load(object sender, EventArgs e)
        {
            // label1.BackgroundImageLayout = ImageLayout.Stretch;
            // button1.BackgroundImageLayout = ImageLayout.Stretch;
             formOriginalSize = this.Size;
            button1OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            textBox1OriginalRect = new Rectangle(textBox1.Location.X, textBox1.Location.Y, textBox1.Width, textBox1.Height);
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