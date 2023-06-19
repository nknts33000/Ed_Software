using Npgsql;
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
    public partial class Test : Form
    {

        
        static string lesson;
        static string session;
        static List<string> questions=new List<string>();
        static List<string> answers1 = new List<string>();
        static List<string> answers2 = new List<string>();
        static List<string> answers3 = new List<string>();
        static List<string> corrects = new List<string>();
        static List<Label> label_list = new List<Label>();
        static List<ComboBox> combobox_list = new List<ComboBox>();

        public Test()
        {
            InitializeComponent();
            Debug.WriteLine(lesson);
            label_list.Add(label1);
            label_list.Add(label2);
            label_list.Add(label3);
            label_list.Add(label4);
            label_list.Add(label5);
            label_list.Add(label6);
            combobox_list.Add(comboBox1);
            combobox_list.Add(comboBox2);
            combobox_list.Add(comboBox3);
            combobox_list.Add(comboBox4);
            combobox_list.Add(comboBox5);
            combobox_list.Add(comboBox6);
            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=6972419550n;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT question,answer1,answer2,answer3,correct_answer FROM tests WHERE lesson='{lesson}';";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    questions.Add(reader.GetString(0));
                    
                    answers1.Add(reader.GetString(1));
                    answers2.Add(reader.GetString(2));
                    answers3.Add(reader.GetString(3));
                    corrects.Add(reader.GetString(4));
                    

                }

                for (int i = 0; i < 6; i++)
                {
                    label_list[i].Text = questions[i];

                    combobox_list[i].Items.Add(answers1[i]);
                    combobox_list[i].Items.Add(answers2[i]);
                    combobox_list[i].Items.Add(answers3[i]);
                }


                cmd.Dispose();

            };
            con.Close();

            
        }

        public static void set_session(string s)
        {

            session = s;
        }

        public static void set_lesson(string ls)
        {

            lesson = ls;
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            
            int score = 0;
            double final;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            button1.Enabled = false;
            for (int k = 0; k < questions.Count; k++)
            {
                    if (combobox_list[k].Text.Equals(corrects[k]))
                    {
                        score++;
                    }
            }
            final = (score * 100) / 6;
            label7.Text = "You scored " + final.ToString() + "%";
            label7.Visible = true;
                

            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=6972419550n;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"INSERT INTO test_results (username,lesson,score) VALUES (@username, @lesson, @score);";
                cmd.Parameters.AddWithValue("username", session);
                
                cmd.Parameters.AddWithValue("lesson", lesson);
                

                cmd.Parameters.AddWithValue("score", final);

                cmd.ExecuteNonQuery();//insert into tests
                //now read from quizzes to form the total grade of the lesson.


                cmd.CommandText = $"SELECT score FROM quiz_results WHERE username='{session}' AND lesson='{lesson}';";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                double x = 0;
                int j = 0;
                while (reader.Read())
                {
                    j++;
                    x += reader.GetDouble(0);  
                }
                reader.Close();
                double total = (x / j + final) / 2;

                cmd.CommandText = $"UPDATE users  SET {lesson}={total} WHERE username='{session}';";

                

                cmd.ExecuteNonQuery();

                cmd.Dispose();
            };
            con.Close();


        }
    }
}
