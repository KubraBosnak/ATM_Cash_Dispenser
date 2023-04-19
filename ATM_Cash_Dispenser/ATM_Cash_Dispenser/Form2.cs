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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string hesap;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-I9TTNVF;Initial Catalog=DbATMCashDispenser;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            lblHesapNo.Text = hesap;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLKISILER WHERE HESAPNO = @P1", baglanti);
            komut.Parameters.AddWithValue("@P1", hesap);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAd.Text = dr[1] + " " + dr[2];
                lblTC.Text = dr[3].ToString();
                lblTelefon.Text = dr[4].ToString();
            }
            baglanti.Close();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            // Gönderilen Hesabın Para Artışı
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE TBLHESAP SET BAKIYE=BAKIYE+@P1 WHERE HESAPNO=@P2",baglanti);
            komut.Parameters.AddWithValue("@P1", decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@P2", mskHesapNo.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            // Gönderen Hesabın Para Azalışı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("UPDATE TBLHESAP SET BAKIYE= BAKIYE-@K1 WHERE HESAPNO=@K2",baglanti);
            komut2.Parameters.AddWithValue("@K1", decimal.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@K2", hesap);
            komut2.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("İşlem gerçekleşti");

        }

        private void btnHareketler_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }
    }
}
