using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace training
{
    public partial class regstudent : Form
    {
        string combo,radio1,radio2;
        public regstudent()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
        SqlCommand cmd = new SqlCommand();
        SqlConnection con1 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");
        SqlCommand cmd1 = new SqlCommand();
     
        public void radiob()
        {
            if (radioButton1.Checked == true)
            {
                radio1 = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                radio1 = radioButton2.Text;

            }
            if (radioButton3.Checked == true)
            {
                radio2 = radioButton3.Text;
                combo = comboBox2.Text;
            }
            if (radioButton4.Checked == true)
            {
                radio2 = radioButton4.Text;
                combo = comboBox2.Text;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                radiob();

                con.Open();
                cmd.CommandText = "insert into studata(studentidno,Name,Fathe_Name,DOB,Sex,University_No,Address,Email_id,Contact_No,Qualification,IT_back,College_Name,Course_Name,Time_Period,Timing,Start_Date,End_Date,Pic_Path) values(@studentidno,@Name,@Fathe_Name,@DOB,Sex,@University_No,@Address,@Email_id,@Contact_No,@Qualification,@IT_back,@College_Name,@Course_Name,@Time_Period,@Timing,@Start_Date,@End_Date,@Pic_Path)";
                cmd.Parameters.AddWithValue("@studentidno", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Father_Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@DOB", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@Sex", radio1);
                cmd.Parameters.AddWithValue("@University_No", textBox6.Text);
                cmd.Parameters.AddWithValue("@Address", textBox7.Text);
                cmd.Parameters.AddWithValue("@email_id", textBox8.Text);
                cmd.Parameters.AddWithValue("@Contac_No", textBox9.Text);
                cmd.Parameters.AddWithValue("@Qualification", textBox10.Text);
                cmd.Parameters.AddWithValue("@IT_back", textBox11.Text);
                cmd.Parameters.AddWithValue("@College_Name", textBox12.Text);
                cmd.Parameters.AddWithValue("@Course_Name", combo);
                cmd.Parameters.AddWithValue("@Time_Period", radio2);
                cmd.Parameters.AddWithValue("@Timing", comboBox5.Text);
                cmd.Parameters.AddWithValue("@Start_Date", comboBox4.Text);
                cmd.Parameters.AddWithValue("@End_Date", label21.Text);
                cmd.Parameters.AddWithValue("@Pic_Path", spic);

                cmd.Connection = con;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                File.Copy(str, spic);
                con.Close();
                cmd.Dispose();
                account();
                clear();
                sidno();
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
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
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
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            comboBox1.Text = null;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox2.Text = null;
            
            comboBox4.Text = null;
            comboBox5.Text = null;
            label21.Text = null;
            pictureBox1.Image = null;
            label19.Visible = true;

            label19.Visible = true;

        }
        private void account()
        {
            SqlConnection con2 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=general");

            con2.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "insert into login(Login_Type,User_Name,Password)values(@Login_Type,@User_Name,@Password)";
            cmd2.Parameters.Add("@Login_Type          ", SqlDbType.VarChar, 50).Value = "Student";
            cmd2.Parameters.Add("@User_Name           ", SqlDbType.VarChar, 50).Value = textBox1.Text;
            cmd2.Parameters.Add("@Password            ", SqlDbType.VarChar, 50).Value = textBox1.Text;
            cmd2.Connection = con2;
            cmd2.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            cmd2.Dispose();
            con2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                radiob();
                if (textBox1.Text.Length > 0)
                {
                    radiob();
                    con.Open();

                    cmd.CommandText = "update studata set Name=@Name,fname=@Father_Name,DOB=@DOB,Sex=@Sex,University_No=@University_No,Address=@Address,Email_id=@emailid,Contact_No=@Contact_No,Qualification=@Qualification,IT_back=@IT_back,College_Name=@College_Name,Course_Name=@Course_Name,Time_Period=@Time_Period,Timing=@Timing,Start_Date=@Start_Date,End_Date=@Start_Date,Batch=@Batch,Teacher_id=@Teacher_id where studentidno=@studentidno";
                    
                    cmd.Parameters.AddWithValue("@studentidno", textBox1.Text);
                    
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Father_Name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@DOB", maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Sex", radio1);
                    cmd.Parameters.AddWithValue("@University_No", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Email_id", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Contact_No", textBox9.Text);
                    cmd.Parameters.AddWithValue("@Qualification", textBox10.Text);
                    cmd.Parameters.AddWithValue("@IT_back", textBox11.Text);
                    cmd.Parameters.AddWithValue("@College_Name", textBox12.Text);
                    
                    
                    cmd.Parameters.AddWithValue("@Time_Period", radio2);
                    cmd.Parameters.AddWithValue("@Course_Name", combo);
                    cmd.Parameters.AddWithValue("@Timing", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@Start_Date", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@End_Date",label21.Text);
                    cmd.Parameters.AddWithValue("@Batch", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Teacher_id", label16.Text);


                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    con.Close();
                    cmd.Dispose();
                    clear();
                    pictureBox1.Image = null;
                    label19.Visible = true;
                   
                    button1.Enabled = true;
                    sidno();
                    
                   
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
            if(textBox1.Text.Length>0)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete from studata where Studentidno=@Studentidno";
                cmd.Parameters.AddWithValue("@Studentidno", textBox1.Text);
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
                sidno();

            button1.Enabled = true;
            
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
                con1.Close();
            }
            
        }

        string spic,str;
        private void label19_Click(object sender, EventArgs e)
        {
          
            OpenFileDialog op1 = new OpenFileDialog();
            op1.InitialDirectory = "c:\\";
            op1.Filter = "JPEG(*.jpg)|*.jpg| Allfiles(*.all files ) |*.*";
          if (op1.ShowDialog(this) == DialogResult.OK)
            {
                 str = op1.FileName;
                string target = Application.StartupPath.ToString();
                spic = target + "\\snap\\"+textBox1.Text+ str.Substring(str.Length - 4);
               
                pictureBox1.Image = Image.FromFile(str);
                label19.Visible = false;

            }
          
        
        }


        public void input()
        {
            //cmd.Parameters.AddWithValue("@studentidno", textBox1.Text);
            //cmd.Parameters.AddWithValue("@name", textBox2.Text);
            //cmd.Parameters.AddWithValue("@fname", textBox3.Text);
            //cmd.Parameters.AddWithValue("@dob", maskedTextBox1.Text);
            //cmd.Parameters.AddWithValue("@sex", radio1);
            //cmd.Parameters.AddWithValue("@unino", textBox6.Text);
            //cmd.Parameters.AddWithValue("@address", textBox7.Text);
            //cmd.Parameters.AddWithValue("@emailid", textBox8.Text);
            //cmd.Parameters.AddWithValue("@contactno", textBox9.Text);
            //cmd.Parameters.AddWithValue("@qualification", textBox10.Text);
            //cmd.Parameters.AddWithValue("@itback", textBox11.Text);
            //cmd.Parameters.AddWithValue("@collegename", textBox12.Text);
            //cmd.Parameters.AddWithValue("@timeperiod", radio2);
            //cmd.Parameters.AddWithValue("@coursename", combo);
            //cmd.Parameters.AddWithValue("@timing", comboBox5.Text);
            //cmd.Parameters.AddWithValue("@sdate", comboBox4.Text);
            //cmd.Parameters.AddWithValue("@edate", label21.Text);
            //cmd.Parameters.AddWithValue("@picpath", spic);

        }


        public void filldata()
        {
           
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.Clear();
            }
            else
            {
                con1.Open();
                comboBox1.Items.Clear();
                comboBox1.Text = null;
                cmd.CommandText = "select distinct batch_code,batch_start from batch1 where course='" + comboBox2.Text + "'";
                cmd.Connection = con1;

                SqlDataReader rd1 = cmd.ExecuteReader();
                while (rd1.Read())
                {
                    comboBox1.Items.Add(rd1[0].ToString());
                    comboBox4.Items.Add(rd1[1].ToString());
                }
                //while (rd.Read())
                //{
                //    comboBox1.Items.Add(rd[0].ToString());
                //    comboBox4.Items.Add(rd[1].ToString());
                //}
                rd1.Close();
                cmd.Dispose();
                con1.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                filldata();
                //label20.Visible = true;
                //label21.Visible = true;
                con.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select * from studata where Studentidno=@Studentidno";
                cmd.Parameters.AddWithValue("@Studentidno", textBox4.Text);
                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                textBox1.Text = rd[0].ToString();
                textBox2.Text = rd[1].ToString();
                textBox3.Text = rd[2].ToString();
                maskedTextBox1.Text = rd[3].ToString();
                radio1 = rd[4].ToString();
                if (radio1 == "Male")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }
                textBox6.Text = rd[5].ToString();
                textBox7.Text = rd[6].ToString();
                textBox8.Text = rd[7].ToString();
                textBox9.Text = rd[8].ToString();
                textBox10.Text = rd[9].ToString();
                textBox11.Text = rd[10].ToString();
                textBox12.Text = rd[11].ToString();
                radio2 = rd[13].ToString();
                if (radio2 == "6 months")
                {
                    radioButton4.Checked = true;
                    comboBox2.Text = rd[12].ToString();
                }
                if (radio2=="6 weeks")
                {
                    radioButton3.Checked = true;
                    comboBox2.Text = rd[12].ToString();

                }  
                //combo = rd[13].ToString();

                comboBox5.Text = rd[14].ToString();
                comboBox4.Text = rd[15].ToString();
                label21.Text = rd[16].ToString();
                label19.Visible = false;
                pictureBox1.Image = Image.FromFile(rd[17].ToString());

                con.Close();
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

        

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Text = null;
            }
            if (radioButton4.Checked == true)
            {
                con1.Open();
                comboBox2.Enabled = true;
                

                cmd1.CommandText = "select distinct(coursename) from coursestart where duration='"+radioButton4.Text+"'";
                cmd1.Connection = con1;
                SqlDataReader rd = cmd1.ExecuteReader();

                while (rd.Read())
                {
                    comboBox2.Items.Add(rd[0].ToString());
                }
                
                
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                
                comboBox4.Text = null;
                comboBox5.Text = null;
                label21.Text = "";

                con1.Close();
                rd.Dispose();
                cmd1.Dispose();
                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.Items.Clear();
                comboBox2.Text = null;
            }
            if (radioButton3.Checked == true)
            {
                con1.Open();
                comboBox2.Enabled = true;
                //comboBox2.Enabled = false;
                cmd1.CommandText = "select coursename from coursestart where duration='" + radioButton3.Text + "'";
                cmd1.Connection = con1;
                SqlDataReader rd = cmd1.ExecuteReader();

                while (rd.Read())
                {
                    comboBox2.Items.Add(rd[0].ToString());
                }

                //comboBox2.Text = null;
                //comboBox2.Items.Clear();
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                
                comboBox4.Text = null;
                comboBox5.Text = null;
                label21.Text = "";


                con1.Close();
                rd.Dispose();
                cmd1.Dispose();
                
                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
           {
            filldata();
            con1.Close();
            con1.Open();
            combo = comboBox2.Text;
            if (comboBox4.Items.Count > 0)
            {
                comboBox4.Items.Clear();
            }
            if (comboBox5.Items.Count > 0)
            {
                comboBox5.Items.Clear();
            }

            cmd1.CommandText = "select start_date from coursestart where coursename='"+combo+"'";

            cmd1.Connection = con1;
            SqlDataReader rd = cmd1.ExecuteReader();

            while (rd.Read())
            {
                comboBox4.Items.Add(rd[0].ToString());
            }

            con1.Close();
            rd.Dispose();
            cmd1.Dispose();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message.ToString());
           }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            con1.Close();
            con1.Open();
            combo = comboBox2.Text;
            if (comboBox4.Items.Count > 0)
            {
                comboBox4.Items.Clear();
            }
            if (comboBox5.Items.Count > 0)
            {
                comboBox5.Items.Clear();
            }
            cmd1.CommandText = "select start_date from coursestart where coursename='"+combo+"'";

            cmd1.Connection = con1;
            SqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                comboBox4.Items.Add(rd[0].ToString());
            }

            
            con1.Close();
            rd.Dispose();
            cmd1.Dispose();
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
                if (comboBox5.Items.Count > 0)
                {
                    comboBox5.Items.Clear();
                }
            con1.Close();
            con1.Open();
            
            cmd1.CommandText = "select end_date,timing from coursestart where start_date='" + comboBox4.Text + "'and coursename='" + combo + "'";

            cmd1.Connection = con1;
            SqlDataReader rd = cmd1.ExecuteReader();

            while (rd.Read())
            {

                comboBox5.Items.Add(rd[1].ToString());
                label21.Text = rd[0].ToString();
            }
            con1.Close();
            
                rd.Dispose();
            cmd1.Dispose();
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
            cmd1.Connection = con1;

            cmd1.CommandText="select te_code,batch_start,batch_end,timing from batch1 where batch_code='"+comboBox1.Text+"'";
            SqlDataReader rd = cmd1.ExecuteReader();
            rd.Read();
            label16.Text = rd[0].ToString();
            comboBox4.Text = rd[1].ToString();
            label21.Text = rd[2].ToString();
            comboBox5.Text = rd[3].ToString();
            con1.Close();
            rd.Dispose();
            cmd1.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void regstudent_Load(object sender, EventArgs e)
        {

            sidno();


        }

        static int sid;
        public void sidno()
        {
            //try
            //{
            SqlConnection con5 = new SqlConnection("server=LOVY\\SQLEXPRESS;uid=sa;pwd=;database=student");
            SqlCommand cmd5 = new SqlCommand();

            con5.Open();
            cmd5.CommandText = "select max(S_No) from studata";
            cmd5.Connection = con5;
            SqlDataReader rd5 = cmd5.ExecuteReader();
            rd5.Read();
            sid = Convert.ToInt32(rd5[0].ToString());
            
                sid++;
            
            con5.Close();
            rd5.Dispose();
            cmd5.Dispose();
            textBox1.Text = "spicstu" + sid;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}

        }

        
    }
}