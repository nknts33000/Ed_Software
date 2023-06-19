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
    public partial class Form3 : Form
    {
        static string session;
        static string lesson;
        
        
        public Form3()
        {
            InitializeComponent();
            label1.Visible = true;
            label1.Text = lesson;
            label2.Text = "Hello " + session + "!";
        }
        public static void set_session(string us)
        {
            session = us;

        }

        public static void set_lesson(string ls)
        {
            lesson=ls;

        }


        public async void go_to_theory(string ls)
        {

            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=2505;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT chapters FROM lessons WHERE lesson_name='{ls}';";
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    
                    if (reader.HasRows)
                    {

                        Theory.set_chapters((int)reader[0]) ;
                        Theory.set_session(session);
                        Theory.set_lesson(lesson);
                        
                    }
                    

                }
                cmd.Dispose();

            };
            con.Close();

            Theory th = new Theory();
            this.Hide();
            th.ShowDialog();
            this.Show();

        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            go_to_theory(label1.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Viewer v=new Viewer();
            if (lesson.Equals("CyberSecurity")) {
                Viewer.set_ofd("cyber_intro.pdf");
                this.Hide();
                v.ShowDialog();
                this.Show();
            }
            else if (lesson.Equals("DBMS")) {
                Viewer.set_ofd("dbms_intro.pdf");
                this.Hide();
                v.ShowDialog();
                this.Show();
            }
            else if (lesson.Equals("DATA ANALYSIS")) {

                Viewer.set_ofd("data_science_intro.pdf");
                this.Hide();
                v.ShowDialog();
                this.Show();
            }
        }
    }
}
