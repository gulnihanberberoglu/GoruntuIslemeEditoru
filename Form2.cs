using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Goruntu_Isleme_Uygulaması
{
    public partial class Form2 : Form
    {
        public int Genislik { get; set; }
        public int Yukseklik { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Genislik = Convert.ToInt32(textBox1.Text);
            Yukseklik = Convert.ToInt32(textBox2.Text);
            Close();
        }

        
    }
}
