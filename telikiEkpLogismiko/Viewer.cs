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
    public partial class Viewer : Form
    {
        static OpenFileDialog openFileDialog1 = new OpenFileDialog();
        static int chapters;
        static string lesson;
        static string session;


        public Viewer()
        {
            InitializeComponent();

        }

        public static void set_ofd(string s)
        {
              
            openFileDialog1.FileName = s;

        }

        public static void set_session(string s)
        {

            session = s;
        }
        public static void set_lessons(string ls)
        {

            lesson = ls;
        }

        public static void set_chapters(int ch)
        {
            chapters = ch;
        }


        private void Viewer_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "pdf files (*.pdf) |*.pdf;";
            axAcroPDF1.LoadFile(openFileDialog1.FileName);
            
        }
    }
}
