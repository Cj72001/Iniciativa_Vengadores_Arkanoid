using System;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Model;

namespace Arkanoid
{
    public partial class Game : Form
    {
        
        public Game()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }   
    }
}