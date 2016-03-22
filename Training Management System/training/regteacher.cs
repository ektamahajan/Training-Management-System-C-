using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace training
{
   
    public partial class regteacher : Form
    {
        string radio;
        public regteacher()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
        SqlCommand cmd = new SqlCommand();
        SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
        SqlCommand cmd1 = new SqlCommand();
        
        string str,tpic;

        private void label19_Click(object sender, EventArgs e)
        {
            try
            {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.InitialDirectory = "c:\\";
            op1.Filter = "JPEG(*.jpg)|*.jpg| Allfiles(*.all files ) |*.*";
            if (op1.ShowDialog(this) == DialogResult.OK)
            {
                str = op1.FileName;
                string target = Application.StartupPath.ToString();
                tpic = target + "\\snap\\" + textBox1.Text + str.Substring(str.Length - 4);

                pictureBox1.Image = Image.FromFile(str);
                label19.Visible = false;

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox1.Image = null;
            label19.Visible = true;
           
        }

        public void filldata()
        {
            
            comboBox1.Items.Clear();
            cmd.CommandText = "select teacheridno from tedata";
            cmd.Connection = con;
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd[0].ToString());
            }
            rd.Close();
            cmd.Dispose();
            con.Close();
            comboBox1.Items.Remove(comboBox1.Items[0].ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tidno();
            filldata();
            label12.Visible = false;
        }

        void rdiob()
        {
            if (radioButton1.Checked == true)
            {
                radio = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                radio = radioButton2.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

                try
                {
                    rdiob();
                    con.Open();
                    cmd.CommandText = "insert into tedata(teacheridno,name,fname,dob,sex,address,contactno,emailid,qualification,itback,specialinwhich,exprienaceduration,joiningdate,picpath) values(@teacheridno,@name,@fname,@dob,@sex,@address,@contactno,@emailid,@qualification,@itback,@specialinwhich,@exprienaceduration,@joiningdate,@picpath)";
                    input();

                    cmd.Connection = con;

                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted");
            
                    File.Copy(str, tpic);
                    con.Close();
                    cmd.Dispose();
                    filldata();
                    account();
                    clear();
                    tidno();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
          
        }

        public void input()
        {
            cmd.Parameters.AddWithValue("@teacheridno", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@fname", textBox3.Text);
            cmd.Parameters.AddWithValue("@dob", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@sex", radio);
            cmd.Parameters.AddWithValue("@address", textBox6.Text);
            cmd.Parameters.AddWithValue("@contactno", textBox7.Text);
            cmd.Parameters.AddWithValue("@emailid", textBox8.Text);
            cmd.Parameters.AddWithValue("@qualification", textBox9.Text);
            cmd.Parameters.AddWithValue("@itback", textBox10.Text);
            cmd.Parameters.AddWithValue("@specialinwhich", textBox11.Text);
            cmd.Parameters.AddWithValue("@exprienaceduration", textBox12.Text);
            cmd.Parameters.AddWithValue("@joiningdate", dateTimePicker2.Text);
            //cmd.Parameters.AddWithValue("@resumeupload", textBox14.Text);
            cmd.Parameters.AddWithValue("@picpath", tpic);
            
        }

        private void account()
        {
            SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into login(Login_Type,User_Name,Password)values(@Login_Type,@User_Name,@Password)";
                cmd.Parameters.Add("@Login_Type          ", SqlDbType.VarChar, 50).Value = "Teacher";
                cmd.Parameters.Add("@User_Name           ", SqlDbType.VarChar, 50).Value = textBox1.Text;
                cmd.Parameters.Add("@Password            ", SqlDbType.VarChar, 50).Value = textBox1.Text;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                cmd.Dispose();
                con.Close();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label12.Visible = false;
                if (textBox1.Text.Length > 0)
                {
                    SqlCommand cmd1 = new SqlCommand();
                    con.Open();
                    rdiob();

                    cmd1.CommandText = "update tedata set name=name,fname=@fname,dob=@dob,sex=@sex,address=@address,contactno=@contactno,emailid=@emailid,qualification=@qualification,itback=@itback,specialinwhich=@specialinwhich,exprienaceduration=@exprienaceduration,joiningdate=@joiningdate where teacheridno=@teacheridno";
                    cmd1.Parameters.AddWithValue("@teacheridno", textBox1.Text);
                    cmd1.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd1.Parameters.AddWithValue("@fname", textBox3.Text);
                    cmd1.Parameters.AddWithValue("@dob", maskedTextBox1.Text);
                    
                    cmd1.Parameters.AddWithValue("@sex", radio);
                    cmd1.Parameters.AddWithValue("@address", textBox6.Text);
                    cmd1.Parameters.AddWithValue("@contactno", textBox7.Text);
                    cmd1.Parameters.AddWithValue("@emailid", textBox8.Text);
                    cmd1.Parameters.AddWithValue("@qualification", textBox9.Text);
                    cmd1.Parameters.AddWithValue("@itback", textBox10.Text);
                    cmd1.Parameters.AddWithValue("@specialinwhich", textBox11.Text);
                    cmd1.Parameters.AddWithValue("@exprienaceduration", textBox12.Text);
                    cmd1.Parameters.AddWithValue("@joiningdate", dateTimePicker2.Text);
                    //cmd1.Parameters.AddWithValue("@resumeupload", textBox14.Text);
            //        cmd1.Parameters.AddWithValue("@picpath", tpic);
                    cmd1.Connection = con;

                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    clear();
                    pictureBox1.Image = null;
                    label19.Visible = true;
                    con.Close();
                    cmd1.Dispose();
                    button1.Enabled = true;
                    filldata();
                    tidno();
                }
                else
                {
                    MessageBox.Show("TeacherIdno must be filled", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                label12.Visible = false;
                if (textBox1.Text.Length > 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "delete from tedata where teacheridno=@teacheridno";
                    cmd.Parameters.AddWithValue("@teacheridno", textBox1.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted");
                    
                    con.Close();
                    cmd.Dispose();

                    con1.Open();
                    cmd1.CommandText = "delete from login where User_Name='" + textBox1.Text + "'";
                    cmd1.Connection = con1;
                    cmd1.ExecuteNonQuery();
                    con1.Close();
                    cmd1.Dispose();
                    clear();
                    button1.Enabled = true;
                    filldata();
                    tidno();
                }
                else
                {
                    MessageBox.Show("TeacherIdno must be filled", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                label12.Visible = true;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from tedata where teacheridno=@teacheridno";
                cmd.Parameters.AddWithValue("@teacheridno", comboBox1.SelectedItem.ToString());
                cmd.Connection = con;

                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                textBox1.Text = rd[0].ToString();
                textBox2.Text = rd[1].ToString();
                textBox3.Text = rd[2].ToString();
                maskedTextBox1.Text = rd[3].ToString();
                radio = rd[4].ToString();
                textBox6.Text = rd[5].ToString();
                textBox7.Text = rd[6].ToString();
                textBox8.Text = rd[7].ToString();
                textBox9.Text = rd[8].ToString();
                textBox10.Text = rd[9].ToString();
                textBox11.Text = rd[10].ToString();
                textBox12.Text = rd[11].ToString();
                label12.Text = rd[12].ToString();

                if (radio == radioButton1.Text)
                {
                    radioButton1.Checked = true;
                }
                if (radio == radioButton2.Text)
                {
                    radioButton2.Checked = true;
                }
                label19.Visible = false;
                pictureBox1.Image = Image.FromFile(rd[13].ToString());

                
                rd.Dispose();
                cmd.Dispose();
                button1.Enabled = false;
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
      static  int id;
      public void tidno()
      {
          try
          {

              SqlConnection con5 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=teacher");
              SqlCommand cmd5 = new SqlCommand();

              con5.Open();
              cmd5.CommandText = "select max(teacheridno) from tedata";
              cmd5.Connection = con5;
              SqlDataReader rd5 = cmd5.ExecuteReader();
              rd5.Read();
              string tid = rd5[0].ToString();
              id = Convert.ToInt32(tid.Substring(6));
              id++;
              textBox1.Text = "spicte" + id;

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