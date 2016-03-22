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
    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
        SqlCommand cmd = new SqlCommand();

        string path, path0, path1;

        public void noticeboard()
        {
            try
            {
            listBox3.Visible = false;
            richTextBox1.Visible = false;
            path = Application.StartupPath.ToString();
            path0 = path + "\\Notice";
            DirectoryInfo dir = new DirectoryInfo(path0);
            FileInfo[] allfiles = dir.GetFiles();
            foreach (FileInfo myfile in allfiles)
            {
                listBox4.Items.Add(myfile.Name.Substring(0, myfile.Name.Length - 4));
            }

            con.Open();
            cmd.Connection = con;
            Class1 c11 = new Class1();
            cmd.CommandText = "select batch from studata where studentidno='" + c11.loginid + "'";
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            SqlConnection con11 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
            SqlCommand cmd11 = new SqlCommand();

            con11.Open();

            cmd11.CommandText = "select notice from batch1 where batch_code='" + rd[0].ToString() + "'";
            cmd11.Connection = con11;
            SqlDataReader rd11 = cmd11.ExecuteReader();
            rd11.Read();

            lable101.Text = rd11[0].ToString();


            con11.Close();
            cmd11.Dispose();
            rd11.Dispose();
            con.Close();
            cmd.Dispose();
            rd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }


        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                panelhide();
                con.Open();
                Class1 c1 = new Class1();
                SqlDataAdapter dr = new SqlDataAdapter("select * from attendence where stu_id='" + c1.loginid + "'", con);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                dataGridView4.DataSource = dt;

                infodisplay();
                noticeboard();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }



        public void infodisplay()
        {
            try
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                Class1 c1 = new Class1();

                cmd.CommandText = "select * from studata where studentidno='" + c1.loginid + "'";

                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();


                label58.Text = rd[1].ToString();
                label59.Text = rd[2].ToString();
                label60.Text = rd[3].ToString();
                label61.Text = rd[4].ToString();
                label62.Text = rd[5].ToString();
                label63.Text = rd[6].ToString();
                label89.Text = rd[7].ToString();
                label64.Text = rd[8].ToString();
                label65.Text = rd[9].ToString();
                label66.Text = rd[10].ToString();
                label67.Text = rd[11].ToString();
                label68.Text = rd[12].ToString();
                label69.Text = rd[13].ToString();
                label70.Text = rd[14].ToString();
                label71.Text = rd[15].ToString();
                label72.Text = rd[16].ToString();
                label73.Text = rd[17].ToString();
                label95.Text = rd[19].ToString();



                label4.Text = rd[2].ToString();
                pictureBox1.BackgroundImage = Image.FromFile(rd[18].ToString());

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
            
                colorchange();
                label1.BackColor = Color.DeepSkyBlue;
                panelhide();

                tabControl1.Visible = true;
                infodisplay();

                groupinfo();
                project_display();
            
        }


        private void label2_MouseHover(object sender, EventArgs e)
        {
            try
            {
                colorchange();
                label2.BackColor = Color.DeepSkyBlue;
                panelhide();

                if (listBox2.Items.Count > 0)
                {
                    listBox2.Items.Clear();
                }

                con.Close();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select studentidno from studata where batch='" + label95.Text + "'";
                SqlDataReader rd3 = cmd.ExecuteReader();

                while (rd3.Read())
                {
                    listBox2.Items.Add(rd3[0].ToString());
                }

                con.Close();
                rd3.Dispose();
                cmd.Dispose();




                panel1.Visible = true;
                panel5.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }





        private void label3_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label3.BackColor = Color.DeepSkyBlue;
            panelhide();
            splitContainer1.Visible = true;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label5.BackColor = Color.DeepSkyBlue;
            panelhide();
            tabControl2.Visible = true;
        }



        private void label6_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label6.BackColor = Color.DeepSkyBlue;
            panelhide();
            tabControl3.Visible = true;

        }


        private void label7_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label7.BackColor = Color.DeepSkyBlue;
            panelhide();
            panel4.Visible = true;
        }



        public void colorchange()
        {
            label1.BackColor = Color.LightBlue;
            label2.BackColor = Color.LightBlue;
            label3.BackColor = Color.LightBlue;
            label5.BackColor = Color.LightBlue;
            label6.BackColor = Color.LightBlue;
            label7.BackColor = Color.LightBlue;


        }

        public void panelhide()
        {
            
            panel1.Visible = false;
            splitContainer1.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            tabControl1.Visible = false;
            tabControl2.Visible = false;

            tabControl3.Visible = false;

        }
        public void project_display()
        {
            panel6.Visible = true;


        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
                if (textBox1.Text.Length > 0)
                {
                    con.Open();
                    Class1 c1 = new Class1();
                    cmd.CommandText = "select password from login where User_name='" + c1.loginid + "'";
                    cmd.Connection = con;


                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();

                    if (textBox1.Text == rd[0].ToString())
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
                                textBox1.Clear();
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
            Download_Assign fm2 = new Download_Assign();
            fm2.Show();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                path1 = path0 + "\\" + listBox4.SelectedItem.ToString();
                SaveFileDialog sav = new SaveFileDialog();


                sav.Filter = "Text File|*.txt";
                //sav.ShowDialog();

                path1 = path1 + ".txt";

                if (sav.ShowDialog(this) == DialogResult.OK)
                {
                    string name = sav.FileName;
                    string name1 = name;
                    File.Copy(path1, name1);
                    MessageBox.Show("Save");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Sub_Assign f3 = new Sub_Assign();
            f3.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lable101.Left > -610)
            {
                lable101.Left = lable101.Left - 2;

            }
            else
            {
                lable101.Left = 668;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                cmd.CommandText = "select Name, Pic_Path from studata where studentidno='" + listBox2.SelectedItem.ToString() + "'";
                SqlDataReader rd2 = cmd.ExecuteReader();
                rd2.Read();
                label93.Text = rd2[0].ToString();
                pictureBox2.BackgroundImage = Image.FromFile(rd2[1].ToString());

                con.Close();
                cmd.Dispose();
                panel5.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void label38_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Class1 c1 = new Class1();
                richTextBox3.Text = richTextBox3.Text + "  (" + c1.loginid + "-" + dateTimePicker1.Value.Day + ")";

                string sug = Application.StartupPath.ToString();
                string sug2 = sug + "\\suggestion box\\" + textBox2.Text + ".txt";


                richTextBox3.SaveFile(sug2, RichTextBoxStreamType.PlainText);

                MessageBox.Show("save");
                richTextBox3.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            textBox2.Clear();
        }

        public void groupinfo()
        {
            try
            {

                SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
                SqlCommand cmd1 = new SqlCommand();
                con1.Open();
                cmd1.CommandText = "select * from project where batch_code='" + label95.Text + "'";
                cmd1.Connection = con1;
                SqlDataReader rd1 = cmd1.ExecuteReader();
                rd1.Read();
                label82.Text = rd1[0].ToString();
                label83.Text = rd1[1].ToString();
                label84.Text = rd1[2].ToString();
                label85.Text = rd1[3].ToString();
                label86.Text = rd1[4].ToString();
                label87.Text = rd1[6].ToString();
                label88.Text = rd1[7].ToString();
                listBox1.Items.Add(rd1[5].ToString());

                con1.Close();
                cmd1.Dispose();
                rd1.Dispose();
            }
            catch
            {
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            path1 = path0 + "\\" + listBox4.SelectedItem.ToString() + ".txt";
            richTextBox2.LoadFile(path1, RichTextBoxStreamType.PlainText);
        }

        

    }
}