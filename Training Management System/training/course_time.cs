using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace training
{
    public partial class course_time : Form
    {

        public course_time()
        {
            InitializeComponent();
        }

        string rdo, combo;

        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
        SqlCommand cmd = new SqlCommand();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    con.Open();
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = false;
                    cmd.CommandText = "select * from spiccourse where duration='" + radioButton1.Text + "'";
                    cmd.Connection = con;
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        comboBox1.Items.Add(rd[1].ToString());
                    }
                    dateTimePicker2.Value = dateTimePicker1.Value.AddDays(183);

                    rdo = radioButton1.Text;

                    con.Close();
                    rd.Dispose();
                    cmd.Dispose();
                    comboBox2.Items.Clear();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            con.Close();
            try
            {
                if (radioButton2.Checked == true)
                {
                    con.Open();
                    comboBox2.Enabled = true;
                    comboBox1.Enabled = false;
                    cmd.CommandText = "select * from spiccourse where duration='" + radioButton2.Text + "'";
                    cmd.Connection = con;
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        comboBox2.Items.Add(rd[1].ToString());
                    }
                    dateTimePicker2.Value = dateTimePicker1.Value.AddDays(42);
                    rdo = radioButton2.Text;

                    con.Close();
                    rd.Dispose();
                    cmd.Dispose();
                    comboBox1.Items.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void new_batch_Load(object sender, EventArgs e)
        {

           
            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select name from tedata";
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();



            con.Close();
            rd.Dispose();
            cmd.Dispose();


        }
        SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
        SqlCommand cmd1 = new SqlCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            combip();

            string time = maskedTextBox1.Text + comboBox3.Text + " " + label4.Text + " " + maskedTextBox2.Text + comboBox4.Text;
            try
            {

                SqlCommand cmd2 = new SqlCommand();
                con1.Open();
                cmd2.Connection = con1;
                cmd2.CommandText = "insert into coursestart(coursename,timing,duration,start_date,end_date) values(@coursename,@timing,@duration,@start_date,@end_date)";

                cmd2.Parameters.AddWithValue("@coursename", combo);
                cmd2.Parameters.AddWithValue("@timing", time);
                cmd2.Parameters.AddWithValue("@duration", rdo);
                cmd2.Parameters.AddWithValue("@start_date", dateTimePicker1.Text);
                cmd2.Parameters.AddWithValue("@end_date", dateTimePicker2.Text);

                cmd2.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                con1.Close();
                cmd2.Dispose();
                this.Close();
            }
          catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        public void combip()
        {
            if (radioButton1.Checked == true)
            {
                combo = comboBox1.Text;
            }
            if (radioButton2.Checked == true)
            {
                combo = comboBox2.Text;
            }
        }
    }
}
