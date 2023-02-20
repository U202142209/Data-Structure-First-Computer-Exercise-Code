using System;
using System.Windows.Forms;

namespace 数据结构第一次上机_复数
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Complex c1 = new Complex(
                    Convert.ToDouble(textBox1.Text),
                    Convert.ToDouble(textBox2.Text)
                    );
                Complex c2 = new Complex(
                    Convert.ToDouble(textBox3.Text),
                    Convert.ToDouble(textBox4.Text)
                    );
                Complex c3=new Complex();
                if (radioButton1.Checked)
                   c3 = c1 + c2;
                else if (radioButton2.Checked)
                    c3 = c1 - c2;
                else if (radioButton3.Checked)
                    c3 = c1 * c2;
                else if (radioButton4.Checked)
                    c3 = c1 / c2;
                MessageBox.Show("计算的结果是；\n" + c3.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show("发生了错误；\n" + error);
            }
        }
    }

    // 复数类
    class Complex
    {
        private double real;
        private double imag;

        // Default constructor
        public Complex()
        {
            real = 0;
            imag = 0;
        }

        // Constructor with real and imaginary parts
        public Complex(double r, double i)
        {
            real = r;
            imag = i;
        }

        // Copy constructor
        public Complex(Complex c)
        {
            real = c.real;
            imag = c.imag;
        }

        // Getters and setters for real and imaginary parts
        public double Real
        {
            get { return real; }
            set { real = value; }
        }

        public double Imag
        {
            get { return imag; }
            set { imag = value; }
        }

        // Addition operator overloading
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.real = c1.real + c2.real;
            result.imag = c1.imag + c2.imag;
            return result;
        }

        // Subtraction operator overloading
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.real = c1.real - c2.real;
            result.imag = c1.imag - c2.imag;
            return result;
        }

        // Multiplication operator overloading
        public static Complex operator *(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            result.real = c1.real * c2.real - c1.imag * c2.imag;
            result.imag = c1.real * c2.imag + c1.imag * c2.real;
            return result;
        }

        // Division operator overloading
        public static Complex operator /(Complex c1, Complex c2)
        {
            Complex result = new Complex();
            double denominator = c2.real * c2.real + c2.imag * c2.imag;
            result.real = (c1.real * c2.real + c1.imag * c2.imag) / denominator;
            result.imag = (c1.imag * c2.real - c1.real * c2.imag) / denominator;
            return result;
        }

        // Overriding ToString method for a better output representation
        public override string ToString()
        {
            string result;
            if (imag < 0)
            {
                result = String.Format("{0} - {1}i", real, Math.Abs(imag));
            }
            else
            {
                result = String.Format("{0} + {1}i", real, imag);
            }
            return result;
        }
    }
}
