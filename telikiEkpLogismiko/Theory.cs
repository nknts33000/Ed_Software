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
    public partial class Theory : Form
    {
         
        static int chapters;
        static string lesson;
        static string session;
        static int starting_point = 60;
        
        public class ExtendeLinkLabel : LinkLabel {
            protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
            {
                
            }
        }
        public Theory()
        {
            InitializeComponent();
            for (int i = 1; i <= chapters; i++)
            {
                LinkLabel lb = new LinkLabel();
                lb.Location = new Point(530, starting_point * (i - 1) + 60);
                lb.Text = "Chapter " + i.ToString();
                lb.Visible = true;
                lb.BackColor = Color.Transparent;

                lb.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                lb.LinkColor = System.Drawing.Color.Violet;
                lb.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
                this.Controls.Add(lb);


            }




        }

        private void Theory_Load(object sender, EventArgs e)
        {
            
        }

        public static void set_session(string s)
        {

            session = s;
        }
        public static void set_lesson(string ls)
        {

            lesson = ls;
        }

        public static void set_chapters(int ch)
        {
            chapters = ch;

        }
    }
}
