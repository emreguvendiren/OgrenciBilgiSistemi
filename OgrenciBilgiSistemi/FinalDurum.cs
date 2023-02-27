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
    public partial class FinalDurum : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter dr;
        MySqlDataReader dx;
        public string ogrno { get; set; }
        public FinalDurum()
        {
            InitializeComponent();
        }

        private void FinalDurum_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");

            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ogrenci.ogrNo,ogrenci.isim,ogrenci.SoyIsim,ders.DersIsim,final.FinalNotu FROM final INNER JOIN ders ON final.dersNo = ders.DersNo " +
                "INNER JOIN ogrenci ON final.ogrNo = ogrenci.OgrNo WHERE ogrenci.ogrNo = '" + ogrno + "'";
            dr = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciForm ogrenciForm = new OgrenciForm();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ogrenci WHERE OgrNo = '" + ogrno + "'";
            dx = cmd.ExecuteReader();
            if (dx.Read())
            {
                ogrenciForm.ogrenciNo = dx["OgrNo"].ToString();
                ogrenciForm.isim = dx["isim"].ToString();
                ogrenciForm.SoyIsim = dx["SoyIsim"].ToString();
                ogrenciForm.Telefon = dx["Telefon"].ToString();
                ogrenciForm.Mail = dx["Mail"].ToString();
                ogrenciForm.TcNo = dx["TcNo"].ToString();
                ogrenciForm.Show();
                this.Close();
            }
            con.Close();
        }
    }
}
