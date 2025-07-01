using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Media;

namespace MW3_Projekt_Infinity_by_RATModz
{
    public partial class MP3 : MetroForm
    {
        public MP3()
        {
            InitializeComponent();
        }

        private void MP3_Load(object sender, EventArgs e)
        {

        }

        private void metroButton235_Click(object sender, EventArgs e)
        {
            if (this.metroCheckBox20.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SoundPlayer soundPlayer = new SoundPlayer(openFileDialog.FileName);
                    soundPlayer.Play();
                }
                else
                {
                    MessageBox.Show("Cant Play Sound !", "Failed To Play", MessageBoxButtons.OKCancel);
                }
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SoundPlayer soundPlayer = new SoundPlayer(openFileDialog.FileName);
                    soundPlayer.PlayLooping();
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.Stop();
        }
    }
}
