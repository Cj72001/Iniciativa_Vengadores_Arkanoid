using System.Windows.Forms;

namespace Arkanoid
{
    public partial class FormTop : Form
    {
        public delegate void OnClosedWindow();
        public OnClosedWindow CloseAction;

        public FormTop()
        {
            InitializeComponent();
        }

        private void FormTop_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseAction?.Invoke();
        }
    }
}
