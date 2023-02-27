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
    public partial class OgrenciSil : Form
    {
        MySqlDataReader dr;
        MySqlConnection con;
        MySqlCommand cmd;
        public string hocaSicilNo { get; set; }
        public OgrenciSil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string ogrNo = txtNumara.Text;
                string TC = txtTc.Text;
                //int ogrNo = Convert.ToInt32(txtNumara.Text);
                //int TC = Convert.ToInt32(txtTc.Text);
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM ogrenci WHERE OgrNo = '" + ogrNo + "' AND TcNo = '" + TC + "'";
                dr = cmd.ExecuteReader();
                
                try
                {

                    dr = cmd.ExecuteReader();
                    MessageBox.Show("Bilgileri Kontrol Ediniz!");
                }
                catch (Exception)
                {

                    MessageBox.Show("Ogrenci Basariyla Silindi!");
                }
                
            }
            else
            {
                MessageBox.Show("Lutfen bilgilerin dogru oldugunu teyit edip isaretleyiniz.");
            }
            con.Close();
        }

        private void OgrenciSil_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgretmenForm ogrForm = new OgretmenForm();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ogretmenler WHERE hocaSicilNo = '" + hocaSicilNo + "'";
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
