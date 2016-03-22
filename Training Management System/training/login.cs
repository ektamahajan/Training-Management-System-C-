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
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection();
        public login()
        {
            InitializeComponent();
        }
        string path, path0, path2;

        private void label1_MouseHover(object sender, EventArgs e)
        {

            colorchange();
            label1.BackColor = Color.DarkKhaki;
            panelhide();

            string path1 = listBox1.Items[0].ToString();
            richTextBox1.LoadFile(path0 + "\\" + path1, RichTextBoxStreamType.PlainText);
            label9.Text = richTextBox1.Text;
            label9.Visible = true;

        }



        private void Form2_Load(object sender, EventArgs e)
        {

            con.ConnectionString = "server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general";
            path = Application.StartupPath.ToString();
            path0 = path + "\\Main Page";
            DirectoryInfo dir = new DirectoryInfo(path0);
            FileInfo[] allfiles = dir.GetFiles();
            foreach (FileInfo myfile in allfiles)
            {
                listBox1.Items.Add(myfile.Name.ToString());

            }
            timetable();


        }






        private void label6_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label6.BackColor = Color.DarkKhaki;
            panelhide();
            panel7.Visible = true;
            
        }



        private void label5_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label5.BackColor = Color.DarkKhaki;
            tabControl1.Visible = false;
            panelhide();
            string path1 = listBox1.Items[4].ToString();
            richTextBox1.LoadFile(path0 + "\\" + path1, RichTextBoxStreamType.PlainText);
            label9.Text = richTextBox1.Text;
            label9.Visible = true;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label4.BackColor = Color.DarkKhaki;

            panelhide();
            path2 = Environment.CurrentDirectory.ToString() + "\\" + "Courses Intro";
            DirectoryInfo dir = new DirectoryInfo(path2);
            FileInfo[] allfiles = dir.GetFiles();
            foreach (FileInfo myfile in allfiles)
            {
                listBox2.Items.Add(myfile.Name.ToString());

            }
            string path3 = listBox2.Items[0].ToString();
            richTextBox1.LoadFile(path2 + "\\" + path3, RichTextBoxStreamType.PlainText);
            label8.Text = richTextBox1.Text;
            tabControl1.Visible = true;






        }
        public void colorchange()
        {
            label1.BackColor = Color.Khaki;
            label2.BackColor = Color.Khaki;
            label3.BackColor = Color.Khaki;
            label4.BackColor = Color.Khaki;
            label5.BackColor = Color.Khaki;
            label6.BackColor = Color.Khaki;
            label7.BackColor = Color.Khaki;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label3.BackColor = Color.DarkKhaki;
            tabControl1.Visible = false;
            string path1 = listBox1.Items[7].ToString();
            richTextBox1.LoadFile(path0 + "\\" + path1, RichTextBoxStreamType.PlainText);
            label9.Text = richTextBox1.Text;
            label9.Visible = true;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label2.BackColor = Color.DarkKhaki;
            panelhide();
            string path1 = listBox1.Items[1].ToString();
            richTextBox1.LoadFile(path0 + "\\" + path1, RichTextBoxStreamType.PlainText);
            label9.Text = richTextBox1.Text;
            label9.Visible = true;
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            colorchange();
            label7.BackColor = Color.DarkKhaki;
            panelhide();
           
            string path1 = listBox1.Items[5].ToString();
            richTextBox1.LoadFile(path0 + "\\" + path1, RichTextBoxStreamType.PlainText);
            label9.Text = richTextBox1.Text;
            label9.Visible = true;
        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            {
                richTextBox1.LoadFile(path2 + "\\" + listBox2.Items[0].ToString(), RichTextBoxStreamType.PlainText);
                label8.Text = richTextBox1.Text;

            }
            if (tabControl1.SelectedIndex == 1)
            {
                richTextBox1.LoadFile(path2 + "\\" + listBox2.Items[1].ToString(), RichTextBoxStreamType.PlainText);
                label13.Text = richTextBox1.Text;
            }
            if (tabControl1.SelectedIndex == 2)
            {
                richTextBox1.LoadFile(path2 + "\\" + listBox2.Items[2].ToString(), RichTextBoxStreamType.PlainText);
                label14.Text = richTextBox1.Text;
            }
            if (tabControl1.SelectedIndex == 3)
            {
                richTextBox1.LoadFile(path2 + "\\" + listBox2.Items[3].ToString(), RichTextBoxStreamType.PlainText);
                label15.Text = richTextBox1.Text;
            }
            if (tabControl1.SelectedIndex == 4)
            {
                richTextBox1.LoadFile(path2 + "\\" + listBox2.Items[4].ToString(), RichTextBoxStreamType.PlainText);
                label16.Text = richTextBox1.Text;
            }
        }

               
        private void button1_Click_1(object sender, EventArgs e)
        {
           try
           {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Password from login where User_Name='" + textBox1.Text + "' and Login_Type='" + comboBox1.Text + "'", con);
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();
            if ((rd.HasRows) == true)
            {
                rd.Read();
                if (rd[0].ToString() == textBox2.Text)
                {

                    if (comboBox1.Text == "Teacher")
                    {
                        Class1 c1 = new Class1();
                        c1.loginid = textBox1.Text; this.Hide();
                        this.Hide();
                        MDIParent1 obj = new MDIParent1();
                        obj.typpe = "T";
                        obj.Show();

                    }
                    if (comboBox1.Text == "Administrator")
                    {
                        Class1 c1 = new Class1();
                        c1.loginid = textBox1.Text;
                        this.Hide();

                        MDIParent1 obj = new MDIParent1();
                        obj.typpe = "A";
                        obj.Show();

                    }
                    if (comboBox1.Text == "Carrier Advisor")
                    {
                        Class1 c1 = new Class1();
                        c1.loginid = textBox1.Text;
                        this.Hide();

                        MDIParent1 obj = new MDIParent1();
                        obj.typpe = "CA";
                        obj.Show();


                    }
                    if (comboBox1.Text == "Student")
                    {
                        Class1 c1 = new Class1();
                        c1.loginid = textBox1.Text;
                        this.Hide();

                        MDIParent1 obj = new MDIParent1();
                        obj.typpe = "S";
                        obj.Show();

                    }
                    if (comboBox1.Text == "Director")
                    {
                        Class1 c1 = new Class1();
                        c1.loginid = textBox1.Text;
                        this.Hide();

                        MDIParent1 obj = new MDIParent1();
                        obj.typpe = "D";
                        obj.Show();

                    }
                }
                else
                {
                    MessageBox.Show("Password not matched");
                }

            }
            else
            {
                MessageBox.Show("Invalid User Name Or User Type");
            }
            con.Close();
            cmd.Dispose();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }

        }
        void timetable()
        {
            try
            {
            SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
            SqlCommand cmd1 = new SqlCommand();

            con1.Open();
            cmd1.Connection = con1;
            Class1 c1 = new Class1();
            SqlDataAdapter dr = new SqlDataAdapter("select batch_code,course, timing,te_code,te_name,batch_start,Batch_end from batch1", con1);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            dt.Rows.RemoveAt(0);
            con1.Close();
            cmd1.Dispose();
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        void panelhide()
        {
            label9.Visible = false;
            tabControl1.Visible = false;
            panel7.Visible = false;
            panel1.Visible = false;
        }

        private void label3_MouseHover_1(object sender, EventArgs e)
        {
            colorchange();
            label3.BackColor = Color.DarkKhaki;
            panelhide();
            panel1.Visible = true;
        }

    }
}