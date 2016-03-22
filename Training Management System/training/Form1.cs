using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace training
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
         string str;
         string assn;
         private void button1_Click(object sender, EventArgs e)
         {
             try
             {
                 OpenFileDialog op1 = new OpenFileDialog();

                 op1.Filter = "TXTfiles(* .txt Files) |*.txt";
                                             
                if (op1.ShowDialog(this) == DialogResult.OK)
                 {
                     str = op1.FileName;

                     string densti = Application.StartupPath.ToString();
                     assn = densti + "\\ASSIGNMENT\\" + comboBox1.Text + textBox2.Text + comboBox2.Text + str.Substring(str.Length - 4);
                   
                 }

             }
             catch (Exception ep)
             {
                 MessageBox.Show(ep.Message.ToString());
             }

         }

     

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            Class1 c1 = new Class1();
            
            SqlCommand cmd=new SqlCommand();
            con.Open();
            cmd.CommandText="insert into tassign(batchcode,te_code,assno,allocatedate,subdate,assitopic,path) values( @batchcode,@te_code,@assno,@allocatedate,@subdate,@assitopic,@path)";
            cmd.Parameters.AddWithValue("@batchcode",comboBox1.Text);
            cmd.Parameters.AddWithValue("@te_code", c1.loginid);
            cmd.Parameters.AddWithValue("@assno",comboBox2.Text);
            cmd.Parameters.AddWithValue("@allocatedate",dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@subdate",dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@assitopic",textBox2.Text);
            cmd.Parameters.AddWithValue("@path",assn);
            cmd.Connection=con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Save");
            File.Copy(str, assn);
            con.Close();
            cmd.Dispose();
            
            comboBox2.Items.Remove(comboBox2.SelectedItem.ToString());
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            dateTimePicker2.Text = dateTimePicker1.Value.AddDays(15).ToShortDateString();
        }


        SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
        
        private void Form1_Load(object sender, EventArgs e)
        {
           try
           {
            Class1 c1=new Class1();
            SqlCommand cmd1 = new SqlCommand();
            
            con1.Open();

            cmd1.CommandText = "select batch_code from batch1 where te_code='" + c1.loginid + "'";
            cmd1.Connection = con1;
            SqlDataReader rd=cmd1.ExecuteReader();
            while( rd.Read())
            {
            comboBox1.Items.Add(rd[0].ToString());
            }
            dateTimePicker2.Text = dateTimePicker1.Value.AddDays(15).ToShortDateString();
            con1.Close();
            cmd1.Dispose();
            rd.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }

            

        }
    }
}
