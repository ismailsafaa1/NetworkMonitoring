using System;
using System.Net.NetworkInformation;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using SpeedTest.Net;

namespace NetworkMonitoring
{
    public partial class SpeedInternet : Form
    {
        public SpeedInternet()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public async void CheckSpeed()
        {
          
            try
            {
                var speed = await FastClient.GetDownloadSpeed(SpeedTest.Net.Enums.SpeedTestUnit.MegaBitsPerSecond);
                labTestSpeed.Text = Math.Round(speed.Speed, 2).ToString() + "MB";
            }
            catch (Exception ex)
            {
                MessageBox.Show("يبدوا انك لم تقم بالاتصال بالشبكة", "خطا في الاتصال بالشبكة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bool Connection = NetworkInterface.GetIsNetworkAvailable();
            if (Connection == true)
            {
                labTestSpeed.Text = ".... جاري فحص السرعة";
                CheckSpeed();
            }else
            {
                MessageBox.Show("يبدوا انك لم تقم بالاتصال بالشبكة","خطا في الاتصال بالشبكة",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
