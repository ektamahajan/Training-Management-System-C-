using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace training
{
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
        SqlCommand cmd = new SqlCommand();

        SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
        SqlCommand cmd1 = new SqlCommand();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            con1.Open();
            Class1 c1 = new Class1();
            cmd1.CommandText = "select batch_code from batch1 where te_code='" + c1.loginid + "'";
            cmd1.Connection = con1;
            SqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd[0].ToString());
            }
            con1.Close();
            cmd1.Dispose();
            
        }
        static int i=0,j=0;
        string[] date = new string[50];
        string[] batchcode = new string[50];
        string[] stuid = new string[50];
        string[]  attendence= new string[50];

        int x;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                radio();
                if (j == 0)
                {
                    con1.Open();
                    cmd1.CommandText = "create table #attnd(date varchar(20),batch_code varchar(20),name varchar(50),att varchar(50))";
                    cmd1.Connection = con1;
                    cmd1.ExecuteNonQuery();
                    j++;
                }

                if (i < listBox1.Items.Count)
                {
                           
                    label1.Text = listBox1.Items[i].ToString();
                    cmd1.CommandText = "insert into #attnd(date,batch_code,name,att)values('" + dateTimePicker1.Text + "','" + comboBox1.Text + "','" + label1.Text + "','" + rdo + "')";
                    date[i] = dateTimePicker1.Text;
                    batchcode[i] = comboBox1.Text;
                    stuid[i] = label1.Text;
                    attendence[i] = rdo;

                    
                    i++;


                    cmd1.Connection = con1;
                    cmd1.ExecuteNonQuery();
                    SqlDataAdapter dr = new SqlDataAdapter("select * from #attnd", con1);
                    DataTable dt = new DataTable();
                    dr.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                else
                {
                    con1.Close();
                    cmd1.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        string rdo;
        public void radio()
        {
            if (radioButton1.Checked == true)
            {
                rdo = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                rdo = radioButton2.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
            
        {
            //con1.Open();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select studentidno from studata";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {

                    listBox1.Items.Add(rd[0].ToString());

                }
                listBox1.Items.Remove(listBox1.Items[0].ToString());
                label1.Text = listBox1.Items[0].ToString();

                con.Close();
                cmd.Dispose();
                rd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            j = 0;
            i = 0;
            con1.Close();
            cmd1.Dispose();
            this.Close();
            Attendence at = new Attendence();
            at.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                for (x = 0; x < i; x++)
                {
                    cmd.CommandText = "insert into attendence(date,batch_code,stu_id,attendence) values('" + date[x] + "','" + batchcode[x] + "','" + stuid[x] + "','" + attendence[x] + "')";

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Saved");

                con.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        

    }
}
