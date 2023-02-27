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
    public partial class OgretmenForm : Form
    {
        public string ogrSicilNo { get; set; }

        public string isim { get; set; }

        public string soyIsim { get; set; }

        public string mail { get; set; }

        public string telefon { get; set; }

        public string fotoPath { get; set; }

        public OgretmenForm()
        {
            
            InitializeComponent();
            
        }

        private void OgretmenForm_Load(object sender, EventArgs e)
        {
            lblIsim.Text = isim;
            lblSoyIsim.Text = soyIsim;
            lblTelefon.Text = telefon;
            lblMail.Text = mail;
            pictureBox1.Image = Image.FromFile(@fotoPath);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            OgrenciEkle ogrEkle = new OgrenciEkle();
            ogrEkle.hocasicilNo = ogrSicilNo;
            ogrEkle.Show();
            this.Close();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            OgrenciSil ogrSil = new OgrenciSil();
            ogrSil.hocaSicilNo = ogrSicilNo;
            ogrSil.Show();
            this.Close();
        }

        private void btnUpdateStudy_Click(object sender, EventArgs e)
        {
            OgrenciGuncelle ogrGuncelle = new OgrenciGuncelle();
            ogrGuncelle.hocasicilNo = ogrSicilNo;
            ogrGuncelle.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            DialogResult result1 = MessageBox.Show("Cikis yapmak istediginizden emin misiniz?","Uygulama Çıkış", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                f1.Show();
                this.Hide();
            }
            
            /*f1.Show();
            this.Hide();*/
        }

        private void btnVize_Click(object sender, EventArgs e)
        {
            VizeNotuGir vize = new VizeNotuGir();
            vize.hocasicilNo = ogrSicilNo;
            vize.Show();
            this.Close();
        }

        private void btnFinal_Click(object sender, EventArgs e)
        {
            FinalNotuGir final = new FinalNotuGir();
            final.hocasicilNo = ogrSicilNo;
            final.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DersEkle ders = new DersEkle();
            ders.hocasicilNo = ogrSicilNo;
            ders.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DersGirisiYap ders = new DersGirisiYap();
            ders.hocasicilNo = ogrSicilNo;
            ders.Show();
            this.Close();
        }
    }
}
