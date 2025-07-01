using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW3_Projekt_Infinity_by_RATModz
{
    public partial class Preview : Form
    {
        public static Image IMG = null;
        public static string IMGName = null;
        public Preview()
        {
            InitializeComponent();
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Preview.IMG;
            base.Width = this.pictureBox1.Width + 16;
            base.Height = this.pictureBox1.Height + 39;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG| *.png";
            saveFileDialog.Title = "Save the " + Preview.IMGName + ".png";
            saveFileDialog.FileName = Preview.IMGName + ".png";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != null)
            {
                this.pictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }
    }
}
