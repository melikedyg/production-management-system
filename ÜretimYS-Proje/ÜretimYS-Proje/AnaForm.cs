using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÜretimYS_Proje
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCalisan_Click(object sender, EventArgs e)
        {
            Çalışan cls = new Çalışan();
            cls.Show();
            this.Hide();
        }

        private void btnRecete_Click(object sender, EventArgs e)
        {
            Reçete rt = new Reçete();
            rt.Show();
            this.Hide();
        }

        private void btnIstasyon_Click(object sender, EventArgs e)
        {
            İşİstasyonu ist = new İşİstasyonu();
            ist.Show();
            this.Hide();
        }

        private void btnOperasyon_Click(object sender, EventArgs e)
        {
            Operasyon opr = new Operasyon();
            opr.Show();
            this.Hide();
        }
    }
}
