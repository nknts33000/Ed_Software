using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telikiEkpLogismiko
{


    public partial class Viewer : Form
    {
        static OpenFileDialog openFileDialog1 = new OpenFileDialog();
        static int chapter;
        static string lesson;
        static string session;
        


        
        public Viewer()
        {
            InitializeComponent();
            
            //button1_Click(null, null);

        }

        public static void set_ofd(string s)
        {
              
            openFileDialog1.FileName = s;

        }
        public void set_lb()
        {
            linkLabel1.Visible= true;
        }
        public static void make_button(Button b) 
        {
            b.Visible = true;   
        }
        public static void set_session(string s)
        {

            session = s;
        }
        public static void set_lesson(string ls)
        {

            lesson = ls;
        }

        public static void set_chapter(int ch)
        {
            chapter = ch;
        }


        private void Viewer_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "pdf files (*.pdf) |*.pdf;";
            axAcroPDF1.LoadFile(openFileDialog1.FileName);
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
