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
    public partial class Çalışan : Form
    {
        public Çalışan()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-9VQH2CNH\\SQLEXPRESS;Initial Catalog=UYS;Integrated Security=True");
        
         
        private void ÇalışanT_Load(object sender, EventArgs e)
        {

           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand ekle = new SqlCommand("insert into Calisan(Tc,AdSoyad,Görev,BrSMaliyet,AyMaliyet)values(@Tc,@AdSoyad,@Grv,@BrSMaliyet,@AyMaliyet)", baglan);
            ekle.Parameters.AddWithValue("@Tc", textBox1.Text);
            ekle.Parameters.AddWithValue("@AdSoyad", textBox2.Text);
            ekle.Parameters.AddWithValue("@Grv", textBox3.Text);
            ekle.Parameters.AddWithValue("@BrSMaliyet", textBox4.Text);
            ekle.Parameters.AddWithValue("@AyMaliyet", textBox5.Text);
            
            ekle.ExecuteNonQuery();
            MessageBox.Show("Çalışan eklendi..");
            baglan.Close();
        
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("select*from Calisan", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sil = new SqlCommand("delete from Calisan  where Tc=@Tc", baglan);
            sil.Parameters.AddWithValue("@Tc", textBox1.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Çalışan kaydı silindi..");
            baglan.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand guncelle = new SqlCommand("update Calisan set AdSoyad=@AdSoyad,Görev=@Grv,BrSMaliyet=@BrSMaliyet,AyMaliyet=@AyMaliyet where Tc=@Tc", baglan);
            guncelle.Parameters.AddWithValue("@Tc", textBox1.Text);
            guncelle.Parameters.AddWithValue("@AdSoyad", textBox2.Text);
            guncelle.Parameters.AddWithValue("@Grv", textBox3.Text);
            guncelle.Parameters.AddWithValue("@BrSMaliyet", textBox4.Text);
            guncelle.Parameters.AddWithValue("@AyMaliyet", textBox5.Text);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Çalışan kaydı güncellendi..");
            baglan.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
           
        }

       
    }
}
