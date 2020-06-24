using System.Windows.Forms;

namespace Arkanoid.Model
{
    public class CustomPictureBox : PictureBox

    {
        public int Hits { get; set; }

        public CustomPictureBox() : base() {}
    }
}