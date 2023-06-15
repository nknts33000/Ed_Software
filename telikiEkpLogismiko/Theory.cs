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
    public partial class Theory : Form
    {
         
        static int chapters;
        static string lesson;
        static string session;
        static int starting_point = 60;
        
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
        public Theory()
        {
            InitializeComponent();
        }

        private void Theory_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < chapters; i++)
            {
                LinkLabel lb = new LinkLabel();
                lb.Location = new Point(400, starting_point*i);
                lb.Text = "Chapter " + (i + 1).ToString();
                this.Controls.Add(lb);
            }
        }
    }
}
