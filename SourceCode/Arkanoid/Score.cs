using System;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Score : Form
    {
        public Score()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }

        private void Score_Resize(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}