using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_Cash_Dispenser
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-I9TTNVF;Initial Catalog=DbATMCashDispenser;Integrated Security=True");

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLKISILER (AD, SOYAD, TC, TELEFON, HESAPNO, SIFRE) VALUES (@P1, @P2, @P3, @P4, @P5, @P6)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", mskTC.Text);
            komut.Parameters.AddWithValue("@P4", mmskTelefon.Text);
            komut.Parameters.AddWithValue("@P5", mskHesapNo.Text);
            komut.Parameters.AddWithValue("@P6", txtSifre.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("INSERT INTO TBLHESAP (HESAPNO) VALUES (@P7)", baglanti);
            komut2.Parameters.AddWithValue("@P7", mskHesapNo.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Müşteri bilgileri sisteme kaydedildi.");
        }

        private void btnHesapNo_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(100000, 1000000);
            mskHesapNo.Text = sayi.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTC.Text = "";
            mmskTelefon.Text = "";
            mskHesapNo.Text = "";
            txtSifre.Text = "";
        }
    }
}
