using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telikiEkpLogismiko
{
    public partial class Form1 : Form
    {
        
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
            query_handler();
           
        }

        public async void query_handler()
        {

            var con = new NpgsqlConnection(
    connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=6972419550n;Database=ed_software;");
            con.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = $"INSERT INTO users (username, password, email, cybersec, ai, ui) VALUES (@username, @password, @email, @cybersec, @ai, @ui );";
                cmd.Parameters.AddWithValue("username", "nknts330");
                cmd.Parameters.AddWithValue("password", "2505");
                cmd.Parameters.AddWithValue("email", "nknts33000@gmail.com");
                //cmd.Parameters.AddWithValue("CyberSec", 0);
                cmd.Parameters.AddWithValue("cybersec", 0);
                cmd.Parameters.AddWithValue("ai", 0);
                cmd.Parameters.AddWithValue("ui", 0);
                // cmd.Parameters.AddWithValue("UI", 0);
                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
            } ;
            con.Close();


        }
    }
}
