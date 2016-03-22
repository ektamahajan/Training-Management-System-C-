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
    public partial class newbatch : Form
    {
        public newbatch()
        {
            InitializeComponent();
        }
        string rado;

        //public void radio()
        //{
        //    if (radioButton1.Checked == true)
        //    {
        //        rado = radioButton1.Text;
        //    }
        //    if (radioButton2.Checked == true)
        //    {
        //        rado = radioButton2.Text;
        //    }
        //}

        SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
        SqlCommand cmd1 = new SqlCommand();

        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
        SqlCommand cmd = new SqlCommand();

        SqlConnection con2 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
        SqlCommand cmd2 = new SqlCommand();

        public void cname()
        {
           try
           {
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.Clear();
                comboBox1.Text = null;
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Text = null;
            }
            if (comboBox4.Items.Count > 0)
            {
                comboBox4.Items.Clear();
                comboBox4.Text = null;
            }
            label8.Text = null;
            

            con1.Open();

            cmd1.CommandText = "select coursename from coursestart where duration='" + rado + "'";
            cmd1.Connection = con1;
            SqlDataReader rd1 = cmd1.ExecuteReader();

            while (rd1.Read())
            {
                comboBox1.Items.Add(rd1[0].ToString());
            }



            con1.Close();
            rd1.Dispose();
            cmd1.Dispose();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }
        private void newbatch_Load(object sender, EventArgs e)
        {
            //radio();
            bidno();
            try
            {
                
                con.Open();
                                
                cmd.CommandText = "select teacheridno from tedata";
                cmd.Connection = con;

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    comboBox3.Items.Add(rd[0].ToString());
                }
                comboBox3.Items.Remove(comboBox3.Items[0].ToString());

                con.Close();
                cmd.Dispose();
                rd.Dispose();
            }




            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //radio();
           try
           {

            close();

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Text = null;
            }
            if (comboBox4.Items.Count > 0)
            {
                comboBox4.Items.Clear();
                comboBox4.Text = null;
            }
            label8.Text = null;

            {
                con1.Open();

                cmd1.CommandText = "select start_date from coursestart where coursename='" + comboBox1.Text + "' and duration='" + rado + "'";
                cmd1.Connection = con1;
                SqlDataReader rd1 = cmd1.ExecuteReader();

                while (rd1.Read())
                {
                    comboBox2.Items.Add(rd1[0].ToString());
                }

                con1.Close();
                rd1.Dispose();
                cmd1.Dispose();
            }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            int i,j;
            if (numericUpDown1.Value < listBox1.Items.Count)
            {
                MessageBox.Show("Please Enter Currect Batch Size");
            }
            if (listBox1.Items.Count <= numericUpDown1.Value)
            {

                for (i = 0; i < numericUpDown1.Value; i++)
                {
                    listBox2.Items.Add(listBox1.Items[i].ToString());
                }
                for (j = Convert.ToInt32(numericUpDown1.Value - 1); j >= 0; j--)
                {
                    listBox1.Items.Remove(listBox1.Items[j].ToString());
                }
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    listBox1.Items.Add(listBox2.Items[i].ToString());
                }
                int j;
                for (j = listBox2.Items.Count - 1; j >= 0; j--)
                {
                    listBox2.Items.Remove(listBox2.Items[j].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Add(listBox1.SelectedItem.ToString());
                listBox1.Items.Remove(listBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add(listBox2.SelectedItem.ToString());
                listBox2.Items.Remove(listBox2.SelectedItem.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            close();
            rado = radioButton1.Text;
            cname();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //radio();
            try
            {
            close();
            if (comboBox4.Items.Count > 0)
            {
                comboBox4.Items.Clear();
                comboBox4.Text = null;
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }

            con1.Open();

            cmd1.CommandText = "select end_date,timing from coursestart where start_date='" + comboBox2.Text + "' and duration='" + rado + "' and coursename='" + comboBox1.Text + "'";
            cmd1.Connection = con1;
            SqlDataReader rd1 = cmd1.ExecuteReader();

            while (rd1.Read())
            {
                label8.Text = rd1[0].ToString();
                comboBox4.Items.Add(rd1[1].ToString());
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
          try
          {
            close();
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
            
            con2.Open();
            cmd2.CommandText = "select studentidno,altd from studata where coursename='" + comboBox1.Text + "'";
            cmd2.Connection = con2;
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                if (rd2[1].ToString() == "")
                {
                    listBox1.Items.Add(rd2[0].ToString());
                }
            }
            con2.Close();
            rd2.Dispose();
            cmd2.Dispose();
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message.ToString());
          }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            close();
            rado = radioButton2.Text;
            cname();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            con1.Open();
            cmd1.CommandText = "insert into batch1(batch_code, duration, course, batch_start, batch_end, timing, te_code,te_name, notice) values('" + textBox1.Text + "','" + rado + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + label8.Text + "','" + comboBox4.Text + "','" + comboBox3.Text + "','" +label12.Text + "','" + textBox2.Text + "')";

            cmd1.ExecuteNonQuery();
            con1.Close();
            cmd1.Dispose();

            con2.Open();
            cmd2.Connection = con2;

            for (int j = 0; j <= listBox2.Items.Count - 1; j++)
            {
                cmd2.CommandText = "update studata set Batch='" + textBox1.Text + "', Teacher_id='" + comboBox3.Text + "', altd='1' where studentidno='" + listBox2.Items[j].ToString() + "'";

                cmd2.ExecuteNonQuery();

            }
            MessageBox.Show("Batch Allotted");
            con2.Close();
            cmd2.Dispose();
            
            clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public void clear()
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;
            textBox1.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked=false;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
           {
            close();
            
            con1.Open();
            cmd1.Connection = con1;
            cmd1.CommandText = "select timing from batch1 where te_code='" + comboBox3.Text + "'";
            SqlDataReader rd1 = cmd1.ExecuteReader();
           
               while (rd1.Read())
               {
                   string time = rd1[0].ToString();
                   if (time == comboBox4.Text)
                   {
                       cmd1.CommandText = "select batch_end from batch1 where timing='" + rd1[0].ToString() + "' and te_code='" + comboBox3.Text + "'";
                       rd1.Dispose();

                       SqlDataReader rd22 = cmd1.ExecuteReader();
                       rd22.Read();
                       MessageBox.Show(rd22[0].ToString());
                       int i = DateTime.Compare(Convert.ToDateTime(rd22[0].ToString()), Convert.ToDateTime(comboBox2.Text));
                       rd22.Dispose();
                       if (i > -1)
                       {
                           MessageBox.Show("Teacher is already heaving class");
                           goto Z;
                       }
                       
                   }
               }
            Z:con1.Close();
            rd1.Dispose();
            cmd1.Dispose();

            con.Open();

            cmd.CommandText = "select name from tedata where teacheridno='" + comboBox3.Text + "'";
            cmd.Connection = con;

            SqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            label12.Text = rd[0].ToString();

            con.Close();
            cmd.Dispose();
            rd.Dispose();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }

        public void close()
        {
            con.Close();
            con1.Close();
            con2.Close();
        }

        static int bid;
        public void bidno()
        {
            try
            {
            SqlConnection con5 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
            SqlCommand cmd5 = new SqlCommand();

            con5.Open();
            cmd5.CommandText = "select max(batch_code) from batch1";
            cmd5.Connection = con5;
            SqlDataReader rd5 = cmd5.ExecuteReader();
            rd5.Read();
            string sid = rd5[0].ToString();
            bid = Convert.ToInt32(sid.Substring(6));
            bid++;

            con5.Close();
            rd5.Dispose();
            cmd5.Dispose();
            textBox1.Text = "spicbt" + bid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

       
    }
}
