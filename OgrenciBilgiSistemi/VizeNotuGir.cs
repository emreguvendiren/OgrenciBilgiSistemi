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
    public partial class VizeNotuGir : Form
    {
        MySqlDataAdapter dr;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dx;
        public string hocasicilNo { get; set; }
        public VizeNotuGir()
        {
            InitializeComponent();
        }

        private void VizeNotuGir_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ders";
            dr = new MySqlDataAdapter(cmd);
            //dx = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ders";
            dx = cmd.ExecuteReader();
            while (dx.Read())
            {
                comboBox1.Items.Add(dx.GetString(0));
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgretmenForm ogrForm = new OgretmenForm();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ogretmenler WHERE hocaSicilNo = '" + hocasicilNo + "'";
            dx = cmd.ExecuteReader();
            if (dx.Read())
            {
                string sicilNo = dx.GetString(0);
                ogrForm.ogrSicilNo = sicilNo;
                ogrForm.isim = dx.GetString(1);
                ogrForm.soyIsim = dx.GetString(2);
                ogrForm.mail = dx.GetString(3);
                ogrForm.telefon = dx.GetString(4);
                ogrForm.fotoPath = dx.GetString(6);
                ogrForm.Show();
                this.Hide();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataReader dd;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM alinandersler WHERE ogrNo = '" + textBox1.Text + "' AND dersNo = '" + comboBox1.Text.ToString() +"'";
            dd = cmd.ExecuteReader();
            if (dd.Read())
            {
                con.Close();
            
            MySqlDataReader d;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ogrenci WHERE OgrNo = '" + textBox1.Text + "'";
            d = cmd.ExecuteReader();
            if (d.Read())
            {
                if (comboBox1.Text.ToString() != "")
                {
                    string dersKodu = comboBox1.Text.ToString();
                    try
                    {
                        int Vize = Convert.ToInt32(textBox2.Text);
                        if (Vize>100 || Vize<0)
                        {
                            MessageBox.Show("Lutfen 0-100 arasinda bir not giriniz.");
                        }
                        else
                        {
                            con.Close();
                            con.Open();
                            MySqlDataReader de;
                            cmd = new MySqlCommand();
                            cmd.Connection = con;
                            cmd.CommandText= "INSERT INTO vize(ogrNo,dersNo,VizeNotu) VALUES ('"+textBox1.Text+"','"+dersKodu+"','"+Vize+"')";
                            try
                            {
                                de = cmd.ExecuteReader();
                                MessageBox.Show("Vize Notu Girildi.");
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("Beklenmeyen Bir Hata Olustu");
                            }
                            con.Close();
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Lutfen gecerli bir not giriniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lutfen ders kodu seciniz");
                }
            }
            else
            {
                MessageBox.Show("Ogrenci numarasi bulunamadi!");
            }
            con.Close();
            }
            else
            {
                MessageBox.Show("Ogrenci dersi almiyor.");
                con.Close();
            }
        }
    }
}
