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
    public partial class Form1 : Form
    {
        MySqlDataReader dr;
        MySqlConnection con;
        MySqlCommand cmd;
        static string username;
        static string password;
        public string sicilNo;
        public Form1()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgretmenForm ogrForm = new OgretmenForm();
            OgrenciEkle ogrEkle = new OgrenciEkle();
            OgrenciForm ogrenciForm = new OgrenciForm();
            username = textBox1.Text;
            password = textBox2.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ogretmenler WHERE hocaSicilNo = '" + username + "' AND sifre = '" + password + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sicilNo = dr.GetString(0);
                ogrForm.ogrSicilNo = sicilNo;
                ogrEkle.hocasicilNo = sicilNo;
                ogrForm.isim = dr.GetString(1);
                ogrForm.soyIsim = dr.GetString(2);
                ogrForm.mail = dr.GetString(3);
                ogrForm.telefon = dr.GetString(4);
                ogrForm.fotoPath = dr.GetString(6);
                MessageBox.Show("Hos Geldiniz " + dr.GetString(1)+ " " + dr.GetString(2));
                ogrForm.Show();
                this.Hide();
                
            }
            else
            {
                con.Close();
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM ogrenci WHERE OgrNo = '" + textBox1.Text + "' AND TcNo = '" + textBox2.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Hos Geldiniz " + dr["isim"] + " " + dr["SoyIsim"]);
                    ogrenciForm.ogrenciNo = dr["OgrNo"].ToString();
                    ogrenciForm.isim = dr["isim"].ToString();
                    ogrenciForm.SoyIsim = dr["SoyIsim"].ToString();
                    ogrenciForm.Telefon = dr["Telefon"].ToString();
                    ogrenciForm.Mail = dr["Mail"].ToString();
                    ogrenciForm.TcNo = dr["TcNo"].ToString();
                    ogrenciForm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Giris Basarisiz");
                }

                
            }
            con.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
