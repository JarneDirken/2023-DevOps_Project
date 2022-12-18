using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//database
using System.Data.SQLite;

namespace CaseStudy
{
    public partial class Form3 : Form
    {
        //variables
        public static Form3 instance;
        public Label lb1, lb2, lb3, lb4;

        public Form3()
        {
            InitializeComponent();
            instance = this;
            lb1 = label4;
            lb2 = label6;
            lb3 = label8;
            lb4 = label9;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lb1.Text = Database.HighScoreValue().ToString(); // this needs to be from database 
            lb2.Text = Database.HighScoreName().ToString(); // this also needs to be from database, The person who has te alltime highscore
            lb3.Text = Program.score.ToString();
            lb4.Text = Form2.instance.name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
