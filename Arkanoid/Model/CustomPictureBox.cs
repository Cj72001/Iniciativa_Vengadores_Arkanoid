using System.Windows.Forms;

namespace Arkanoid.Model
{
    public class CustomPictureBox : PictureBox

    {

        public int Golpes { get; set; }

        public CustomPictureBox() : base() {}
    }
}