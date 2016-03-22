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
    public partial class view_attendence : Form
    {
        public view_attendence()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
        SqlCommand cmd = new SqlCommand();

        SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
        SqlCommand cmd1 = new SqlCommand();

        private void view_attendence_Load(object sender, EventArgs e)
        {
            con.Open();
            Class1 c1 = new Class1();
            cmd.CommandText = "select batch_code from batch1 where te_code='" + c1.loginid + "'";
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd[0].ToString());
            }
            con.Close();
            rd.Dispose();
            cmd.Dispose();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            
            con1.Open();
            SqlDataAdapter dr1 = new SqlDataAdapter("select * from attendence where batch_code='" + comboBox1.SelectedItem.ToString() + "'", con1);

            DataTable dt1 = new DataTable();
            dr1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           try
           {
            con1.Open();
            SqlDataAdapter dr1 = new SqlDataAdapter("select * from attendence where batch_code='" + comboBox1.SelectedItem.ToString() + "' and date='" + dateTimePicker1.Text + "'", con1);

            DataTable dt1 = new DataTable();
            dr1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            con1.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
            con1.Open();
            SqlDataAdapter dr1 = new SqlDataAdapter("select * from attendence where stu_id='" + textBox1.Text + "'", con1);

            DataTable dt1 = new DataTable();
            dr1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

