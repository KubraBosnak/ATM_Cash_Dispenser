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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-I9TTNVF;Initial Catalog=DbATMCashDispenser;Integrated Security=True");
        private void Form4_Load(object sender, EventArgs e)
        {
          
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLHAREKET", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
