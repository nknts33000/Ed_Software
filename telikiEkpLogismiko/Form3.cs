using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telikiEkpLogismiko
{
    public partial class Form3 : Form
    {
        static string session;
        static string lesson;
        public Form3()
        {
            InitializeComponent();
            label1.Visible = true;
            label1.Text = lesson;
        }
        public static void set_session(string us)
        {
            session = us;

        }

        public static void set_lesson(string ls)
        {
            lesson=ls;

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
