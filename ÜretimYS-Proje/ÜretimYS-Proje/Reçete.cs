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
    public partial class Reçete : Form
    {
        public Reçete()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-9VQH2CNH\\SQLEXPRESS;Initial Catalog=UYS;Integrated Security=True");

       
        private void Reçete_Load(object sender, EventArgs e)
        {
          
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand ekle = new SqlCommand("insert into Recete(UrunKod,Aciklama,Miktar,satirSayi)values(@UrunKod,@Aciklama,@Miktar,@satirSayi)", baglan);
            ekle.Parameters.AddWithValue("@UrunKod", textBox1.Text);
            ekle.Parameters.AddWithValue("@Aciklama", textBox2.Text);
            ekle.Parameters.AddWithValue("@Miktar", textBox3.Text);
            ekle.Parameters.AddWithValue("@satirSayi", textBox4.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Reçete eklendi..");
            baglan.Close();
            
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("select*from Recete", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sil = new SqlCommand("delete from Recete  where UrunKod=@UrunKod", baglan);
            sil.Parameters.AddWithValue("@UrunKod", textBox1.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Reçete kaydı silindi..");
            baglan.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand guncelle = new SqlCommand("update Recete set Aciklama=@Aciklama,Miktar=@Miktar,satirSayi=@satirSayi where UrunKod=@UrunKod", baglan);
            guncelle.Parameters.AddWithValue("@UrunKod", textBox1.Text);
            guncelle.Parameters.AddWithValue("@Aciklama", textBox2.Text);
            guncelle.Parameters.AddWithValue("@Miktar", textBox3.Text);
            guncelle.Parameters.AddWithValue("@satirSayi", textBox4.Text);

            guncelle.ExecuteNonQuery();
            MessageBox.Show("Reçete kaydı güncellendi..");
            baglan.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }
    }  
}
