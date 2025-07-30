using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace NetworkMonitoring
{
    public partial class IPInterface : Form
    {
        public IPInterface()
        {
            InitializeComponent();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface intf in interfaces)
            {
                
                    guna2ComboBox1.Items.Add(intf.Name);
                
            }
        }
        private void SetIP(string changeaddress)
        {
            try
            {
                ProcessStartInfo cmd = new ProcessStartInfo("cmd.exe");
                cmd.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.Verb = "runas";
                cmd.Arguments = changeaddress;
                Process.Start(cmd);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void IPInterface_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string IpAddress = textIPaddress.Text;
            string SubnetMask = textSubnetMask.Text;
            string GetWay = textDafaultGetway.Text;
            string Pirmarykey = textPrimayDns.Text;
            string SecondDns = textSecondDns.Text;
           SetIP("/c netsh interface ip set address" + guna2ComboBox1.Text + "static" + IpAddress + "" + SubnetMask + "" + GetWay + "& netsh interface ip set dns" + guna2ComboBox1.Text + "static" + "" + Pirmarykey + $"& netsh interface ip add dns {guna2ComboBox1.Text} { SecondDns} index=2");
        }

        private void btnDhcp_Click(object sender, EventArgs e)
        {
            SetIP("/c netsh interface ip set address" + guna2ComboBox1.Text + "dhcp & netsh interface ip set dns"+ guna2ComboBox1.Text + "dhcp");

        }
    }
}
