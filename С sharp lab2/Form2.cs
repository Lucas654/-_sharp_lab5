using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace С_sharp_lab2
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 f)
        {
            form1 = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.Empty != textBox1.Text && int.TryParse(textBox2.Text, out int k) && int.TryParse(textBox3.Text, out int costBuy) && int.TryParse(textBox4.Text, out int costForPeople))
            {
                Data.storage.storage.Add(new Product(textBox1.Text, k, costBuy, costForPeople));
                this.Close();
            }
            else
                MessageBox.Show("Некорректні дані");
        }
    }
}
