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
    public partial class Form2 : Form
    {
        MySqlConnection DBConnect = new MySqlConnection("datasource = localhost; username=root; password=; database=blood");
        int i;
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            DBConnect.Open();
            MySqlCommand cmd = DBConnect.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select userid, pass from user where userid = '" + textBox1.Text + "' and pass ='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Invalid User Id or Password");
            }
            else
            {
                
                Form6 f1 = new Form6();
                this.Hide();
                f1.ShowDialog();

            }
            DBConnect.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
    
}
