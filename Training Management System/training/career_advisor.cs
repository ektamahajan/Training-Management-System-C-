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
    public partial class career_advisor : Form
    {
        string path2;
        public career_advisor()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            infodisplay();
            teacherp();
            panelhide();

        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = Color.MediumPurple;
            panelhide();
            panel1.Visible = true;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Thistle;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.BackColor = Color.MediumPurple;
            panelhide();
            panel2.Visible = true;
            tabControl4.Visible = true;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.Thistle;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = Color.MediumPurple;
            panelhide();
            panel4.Visible = true;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.Thistle;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.BackColor = Color.MediumPurple;
            panelhide();
            panel3.Visible = true;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.Thistle;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.BackColor = Color.MediumPurple;
            panelhide();

            path2 = Environment.CurrentDirectory.ToString() + "\\" + "Course Details";
            DirectoryInfo dir = new DirectoryInfo(path2);
            FileInfo[] allfiles = dir.GetFiles();
            foreach (FileInfo myfile in allfiles)
            {
                listBox2.Items.Add(myfile.Name.ToString());

            }
            string path3 = listBox2.Items[0].ToString();
            richTextBox1.LoadFile(path2 + "\\" + path3, RichTextBoxStreamType.PlainText);
            tabControl1.Visible = true;
            label15.Text = richTextBox1.Text;


        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.Thistle;
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label6.BackColor = Color.MediumPurple;
            panelhide();
            panel6.Visible = true;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.BackColor = Color.Thistle;
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            
            try
            {
                label7.BackColor = Color.MediumPurple;
                panelhide();
                panel8.Visible = true;
                SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
                SqlCommand cmd1 = new SqlCommand();

                con1.Open();
                cmd1.Connection = con1;
                Class1 c1 = new Class1();
                SqlDataAdapter dr = new SqlDataAdapter("select batch_code,course, timing,te_code,te_name,batch_start,Batch_end from batch1", con1);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                dataGridView3.DataSource = dt;
                dt.Rows.RemoveAt(0);
                con1.Close();
                cmd1.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.BackColor = Color.Thistle;


        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            label8.BackColor = Color.MediumPurple;
            panelhide();
            panel4.Visible = true;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = Color.Thistle;
        }

        public void panelhide()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            tabControl1.Visible = false;
            panel8.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            try
            {
                regstudent s1 = new regstudent();
                s1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void label16_Click(object sender, EventArgs e)
        {
            regteacher s2 = new regteacher();
            s2.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                richTextBox1.LoadFile(path2 + "\\" + listBox2.Items[0].ToString(), RichTextBoxStreamType.PlainText);
                label15.Text = richTextBox1.Text;

            }
            if (tabControl1.SelectedIndex == 1)
            {
                richTextBox1.LoadFile(path2 + "\\" + listBox2.Items[1].ToString(), RichTextBoxStreamType.PlainText);
                label17.Text = richTextBox1.Text;
            }
            if (tabControl1.SelectedIndex == 2)
            {
                richTextBox1.LoadFile(path2 + "\\" + listBox2.Items[2].ToString(), RichTextBoxStreamType.PlainText);
                label18.Text = richTextBox1.Text;
            }
            if (tabControl1.SelectedIndex == 3)
            {
                richTextBox1.LoadFile(path2 + "\\" + listBox2.Items[3].ToString(), RichTextBoxStreamType.PlainText);
                label19.Text = richTextBox1.Text;
            }
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

                cmd.CommandText = "select * from cadata where caidno='" + c1.loginid + "'";

                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();


                label22.Text = rd[0].ToString();
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

                label20.Text = rd[1].ToString();
                pictureBox2.Image = Image.FromFile(rd[13].ToString());
                pictureBox1.Image = Image.FromFile(rd[13].ToString());

                con.Close();
                rd.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void teacherp()
        {
            try
            {
                SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.CommandText = "select teacheridno from tedata";
                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    listBox1.Items.Add(rd[0].ToString());
                }
                con.Close();
                cmd.Dispose();
                rd.Dispose();
                listBox1.Items.Remove(listBox1.Items[0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.CommandText = "select * from tedata where teacheridno='" + listBox1.Text + "'";
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
                pictureBox3.Image = Image.FromFile(rd[13].ToString());
                con.Close();
                cmd.Dispose();
                rd.Dispose();
                tabControl4.Visible = true;
                // panel2.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            try
            {
                if (textBox6.Text.Length > 0)
                {


                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.CommandText = "select * from studata where studentidno='" + textBox6.Text + "'";
                    cmd.Connection = con;
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    label25.Text = rd[0].ToString();
                    label26.Text = rd[1].ToString();
                    label27.Text = rd[2].ToString();
                    label28.Text = rd[3].ToString();
                    label29.Text = rd[4].ToString();
                    label30.Text = rd[5].ToString();
                    label31.Text = rd[6].ToString();
                    label32.Text = rd[7].ToString();
                    label33.Text = rd[8].ToString();
                    label34.Text = rd[9].ToString();
                    label35.Text = rd[10].ToString();
                    label36.Text = rd[11].ToString();
                    label37.Text = rd[12].ToString();
                    label38.Text = rd[13].ToString();
                    label39.Text = rd[18].ToString();
                    label70.Text = rd[14].ToString();
                    label71.Text = rd[15].ToString();
                    label120.Text = rd[16].ToString();


                    pictureBox4.Image = Image.FromFile(rd[17].ToString());
                    con.Close();
                    cmd.Dispose();
                    rd.Dispose();
                    tabControl3.Visible = true;
                    panel4.Visible = false;
                    textBox6.Clear();



                }
                else
                {
                    MessageBox.Show("Must fill information");
                }
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

        private void label121_Click(object sender, EventArgs e)
        {
            newbatch nw = new newbatch();
            nw.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            course_time ct = new course_time();
            ct.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
                SqlCommand cmd = new SqlCommand();
                if (textBox2.Text.Length > 0)
                {
                    con.Open();
                    Class1 c1 = new Class1();
                    cmd.CommandText = "select Password from login where User_Name='" + c1.loginid + "'";
                    cmd.Connection = con;


                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();

                    if (textBox2.Text == rd[0].ToString())
                    {
                        if (textBox3.Text.Length > 0)
                        {
                            if (textBox3.Text == textBox4.Text)
                            {
                                con.Close();
                                con.Open();
                                cmd.CommandText = "update login set Password= @Password where User_Name='" + c1.loginid + "'";
                                cmd.Parameters.Add("@Password  ", SqlDbType.VarChar, 50).Value = textBox3.Text;
                                cmd.Connection = con;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show(" Password Updated");


                                con.Close();
                                cmd.Dispose();
                                panel7.Visible = false;
                                textBox2.Clear();
                                textBox3.Clear();
                                textBox4.Clear();
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

        private void label125_MouseHover(object sender, EventArgs e)
        {
            label125.BackColor = Color.MediumPurple;
            panelhide();
            panel7.Visible = true;
        }

        private void label125_MouseLeave(object sender, EventArgs e)
        {
            label125.BackColor = Color.Thistle;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panelhide();
            tabControl3.Visible = true;
            studentinfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelhide();
            panel4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelhide();
            panel4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelhide();
            panel4.Visible = true;
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
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
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

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox5.Text = null;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox6.Text = null;
            button1.Enabled = false;
        }

        public void attendence()
        {
            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            SqlDataAdapter dr = new SqlDataAdapter("select * from attendence where stu_id='" + label25.Text + "'", con);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            cmd.Dispose();
        }

        public void groupinfo()
        {
            try
            {

                SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
                SqlCommand cmd1 = new SqlCommand();
                con1.Open();
                cmd1.CommandText = "select * from project where batch_code='" + label39.Text + "'";
                cmd1.Connection = con1;
                SqlDataReader rd1 = cmd1.ExecuteReader();
                rd1.Read();
                label111.Text = rd1[0].ToString();
                label110.Text = rd1[1].ToString();
                label109.Text = rd1[2].ToString();
                label108.Text = rd1[3].ToString();
                label107.Text = rd1[4].ToString();
                label106.Text = rd1[6].ToString();
                label107.Text = rd1[7].ToString();
                listBox3.Items.Add(rd1[5].ToString());

                con1.Close();
                cmd1.Dispose();
                rd1.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    public void studentinfo()
        {
            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            try
            {
                if (textBox6.Text.Length > 0)
                {


                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.CommandText = "select * from studata where studentidno='" + textBox6.Text + "'";
                    cmd.Connection = con;
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    label25.Text = rd[0].ToString();
                    label26.Text = rd[1].ToString();
                    label27.Text = rd[2].ToString();
                    label28.Text = rd[3].ToString();
                    label29.Text = rd[4].ToString();
                    label30.Text = rd[5].ToString();
                    label31.Text = rd[6].ToString();
                    label32.Text = rd[7].ToString();
                    label33.Text = rd[8].ToString();
                    label34.Text = rd[9].ToString();
                    label35.Text = rd[10].ToString();
                    label36.Text = rd[11].ToString();
                    label37.Text = rd[12].ToString();
                    label38.Text = rd[13].ToString();
                    label39.Text = rd[18].ToString();
                    label70.Text = rd[14].ToString();
                    label17.Text = rd[15].ToString();
                    label120.Text = rd[16].ToString();

                    pictureBox4.Image = Image.FromFile(rd[17].ToString());
                    con.Close();
                    cmd.Dispose();
                    rd.Dispose();
                    groupinfo();
                    attendence();



                }
                else
                {
                    MessageBox.Show("Must fill information");
                }
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

    }
}
