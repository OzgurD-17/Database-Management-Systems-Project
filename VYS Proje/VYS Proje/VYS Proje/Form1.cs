using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VYS_Proje
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 kisi = new Form2();
            kisi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 calisan = new Form3();
            calisan.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form17 uye = new Form17();
            uye.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form20 egitmen = new Form20();
            egitmen.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 uyelik = new Form5();
            uyelik.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form15 uyelikPaketi = new Form15();
            uyelikPaketi.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 odeme = new Form6();
            odeme.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form21 isci = new Form21();
            isci.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 sinifRezervasyon = new Form9();
            sinifRezervasyon.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form8 sinif = new Form8();
            sinif.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form18 sinifDers = new Form18();
            sinifDers.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form7 ders = new Form7();
            ders.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form13 antrenmanProgrami = new Form13();
            antrenmanProgrami.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form14 beslenmeProgrami = new Form14();
            beslenmeProgrami.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 ekipman = new Form4();
            ekipman.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form19 uyeEkipman = new Form19();
            uyeEkipman.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form11 yarisma = new Form11();
            yarisma.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form12 yarismayaKatilim = new Form12();
            yarismayaKatilim.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form10 degerlendirme = new Form10();
            degerlendirme.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form16 yoklama = new Form16();
            yoklama.Show();
        }
    }
}
