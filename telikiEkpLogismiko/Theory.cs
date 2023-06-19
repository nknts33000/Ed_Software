using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        public class ExtendedLinkLabel : LinkLabel
        {
            private int chapter;

            protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
            {
                Viewer.set_chapter(chapter);
                Viewer.set_session(Theory.get_session());
                Viewer.set_lesson(Theory.get_lesson());
                Viewer.set_ofd(Theory.get_lesson() + chapter + ".pdf");
                
                Viewer v = new Viewer();

                this.Hide();
                v.set_lb();
                v.ShowDialog();

                this.Show();


            }
            public void set_chapter(int s)
            {
                chapter = s;
            }

            public int get_chapter()
            {
                return chapter;
            }
        }




        public Theory()
        {
            InitializeComponent();
            Debug.WriteLine(lesson);
            for (int i = 1; i <= chapters; i++)
            {
                ExtendedLinkLabel lb = new ExtendedLinkLabel();
                lb.Location = new Point(530, starting_point * (i - 1) + 60);
                lb.Text = "Chapter " + i.ToString();
                lb.Visible = true;
                lb.BackColor = Color.Transparent;

                lb.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                lb.LinkColor = System.Drawing.Color.Violet;
                lb.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
                lb.set_chapter(i);
                this.Controls.Add(lb);

                label2.Text = "Hello " + session + "!";
            }




        }

        private void Theory_Load(object sender, EventArgs e)
        {
            
        }

        public static void set_session(string s)
        {

            session = s;
        }

        public static string get_session() 
        { 
            return session;
        
        }
        public static void set_lesson(string ls)
        {

            lesson = ls;
        }
        public static string get_lesson()
        {
            return lesson;

        }
        public static void set_chapters(int ch)
        {
            chapters = ch;

        }

        private void final_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=6972419550n;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM quiz_results WHERE username='{session}' AND lesson='{lesson}';";

                NpgsqlDataReader reader = cmd.ExecuteReader();
               
                //while (reader.Read())
                //{
                int i = 0;
                while(reader.Read())
                {
                    i++;
                }
                reader.Close();
                if (i == chapters)
                {
                    cmd.CommandText = $"SELECT * FROM test_results WHERE username='{session}' AND lesson='{lesson}';";
                    NpgsqlDataReader reader2 = cmd.ExecuteReader();
                    
                    
                    if (reader2.Read())
                    {
                        MessageBox.Show("You have completed the lesson's evaluation.");
                    }
                    else 
                    {
                        Test.set_lesson(lesson);
                        Test.set_session(session);
                        Test t = new Test();
                        this.Hide();
                        t.ShowDialog();
                        this.Show();
                    }
                    
                    
                }
                else 
                {
                    MessageBox.Show("You have to take quizzes of all chapters before taking the final test.");
                }
                
                
                //}
                cmd.Dispose();

            };
            con.Close();
        }
    }
}
