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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NetProgram netProgram = new NetProgram();
            netProgram.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataBaseRegister dataBaseRegister = new DataBaseRegister();
            dataBaseRegister.ShowDialog();
        }

   

        private void button5_Click_1(object sender, EventArgs e)
        {
            SpeedInternet speedInternet = new SpeedInternet();
            speedInternet.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            IPInterface IPInterface = new IPInterface();
            IPInterface.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NetProgram netProgram = new NetProgram();
            netProgram.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataBaseRegister dataBaseRegister = new DataBaseRegister();
            dataBaseRegister.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            IPInterface IPInterface = new IPInterface();
            IPInterface.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SpeedInternet speedInternet = new SpeedInternet();
            speedInternet.ShowDialog();
        }
    }
}
