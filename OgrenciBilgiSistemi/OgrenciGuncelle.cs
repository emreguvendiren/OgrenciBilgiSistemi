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
    public partial class OgrenciGuncelle : Form
    {
        MySqlDataReader dr;
        MySqlConnection con;
        MySqlCommand cmd;
        public string hocasicilNo { get; set; }
        public OgrenciGuncelle()
        {
            InitializeComponent();
        }

        private void OgrenciGuncelle_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                if (checkBox1.Checked)
                {

                
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM ogrenci WHERE OgrNo = '"+textBox1.Text+"'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    switch (comboBox1.SelectedItem.ToString())
                    {
                        case "Numara":
                            cmd = new MySqlCommand();
                            MySqlDataReader dx;
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE ogrenci SET OgrNo = '" + textBox3.Text +"' WHERE OgrNo = '"+textBox1.Text+"' AND TcNo = '"+textBox2.Text+"'";
                            try
                            {
                                dx = cmd.ExecuteReader();
                                MessageBox.Show("Guncelleme Basarili");
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("Beklenmeyen Bir hata Olustu");
                            }
                            con.Close();
                            break;
                        case "Isim":
                            cmd = new MySqlCommand();
                            MySqlDataReader dc;
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE ogrenci SET isim = '" + textBox3.Text + "' WHERE OgrNo = '" + textBox1.Text + "' AND TcNo = '" + textBox2.Text + "'";
                            try
                            {
                                dc = cmd.ExecuteReader();
                                MessageBox.Show("Guncelleme Basarili");
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("Beklenmeyen Bir hata Olustu");
                            }
                            con.Close();
                            break;
                        case "Soy Isim":
                            cmd = new MySqlCommand();
                            MySqlDataReader dv;
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE ogrenci SET SoyIsim = '" + textBox3.Text + "' WHERE OgrNo = '" + textBox1.Text + "' AND TcNo = '" + textBox2.Text + "'";
                            try
                            {
                                dv = cmd.ExecuteReader();
                                MessageBox.Show("Guncelleme Basarili");
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("Beklenmeyen Bir hata Olustu");
                            }
                            con.Close();
                            break;
                        case "Telefon":
                            cmd = new MySqlCommand();
                            MySqlDataReader db;
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE ogrenci SET Telefon = '" + textBox3.Text + "' WHERE OgrNo = '" + textBox1.Text + "' AND TcNo = '" + textBox2.Text + "'";
                            try
                            {
                                db = cmd.ExecuteReader();
                                MessageBox.Show("Guncelleme Basarili");
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("Beklenmeyen Bir hata Olustu");
                            }
                            con.Close();
                            break;
                        case "Mail":
                            cmd = new MySqlCommand();
                            MySqlDataReader du;
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE ogrenci SET Mail = '" + textBox3.Text + "' WHERE OgrNo = '" + textBox1.Text + "' AND TcNo = '" + textBox2.Text + "'";
                            try
                            {
                                du = cmd.ExecuteReader();
                                MessageBox.Show("Guncelleme Basarili");
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("Beklenmeyen Bir hata Olustu");
                            }
                            con.Close();
                            break;
                        case "Tc Kimlik Numarasi":
                            cmd = new MySqlCommand();
                            MySqlDataReader da;
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE ogrenci SET TcNo = '" + textBox3.Text + "' WHERE OgrNo = '" + textBox1.Text + "' AND TcNo = '" + textBox2.Text + "'";
                            try
                            {
                                da = cmd.ExecuteReader();
                                MessageBox.Show("Guncelleme Basarili");
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("Beklenmeyen Bir hata Olustu");
                            }
                            con.Close();
                            break;
                        default:
                            break;
                    }
                    //cmd = new MySqlCommand();
                    //MySqlDataReader dx;
                    //con.Open();

                }
                else
                {
                    MessageBox.Show("Ogrenci Numarasi Bulunamadi");
                    con.Close();
                }
                }
                else
                {
                    MessageBox.Show("Lutfen Kutucugu Isaretleyin.");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Lutfen Degistirilecek Degeri Seciniz");
            }
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
                this.Hide();
            }
            con.Close();
        }
    }
}
