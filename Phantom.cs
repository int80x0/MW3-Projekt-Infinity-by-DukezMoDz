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
using PS3Lib;
using SNMAPINetLib;
using MetroFramework.Forms;

namespace MW3_Projekt_Infinity_by_RATModz
{
    public partial class Phantom : MetroForm
    {
        public Phantom()
        {
            InitializeComponent();
        }

        private void Phantom_Load(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.metroCheckBox1.Checked)
            {
                Form1.PhantomOpen = true;
                return;
            }
            Form1.PhantomOpen = false;
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.metroCheckBox2.Checked)
            {
                Form1.PhantomAutoLeave = true;
                return;
            }
            Form1.PhantomAutoLeave = false;
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.metroCheckBox3.Checked)
            {
                Form1.NonHostNameChange = true;
                return;
            }
            Form1.NonHostNameChange = false;
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.metroCheckBox4.Checked)
            {
                MessageBox.Show("Das NonHost Juggernaut kann fälschlicher weiße verwechselt werden wenn jemand die StandartKlasse nimmt.");
                Form1.Juggernaut = true;
                return;
            }
            Form1.Juggernaut = false;
        }
    }
}


