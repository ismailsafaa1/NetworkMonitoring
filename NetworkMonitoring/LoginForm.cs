using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMonitoring
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          

          
           
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (texUserName.Text == "admin" || texPassword.Text == "1234")
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("خطا في معلومات المسجلة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
