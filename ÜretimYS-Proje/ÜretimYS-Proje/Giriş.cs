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


namespace ÜretimYS_Proje
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-9VQH2CNH\\SQLEXPRESS;Initial Catalog=UYS;Integrated Security=True");
        private void Giriş_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglan.Open();
            
            SqlCommand blg = new SqlCommand("Select* From Giris where Ad=@ad AND Sifre=@sfr", baglan);
            blg.Parameters.AddWithValue("@ad", txtAd.Text);
            blg.Parameters.AddWithValue("@sfr", txtSifre.Text);
            SqlDataReader rd = blg.ExecuteReader();
            if (rd.Read())
            {
                AnaForm anf = new AnaForm();
                anf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
            }
            
            baglan.Close();
        }
    }
}
