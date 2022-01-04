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
    public partial class Operasyon : Form
    {
        public Operasyon()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-9VQH2CNH\\SQLEXPRESS;Initial Catalog=UYS;Integrated Security=True");
        private void Operasyon_Load(object sender, EventArgs e)
        {
        
            SqlCommand komut = new SqlCommand("select*from Istasyon",baglan);
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr["istasyonlar"]);
                comboBox2.Items.Add(dr["istasyonSüreleri"]);
            }
            baglan.Close();


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            baglan.Open();
            SqlCommand ekle = new SqlCommand("insert into Operasyon(OprKodu,TopSure,islemSure,BeklemeSure,TasimaSure,Aciklama,istasyonBağlantıları,istasyonSüreleri)values(@OprKodu,@TopSure,@islemSure,@BSure,@TSure,@Aciklama,@baglanti,@iSure)", baglan);
            ekle.Parameters.AddWithValue("@OprKodu", textBox1.Text);
            ekle.Parameters.AddWithValue("@TopSure", textBox2.Text);
            ekle.Parameters.AddWithValue("@islemSure", textBox3.Text);
            ekle.Parameters.AddWithValue("@BSure", textBox4.Text);
            ekle.Parameters.AddWithValue("@TSure", textBox5.Text);
            ekle.Parameters.AddWithValue("@Aciklama", textBox6.Text);
            ekle.Parameters.AddWithValue("baglanti", comboBox1.Text);
            ekle.Parameters.AddWithValue("@iSure", comboBox2.Text);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Operasyon kaydı eklendi..");
            baglan.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Operasyon", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
    }
}
