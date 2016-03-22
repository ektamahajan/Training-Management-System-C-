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
    public partial class Download_Assign : Form
    {
        public Download_Assign()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
        SqlCommand cmd = new SqlCommand();

        SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
        SqlCommand cmd1 = new SqlCommand();

        SqlConnection con2 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
        SqlCommand cmd2 = new SqlCommand();

        private void Form2_Load(object sender, EventArgs e)
        {
            filldata();
        }

        


        public void filldata()
        {
            try
            {
            con2.Open();
            con1.Open();
            SqlCommand cmd2 = new SqlCommand();
            Class1 c1 = new Class1();
            cmd2.Connection = con2;

            cmd2.CommandText = "select batch from studata where studentidno='" + c1.loginid + "'";

            
            SqlDataReader rd = cmd2.ExecuteReader();
            rd.Read();
            label444.Text = rd[0].ToString();

            cmd1.CommandText = "select assno from tassign where batchcode='" + label444.Text + "'";
            cmd1.Connection = con1;
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
            {
                comboBox2.Items.Add(rd1[0].ToString());
            }

            con1.Close();
            con2.Close();
            rd.Dispose();
            rd1.Dispose();
            cmd2.Dispose();
            cmd1.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        
        
        string assin;
        
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sav = new SaveFileDialog();

                sav.FileName = label1.Text;
                sav.Filter = "Text File|*.*";
                //sav.ShowDialog();
                string name = sav.FileName;
                string abc = assin.Substring(assin.Length - 4);
                string name1 = name + abc;
                if (sav.ShowDialog(this) == DialogResult.OK)
                {
                    File.Copy(assin, name1);
                    MessageBox.Show("Save");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con1.Open();
                cmd1.CommandText = "select assno from tassign where batchcode='" + label444.Text + "'";
                cmd1.Connection = con1;

                SqlDataReader rd1 = cmd1.ExecuteReader();
                comboBox2.Items.Clear(); 
                while (rd1.Read())
                {

                    comboBox2.Items.Add(rd1[0].ToString());

                }
                rd1.Dispose();
                con1.Close();
                cmd1.Dispose();
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message.ToString());
            }
            finally
            {
                


                con1.Close();
                cmd1.Dispose();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con1.Open();
                cmd1.CommandText = "select assitopic,path,subdate from tassign where assno='" + comboBox2.Text + "' and batchcode='" + label444.Text + "'";

                cmd1.Connection = con1;
                SqlDataReader rd1 = cmd1.ExecuteReader();
                rd1.Read();
                label1.Text = rd1[0].ToString();
                label7.Text = rd1[2].ToString();
                assin = rd1[1].ToString();


                rd1.Dispose();
                cmd1.Dispose();
                con1.Close();
                
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message.ToString());
            }
            finally
            {
                con1.Close();
                cmd1.Dispose();
            }

        }
    }
}

