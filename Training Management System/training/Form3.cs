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
    public partial class Sub_Assign : Form
    {
        public Sub_Assign()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
        SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
            

      string upload,str;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op1 = new OpenFileDialog();

                op1.Filter = "All Files(*.all Files) |*.*";
                        
              if (op1.ShowDialog(this) == DialogResult.OK)
                {
                    str = op1.FileName;

                    string densti = Application.StartupPath.ToString();
                    upload = densti + "\\Assignment submit\\" + label333.Text + "-" + dateTimePicker1.Value.Day.ToString() + "-" + label444.Text + str.Substring(str.Length - 4);
                    MessageBox.Show(upload);
                    button2.Enabled = true;
                }


            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message.ToString());
            }
            
            
        }

        SqlCommand cmd = new SqlCommand();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.CommandText = "insert into stu_asgn(batch_code,stu_code,assg_no,sub_date,asgn_path) values(@batch_code,@stu_code,@assg_no,@sub_date,@asgn_path)";
                cmd.Parameters.AddWithValue("@batch_code", label555.Text);
                cmd.Parameters.AddWithValue("@stu_code", label333.Text);
                cmd.Parameters.AddWithValue("@assg_no", label444.Text);
                cmd.Parameters.AddWithValue("@sub_date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@asgn_path", upload);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                File.Copy(str, upload);
                con.Close();
                cmd.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }

           
        }

        public void filldata()
        {
            try
            {
            con.Close();
            con1.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            Class1 c1 = new Class1();

            cmd.CommandText = "select batch from studata where studentidno='" + c1.loginid + "'";

            cmd.Connection = con;
            
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            label555.Text = rd[0].ToString();
            label333.Text = c1.loginid;

            con.Close();
            rd.Dispose();
            cmd.Dispose();

            con1.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandText = "select max(assno) from tassign where batchcode='" + label555.Text + "'";
            SqlDataReader rd1 = cmd1.ExecuteReader();
            rd1.Read();

            label444.Text = rd1[0].ToString();
            con1.Close();
            rd1.Dispose();
            cmd1.Dispose();

            con1.Open();
            SqlCommand cmd11 = new SqlCommand();
            cmd11.CommandText = "select subdate from tassign where assno='" + label444.Text + "' and batchcode='" + label555.Text + "'";
            cmd11.Connection = con1;
            SqlDataReader rd11 = cmd11.ExecuteReader();
            rd11.Read();
            label666.Text = rd11[0].ToString();

            con1.Close();
            rd11.Dispose();
            cmd11.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
       
        public void check()
        {
            int i = DateTime.Compare(Convert.ToDateTime(label666.Text), Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()));
            
            if (i > -1)
            {
                button1.Enabled = true;
            }
            if (i == -1)
            {
                MessageBox.Show("You Can't Submit Assignment");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            filldata();
            check();
        }
    }
}
