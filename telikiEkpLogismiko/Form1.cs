using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace telikiEkpLogismiko
{
    public partial class Form1 : Form
    {
        string session;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text).Equals((textBox3.Text))) {
                label5.Visible = false; 
                registration(textBox1.Text,textBox2.Text,textBox4.Text);
            } 
            else
            {
                label5.Visible = true;
                label5.Text = "Passwords don/'t match!";
            }
           
        }

        public async void registration(string us,string pass, string email)
        {

            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=2505;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"INSERT INTO users (username, password, email, CyberSecurity, DBMS, DATA ANALYSIS) VALUES (@username, @password, @email, @cybersec, @DBMS, @datascience );";
                cmd.Parameters.AddWithValue("username",us);
                cmd.Parameters.AddWithValue("password",pass);
                cmd.Parameters.AddWithValue("email", email);
                //cmd.Parameters.AddWithValue("CyberSec", 0);
                cmd.Parameters.AddWithValue("cybersec", 0);
                
                cmd.Parameters.AddWithValue("DBMS", 0);
                cmd.Parameters.AddWithValue("datascience", 0);
                // cmd.Parameters.AddWithValue("UI", 0);
                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
            } ;
            con.Close();


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sign_in(textBox1.Text,textBox2.Text);
        }


        public async void sign_in(string us, string pass)
        {

            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=2505;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM users WHERE username='{us}' AND password='{pass}'";
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
               
                while (await reader.ReadAsync())
                {
                    if (reader.HasRows) { 
                        session = (string)reader[0]; //throws username to the next form
                        
                    
                        Form2.set_session(session);
                    }
                }
                cmd.Dispose();

            };
            con.Close();

            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
            
              



        }

    }
}
