using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace kursach
{
    public partial class Form1 : Form
    {
        double goodmath;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile("D:\\University\\NetFramework\\Курсовая\\image.jpg");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            Random random = new Random();



            double xmin, xmax, dx, q, a;
            a = 25;
            int count1 = 0;
            int count2 = 0;
            q = random.NextDouble() * (1.0 - 0.0001) + 0.0001;

            void Func()
            {
                for (double i = xmin; i <= xmax; i += dx)
                {


                    if (q > 0 && q <= 0.35)
                    {

                        if ((q * Sin(i)) < 0)
                        {
                            listBox1.Items.Add($"No value for x = {i:F3}");
                        }
                        else
                        {

                            goodmath = Pow(Sqrt(q * Sin(i)), 1 / 3.0);

                            if (double.IsInfinity(goodmath))
                            {
                                listBox1.Items.Add($"Does not exist");
                            }
                            else
                            {
                                listBox1.Items.Add($"F = {goodmath:F3} for x = {i:F3}");
                            }
                        }

                        listBox1.Items.Add($" ");
                        count1++;
                    }
                    else if (q > 0.35 && q <= 1)
                    {

                        if (double.IsNaN(Log(q * Sin(a * i))) || q == 0)
                        {
                            listBox2.Items.Add($"No value for x = {i:F3}");
                        }
                        else
                        {
                            goodmath = (Log(q * Sin(a * i))) / q;


                            if (double.IsInfinity(goodmath))
                            {
                                listBox2.Items.Add($"Not Exist");
                            }
                            else
                            {
                                listBox2.Items.Add($"F = {goodmath:F3} for x = {i:F3}");
                            }
                        }

                        listBox2.Items.Add($" ");
                        count2++;
                    }
                }

                label10.Text = Convert.ToString(count1);
                label11.Text = Convert.ToString(count2);
            }

            try
            {
                xmin = Convert.ToDouble(textBox1.Text);
                xmax = Convert.ToDouble(textBox2.Text);
                dx = Convert.ToDouble(textBox3.Text);



                if (xmin > xmax)
                {
                    MessageBox.Show("xmin > xmax", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    Func();

                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Input is invalid!");
            }
        }

    }

}