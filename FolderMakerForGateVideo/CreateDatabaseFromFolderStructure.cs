using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderMakerForGateVideo
{
    public partial class CreateDatabaseFromFolderStructure : Form
    {
        public CreateDatabaseFromFolderStructure()
        {
            InitializeComponent();
        }

        private void CreateDatabaseFromFolderStructure_Load(object sender, EventArgs e)
        {
            string rootPath = folderBrowserDialog1.ShowDialog().ToString();
            IEnumerable<string> subjectsList = Directory.EnumerateDirectories(rootPath);
            using (var dbContext = new DBConnection())
            {
                foreach (string subName in subjectsList)
                {
                }
            }
        }
    }
}
