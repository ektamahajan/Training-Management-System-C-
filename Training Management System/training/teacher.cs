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
    public partial class teacher : Form
    {
        public teacher()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
        SqlCommand cmd = new SqlCommand();

        public void infodisplay()
        {
            try
            {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            Class1 c1 = new Class1();
            cmd.CommandText = "select * from tedata where teacheridno='" + c1.loginid + "'";


            cmd.Connection = con;

            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();


            label84.Text = rd[0].ToString();
            label85.Text = rd[1].ToString();
            label86.Text = rd[2].ToString();
            label87.Text = rd[3].ToString();
            label88.Text = rd[4].ToString();
            label96.Text = rd[5].ToString();
            label89.Text = rd[6].ToString();
            label90.Text = rd[7].ToString();
            label91.Text = rd[8].ToString();
            label92.Text = rd[9].ToString();
            label93.Text = rd[10].ToString();
            label94.Text = rd[11].ToString();
            label95.Text = rd[12].ToString();
            label4.Text = rd[1].ToString();
            pictureBox1.BackgroundImage = Image.FromFile(rd[13].ToString());
            //label70.Text = rd[13].ToString();
            //label71.Text = rd[14].ToString();
            //label72.Text = rd[15].ToString();
            ////label73.Text = rd[16].ToString();



            con.Close();
            rd.Dispose();
            cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = Color.Goldenrod;
            panelhide();
            tabControl1.Visible = true;

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Tan;
        }

        public void com1()
        {
           try
           {
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.Clear();
            }
            if (comboBox4.Items.Count > 0)
            {
                comboBox4.Items.Clear();
            }
            con.Open();
            Class1 c1 = new Class1();
            cmd.CommandText = "select batchcode from tassign where te_code='" + c1.loginid + "'";
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd[0].ToString());
                comboBox4.Items.Add(rd[0].ToString());
            }


            con.Close();
            cmd.Dispose();
            rd.Dispose();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }


        private void label2_MouseHover(object sender, EventArgs e)
        {
           try
           {
            label2.BackColor = Color.Goldenrod;
            panelhide();
            label109.Text = "Teachers";
            con.Open();

            SqlDataAdapter dr = new SqlDataAdapter("select name, emailid from tedata", con);


            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

            panel1.Visible = true;
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = Color.Goldenrod;
            panelhide();
            panel2.Visible = true;
        }


        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.BackColor = Color.Goldenrod;
            panelhide();
            panel3.Visible = true;
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            try
            {
            label6.BackColor = Color.Goldenrod;
            panelhide();

            label109.Text = "Time Table";

            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
            SqlCommand cmd1 = new SqlCommand();

            con1.Open();
            cmd1.Connection = con1;
            Class1 c1 = new Class1();
            SqlDataAdapter dr = new SqlDataAdapter("select batch_code, course, timing from batch1 where te_code='" + c1.loginid + "'", con1);


            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;

            con1.Close();

            panel1.Visible = true;
            panel7.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.Tan;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.Tan;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.Tan;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.BackColor = Color.Tan;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.BackColor = Color.Tan;
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            label7.BackColor = Color.Goldenrod;
            panelhide();
            com1();

            tabControl3.Visible = true;
        }
        public void panelhide()
        {
            tabControl1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            tabControl3.Visible = false;
            splitContainer1.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
            tabControl3.Visible = true;

        }

        public void batch()
        {
            try
            {
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");


            Class1 c1 = new Class1();
            SqlCommand cmd1 = new SqlCommand();

            con1.Open();

            cmd1.CommandText = "select batch_code from batch1 where te_code='" + c1.loginid + "'";
            cmd1.Connection = con1;
            SqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                comboBox2.Items.Add(rd[0].ToString());
                comboBox1.Items.Add(rd[0].ToString());

            }
            con1.Close();
            cmd1.Dispose();
            rd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                infodisplay();
                batch();
                panelhide();
                

            }
            //    
            //    panelhide();
            //    //
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    Class1 c1 = new Class1();

            //    cmd.CommandText = "select * from tedata where teacheridno='" + c1.loginid + "'";

            //    cmd.Connection = con;
            //    SqlDataReader rd = cmd.ExecuteReader();
            //    rd.Read();

            //    label4.Text = rd[1].ToString();
            //    pictureBox1.BackgroundImage = Image.FromFile(rd[13].ToString());
            //    con.Close();
            //    rd.Dispose();
            //    cmd.Dispose();
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void label17_Click(object sender, EventArgs e)
        {
            project_allotment p1 = new project_allotment();
            p1.Show();
        }

        private void label98_MouseHover(object sender, EventArgs e)
        {
            label98.BackColor = Color.Goldenrod;
            panelhide();
            panel4.Visible = true;
        }

        private void label98_MouseLeave(object sender, EventArgs e)
        {
            label98.BackColor = Color.Tan;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
            if (textBox5.Text.Length > 0)
            {
                con.Open();
                Class1 c1 = new Class1();
                cmd.CommandText = "select password from login  where User_name='" + c1.loginid + "'";
                cmd.Connection = con;


                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();

                if (textBox5.Text == rd[0].ToString())
                {
                    if (textBox3.Text.Length > 0)
                    {
                        if (textBox3.Text == textBox4.Text)
                        {
                            con.Close();
                            con.Open();
                            cmd.CommandText = "update login set password= @password where User_name='" + c1.loginid + "'";
                            cmd.Parameters.Add("@password  ", SqlDbType.VarChar, 50).Value = textBox3.Text;
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show(" Password Updated");
                            textBox5.Clear();
                            textBox3.Clear();
                            textBox4.Clear();


                            con.Close();
                            cmd.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Confirm password not match");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Must Fill New Password");
                    }
                }

                else
                {
                    MessageBox.Show("Wrong Password");
                }
            }
            else
            {
                MessageBox.Show("Enter Current Password");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Form1 up = new Form1();
            up.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
           
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");


            Class1 c1 = new Class1();
            SqlCommand cmd1 = new SqlCommand();

            con1.Open();

            cmd1.CommandText = "select course,timing,notice from batch1 where te_code='" + c1.loginid + "'";
            cmd1.Connection = con1;
            SqlDataReader rd = cmd1.ExecuteReader();
            rd.Read();
            label107.Text = rd[0].ToString();
            label108.Text = rd[1].ToString();
            textBox6.Text = rd[2].ToString();

            con1.Close();
            cmd1.Dispose();
            rd.Close();
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
            SqlConnection com2 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");

            SqlCommand cmd2 = new SqlCommand();
            com2.Open();
            cmd2.CommandText = "update batch1 set notice='" + textBox6.Text + "' where batch_code='" + comboBox2.Text + "'";
            cmd2.Connection = com2;
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Updated");

            com2.Close();
            cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Attendence at = new Attendence();
            at.Show();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd1 = new SqlCommand();
            con1.Open();
            Class1 c1 = new Class1();
            SqlDataAdapter dr1 = new SqlDataAdapter("select studentidno, Name,Email_id,Contact_No from studata where Teacher_id='" + c1.loginid + "'and studentidno='" + textBox1.Text + "'", con1);


            DataTable dt1 = new DataTable();
            dr1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd1 = new SqlCommand();
            con1.Open();
            Class1 c1 = new Class1();
            SqlDataAdapter dr1 = new SqlDataAdapter("select studentidno,Name,Email_id,Contact_No from studata where Teacher_id='" + c1.loginid + "'and Name='" + textBox2.Text + "'", con1);


            DataTable dt1 = new DataTable();
            dr1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view_attendence va = new view_attendence();
            va.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            panel8.Visible = true;
            panel9.Visible = false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (comboBox3.Items.Count > 0)
                {
                    comboBox3.Items.Clear();
                }
                con.Open();
                cmd.CommandText = "select assno from tassign where batchcode='" + comboBox1.Text + "'";
                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox3.Items.Add(rd[0].ToString());
                }
                con.Close();
                rd.Dispose();
                cmd.Dispose();

                if (listBox2.Items.Count > 0)
                {
                    listBox2.Items.Clear();
                }
                con.Open();
                cmd.CommandText = "select assitopic from tassign where batchcode='" + comboBox1.Text + "'";
                cmd.Connection = con;
                SqlDataReader rd1 = cmd.ExecuteReader();
                while (rd1.Read())
                {
                    listBox2.Items.Add(rd1[0].ToString());
                }
                con.Close();
                rd1.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
           {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd1 = new SqlCommand();
            con1.Open();

            cmd1.CommandText = "select stu_code from stu_asgn where batch_code='" + comboBox1.Text + "' and assg_no='" + comboBox3.Text + "'";
            cmd1.Connection = con1;
            SqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                listBox1.Items.Add(rd[0].ToString());
            }
            label112.Text = listBox1.Items.Count.ToString();
            con1.Close();
            rd.Dispose();
            cmd1.Dispose();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel9.Visible = true;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            
            con.Open();
            string str = listBox2.SelectedItem.ToString();
            cmd.CommandText = "select assno,subdate,path from tassign where assitopic='" + str + "'";
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            label115.Text = rd[0].ToString();
            label116.Text = rd[1].ToString();
            assin = rd[2].ToString();

            con.Close();
            rd.Dispose();
            cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox2.Text = null;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void label168_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            label10.BackColor = Color.Goldenrod;
            panelhide();
            splitContainer1.Visible = true;
         

        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.BackColor = Color.Tan;
        }
        string assin;
        private void button1_Click_1(object sender, EventArgs e)
        {
           try
           {
            SaveFileDialog sav = new SaveFileDialog();

            sav.FileName = listBox2.SelectedItem.ToString();
            sav.Filter = "Text File|*.*";
            string name = sav.FileName;
            string abc = assin.Substring(assin.Length - 4);
            string name1 = name + abc;
            if (sav.ShowDialog(this) == DialogResult.OK)
            {
                File.Copy(assin, name1);
                MessageBox.Show("Save");
            }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            try
            {
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd1 = new SqlCommand();
            con1.Open();
            cmd1.CommandText = "select * from project where group_no='" + comboBox5.Text + "'";
            cmd1.Connection = con1;
            SqlDataReader rd1 = cmd1.ExecuteReader();
            rd1.Read();
          label152.Text=  rd1[0].ToString();
          label157.Text = rd1[1].ToString();
          label156.Text = rd1[2].ToString();
          label155.Text = rd1[3].ToString();
          label151.Text = rd1[4].ToString();
          label154.Text = rd1[6].ToString();
          label153.Text = rd1[7].ToString();
          listBox4.Items.Add(rd1[5].ToString());
       
            con1.Close();
            cmd1.Dispose();
            rd1.Dispose();
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
                comboBox5.Items.Clear();
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd1 = new SqlCommand();
            con1.Open();
            cmd1.CommandText = "select group_no from project where batch_code='" + comboBox4.Text + "'";
            cmd1.Connection = con1;
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
            {
                comboBox5.Items.Add(rd1[0].ToString());
            }
            con1.Close();
            cmd1.Dispose();
            rd1.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

         }
        string shaw;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
                SqlCommand cmd1 = new SqlCommand();
                con1.Open();
                cmd1.CommandText = "select asgn_path from stu_asgn where stu_code='" + listBox1.Text +"'";
                cmd1.Connection = con1;
                SqlDataReader rd1 = cmd1.ExecuteReader();
                rd1.Read();
                shaw = rd1[0].ToString();

                con1.Close();
                cmd1.Dispose();
                rd1.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sav = new SaveFileDialog();

                sav.FileName = listBox1.SelectedItem.ToString();
                sav.Filter = "Text File|*.*";
                string name; 
                name = sav.FileName;
                string abc = shaw.Substring(shaw.Length - 4);
                string name1 = name + abc;
                if (sav.ShowDialog(this) == DialogResult.OK)
                {
                    File.Copy(shaw, name1);
                    MessageBox.Show("Save");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

       
             
      
    }
}
