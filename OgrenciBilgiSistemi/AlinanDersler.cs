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
    public partial class AlinanDersler : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter dr;
        MySqlDataReader dx;
        public string ogrno { get; set; }
        public AlinanDersler()
        {
            InitializeComponent();
        }

        private void AlinanDersler_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ders.DersNo,ogrenci.OgrNo,ogrenci.isim,ogrenci.SoyIsim,ders.DersIsim FROM alinandersler INNER JOIN ogrenci ON alinandersler.ogrNo = ogrenci.OgrNo " +
                "INNER JOIN ders ON alinandersler.dersNo = ders.DersNo WHERE ogrenci.OgrNo = '" + ogrno + "'";
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
