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
    public partial class Form5 : Form
    {
        MySqlConnection DBConnect = new MySqlConnection("datasource = localhost; username=root; password=; database=blood");
        MySqlCommand cmd;
        public Form5()
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertquery = " INSERT INTO blood.donation(userid,B_D_Date,Area) VALUES('" + textBox4.Text + "', '" + dateTimePicker1.Text + "','" + comboBox1.Text + "')";
            if (textBox4.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please fill the form.");
            }
            else
            {
                DBConnect.Open();
                MySqlCommand command = new MySqlCommand(insertquery, DBConnect);
                if (command.ExecuteNonQuery() == 1)
                {


                    string updatequery = " UPDATE blood.user SET ld_donation = '" + dateTimePicker1.Text + "' where userid = '" + textBox4.Text + "'";
                    MySqlCommand commandd = new MySqlCommand(updatequery, DBConnect);
                    if (commandd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Yor are all set to donet.");

                    }
                    else
                    {
                        MessageBox.Show("Invalid");

                    }
                    DBConnect.Close();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            this.Hide();
            f1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
