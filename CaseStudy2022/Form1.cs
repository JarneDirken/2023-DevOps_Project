using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace CaseStudy
{
    public partial class Form1 : Form
    {
        //variables
        public static Form1 instance;
        public Label lb1, lb2;
        public Form3 form3 = new Form3();

        public Form1()
        {
            InitializeComponent();
            instance = this;
            lb1 = label1;
            lb2 = label4;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label.Text = Program.generateRandomString();
        }
        private void button2_Click(object sender, EventArgs e) //notseen
        {
            label.Text = Program.generateRandomString();
            label4.Text = Program.updateScore(1).ToString();
            label1.Text = Program.updateLives(1).ToString();
            if (lb1.Text == "0")
            {
                Form1.instance.Hide();
                form3.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e) //seen
        {
            label.Text = Program.generateRandomString();
            label4.Text = Program.updateScore(0).ToString();
            label1.Text = Program.updateLives(0).ToString();
            if (lb1.Text == "0")
            {
                Form1.instance.Hide();
                form3.Show();
            }
        }
    }
}
