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
    public partial class Quiz : Form
    {
        static int chapter;
        static string lesson;
        static string session;

        public class QuizField
        {
            private string correct;
            private Label lb;
            private ComboBox cb;

            QuizField(string c,string question, string answer1, string answer2, string answer3) {
                correct = c;

                lb.BackColor = Color.Transparent;

                lb.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                lb.ForeColor = System.Drawing.Color.Violet;

                cb.Size = new Size(430,25);

                lb.Text = question;
                cb.Items.Add(answer1);
                cb.Items.Add(answer2);
                cb.Items.Add(answer3);

                cb.Location = new Point(lb.Location.X,lb.Location.Y +20);

            }






        }

        public Quiz()
        {
            InitializeComponent();
        }
    }
}
