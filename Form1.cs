using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace XO
{
    public partial class Form1 : Form
    {
        private int Turn;
        private int Won = -1;
        private Button[,] btn = new Button[3, 3];

        int Score1 = 0;
        int Score2 = 0;

        int x = 12, y = 74;

        public Form1()
        {
            InitializeComponent();
            Turn = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].Size = new Size(80, 80);
                    btn[i, j].Text = "";
                    btn[i, j].Location = new Point(x + 86 * j, y + 86 * i);

                    btn[i, j].Font = new Font("", 25, FontStyle.Bold);

                    btn[i, j].Click += button_Click;
                    this.Controls.Add(btn[i, j]);
                }
            }
        }

        private void Verify()
        {
            String aux;
            int ok = 0;

            for (int i = 0; i < 3; i++) // Horizontal
            {
                aux = btn[i, 0].Text;
                ok = 0;

                if (aux != "")
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (btn[i, j].Text == aux)
                            ok++;
                        else
                            break;

                        if (ok == 3)
                        {
                            if (aux == "O")
                                Won = 0;
                            else Won = 1;
                        }
                    }
                }
            }

            for (int i = 0; i < 3; i++) // Vertical
            {
                aux = btn[0, i].Text;
                ok = 0;

                if (aux != "")
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (btn[j, i].Text == aux)
                            ok++;
                        else
                            break;

                        if (ok == 3)
                        {
                            if (aux == "O")
                                Won = 0;
                            else Won = 1;
                        }
                    }
                }
            }

            if (btn[0, 0].Text != "" && btn[0, 0].Text == btn[1, 1].Text && btn[0, 0].Text == btn[2, 2].Text)
            {
                if (btn[0, 0].Text == "O")
                    Won = 0;
                else
                    Won = 1;
            }
            else if (btn[0, 2].Text != "" && btn[0, 2].Text == btn[1, 1].Text && btn[0, 2].Text == btn[2, 0].Text)
            {
                if (btn[0, 2].Text == "O")
                    Won = 0;
                else
                    Won = 1;
            }

            ok = 0;
            for (int i = 0; i < 3; i++) // Draw
            {
                for (int j = 0; j < 3; j++)
                {
                    if (btn[i, j].Text != "" && Won == -1)
                        ok++;
                }
            }

            if (ok == 9)
                Won = 2;

        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender.GetType().GetProperty("Text").GetValue(sender).ToString() == "")
            {
                if (Turn == 1)
                {
                    sender.GetType().GetProperty("Text").SetValue(sender, "X");
                    Turn = 0;
                }
                else
                {
                    sender.GetType().GetProperty("Text").SetValue(sender, "O");
                    Turn = 1;
                }

                sender.GetType().GetProperty("Enabled").SetValue(sender, false);
                Verify();
            }

            if (Won == 0)
            {
                label1.Text = "O win";
                Score2++;
                textBox2.Text = Score2.ToString();
            }
            else if (Won == 1)
            {
                label1.Text = "X win";
                Score1++;
                textBox1.Text = Score1.ToString();  
            }
            else if (Won == 2)
                label1.Text = "Draw";

            if (Won == 0 || Won == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        btn[i, j].Enabled = false;
                    }
                }
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Won = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btn[i, j].Text = "";
                    btn[i, j].Enabled = true;
                }
            }
        }

    }
}
