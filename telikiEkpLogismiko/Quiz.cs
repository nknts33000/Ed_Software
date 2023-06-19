using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace telikiEkpLogismiko
{
    public partial class Quiz : Form
    {
        static int chapter;
        static string lesson;
        static string session;
        static string correct_answer1;
        static string correct_answer2;

        public Quiz()
        {
            InitializeComponent();
            label4.Text = "Hello " + session + "!";
            quiz_questions();
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

        public async void quiz_questions() 
        {
            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=2505;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT question,answer1,answer2,answer3,correct_answer FROM quizzes WHERE lesson='{lesson}' and chapter='{chapter}';";
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
                int i = 0;
                while (reader.Read())
                {
                    
                    if (i == 2) break;
                    if (reader.HasRows)
                    { 
                        
                        if (i == 0)
                        {
                            label1.Text = reader.GetString(0);
                            comboBox1.Items.Add(reader.GetString(1));
                            comboBox1.Items.Add(reader.GetString(2));
                            comboBox1.Items.Add(reader.GetString(3));
                            correct_answer1 = reader.GetString(4);
                        }
                        else {
                            label2.Text = reader.GetString(0);
                            comboBox2.Items.Add(reader.GetString(1));
                            comboBox2.Items.Add(reader.GetString(2));
                            comboBox2.Items.Add(reader.GetString(3));
                            correct_answer2 = reader.GetString(4);
                        }
                        i++;
                    }

                }
                cmd.Dispose();

            };
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int score;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            if (comboBox1.Text.Equals(correct_answer1) || comboBox2.Text.Equals(correct_answer2)) 
            {
                if (comboBox1.Text.Equals(correct_answer1) && comboBox2.Text.Equals(correct_answer2))
                {
                    score = 100;
                }
                else 
                {
                    score = 50;
                }
            }
            else 
            {
                score=0;
            }

            label3.Text = "You scored "+score.ToString();
            label3.Visible = true;
            button1.Enabled = false;

            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=2505;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"INSERT INTO quiz_results (username,lesson,chapter,score) VALUES (@username, @lesson, @chapter, @score);";
                cmd.Parameters.AddWithValue("username", session);
                Debug.WriteLine(session);
                cmd.Parameters.AddWithValue("lesson", lesson);
                cmd.Parameters.AddWithValue("chapter", chapter);
                
                cmd.Parameters.AddWithValue("score", score);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            };
            con.Close();

        }
    }
}
