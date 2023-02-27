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
    public partial class DersGirisiYap : Form
    {
        MySqlDataReader dx;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter dr;
        public string hocasicilNo { get; set; }
        public DersGirisiYap()
        {
            InitializeComponent();
        }

        private void DersGirisiYap_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ogrenci.ogrno,ogrenci.isim,ogrenci.soyisim FROM ogrenci";
            dr = new MySqlDataAdapter(cmd);
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
            cmd = new MySqlCommand();
            MySqlDataReader dv;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ogrenci WHERE ogrno = '"+textBox1.Text+"'";
            dx = cmd.ExecuteReader();
            if (dx.Read())
            {
                con.Close();
                if (comboBox1.Text.ToString() != "")
                {
                    cmd = new MySqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO alinandersler(dersNo,ogrNo) VALUES('"+comboBox1.Text.ToString()+"','"+textBox1.Text+"')";
                    
                    try
                    {
                        dv = cmd.ExecuteReader();
                        MessageBox.Show("Ders girisi yapildi");
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Beklenmeyen bir hata olustu!");
                    }
                }
                else
                {
                    MessageBox.Show("Lutfen ders seciniz!");
                }
            }
            else
            {
                MessageBox.Show("Lutfen dogru bir ogrenci numarasi yaziniz.");
                con.Close();
            }
            con.Close();
        }
    }
}
