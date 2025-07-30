using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMonitoring
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Load()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            picAP.BackColor = Color.Green;
            picCamera.BackColor = Color.Red;
            picDesktop.BackColor = Color.Green;
            picRouter.BackColor = Color.Red;
            pictureBox1.BackColor = Color.Green;
            picTelephone.BackColor = Color.Red;
        }
    }
}
