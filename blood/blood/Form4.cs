using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace blood
{
    public partial class Form4 : Form
    {
        MySqlConnection DBConnect = new MySqlConnection("datasource = localhost; username=root; password=; database=blood");
        MySqlCommand cmd;
        public Form4()
        {
            InitializeComponent();
            Fillcombo();
        }
        void Fillcombo()
        {
            comboBox1.Items.Clear();
            DBConnect.Open();
            cmd = DBConnect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Area FROM blood_bank";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Area"].ToString());
            }
            DBConnect.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection DBConnect = new MySqlConnection("datasource = localhost; username=root; password=; database=blood");
            string search =("SELECT username as Donor_Name, phone, address, Area FROM user NATURAL JOIN donation WHERE b_group = '" + textBox1.Text + "' and Area = '" + comboBox1.Text + "'");
            DBConnect.Open();
            MySqlCommand searchb = new MySqlCommand(search, DBConnect);
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchb);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            DBConnect.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }
    }
}
