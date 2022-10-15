using System.Windows.Forms;

namespace FolderMakerForGateVideo
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }
        public Player(string path)
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = path;
            //axWindowsMediaPlayer1.settings.rate = 9.5;
        }
    }
}
