using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace training
{
    public partial class MDIParent1 : Form
    {
        //private int childFormNumber = 0;
        public string typpe = "";
        public MDIParent1()
        {
            InitializeComponent();
        }

        

        private void MDIParent1_Load(object sender, EventArgs e)
        {


            if (typpe == "S")
            {
                student st = new student();
                st.MdiParent = this;
                st.Show();
            }

            if (typpe == "D")
            {
                director_page st = new director_page();
                st.MdiParent = this;
                st.Show();
            }

            if (typpe == "A")
            {
                Administrator st = new Administrator();
                st.MdiParent = this;
                st.Show();
            }

            if (typpe == "CA")
            {
                career_advisor st = new career_advisor();
                st.MdiParent = this;
                st.Show();
            }

            if (typpe == "T")
            {
                teacher st = new teacher();
                st.MdiParent = this;
                st.Show();
            }

        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
