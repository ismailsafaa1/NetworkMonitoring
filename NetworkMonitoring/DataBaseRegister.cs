using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMonitoring
{
    public partial class DataBaseRegister : Form
    {
        public DataBaseRegister()
        {
            InitializeComponent();
        }
        private static string connectionString = "data source=DESKTOP-GE3H3SI; database=mastr; User Id=sa; Password=sa123456; integrated security=True";

        private void DataBaseRegister_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string qouery = "select * from networkRegister ";
            SqlCommand command = new SqlCommand(qouery , con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
