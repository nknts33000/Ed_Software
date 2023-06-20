using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    public partial class Form2 : Form
    {
        static string session;
        public Form2()
        {
            InitializeComponent();
            label2.Text = "Hello "+session+"!";
        }

        public static void set_session(string us)
        {
            session=us;
            
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3.set_lesson(linkLabel3.Text);
            Form3.set_session(session);
            open_f3();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3.set_lesson(linkLabel1.Text);
            Form3.set_session(session);
            open_f3();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3.set_lesson(linkLabel2.Text);
            Form3.set_session(session);
            open_f3();
        }

        private void open_f3()
        {
            Form3 f3=new Form3();
            
            this.Hide();
            f3.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=2505;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT lesson,score FROM test_results WHERE username='{session}';";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                Dictionary<double, string> tests_data = new Dictionary<double, string>();
                if (reader.Read())
                {
                    tests_data.Add(reader.GetDouble(1),reader.GetString(0));
                    while (reader.Read())
                    {
                        tests_data.Add(reader.GetDouble(1), reader.GetString(0));
                    }
                    tests_data.ToImmutableSortedDictionary();
                    if (tests_data.First().Key > 70)
                    {
                        if (tests_data.First().Value.Equals("CyberSecurity"))
                        {
                            Form4 f4= new Form4();
                            f4.set_label("After your self-assessment, we see that the branch of CyberSecurity would suit you\r\nBelow we suggest some postgraduate courses close to this subject,\r\nto further expand your industry knowledge\r\n\r\nIn the professional field, some of the specializations that seem to suit you are Security Analyst,\nPenetration Tester,DevSecOps or any other Security specialization.");
                            f4.set_link_label("https://cybersecdatasci.cs.unipi.gr/");
                            this.Hide();
                            f4.ShowDialog();
                            this.Show();
                        }
                        else if(tests_data.First().Value.Equals("DBMS"))
                        {
                            Form4 f4 = new Form4();
                            f4.set_label("After your self-assessment, we see that the branch of Database Administration would suit you\r\nBelow we suggest some postgraduate courses close to this subject,\r\nto further expand your industry knowledge\r\n\r\nIn the professional field, some of the specializations that seem to suit you are \nDatabase Administrator/Engineer, DevOps");
                            f4.set_link_label("https://mscdss.ds.unipi.gr/");
                            this.Hide();
                            f4.ShowDialog();
                            this.Show();
                        }
                        else if (tests_data.First().Value.Equals("DATA ANALYSIS"))
                        {
                            Form4 f4 = new Form4();
                            f4.set_label("After your self-assessment, we see that the branch of Data Analysis would suit you\r\nBelow we suggest some postgraduate courses close to this subject,\r\nto further expand your industry knowledge\r\n\r\nIn the professional field, some of the specializations that seem to suit you are\n Data Analyst,Machine Learning Engineer");
                            f4.set_link_label("https://dsml.ece.ntua.gr/");
                            this.Hide();
                            f4.ShowDialog();
                            this.Show();
                        }
                    }

                }
                else 
                {
                    MessageBox.Show("We can't recommend you anything if you haven't completed any lesson! ");
                }
                cmd.Dispose();

            };
            con.Close();
        }
    }
}
