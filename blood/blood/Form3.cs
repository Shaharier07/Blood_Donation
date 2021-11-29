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
    public partial class Form3 : Form
    {
        MySqlConnection DBConnect = new MySqlConnection("datasource = localhost; username=root; password=; database=blood");
        MySqlDataReader chk;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertquery = " INSERT INTO blood.user(username,userid,pass,b_group,phone,address) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
            string check = "SELECT * FROM blood.user where userid= '" + textBox2.Text + "'";
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Please fill the form.");
            }
            else
            {
                DBConnect.Open();

                MySqlCommand checkuser = new MySqlCommand(check, DBConnect);
                chk = checkuser.ExecuteReader();
                if (chk.Read())
                {
                    MessageBox.Show("User id taken");

                }

                else
                {
                    chk.Close();
                    MySqlCommand command = new MySqlCommand(insertquery, DBConnect);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        if (MessageBox.Show("Sign Up seccessfully", "Registration successful", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            Form2 f2 = new Form2();
                            this.Hide();
                            f2.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not Inserted");
                    }
                }
                DBConnect.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text == "example: na123")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "example: na123")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "example: na123";
                textBox2.ForeColor = Color.LightGray;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = true;
            }
            else
            {
                textBox3.UseSystemPasswordChar = false;
            }
        }
    }
}
