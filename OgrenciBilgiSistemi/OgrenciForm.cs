using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciBilgiSistemi
{
    public partial class OgrenciForm : Form
    {
        public string ogrenciNo { get; set; }

        public string isim { get; set; }

        public string SoyIsim { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string TcNo { get; set; }

        public OgrenciForm()
        {
            InitializeComponent();
        }

        private void OgrenciForm_Load(object sender, EventArgs e)
        {
            label7.Text = ogrenciNo;
            label8.Text = TcNo;
            label9.Text = isim;
            label10.Text = SoyIsim;
            label11.Text = Mail;
            label12.Text = Telefon;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            VizeDurum vize = new VizeDurum();
            vize.ogrno = ogrenciNo;
            vize.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalDurum final = new FinalDurum();
            final.ogrno = ogrenciNo;
            final.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlinanDersler alinanDers = new AlinanDersler();
            alinanDers.ogrno = ogrenciNo;
            alinanDers.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            DialogResult result1 = MessageBox.Show("Cikis yapmak istediginizden emin misiniz?", "Uygulama Çıkış", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                f1.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VizeOrtalamaGoruntule vizeort = new VizeOrtalamaGoruntule();
            vizeort.ogrno = ogrenciNo;
            vizeort.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FinalOrtalamaGoster finalort = new FinalOrtalamaGoster();
            finalort.ogrno = ogrenciNo;
            finalort.Show();
            this.Close();
        }
    }
}
