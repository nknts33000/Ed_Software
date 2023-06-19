using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telikiEkpLogismiko
{
    public partial class Form2 : Form
    {
        static string session;
        public Form2()
        {
            InitializeComponent();
            label2.Text = "Hello "+session+"!";
        }

        public static void set_session(string us)
        {
            session=us;
            
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3.set_lesson(linkLabel3.Text);
            Form3.set_session(session);
            open_f3();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3.set_lesson(linkLabel1.Text);
            Form3.set_session(session);
            open_f3();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3.set_lesson(linkLabel2.Text);
            Form3.set_session(session);
            open_f3();
        }

        private void open_f3()
        {
            Form3 f3=new Form3();
            
            this.Hide();
            f3.ShowDialog();
            this.Show();
        }
    }
}
