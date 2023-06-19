using Npgsql;
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
    public partial class Test : Form
    {

        
        static string lesson;
        static string session;
        static List<string> questions;
        static List<string> answers1;
        static List<string> answers2;
        static List<string> answers3;
        static List<string> corrects;

        public Test()
        {
            InitializeComponent();
            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=2505;Database=ed_software;");
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
                cmd.Dispose();

            };
            con.Close();

            for (int i = 0; i < 6; i++)
            {
                
            }
        }

        public static void set_session(string s)
        {

            session = s;
        }

        public static void set_lesson(string ls)
        {

            lesson = ls;
        }


    }
}
