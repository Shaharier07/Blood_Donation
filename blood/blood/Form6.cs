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

    public partial class Form6 : Form
    {
        MySqlConnection DBConnect = new MySqlConnection("datasource = localhost; username=root; password=; database=blood");
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f1 = new Form5();
            this.Hide();
            f1.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string search = ("SELECT userid as UserId,Area,B_D_Date as Date_of_Donation FROM donation WHERE userid = '" + textBox1.Text + "'");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            this.Hide();
            f1.ShowDialog();
        }
    }
}
