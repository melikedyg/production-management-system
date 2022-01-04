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
    public partial class İşİstasyonu : Form
    {
        public İşİstasyonu()
        {
            InitializeComponent();
        }
          SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-9VQH2CNH\\SQLEXPRESS;Initial Catalog=UYS;Integrated Security=True");
        private void İşİstasyonu_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand ekle = new SqlCommand("insert into Istasyon(istasyonKodu,Aciklama,Ambar,Maliyet,istasyonlar,istasyonSüreleri)values(@istKod,@Aciklama,@Ambar,@Maliyet,@istasyon,@Süre)", baglan);
            ekle.Parameters.AddWithValue("@istKod", textBox1.Text);
            ekle.Parameters.AddWithValue("@Aciklama", textBox2.Text);
            ekle.Parameters.AddWithValue("@Ambar", textBox3.Text);
            ekle.Parameters.AddWithValue("@Maliyet", textBox4.Text);
            ekle.Parameters.AddWithValue("@istasyon", textBox5.Text);
            ekle.Parameters.AddWithValue("@Süre", textBox6.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("İş İstasyon kaydı eklendi..");
            baglan.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("select*from Istasyon", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sil = new SqlCommand("delete from Istasyon  where istasyonKodu=@istKod", baglan);
            sil.Parameters.AddWithValue("@istKod", textBox1.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("İş İstasyon kaydı silindi..");
            baglan.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand guncelle = new SqlCommand("update Istasyon set Aciklama=@Aciklama,Ambar=@Ambar,Maliyet=@Maliyet,istasyonlar=@istasyon,istasyonSüreleri=@süre where istasyonKodu=@istKod", baglan);
            guncelle.Parameters.AddWithValue("@istKod", textBox1.Text);
            guncelle.Parameters.AddWithValue("@Aciklama", textBox2.Text);
            guncelle.Parameters.AddWithValue("@Ambar", textBox3.Text);
            guncelle.Parameters.AddWithValue("@Maliyet", textBox4.Text);
            guncelle.Parameters.AddWithValue("@istasyon", textBox5.Text);
            guncelle.Parameters.AddWithValue("@Süre", textBox6.Text);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("İş İstasyon kaydı güncellendi..");
            baglan.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}
