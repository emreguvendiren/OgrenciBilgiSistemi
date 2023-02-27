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
    public partial class FinalOrtalamaGoster : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter dx;
        MySqlDataReader dr;
        MySqlDataReader d;
        public string ogrno { get; set; }
        public FinalOrtalamaGoster()
        {
            InitializeComponent();
        }

        private void FinalOrtalamaGoster_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=ogrencibilgisistemi;user=root;Pwd=667130Emre.;SslMode=none");
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("DersIsim", typeof(string));
            dt.Columns.Add("Ortalama", typeof(float));
            dataGridView1.DataSource = dt;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT dersNo FROM alinandersler WHERE ogrNo = '" + ogrno + "'";
            dx = new MySqlDataAdapter(cmd);
            int sayac = 0;
            List<string> alinanDersler = new List<string>();
            DataTable dyeni = new DataTable();
            dx.Fill(dyeni);
            try
            {
                while (true)
                {
                    alinanDersler.Add(dyeni.Rows[sayac][0].ToString());
                    sayac++;
                }


            }
            catch (Exception)
            {

                int x = 0;
            }
            con.Close();

            DataTable d = new DataTable();
            foreach (var item in alinanDersler)
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT ders.DersNo,ders.DersIsim,avg(finalnotu) as FinalNotu FROM final INNER JOIN ders on ders.DersNo = final.dersNo WHERE ders.DersNo = '" + item + "' group by dersIsim";

                dx = new MySqlDataAdapter(cmd);
                dx.Fill(d);
                dataGridView1.DataSource = d;
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciForm ogrenciForm = new OgrenciForm();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ogrenci WHERE OgrNo = '" + ogrno + "'";
            d = cmd.ExecuteReader();
            if (d.Read())
            {
                ogrenciForm.ogrenciNo = d["OgrNo"].ToString();
                ogrenciForm.isim = d["isim"].ToString();
                ogrenciForm.SoyIsim = d["SoyIsim"].ToString();
                ogrenciForm.Telefon = d["Telefon"].ToString();
                ogrenciForm.Mail = d["Mail"].ToString();
                ogrenciForm.TcNo = d["TcNo"].ToString();
                ogrenciForm.Show();
                this.Close();
            }
            con.Close();
        }
    }
}
