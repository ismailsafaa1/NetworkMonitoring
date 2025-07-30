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
            //SqlConnection con = new SqlConnection(connectionString);
            //string qouery = "select * from networkRegister ";
            //SqlCommand command = new SqlCommand(qouery , con);
            //con.Open();
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable dt = new DataTable();
            
            //adapter.Fill(dt);
            //dataGridView1.DataSource = dt;
            //con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM networkRegister WHERE CAST(DateTimeAPDown AS DATE) = CAST(GETDATE() AS DATE)";
            LoadFilteredData(query);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT * FROM networkRegister 
        WHERE CAST(DateTimeAPDown AS DATE) >= CAST(DATEADD(DAY, -7, GETDATE()) AS DATE) 
        AND CAST(DateTimeAPDown AS DATE) < CAST(GETDATE() AS DATE)";
            LoadFilteredData(query);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT * FROM networkRegister 
        WHERE MONTH(DateTimeAPDown) = MONTH(GETDATE()) 
        AND YEAR(DateTimeAPDown) = YEAR(GETDATE())";
            LoadFilteredData(query);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM networkRegister";
            LoadFilteredData(query);
        }

        private void LoadFilteredData(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void txtDeviceName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
