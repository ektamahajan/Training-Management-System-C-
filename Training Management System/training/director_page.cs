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
    public partial class director_page : Form
    {
        public director_page()
        {
            InitializeComponent();
        }

        string path, path0, path1, path2, path3;

        public void panelhide()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;



        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label9.BackColor = Color.MediumSeaGreen;
            panelhide();
            panel1.Visible = true;

        }
        public void colorchange()
        {
            label1.BackColor = Color.DarkSeaGreen;
            label2.BackColor = Color.DarkSeaGreen;
            label3.BackColor = Color.DarkSeaGreen;
            label4.BackColor = Color.DarkSeaGreen;
            label5.BackColor = Color.DarkSeaGreen;
            label6.BackColor = Color.DarkSeaGreen;
            label8.BackColor = Color.DarkSeaGreen;
            label9.BackColor = Color.DarkSeaGreen;
            label7.BackColor = Color.DarkSeaGreen;

        }

        public void sugg()
        {
            try
            {
                if (listBox4.Items.Count > 0)
                {
                    listBox4.Items.Clear();
                }
                path = Application.StartupPath.ToString();
                path0 = path + "\\suggestion box";
                DirectoryInfo dir = new DirectoryInfo(path0);
                FileInfo[] allfiles = dir.GetFiles();
                foreach (FileInfo myfile in allfiles)
                {
                    listBox4.Items.Add(myfile.Name.Substring(0, myfile.Name.Length - 4));
                }

                if (listBox1.Items.Count > 0)
                {
                    listBox1.Items.Clear();
                }

                path2 = path + "\\Notice";
                DirectoryInfo dir1 = new DirectoryInfo(path2);
                FileInfo[] allfiles1 = dir1.GetFiles();
                foreach (FileInfo myfile1 in allfiles1)
                {
                    listBox1.Items.Add(myfile1.Name.Substring(0, myfile1.Name.Length - 4));
                }

                richTextBox1.Text = null;
                richTextBox2.Text = null;
            }
              
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void director_page_Load(object sender, EventArgs e)
        {
            infodisplay();
            panelhide();
            sugg();

        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label2.BackColor = Color.MediumSeaGreen;
            teacherp();
            panelhide();
            panel3.Visible = true;
            tabControl3.Visible = true;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label3.BackColor = Color.MediumSeaGreen;
            panelhide();
            panel2.Visible = true;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label4.BackColor = Color.MediumSeaGreen;
            panelhide();
            batchinfo();
            panel3.Visible = true;
            panel5.Visible = true;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label5.BackColor = Color.MediumSeaGreen;
            panelhide();
            sugg();
            tabControl2.Visible = true;


        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label6.BackColor = Color.MediumSeaGreen;
            panelhide();
            tabControl1.Visible = true;


        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label69_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public void infodisplay()
        {
            try
            {
                SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
                SqlCommand cmd = new SqlCommand();

                con.Close();
                con.Open();

                Class1 c1 = new Class1();

                cmd.CommandText = "select * from dirdata where directoridno='" + c1.loginid + "'";

                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();


                label70.Text = rd[0].ToString();
                label45.Text = rd[1].ToString();
                label46.Text = rd[2].ToString();
                label47.Text = rd[3].ToString();
                label48.Text = rd[5].ToString();
                label49.Text = rd[6].ToString();
                label50.Text = rd[7].ToString();
                label57.Text = rd[8].ToString();
                label58.Text = rd[9].ToString();
                label59.Text = rd[10].ToString();
                label60.Text = rd[11].ToString();
                label61.Text = rd[12].ToString();

                label13.Text = rd[1].ToString();
                pictureBox2.Image = Image.FromFile(rd[13].ToString());
                pictureBox3.Image = Image.FromFile(rd[13].ToString());

                con.Close();
                rd.Dispose();
                cmd.Dispose();
            }
              
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void label96_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            course_time ct = new course_time();
            ct.Show();
        }


        public void teacherp()
        {
           try
           {

            if (listBox3.Items.Count > 0)
            {
                listBox3.Items.Clear();
            }
            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select teacheridno from tedata";
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                listBox3.Items.Add(rd[0].ToString());
            }
            con.Close();
            cmd.Dispose();
            rd.Dispose();
            listBox3.Items.Remove(listBox3.Items[0].ToString());
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }


        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from tedata where teacheridno='" + listBox3.SelectedItem.ToString() + "'";
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            label84.Text = rd[0].ToString();
            label85.Text = rd[1].ToString();
            label86.Text = rd[2].ToString();
            label87.Text = rd[3].ToString();
            label88.Text = rd[5].ToString();
            label89.Text = rd[6].ToString();
            label90.Text = rd[7].ToString();
            label91.Text = rd[8].ToString();
            label92.Text = rd[10].ToString();
            label93.Text = rd[9].ToString();
            label94.Text = rd[11].ToString();
            label95.Text = rd[12].ToString();
            pictureBox1.Image = Image.FromFile(rd[13].ToString());
            con.Close();
            cmd.Dispose();
            rd.Dispose();
            tabControl3.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label8.BackColor = Color.MediumSeaGreen;
            panelhide();
            panel4.Visible = true;
        }

        public void batchinfo()
        {
            try
            {
                if (listBox3.Items.Count > 0)
                {
                    listBox3.Items.Clear();
                }
                SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.CommandText = "select batch_code from batch1";
                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    listBox3.Items.Add(rd[0].ToString());
                }
                listBox3.Items.Remove(listBox3.Items[0].ToString());
                con.Close();
                cmd.Dispose();
                rd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
           {
            if (panel5.Visible == true)
            {
                SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.CommandText = "select * from batch1 where batch_code='" + listBox3.SelectedItem.ToString() + "'";
                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();

                label133.Text = rd[0].ToString();
                label134.Text = rd[1].ToString();
                label135.Text = rd[2].ToString();
                label136.Text = rd[3].ToString();
                label137.Text = rd[4].ToString();
                label138.Text = rd[5].ToString();
                label139.Text = rd[6].ToString();

                con.Close();
                cmd.Dispose();
                rd.Dispose();
              }
                   
         

            if (tabControl3.Visible == true)
            {
                SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.CommandText = "select * from tedata where teacheridno='" + listBox3.SelectedItem.ToString() + "'";
                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();

                label84.Text = rd[0].ToString();
                label85.Text = rd[1].ToString();
                label86.Text = rd[2].ToString();
                label87.Text = rd[3].ToString();
                label88.Text = rd[5].ToString();
                label89.Text = rd[6].ToString();
                label90.Text = rd[7].ToString();
                label91.Text = rd[8].ToString();
                label92.Text = rd[10].ToString();
                label93.Text = rd[9].ToString();
                label94.Text = rd[11].ToString();
                label95.Text = rd[12].ToString();
                pictureBox1.Image = Image.FromFile(rd[13].ToString());
                con.Close();
                cmd.Dispose();
                rd.Dispose();
                tabControl3.Visible = true;
            }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
                SqlCommand cmd = new SqlCommand();
                if (textBox2.Text.Length > 0)
                {
                    con.Open();
                    Class1 c1 = new Class1();
                    cmd.CommandText = "select password from login where User_name='" + c1.loginid + "'";
                    cmd.Connection = con;


                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();

                    if (textBox2.Text == rd[0].ToString())
                    {
                        if (textBox3.Text.Length > 0)
                        {
                            if (textBox3.Text == textBox1.Text)
                            {
                                con.Close();
                                con.Open();
                                cmd.CommandText = "update login set password= @password where User_name='" + c1.loginid + "'";
                                cmd.Parameters.Add("@password  ", SqlDbType.VarChar, 50).Value = textBox3.Text;
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show(" Password Updated");


                                con.Close();
                                cmd.Dispose();
                                textBox2.Clear();
                                textBox3.Clear();
                                textBox1.Clear();
                                panel6.Visible = false;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label7.BackColor = Color.MediumSeaGreen;
            panelhide();
            panel6.Visible = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           try
           {
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd1 = new SqlCommand();
            con1.Open();
            Class1 c1 = new Class1();
            SqlDataAdapter dr1 = new SqlDataAdapter("select studentidno,Name,Father_Name,DOB,Sex,University_No,Address,Email_id,Contact_No,Qualification,IT_back,College_Name,Course_Name,Time_Period,Timing,Start_Date,End_Date,Batch from studata where studentidno='" + textBox6.Text + "'", con1);


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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          try
          {
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd1 = new SqlCommand();
            con1.Open();
            Class1 c1 = new Class1();
            SqlDataAdapter dr1 = new SqlDataAdapter("select studentidno,Name,Father_Name,DOB,Sex,University_No,Address,Email_id,Contact_No,Qualification,IT_back,College_Name,Course_Name,Time_Period,Timing,Start_Date,End_Date,Batch from studata where name='" + textBox5.Text + "'", con1);


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

        private void button2_Click(object sender, EventArgs e)
        {
           if (textBox4.TextLength > 0)
            {
                string not = Application.StartupPath.ToString();
                string not2 = not + "\\Notice\\" + textBox4.Text + ".txt";


                richTextBox2.SaveFile(not2, RichTextBoxStreamType.PlainText);

                MessageBox.Show("save");
                textBox4.Text = null;
                richTextBox2.Text = null;
            }
            else
            {
                MessageBox.Show("Please enter notice title");
            }
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
           sugg();
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            path1 = path0 + "\\" + listBox4.SelectedItem.ToString() + ".txt";
            richTextBox1.LoadFile(path1, RichTextBoxStreamType.PlainText);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Visible = false;
            label12.Visible = false;
            label18.Visible = false;
            button2.Visible = false;
            button5.Visible = true;
            path3 = path2 + "\\" + listBox1.SelectedItem.ToString() + ".txt";
            richTextBox2.LoadFile(path3, RichTextBoxStreamType.PlainText);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Visible = true;
            label12.Visible = true;
            label18.Visible = true;
            button2.Visible = true;
            button5.Visible = false;

            richTextBox2.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string path22 = path2 + "\\" + listBox1.SelectedItem.ToString() + ".txt";
                DialogResult d = MessageBox.Show("Do you realy want to delete this Notice", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {
                    File.Delete(path22);
                }
                sugg();
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
                string path11 = path0 + "\\" + listBox4.SelectedItem.ToString() + ".txt";
                DialogResult d = MessageBox.Show("Do you realy want to delete this Suggestion", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {
                    File.Delete(path11);
                }
                sugg();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.SelectAll();
            textBox5.Text = null;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.SelectAll();
            textBox6.Text = null;
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.SelectAll();
            textBox6.Text = null;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.SelectAll();
            textBox5.Text = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {

            try
            {
                listBox8.Items.Clear();
               
                if (textBox9.Text.Length > 0)
                {
                    SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
                    SqlCommand cmd1 = new SqlCommand();
                    con1.Open();
                    cmd1.CommandText = "select * from project where group_no='" + textBox9.Text + "'";
                    cmd1.Connection = con1;
                    SqlDataReader rd1 = cmd1.ExecuteReader();
                    rd1.Read();
                    label38.Text = rd1[0].ToString();
                    label43.Text = rd1[1].ToString();
                    label42.Text = rd1[2].ToString();
                    label41.Text = rd1[3].ToString();
                    label37.Text = rd1[4].ToString();
                    label40.Text = rd1[6].ToString();
                    label39.Text = rd1[7].ToString();
                    listBox8.Items.Add(rd1[5].ToString());

                    con1.Close();
                    cmd1.Dispose();
                    rd1.Dispose();
                }
                else
                {
                    MessageBox.Show("Must Filled group Number");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        
    }
}
