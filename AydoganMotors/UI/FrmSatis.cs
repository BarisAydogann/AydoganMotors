using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AydoganMotors.UI
{
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }
        public Satis Satis { get; set; }
        public bool Güncelleme { get; set; } = false;
        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (nmFiyat.Value == 0)
            {
                errorProvider1.SetError(nmFiyat, "Lütfen fiyat giriniz!");
                nmFiyat.Focus();
                return;

            }
            else
            {
                errorProvider1.SetError(nmFiyat, "");
            }

            Satis.Tarih = dtTarih.Value;
            Satis.Fiyat = (double)nmFiyat.Value;
            Satis.AracID = Guid.Parse(txtArac.Text);
            Satis.MusteriID = Guid.Parse(txtMusteri.Text);
            

            DialogResult = DialogResult.OK;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
           
            DialogResult = DialogResult.Cancel;
        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            txtID.Text = Satis.ID.ToString();
            if (Güncelleme)
            {
                txtMusteri.Text = Satis.MusteriID.ToString();
                txtArac.Text = Satis.AracID.ToString();
                nmFiyat.Value = (decimal)Satis.Fiyat;
                dtTarih.Value = Satis.Tarih;
            }
        }

        private void btnMusteriSec_click(object sender, EventArgs e)
        {
            Musteriler frm = new Musteriler();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtMusteri.Text = frm.Musteri.ID.ToString();
            }
        }

        private void btnAracSec_clik(object sender, EventArgs e)
        {
            Araclar frm = new Araclar();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtArac.Text = frm.Arac.ID.ToString();
            }
        }
    }
}
