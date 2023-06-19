using Npgsql;
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
            label1.Text = "Hello " + session + "!";
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

            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=2505;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM quiz_results WHERE username='{session}' AND lesson='{lesson}' AND chapter='{chapter}';";
                NpgsqlDataReader reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                    if (reader.Read())
                    {
                    MessageBox.Show("You have already taken this quiz.");
                    }
                    else 
                    {
                        Quiz.set_chapter(chapter);
                        Quiz.set_lesson(lesson);
                        Quiz.set_session(session);
                        Quiz quiz = new Quiz();
                        this.Hide();
                        quiz.ShowDialog();
                        this.Show();
                    }
                //}
                cmd.Dispose();

            };
            con.Close();

           
            
        }
    }
}
