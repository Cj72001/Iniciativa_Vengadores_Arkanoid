using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid.Views
{
    public partial class MainForm : Form
    {
        private UserControl ControlActual = new UserControl();
        public MainForm()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }

        public MainForm(UserControl uc)
        {
            InitializeComponent();
            ControlActual = uc;
            ControlActual.Height = Height;
            ControlActual.Width = Width;
            ControlActual.AutoSize = true;
            this.Controls.Add(ControlActual);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ControlActual.Height = Height;
            ControlActual.Width = Width;
        }
    }
}
