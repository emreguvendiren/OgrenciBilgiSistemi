using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace OgrenciBilgiSistemi
{
    public partial class OgrenciEkle : Form
    {
        MySqlDataReader dr;
        MySqlConnection con;
        MySqlCommand cmd;
        public string hocasicilNo { get; set; }
        public OgrenciEkle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgretmenForm ogrForm = new OgretmenForm();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ogretmenler WHERE hocaSicilNo = '" + hocasicilNo + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string sicilNo = dr.GetString(0);
                ogrForm.ogrSicilNo = sicilNo;               
                ogrForm.isim = dr.GetString(1);
                ogrForm.soyIsim = dr.GetString(2);
                ogrForm.mail = dr.GetString(3);
                ogrForm.telefon = dr.GetString(4);
                ogrForm.fotoPath = dr.GetString(6);
                ogrForm.Show();
                this.Close();
            }
            con.Close();

        }

        private void OgrenciEkle_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgretmenForm ogrForm = new OgretmenForm();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "INSERT INTO ogrenci(OgrNo,isim,SoyIsim,Telefon,Mail,TcNo) VALUES('" + txtOgrNo.Text + "','" + txtIsim.Text + "','" + txtSoyIsim.Text + "','" + txtTelefon.Text + "','" + txtMail.Text + "','" + txtTc.Text + "')";
                dr = cmd.ExecuteReader();
                MessageBox.Show("Kayit Basarili!");
            }
            catch (Exception)
            {

                MessageBox.Show("Girilen Verileri Gozden Geciriniz");
            }
            con.Close();

        }
    }
}
