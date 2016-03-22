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
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            //label1.BackColor = Color.SteelBlue;
            panelhide();
           
        }

       

        private void label2_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label2.BackColor = Color.SteelBlue;
            panelhide();
            panel8.Visible = true;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label3.BackColor = Color.SteelBlue;
            panelhide();
            panel2.Visible = true;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label4.BackColor = Color.SteelBlue;
            panelhide();
            panel1.Visible = true;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label5.BackColor = Color.SteelBlue;
            panelhide();
            panel7.Visible = true;
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label6.BackColor = Color.SteelBlue;
            panelhide();
            panel5.Visible = true;
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label7.BackColor = Color.SteelBlue;
            panelhide();
            tabControl2.Visible = true;
        }

        

       
        public void panelhide()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl1.Visible = false;
            panel5.Visible = false;
          
            panel7.Visible = false;
            
            panel8.Visible = false;
        
        }

       

        
        public void colorchange()
        {
            
            label2.BackColor = Color.LightSteelBlue;
            label3.BackColor = Color.LightSteelBlue;
            label4.BackColor = Color.LightSteelBlue;
            label5.BackColor = Color.LightSteelBlue;
            label6.BackColor = Color.LightSteelBlue;
            label7.BackColor = Color.LightSteelBlue;
           
        
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            sugg();
            teacherp();
            panelhide();
           
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
          regstudent s1 = new regstudent();
            s1.Show();
            
        }

        private void label16_Click(object sender, EventArgs e)
        {
            regteacher regt = new regteacher();
            regt.Show();
        }

        private void label69_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            regdirector rgd = new regdirector();
            rgd.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            regcarrieraddr rgc = new regcarrieraddr();
            rgc.Show();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            course_time ct = new course_time();
            ct.Show();

        }

        private void label22_Click(object sender, EventArgs e)
        {
            newbatch nw = new newbatch();
            nw.Show();
        }

        public void teacherp()
        {
            try
            {
                SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
                SqlCommand cmd1 = new SqlCommand();
                con1.Open();
                cmd1.CommandText = "select teacheridno from tedata";
                cmd1.Connection = con1;
                SqlDataReader rd1 = cmd1.ExecuteReader();
                while (rd1.Read())
                {
                    listBox5.Items.Add(rd1[0].ToString());
                }
                con1.Close();
                cmd1.Dispose();
                rd1.Dispose();
                listBox5.Items.Remove(listBox5.Items[0].ToString());
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
                cmd.CommandText = "select * from tedata where teacheridno='" + listBox5.Text + "'";
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
        string path, path0, path1;

        public void sugg()
        {
            path = Application.StartupPath.ToString();
            path0 = path + "\\suggestion box";
            DirectoryInfo dir = new DirectoryInfo(path0);
            FileInfo[] allfiles = dir.GetFiles();
            foreach (FileInfo myfile in allfiles)
            {
                listBox4.Items.Add(myfile.Name.Substring(0, myfile.Name.Length - 4));
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            path1 = path0 + "\\" + listBox4.SelectedItem.ToString() + ".txt";
            richTextBox1.LoadFile(path1, RichTextBoxStreamType.PlainText);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            try
            {
                if (textBox3.Text.Length > 0)
                {

                   
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.CommandText = "select * from studata where studentidno='" + textBox3.Text + "'";
                    cmd.Connection = con;
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    label58.Text = rd[0].ToString();
                    label59.Text = rd[1].ToString();
                    label60.Text = rd[2].ToString();
                    label61.Text = rd[3].ToString();
                    label62.Text = rd[4].ToString();
                    label63.Text = rd[5].ToString();
                    label64.Text = rd[6].ToString();
                    label65.Text = rd[7].ToString();
                    label66.Text = rd[8].ToString();
                    label70.Text = rd[9].ToString();
                    label71.Text = rd[10].ToString();
                    label19.Text = rd[11].ToString();
                    label20.Text = rd[12].ToString();
                    label23.Text = rd[13].ToString();
                    label24.Text = rd[18].ToString();
                    label25.Text = rd[14].ToString();
                    label26.Text = rd[15].ToString();
                    label12.Text = rd[16].ToString();

                    pictureBox2.Image = Image.FromFile(rd[17].ToString());
                    con.Close();
                    cmd.Dispose();
                    rd.Dispose();
                    tabControl1.Visible = true;
                    panel2.Visible = false;
                    textBox3.Clear();
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
                listBox4.Items.Clear();
                richTextBox1.Clear();
                sugg();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public void groupinfo()
        {
           
                SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
                SqlCommand cmd1 = new SqlCommand();
                con1.Open();
                cmd1.CommandText = "select * from project where batch_code='" + label24.Text + "'";
                cmd1.Connection = con1;
                SqlDataReader rd1 = cmd1.ExecuteReader();
                rd1.Read();
                label36.Text = rd1[0].ToString();
                label35.Text = rd1[1].ToString();
                label34.Text = rd1[2].ToString();
                label33.Text = rd1[3].ToString();
                label32.Text = rd1[4].ToString();
                label31.Text = rd1[6].ToString();
                label30.Text = rd1[7].ToString();
                listBox1.Items.Add(rd1[5].ToString());

                con1.Close();
                cmd1.Dispose();
           
        }

        public void attendence()
        {
            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            SqlDataAdapter dr = new SqlDataAdapter("select * from attendence where stu_id='" +textBox3.Text+ "'", con);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();
            cmd.Dispose();
        }

        private void tabControl1_VisibleChanged(object sender, EventArgs e)
        {
            attendence();
        }
        
    }
}
