using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseStudy
{
    public partial class Form2 : Form
    {
        //variables
        public static Form2 instance;
        public TextBox tb1;
        public Label lb1, lb2;
        public bool isClicked = false;
        public string name = "";
        public Form1 form1 = new Form1();
        public static Difficulty easy = new Difficulty.Easy();
        public static Difficulty medium = new Difficulty.Medium();
        public static Difficulty hard = new Difficulty.Hard();
        public int easyLives = easy.Lives;
        public int mediumLives = medium.Lives;
        public int hardLives = hard.Lives;

        public Form2()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox1;
            lb1 = label2;
            lb2 = label3;
            label2.Hide();
            label3.Hide();
        }
        public void checkName()
        {
            label2.Hide();
            label3.Hide();
            if (tb1.Text.Length < 25)
            {
                if (!String.IsNullOrWhiteSpace(tb1.Text))
                {
                    if (isClicked == false)
                    {
                        instance.Hide();
                        form1.Show();
                        isClicked = true;
                        name = tb1.Text;
                    }
                }
                else
                {
                    label2.Show();
                }
            }
            else
            {
                label3.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            checkName();
            form1.lb1.Text = easyLives.ToString();
            Program.lives = easyLives;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            checkName();
            form1.lb1.Text = mediumLives.ToString();
            Program.lives = mediumLives;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            checkName();
            form1.lb1.Text = hardLives.ToString();
            Program.lives = hardLives;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
