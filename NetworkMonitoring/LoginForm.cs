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
          

            if(texUserName.Text == "admin" || texPassword.Text == "1234")
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
               this.Hide();


            }
            else
            {
              MessageBox.Show("خطا في معلومات المسجلة","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

           
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

            StreamWriter streamWriter = new StreamWriter(@"seetingnet.txt");

            if (checkBox1.Checked == true)
            {
                streamWriter.WriteLine(texPassword.Text);
                streamWriter.WriteLine(texUserName.Text);
                texUserName.Text = streamWriter.ToString();
                texPassword.Text = streamWriter.ToString();
                streamWriter.Close();
            }
            else
            {
                streamWriter.WriteLine("");
            }

        }
    }
}
