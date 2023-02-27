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
    public partial class DersEkle : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public string hocasicilNo { get; set; }
        public DersEkle()
        {
            InitializeComponent();
        }

        private void DersEkle_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (textBox1.Text !="")
                {
                    if (textBox2.Text != "")
                    {
                        cmd = new MySqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO ders(DersNo,DersIsim) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";
                        try
                        {
                            dr = cmd.ExecuteReader();
                            MessageBox.Show("Ders Basariyla Eklendi");

                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Beklenmeyen Bir Hata Olustu!");
                        }
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lutfen bos bilgi birakmayiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Lutfen bos bilgi birakmayiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lutfen kutucugu isaretleyiniz!");
            }
        }
    }
}
