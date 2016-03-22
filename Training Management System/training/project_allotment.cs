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
    public partial class project_allotment : Form
    {
        public project_allotment()
        {
            InitializeComponent();
            
        }
        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
        SqlCommand cmd = new SqlCommand();



        private void button1_Click(object sender, EventArgs e)
        {

            listBox2.Items.Add(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem.ToString());

        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.SelectedItem.ToString());
            listBox2.Items.Remove(listBox2.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
           try
           {
            con.Open();
            cmd.Connection = con;

            for (int i = 0; i < listBox2.Items.Count;i++)
            {


                cmd.CommandText = "insert into project(group_no,project_name ,allotment_date ,submission_date,batch_code,team_members ,mentor ,detail) values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','"+comboBox2.Text+"','" + listBox2.Items[i].ToString() + "','" + comboBox1.Text + "','" + textBox4.Text + "')";
                cmd.ExecuteNonQuery();
             }
            MessageBox.Show("Saved");
           

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            cmd.Dispose();
            con.Close();
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
              if(textBox1.Text.Length>0)
                {

            SqlCommand cmd1 = new SqlCommand();
            con.Open();
            cmd.CommandText = "update project set Group_Name=@Group_Name,Project_Name=@Project_Name,Allotment_Date=@Allotment_Date,Submission_Date=@Submission_Date,batch_code=@batch_code,Team_Members =@Team_Members ,Mentor =@Mentor ,Detail=@Detail where Group_Name=@Group_Name";
            cmd.Parameters.Add("@Group_Name     ", SqlDbType.VarChar, 50).Value = textBox1.Text;
            cmd.Parameters.Add("@Project_Name   ", SqlDbType.VarChar, 50).Value = textBox2.Text;
            cmd.Parameters.Add("@Allotment_Date ", SqlDbType.VarChar, 50).Value = dateTimePicker1.Text;
            cmd.Parameters.Add("@Submission_Date", SqlDbType.VarChar, 50).Value = dateTimePicker2.Text;
            cmd.Parameters.Add("@batch_code     ", SqlDbType.VarChar, 50).Value = comboBox2.Text;
            cmd.Parameters.Add("@Team_Members   ", SqlDbType.VarChar, 150).Value = listBox2.Text;
            cmd.Parameters.Add("@Mentor         ", SqlDbType.VarChar, 50).Value = comboBox1.Text;
            cmd.Parameters.Add("@Detail         ", SqlDbType.VarChar, 150).Value = textBox4.Text;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated");
            
            con.Close();
            cmd.Dispose();
            button1.Enabled = true;
                }
              else
              {
                  MessageBox.Show("Group_Name must be filled", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Text = null;
            listBox2.Text = null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            con.Open();
          

            cmd.CommandText = "select studentidno from studata where batch='"+comboBox2.Text+"'";
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();


            foreach (var stu_code in rd)
            {
                listBox1.Items.Add(rd[0].ToString());
            }
            //while (rd.Read())
            //{
            //    listBox1.Items.Add(rd[0].ToString());
            //}

            //listBox1.Items.Remove(listBox1.Items[0].ToString());
            con.Close();
            cmd.Dispose();
            rd.Dispose();
            
          }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        static int id;
        string gno;
        private void project_allotment_Load(object sender, EventArgs e)
        {
            try
            {
            
            groupno();

            SqlConnection con2 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
            Class1 c1 = new Class1();
            SqlCommand cmd2 = new SqlCommand();

            con2.Open();

            cmd2.CommandText = "select batch_code from batch1 where te_code='" + c1.loginid + "'";
            cmd2.Connection = con2;
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                comboBox2.Items.Add(rd2[0].ToString());

            }
            con2.Close();
            cmd2.Dispose();
            rd2.Close();

            SqlConnection con3 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
            
            SqlCommand cmd3 = new SqlCommand();

            con3.Open();

            cmd3.CommandText = "select name from tedata";
            cmd3.Connection = con3;
            SqlDataReader rd3 = cmd3.ExecuteReader();
            while (rd3.Read())
            {
                comboBox1.Items.Add(rd3[0].ToString());

            }
            comboBox1.Items.Remove(comboBox1.Items[0].ToString());
            con3.Close();
            cmd3.Dispose();
            rd3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        
        }


        public void groupno()
        {
            try
            {
            SqlConnection con5 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd5 = new SqlCommand();

            con5.Open();
            cmd5.CommandText = "select max(group_no) from project";
            cmd5.Connection = con5;
            SqlDataReader rd5 = cmd5.ExecuteReader();
            rd5.Read();

            gno = rd5[0].ToString();
            id = Convert.ToInt32(gno.Substring(5));
            id++;
            textBox1.Text = "group" + id;
            con5.Close();
            rd5.Dispose();
            cmd5.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

        }
    }
}
